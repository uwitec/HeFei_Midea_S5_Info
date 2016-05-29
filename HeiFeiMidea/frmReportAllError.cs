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
    public partial class frmReportAllError : All.Window.MainWindow
    {
        public frmReportAllError()
        {
            InitializeComponent();
        }

        private void frmReportAllError_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();
            rptSheBei1.LocalReport.DataSources.Clear();
            rptSheBei2.LocalReport.DataSources.Clear();
            rptChaoShi1.LocalReport.DataSources.Clear();
            rptChaoShi2.LocalReport.DataSources.Clear();
            rptWuLiao1.LocalReport.DataSources.Clear();
            rptWuLiao2.LocalReport.DataSources.Clear();
            string sql = "";// = string.Format("select ErrorText,StartTime,EndTime,ErrorTime,ErrorEnum From StatueErrorAll where ErrorTime>60 and StartTime>='{0:yyyy-MM-dd} 00:00:00' and StartTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            DataTable dt;// = frmMain.mMain.AllDataBase.ReportData.Read(sql);

            //设备
            sql = string.Format("select ErrorText,StartTime,EndTime,ErrorTime From StatueErrorAll where ErrorEnum=1 and ErrorTime>60 and StartTime>='{0:yyyy-MM-dd} 00:00:00' and StartTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptSheBei1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));
            rptSheBei2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));

            //超时
            sql = string.Format("select ErrorText,StartTime,EndTime,ErrorTime From StatueErrorAll where ErrorEnum=3 and StartTime>='{0:yyyy-MM-dd} 00:00:00' and StartTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptChaoShi1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));
            rptChaoShi2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));


            //物料
            sql = string.Format("select ErrorText,StartTime,EndTime,ErrorTime From StatueErrorAll where ErrorEnum=2  and StartTime>='{0:yyyy-MM-dd} 00:00:00' and StartTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptWuLiao1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));
            rptWuLiao2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtAllError", dt));



            rptSheBei1.RefreshReport();
            rptSheBei2.RefreshReport();
            rptChaoShi1.RefreshReport();
            rptChaoShi2.RefreshReport();
            rptWuLiao1.RefreshReport();
            rptWuLiao2.RefreshReport();

        }
    }
}
