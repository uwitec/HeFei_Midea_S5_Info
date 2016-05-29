namespace HeiFeiMidea
{
    partial class frmPlayTick
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayTick));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.itemTime = new All.Control.Metro.ItemBox();
            this.itemSlow1 = new All.Control.Metro.ItemBox();
            this.itemSlow2 = new All.Control.Metro.ItemBox();
            this.itemSlow3 = new All.Control.Metro.ItemBox();
            this.timFlush = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(423, 61);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(526, 169);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            // 
            // itemTime
            // 
            this.itemTime.BackColor = System.Drawing.Color.White;
            this.itemTime.CanFouce = false;
            this.itemTime.Check = true;
            this.itemTime.CheckColor = System.Drawing.Color.Red;
            this.itemTime.Icon = ((System.Drawing.Image)(resources.GetObject("itemTime.Icon")));
            this.itemTime.Location = new System.Drawing.Point(17, 64);
            this.itemTime.Name = "itemTime";
            this.itemTime.Size = new System.Drawing.Size(198, 73);
            this.itemTime.TabIndex = 14;
            this.itemTime.Text = "itemBox1";
            this.itemTime.Title = "当前时间 ";
            this.itemTime.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTime.Value = "2015-11-27 15:22";
            this.itemTime.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemSlow1
            // 
            this.itemSlow1.BackColor = System.Drawing.Color.White;
            this.itemSlow1.CanFouce = false;
            this.itemSlow1.Check = true;
            this.itemSlow1.CheckColor = System.Drawing.Color.Olive;
            this.itemSlow1.Icon = ((System.Drawing.Image)(resources.GetObject("itemSlow1.Icon")));
            this.itemSlow1.Location = new System.Drawing.Point(224, 64);
            this.itemSlow1.Name = "itemSlow1";
            this.itemSlow1.Size = new System.Drawing.Size(198, 73);
            this.itemSlow1.TabIndex = 15;
            this.itemSlow1.Text = "itemBox2";
            this.itemSlow1.Title = "瓶颈岗位一";
            this.itemSlow1.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSlow1.Value = "";
            this.itemSlow1.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemSlow2
            // 
            this.itemSlow2.BackColor = System.Drawing.Color.White;
            this.itemSlow2.CanFouce = false;
            this.itemSlow2.Check = true;
            this.itemSlow2.CheckColor = System.Drawing.Color.Green;
            this.itemSlow2.Icon = ((System.Drawing.Image)(resources.GetObject("itemSlow2.Icon")));
            this.itemSlow2.Location = new System.Drawing.Point(17, 145);
            this.itemSlow2.Name = "itemSlow2";
            this.itemSlow2.Size = new System.Drawing.Size(198, 73);
            this.itemSlow2.TabIndex = 16;
            this.itemSlow2.Text = "itemBox3";
            this.itemSlow2.Title = "瓶颈岗位二";
            this.itemSlow2.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSlow2.Value = "";
            this.itemSlow2.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // itemSlow3
            // 
            this.itemSlow3.BackColor = System.Drawing.Color.White;
            this.itemSlow3.CanFouce = false;
            this.itemSlow3.Check = true;
            this.itemSlow3.CheckColor = System.Drawing.Color.Blue;
            this.itemSlow3.Icon = ((System.Drawing.Image)(resources.GetObject("itemSlow3.Icon")));
            this.itemSlow3.Location = new System.Drawing.Point(224, 145);
            this.itemSlow3.Name = "itemSlow3";
            this.itemSlow3.Size = new System.Drawing.Size(198, 73);
            this.itemSlow3.TabIndex = 17;
            this.itemSlow3.Text = "itemBox4";
            this.itemSlow3.Title = "瓶颈岗位三";
            this.itemSlow3.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSlow3.Value = "";
            this.itemSlow3.ValueFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // timFlush
            // 
            this.timFlush.Interval = 500;
            this.timFlush.Tick += new System.EventHandler(this.timFlush_Tick);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 221);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(930, 307);
            this.chart2.TabIndex = 18;
            this.chart2.Text = "chart2";
            // 
            // frmPlayTick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.itemSlow3);
            this.Controls.Add(this.itemSlow2);
            this.Controls.Add(this.itemSlow1);
            this.Controls.Add(this.itemTime);
            this.Controls.Add(this.chart1);
            this.Name = "frmPlayTick";
            this.Text = "生产信息化 － 瓶颈岗位";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayTick_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayTick_Load);
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.itemTime, 0);
            this.Controls.SetChildIndex(this.itemSlow1, 0);
            this.Controls.SetChildIndex(this.itemSlow2, 0);
            this.Controls.SetChildIndex(this.itemSlow3, 0);
            this.Controls.SetChildIndex(this.chart2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private All.Control.Metro.ItemBox itemTime;
        private All.Control.Metro.ItemBox itemSlow1;
        private All.Control.Metro.ItemBox itemSlow2;
        private All.Control.Metro.ItemBox itemSlow3;
        private System.Windows.Forms.Timer timFlush;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}