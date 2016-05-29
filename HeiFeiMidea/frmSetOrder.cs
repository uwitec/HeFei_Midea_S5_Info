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
    public partial class frmSetOrder : All.Window.MainWindow
    {
        public frmSetOrder()
        {
            InitializeComponent();
        }

        private void frmSetOrder_Load(object sender, EventArgs e)
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
            dataGridView1.Columns["colOrder"].DataPropertyName = "OrderName";
            dataGridView1.Columns["colBarCode"].DataPropertyName = "BarCode";
            dataGridView1.Columns["colBarStart"].DataPropertyName = "BarStart";
            dataGridView1.Columns["colBarEnd"].DataPropertyName = "BarEnd";
            dataGridView1.Columns["colMonth"].DataPropertyName = "OrderMonth";
            dataGridView1.Columns["colDay"].DataPropertyName = "OrderDay";
            dataGridView1.Columns["colBarLenNing"].DataPropertyName = "LenNingCode";
            dataGridView1.Columns["colBarLenNingStart"].DataPropertyName = "LenNingStart";
            dataGridView1.Columns["colBarLenNingEnd"].DataPropertyName = "LenNingEnd";
            dataGridView1.Columns["colPrintFile"].DataPropertyName = "PrintFile";
            dataGridView1.Columns["colMidea"].DataPropertyName = "BoShi";

            DataGridViewImageColumn vic = (DataGridViewImageColumn)dataGridView1.Columns["colAdd"];
            vic.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns["colAdd"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGridViewComboBoxColumn chkColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["colMidea"];
            chkColumn.Items.Add("美的");
            chkColumn.Items.Add("博世");
            chkColumn.DefaultCellStyle.NullValue = "美的";
            chkColumn.DefaultCellStyle.DataSourceNullValue = "美的";
        }
        private void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Add", typeof(Image));
            dt.Columns.Add("OrderName", typeof(string));
            dt.Columns.Add("BarCode", typeof(string));
            dt.Columns.Add("BarStart", typeof(int));
            dt.Columns.Add("BarEnd", typeof(int));
            dt.Columns.Add("OrderMonth", typeof(int));
            dt.Columns.Add("OrderDay", typeof(int));
            dt.Columns.Add("LenNingCode", typeof(string));
            dt.Columns.Add("LenNingStart", typeof(int));
            dt.Columns.Add("LenNingEnd", typeof(int));
            dt.Columns.Add("PrintFile", typeof(string));
            dt.Columns.Add("Boshi", typeof(string));
            DataRow dr;
            List<HeiFeiMideaDll.OrderSet> tmpOrder =HeiFeiMideaDll.OrderSet.GetOrder(frmMain.mMain.AllOrder, DateTime.Now);
            if (tmpOrder != null)
            {
                tmpOrder.ForEach
                (order =>
                {
                    dr = dt.NewRow();
                    dr["Add"] = HeiFeiMidea.Properties.Resources.Remove.ToBitmap();
                    dr["OrderName"] = order.OrderName;
                    dr["BarCode"] = order.BarCode;
                    dr["BarStart"] = order.BarStart;
                    dr["BarEnd"] = order.BarEnd;
                    dr["OrderMonth"] = order.OrderMonth;
                    dr["OrderDay"] = order.OrderDay;
                    dr["LenNingCode"] = order.LenNingCode;
                    dr["LenNingStart"] = order.LenNingStart;
                    dr["LenNingEnd"] = order.LenNingEnd;
                    dr["PrintFile"] = order.PrintFile;
                    dr["Boshi"] = order.BoShi;
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
                dt.Rows.Add(dr);
            }
            dataGridView1.DataSource = dt;
        }
        private List<HeiFeiMideaDll.OrderSet> GetData()
        {
            dataGridView1.EndEdit();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            DateTime now = DateTime.Now;
            List<HeiFeiMideaDll.OrderSet> result = new List<HeiFeiMideaDll.OrderSet>();
            HeiFeiMideaDll.OrderSet tmp;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                tmp = new HeiFeiMideaDll.OrderSet();
                tmp.OrderName = All.Class.Num.ToString(dt.Rows[i]["OrderName"]);
                tmp.BarCode = All.Class.Num.ToString(dt.Rows[i]["BarCode"]);
                tmp.BarStart = All.Class.Num.ToInt(dt.Rows[i]["BarStart"]);
                tmp.BarEnd = All.Class.Num.ToInt(dt.Rows[i]["BarEnd"]);
                tmp.LenNingCode = All.Class.Num.ToString(dt.Rows[i]["LenNingCode"]);
                tmp.LenNingStart = All.Class.Num.ToInt(dt.Rows[i]["LenNingStart"]);
                tmp.LenNingEnd = All.Class.Num.ToInt(dt.Rows[i]["LenNingEnd"]);
                tmp.PrintFile = All.Class.Num.ToString(dt.Rows[i]["PrintFile"]);
                tmp.BoShi = All.Class.Num.ToString(dt.Rows[i]["BoShi"]);
                tmp.OrderTime = now;
                tmp.OrderYear = now.Year;
                tmp.OrderMonth = All.Class.Num.ToInt(dt.Rows[i]["OrderMonth"]);
                tmp.OrderDay = All.Class.Num.ToInt(dt.Rows[i]["OrderDay"]);
                if (tmp.OrderName != "" && tmp.BarCode != "")
                {
                    result.Add(tmp);
                }
            }
            //检查当前条码格式是否已存在于记忆中
            List<string> BarFormatLists = frmMain.mMain.AllDataXml.LocalSet.FormatBarStr.ToList();
            result.ForEach(
                order =>
                {
                    string nowFormatStr = GetFormatStrFromBar(order.BarCode);
                    if (BarFormatLists.FindIndex(
                        barFormatList =>
                        {
                            return barFormatList == nowFormatStr;
                        }) < 0)
                    {
                        BarFormatLists.Add(nowFormatStr);
                        frmMain.mMain.AllDataXml.LocalSet.Save();
                    }
                });
            return result;
        }
        /// <summary>
        /// 将当前条码转化为通讯格式
        /// </summary>
        /// <param name="bar"></param>
        /// <returns></returns>
        private string GetFormatStrFromBar(string bar)
        {
            List<byte> result=new List<byte>();
            byte[] buff = Encoding.ASCII.GetBytes(bar);
            for (int i = 0; i < buff.Length; i++)
            {
                if (All.Class.Num.IsVisableHex(buff[i]))
                {
                    result.Add(0x30);
                }
                else
                {
                    result.Add(buff[i]);
                }
            }
            return Encoding.ASCII.GetString(result.ToArray());
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            openExcel.FileName = "订单文件";
            openExcel.Title = "打开指定的订单";
            openExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openExcel.Filter = "数据库文件|*.xlsx;*.xls";
            if (openExcel.ShowDialog() == DialogResult.OK)
            {

                All.Class.Excel excel = new All.Class.Excel();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (HeiFeiMideaDll.OrderSet.SaveOrder(GetData(),frmMain.mMain.AllDataBase.LocalData))
            {
                All.Window.MetroMessageBox.Show(this, "所有订单数据已成功保存至数据库", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain.mMain.AllOrder = HeiFeiMideaDll.OrderSet.GetOrder(1000, frmMain.mMain.AllDataBase.LocalData);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "订单数据保存失败，请查看故障记录后重新保存", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridView1.Columns.Count
                || e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }
            switch (dataGridView1.Columns[e.ColumnIndex].HeaderText)
            {
                case "标贴图像":
                    openAi.Filter = "AI文件|*.Ai";
                    openAi.InitialDirectory = frmMain.mMain.AllDataXml.LocalSet.AiDirectory;
                    openAi.Title = "标贴原始文件";
                    DataGridViewCell dgvc = dataGridView1.CurrentCell;
                    if (openAi.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openAi.FileName;
                        if (fileName.IndexOf(frmMain.mMain.AllDataXml.LocalSet.AiDirectory) < 0)
                        {
                            All.Window.MetroMessageBox.Show(this, string.Format("对不起，AI文件必须位于   {0}   文件夹目录下", frmMain.mMain.AllDataXml.LocalSet.AiDirectory), "错误的文件位置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvc.Value = fileName.Replace(frmMain.mMain.AllDataXml.LocalSet.AiDirectory, "");
                        //DataTable dt = (DataTable)dataGridView1.DataSource;
                        //dt.Rows[e.RowIndex][e.ColumnIndex] = fileName.Replace(frmMain.mMain.AllDataXml.LocalSet.AiDirectory, "");
                        //dataGridView1.DataSource = dt;
                    }
                    break;
            }
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
