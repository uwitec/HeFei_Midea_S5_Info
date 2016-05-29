using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新检漏数据
    /// </summary>
    public class FlushSingleJianLou:All.Class.FlushAll.FlushMethor
    {
        bool oldConn = true;
        public bool Blink
        {
            get
            {
                if (oldConn != frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Conn)
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("氦检工位 {0} 通讯失败", ""), (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.真空氦检, "氦检工位 通讯失败", (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                    oldConn = frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Conn;
                }
                return jianLou.Error || (!frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Conn);
            }
        }
        public System.Drawing.Color Color
        {
            get
            {
                System.Drawing.Color result = System.Drawing.Color.Purple;
                if (Blink)
                {
                    return result;
                }
                switch (jianLou.GongZuoZhuangTai)
                {
                    case 0:
                        result = System.Drawing.Color.Green;
                        break;
                    default:
                        result = System.Drawing.Color.Yellow;
                        break;
                }
                return result;
            }
        }
        JianLou jianLou = new JianLou();
        int allErrorCount = 0;//所有故障总量，用于屏蔽爱发科设备的过多故障
        public override void Flush()
        {
            if (frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Conn)
            {
                allErrorCount = 0;
                //检测数据
                jianLou.SetValue(
                    (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[172] == 1),
                    frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[173],
                    frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[174],
                    frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[12],
                    frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[13],
                    frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[14]);
                jianLou.JiLuZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[171];

                //实时数据
                jianLou.ShiShiLouLv = frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[11];
                jianLou.GongZuoZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[170];

                //故障
                for (int i = 0; i < JianLou.AllErrorCount; i++)
                {
                    if (frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[i])
                    {
                        allErrorCount++;
                    }
                }
                if (allErrorCount < 20)//小于20个才认为是正常现象，一次性故障过多是他们自己的原因造成的
                {
                    for (int i = 0; i < JianLou.AllErrorCount; i++)
                    {
                        jianLou.SetErrorInfo(i, frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[i],
                            frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Info[i]);
                    }
                }
                //要料信息
                for (int i = 0; i < jianLou.Material.Length; i++)
                {
                    jianLou.SetMaterial(i, frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[117 + i]);
                }
            }
        }
        public override void Load()
        {

        }
        public class JianLou
        {
            /// <summary>
            /// 检漏结果
            /// </summary>
            public bool JieGuo
            { get; set; }
            /// <summary>
            /// 检测时间
            /// </summary>
            public int HaiJianShiJian
            { get; set; }
            /// <summary>
            /// 节拍时间
            /// </summary>
            public int ZongJiePai
            { get; set; }
            /// <summary>
            /// 序列号
            /// </summary>
            public float XuLieHao
            { get; set; }
            /// <summary>
            /// 真空度
            /// </summary>
            public float ZhenKongDu
            { get; set; }
            /// <summary>
            /// 漏率
            /// </summary>
            public float LouLv
            { get; set; }
            /// <summary>
            /// 实时漏率
            /// </summary>
            public float ShiShiLouLv
            { get; set; }

            ushort gongZuoZhuangTai = 0;
            string barCode = "";
            /// <summary>
            /// 工位状态
            /// </summary>
            public ushort GongZuoZhuangTai
            {
                get { return gongZuoZhuangTai; }
                set
                {
                    if (value == 6)
                    {
                        SaveTmp();
                    }
                    else
                    { barCode = ""; }
                    gongZuoZhuangTai = value;
                }
            }
            ushort jiLuZhuangTai = 0;
            /// <summary>
            /// 记录状态
            /// </summary>
            public ushort JiLuZhuangTai
            {
                get { return jiLuZhuangTai; }
                set {
                    if (jiLuZhuangTai == 0 && value == 1)//上升沿，记录一次数据
                    {
                        Save();
                    }
                    jiLuZhuangTai = value; }
            }
            /// <summary>
            /// 故障
            /// </summary>
            public bool Error
            {
                get
                {
                    for (int i = 0; i < ErrorSingle.Length; i++)
                    {
                        if (ErrorSingle[i])
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            /// <summary>
            /// 故障
            /// </summary>
            public bool[] ErrorSingle
            { get; set; }
            /// <summary>
            /// 故障个数
            /// </summary>
            public const int AllErrorCount = 30;

            public string[] Material
            { get; set; }
            public JianLou()
            {
                ErrorSingle = new bool[AllErrorCount];
                for (int i = 0; i < AllErrorCount; i++)
                {
                    ErrorSingle[i] = false;
                }
                Material = new string[5];
                for (int i = 0; i < Material.Length; i++)
                {
                    Material[i] = "空";
                }
            }
            /// <summary>
            /// 赋值
            /// </summary>
            /// <param name="barCode"></param>
            /// <param name="result"></param>
            /// <param name="testTime"></param>
            /// <param name="jiePai"></param>
            /// <param name="xuLieHao"></param>
            /// <param name="zhenKongDu"></param>
            /// <param name="louLv"></param>
            public void SetValue(bool result, int testTime, int jiePai, float xuLieHao, float zhenKongDu, float louLv)
            {
                this.JieGuo = result;
                this.HaiJianShiJian = testTime;
                this.ZongJiePai = jiePai;
                this.XuLieHao = xuLieHao;
                this.ZhenKongDu = zhenKongDu;
                this.LouLv = louLv;
            }
            /// <summary>
            /// 保存检测结果
            /// </summary>
            private void Save()
            {
                //记录状态为1时，记录数据，读到此状态后，将此状态复位
                frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Write<ushort>(0, 2);

                string tmpBarCode = "";
                if (!frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Read<string>(out tmpBarCode, 40))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Read<string>(out tmpBarCode, 40))
                    {
                        return;
                    }
                }
                if (tmpBarCode == "")
                {
                    return;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckLenNingFile(tmpBarCode), "AllLenNingValue.sdf", "", ""))
                {
                    return;
                }

                sql.Write(string.Format("insert into TestJianLou Values ('{0}',{1},{2},{3},{4},{5})",
                    JieGuo, HaiJianShiJian, ZongJiePai, XuLieHao, ZhenKongDu, LouLv));
                sql.Close();
            }
            /// <summary>
            /// 保存实时漏率
            /// </summary>
            private void SaveTmp()
            {
                if (barCode == "")
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Read<string>(out barCode, 40))
                    {
                        if (!frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Read<string>(out barCode, 40))
                        {
                            return;
                        }
                    }
                    if (barCode == "")
                    {
                        return;
                    }
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckLenNingFile(barCode), "AllLenNingValue.sdf", "", ""))
                {
                    return;
                }

                sql.Write(string.Format("insert into TestLouLv (LouLv) Values ({0:F10})",
                   ShiShiLouLv));
                sql.Close();
            }
            /// <summary>
            /// 刷新显示故障
            /// </summary>
            /// <param name="index"></param>
            /// <param name="error"></param>
            /// <param name="info"></param>
            public void SetErrorInfo(int index, bool error,string info)
            {
                if (index < 0 || index >= ErrorSingle.Length)
                {
                    return;
                }
                if (ErrorSingle[index] != error)
                {
                    ErrorSingle[index] = error;
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("氦检工位 {0} 故障", info), (error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.真空氦检, info, error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                }
            }
            /// <summary>
            /// 刷新物料呼叫
            /// </summary>
            /// <param name="index"></param>
            /// <param name="material"></param>
            public void SetMaterial(int index, string material)
            {
                if (Material[index] != material)
                {
                    frmMain.mMain.AllDataBase.WriteData.Write(
                        string.Format("delete from StatueMaterial where WorkStation={0}", index + 100));
                    if (material == "")
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'空',0,0,'{1:yyyy-MM-dd HH:mm:ss}','true')", index + 100, DateTime.Now));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'{1}',0,0,'{2:yyyy-MM-dd HH:mm:ss}','false')", index + 100, material, DateTime.Now));
                    }
                    Material[index] = material;
                }
            }
        }
    }
}
