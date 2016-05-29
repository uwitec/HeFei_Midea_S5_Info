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
    public partial class frmErrorFrom : All.Window.BaseWindow
    {
        public string Error
        { get; set; }
        /// <summary>
        /// 故障原因
        /// </summary>
        public string Source
        { get; set; }
        /// <summary>
        /// 故障工位号,100 以下为工位故障，100为其他故障
        /// </summary>
        public int ErrorWorkStation
        { get; set; }


        List<HeiFeiMideaDll.Error.ErrorStation> stationError;
        List<HeiFeiMideaDll.Error.ErrorEnum> allError;
        public frmErrorFrom()
        {
            InitializeComponent();
        }
        private void frmErrorFrom_Load(object sender, EventArgs e)
        {
            InitFrm();
        }
        private void InitFrm()
        {
            stationError = HeiFeiMideaDll.Error.GetError(frmMain.mMain.AllDataXml.LocalSettings.TestNo, frmMain.mMain.AllDataBase.FlushData);
            ListViewItem lvi;
            if (stationError != null && stationError.Count > 0)
            {
                if (stationError[0].ErrorEnum != null && stationError[0].ErrorEnum.Count > 0)
                {
                    stationError[0].ErrorEnum.ForEach(
                        errorEnum =>
                        {
                            lvi = new ListViewItem();
                            lvi.ImageIndex = 1;
                            lvi.Text = errorEnum.Value;
                            lstEnum.Items.Add(lvi);
                        });
                }
            }
            List<HeiFeiMideaDll.cDataLocal.InfoLineStation> allStation = frmMain.mMain.AllDataBase.Local.GetAllInfoLineStation();
            allStation.ForEach(
                station =>
                {
                    if (station.TestStation)
                    {
                        lvi = new ListViewItem();
                        lvi.ImageIndex = 1;
                        lvi.Text = station.StationName;
                        lvi.Tag = station.WorkStation;
                        lsvStation.Items.Add(lvi);
                    }
                });
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lsvError.SelectedIndices.Count <=0)
            {
                MessageBox.Show("对不起，当前没有选择故障名称", "选择故障名称", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lsvOther.SelectedIndices.Count > 0)
            {
                Source = lsvOther.Items[lsvOther.SelectedIndices[0]].Text;
                ErrorWorkStation = 100;
            }
            if (lsvStation.SelectedIndices.Count > 0)
            {
                Source = lsvStation.Items[lsvStation.SelectedIndices[0]].Text;
                ErrorWorkStation = All.Class.Num.ToInt(lsvStation.Items[lsvStation.SelectedIndices[0]].Tag, 0);
            }
            Error = lsvError.Items[lsvError.SelectedIndices[0]].Text;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void lstEnum_ItemActivate(object sender, EventArgs e)
        {
        }

        private void lstEnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEnum.SelectedIndices.Count > 0)
            {
                if (lstEnum.Items[lstEnum.SelectedIndices[0]].ImageIndex == 0)
                {
                    for (int i = 0; i < lstEnum.Items.Count; i++)
                    {
                        lstEnum.Items[i].ImageIndex = 1;
                    }
                    InitError("");
                }
                else
                {
                    for (int i = 0; i < lstEnum.Items.Count; i++)
                    {
                        lstEnum.Items[i].ImageIndex = 1;
                    }
                    lstEnum.Items[lstEnum.SelectedIndices[0]].ImageIndex = 0;//没问题
                    string text = lstEnum.Items[lstEnum.SelectedIndices[0]].Text;
                    InitError(text);
                }
            }
        }
        private void InitError(string ErrorEnumText)
        {
            ListViewItem lvi;
            lsvError.Items.Clear();
            lsvOther.Items.Clear();
            if (ErrorEnumText != "")
            {
                if (allError == null)
                {
                    allError = HeiFeiMideaDll.Error.GetAllErrorSet(frmMain.mMain.AllDataBase.FlushData);
                }
                if (allError != null && allError.Count > 0)
                {
                    foreach (HeiFeiMideaDll.Error.ErrorEnum errorEnum in allError)
                    {
                        if (errorEnum.Value == ErrorEnumText)
                        {
                            if (errorEnum.Errors != null && errorEnum.Errors.Count > 0)
                            {
                                errorEnum.Errors.ForEach(
                                    errors =>
                                    {
                                        lvi = new ListViewItem();
                                        lvi.Text = errors.Value;
                                        lvi.ImageIndex = 1;
                                        lsvError.Items.Add(lvi);
                                    });
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void lsvError_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvError.SelectedIndices.Count > 0 && lstEnum.SelectedIndices.Count > 0)
            {
                if (lsvError.Items[lsvError.SelectedIndices[0]].ImageIndex == 0)
                {
                    for (int i = 0; i < lsvError.Items.Count; i++)
                    {
                        lsvError.Items[i].ImageIndex = 1;
                    }
                    InitFrom("", "");
                }
                else
                {
                    for (int i = 0; i < lsvError.Items.Count; i++)
                    {
                        lsvError.Items[i].ImageIndex = 1;
                    }
                    lsvError.Items[lsvError.SelectedIndices[0]].ImageIndex = 0;//没问题
                    string text = lsvError.Items[lsvError.SelectedIndices[0]].Text;
                    string errorEnum = lstEnum.Items[lstEnum.SelectedIndices[0]].Text;
                    InitFrom(errorEnum, text);
                }
            }
        }
        private void InitFrom(string ErrorEnumText,string ErrorText)
        {
            ListViewItem lvi;

            lsvOther.Items.Clear();
            if (ErrorText != "" && ErrorEnumText != "")
            {
                if (allError == null)
                {
                    allError = HeiFeiMideaDll.Error.GetAllErrorSet(frmMain.mMain.AllDataBase.FlushData);
                }
                if (allError != null && allError.Count > 0)
                {
                    foreach (HeiFeiMideaDll.Error.ErrorEnum errorEnum in allError)
                    {
                        if (errorEnum.Value == ErrorEnumText)
                        {
                            if (errorEnum.Errors != null && errorEnum.Errors.Count > 0)
                            {
                                errorEnum.Errors.ForEach(
                                    errors =>
                                    {
                                        if (errors.Value == ErrorText)
                                        {
                                            if (errors.ErrorFrom != null && errors.ErrorFrom.Count > 0)
                                            {
                                                errors.ErrorFrom.ForEach(
                                                    errorFrom =>
                                                    {
                                                        lvi = new ListViewItem();
                                                        lvi.Text = errorFrom.Value;
                                                        lvi.ImageIndex = 1;
                                                        lsvOther.Items.Add(lvi);
                                                    });

                                            }
                                        }
                                    });
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void lsvOther_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvOther.SelectedIndices.Count > 0 )
            {
                if (lsvOther.Items[lsvOther.SelectedIndices[0]].ImageIndex == 0)
                {
                    for (int i = 0; i < lsvOther.Items.Count; i++)
                    {
                        lsvOther.Items[i].ImageIndex = 1;
                    }
                }
                else
                {
                    for (int i = 0; i < lsvOther.Items.Count; i++)
                    {
                        lsvOther.Items[i].ImageIndex = 1;
                    }
                    for (int i = 0; i < lsvStation.Items.Count; i++)
                    {
                        lsvStation.Items[i].ImageIndex = 1;
                    }
                    lsvOther.Items[lsvOther.SelectedIndices[0]].ImageIndex = 0;//没问题
                }
            }
        }

        private void lsvStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvStation.SelectedIndices.Count > 0)
            {
                if (lsvStation.Items[lsvStation.SelectedIndices[0]].ImageIndex == 0)
                {
                    for (int i = 0; i < lsvStation.Items.Count; i++)
                    {
                        lsvStation.Items[i].ImageIndex = 1;
                    }
                }
                else
                {
                    for (int i = 0; i < lsvOther.Items.Count; i++)
                    {
                        lsvOther.Items[i].ImageIndex = 1;
                    }
                    for (int i = 0; i < lsvStation.Items.Count; i++)
                    {
                        lsvStation.Items[i].ImageIndex = 1;
                    }
                    lsvStation.Items[lsvStation.SelectedIndices[0]].ImageIndex = 0;//没问题
                }
            }
        }
    }
}
