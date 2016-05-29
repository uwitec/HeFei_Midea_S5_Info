using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace HeiFeiMidea
{
    public partial class frmReportPingZhi : All.Window.MainWindow
    {
        public frmReportPingZhi()
        {
            InitializeComponent();
        }

        private void frmReportPingZhi_Load(object sender, EventArgs e)
        {
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            tabControl1.Focus();

            rptTestPass.LocalReport.DataSources.Clear();
            rptAllPass.LocalReport.DataSources.Clear();
            rptError.LocalReport.DataSources.Clear();
            rptDetial.LocalReport.DataSources.Clear();
            //详细记录
            string sql = string.Format("select BarCode,Error,ErrorTime,ErrorFrom,ErrorSpace,Repair From StatueError where WorkStation>0 and ErrorTime>='{0:yyyy-MM-dd} 00:00:00' and ErrorTime<='{1:yyyy-MM-dd} 23:59:59'", dateTimePicker2.Value, dateTimePicker1.Value);
            DataTable dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            rptDetial.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtPingZhi", dt));
            rptError.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtPingZhi", dt));

            //下线总数与故障数据
            DataTable allTable = new DataTable();
            allTable.TableName = "dtPingZhiXiaXian";
            allTable.Columns.Add("AllCount", typeof(int));
            allTable.Columns.Add("ErrorCount", typeof(int));
            allTable.Columns.Add("ErrorMachine", typeof(float));
            allTable.Columns.Add("PassMachine", typeof(float));
            int AllCount = 0;
            int ErrorCount = 0;
            int ErrorMachine = 0;
            int PassMachine = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                ErrorCount = dt.Rows.Count;
            }
            sql = string.Format("select Count(ID) as AllCount from TestAll where InLineTime>='{0:yyyy-MM-dd} 00:00:00' and InLineTime<='{1:yyyy-MM-dd} 23:59:59' and OutLine='true'", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            if (dt != null && dt.Rows.Count >0)
            {
                AllCount = All.Class.Num.ToInt(dt.Rows[0]["AllCount"]);
            }
            sql = string.Format("select Count(BarCode) as ErrorMachine from StatueError where WorkStation>0 and ErrorTime>='{0:yyyy-MM-dd} 00:00:00' and ErrorTime<='{1:yyyy-MM-dd} 23:59:59' group by BarCode", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReportData.Read(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                ErrorMachine = dt.Rows.Count;
            }
            PassMachine =  Math.Max(0, AllCount - ErrorMachine);

            DataRow dr = allTable.NewRow();
            dr["AllCount"] = AllCount;
            dr["ErrorCount"] = ErrorCount;
            if (AllCount > 0)
            {
                dr["ErrorMachine"] = 100.0f * ErrorMachine / AllCount;
                dr["PassMachine"] = 100.0f * PassMachine / AllCount;
            }
            else
            {
                if (ErrorCount > 0)
                {
                    dr["ErrorMachine"] = 100;
                    dr["PassMachine"] = 0;
                }
                else
                {
                    dr["ErrorMachine"] = 0;
                    dr["PassMachine"] = 100;
                }
            }
            allTable.Rows.Add(dr);
            rptAllPass.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtPingZhiXiaXian", allTable));
            rptDetial.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtPingZhiXiaXian", allTable));

            //岗位故障数量
            sql = string.Format("select ErrorFrom,count(ErrorFrom) as ErrorCount from StatueError where ErrorSpace<100 and  WorkStation>0 and ErrorTime>='{0:yyyy-MM-dd} 00:00:00' and ErrorTime<='{1:yyyy-MM-dd} 23:59:59' group by ErrorFrom", dateTimePicker2.Value, dateTimePicker1.Value);
            dt = frmMain.mMain.AllDataBase.ReadData.Read(sql);

            List<string> allStopTestStation = new List<string>();
            string errorStation="";
            DataTable dtYiCiTongGuoLv = new DataTable();
            dtYiCiTongGuoLv.Columns.Add("ErrorFrom", typeof(string));
            dtYiCiTongGuoLv.Columns.Add("TongGuoLv", typeof(float));

            frmMain.mMain.AllCars.AllInfoLineStation.ToList().ForEach(
                tmpStation =>
                {
                    if (tmpStation.TestStation)
                    {
                        allStopTestStation.Add(tmpStation.StationName);
                    }
                });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dtYiCiTongGuoLv.NewRow();
                errorStation = All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"]);
                allStopTestStation.Remove(errorStation);
                dr["ErrorFrom"] = errorStation;

                if (AllCount > 0)
                {
                    dr["TongGuoLv"] = (float)(AllCount - All.Class.Num.ToInt(dt.Rows[i]["ErrorCount"])) / AllCount * 100.0f;
                }
                else
                {
                    dr["TongGuoLv"] = 1;
                }
                dtYiCiTongGuoLv.Rows.Add(dr);
            }
            for (int i = 0; i < allStopTestStation.Count; i++)
            {
                dr = dtYiCiTongGuoLv.NewRow();
                dr["ErrorFrom"] = allStopTestStation[i];
                dr["TongGuoLv"] = 100;
                dtYiCiTongGuoLv.Rows.Add(dr);
            }
            rptTestPass.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dtYiCiTongGuoLv", dtYiCiTongGuoLv));
            
            
            rptTestPass.RefreshReport();
            rptAllPass.RefreshReport();
            rptDetial.RefreshReport();
            rptError.RefreshReport();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rptTestPass.RefreshReport();
            //rptAllPass.RefreshReport();
            //rptDetial.RefreshReport();
            //rptError.RefreshReport();
        }

    }
}
