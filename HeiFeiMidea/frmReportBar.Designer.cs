namespace HeiFeiMidea
{
    partial class frmReportBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportBar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoShi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLenNing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panTtile = new System.Windows.Forms.Panel();
            this.txtBoshi = new System.Windows.Forms.TextBox();
            this.cbbOutLine = new All.Control.Metro.ComBoBox();
            this.btnOut = new All.Control.Metro.PicButton();
            this.btnSearch = new All.Control.Metro.PicButton();
            this.cbbOrder = new All.Control.Metro.ComBoBox();
            this.chkOrderName = new System.Windows.Forms.CheckBox();
            this.txtBar = new System.Windows.Forms.TextBox();
            this.chkBarCode = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.panSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnClose.TabIndex = 50;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.BackColor = System.Drawing.Color.White;
            this.panSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSize.Controls.Add(this.dataGridView1);
            this.panSize.Controls.Add(this.panTtile);
            this.panSize.Location = new System.Drawing.Point(125, 126);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(714, 384);
            this.panSize.TabIndex = 63;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrder,
            this.colBarCode,
            this.colBoShi,
            this.colLenNing,
            this.colOutLine,
            this.colInTime,
            this.colDetail});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(712, 267);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colOrder
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOrder.HeaderText = "订单";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            this.colOrder.Width = 130;
            // 
            // colBarCode
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBarCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBarCode.HeaderText = "美的条码";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.ReadOnly = true;
            this.colBarCode.Width = 170;
            // 
            // colBoShi
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBoShi.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBoShi.HeaderText = "博世条码";
            this.colBoShi.Name = "colBoShi";
            this.colBoShi.ReadOnly = true;
            this.colBoShi.Width = 190;
            // 
            // colLenNing
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLenNing.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLenNing.HeaderText = "冷凝器条码";
            this.colLenNing.Name = "colLenNing";
            this.colLenNing.ReadOnly = true;
            this.colLenNing.Width = 170;
            // 
            // colOutLine
            // 
            this.colOutLine.HeaderText = "是否下线";
            this.colOutLine.Name = "colOutLine";
            this.colOutLine.ReadOnly = true;
            this.colOutLine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOutLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOutLine.Width = 120;
            // 
            // colInTime
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colInTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.colInTime.HeaderText = "下线时间";
            this.colInTime.Name = "colInTime";
            this.colInTime.ReadOnly = true;
            this.colInTime.Width = 130;
            // 
            // colDetail
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDetail.HeaderText = "详细";
            this.colDetail.Name = "colDetail";
            this.colDetail.Text = "详细";
            this.colDetail.Width = 70;
            // 
            // panTtile
            // 
            this.panTtile.BackColor = System.Drawing.Color.Gray;
            this.panTtile.Controls.Add(this.txtBoshi);
            this.panTtile.Controls.Add(this.cbbOutLine);
            this.panTtile.Controls.Add(this.btnOut);
            this.panTtile.Controls.Add(this.btnSearch);
            this.panTtile.Controls.Add(this.cbbOrder);
            this.panTtile.Controls.Add(this.chkOrderName);
            this.panTtile.Controls.Add(this.txtBar);
            this.panTtile.Controls.Add(this.chkBarCode);
            this.panTtile.Controls.Add(this.dateTimePicker1);
            this.panTtile.Controls.Add(this.dateTimePicker2);
            this.panTtile.Controls.Add(this.chkDate);
            this.panTtile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTtile.Location = new System.Drawing.Point(0, 0);
            this.panTtile.Name = "panTtile";
            this.panTtile.Size = new System.Drawing.Size(712, 115);
            this.panTtile.TabIndex = 0;
            // 
            // txtBoshi
            // 
            this.txtBoshi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoshi.ForeColor = System.Drawing.Color.Gray;
            this.txtBoshi.Location = new System.Drawing.Point(302, 6);
            this.txtBoshi.Name = "txtBoshi";
            this.txtBoshi.Size = new System.Drawing.Size(252, 29);
            this.txtBoshi.TabIndex = 33;
            this.txtBoshi.Text = "输入博世条码";
            this.txtBoshi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoshi.Enter += new System.EventHandler(this.txtBoshi_Enter);
            // 
            // cbbOutLine
            // 
            this.cbbOutLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOutLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOutLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOutLine.ForeColor = System.Drawing.Color.Black;
            this.cbbOutLine.FormattingEnabled = true;
            this.cbbOutLine.Icon = null;
            this.cbbOutLine.IconStyle = All.Control.Metro.ComBoBox.IconStyleList.无;
            this.cbbOutLine.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.cbbOutLine.ItemHeight = 23;
            this.cbbOutLine.Items.AddRange(new object[] {
            "所有产品",
            "上线产品",
            "下线产品"});
            this.cbbOutLine.Location = new System.Drawing.Point(302, 41);
            this.cbbOutLine.Name = "cbbOutLine";
            this.cbbOutLine.Size = new System.Drawing.Size(252, 29);
            this.cbbOutLine.TabIndex = 32;
            this.cbbOutLine.Tail = false;
            this.cbbOutLine.Title = "所有产品";
            this.cbbOutLine.TitleColor = System.Drawing.Color.White;
            this.cbbOutLine.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOut.BackImage = ((System.Drawing.Image)(resources.GetObject("btnOut.BackImage")));
            this.btnOut.Border = false;
            this.btnOut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.ForeColor = System.Drawing.Color.Black;
            this.btnOut.Location = new System.Drawing.Point(599, 41);
            this.btnOut.Name = "btnOut";
            this.btnOut.PicBackColor = System.Drawing.Color.Teal;
            this.btnOut.Size = new System.Drawing.Size(100, 29);
            this.btnOut.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnOut.TabIndex = 31;
            this.btnOut.Text = "导出";
            this.btnOut.Visible = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.BackImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackImage")));
            this.btnSearch.Border = false;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(599, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PicBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbbOrder
            // 
            this.cbbOrder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOrder.ForeColor = System.Drawing.Color.Gray;
            this.cbbOrder.FormattingEnabled = true;
            this.cbbOrder.Icon = null;
            this.cbbOrder.IconStyle = All.Control.Metro.ComBoBox.IconStyleList.无;
            this.cbbOrder.ItemColor = new System.Drawing.Color[] {
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue};
            this.cbbOrder.ItemHeight = 23;
            this.cbbOrder.Items.AddRange(new object[] {
            "20050109",
            "20069873"});
            this.cbbOrder.Location = new System.Drawing.Point(35, 41);
            this.cbbOrder.Name = "cbbOrder";
            this.cbbOrder.Size = new System.Drawing.Size(261, 29);
            this.cbbOrder.TabIndex = 27;
            this.cbbOrder.Tail = false;
            this.cbbOrder.Title = "选择订单号";
            this.cbbOrder.TitleColor = System.Drawing.Color.White;
            this.cbbOrder.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOrder.SelectedIndexChanged += new System.EventHandler(this.cbbOrder_SelectedIndexChanged);
            // 
            // chkOrderName
            // 
            this.chkOrderName.AutoSize = true;
            this.chkOrderName.Location = new System.Drawing.Point(14, 51);
            this.chkOrderName.Name = "chkOrderName";
            this.chkOrderName.Size = new System.Drawing.Size(15, 14);
            this.chkOrderName.TabIndex = 25;
            this.chkOrderName.UseVisualStyleBackColor = true;
            // 
            // txtBar
            // 
            this.txtBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBar.ForeColor = System.Drawing.Color.Gray;
            this.txtBar.Location = new System.Drawing.Point(35, 6);
            this.txtBar.Name = "txtBar";
            this.txtBar.Size = new System.Drawing.Size(261, 29);
            this.txtBar.TabIndex = 24;
            this.txtBar.Text = "输入美的条码";
            this.txtBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBar.Enter += new System.EventHandler(this.txtBar_Enter);
            // 
            // chkBarCode
            // 
            this.chkBarCode.AutoSize = true;
            this.chkBarCode.Checked = true;
            this.chkBarCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBarCode.Location = new System.Drawing.Point(14, 16);
            this.chkBarCode.Name = "chkBarCode";
            this.chkBarCode.Size = new System.Drawing.Size(15, 14);
            this.chkBarCode.TabIndex = 23;
            this.chkBarCode.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "            到         yyyy - MM - dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(302, 76);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(35, 76);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(261, 29);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Location = new System.Drawing.Point(14, 86);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 1;
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // frmReportBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmReportBar";
            this.Text = "条码查询";
            this.Load += new System.EventHandler(this.frmReportBar_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panTtile.ResumeLayout(false);
            this.panTtile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        public System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.Panel panTtile;
        private System.Windows.Forms.CheckBox chkOrderName;
        private System.Windows.Forms.TextBox txtBar;
        private System.Windows.Forms.CheckBox chkBarCode;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox chkDate;
        private All.Control.Metro.ComBoBox cbbOrder;
        private All.Control.Metro.PicButton btnSearch;
        private All.Control.Metro.PicButton btnOut;
        private All.Control.Metro.ComBoBox cbbOutLine;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBoshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoShi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLenNing;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOutLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInTime;
        private System.Windows.Forms.DataGridViewLinkColumn colDetail;
    }
}