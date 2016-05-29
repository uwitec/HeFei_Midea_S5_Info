using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新抽空充注数据
    /// </summary>
    public class FlushSingleChouKongChongZhu:All.Class.FlushAll.FlushMethor
    {
        bool oldConn = true;
        public bool BlinkOne
        {
            get
            {
                if (oldConn != frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Conn)
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("抽空工位 {0} 通讯失败", ""), (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.抽空充注, "抽空工位 通讯失败", (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                    oldConn = frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Conn;
                }
                return !frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Conn || chouKongChongZhu.ErrorOne;
            }
        }
        public bool BlinkTwo
        {
            get
            {
                return !frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Conn || chouKongChongZhu.ErrorTwo;
            }
        }
        public System.Drawing.Color ColorOne
        {
            get
            {
                if (BlinkOne)
                {
                    return System.Drawing.Color.Purple;
                }
                if (chouKongChongZhu.AGongZuoZhuangTai == 0)
                {
                    return System.Drawing.Color.Green;
                }
                return System.Drawing.Color.Yellow;
            }
        }
        public System.Drawing.Color ColorTwo
        {
            get
            {
                if (BlinkTwo)
                {
                    return System.Drawing.Color.Purple;
                }
                if (chouKongChongZhu.BGongZuoZhuangTai == 0)
                {
                    return System.Drawing.Color.Green;
                }
                return System.Drawing.Color.Yellow;
            }
        }
        ChouKongChongZhu chouKongChongZhu = new ChouKongChongZhu();
        public override void Flush()
        {

            //保存实时数据
            chouKongChongZhu.AQuXian.SetValue(frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value, 20);
            chouKongChongZhu.BQuXian.SetValue(frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value, 25);
            chouKongChongZhu.AQuXian.QuXianKongZhi = frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[130];
            chouKongChongZhu.BQuXian.QuXianKongZhi = frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[131];

            //故障显示
            for (int i = 0; i < ChouKongChongZhu.AllErrorCount; i++)
            {
                chouKongChongZhu.SetErrorInfo(i,
                    frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[77 + i],
                    frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Info[77 + i]);
            }
            //要料信息
            for (int i = 0; i < chouKongChongZhu.Material.Length; i++)
            {
                chouKongChongZhu.SetMaterial(i, frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[127 + i]);
            }
            //工作状态
            chouKongChongZhu.AGongZuoZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[190];
            chouKongChongZhu.BGongZuoZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[191];
            //结果数据
            chouKongChongZhu.JiLuZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[192];

        }
        public override void Load()
        {
        }
        public class ChouKongChongZhu
        {
            /// <summary>
            /// A工作状态
            /// </summary>
            public ushort AGongZuoZhuangTai
            { get; set; }
            /// <summary>
            /// B工作状态
            /// </summary>
            public ushort BGongZuoZhuangTai
            { get; set; }
            /// <summary>
            /// A实时曲线
            /// </summary>
            public ShiShiQuXian AQuXian
            { get; set; }
            /// <summary>
            /// B实时曲线
            /// </summary>
            public ShiShiQuXian BQuXian
            { get; set; }
            ushort jiLuZhuangTai = 0;

            public ushort JiLuZhuangTai
            {
                get { return jiLuZhuangTai; }
                set {
                    if (jiLuZhuangTai==0 &&  value == 1)
                    {
                        Save();
                    }
                    jiLuZhuangTai = value; 
                }
            }

            /// <summary>
            /// 当前是否有故障
            /// </summary>
            public bool ErrorOne
            {
                get
                {
                    for (int i = 0; i < 27; i++)//前面27个是A组故障
                    {
                        if (ErrorSingle[i])
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public bool ErrorTwo
            {
                get
                {
                    for (int i = 27; i < AllErrorCount; i++)
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
            /// 单个故障
            /// </summary>
            public bool[] ErrorSingle
            { get; set; }
            /// <summary>
            /// 要料信息
            /// </summary>
            public string[] Material
            { get; set; }
            /// <summary>
            /// 故障个数
            /// </summary>
            public const int AllErrorCount = 53;

            public ChouKongChongZhu()
            {
                AQuXian = new ShiShiQuXian();
                BQuXian = new ShiShiQuXian();
                ErrorSingle = new bool[AllErrorCount];
                for (int i = 0; i < AllErrorCount; i++)
                {
                    ErrorSingle[i] = false;
                }
                Material = new string[5];
                for (int i = 0; i < Material.Length; i++)
                {
                    Material[i] = "";
                }
            }
            /// <summary>
            /// 显示故障信息
            /// </summary>
            /// <param name="index"></param>
            /// <param name="error"></param>
            /// <param name="info"></param>
            public void SetErrorInfo(int index, bool error, string info)
            {
                if (index < 0 || index >= ErrorSingle.Length)
                {
                    return;
                }
                if (ErrorSingle[index] != error)
                {
                    ErrorSingle[index] = error;
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("抽空工位 {0} 故障", info), (error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.抽空充注, info, error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
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
                        string.Format("delete from StatueMaterial where WorkStation={0}", index + 110));
                    if (material == "")
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'空',0,0,'{1:yyyy-MM-dd HH:mm:ss}','true')", index + 110, DateTime.Now));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'{1}',0,0,'{2:yyyy-MM-dd HH:mm:ss}','false')", index + 110, material, DateTime.Now));
                    }
                    Material[index] = material;
                }
            }
            public void Save()
            {
                frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Write<ushort>(0, 3);

                string tmpBarCode = "";
                string sheDingLiang = "";
                string shiJiLiang = "";
                string jieGuo = "";
                string leiXing = "";
                if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out tmpBarCode, 104))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out tmpBarCode, 104))
                    {
                        return;
                    }
                }
                if (tmpBarCode == "")
                {
                    return;
                }
                if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out sheDingLiang, 168))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out sheDingLiang, 168))
                    {
                        return;
                    }
                }
                if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out shiJiLiang, 232))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out shiJiLiang, 232))
                    {
                        return;
                    }
                }
                if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out jieGuo, 296))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out jieGuo, 296))
                    {
                        return;
                    }
                }
                if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out leiXing, 360))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Read<string>(out leiXing, 360))
                    {
                        return;
                    }
                }

                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(tmpBarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                sql.Write(string.Format("insert into TestChongZhu Values('{0}','{1}','{2}','{3}')",
                    sheDingLiang, shiJiLiang, jieGuo, leiXing));
                sql.Close();
            }
            public class ShiShiQuXian
            {
                public string BarCode
                { get; set; }
                public float[] Value
                { get; set; }
                bool quXianKongZhi = false;
                public bool QuXianKongZhi
                {
                    get { return quXianKongZhi; }
                    set {
                        if (value)
                        {
                            BarCode = frmMain.mMain.AllCars.AllStatueLineStation[29].BarCode;
                            Save();
                        }
                        else
                        {
                            BarCode = "";
                        }
                        quXianKongZhi = value; }
                }
                public ShiShiQuXian()
                {
                    BarCode = "";
                    Value = new float[5];
                }
                /// <summary>
                /// 设置值
                /// </summary>
                /// <param name="value"></param>
                /// <param name="start"></param>
                public void SetValue(List<float> value, int start)
                {
                    for (int i = 0, j = start; i < Value.Length && j < value.Count; i++, j++)
                    {
                        Value[i] = value[j];
                    }
                }
                /// <summary>
                /// 保存曲线 
                /// </summary>
                private void Save()
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
                    sql.Write(string.Format("insert into TestChouKong (Data1,Data2,Data3,Data4,Data5) values ({0},{1},{2},{3},{4})", Value[0],Value[1],Value[2],Value[3],Value[4]));
                    sql.Close();
                }
            }
        }
    }
}
