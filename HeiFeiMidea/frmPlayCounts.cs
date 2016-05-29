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
    public partial class frmPlayCounts : frmPlayWindow
    {
        public frmPlayCounts()
        {
            InitializeComponent();
        }

        private void frmPlayCounts_Load(object sender, EventArgs e)
        {

            Init();
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
        private void Init()
        {
            Title title = new Title("今日每小时上线数量", Docking.Top, new Font("宋体", 16, FontStyle.Bold), Color.White);
            chart1.Titles.Add(title);
            //图示
            chart1.Legends[0].Enabled = true;
            chart1.Legends[0].BackColor = Color.Black;
            chart1.Legends[0].Docking = Docking.Right;
            chart1.Legends[0].ForeColor = Color.White;
            //3D
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LineColor = Color.White;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chart1.BackColor = Color.Black;//背景色

            //chart1.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chart1.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chart1.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chart1.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chart1.Series[0]["ColumnLabelStyle"] = "center";
            chart1.Series[0].LegendText = "产量(台)";
            chart1.Series[0].LabelFormat = "{0}(台)";

            chart1.Palette = ChartColorPalette.None;
            chart1.PaletteCustomColors = new Color[] { Color.Green };

            title = new Title("今日每小时下线数量", Docking.Top, new Font("宋体", 18, FontStyle.Bold), Color.White);
            chart2.Titles.Add(title);
            //图示
            chart2.Legends[0].Enabled = true;
            chart2.Legends[0].BackColor = Color.Black;
            chart2.Legends[0].Docking = Docking.Right;
            chart2.Legends[0].ForeColor = Color.White;
            //3D
            //chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            //图形类型
            chart2.Series[0].ChartType = SeriesChartType.Column;
            chart2.Series[0].IsValueShownAsLabel = true;

            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.LineColor = Color.White;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;//竖直网格线
            chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart2.ChartAreas[0].BackColor = Color.Black;//整体背景色
            chart2.BackColor = Color.Black;//背景色

            //chart1.ChartAreas[0].Area3DStyle.PointDepth = 5;//3D进深为20像素
            //chart1.Series[0]["DrawingStyle"] = "Cylinder";//圆柱


            chart2.Series[0].LabelForeColor = Color.White;//圆柱上方文字颜色
            chart2.Series[0].Font = new Font("黑体", 10, FontStyle.Bold);//圆柱上方文字字体
            chart2.Series[0]["ColumnLabelStyle"] = "center";
            chart2.Series[0].LegendText = "小时产量(台)";
            chart2.Series[0].LabelFormat = "{0}(台)";

            chart2.Palette = ChartColorPalette.None;
            chart2.PaletteCustomColors = new Color[] { Color.DarkOrange };
        }
        private void timFlush_Tick(object sender, EventArgs e)
        {

            itemTime.Value = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            itemAllCount.Value = frmMain.mMain.AllPCs.AllCountPerHour.AllCount.ToString();
            itemInLineCount.Value = frmMain.mMain.AllPCs.AllCountPerHour.InLineCount.ToString();
            itemOutLineCount.Value = frmMain.mMain.AllPCs.AllCountPerHour.OutLineCount.ToString();

            chart1.Series[0].Points.DataBindXY(frmMain.mMain.AllPCs.AllCountPerHour.TimeXLine, frmMain.mMain.AllPCs.AllCountPerHour.InCountLine);
            chart2.Series[0].Points.DataBindXY(frmMain.mMain.AllPCs.AllCountPerHour.TimeXLine, frmMain.mMain.AllPCs.AllCountPerHour.Z);
            
        }

        private void frmPlayCounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            timFlush.Enabled = false;
            timFlush.Stop();
        } 
    }
}
