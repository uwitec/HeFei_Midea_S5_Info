using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新注油机数据
    /// </summary>
    public class FlushSingleOil:All.Class.FlushAll.FlushMethor
    {
        bool oldConnect = true;
        bool oldGuanJi = false;
        bool oldGuZhang = false;
        /// <summary>
        /// 是否闪烁
        /// </summary>
        public bool Blink
        { get; set; }
        int errorCount = 0;
        DateTime lastStatueTime = DateTime.Now;
        /// <summary>
        /// 显示颜色
        /// </summary>
        public Color ShowColor
        {
            get
            {
                Color result = Color.Red;
                if (lastStatueTime != LastStatueTime)
                {
                    if (!oldConnect)
                    {
                        frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.注油机, FlushAllError.ChangeList.Del);

                        if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.注油机))
                        {
                            frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  通讯故障", "注油机"), FlushAllError.ChangeList.Del));
                        } oldConnect = true;
                    }
                    errorCount = 0;
                    lastStatueTime = LastStatueTime;
                }
                else
                {
                    errorCount++;
                    if (errorCount >= 6)
                    {
                        errorCount = 6;
                        Statue = 0;
                        Blink = true;
                        if (oldConnect)
                        {
                            frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.注油机, FlushAllError.ChangeList.Add);

                            if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.注油机))
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  通讯故障", "注油机"), FlushAllError.ChangeList.Add));
                            } 
                            oldConnect = false;
                        }
                        return Color.Purple;
                    }
                }
                switch (Statue)
                {
                    case 0:
                        Blink = true;
                        result = Color.Purple;
                        break;
                    case 1:
                        Blink = false;
                        result = Color.Blue;
                        break;
                    case 2:
                        Blink = false;
                        result = Color.Yellow;
                        break;
                    case 4:
                        Blink = false;
                        result = Color.Green;
                        break;
                    case 6:
                        Blink = true;
                        result = Color.Purple;
                        break;
                }

                if (Statue == 0)
                {
                    if (!oldGuanJi)
                    {
                        if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.注油机))
                        {
                            frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  已关机", "注油机"), FlushAllError.ChangeList.Add));
                        }
                        oldGuanJi = true;
                    }
                }
                else
                {
                    if (oldGuanJi)
                    {
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  已关机", "注油机"), FlushAllError.ChangeList.Del));
                        oldGuanJi = false;
                    }
                }
                if (Statue == 6)
                {
                    if (!oldGuZhang)
                    {
                        frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.注油机, FlushAllError.ChangeList.Add);

                        if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.注油机))
                        {
                            frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  出现故障", "注油机"), FlushAllError.ChangeList.Add));
                        }
                        oldGuZhang = true;
                    }
                }
                else
                {
                    if (oldGuZhang)
                    {
                        frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.注油机, FlushAllError.ChangeList.Del);
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  出现故障", "注油机"), FlushAllError.ChangeList.Del));
                        oldGuZhang = false;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 当前状态
        /// </summary>
        public int Statue
        { get; set; }
        /// <summary>
        /// 读取设备最后更新时间
        /// </summary>
        public DateTime LastStatueTime
        { get; set; }
        string dataFile = "";
        public FlushSingleOil()
        {
            Statue = 0;
        }
        public override  void Flush()
        {
            if (frmMain.mMain.AllDataBase.OilData != null
                && frmMain.mMain.AllDataBase.OilData.Conn.State == System.Data.ConnectionState.Open)
            {
                ConnectOkFlushData();
            }
            else
            {
                Blink = true;
                frmMain.mMain.AllDataBase.OilData = All.Class.DataReadAndWrite.GetData(dataFile, "OilData");
            }
        }
        private void ConnectOkFlushData()
        {
            //将8号地标数据写入到加油机
            frmMain.mMain.AllDataBase.OilData.Write(string.Format("update TestBarCode Set BarCode='{0}'", frmMain.mMain.AllCars.AllStatueLineStation[7].BarCode));
            using (DataTable dt = frmMain.mMain.AllDataBase.OilData.Read("select * from YBZT where 仪表地址=1"))
            {
                if (dt != null && dt.Rows.Count == 1)
                {
                    LastStatueTime = All.Class.Num.ToDateTime(dt.Rows[0]["更新时间"]);
                    Statue = All.Class.Num.ToInt(dt.Rows[0]["状态"]);
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.OilData.Read(string.Format("select top 2 * from YFYB where ID>{0} order by ID", frmMain.mMain.AllDataXml.LocalSingleFlush.OilIndex)))
            {
                if (dt != null && dt.Rows.Count > 1)//当有2条以上的记录时才添加，注油机开机会先放一条临时记录，所以要先屏蔽这个临时记录
                {
                    Oil tmpOil = new Oil();
                    tmpOil.FaLiaoShiJian = All.Class.Num.ToDateTime(dt.Rows[0]["发料时间"]);
                    tmpOil.FaPiaoHaoMa = All.Class.Num.ToString(dt.Rows[0]["发票号码"]);
                    tmpOil.BarCode = All.Class.Num.ToString(dt.Rows[0]["条码"]);
                    tmpOil.ShiBieMa = All.Class.Num.ToString(dt.Rows[0]["识别码"]);
                    tmpOil.GuiJiHao = All.Class.Num.ToString(dt.Rows[0]["轨迹号"]);
                    tmpOil.YouPin = All.Class.Num.ToString(dt.Rows[0]["油品"]);
                    tmpOil.ChengXuShu = All.Class.Num.ToInt(dt.Rows[0]["程序数"]);
                    tmpOil.DingLiangHeJi = All.Class.Num.ToFloat(dt.Rows[0]["定量合计"]);
                    tmpOil.ShiFaHeJi = All.Class.Num.ToFloat(dt.Rows[0]["实发合计"]);
                    tmpOil.GuoChengJieGuo = All.Class.Num.ToString(dt.Rows[0]["过程结果"]);
                    tmpOil.YiBiaoDiZhi = All.Class.Num.ToInt(dt.Rows[0]["仪表地址"]);
                    tmpOil.ZiDong = All.Class.Num.ToBool(dt.Rows[0]["自动"]);
                    tmpOil.LiuLiangXiShu = All.Class.Num.ToFloat(dt.Rows[0]["流量系数"]);
                    tmpOil.LeiXingMiaoShu = All.Class.Num.ToString(dt.Rows[0]["类型描述"]);
                    for (int i = 0; i < 10; i++)
                    {
                        tmpOil.DingLiang[i] = All.Class.Num.ToFloat(dt.Rows[0][string.Format("定量{0}", i + 1)]);
                        tmpOil.ShiFa[i] = All.Class.Num.ToFloat(dt.Rows[0][string.Format("实发{0}", i + 1)]);
                    }
                    tmpOil.Save();
                    frmMain.mMain.AllDataXml.LocalSingleFlush.OilIndex = All.Class.Num.ToInt(dt.Rows[0]["ID"]);
                    frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                }
            }
        }
        public override void Load()
        {
            dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());
        }
        #region//注油纪录
        public class Oil
        {
            public int ID
            { get; set; }
            public DateTime FaLiaoShiJian
            { get; set; }
            public string FaPiaoHaoMa
            { get; set; }
            public string BarCode
            { get; set; }
            public string ShiBieMa
            { get; set; }
            public string GuiJiHao
            { get; set; }
            public string YouPin
            { get; set; }
            public int ChengXuShu
            { get; set; }
            public double DingLiangHeJi
            { get; set; }
            public double ShiFaHeJi
            { get; set; }
            public string GuoChengJieGuo
            { get; set; }
            public int YiBiaoDiZhi
            { get; set; }
            public bool ZiDong
            { get; set; }
            public float LiuLiangXiShu
            { get; set; }
            public string LeiXingMiaoShu
            { get; set; }
            public float[] DingLiang
            { get; set; }
            public float[] ShiFa
            { get; set; }
            public Oil()
            {
                DingLiang = new float[10];
                ShiFa = new float[10];
            }
            public void Save()
            {
                if (BarCode == "")
                {
                    return;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(BarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                string str = "insert into TestOil Values('{0:yyyy-MM-dd HH:mm:ss}','{1}','{2}','{3}','{4}','{5}',{6},{7:f3},{8:f3},'{9}',{10},'{11}',{12:f3},'{13}'{14}{15})";
                string s = "";
                string d = "";
                for (int i = 0; i < DingLiang.Length; i++)
                {
                    d = string.Format("{0},{1:F3}", d, DingLiang[i]);
                }
                for (int i = 0; i < ShiFa.Length; i++)
                {
                    s = string.Format("{0},{1:F3}", s, ShiFa[i]);
                }
                str = string.Format(str, FaLiaoShiJian, FaPiaoHaoMa, BarCode, ShiBieMa, GuiJiHao, YouPin, ChengXuShu, DingLiangHeJi, ShiFaHeJi, GuoChengJieGuo, YiBiaoDiZhi, ZiDong, LiuLiangXiShu, LeiXingMiaoShu, d, s);
                sql.Write(str);
                sql.Close();
            }
        }
        #endregion
    }
}
