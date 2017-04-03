namespace HeiFeiMidea
{
    partial class frmSetSheBei
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetSheBei));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSheBei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZhouQi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanWei = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colOk = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colVideo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new All.Control.Metro.PicButton();
            this.openAi = new System.Windows.Forms.OpenFileDialog();
            this.btnError = new All.Control.Metro.PicButton();
            this.panSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Location = new System.Drawing.Point(764, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 67;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.dataGridView1);
            this.panSize.Controls.Add(this.panel1);
            this.panSize.Location = new System.Drawing.Point(125, 156);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(714, 350);
            this.panSize.TabIndex = 68;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.colSheBei,
            this.colLast,
            this.colZhouQi,
            this.colDanWei,
            this.colOk,
            this.colVideo,
            this.colOpen});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(714, 303);
            this.dataGridView1.TabIndex = 65;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "添加/移除";
            this.colImage.Name = "colImage";
            // 
            // colSheBei
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSheBei.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSheBei.HeaderText = "设备名称";
            this.colSheBei.Name = "colSheBei";
            this.colSheBei.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSheBei.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSheBei.Width = 200;
            // 
            // colLast
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLast.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLast.HeaderText = "上次维护时间";
            this.colLast.Name = "colLast";
            this.colLast.ReadOnly = true;
            this.colLast.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLast.Width = 150;
            // 
            // colZhouQi
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colZhouQi.DefaultCellStyle = dataGridViewCellStyle3;
            this.colZhouQi.HeaderText = "维护周期";
            this.colZhouQi.Name = "colZhouQi";
            this.colZhouQi.Width = 120;
            // 
            // colDanWei
            // 
            this.colDanWei.HeaderText = "单位";
            this.colDanWei.Items.AddRange(new object[] {
            "年",
            "月",
            "日",
            "周",
            "时",
            "分"});
            this.colDanWei.Name = "colDanWei";
            // 
            // colOk
            // 
            this.colOk.HeaderText = "维护完成";
            this.colOk.Name = "colOk";
            // 
            // colVideo
            // 
            this.colVideo.HeaderText = "维护视频";
            this.colVideo.Name = "colVideo";
            this.colVideo.Width = 400;
            // 
            // colOpen
            // 
            this.colOpen.HeaderText = "设备资料";
            this.colOpen.Name = "colOpen";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnError);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 47);
            this.panel1.TabIndex = 64;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackImage = null;
            this.btnSave.Border = true;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(601, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.PicBackColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnError
            // 
            this.btnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnError.BackColor = System.Drawing.SystemColors.Control;
            this.btnError.BackImage = null;
            this.btnError.Border = true;
            this.btnError.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnError.Location = new System.Drawing.Point(492, 11);
            this.btnError.Name = "btnError";
            this.btnError.PicBackColor = System.Drawing.Color.Black;
            this.btnError.Size = new System.Drawing.Size(89, 28);
            this.btnError.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnError.TabIndex = 74;
            this.btnError.Text = "故障显示";
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // frmSetSheBei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSetSheBei";
            this.Text = "设备维护与保养";
            this.Load += new System.EventHandler(this.frmSetSheBei_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panSize, 0);
            this.panSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private All.Control.Metro.TitleButton btnClose;
        public System.Windows.Forms.Panel panSize;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private All.Control.Metro.PicButton btnSave;
        private System.Windows.Forms.OpenFileDialog openAi;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSheBei;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZhouQi;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDanWei;
        private System.Windows.Forms.DataGridViewButtonColumn colOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVideo;
        private System.Windows.Forms.DataGridViewButtonColumn colOpen;
        private All.Control.Metro.PicButton btnError;
    }
}