using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace IndoorUpdata
{
    public partial class frmMain : Form
    {
        All.Class.Access access = new All.Class.Access();
        PostGreSQL postsql = new PostGreSQL();
        LocalSave localSave = new LocalSave();
        public frmMain()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            localSave.Load();
            new Thread(() => Run())
            {
                IsBackground = true
            }.Start();
        }
        private void Run()
        {
            while (true)
            {
                if (postsql.Conn==null || postsql.Conn.State != ConnectionState.Open)
                {
                    postsql.Login("192.168.1.201", "midea", "odoo", "odoo");
                }
                else
                {
                    if (access.Conn==null || access.Conn.State != ConnectionState.Open)
                    {
                        access.Login(string.Format("{0}\\Data\\", Application.StartupPath), "Main.mdb", "", "");
                    }
                    else
                    {
                        DataTable dt = access.Read("select count(TestTime) as allCount from tb_dpData");
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if (All.Class.Num.ToInt(dt.Rows[0]["allCount"]) > localSave.TestIndex)
                            {
                                DataTable dt2 = access.Read("select top 1 * from tb_dpdata order by testtime desc,stepid desc");
                                if (dt2 != null && dt2.Rows.Count > 0)
                                {
                                    if (postsql.Write(string.Format("insert into post_performance_investigator (\"BarCode\",\"LineName\",\"TestTime\",\"StepId\",\"StepName\",\"Data_C\",\"Result\",\"TestNR\",\"modeID\",\"ModelCode\",\"MachineType\",\"ModeCurrent\",\"ModeDFR\",\"ModeElectrical\") values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",
                                        dt2.Rows[0]["barcode"], "NJ", dt2.Rows[0]["TestTime"], dt2.Rows[0]["stepId"], dt2.Rows[0]["StepName"], dt2.Rows[0]["Data_C"], dt2.Rows[0]["Result"], dt2.Rows[0]["TestNR"], dt2.Rows[0]["modeID"], dt2.Rows[0]["ModelCode"], dt2.Rows[0]["MachineType"],
                                        dt2.Rows[0]["ModeCurrent"], dt2.Rows[0]["ModeDFR"], dt2.Rows[0]["ModeElectrical"])) > 0)
                                    {
                                        localSave.TestIndex = All.Class.Num.ToInt(dt.Rows[0]["allCount"]);
                                        localSave.Save();
                                    }
                                    dt2.Dispose();
                                }
                            }
                        }
                        dt.Dispose();
                    }
                }
                Thread.Sleep(1000);
            }
        }
       
    }
    public class LocalSave
    {
        const string FilePath = ".\\LocalSaveIndex.txt";
        public int TestIndex
        { get; set; }
        public LocalSave()
        {
            TestIndex = 0;
        }
        public void Load()
        {
            if (System.IO.File.Exists(FilePath))
            {
                Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(FilePath));
                if (buff.ContainsKey("TestIndex"))
                {
                    TestIndex = All.Class.Num.ToInt(buff["TestIndex"]);
                }
            }
            else
            {
                Save();
            }
        }
        public void Save()
        {
            Dictionary<string, string> buff = new Dictionary<string, string>();
            buff.Add("TestIndex", TestIndex.ToString());
            All.Class.FileIO.Write(FilePath, All.Class.SSFile.Dictionary2Text(buff), System.IO.FileMode.Create);
        }
    }
}
