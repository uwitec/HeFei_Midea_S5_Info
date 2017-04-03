using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea
{
    public partial class frmReportLine : All.Window.MainWindow
    {
        public frmReportLine()
        {
            InitializeComponent();
        }

        private void frmReportLine_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();
            rptTestTimeEveryHour.LocalReport.DataSources.Clear();

            string sql = "";
            DataTable dt;
            DataTable dtStationTime;
            DataRow dr;
            int avg = 0;
            using (DataTable stationTable = frmMain.mMain.AllDataBase.ReportData.Read("select * from InfoLineStation"))
            {
                Dictionary<string, int> TimeEveryStation = new Dictionary<string, int>();
                for (int i = 0; i < stationTable.Rows.Count; i++)
                {
                    if (!TimeEveryStation.ContainsKey(All.Class.Num.ToString(stationTable.Rows[i]["StationName"])))
                    {
                        TimeEveryStation.Add(All.Class.Num.ToString(stationTable.Rows[i]["StationName"]),
                            All.Class.Num.ToInt(stationTable.Rows[i]["TimeOut"]));
                    }
                }
                avg = (int)TimeEveryStation.Values.ToList().Average();

                sql = string.Format("select count(UseTime) as AllCount,sum(useTime) as AllTime,stationName from AllTestStationTimeEveryHour where testTime >='{0:yyyy-MM-dd HH}:00:00' and testTime<='{1:yyyy-MM-dd HH}:59:59' group by stationName", dateTimePicker2.Value, dateTimePicker1.Value);
                dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
                dtStationTime = new DataTable("dtStationTime");
                dtStationTime.Columns.Add("StationName", typeof(string));
                dtStationTime.Columns.Add("TimePerEveryOne", typeof(int));
                dtStationTime.Columns.Add("TimeSet", typeof(int));
                dtStationTime.Columns.Add("XiaoLv", typeof(int));
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (All.Class.Num.ToInt(dt.Rows[i]["AllCount"]) >= 0)
                        {
                            dr = dtStationTime.NewRow();
                            dr["StationName"] = dt.Rows[i]["StationName"];
                            dr["TimePerEveryOne"] = All.Class.Num.ToInt(dt.Rows[i]["AllTime"]) / All.Class.Num.ToInt(dt.Rows[i]["AllCount"]);
                            if (TimeEveryStation.ContainsKey(All.Class.Num.ToString(dt.Rows[i]["StationName"])))
                            {
                                dr["TimeSet"] = TimeEveryStation[All.Class.Num.ToString(dt.Rows[i]["StationName"])];
                            }
                            else
                            {
                                dr["TimeSet"] = avg;
                            }
                            if (All.Class.Num.ToInt(dr["TimeSet"]) > 0)
                            {
                                dr["XiaoLv"] = (int)(100 * All.Class.Num.ToInt(dr["TimePerEveryOne"]) / All.Class.Num.ToInt(dr["TimeSet"]));
                            }
                            else
                            {
                                dr["XiaoLv"] = 0;
                            }
                            dtStationTime.Rows.Add(dr);
                        }
                    }
                }
                rptTestTimeEveryHour.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtStationTime", dtStationTime));
                rptTestTimeEveryHour.RefreshReport();
            }
        }
    }
}
