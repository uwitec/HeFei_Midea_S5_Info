namespace HeiFeiMidea
{
    partial class frmReportPingZhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPingZhi));
            this.panSize = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rptTestPass = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rptAllPass = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rptError = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rptDetial = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panTtile = new System.Windows.Forms.Panel();
            this.btnSearch = new All.Control.Metro.PicButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panTtile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.tabControl1);
            this.panSize.Controls.Add(this.panTtile);
            this.panSize.Location = new System.Drawing.Point(124, 135);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(715, 389);
            this.panSize.TabIndex = 47;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 352);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.rptTestPass);
            this.tabPage1.Location = new System.Drawing.Point(48, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "岗位一次性通过主";
            // 
            // rptTestPass
            // 
            this.rptTestPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptTestPass.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptPingZhiTestPass.rdlc";
            this.rptTestPass.Location = new System.Drawing.Point(3, 3);
            this.rptTestPass.Name = "rptTestPass";
            this.rptTestPass.Size = new System.Drawing.Size(657, 338);
            this.rptTestPass.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rptAllPass);
            this.tabPage2.Location = new System.Drawing.Point(22, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(689, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "整体一次通过率";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rptAllPass
            // 
            this.rptAllPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptAllPass.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptPinZhiAllPass.rdlc";
            this.rptAllPass.Location = new System.Drawing.Point(3, 3);
            this.rptAllPass.Name = "rptAllPass";
            this.rptAllPass.Size = new System.Drawing.Size(683, 338);
            this.rptAllPass.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rptError);
            this.tabPage3.Location = new System.Drawing.Point(22, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(689, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "故障分布";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rptError
            // 
            this.rptError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptError.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptPinZhiError.rdlc";
            this.rptError.Location = new System.Drawing.Point(3, 3);
            this.rptError.Name = "rptError";
            this.rptError.Size = new System.Drawing.Size(683, 338);
            this.rptError.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rptDetial);
            this.tabPage4.Location = new System.Drawing.Point(22, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(689, 344);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "详细记录";
            // 
            // rptDetial
            // 
            this.rptDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptDetial.LocalReport.ReportEmbeddedResource = "HeiFeiMidea.Report.rptPinZhi.rdlc";
            this.rptDetial.Location = new System.Drawing.Point(3, 3);
            this.rptDetial.Name = "rptDetial";
            this.rptDetial.Size = new System.Drawing.Size(683, 338);
            this.rptDetial.TabIndex = 5;
            // 
            // panTtile
            // 
            this.panTtile.BackColor = System.Drawing.Color.Gray;
            this.panTtile.Controls.Add(this.btnSearch);
            this.panTtile.Controls.Add(this.dateTimePicker1);
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
            this.btnSearch.Location = new System.Drawing.Point(599, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PicBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "            到         yyyy - MM - dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(277, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(252, 29);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CustomFormat = "            从      yyyy - MM - dd";
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
            this.btnClose.Location = new System.Drawing.Point(764, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 52;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReportPingZhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmReportPingZhi";
            this.Text = "品质报表";
            this.Load += new System.EventHandler(this.frmReportPingZhi_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panTtile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.Panel panTtile;
        private All.Control.Metro.PicButton btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer rptTestPass;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Microsoft.Reporting.WinForms.ReportViewer rptAllPass;
        private Microsoft.Reporting.WinForms.ReportViewer rptError;
        private Microsoft.Reporting.WinForms.ReportViewer rptDetial;
    }
}