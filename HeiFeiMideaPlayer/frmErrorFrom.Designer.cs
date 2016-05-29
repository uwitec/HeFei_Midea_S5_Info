namespace HeiFeiMideaPlayer
{
    partial class frmErrorFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorFrom));
            this.btnCancel = new All.Control.Metro.PicButton();
            this.btnOk = new All.Control.Metro.PicButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstEnum = new System.Windows.Forms.ListView();
            this.lsvError = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lsvStation = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lsvOther = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackImage = null;
            this.btnCancel.Border = true;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(589, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PicBackColor = System.Drawing.Color.Black;
            this.btnCancel.Size = new System.Drawing.Size(89, 28);
            this.btnCancel.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.BackImage = null;
            this.btnOk.Border = true;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(698, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.PicBackColor = System.Drawing.Color.Black;
            this.btnOk.Size = new System.Drawing.Size(89, 28);
            this.btnOk.Style = All.Control.Metro.PicButton.Styles.Button;
            this.btnOk.TabIndex = 75;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 77;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstEnum);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 433);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择故障分类";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvError);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(204, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 433);
            this.groupBox2.TabIndex = 131;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择故障名称";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok (3).ico");
            this.imageList1.Images.SetKeyName(1, "Black.png");
            // 
            // lstEnum
            // 
            this.lstEnum.BackColor = System.Drawing.Color.Black;
            this.lstEnum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstEnum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEnum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstEnum.ForeColor = System.Drawing.Color.White;
            this.lstEnum.FullRowSelect = true;
            this.lstEnum.LargeImageList = this.imageList1;
            this.lstEnum.Location = new System.Drawing.Point(3, 22);
            this.lstEnum.MultiSelect = false;
            this.lstEnum.Name = "lstEnum";
            this.lstEnum.Size = new System.Drawing.Size(194, 408);
            this.lstEnum.SmallImageList = this.imageList1;
            this.lstEnum.TabIndex = 0;
            this.lstEnum.UseCompatibleStateImageBehavior = false;
            this.lstEnum.View = System.Windows.Forms.View.List;
            this.lstEnum.ItemActivate += new System.EventHandler(this.lstEnum_ItemActivate);
            this.lstEnum.SelectedIndexChanged += new System.EventHandler(this.lstEnum_SelectedIndexChanged);
            // 
            // lsvError
            // 
            this.lsvError.BackColor = System.Drawing.Color.Black;
            this.lsvError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvError.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvError.ForeColor = System.Drawing.Color.White;
            this.lsvError.FullRowSelect = true;
            this.lsvError.LargeImageList = this.imageList1;
            this.lsvError.Location = new System.Drawing.Point(3, 22);
            this.lsvError.MultiSelect = false;
            this.lsvError.Name = "lsvError";
            this.lsvError.Size = new System.Drawing.Size(194, 408);
            this.lsvError.SmallImageList = this.imageList1;
            this.lsvError.TabIndex = 1;
            this.lsvError.UseCompatibleStateImageBehavior = false;
            this.lsvError.View = System.Windows.Forms.View.List;
            this.lsvError.SelectedIndexChanged += new System.EventHandler(this.lsvError_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lsvStation);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(604, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 433);
            this.groupBox3.TabIndex = 132;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "选择工位故障来源";
            // 
            // lsvStation
            // 
            this.lsvStation.BackColor = System.Drawing.Color.Black;
            this.lsvStation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvStation.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvStation.ForeColor = System.Drawing.Color.White;
            this.lsvStation.FullRowSelect = true;
            this.lsvStation.LargeImageList = this.imageList1;
            this.lsvStation.Location = new System.Drawing.Point(3, 22);
            this.lsvStation.MultiSelect = false;
            this.lsvStation.Name = "lsvStation";
            this.lsvStation.Size = new System.Drawing.Size(194, 408);
            this.lsvStation.SmallImageList = this.imageList1;
            this.lsvStation.TabIndex = 4;
            this.lsvStation.UseCompatibleStateImageBehavior = false;
            this.lsvStation.View = System.Windows.Forms.View.List;
            this.lsvStation.SelectedIndexChanged += new System.EventHandler(this.lsvStation_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lsvOther);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(404, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 433);
            this.groupBox4.TabIndex = 133;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选择其他故障来源";
            // 
            // lsvOther
            // 
            this.lsvOther.BackColor = System.Drawing.Color.Black;
            this.lsvOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvOther.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvOther.ForeColor = System.Drawing.Color.White;
            this.lsvOther.FullRowSelect = true;
            this.lsvOther.LargeImageList = this.imageList1;
            this.lsvOther.Location = new System.Drawing.Point(3, 22);
            this.lsvOther.MultiSelect = false;
            this.lsvOther.Name = "lsvOther";
            this.lsvOther.Size = new System.Drawing.Size(194, 408);
            this.lsvOther.SmallImageList = this.imageList1;
            this.lsvOther.TabIndex = 4;
            this.lsvOther.UseCompatibleStateImageBehavior = false;
            this.lsvOther.View = System.Windows.Forms.View.List;
            this.lsvOther.SelectedIndexChanged += new System.EventHandler(this.lsvOther_SelectedIndexChanged);
            // 
            // frmErrorFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 492);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmErrorFrom";
            this.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmErrorFrom";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmErrorFrom_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private All.Control.Metro.PicButton btnCancel;
        private All.Control.Metro.PicButton btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstEnum;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lsvError;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvStation;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lsvOther;
    }
}