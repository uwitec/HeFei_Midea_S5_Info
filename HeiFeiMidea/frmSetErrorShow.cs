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
    public partial class frmSetErrorShow : All.Window.MainWindow
    {
        public frmSetErrorShow()
        {
            InitializeComponent();
        }

        private void frmSetErrorShow_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitFrm()
        {
            string[] allNames = Enum.GetNames(typeof(FlushAllError.SpaceList));
            if (allNames == null || allNames.Length <= 0)
            {
                return;
            }
            int index=0;
            dataGridView1.Rows.Add(allNames.Length);
            allNames.ToList().ForEach(
                error =>
                {
                    dataGridView1.Rows[index].Cells["colIndex"].Value = index + 1;
                    dataGridView1.Rows[index].Cells["colText"].Value = string.Format("{0}  ->  故障显示", error);
                    dataGridView1.Rows[index].Cells["colValue"].Value = false;
                    index++;
                });
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void InitData()
        {
            for (int i = 0; i < frmMain.mMain.AllDataXml.ErrorShow.AllSheBeiShows.Length && i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["colValue"].Value = frmMain.mMain.AllDataXml.ErrorShow.AllSheBeiShows[i];
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < frmMain.mMain.AllDataXml.ErrorShow.AllSheBeiShows.Length && i < dataGridView1.Rows.Count; i++)
            {
                frmMain.mMain.AllDataXml.ErrorShow.AllSheBeiShows[i] = All.Class.Num.ToBool(dataGridView1.Rows[i].Cells["colValue"].Value);
            }
            frmMain.mMain.AllDataXml.ErrorShow.Save();
            All.Window.MetroMessageBox.Show(this, "当前数据已成功保存至数据库", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
