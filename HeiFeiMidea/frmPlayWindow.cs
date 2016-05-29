using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMidea
{
    public partial class frmPlayWindow : All.Window.PlayWindow
    {
        bool showTitle = true;
        /// <summary>
        /// 是否显示标题栏
        /// </summary>
        [Description("是否显示标题栏")]
        [Category("Shuai")]
        public bool ShowTitle
        {
            get { return showTitle; }
            set
            {
                showTitle = value;
                lblTitle.Visible = value;
                panel2.Visible = value;
                pictureBox1.Visible = value;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            if (lblTitle != null)
            {
                lblTitle.Text = Text;
            }
            base.OnTextChanged(e);
        }
        public frmPlayWindow()
        {
            InitializeComponent();
        }

        private void frmPlayWindow_Load(object sender, EventArgs e)
        {
        }

        private void frmPlayWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
