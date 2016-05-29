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
    public partial class frmSetTime : All.Window.MainWindow
    {
        public frmSetTime()
        {
            InitializeComponent();
        }

        private void frmSetTime_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitFrm()
        {

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns["colAdd"].DataPropertyName = "Add";
            dataGridView1.Columns["colUseTime"].DataPropertyName = "Image";
            dataGridView1.Columns["colHourStart"].DataPropertyName = "HourStart";
            dataGridView1.Columns["colMinStart"].DataPropertyName = "MinStart";
            dataGridView1.Columns["colHourEnd"].DataPropertyName = "HourEnd";
            dataGridView1.Columns["colMinEnd"].DataPropertyName = "MinEnd";
            dataGridView1.Columns["colCheck"].DataPropertyName = "UseTime";

            DataGridViewImageColumn vic = (DataGridViewImageColumn)dataGridView1.Columns["colAdd"];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns["colAdd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            vic = (DataGridViewImageColumn)dataGridView1.Columns["colUseTime"];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns["colUseTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }
        private void InitData()
        {
            txtAllCount.Text = frmMain.mMain.AllDataXml.LocalSet.OEECount.ToString();
            txtGreet.Text = string.Format("{0}%", frmMain.mMain.AllDataXml.LocalSet.OEEGreet);
            txtPass.Text = string.Format("{0}%", frmMain.mMain.AllDataXml.LocalSet.OEEPass);
            DataTable dt = new DataTable();
            dt.Columns.Add("Add", typeof(Image));
            dt.Columns.Add("UseTime", typeof(bool));
            dt.Columns.Add("Image", typeof(Image));
            dt.Columns.Add("HourStart", typeof(int));
            dt.Columns.Add("MinStart", typeof(int));
            dt.Columns.Add("HourEnd", typeof(int));
            dt.Columns.Add("MinEnd", typeof(int));
            DataRow dr;
            List<FlushOEE.OEETime> allOEETimes = FlushOEE.OEETime.GetAllOEETime();
            if (allOEETimes != null)
            {
                allOEETimes.ForEach(
                    oee =>
                    {
                        dr = dt.NewRow();
                        dr["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                        dr["UseTime"] = oee.UseTime;
                        dr["Image"] = (oee.UseTime ? HeiFeiMidea.Properties.Resources.check.ToBitmap() : HeiFeiMidea.Properties.Resources.No.ToBitmap());
                        dr["HourStart"] = oee.HourStart;
                        dr["MinStart"] = oee.MinStart;
                        dr["HourEnd"] = oee.HourEnd;
                        dr["MinEnd"] = oee.MinEnd;

                        dt.Rows.Add(dr);
                    });
            }
            if (dt.Rows.Count > 0)
            {
                dt.Rows[dt.Rows.Count - 1]["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
            }
            else
            {
                dr = dt.NewRow();
                dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                dr["Image"] = HeiFeiMidea.Properties.Resources.check.ToBitmap();
                dr["UseTime"] = true;
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataRow dr;
            if (dt == null ||
                e.ColumnIndex < 0 || e.ColumnIndex >= dt.Columns.Count
                || e.RowIndex < 0 || e.RowIndex >= dt.Rows.Count)
            {
                return;
            }
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "colAdd":
                    if (e.RowIndex == dt.Rows.Count - 1)//最后一行
                    {
                        dt.Rows[e.RowIndex]["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                        dr = dt.NewRow();
                        dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                        dr["Image"] = HeiFeiMidea.Properties.Resources.check.ToBitmap();
                        dr["UseTime"] = true;
                        dt.Rows.Add(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        dt.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = dt;
                    }
                    break;
                case "colUseTime":
                    if (All.Class.Num.ToBool(dt.Rows[e.RowIndex]["UseTime"]))
                    {
                        dt.Rows[e.RowIndex]["UseTime"] = false;
                        dt.Rows[e.RowIndex]["Image"] = HeiFeiMidea.Properties.Resources.No.ToBitmap();
                    }
                    else
                    {
                        dt.Rows[e.RowIndex]["UseTime"] = true;
                        dt.Rows[e.RowIndex]["Image"] = HeiFeiMidea.Properties.Resources.check.ToBitmap();
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmMain.mMain.AllDataXml.LocalSet.OEECount = All.Class.Num.ToFloat(txtAllCount.Text);
            frmMain.mMain.AllDataXml.LocalSet.OEEGreet = All.Class.Num.ToFloat(txtGreet.Text.Replace("%", ""));
            frmMain.mMain.AllDataXml.LocalSet.OEEPass = All.Class.Num.ToFloat(txtPass.Text.Replace("%", ""));
            if (FlushOEE.OEETime.Save(GetData()))
            {
                frmMain.mMain.FlushOEE.Load();
                All.Window.MetroMessageBox.Show(this, "所有时间已成功保存到数据，重启系统后生效", "成功保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "对不起，时间段数据保存失败，请稍候再试", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<FlushOEE.OEETime> GetData()
        {
            dataGridView1.EndEdit();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DateTime now = DateTime.Now;
            List<FlushOEE.OEETime> result = new List<FlushOEE.OEETime>();
            FlushOEE.OEETime tmp;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmp = new FlushOEE.OEETime();
                tmp.HourStart = All.Class.Num.ToInt(dt.Rows[i]["HourStart"]);
                tmp.MinStart = All.Class.Num.ToInt(dt.Rows[i]["MinStart"]);
                tmp.HourEnd = All.Class.Num.ToInt(dt.Rows[i]["HourEnd"]);
                tmp.MinEnd = All.Class.Num.ToInt(dt.Rows[i]["MinEnd"]);
                tmp.UseTime = All.Class.Num.ToBool(dt.Rows[i]["UseTime"]);
                if (tmp.HourStart > 0 && tmp.HourEnd > 0)
                {
                    result.Add(tmp);
                }
            }
            return result;
        }
    }
}
