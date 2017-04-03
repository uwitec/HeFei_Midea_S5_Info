namespace HeiFeiMidea
{
    partial class frmReportLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportLine));
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rptTestTimeEveryHour = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panTtile = new System.Windows.Forms.Panel();
            this.btnSearch = new All.Control.Metro.PicButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panSize.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panTtile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 59;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.tabControl1);
            this.panSize.Controls.Add(this.panTtile);
            this.panSize.Location = new System.Drawing.Point(123, 140);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(715, 361);
            this.panSize.TabIndex = 60;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
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
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rptTestTimeEveryHour);
            this.tabPage5.Location = new System.Drawing.Point(26, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(685, 316);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "线平衡图";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rptTestTimeEveryHour
            // 
            this.rptTestTimeEveryHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptTestTimeEveryHour.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptStationTimeEveryHour.rdlc";
            this.rptTestTimeEveryHour.Location = new System.Drawing.Point(3, 3);
            this.rptTestTimeEveryHour.Name = "rptTestTimeEveryHour";
            this.rptTestTimeEveryHour.Size = new System.Drawing.Size(679, 310);
            this.rptTestTimeEveryHour.TabIndex = 4;
            // 
            // panTtile
            // 
            this.panTtile.BackColor = System.Drawing.Color.Gray;
            this.panTtile.Controls.Add(this.dateTimePicker1);
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
            this.dateTimePicker2.CustomFormat = "从   yyyy年 - MM月 - dd日  HH时";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(10, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(261, 29);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "到   yyyy年 - MM月 - dd日  HH时";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(277, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(261, 29);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // frmReportLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmReportLine";
            this.Text = "线平衡报表";
            this.Load += new System.EventHandler(this.frmReportLine_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panTtile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer rptTestTimeEveryHour;
        private System.Windows.Forms.Panel panTtile;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private All.Control.Metro.PicButton btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}