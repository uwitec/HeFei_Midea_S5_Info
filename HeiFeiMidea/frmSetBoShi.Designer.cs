namespace HeiFeiMidea
{
    partial class frmSetBoShi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetBoShi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panSize = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMidea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJiXing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new All.Control.Metro.PicButton();
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
            this.btnClose.TabIndex = 68;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panSize
            // 
            this.panSize.Controls.Add(this.dataGridView1);
            this.panSize.Controls.Add(this.panel1);
            this.panSize.Location = new System.Drawing.Point(128, 154);
            this.panSize.Name = "panSize";
            this.panSize.Size = new System.Drawing.Size(711, 308);
            this.panSize.TabIndex = 67;
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
            this.colMidea,
            this.colBoshi,
            this.colJiXing});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(711, 261);
            this.dataGridView1.TabIndex = 65;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colImage
            // 
            this.colImage.HeaderText = "添加/移除";
            this.colImage.Name = "colImage";
            // 
            // colMidea
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMidea.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMidea.HeaderText = "美的代码";
            this.colMidea.Name = "colMidea";
            this.colMidea.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMidea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMidea.Width = 230;
            // 
            // colBoshi
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBoshi.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBoshi.HeaderText = "博世代码";
            this.colBoshi.Name = "colBoshi";
            this.colBoshi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBoshi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBoshi.Width = 280;
            // 
            // colJiXing
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colJiXing.DefaultCellStyle = dataGridViewCellStyle3;
            this.colJiXing.HeaderText = "博世机型";
            this.colJiXing.Name = "colJiXing";
            this.colJiXing.Width = 330;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 47);
            this.panel1.TabIndex = 64;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackImage = null;
            this.btnSave.Border = true;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(598, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.PicBackColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSetBoShi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panSize);
            this.Controls.Add(this.btnClose);
            this.Name = "frmSetBoShi";
            this.Text = "博世机型设置";
            this.Load += new System.EventHandler(this.frmSetBoShi_Load);
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
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMidea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJiXing;
    }
}