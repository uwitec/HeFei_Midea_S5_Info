namespace HeiFeiMidea
{
    partial class frmSetOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetOrder));
            this.panSize = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colAdd = new System.Windows.Forms.DataGridViewImageColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarLenNing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarLenNingStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarLenNingEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrintFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMidea = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.openExcel = new System.Windows.Forms.OpenFileDialog();
            this.openAi = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTodayCount = new System.Windows.Forms.TextBox();
            this.panSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.dataGridView1);
            this.panSize.Controls.Add(this.panel1);
            this.panSize.Location = new System.Drawing.Point(125, 135);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(714, 381);
            this.panSize.TabIndex = 63;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdd,
            this.colOrder,
            this.colBarCode,
            this.colBarStart,
            this.colBarEnd,
            this.colBarLenNing,
            this.colMonth,
            this.colDay,
            this.colBarLenNingStart,
            this.colBarLenNingEnd,
            this.colPrintFile,
            this.colMidea});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(714, 341);
            this.dataGridView1.TabIndex = 65;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // colAdd
            // 
            this.colAdd.HeaderText = "添加/删除";
            this.colAdd.Name = "colAdd";
            this.colAdd.ReadOnly = true;
            this.colAdd.Width = 85;
            // 
            // colOrder
            // 
            this.colOrder.HeaderText = "订单名称";
            this.colOrder.Name = "colOrder";
            this.colOrder.Width = 160;
            // 
            // colBarCode
            // 
            this.colBarCode.HeaderText = "整机条码前段";
            this.colBarCode.Name = "colBarCode";
            this.colBarCode.Width = 180;
            // 
            // colBarStart
            // 
            this.colBarStart.HeaderText = "流水号起始";
            this.colBarStart.Name = "colBarStart";
            // 
            // colBarEnd
            // 
            this.colBarEnd.HeaderText = "流水号结束";
            this.colBarEnd.Name = "colBarEnd";
            // 
            // colBarLenNing
            // 
            this.colBarLenNing.HeaderText = "冷凝器条码前段";
            this.colBarLenNing.Name = "colBarLenNing";
            this.colBarLenNing.Visible = false;
            this.colBarLenNing.Width = 5;
            // 
            // colMonth
            // 
            this.colMonth.HeaderText = "月";
            this.colMonth.Name = "colMonth";
            this.colMonth.Width = 50;
            // 
            // colDay
            // 
            this.colDay.HeaderText = "日";
            this.colDay.Name = "colDay";
            this.colDay.Width = 50;
            // 
            // colBarLenNingStart
            // 
            this.colBarLenNingStart.HeaderText = "冷凝器条码流水号起始";
            this.colBarLenNingStart.Name = "colBarLenNingStart";
            this.colBarLenNingStart.Visible = false;
            this.colBarLenNingStart.Width = 5;
            // 
            // colBarLenNingEnd
            // 
            this.colBarLenNingEnd.HeaderText = "冷凝器条码流水号结束";
            this.colBarLenNingEnd.Name = "colBarLenNingEnd";
            this.colBarLenNingEnd.Visible = false;
            this.colBarLenNingEnd.Width = 5;
            // 
            // colPrintFile
            // 
            this.colPrintFile.HeaderText = "标贴图像";
            this.colPrintFile.Name = "colPrintFile";
            this.colPrintFile.Width = 150;
            // 
            // colMidea
            // 
            this.colMidea.HeaderText = "产品类别";
            this.colMidea.Name = "colMidea";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTodayCount);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 40);
            this.panel1.TabIndex = 64;
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(499, 6);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(89, 29);
            this.btnIn.TabIndex = 64;
            this.btnIn.Text = "导入";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Visible = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(613, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 63;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 64;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(25, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 21);
            this.label7.TabIndex = 104;
            this.label7.Text = "显示今日目标产量";
            // 
            // txtTodayCount
            // 
            this.txtTodayCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodayCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTodayCount.Location = new System.Drawing.Point(185, 7);
            this.txtTodayCount.Name = "txtTodayCount";
            this.txtTodayCount.Size = new System.Drawing.Size(65, 29);
            this.txtTodayCount.TabIndex = 105;
            // 
            // frmSetOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSetOrder";
            this.Text = "订单录入";
            this.Load += new System.EventHandler(this.frmSetOrder_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panSize;
        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openExcel;
        private System.Windows.Forms.OpenFileDialog openAi;
        private System.Windows.Forms.DataGridViewImageColumn colAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarLenNing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarLenNingStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarLenNingEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrintFile;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMidea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTodayCount;
    }
}