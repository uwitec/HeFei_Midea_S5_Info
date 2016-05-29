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
    public partial class frmSetBoShi : All.Window.MainWindow
    {
        public frmSetBoShi()
        {
            InitializeComponent();
        }

        private void frmSetBoShi_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitData()
        {

            Dictionary<string, HeiFeiMideaDll.cBoShi.BoShiValue> allMode = HeiFeiMideaDll.cBoShi.GetAllMode(frmMain.mMain.AllDataBase.LocalData);
            DataTable dt = new DataTable();
            dt.Columns.Add("Add", typeof(Image));
            dt.Columns.Add("Midea",typeof(string));
            dt.Columns.Add("Boshi",typeof(string));
            dt.Columns.Add("BoShiJiXing",typeof(string));
            DataRow dr;
            allMode.Keys.ToList().ForEach(
                mode =>
                {
                    dr = dt.NewRow();
                    dr["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                    dr["Midea"] = mode;
                    dr["BoShi"] = allMode[mode].ID;
                    dr["BoShiJiXing"] = allMode[mode].Mode;
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
            dataGridView1.Columns["colMidea"].DataPropertyName = "Midea";
            dataGridView1.Columns["colBoShi"].DataPropertyName = "Boshi";
            dataGridView1.Columns["colJiXing"].DataPropertyName = "BoShiJiXing";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            
            DataTable dt = (DataTable)dataGridView1.DataSource;
            Dictionary<string, HeiFeiMideaDll.cBoShi.BoShiValue> buff = new Dictionary<string, HeiFeiMideaDll.cBoShi.BoShiValue>();
                string midea ="";
                HeiFeiMideaDll.cBoShi.BoShiValue boshi = new HeiFeiMideaDll.cBoShi.BoShiValue("", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                midea = All.Class.Num.ToString(dt.Rows[i]["Midea"]);
                boshi = new HeiFeiMideaDll.cBoShi.BoShiValue(
                    All.Class.Num.ToString(dt.Rows[i]["Boshi"]),
                    All.Class.Num.ToString(dt.Rows[i]["BoShiJiXing"]));
                if (!buff.ContainsKey(midea))
                {
                    buff.Add(midea, boshi);
                }
            }
            if (HeiFeiMideaDll.cBoShi.SaveAllMode(buff, frmMain.mMain.AllDataBase.LocalData))
            {
                All.Window.MetroMessageBox.Show(this, "所有机型已成功保存到数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "机型数据保存失败，请检查后再重新尝试", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
