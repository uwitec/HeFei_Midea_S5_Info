using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace HeiFeiMidea
{
    public partial class frmPlayManagement : frmPlayWindow
    {
        public frmPlayManagement()
        {
            InitializeComponent();
            textPlayer1.Title = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[6].Info[0] ;// show["Title"];
            textPlayer1.Value = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[6].Info[1];
            textPlayer1.Date = frmMain.mMain.AllDataXml.AllPlaySet.AllPlay[6].Info[2];
        }

        private void frmPlayManagement_Load(object sender, EventArgs e)
        {
        }
    }

}
