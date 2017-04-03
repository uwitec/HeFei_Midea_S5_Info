using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeiFeiMideaPlayer
{
    public partial class frmLogin : All.Window.MainWindow
    {
        List<HeiFeiMideaDll.UserSet> AllUser = new List<HeiFeiMideaDll.UserSet>();
        All.Control.Metro.ItemBox[] allTestItem = new All.Control.Metro.ItemBox[24];//暂时只有这么多手动，再多没地放
        public frmLogin()
        {
            InitializeComponent();
            InitForm();
        }
        private void InitForm()
        {
            for (int i = 0; i < allTestItem.Length; i++)
            {
                allTestItem[i] = (All.Control.Metro.ItemBox)this.Controls.Find(string.Format("itemBox{0}", i + 1), true)[0];
                allTestItem[i].Click += frmLogin_Click;
                allTestItem[i].DoubleClick += frmLogin_DoubleClick;
            }

            int AllTestByHandle = 0;
            frmMain.mMain.FlushAllUser.allLineStation.ForEach(
                allStation =>
                {
                    if (allStation.TestStation)
                    {
                        if (AllTestByHandle < allTestItem.Length)
                        {
                            allTestItem[AllTestByHandle].Visible = true;
                            allTestItem[AllTestByHandle].Title = allStation.StationName;
                            allTestItem[AllTestByHandle].Value = allStation.UserName;
                            allTestItem[AllTestByHandle].Tag = allStation.WorkStation;
                            if (allStation.UserName == "")
                            {
                                allTestItem[AllTestByHandle].Icon = HeiFeiMideaPlayer.Properties.Resources.UseError;
                            }
                            else
                            {
                                allTestItem[AllTestByHandle].Icon = HeiFeiMideaPlayer.Properties.Resources.UserOk;
                            }
                        }
                        AllTestByHandle++;
                    }
                });
            int heightLen = (int)Math.Ceiling(AllTestByHandle / 4.0f);
            panAllSize.Height = panAllSize.Height - (6 - heightLen) * (5 + itemBox1.Height);
            groupBox1.Height = groupBox1.Height - (6 - heightLen) * (5 + itemBox1.Height);
        }

        void frmLogin_DoubleClick(object sender, EventArgs e)
        {
            All.Control.Metro.ItemBox btn = (All.Control.Metro.ItemBox)sender;
            btn.Icon = HeiFeiMideaPlayer.Properties.Resources.UseError;
            btn.Value = "";

            frmMain.mMain.AllDataBase.FlushData.Write(
                string.Format("Update InfoLineStation Set UserName='' where workStation={0}", btn.Tag));
        }

        void frmLogin_Click(object sender, EventArgs e)
        {
            All.Control.Metro.ItemBox btn = (All.Control.Metro.ItemBox)sender;
            for (int i = 0; i < allTestItem.Length; i++)
            {
                allTestItem[i].Check = false;
            }
            btn.Check = true;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            AllUser = HeiFeiMideaDll.UserSet.GetAllUser(frmMain.mMain.AllDataBase.FlushData);
            frmMain.mMain.AllMeterData.AllReadValue.StringValue.ChangeValue += StringValue_ChangeValue;
        }
        void StringValue_ChangeValue(string Value, string OldValue, string Info, int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    if (Value == "")
                    {
                        return;
                    }
                    int userIndex = AllUser.FindIndex(
                        user =>
                        {
                            return user.Word == Value;
                        });
                    if (userIndex >= 0)
                    {
                        SetUser(AllUser[userIndex].Text,AllUser[userIndex].Use);
                    }
                    break;
            }
        }
        delegate void SetUserHandle(string UserName,bool[] Use);
        private void SetUser(string UserName,bool[] Use)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SetUserHandle(SetUser), UserName,Use);
            }
            else
            {
                for (int i = 0; i < allTestItem.Length; i++)
                {
                    if (allTestItem[i].Check)
                    {
                        if (!Use[All.Class.Num.ToInt(allTestItem[i].Tag)])
                        {
                            return;
                        }
                        allTestItem[i].Value = UserName;
                        allTestItem[i].Icon = HeiFeiMideaPlayer.Properties.Resources.UserOk;
                        frmMain.mMain.AllDataBase.FlushData.Write(
                            string.Format("Update InfoLineStation Set UserName='{0}' where workStation={1}", UserName, allTestItem[i].Tag));
                        using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select UserName from StatueUserLogin where UserName='{0}' and TestYear={1:yyyy} and TestMonth={1:MM}", UserName,DateTime.Now)))
                        {
                            if (dt == null || dt.Rows.Count <= 0)
                            {
                                frmMain.mMain.AllDataBase.FlushData.Write(
                                    string.Format("insert into StatueUserLogin (UserName,TestYear,TestMonth,Test{0:dd}) Values ('{1}',{0:yyyy},{0:MM},'true')", DateTime.Now, UserName));
                            }
                            else
                            {
                                frmMain.mMain.AllDataBase.FlushData.Write(
                                    string.Format("update StatueUserLogin Set Test{0:dd}='true' where UserName='{1}'", DateTime.Now, UserName));
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain.mMain.AllMeterData.AllReadValue.StringValue.ChangeValue -= StringValue_ChangeValue;
            this.Close();
        }
    }
}
