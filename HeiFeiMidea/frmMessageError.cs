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
    public partial class frmMessageError : All.Window.BaseWindow
    {
        
        public frmMessageError(string[] value)
        {
            InitializeComponent();
            if (value != null && value.Length > 0)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    listBox1.Items.Add(value[i]);
                }
            }
        }

        private void frmMessageError_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", string.Format("{0}\\SheBei\\", Application.StartupPath));
        }

        private void titleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
