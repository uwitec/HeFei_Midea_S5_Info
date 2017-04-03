using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新充氦回收数据
    /// </summary>
    public class FlushSingleChongHaiHuiShou:All.Class.FlushAll.FlushMethor
    {
        bool oldConn = true;
        public bool Blink
        {
            get
            {
                if (oldConn != frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Conn)
                {
                    if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.氦检回收))
                    {
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("检大漏,氦检工位  通讯失败"), (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    }
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.氦检回收, "检大漏,氦检工位 通讯失败", (oldConn ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                    oldConn = frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Conn;
                }
                return haiJianHuiShou.Error || (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Conn);
            }
        }
        public System.Drawing.Color Color
        {
            get
            {
                if (Blink)
                {
                    return System.Drawing.Color.Purple;
                }
                if (haiJianHuiShou.AGongZuoZhuangTai == 0 &&
                    haiJianHuiShou.BGongZuoZhuangTai == 0)
                {
                    return System.Drawing.Color.Green;
                }
                return System.Drawing.Color.Yellow;
            }
        }
        HaiJianHuiShou haiJianHuiShou = new HaiJianHuiShou();
        public override void Flush()
        {
            //保存结果记录
            haiJianHuiShou.SetValue(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[178],
                frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[179],
                frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[180],
                frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[17],
                frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[18],
                frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[19]);
            haiJianHuiShou.JiLuZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[177];

            //保存A路实时数据
            haiJianHuiShou.ALuShiShiYaLi = frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[15];
            haiJianHuiShou.AGongZuoZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[175];

            //保存B路实时数据 
            haiJianHuiShou.BLuShiShiYaLi = frmMain.mMain.AllMeterData.AllReadValue.FloatValue.Value[16];
            haiJianHuiShou.BGongZuoZhuangTai = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[176];

            //故障显示
            for (int i = 0; i < HaiJianHuiShou.AllErrorCount; i++)
            {
                haiJianHuiShou.SetErrorInfo(i,
                    frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Value[30 + i],
                    frmMain.mMain.AllMeterData.AllReadValue.BoolValue.Info[30 + i]);
            }
            //要料信息
            for (int i = 0; i < haiJianHuiShou.Material.Length; i++)
            {
                haiJianHuiShou.SetMaterial(i, frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[122 + i]);
            }

        }
        public override void Load()
        {
        }
        public class HaiJianHuiShou
        {
            public string BarCode
            { get; set; }
            ushort aGongZuoZhuangTai = 0;
            string aBarCode = "";
            /// <summary>
            /// A工位状态
            /// </summary>
            public ushort AGongZuoZhuangTai
            {
                get { return aGongZuoZhuangTai; }
                set {
                    if (value == 0)
                    {
                        aBarCode = "";
                    }
                    else
                    {
                        SaveTmpA();
                    }
                    aGongZuoZhuangTai = value;
                }
            }
            ushort bGongZuoZhuangTai = 0;
            string bBarCode = "";
            /// <summary>
            /// B工位状态
            /// </summary>
            public ushort BGongZuoZhuangTai
            {
                get { return bGongZuoZhuangTai; }
                set {
                    if (value == 0)
                    {
                        bBarCode = "";
                    }
                    else
                    {
                        SaveTmpB();
                    }
                    bGongZuoZhuangTai = value;
                }
            }
            ushort jiLuZhuangTai = 0;
            /// <summary>
            /// 记录状态
            /// </summary>
            public ushort JiLuZhuangTai
            {
                get { return jiLuZhuangTai; }
                set 
                {
                    if (jiLuZhuangTai == 0 && value == 1)
                    {
                        Save();
                    }
                    jiLuZhuangTai = value;
                }
            }
            /// <summary>
            /// 工位号
            /// </summary>
            public ushort GongWeiHao
            { get; set; }
            /// <summary>
            /// 结果 
            /// </summary>
            public ushort JieGuo
            { get; set; }
            /// <summary>
            /// 抽空时间
            /// </summary>
            public ushort ChouKongShiJian
            { get; set; }
            /// <summary>
            /// A路实时压力
            /// </summary>
            public float ALuShiShiYaLi
            { get; set; }
            /// <summary>
            /// B路实时压力
            /// </summary>
            public float BLuShiShiYaLi
            { get; set; }
            /// <summary>
            /// 充氮压力
            /// </summary>
            public float ChongDanYaLi
            { get; set; }
            /// <summary>
            /// 充空压力
            /// </summary>
            public float ChouKongYaLi
            { get; set; }
            /// <summary>
            /// 充氦压力
            /// </summary>
            public float ChongHaiYaLi
            { get; set; }
            /// <summary>
            /// 当前是否有故障
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
            public const int AllErrorCount = 47;
            public HaiJianHuiShou()
            {
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
            public void SetValue(ushort gongWeiHao, ushort jieGuo, ushort chouKongShiJian, float chongDanYaLi, float chouKongYaLi, float chongHaiYaLi)
            {
                this.GongWeiHao = gongWeiHao;
                this.JieGuo = jieGuo;
                this.ChouKongShiJian = chouKongShiJian;
                this.ChongDanYaLi = chongDanYaLi;
                this.ChouKongYaLi = chouKongYaLi;
                this.ChongHaiYaLi = chongHaiYaLi;
            }
            private void Save()
            {
                //记录状态为1时，记录数据，读到此状态后，将此状态复位
                frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Write<ushort>(0, 3);

                string tmpBarCode = "";
                if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out tmpBarCode, 40))
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out tmpBarCode, 40))
                    {
                        return;
                    }
                }
                if (tmpBarCode == "")
                {
                    return;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(tmpBarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }

                sql.Write(string.Format("insert into TestChongHaiHuiShou Values ('{0}','{1}',{2},{3:F10},{4:F10},{5:F10})",
                    (GongWeiHao == 1 ? "A" : "B"), (JieGuo == 1), ChouKongShiJian, ChongDanYaLi, ChouKongYaLi, ChongHaiYaLi));
                sql.Close();
            }
            /// <summary>
            /// 保存A路实时数据
            /// </summary>
            private void SaveTmpA()
            {
                if (aBarCode == "")
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out aBarCode, 40))
                    {
                        if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out aBarCode, 40))
                        {
                            return;
                        }
                    }
                    if (aBarCode == "")
                    {
                        return;
                    }
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(aBarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                sql.Write(string.Format("insert into TestChongHaiA (Press) values ({0:F10})", ALuShiShiYaLi));
                sql.Close();
            }
            /// <summary>
            /// 保存B路实时数据
            /// </summary>
            private void SaveTmpB()
            {
                if (bBarCode == "")
                {
                    if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out bBarCode, 40))
                    {
                        if (!frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Read<string>(out bBarCode, 40))
                        {
                            return;
                        }
                    }
                    if (bBarCode == "")
                    {
                        return;
                    }
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(bBarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                sql.Write(string.Format("insert into TestChongHaiB (Press) values ({0:F10})", BLuShiShiYaLi));
                sql.Close();
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
                    if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.氦检回收))
                    {
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("氦检回收工位 {0} 故障", info), (error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    }
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.氦检回收, info, error ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
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
                        string.Format("delete from StatueMaterial where WorkStation={0}", index + 105));
                    if (material == "")
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'空',0,0,'{1:yyyy-MM-dd HH:mm:ss}','true')", index + 105, DateTime.Now));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(
                            string.Format("insert into StatueMaterial values({0},'{1}',0,0,'{2:yyyy-MM-dd HH:mm:ss}','false')", index + 105, material, DateTime.Now));
                    }
                    Material[index] = material;
                }
            }
        }
    }
}
