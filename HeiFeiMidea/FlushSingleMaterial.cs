using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新物料呼叫
    /// </summary>
    public class FlushSingleMaterial:All.Class.FlushAll.FlushMethor
    {
        bool connect = true;

        /// <summary>
        /// 物料呼叫网络连接状态
        /// </summary>
        public bool Connect
        {
            get { return connect; }
            set
            {
                if (connect != value)
                {
                    if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.物料网络))
                    {
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("物料网络连接失败", value ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add));
                    }
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.物料网络, value ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add);
                }
                connect = value;
            }
        }
        string dataFile = "";
        public override void Flush()
        {
            if (frmMain.mMain.AllDataBase.MaterialData != null
                && frmMain.mMain.AllDataBase.MaterialData.Conn.State == System.Data.ConnectionState.Open)
            {
                Connect = true;
                ConnectOkFlushData(false, true);
            }
            else
            {
                Connect = false;
                frmMain.mMain.AllDataBase.MaterialData = new All.Class.PostGreSQL();
                frmMain.mMain.AllDataBase.MaterialData.Login("192.168.1.201", "LEDSHOW", "odoo", "odoo");
            }
            ConnectOkFlushData(true, false);
        }
        public override void Load()
        {
            dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());
        }
        /// <summary>
        /// 刷新物料呼叫
        /// </summary>
        /// <param name="Report">当次刷新是否为本地报表用</param>
        /// <param name="Remote">当次刷新是否为写入远程主机</param>
        private void ConnectOkFlushData(bool Report,bool Remote)
        {
            int tmpIndex = 0;
            if (Report)
            {
                tmpIndex = frmMain.mMain.AllDataXml.LocalSingleFlush.MaterialIndexReport;
            }
            if (Remote)
            {
                tmpIndex = frmMain.mMain.AllDataXml.LocalSingleFlush.MaterialIndex;
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read(string.Format("select top 1 * from StatueMaterial where ID>{0} order by ID", tmpIndex)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    //1-11为相应电脑工位
                    //100,101,102,103,104为检漏工位,每一个物料呼叫当一个工位，只为准确解决开电时的主机与分机的信息不对等 
                    //105,106,107,108,109为氦检回收工位
                    //110,111,112,113,114为抽空充注工位
                    int index = All.Class.Num.ToInt(dt.Rows[0]["WorkStation"]);
                    string text = "";
                    string stationName = "";
                    switch (index)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            stationName = frmMain.mMain.AllCars.AllInfoStation[index].StationName;
                            text = string.Format("{0}",dt.Rows[0]["Material"]);
                            break;
                        case 100:
                        case 101:
                        case 102:
                        case 103:
                        case 104:
                            stationName = "检漏工位";
                            text = string.Format("{0}", dt.Rows[0]["Material"]);
                            break;
                        case 105:
                        case 106:
                        case 107:
                        case 108:
                        case 109:
                            stationName = "氦检回收工位";
                            text = string.Format("{0}", dt.Rows[0]["Material"]);
                            break;
                        case 110:
                        case 111:
                        case 112:
                        case 113:
                        case 114:
                            stationName = "抽空充注工位";
                            text = string.Format("{0}", dt.Rows[0]["Material"]);
                            break;
                    }
                    Material.OperaList opera = Material.OperaList.Add;
                    if (Report)
                    {
                        if (All.Class.Num.ToBool(dt.Rows[0]["CallOver"]))
                        {
                            opera = Material.OperaList.Del;
                            if (index < 100)
                            {
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.物料, 0, text, FlushAllError.ChangeList.Del, index);
                            }
                        }
                        else
                        {
                            opera = Material.OperaList.Add;
                            if (index < 100)
                            {
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.物料, 0, text, FlushAllError.ChangeList.Add, index);
                            }
                        }
                        frmMain.mMain.AllDataXml.LocalSingleFlush.MaterialIndexReport = All.Class.Num.ToInt(dt.Rows[0]["ID"]);
                    }
                    if (Remote)
                    {
                        if (All.Class.Num.ToBool(dt.Rows[0]["CallOver"]))
                        {
                            opera = Material.OperaList.Del;
                        }
                        Material tmp = new Material(stationName, text, opera);
                        tmp.Save();
                        frmMain.mMain.AllDataXml.LocalSingleFlush.MaterialIndex = All.Class.Num.ToInt(dt.Rows[0]["ID"]);
                    }
                    frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                }
            }
        }
        public class Material
        {
            public string Index
            { get; set; }
            public string Text
            { get; set; }
            /// <summary>
            /// 操作方法
            /// </summary>
            public enum OperaList
            {
                Add,
                Del
            }
            /// <summary>
            /// 操作方法
            /// </summary>
            public OperaList Opera
            { get; set; }
            public Material(string index,string text, OperaList opera)
            {
                this.Index = string.Format("外机{0}", index);
                this.Text = text;
                this.Opera = opera;
            }
            public void Save()
            {
                if (Opera == OperaList.Add)
                {
                    frmMain.mMain.AllDataBase.MaterialData.Write(string.Format("insert into ledshow values('{0}','{1}','{2}')",
                        Index, "", Text));
                }
                else
                {
                    frmMain.mMain.AllDataBase.MaterialData.Write(string.Format("delete from ledshow where workstation='{0}' and info='{1}'", Index,Text));
                }
            }
        }
    }
}
