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
    public partial class frmReportUser : All.Window.MainWindow
    {
        public frmReportUser()
        {
            InitializeComponent();
        }

        private void frmReportError_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();
            rptKaoQin1.LocalReport.DataSources.Clear();
            rptKaoQin2.LocalReport.DataSources.Clear();
            rptError1.LocalReport.DataSources.Clear();
            rptError2.LocalReport.DataSources.Clear();

            //考勤详情
            string sql = string.Format("select UserName,TestYear,TestMonth,Test01,Test02,Test03,Test04,Test05,Test06,Test07,Test08,Test09,Test10,Test11,Test12,Test13,Test14,Test15,Test16,Test17,Test18,Test19,Test20,Test21,Test22,Test23,Test24,Test25,Test26,Test27,Test28,Test29,Test30,Test31 From StatueUserLogin where TestYear>={0:yyyy} and TestYear<={1:yyyy} and TestMonth>={0:MM} and TestMonth<={1:MM}", dateTimePicker2.Value, dateTimePicker1.Value);
            DataTable dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptKaoQin2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtUserLoginDetial", dt));

            //考勤总表
            DataTable dtUserLogin = new DataTable();
            DataRow dr;
            dtUserLogin.Columns.Add("UserName", typeof(string));
            dtUserLogin.Columns.Add("TestCount", typeof(int));
            Dictionary<string, int> userLogin = new Dictionary<string, int>();
            string tmpUser = "";
            int startDay = All.Class.Num.ToInt(string.Format("{0:dd}", dateTimePicker2.Value));
            int endDay = All.Class.Num.ToInt(string.Format("{0:dd}", dateTimePicker1.Value));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpUser = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                if (!userLogin.ContainsKey(tmpUser))
                {
                    userLogin.Add(tmpUser, 0);
                }
                for (int j = 1; j < 31; j++)
                {
                    if (j >= startDay && j <= endDay)
                    {
                        if (All.Class.Num.ToBool(dt.Rows[i][string.Format("Test{0:D2}", j)]))
                        {
                            userLogin[tmpUser] = userLogin[tmpUser] + 1;
                        }
                    }
                }
            }
            userLogin.Keys.ToList().ForEach(
                key =>
                {
                    dr = dtUserLogin.NewRow();
                    dr["UserName"] = key;
                    dr["TestCount"] = userLogin[key];
                    dtUserLogin.Rows.Add(dr);
                })
                ;
            rptKaoQin1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtUserLogin", dtUserLogin));

            sql = string.Format("select UserName,TestTime,Error,BarCode from StatueUserError where TestTime>='{0:yyyy-MM-dd} 00:00:00' and TestTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptError2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtUserErrorList", dt));

            sql = string.Format("select Count(UserName) as TestCount,UserName from StatueUserError  where TestTime>='{0:yyyy-MM-dd} 00:00:00' and TestTime<='{1:yyyy-MM-dd} 23:59:59' group by UserName", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptError1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtUserLogin", dt));

            rptKaoQin1.RefreshReport();
            rptKaoQin2.RefreshReport();
            rptError1.RefreshReport();
            rptError2.RefreshReport();
        }
    }
}
