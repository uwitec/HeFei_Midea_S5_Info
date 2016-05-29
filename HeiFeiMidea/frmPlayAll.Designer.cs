namespace HeiFeiMidea
{
    partial class frmPlayAll
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartOrder = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSlow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHour = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timFlush = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picOEE = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOEE)).BeginInit();
            this.SuspendLayout();
            // 
            // chartOrder
            // 
            this.chartOrder.BackColor = System.Drawing.Color.Black;
            this.chartOrder.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartOrder.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOrder.Legends.Add(legend1);
            this.chartOrder.Location = new System.Drawing.Point(16, 349);
            this.chartOrder.Name = "chartOrder";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartOrder.Series.Add(series1);
            this.chartOrder.Size = new System.Drawing.Size(305, 183);
            this.chartOrder.TabIndex = 17;
            this.chartOrder.Text = "chartOrder";
            // 
            // chartError
            // 
            this.chartError.BackColor = System.Drawing.Color.Black;
            this.chartError.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chartError.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartError.Legends.Add(legend2);
            this.chartError.Location = new System.Drawing.Point(643, 349);
            this.chartError.Name = "chartError";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartError.Series.Add(series2);
            this.chartError.Size = new System.Drawing.Size(305, 183);
            this.chartError.TabIndex = 18;
            this.chartError.Text = "chartError";
            // 
            // chartSlow
            // 
            this.chartSlow.BackColor = System.Drawing.Color.Black;
            this.chartSlow.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chartSlow.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSlow.Legends.Add(legend3);
            this.chartSlow.Location = new System.Drawing.Point(330, 349);
            this.chartSlow.Name = "chartSlow";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSlow.Series.Add(series3);
            this.chartSlow.Size = new System.Drawing.Size(305, 183);
            this.chartSlow.TabIndex = 19;
            this.chartSlow.Text = "chartSlow";
            // 
            // chartHour
            // 
            this.chartHour.BackColor = System.Drawing.Color.Black;
            this.chartHour.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartHour.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartHour.Legends.Add(legend4);
            this.chartHour.Location = new System.Drawing.Point(484, 61);
            this.chartHour.Name = "chartHour";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartHour.Series.Add(series4);
            this.chartHour.Size = new System.Drawing.Size(464, 206);
            this.chartHour.TabIndex = 20;
            this.chartHour.Text = "chartHour";
            // 
            // timFlush
            // 
            this.timFlush.Interval = 500;
            this.timFlush.Tick += new System.EventHandler(this.timFlush_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colData1,
            this.colData2,
            this.colData3,
            this.colData4,
            this.colData5,
            this.colData6,
            this.colData7,
            this.colData8,
            this.colData9,
            this.colData10,
            this.colData11,
            this.colData12,
            this.colData13,
            this.colData14,
            this.colData15,
            this.colData16,
            this.colData17,
            this.colData18,
            this.colData19,
            this.colData20,
            this.colData21,
            this.colData22,
            this.colData23,
            this.colData24});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 270);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(932, 76);
            this.dataGridView1.TabIndex = 21;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colData1
            // 
            this.colData1.HeaderText = "";
            this.colData1.Name = "colData1";
            this.colData1.ReadOnly = true;
            // 
            // colData2
            // 
            this.colData2.HeaderText = "";
            this.colData2.Name = "colData2";
            this.colData2.ReadOnly = true;
            // 
            // colData3
            // 
            this.colData3.HeaderText = "";
            this.colData3.Name = "colData3";
            this.colData3.ReadOnly = true;
            // 
            // colData4
            // 
            this.colData4.HeaderText = "";
            this.colData4.Name = "colData4";
            this.colData4.ReadOnly = true;
            // 
            // colData5
            // 
            this.colData5.HeaderText = "";
            this.colData5.Name = "colData5";
            this.colData5.ReadOnly = true;
            // 
            // colData6
            // 
            this.colData6.HeaderText = "";
            this.colData6.Name = "colData6";
            this.colData6.ReadOnly = true;
            // 
            // colData7
            // 
            this.colData7.HeaderText = "";
            this.colData7.Name = "colData7";
            this.colData7.ReadOnly = true;
            // 
            // colData8
            // 
            this.colData8.HeaderText = "";
            this.colData8.Name = "colData8";
            this.colData8.ReadOnly = true;
            // 
            // colData9
            // 
            this.colData9.HeaderText = "";
            this.colData9.Name = "colData9";
            this.colData9.ReadOnly = true;
            // 
            // colData10
            // 
            this.colData10.HeaderText = "";
            this.colData10.Name = "colData10";
            this.colData10.ReadOnly = true;
            // 
            // colData11
            // 
            this.colData11.HeaderText = "";
            this.colData11.Name = "colData11";
            this.colData11.ReadOnly = true;
            // 
            // colData12
            // 
            this.colData12.HeaderText = "";
            this.colData12.Name = "colData12";
            this.colData12.ReadOnly = true;
            // 
            // colData13
            // 
            this.colData13.HeaderText = "";
            this.colData13.Name = "colData13";
            this.colData13.ReadOnly = true;
            // 
            // colData14
            // 
            this.colData14.HeaderText = "";
            this.colData14.Name = "colData14";
            this.colData14.ReadOnly = true;
            // 
            // colData15
            // 
            this.colData15.HeaderText = "";
            this.colData15.Name = "colData15";
            this.colData15.ReadOnly = true;
            // 
            // colData16
            // 
            this.colData16.HeaderText = "";
            this.colData16.Name = "colData16";
            this.colData16.ReadOnly = true;
            // 
            // colData17
            // 
            this.colData17.HeaderText = "";
            this.colData17.Name = "colData17";
            this.colData17.ReadOnly = true;
            // 
            // colData18
            // 
            this.colData18.HeaderText = "";
            this.colData18.Name = "colData18";
            this.colData18.ReadOnly = true;
            // 
            // colData19
            // 
            this.colData19.HeaderText = "";
            this.colData19.Name = "colData19";
            this.colData19.ReadOnly = true;
            // 
            // colData20
            // 
            this.colData20.HeaderText = "";
            this.colData20.Name = "colData20";
            this.colData20.ReadOnly = true;
            // 
            // colData21
            // 
            this.colData21.HeaderText = "";
            this.colData21.Name = "colData21";
            this.colData21.ReadOnly = true;
            // 
            // colData22
            // 
            this.colData22.HeaderText = "";
            this.colData22.Name = "colData22";
            this.colData22.ReadOnly = true;
            // 
            // colData23
            // 
            this.colData23.HeaderText = "";
            this.colData23.Name = "colData23";
            this.colData23.ReadOnly = true;
            // 
            // colData24
            // 
            this.colData24.HeaderText = "";
            this.colData24.Name = "colData24";
            this.colData24.ReadOnly = true;
            // 
            // picOEE
            // 
            this.picOEE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picOEE.Location = new System.Drawing.Point(17, 61);
            this.picOEE.Name = "picOEE";
            this.picOEE.Size = new System.Drawing.Size(461, 206);
            this.picOEE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOEE.TabIndex = 22;
            this.picOEE.TabStop = false;
            // 
            // frmPlayAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.picOEE);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chartHour);
            this.Controls.Add(this.chartSlow);
            this.Controls.Add(this.chartError);
            this.Controls.Add(this.chartOrder);
            this.Name = "frmPlayAll";
            this.Text = "生产信息化 - 整线信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayAll_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayAll_Load);
            this.Controls.SetChildIndex(this.chartOrder, 0);
            this.Controls.SetChildIndex(this.chartError, 0);
            this.Controls.SetChildIndex(this.chartSlow, 0);
            this.Controls.SetChildIndex(this.chartHour, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.picOEE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chartOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOEE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartOrder;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSlow;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHour;
        private System.Windows.Forms.Timer timFlush;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData9;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData12;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData13;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData14;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData15;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData16;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData17;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData18;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData19;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData20;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData21;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData22;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData23;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData24;
        private System.Windows.Forms.PictureBox picOEE;
    }
}