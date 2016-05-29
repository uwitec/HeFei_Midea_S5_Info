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
    public partial class frmSetMaterial : All.Window.MainWindow
    {
        Dictionary<string, int> StationNameToIndex = new Dictionary<string, int>();
        public frmSetMaterial()
        {
            InitializeComponent();
        }

        private void frmSetMaterial_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitData()
        {
            List<HeiFeiMideaDll.cDataLocal.Material> allMaterial = frmMain.mMain.AllDataBase.Local.GetMaterial();
            DataTable dt = new DataTable();
            dt.Columns.Add("Add", typeof(Image));
            dt.Columns.Add("StationName", typeof(string));
            dt.Columns.Add("Material", typeof(string));
            dt.Columns.Add("MaterialNum", typeof(int));
            dt.Columns.Add("Up", typeof(Image));
            dt.Columns.Add("Down", typeof(Image));
            DataRow dr;
            allMaterial.ForEach(
                mater =>
                {
                    dr = dt.NewRow();
                    dr["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                    dr["StationName"] = mater.StationName;
                    dr["Material"] = mater.Text;
                    dr["MaterialNum"] = mater.Num;
                    dr["Up"] = HeiFeiMidea.Properties.Resources.Up.ToBitmap();
                    dr["Down"] = HeiFeiMidea.Properties.Resources.Down.ToBitmap();
                    dt.Rows.Add(dr);
                }
                );
            if (dt.Rows.Count > 0)
            {
                dt.Rows[dt.Rows.Count - 1]["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
            }
            else
            {
                dr = dt.NewRow();
                dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                dr["Up"] = HeiFeiMidea.Properties.Resources.Up.ToBitmap();
                dr["Down"] = HeiFeiMidea.Properties.Resources.Down.ToBitmap();
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }

        private void InitFrm()
        {
            dataGridView1.Font = new System.Drawing.Font("Segoe WP", 10, FontStyle.Regular);
            DataGridViewComboBoxColumn cbb = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
            //List<HeiFeiMideaDll.cDataLocal.InfoStation> AllStation = frmMain.mMain.AllDataBase.Local.GetStation();
            StationNameToIndex.Clear();
            StationNameToIndex.Add("", -1);
            frmMain.mMain.AllCars.AllInfoStation.ToList().ForEach(station =>
                {
                    if (station.TestStation && station.MaterialShow)
                    {
                        cbb.Items.Add(station.StationName);
                        StationNameToIndex.Add(station.StationName, station.WorkStation);
                    }
                }
            );
            DataGridViewImageColumn vic;
            vic = (DataGridViewImageColumn)dataGridView1.Columns[0];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            vic = (DataGridViewImageColumn)dataGridView1.Columns[4];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            vic = (DataGridViewImageColumn)dataGridView1.Columns[5];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;


            dataGridView1.Columns[0].DataPropertyName = "Add";
            dataGridView1.Columns[1].DataPropertyName = "StationName";
            dataGridView1.Columns[2].DataPropertyName = "Material";
            dataGridView1.Columns[3].DataPropertyName = "MaterialNum";
            dataGridView1.Columns[4].DataPropertyName = "Up";
            dataGridView1.Columns[5].DataPropertyName = "Down";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            List<HeiFeiMideaDll.cDataLocal.Material> AllMaterial = new List<HeiFeiMideaDll.cDataLocal.Material>();
            HeiFeiMideaDll.cDataLocal.Material tmpMaterial;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tmpMaterial = new HeiFeiMideaDll.cDataLocal.Material();
                    tmpMaterial.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                    tmpMaterial.WorkStation = StationNameToIndex[tmpMaterial.StationName];
                    tmpMaterial.Text = All.Class.Num.ToString(dt.Rows[i]["Material"]);
                    tmpMaterial.Num = All.Class.Num.ToInt(dt.Rows[i]["MaterialNum"]);
                    if (tmpMaterial.WorkStation > 0 && tmpMaterial.Text != "")
                    {
                        AllMaterial.Add(tmpMaterial);
                    }
                }
            }
            if (frmMain.mMain.AllDataBase.Local.SaveMaterial(AllMaterial))
            {
                All.Window.MetroMessageBox.Show(this, "所有物料与工位对应数据已保存成功", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "物料与工位对应数据保存过程出现问题,问题原因请查看错误文档", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            switch (e.ColumnIndex)
            {
                case 0:
                    if (e.RowIndex == dt.Rows.Count - 1)//最后一行
                    {
                        dt.Rows[e.RowIndex]["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                        dr = dt.NewRow();
                        dr["Add"] = HeiFeiMidea.Properties.Resources.Add.ToBitmap();
                        dr["Up"] = HeiFeiMidea.Properties.Resources.Up.ToBitmap();
                        dr["Down"] = HeiFeiMidea.Properties.Resources.Down.ToBitmap();
                        dt.Rows.Add(dr);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        dt.Rows.RemoveAt(e.RowIndex);
                        dataGridView1.DataSource = dt;
                    }
                    break;
            }
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
    }

}
