namespace HeiFeiMidea
{
    partial class frmUserLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserLevel));
            this.panMain = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.chk1 = new All.Control.Metro.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNoAll = new All.Control.Metro.PicButton();
            this.btnAll = new All.Control.Metro.PicButton();
            this.cbbName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new All.Control.Metro.PicButton();
            this.btnClose = new All.Control.Metro.TitleButton();
            this.panMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.groupBox2);
            this.panMain.Controls.Add(this.groupBox1);
            this.panMain.Controls.Add(this.btnSave);
            this.panMain.Location = new System.Drawing.Point(104, 150);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(758, 339);
            this.panMain.TabIndex = 64;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl1);
            this.groupBox2.Controls.Add(this.chk1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(26, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(706, 208);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户权限";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(28, 34);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(46, 21);
            this.lbl1.TabIndex = 75;
            this.lbl1.Text = "主机";
            // 
            // chk1
            // 
            this.chk1.CheckColor = System.Drawing.Color.LimeGreen;
            this.chk1.Checked = false;
            this.chk1.CheckText = "";
            this.chk1.Location = new System.Drawing.Point(155, 30);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(64, 28);
            this.chk1.TabIndex = 74;
            this.chk1.Text = "checkBox1";
            this.chk1.UnCheckColor = System.Drawing.Color.DarkGray;
            this.chk1.UnCheckText = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNoAll);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.cbbName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(24, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 62);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // btnNoAll
            // 
            this.btnNoAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnNoAll.BackImage = null;
            this.btnNoAll.Border = true;
            this.btnNoAll.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoAll.Location = new System.Drawing.Point(490, 21);
            this.btnNoAll.Name = "btnNoAll";
            this.btnNoAll.PicBackColor = System.Drawing.Color.Black;
            this.btnNoAll.Size = new System.Drawing.Size(89, 28);
            this.btnNoAll.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnNoAll.TabIndex = 99;
            this.btnNoAll.Text = "全不选";
            this.btnNoAll.Click += new System.EventHandler(this.btnNoAll_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.SystemColors.Control;
            this.btnAll.BackImage = null;
            this.btnAll.Border = true;
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(594, 21);
            this.btnAll.Name = "btnAll";
            this.btnAll.PicBackColor = System.Drawing.Color.Black;
            this.btnAll.Size = new System.Drawing.Size(89, 28);
            this.btnAll.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnAll.TabIndex = 98;
            this.btnAll.Text = "全选";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // cbbName
            // 
            this.cbbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbName.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbName.FormattingEnabled = true;
            this.cbbName.Location = new System.Drawing.Point(155, 21);
            this.cbbName.Name = "cbbName";
            this.cbbName.Size = new System.Drawing.Size(296, 29);
            this.cbbName.TabIndex = 71;
            this.cbbName.SelectedIndexChanged += new System.EventHandler(this.cbbName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 62;
            this.label5.Text = "用户名";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackImage = null;
            this.btnSave.Border = true;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(618, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.PicBackColor = System.Drawing.Color.Black;
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "保存";
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
            // frmUserLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.btnClose);
            this.Name = "frmUserLevel";
            this.Text = "用户权限设置";
            this.Load += new System.EventHandler(this.frmuserLevel_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panMain, 0);
            this.panMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panMain;
        private All.Control.Metro.PicButton btnSave;
        private System.Windows.Forms.ComboBox cbbName;
        private System.Windows.Forms.Label label5;
        private All.Control.Metro.CheckBox chk1;
        private All.Control.Metro.TitleButton btnClose;
        private System.Windows.Forms.Label lbl1;
        private All.Control.Metro.PicButton btnAll;
        private All.Control.Metro.PicButton btnNoAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}