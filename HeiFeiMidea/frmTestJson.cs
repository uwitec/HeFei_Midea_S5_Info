using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
namespace HeiFeiMidea
{
    public partial class frmTestJson : Form
    {
        public frmTestJson()
        {
            InitializeComponent();
        }

        private void frmTestJson_Load(object sender, EventArgs e)
        {
            //http://localhost:58143/Account/Login
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create("http://localhost:58143/Account/Login");
            //hwr.Headers
        }
    }
}
