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
    public partial class frmSetModeList : Form
    {
        public enum ModeLists
        {
            Mode,
            ZheWang
        }
        ModeLists ModeList = ModeLists.Mode;
        /// <summary>
        /// 返回机型
        /// </summary>
        public string ModeID
        { get; set; }
        public frmSetModeList(ModeLists modeList)
        {
            ModeID = "";
            ModeList = modeList;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmSetModeList_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData("","");
        }
        private void InitFrm()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView1.Columns["colID"].DataPropertyName = "ModeID";
            dataGridView1.Columns["colMode"].DataPropertyName = "Mode";
            dataGridView1.Columns["colInfo"].DataPropertyName = "ModeInfo";
        }
        private void InitData(string id,string mode)
        {
            bool initOk = false;
            DataTable dt = new DataTable();
            DataRow dr;
            switch (ModeList)
            {
                case ModeLists.Mode:
                    dt.Columns.Add("ModeID", typeof(string));
                    dt.Columns.Add("Mode", typeof(string));
                    dt.Columns.Add("ModeInfo", typeof(string));
                    List<HeiFeiMideaDll.ModeSet> allMode = HeiFeiMideaDll.ModeSet.GetModeList(frmMain.mMain.AllDataBase.LocalData);

                    allMode.ForEach(
                        tmpMode =>
                        {
                            if (tmpMode.ID.ToUpper().IndexOf(id.ToUpper()) >= 0
                                && tmpMode.Mode.ToUpper().IndexOf(mode.ToUpper()) >= 0)
                            {
                                dr = dt.NewRow();
                                dr["ModeID"] = tmpMode.ID;
                                dr["Mode"] = tmpMode.Mode;
                                dr["ModeInfo"] = tmpMode.Info;
                                dt.Rows.Add(dr);
                                initOk = true;
                            }
                        });
                    dataGridView1.DataSource = dt;
                    break;
                case ModeLists.ZheWang:
                    dt.Columns.Add("ModeID", typeof(string));
                    dt.Columns.Add("Mode", typeof(string));
                    dt.Columns.Add("ModeInfo", typeof(string));

                    List<HeiFeiMideaDll.ModeZheWangSet> allModeZheWang = HeiFeiMideaDll.ModeZheWangSet.GetModeList(frmMain.mMain.AllDataBase.LocalData);

                    allModeZheWang.ForEach(
                        tmpMode =>
                        {
                            if (tmpMode.ID.ToUpper().IndexOf(id.ToUpper()) >= 0
                                && tmpMode.Mode.ToUpper().IndexOf(mode.ToUpper()) >= 0)
                            {
                                dr = dt.NewRow();
                                dr["ModeID"] = tmpMode.ID;
                                dr["Mode"] = tmpMode.Mode;
                                dr["ModeInfo"] = tmpMode.Info;
                                dt.Rows.Add(dr);

                                initOk = true;
                            }
                        });
                    dataGridView1.DataSource = dt;
                    break;
            }
            if (initOk)
            {
                lblSelect.Text = All.Class.Num.ToString(dt.Rows[0][0]);
                btnOk.Enabled = true;
            }
            else
            {
                lblSelect.Text = "";
                btnOk.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ModeID = lblSelect.Text;
            if (ModeID != "")
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            InitData(txtID.Text, txtMode.Text);
        }

        private void txtMode_TextChanged(object sender, EventArgs e)
        {
            InitData(txtID.Text, txtMode.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0
                && e.ColumnIndex < dataGridView1.Columns.Count
                && e.RowIndex >= 0
                && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                lblSelect.Text = All.Class.Num.ToString(dt.Rows[e.RowIndex][0]);
                btnOk.Enabled = true;
            }
        }
    }
}
