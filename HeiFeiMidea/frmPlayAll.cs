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
    public partial class frmPlayAll :frmPlayWindow
    {
        public frmPlayAll()
        {
            InitializeComponent();
        }

        private void frmPlayAll_Load(object sender, EventArgs e)
        {
            InitFrm();
            timFlush.Enabled = true;
        }
        public override void HideWindow()
        {
            timFlush.Enabled = false;
        }
        public override void ShowWindow()
        {
            timFlush.Enabled = true;
        }
        private void InitFrm()
        {
            #region//小时产量
            Title title = new Title("今日小时下线数量", Docking.Top, new Font("宋体", 18, FontStyle.Bold), Color.White);
            chartHour.Titles.Add(title);
            //图示
            chartHour.Legends[0].Enabled = false;
            chartHour.Legends[0].BackColor = Color.Black;
            chartHour.Legends[0].Docking = Docking.Right;
            chartHour.Legends[0].ForeColor = Color.White;
            //3D
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chartHour.Series[0].ChartType = SeriesChartType.Column;
            chartHour.Series[0].IsValueShownAsLabel = true;

            chartHour.ChartAreas[0].AxisX.Interval = 1;
            chartHour.ChartAreas[0].AxisX.LineColor = Color.White;
            chartHour.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chartHour.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chartHour.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartHour.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chartHour.BackColor = Color.Black;//背景色

            //chart1.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chart1.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chartHour.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chartHour.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chartHour.Series[0]["ColumnLabelStyle"] = "center";
            chartHour.Series[0].LegendText = "小时产量(台)";
            chartHour.Series[0].LabelFormat = "{0}(台)";
            

            chartHour.Palette = ChartColorPalette.None;
            chartHour.PaletteCustomColors = new Color[] { Color.Green };
            #endregion
            #region//订单
            
            title = new Title("今日产量信息", Docking.Top, new Font("宋体", 16, FontStyle.Bold), Color.White);
            chartOrder.Titles.Add(title);
            //图示
            chartOrder.Legends[0].Enabled = false;
            chartOrder.Legends[0].BackColor = Color.Black;
            chartOrder.Legends[0].Docking = Docking.Right;
            chartOrder.Legends[0].ForeColor = Color.White;
            //3D
            //chartOrder.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chartOrder.Series[0].ChartType = SeriesChartType.Column;
            chartOrder.Series[0].IsValueShownAsLabel = true;

            chartOrder.ChartAreas[0].AxisX.Interval = 1;
            chartOrder.ChartAreas[0].AxisX.LineColor = Color.White;
            chartOrder.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chartOrder.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chartOrder.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartOrder.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chartOrder.BackColor = Color.Black;//背景色

            //chartOrder.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chartOrder.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chartOrder.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chartOrder.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chartOrder.Series[0]["ColumnLabelStyle"] = "center";
            chartOrder.Series[0].LegendText = "目标产量(台)";
            chartOrder.Series[0].LabelFormat = "{0}(台)";

            chartOrder.Palette = ChartColorPalette.None;
            chartOrder.PaletteCustomColors = new Color[] { Color.Blue };
            #endregion
            #region//瓶颈前三位
            
            title = new Title("瓶颈岗位前三名", Docking.Top, new Font("宋体", 16, FontStyle.Bold), Color.White);
            chartSlow.Titles.Add(title);
            //图示
            chartSlow.Legends[0].Enabled = false;
            chartSlow.Legends[0].BackColor = Color.Black;
            chartSlow.Legends[0].Docking = Docking.Right;
            chartSlow.Legends[0].ForeColor = Color.White;
            //3D
            //chartSlow.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chartSlow.Series[0].ChartType = SeriesChartType.Column;
            chartSlow.Series[0].IsValueShownAsLabel = true;

            chartSlow.ChartAreas[0].AxisX.Interval = 1;
            chartSlow.ChartAreas[0].AxisX.LineColor = Color.White;
            chartSlow.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chartSlow.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chartSlow.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartSlow.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chartSlow.BackColor = Color.Black;//背景色

            //chartSlow.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chartSlow.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chartSlow.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chartSlow.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chartSlow.Series[0]["ColumnLabelStyle"] = "center";
            chartSlow.Series[0].LegendText = "平均节拍(秒)";
            chartSlow.Series[0].LabelFormat = "{0}(秒)";

            chartSlow.Palette = ChartColorPalette.None;
            chartSlow.PaletteCustomColors = new Color[] { Color.DarkRed };
            #endregion
            #region//故障前三位
            
            title = new Title("内部缺陷前三位", Docking.Top, new Font("宋体", 16, FontStyle.Bold), Color.White);
            chartError.Titles.Add(title);
            //图示
            chartError.Legends[0].Enabled = false;
            chartError.Legends[0].BackColor = Color.Black;
            chartError.Legends[0].Docking = Docking.Right;
            chartError.Legends[0].ForeColor = Color.White;
            //3D
            //chartError.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chartError.Series[0].ChartType = SeriesChartType.Column;
            chartError.Series[0].IsValueShownAsLabel = true;

            chartError.ChartAreas[0].AxisX.Interval = 1;
            chartError.ChartAreas[0].AxisX.LineColor = Color.White;
            chartError.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chartError.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chartError.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chartError.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chartError.BackColor = Color.Black;//背景色

            //chartError.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chartError.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chartError.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chartError.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chartError.Series[0]["ColumnLabelStyle"] = "center";
            chartError.Series[0].LegendText = "故障数量(次)";
            chartError.Series[0].LabelFormat = "{0}(次)";

            chartError.Palette = ChartColorPalette.None;
            chartError.PaletteCustomColors = new Color[] { Color.Orange };
            #endregion
            InitOEEGrid();
        }
        private void InitOEEGrid()
        { 
            #region//OEE表格
            dataGridView1.Font = new Font("宋体", 12, FontStyle.Regular);
            for (int i = frmMain.mMain.FlushOEE.OEETimes.Count; i < 24; i++)
            {
                dataGridView1.Columns.Remove(string.Format("colData{0}", i + 1));
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Black;
                dataGridView1.Columns[i].DefaultCellStyle.ForeColor = Color.White;
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 27;
            dataGridView1.Rows[1].Height = 27;
            dataGridView1.Rows[2].Height = 27;
            dataGridView1.Rows[3].Height = 27;
            dataGridView1.Rows[0].Cells[0].Value = "时间段";
            dataGridView1.Rows[1].Cells[0].Value = "实际产出";
            dataGridView1.Rows[2].Cells[0].Value = "OEE";
            dataGridView1.Rows[3].Cells[0].Value = "表现";
            DataGridViewImageCell imageCell;
            for (int i = 0; i < frmMain.mMain.FlushOEE.OEETimes.Count; i++)
            {
                if (frmMain.mMain.FlushOEE.OEETimes[i].UseTime)
                {
                    dataGridView1.Rows[0].Cells[i + 1].Value = frmMain.mMain.FlushOEE.OEEShow[i];
                    dataGridView1.Rows[1].Cells[i + 1].Value = 0;
                    dataGridView1.Rows[2].Cells[i + 1].Value = 0;
                    imageCell = new DataGridViewImageCell();
                    imageCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCell.Value = HeiFeiMidea.Properties.Resources.Black;
                    dataGridView1.Rows[3].Cells[i + 1] = imageCell;
                }
                else
                {
                    dataGridView1.Columns[i + 1].Visible = false;
                }
            }
            #endregion
        }
        private void frmPlayAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            timFlush.Enabled = false;
            timFlush.Stop();
        }

        private void timFlush_Tick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            float tmpValue = 0;
            float tmpCount = 0;
            float tmpTime = 0;
            DateTime now=DateTime.Now;
            switch (frmMain.mMain.FlushOEE.Smile)
            {
                case FlushOEE.SmileList.优:
                    picOEE.Image = HeiFeiMidea.Properties.Resources.OK;
                    break;
                case FlushOEE.SmileList.良:
                    picOEE.Image = HeiFeiMidea.Properties.Resources.Test;
                    break;
                case FlushOEE.SmileList.差:
                    picOEE.Image = HeiFeiMidea.Properties.Resources.Sad;
                    break;
            }
            //订单产量
            List<string> x = new List<string>();
            List<int> y = new List<int>();
            x.Add("目标产量");
            x.Add("上线产量");
            x.Add("下线产量");
            y.Add(frmMain.mMain.AllDataXml.LocalSet.TodayCount);
            y.Add(frmMain.mMain.AllPCs.AllCountPerHour.InLineCount);
            y.Add(frmMain.mMain.AllPCs.AllCountPerHour.OutLineCount);
            chartOrder.Series[0].Points.DataBindXY(x, y);

            //小时产量
            //chartHour.Series[0].Points.DataBindXY(frmMain.mMain.AllPCs.AllCountPerHour.TimeXLine, frmMain.mMain.AllPCs.AllCountPerHour.Z);
            chartHour.Series[0].Points.DataBindXY(frmMain.mMain.FlushOEE.OEEShow, frmMain.mMain.FlushOEE.OEECount);

            //瓶颈岗位
            chartSlow.Series[0].Points.DataBindXY(frmMain.mMain.AllPCs.AllStatueTick.SlowName,
                frmMain.mMain.AllPCs.AllStatueTick.SlowAverageTime);

            //故障
            if (frmMain.mMain.FlushAllError.ShowErrorTable != null)
            {
                chartError.Series[0].Points.DataBind(frmMain.mMain.FlushAllError.ShowErrorTable.AsEnumerable(), "Error", "AllErrors", "");
            }
            //小时OEE
            for (int i = 0; i < frmMain.mMain.FlushOEE.OEECount.Count && i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Rows[1].Cells[i + 1].Value = frmMain.mMain.FlushOEE.OEECount[i];
                tmpCount = 0;
                tmpTime = 0;
                for (int j = 0; j <= i; j++)
                {
                    tmpCount += frmMain.mMain.FlushOEE.OEECount[j];
                    tmpTime += frmMain.mMain.FlushOEE.OEETimes[j].TotalTime;
                }
                //减去当前小时段还没有过去的时间
                if ((frmMain.mMain.FlushOEE.OEETimes[i].HourEnd * 60 + frmMain.mMain.FlushOEE.OEETimes[i].MinEnd) >
                    (now.Hour * 60 + now.Minute))
                {
                    tmpTime -= (frmMain.mMain.FlushOEE.OEETimes[i].HourEnd * 60 + frmMain.mMain.FlushOEE.OEETimes[i].MinEnd -
                        now.Hour * 60 - now.Minute) / 60.0f;
                }
                if (tmpTime > 0 && frmMain.mMain.AllDataXml.LocalSet.OEECount > 0)
                {
                    tmpValue = (tmpCount * 100.0f)
                            / tmpTime
                            / frmMain.mMain.AllDataXml.LocalSet.OEECount;
                }

                if ((frmMain.mMain.FlushOEE.OEETimes[i].HourStart * 60 + frmMain.mMain.FlushOEE.OEETimes[i].MinStart) < (DateTime.Now.Hour * 60 + DateTime.Now.Minute))
                {
                    if (frmMain.mMain.FlushOEE.OEETimes[i].TotalTime > 0 && frmMain.mMain.AllDataXml.LocalSet.OEECount > 0)
                    {
                        dataGridView1.Rows[2].Cells[i + 1].Value = string.Format("{0:F3}%", tmpValue);
                    }
                    if (tmpValue >= frmMain.mMain.AllDataXml.LocalSet.OEEGreet)
                    {
                        dataGridView1.Rows[3].Cells[i + 1].Value = HeiFeiMidea.Properties.Resources.OK;
                    }
                    else if (tmpValue >= frmMain.mMain.AllDataXml.LocalSet.OEEPass )
                    {
                        dataGridView1.Rows[3].Cells[i + 1].Value = HeiFeiMidea.Properties.Resources.Test;
                    }
                    else
                    {
                        dataGridView1.Rows[3].Cells[i + 1].Value = HeiFeiMidea.Properties.Resources.Sad;
                    }
                }
            }
            this.ResumeLayout();
        }
    }
}
