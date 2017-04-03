using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintFile
{
    public partial class frmMain : Form
    {
        HeiFeiMideaPlayer.cAiWrite AiWrite = new HeiFeiMideaPlayer.cAiWrite();
        public frmMain()
        {
            InitializeComponent();
            this.MaximumSize = new Size(734, 290);
            this.MinimumSize = new Size(734, 290);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetProcesses().ToList().ForEach(
                process =>
                {
                    if (process.ProcessName.ToUpper().IndexOf("ILLUSTRATOR") >= 0)
                    {
                        process.Kill();
                    }
                });
            if (!System.IO.Directory.Exists(string.Format("{0}\\xls\\", Application.StartupPath)))
            {
                System.IO.Directory.CreateDirectory(string.Format("{0}\\xls\\", Application.StartupPath));
            }
            AiWrite.OpenApp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtMBarCode.Text.Length < 22)
            {
                MessageBox.Show("美的条码长度不正确,无法打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(txtFile.Text))
            {
                MessageBox.Show("指定的AI文件不存在,不能打印", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mbar = "";
            string bbar = "";
            int xCount=0;
            string mformat = "";
            string bformat = "";
            xCount = txtMBarCode.Text.Count(c => c == '*');
            mformat = "********************".Substring(0, xCount);
            xCount = txtBBarCode.Text.Count(c => c == '*');
            bformat = "********************".Substring(0, xCount);
            int mIndex = All.Class.Num.ToInt(txtMStart.Text);
            int bIndex = All.Class.Num.ToInt(txtBStart.Text);
            for (int i = 0; i < All.Class.Num.ToInt(txtCount.Text); i++)
            {
                mbar = txtMBarCode.Text.Replace(mformat, string.Format("{0}", mIndex + i).PadLeft(mformat.Length, '0'));
                bbar = txtBBarCode.Text.Replace(bformat, string.Format("{0}", bIndex + i).PadLeft(bformat.Length, '0'));

                All.Class.FileIO.WriteLine(string.Format("{0}\\xls\\{1}.xls", Application.StartupPath, txtOrder.Text), string.Format("{0}\t{1}", mbar, bbar));
                AiWrite.PrintFile(txtFile.Text, mbar, txtMMode.Text, txtOrder.Text, bbar, txtBMode.Text, All.Class.MideaBarCode.GetTimeFromBar(mbar),
                    All.Class.BoShi.WaiXiaoOrderChange(txtOrder.Text), All.Class.MideaBarCode.WaiXiaoBarChange(mbar, txtOrder.Text));
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "AI文件|*.*";
            openFileDialog1.Title = "请选择要打印的AI文件";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
