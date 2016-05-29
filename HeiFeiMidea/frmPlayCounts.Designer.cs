namespace HeiFeiMidea
{
    partial class frmPlayCounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayCounts));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.itemOutLineCount = new All.Control.Metro.ItemBox();
            this.itemInLineCount = new All.Control.Metro.ItemBox();
            this.itemAllCount = new All.Control.Metro.ItemBox();
            this.itemTime = new All.Control.Metro.ItemBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timFlush = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemOutLineCount
            // 
            this.itemOutLineCount.BackColor = System.Drawing.Color.White;
            this.itemOutLineCount.CanFouce = false;
            this.itemOutLineCount.Check = true;
            this.itemOutLineCount.CheckColor = System.Drawing.Color.Blue;
            this.itemOutLineCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemOutLineCount.Icon")));
            this.itemOutLineCount.Location = new System.Drawing.Point(224, 146);
            this.itemOutLineCount.Name = "itemOutLineCount";
            this.itemOutLineCount.Size = new System.Drawing.Size(198, 73);
            this.itemOutLineCount.TabIndex = 23;
            this.itemOutLineCount.Text = "itemBox4";
            this.itemOutLineCount.Title = "下线产量";
            this.itemOutLineCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemOutLineCount.Value = "this is ItemBox";
            this.itemOutLineCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemInLineCount
            // 
            this.itemInLineCount.BackColor = System.Drawing.Color.White;
            this.itemInLineCount.CanFouce = false;
            this.itemInLineCount.Check = true;
            this.itemInLineCount.CheckColor = System.Drawing.Color.Green;
            this.itemInLineCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemInLineCount.Icon")));
            this.itemInLineCount.Location = new System.Drawing.Point(17, 146);
            this.itemInLineCount.Name = "itemInLineCount";
            this.itemInLineCount.Size = new System.Drawing.Size(198, 73);
            this.itemInLineCount.TabIndex = 22;
            this.itemInLineCount.Text = "itemBox3";
            this.itemInLineCount.Title = "上线产量";
            this.itemInLineCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemInLineCount.Value = "this is ItemBox";
            this.itemInLineCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemAllCount
            // 
            this.itemAllCount.BackColor = System.Drawing.Color.White;
            this.itemAllCount.CanFouce = false;
            this.itemAllCount.Check = true;
            this.itemAllCount.CheckColor = System.Drawing.Color.Olive;
            this.itemAllCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemAllCount.Icon")));
            this.itemAllCount.Location = new System.Drawing.Point(224, 65);
            this.itemAllCount.Name = "itemAllCount";
            this.itemAllCount.Size = new System.Drawing.Size(198, 73);
            this.itemAllCount.TabIndex = 21;
            this.itemAllCount.Text = "itemBox2";
            this.itemAllCount.Title = "目标产量";
            this.itemAllCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemAllCount.Value = "this is ItemBox";
            this.itemAllCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemTime
            // 
            this.itemTime.BackColor = System.Drawing.Color.White;
            this.itemTime.CanFouce = false;
            this.itemTime.Check = true;
            this.itemTime.CheckColor = System.Drawing.Color.Red;
            this.itemTime.Icon = ((System.Drawing.Image)(resources.GetObject("itemTime.Icon")));
            this.itemTime.Location = new System.Drawing.Point(17, 65);
            this.itemTime.Name = "itemTime";
            this.itemTime.Size = new System.Drawing.Size(198, 73);
            this.itemTime.TabIndex = 20;
            this.itemTime.Text = "itemBox1";
            this.itemTime.Title = "当前时间 ";
            this.itemTime.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTime.Value = "2015-11-27 15:22";
            this.itemTime.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(11, 240);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(937, 293);
            this.chart2.TabIndex = 19;
            this.chart2.Text = "chart2";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(423, 65);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(526, 169);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // timFlush
            // 
            this.timFlush.Interval = 500;
            this.timFlush.Tick += new System.EventHandler(this.timFlush_Tick);
            // 
            // frmPlayCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.itemOutLineCount);
            this.Controls.Add(this.itemInLineCount);
            this.Controls.Add(this.itemAllCount);
            this.Controls.Add(this.itemTime);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "frmPlayCounts";
            this.Text = "生产信息化 － 小时生产产量";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayCounts_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayCounts_Load);
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.chart2, 0);
            this.Controls.SetChildIndex(this.itemTime, 0);
            this.Controls.SetChildIndex(this.itemAllCount, 0);
            this.Controls.SetChildIndex(this.itemInLineCount, 0);
            this.Controls.SetChildIndex(this.itemOutLineCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.Metro.ItemBox itemOutLineCount;
        private All.Control.Metro.ItemBox itemInLineCount;
        private All.Control.Metro.ItemBox itemAllCount;
        private All.Control.Metro.ItemBox itemTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timFlush;
    }
}