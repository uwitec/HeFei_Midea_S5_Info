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
    public partial class frmReportCount : All.Window.MainWindow
    {
        public frmReportCount()
        {
            InitializeComponent();
        }

        private void frmReportCount_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();
            DateTime timeMonth = DateTime.Parse(string.Format("{0:yyyy}-{0:MM}-01 00:00:00", dateTimePicker2.Value));
            DateTime timeDay = DateTime.Parse(string.Format("{0:yyyy}-{0:MM}-{0:dd} 00:00:00", dateTimePicker2.Value));
            rptMonth.LocalReport.DataSources.Clear();
            rptDay.LocalReport.DataSources.Clear();
            rptEvery.LocalReport.DataSources.Clear();
            rptOEEChart.LocalReport.DataSources.Clear();
            rptOEEDetial.LocalReport.DataSources.Clear();

            //月报表
            string sql = "";
            DataTable dt;
            DataTable dtEvery;
            sql = string.Format("select TestDay,Count(TestDay) as TestCount from TestAll where InLineTime>='{0:yyyy-MM-dd HH:mm:ss}' and InLineTime<='{1:yyyy-MM-dd HH:mm:ss}' and OutLine='true' group by TestDay order by testDay", timeMonth, timeMonth.AddMonths(1));
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            dtEvery = dt.Copy();
            rptMonth.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtCountMonth", dt));
            //日报表
            sql = string.Format("select TestHour,Count(TestHour) as TestCount from TestAll where InLineTime>='{0:yyyy-MM-dd HH:mm:ss}' and InLineTime<='{1:yyyy-MM-dd HH:mm:ss}' and OutLine='true' group by TestHour order by TestHour", timeDay, timeDay.AddDays(1));
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptDay.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtCountDay", dt));
            //人均产量
            sql = string.Format("select * from StatueUserLogin where TestYear={0:yyyy} and TestMonth={0:MM}", timeMonth);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            List<int> allUser = new List<int>();
            DataTable dtCountEvery = new DataTable();
            DataRow dr;
            int TestDay = 0;
            float TestCount = 0;
            dtCountEvery.Columns.Add("TestDay", typeof(int));
            dtCountEvery.Columns.Add("TestCount", typeof(float));
            for (int i = 0; i < 31; i++)
            {
                allUser.Add(0);
            }
            for (int i = 0; i < dt.Rows.Count; i++)//每个人
            {
                for (int j = 0; j < 31; j++)//每一天，
                {
                    if (All.Class.Num.ToBool(dt.Rows[i][string.Format("Test{0:D2}", j + 1)]))//是否登陆
                    {
                        allUser[j] = allUser[j] + 1;
                    }
                }
            }
            for (int i = 0; i < dtEvery.Rows.Count; i++)
            {
                TestDay = All.Class.Num.ToInt(dtEvery.Rows[i]["TestDay"]);
                TestCount = 0;
                if (TestDay >= 1 && TestDay <= 31 && allUser.Count == 31)
                {
                    if (allUser[TestDay - 1] > 0)
                    {
                        TestCount = (float)All.Class.Num.ToInt(dtEvery.Rows[i]["TestCount"]) / allUser[TestDay - 1];
                    }
                }
                dr = dtCountEvery.NewRow();
                dr["TestDay"] = TestDay;
                dr["TestCount"] = TestCount;
                dtCountEvery.Rows.Add(dr);
            }
            rptEvery.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtCountEvery", dtCountEvery));

            //OEE
            dt = frmMain.mMain.AllDataBase.ReportData.Read(string.Format("select * from TestCount where TestYear={0:yyyy} and TestMonth={0:MM}", timeMonth));
            DataTable dtOEE = new DataTable();
            dtOEE.Columns.Add("TimeShow", typeof(string));
            dtOEE.Columns.Add("AllCount", typeof(int));
            dtOEE.Columns.Add("AllTime", typeof(int));
            dtOEE.Columns.Add("OEEValue", typeof(float));
            int AllTime = 0;
            int AllCount = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < 31; i++)
                {
                    AllTime = All.Class.Num.ToInt(dt.Rows[0][string.Format("Time{0}", i + 1)]);
                    AllCount = All.Class.Num.ToInt(dt.Rows[0][string.Format("Count{0}", i + 1)]);
                    if (AllTime > 0)
                    {
                        dr = dtOEE.NewRow();
                        dr["TimeShow"] = i + 1;
                        dr["AllCount"] = AllCount;
                        dr["AllTime"] = AllTime;
                        dr["OEEValue"] = (float)((AllCount * 60) / (float)AllTime) / frmMain.mMain.AllDataXml.LocalSet.OEECount;
                        dtOEE.Rows.Add(dr);
                    }
                }
            }
            rptOEEChart.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtOEE", dtOEE));
            rptOEEDetial.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtOEE", dtOEE));

            rptMonth.RefreshReport();
            rptDay.RefreshReport();
            rptEvery.RefreshReport();
            rptOEEChart.RefreshReport();
            rptOEEDetial.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
