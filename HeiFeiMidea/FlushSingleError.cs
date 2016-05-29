using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新检测过程中的故障
    /// </summary>
    public class FlushSingleError:All.Class.FlushAll.FlushMethor
    {
        public override void Flush()
        {

            using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read(string.Format("select Top 1 * from StatueError Where Id>{0} order by ID", frmMain.mMain.AllDataXml.LocalSingleFlush.ErrorIndex)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Error err = new Error();
                    err.BarCode = All.Class.Num.ToString(dt.Rows[0]["BarCode"]);
                    err.WorkStation = All.Class.Num.ToInt(dt.Rows[0]["WorkStation"]);
                    err.Text = All.Class.Num.ToString(dt.Rows[0]["Error"]);
                    err.ErrorNum = All.Class.Num.ToInt(dt.Rows[0]["ErrorNum"]);
                    err.ErrorTime = All.Class.Num.ToDateTime(dt.Rows[0]["ErrorTime"]);
                    err.Repair = All.Class.Num.ToBool(dt.Rows[0]["Repair"]);
                    err.RepairTime = All.Class.Num.ToDateTime(dt.Rows[0]["RepairTime"]);
                    err.ErrorFrom = All.Class.Num.ToString(dt.Rows[0]["ErrorFrom"]);
                    err.ErrorSpace = All.Class.Num.ToInt(dt.Rows[0]["ErrorSpace"]);
                    err.Save();
                    frmMain.mMain.AllDataXml.LocalSingleFlush.ErrorIndex = All.Class.Num.ToInt(dt.Rows[0]["ID"]);
                    frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                }
            }
        }
        public override void Load()
        {
            //throw new NotImplementedException();
        }
        public class Error
        {
            /// <summary>
            /// 条码
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 工位号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 故障原因
            /// </summary>
            public string Text
            { get; set; }
            /// <summary>
            /// 故障代码
            /// </summary>
            public int ErrorNum
            { get; set; }
            /// <summary>
            /// 故障时间
            /// </summary>
            public DateTime ErrorTime
            { get; set; }
            /// <summary>
            /// 是否维修
            /// </summary>
            public bool Repair
            { get; set; }
            /// <summary>
            /// 维修时间
            /// </summary>
            public DateTime RepairTime
            { get; set; }
            /// <summary>
            /// 故障源
            /// </summary>
            public string ErrorFrom
            { get; set; }
            /// <summary>
            /// 故障源分类
            /// </summary>
            public int ErrorSpace
            { get; set; }
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
                if (Repair)
                {
                    sql.Write(string.Format("update StatueError Set Repair='true',RepairTime='{0:yyyy-MM-dd HH:mm:ss}' where Error='{1}'",DateTime.Now, Text));
                }
                else
                {
                    sql.Write(string.Format("delete from StatueError where  Error='{0}'", Text));
                    sql.Write(string.Format("insert into StatueError Values({0},'{1}',{2},'{3:yyyy-MM-dd HH:mm:ss}','{4}','{5:yyyy-MM-dd HH:mm:ss}')",
                        WorkStation, Text, ErrorNum, ErrorTime, Repair, RepairTime));
                    sql.Close();
                }
            }
        }
    }
}
