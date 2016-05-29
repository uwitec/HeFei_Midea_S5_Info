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
    public partial class frmSetSheBei : All.Window.MainWindow
    {
        public frmSetSheBei()
        {
            InitializeComponent();
        }

        private void frmSetSheBei_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitFrm()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Font = new System.Drawing.Font("黑体", 14);
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            DataGridViewImageColumn vic;
            vic = (DataGridViewImageColumn)dataGridView1.Columns[0];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns["colImage"].DataPropertyName = "Add";
            dataGridView1.Columns["colSheBei"].DataPropertyName = "SheBei";
            dataGridView1.Columns["colLast"].DataPropertyName = "Last";
            dataGridView1.Columns["colZhouQi"].DataPropertyName = "ZhouQi";
            dataGridView1.Columns["colDanWei"].DataPropertyName = "DanWei";
            dataGridView1.Columns["colOk"].DataPropertyName = "OK";
            dataGridView1.Columns["colVideo"].DataPropertyName = "Video";
            dataGridView1.Columns["colOk"].DefaultCellStyle.NullValue = "完成";
            dataGridView1.Columns["colOpen"].DefaultCellStyle.NullValue = "打开";
        }
        private void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Add", typeof(Image));
            dt.Columns.Add("SheBei", typeof(string));
            dt.Columns.Add("Last", typeof(DateTime));
            dt.Columns.Add("ZhouQi", typeof(int));
            dt.Columns.Add("DanWei", typeof(string));
            dt.Columns.Add("Video", typeof(string));
            DataRow dr;
            frmMain.mMain.FlushSheBei.AllSheBei.ForEach(
                sheBei =>
                {
                    dr = dt.NewRow();
                    dr["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                    dr["SheBei"] = sheBei.SheBei;
                    dr["Last"] = sheBei.Last;
                    dr["ZhouQi"] = sheBei.ZhouQi;
                    dr["DanWei"] = sheBei.DanWei;
                    dr["Video"] = sheBei.Video;
                    dt.Rows.Add(dr);
                });
            if (dt.Rows.Count > 0)
            {
                dt.Rows[dt.Rows.Count - 1]["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
            }
            else
            {
                dr = dt.NewRow();
                dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataTable dt = (DataTable)dataGridView1.DataSource;
            DataRow dr;
            if (dt == null)
            {
                return;
            }
            DataGridViewCell dgvc = dataGridView1.CurrentCell;
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "colImage":
                    if (e.RowIndex == dt.Rows.Count - 1)//最后一行
                    {
                        dt.Rows[e.RowIndex]["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                        dr = dt.NewRow();
                        dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                        dt.Rows.Add(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        dt.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = dt;
                    }
                    break;
                case "colOk":
                    dgvc = dataGridView1.Rows[e.RowIndex].Cells["colLast"];
                    dgvc.Value = DateTime.Now;
                    break;
                case "colOpen":
                    if (!System.IO.Directory.Exists(string.Format("{0}\\SheBei\\{1}", Application.StartupPath, dataGridView1.Rows[e.RowIndex].Cells["colSheBei"].Value)))
                    {
                        System.IO.Directory.CreateDirectory(string.Format("{0}\\SheBei\\{1}", Application.StartupPath, dataGridView1.Rows[e.RowIndex].Cells["colSheBei"].Value));
                    }
                    System.Diagnostics.Process.Start("Explorer.exe", string.Format("{0}\\SheBei\\{1}", Application.StartupPath, dataGridView1.Rows[e.RowIndex].Cells["colSheBei"].Value));
                    break;
                case "colVideo":
                    openAi.Filter = All.Control.MediaPlayerLocal.FileFilter;
                    openAi.InitialDirectory = frmMain.mMain.AllDataXml.LocalSet.VideoDirectory;
                    openAi.Title = "设备维护视频";
                    if (openAi.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openAi.FileName;
                        if (fileName.IndexOf(frmMain.mMain.AllDataXml.LocalSet.VideoDirectory) < 0)
                        {
                            All.Window.MetroMessageBox.Show(this, string.Format("对不起，视频文件必须位于   {0}   文件夹目录下", frmMain.mMain.AllDataXml.LocalSet.VideoDirectory), "错误的文件位置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvc.Value = fileName.Replace(frmMain.mMain.AllDataXml.LocalSet.VideoDirectory, "");
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dt == null || dt.Rows.Count == 0)
            {
                All.Window.MetroMessageBox.Show(this, "对不起，当前设备信息设置为空，不能保存数据，请稍后再试", "错误的设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<FlushSheBei.SingleSheBei> tmpAllSheBei = new List<FlushSheBei.SingleSheBei>();
            FlushSheBei.SingleSheBei tmpSheBei;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpSheBei = new FlushSheBei.SingleSheBei();
                tmpSheBei.SheBei = All.Class.Num.ToString(dt.Rows[i]["SheBei"]);
                tmpSheBei.Last = All.Class.Num.ToDateTime(dt.Rows[i]["Last"]);
                tmpSheBei.ZhouQi = All.Class.Num.ToInt(dt.Rows[i]["ZhouQi"]);
                tmpSheBei.DanWei = All.Class.Num.ToString(dt.Rows[i]["DanWei"]);
                tmpSheBei.Video = All.Class.Num.ToString(dt.Rows[i]["Video"]);
                tmpAllSheBei.Add(tmpSheBei);
            }
            if (!frmMain.mMain.FlushSheBei.Write(tmpAllSheBei))
            {
                All.Window.MetroMessageBox.Show(this, "对不起，保存设备信息失败，请稍后再试", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "所有设备数据已成功保存到数据库", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
