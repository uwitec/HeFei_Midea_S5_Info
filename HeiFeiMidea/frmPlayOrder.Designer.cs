namespace HeiFeiMidea
{
    partial class frmPlayOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayOrder));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.itemCurCount = new All.Control.Metro.ItemBox();
            this.itemNeedCount = new All.Control.Metro.ItemBox();
            this.itemOrderCount = new All.Control.Metro.ItemBox();
            this.itemTime = new All.Control.Metro.ItemBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timFlush = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemCurCount
            // 
            this.itemCurCount.BackColor = System.Drawing.Color.White;
            this.itemCurCount.CanFouce = false;
            this.itemCurCount.Check = true;
            this.itemCurCount.CheckColor = System.Drawing.Color.Blue;
            this.itemCurCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemCurCount.Icon")));
            this.itemCurCount.Location = new System.Drawing.Point(224, 146);
            this.itemCurCount.Name = "itemCurCount";
            this.itemCurCount.Size = new System.Drawing.Size(198, 73);
            this.itemCurCount.TabIndex = 29;
            this.itemCurCount.Text = "itemBox4";
            this.itemCurCount.Title = "实际产量";
            this.itemCurCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCurCount.Value = "this is ItemBox";
            this.itemCurCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemNeedCount
            // 
            this.itemNeedCount.BackColor = System.Drawing.Color.White;
            this.itemNeedCount.CanFouce = false;
            this.itemNeedCount.Check = true;
            this.itemNeedCount.CheckColor = System.Drawing.Color.Green;
            this.itemNeedCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemNeedCount.Icon")));
            this.itemNeedCount.Location = new System.Drawing.Point(17, 146);
            this.itemNeedCount.Name = "itemNeedCount";
            this.itemNeedCount.Size = new System.Drawing.Size(198, 73);
            this.itemNeedCount.TabIndex = 28;
            this.itemNeedCount.Text = "itemBox3";
            this.itemNeedCount.Title = "目标产量";
            this.itemNeedCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNeedCount.Value = "this is ItemBox";
            this.itemNeedCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemOrderCount
            // 
            this.itemOrderCount.BackColor = System.Drawing.Color.White;
            this.itemOrderCount.CanFouce = false;
            this.itemOrderCount.Check = true;
            this.itemOrderCount.CheckColor = System.Drawing.Color.Olive;
            this.itemOrderCount.Icon = ((System.Drawing.Image)(resources.GetObject("itemOrderCount.Icon")));
            this.itemOrderCount.Location = new System.Drawing.Point(224, 65);
            this.itemOrderCount.Name = "itemOrderCount";
            this.itemOrderCount.Size = new System.Drawing.Size(198, 73);
            this.itemOrderCount.TabIndex = 27;
            this.itemOrderCount.Text = "itemBox2";
            this.itemOrderCount.Title = "订单数量";
            this.itemOrderCount.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemOrderCount.Value = "this is ItemBox";
            this.itemOrderCount.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.itemTime.TabIndex = 26;
            this.itemTime.Text = "itemBox1";
            this.itemTime.Title = "当前时间 ";
            this.itemTime.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTime.Value = "2015-11-27 15:22";
            this.itemTime.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Black;
            chartArea1.BorderWidth = 10;
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
            this.chart2.TabIndex = 25;
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
            this.chart1.TabIndex = 24;
            this.chart1.Text = "chart1";
            // 
            // timFlush
            // 
            this.timFlush.Interval = 500;
            this.timFlush.Tick += new System.EventHandler(this.timFlush_Tick);
            // 
            // frmPlayOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.itemCurCount);
            this.Controls.Add(this.itemNeedCount);
            this.Controls.Add(this.itemOrderCount);
            this.Controls.Add(this.itemTime);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "frmPlayOrder";
            this.Text = "生产信息化 － 订单状态";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayOrder_Load);
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.chart2, 0);
            this.Controls.SetChildIndex(this.itemTime, 0);
            this.Controls.SetChildIndex(this.itemOrderCount, 0);
            this.Controls.SetChildIndex(this.itemNeedCount, 0);
            this.Controls.SetChildIndex(this.itemCurCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.Metro.ItemBox itemCurCount;
        private All.Control.Metro.ItemBox itemNeedCount;
        private All.Control.Metro.ItemBox itemOrderCount;
        private All.Control.Metro.ItemBox itemTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timFlush;
    }
}