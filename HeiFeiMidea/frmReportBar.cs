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
    public partial class frmReportBar : All.Window.MainWindow
    {
    //    const int ShowAllHeight = 154;
    //    const int ShowMainHeight = 41;
        //bool showAll = true;
        public frmReportBar()
        {
            InitializeComponent();
        }

        private void frmReportBar_Load(object sender, EventArgs e)
        {
           // btnShowAll_Click(btnShowAll, new EventArgs());
            InitFrm();
        }
        private void InitFrm()
        {
            cbbOrder.Items.Clear();
            List<string> allOrder = HeiFeiMideaDll.OrderSet.GetOrder(frmMain.mMain.AllDataBase.ReportData);
            allOrder.ForEach(
                order =>
                {
                    cbbOrder.Items.Add(order);
                });
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].HeaderCell.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView1.Columns["colOrder"].DataPropertyName = "OrderName";
            dataGridView1.Columns["colBarCode"].DataPropertyName = "BarCode";
            dataGridView1.Columns["colBoShi"].DataPropertyName = "BoShiBarCode";
            dataGridView1.Columns["colLenNing"].DataPropertyName = "LenNingCode";
            dataGridView1.Columns["colInTime"].DataPropertyName = "InLineTime";
            dataGridView1.Columns["colOutLine"].DataPropertyName = "OutLine";
            dataGridView1.Columns["colInTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView1.Columns["colDetail"].DefaultCellStyle.NullValue = "详细";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //showAll = !showAll;
            //if (showAll)
            //{
            //    panTtile.Height = ShowAllHeight;
            //    btnShowAll.BackgroundImage = HeiFeiMidea.Properties.Resources.Upload___01;
            //}
            //else
            //{
            //    panTtile.Height = ShowMainHeight;
            //    btnShowAll.BackgroundImage = HeiFeiMidea.Properties.Resources.Download___01;
            //}
        }

        private void txtBar_Enter(object sender, EventArgs e)
        {
            if (txtBar.ForeColor != Color.Black)
            {
                txtBar.Text = "";
                txtBar.ForeColor = Color.Black;
            }
        }
        private void txtBoshi_Enter(object sender, EventArgs e)
        {
            if (txtBoshi.ForeColor != Color.Black)
            {
                txtBoshi.Text = "";
                txtBoshi.ForeColor = Color.Black;
            }

        }

        private void cbbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbOrder.ForeColor != Color.Black)
            {
                cbbOrder.ForeColor = Color.Black;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = frmMain.mMain.AllDataBase.ReportData.Read(GetSQL());
        }
        private string GetSQL()
        {
            dataGridView1.Focus();
            string sql = "";
            string tiaoJian = " where 1=1 ";
            sql = "select OrderName,BarCode,BoShiBarCode,LenNingCode,OutLine,InLineTime from TestAll";
            if (chkBarCode.Checked)
            {
                if (txtBar.Text.Replace("输入美的条码", "").Length > 3)
                {
                    tiaoJian = string.Format("{0} and BarCode  like '%{1}%'", tiaoJian, txtBar.Text.Replace("输入美的条码", ""));
                }
                else
                {
                    tiaoJian = string.Format("{0} and BoShiBarCode Like '%{1}%'", tiaoJian, txtBoshi.Text.Replace("输入博世条码", ""));
                }
            }
            if (chkOrderName.Checked)
            {
                tiaoJian = string.Format("{0} and orderName='{1}'", tiaoJian, cbbOrder.Text);
            }
            if (chkDate.Checked)
            {
                tiaoJian = string.Format("{0} and InLineTime>='{1:yyyy-MM-dd 00:00:00}'", tiaoJian, dateTimePicker2.Value);
                tiaoJian = string.Format("{0} and InLineTime<='{1:yyyy-MM-dd 23:59:59}'", tiaoJian, dateTimePicker1.Value);
            }
            switch (cbbOutLine.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    tiaoJian = string.Format("{0} and OutLine='false' ", tiaoJian);
                    break;
                case 2:
                    tiaoJian = string.Format("{0} and OutLine='true' ", tiaoJian);
                    break;
            }
            sql = string.Format("{0} {1} order by InLineTime desc", sql, tiaoJian);
            return sql;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "详细" &&
                e.RowIndex >= 0)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                string barCode = All.Class.Num.ToString(dt.Rows[e.RowIndex]["BarCode"]);
                string lenNingCode = All.Class.Num.ToString(dt.Rows[e.RowIndex]["LenNingCode"]);
                if (barCode == "" && lenNingCode == "")
                {
                    All.Window.MetroMessageBox.Show(this, "当前选择行条码为空，不能查看详细信息", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmReportDetail frd = new frmReportDetail(barCode,lenNingCode);
                frd.ShowDialog();
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Report.frmMainList fm = new Report.frmMainList(frmMain.mMain.AllDataBase.ReportData, GetSQL());
            fm.ShowDialog();
        }

    }
}
