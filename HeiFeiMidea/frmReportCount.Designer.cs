namespace HeiFeiMidea
{
    partial class frmReportCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCount));
            this.panSize = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rptMonth = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rptDay = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rptEvery = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panTtile = new System.Windows.Forms.Panel();
            this.btnSearch = new All.Control.Metro.PicButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rptOEEChart = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptOEEDetial = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panSize.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panTtile.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.tabControl1);
            this.panSize.Controls.Add(this.panTtile);
            this.panSize.Location = new System.Drawing.Point(123, 144);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(715, 361);
            this.panSize.TabIndex = 57;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 324);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rptMonth);
            this.tabPage1.Location = new System.Drawing.Point(48, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "当月报表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rptMonth
            // 
            this.rptMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptMonth.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptCountMonth.rdlc";
            this.rptMonth.Location = new System.Drawing.Point(3, 3);
            this.rptMonth.Name = "rptMonth";
            this.rptMonth.Size = new System.Drawing.Size(657, 310);
            this.rptMonth.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rptDay);
            this.tabPage2.Location = new System.Drawing.Point(26, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "当日报表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rptDay
            // 
            this.rptDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDay.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptCountDay.rdlc";
            this.rptDay.Location = new System.Drawing.Point(3, 3);
            this.rptDay.Name = "rptDay";
            this.rptDay.Size = new System.Drawing.Size(679, 310);
            this.rptDay.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rptEvery);
            this.tabPage3.Location = new System.Drawing.Point(26, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(685, 316);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "人均产量报表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rptEvery
            // 
            this.rptEvery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptEvery.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptCountEvery.rdlc";
            this.rptEvery.Location = new System.Drawing.Point(3, 3);
            this.rptEvery.Name = "rptEvery";
            this.rptEvery.Size = new System.Drawing.Size(679, 310);
            this.rptEvery.TabIndex = 5;
            // 
            // panTtile
            // 
            this.panTtile.BackColor = System.Drawing.Color.Gray;
            this.panTtile.Controls.Add(this.btnSearch);
            this.panTtile.Controls.Add(this.dateTimePicker2);
            this.panTtile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTtile.Location = new System.Drawing.Point(0, 0);
            this.panTtile.Name = "panTtile";
            this.panTtile.Size = new System.Drawing.Size(715, 37);
            this.panTtile.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.BackImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackImage")));
            this.btnSearch.Border = false;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(612, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PicBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CustomFormat = "       选择日期      yyyy - MM - dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(10, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(261, 29);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 58;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rptOEEChart);
            this.tabPage4.Location = new System.Drawing.Point(48, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(663, 316);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "OEE月报表";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rptOEEDetial);
            this.tabPage5.Location = new System.Drawing.Point(48, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(663, 316);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "OEE详细记录";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rptOEEChart
            // 
            this.rptOEEChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptOEEChart.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptOEEChart.rdlc";
            this.rptOEEChart.Location = new System.Drawing.Point(3, 3);
            this.rptOEEChart.Name = "rptOEEChart";
            this.rptOEEChart.Size = new System.Drawing.Size(657, 310);
            this.rptOEEChart.TabIndex = 4;
            // 
            // rptOEEDetial
            // 
            this.rptOEEDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptOEEDetial.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptOEEDetial.rdlc";
            this.rptOEEDetial.Location = new System.Drawing.Point(3, 3);
            this.rptOEEDetial.Name = "rptOEEDetial";
            this.rptOEEDetial.Size = new System.Drawing.Size(657, 310);
            this.rptOEEDetial.TabIndex = 4;
            // 
            // frmReportCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panSize);
            this.Name = "frmReportCount";
            this.Text = "计数报表";
            this.Load += new System.EventHandler(this.frmReportCount_Load);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panSize.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panTtile.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer rptMonth;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer rptDay;
        private System.Windows.Forms.Panel panTtile;
        private All.Control.Metro.PicButton btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer rptEvery;
        private System.Windows.Forms.TabPage tabPage4;
        private Microsoft.Reporting.WinForms.ReportViewer rptOEEChart;
        private System.Windows.Forms.TabPage tabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer rptOEEDetial;
    }
}