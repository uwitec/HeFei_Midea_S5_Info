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
    public partial class frmSetStation : All.Window.MainWindow
    {
        public frmSetStation()
        {
            InitializeComponent();
        }

        private void frmSetStation_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitFrm()
        {
            dataGridView1.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].HeaderCell.Style.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }
            dataGridView1.Columns["colIndex"].DataPropertyName = "WorkStation";
            dataGridView1.Columns["colText"].DataPropertyName = "StationName";
            dataGridView1.Columns["colUse"].DataPropertyName = "TestStation";
            dataGridView1.Columns["colTime"].DataPropertyName = "TimeOut";
        }
        private void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("WorkStation", typeof(int));
            dt.Columns.Add("StationName", typeof(string));
            dt.Columns.Add("TestStation", typeof(bool));
            dt.Columns.Add("TimeOut", typeof(int));
            DataRow dr;
            for (int i = 0; i < frmMain.mMain.AllCars.AllInfoLineStation.Length; i++)
            {
                dr = dt.NewRow();
                dr["WorkStation"] = frmMain.mMain.AllCars.AllInfoLineStation[i].WorkStation;
                dr["StationName"] = frmMain.mMain.AllCars.AllInfoLineStation[i].StationName;
                dr["TestStation"] = frmMain.mMain.AllCars.AllInfoLineStation[i].TestStation;
                dr["TimeOut"] = frmMain.mMain.AllCars.AllInfoLineStation[i].TimeOut;
                dt.Rows.Add(dr);
            }
            
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            List<HeiFeiMideaDll.cDataLocal.InfoLineStation> infoLineStations = new List<HeiFeiMideaDll.cDataLocal.InfoLineStation>();
            HeiFeiMideaDll.cDataLocal.InfoLineStation tmpInfoLineStation;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tmpInfoLineStation = new HeiFeiMideaDll.cDataLocal.InfoLineStation();
                tmpInfoLineStation.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                tmpInfoLineStation.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                tmpInfoLineStation.TestStation = All.Class.Num.ToBool(dt.Rows[i]["TestStation"]);
                tmpInfoLineStation.TimeOut = All.Class.Num.ToInt(dt.Rows[i]["TimeOut"]);
                if (tmpInfoLineStation.StationName == "")
                {
                    All.Window.MetroMessageBox.Show(this, "对不起,工位的名称不能为空,请输入工位名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tmpInfoLineStation.TestStation && tmpInfoLineStation.TimeOut < 0)
                {
                    All.Window.MetroMessageBox.Show(this, "对不起,输入的超时时间错误,检测工位的时间不能小于0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                infoLineStations.Add(tmpInfoLineStation);
            }
            bool result = frmMain.mMain.AllDataBase.Local.SaveInfoLineStation(infoLineStations);
            if (result)
            {
                All.Window.MetroMessageBox.Show(this, "所有数据保存完毕,请重新启动程序以应用这些设置", "保存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "数据保存失败,请检查数据的正确性后再重新保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
