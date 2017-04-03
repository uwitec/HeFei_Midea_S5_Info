namespace HeiFeiMidea
{
    partial class frmSetTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetTime));
            this.panSize = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colAdd = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUseTime = new System.Windows.Forms.DataGridViewImageColumn();
            this.colHourStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHourEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGreet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAllCount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.dataGridView1);
            this.panSize.Controls.Add(this.panel1);
            this.panSize.Location = new System.Drawing.Point(124, 129);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(714, 381);
            this.panSize.TabIndex = 64;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdd,
            this.colCheck,
            this.colUseTime,
            this.colHourStart,
            this.colMinStart,
            this.colHourEnd,
            this.colMinEnd});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.Off;
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
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // colAdd
            // 
            this.colAdd.HeaderText = "添加/删除";
            this.colAdd.Name = "colAdd";
            this.colAdd.ReadOnly = true;
            this.colAdd.Width = 85;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "是否启用";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = false;
            // 
            // colUseTime
            // 
            this.colUseTime.HeaderText = "启用时间段";
            this.colUseTime.Name = "colUseTime";
            // 
            // colHourStart
            // 
            this.colHourStart.HeaderText = "开始时间【小时】";
            this.colHourStart.Name = "colHourStart";
            this.colHourStart.Width = 160;
            // 
            // colMinStart
            // 
            this.colMinStart.HeaderText = "开始时间【分钟】";
            this.colMinStart.Name = "colMinStart";
            this.colMinStart.Width = 160;
            // 
            // colHourEnd
            // 
            this.colHourEnd.HeaderText = "结束时间【小时】";
            this.colHourEnd.Name = "colHourEnd";
            this.colHourEnd.Width = 160;
            // 
            // colMinEnd
            // 
            this.colMinEnd.HeaderText = "结束时间【分钟】";
            this.colMinEnd.Name = "colMinEnd";
            this.colMinEnd.Width = 160;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtGreet);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtAllCount);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 40);
            this.panel1.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(366, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 106;
            this.label2.Text = "合格百分比";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPass.Location = new System.Drawing.Point(470, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(65, 29);
            this.txtPass.TabIndex = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(186, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 104;
            this.label1.Text = "笑脸百分比";
            // 
            // txtGreet
            // 
            this.txtGreet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGreet.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtGreet.Location = new System.Drawing.Point(290, 5);
            this.txtGreet.Name = "txtGreet";
            this.txtGreet.Size = new System.Drawing.Size(65, 29);
            this.txtGreet.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 102;
            this.label7.Text = "理论产出值";
            // 
            // txtAllCount
            // 
            this.txtAllCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllCount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtAllCount.Location = new System.Drawing.Point(115, 5);
            this.txtAllCount.Name = "txtAllCount";
            this.txtAllCount.Size = new System.Drawing.Size(65, 29);
            this.txtAllCount.TabIndex = 103;
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
            this.btnClose.TabIndex = 65;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panSize);
            this.Name = "frmSetTime";
            this.Text = "时间段设置";
            this.Load += new System.EventHandler(this.frmSetTime_Load);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGreet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAllCount;
        private System.Windows.Forms.DataGridViewImageColumn colAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewImageColumn colUseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHourStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHourEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinEnd;
    }
}