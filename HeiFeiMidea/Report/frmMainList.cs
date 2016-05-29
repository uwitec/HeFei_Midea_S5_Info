using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea.Report
{
    public partial class frmMainList : All.Window.MainWindow
    {
        All.Class.DataReadAndWrite conn;
        string sql = "";
        public frmMainList(All.Class.DataReadAndWrite conn,string sql)
        {
            this.conn = conn;
            this.sql = sql;
            InitializeComponent();
        }

        private void frmMainList_Load(object sender, EventArgs e)
        {

            DataTable dt;
            dt = conn.Read(sql);
            dt.TableName = "dtTestAll";
            dsReport dsr = new Report.dsReport();
            dsr.Load(dt.CreateDataReader(), LoadOption.Upsert, dt.TableName);

            Microsoft.Reporting.WinForms.ReportDataSource rd = new Microsoft.Reporting.WinForms.ReportDataSource("dtTestAll", dsr.Tables["dtTestAll"]);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rd);
            reportViewer1.RefreshReport();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
