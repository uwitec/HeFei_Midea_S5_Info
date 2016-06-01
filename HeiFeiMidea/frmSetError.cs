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
    public partial class frmSetError : All.Window.MainWindow
    {
        Dictionary<string, int> StationNameToIndex = new Dictionary<string, int>();
        public frmSetError()
        {
            InitializeComponent();
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void InitData()
        {
            treeError.Nodes.Clear();
            treeStation.Nodes.Clear();
            List<HeiFeiMideaDll.Error.ErrorEnum> allErrors = HeiFeiMideaDll.Error.GetAllErrorSet(frmMain.mMain.AllDataBase.LocalData);
            List<HeiFeiMideaDll.Error.ErrorStation> allStation = HeiFeiMideaDll.Error.GetError(0, frmMain.mMain.AllDataBase.LocalData);
            TreeNode tnL1;
            TreeNode tnL2;
            TreeNode tnL3;

            TreeNode tnR0;
            TreeNode tnR1;
            //string tmpName = "";

            treeError.Nodes.Add(CreatNode("所有故障列表",0,true));
            treeStation.Nodes.Add(CreatNode("所有工位列表", 0, false));
            tnR0 = treeStation.Nodes["所有工位列表"];
            tnL1 = treeError.Nodes["所有故障列表"];

            if (tnL1 != null && allErrors != null && allErrors.Count > 0)
            {
                allErrors.ForEach(
                    errorEnum =>
                    {
                        if (errorEnum.Value != "")
                        {
                            tnL1.Nodes.Add(CreatNode(errorEnum.Value, 1, true));
                            tnL2 = tnL1.Nodes[errorEnum.Value];
                            errorEnum.Errors.ForEach(
                                errors =>
                                {
                                    if (errors.Value != "")
                                    {
                                        tnL2.Nodes.Add(CreatNode(errors.Value, 2, true));
                                        tnL3 = tnL2.Nodes[errors.Value];
                                        errors.ErrorFrom.ForEach(
                                            errorFrom =>
                                            {
                                                if (errorFrom.Value != "")
                                                {
                                                    tnL3.Nodes.Add(CreatNode(errorFrom.Value, 3, true));
                                                }
                                            });
                                    }
                                });
                        }
                    });
            }

            frmMain.mMain.AllCars.AllInfoStation.ToList().ForEach(
                InfoStation => 
                {
                    tnR0.Nodes.Add(CreatNode(InfoStation.StationName, 1, false));
                });

            allStation.ForEach(
                station =>
                {
                    if (station.WorkStation > 0 && station.WorkStation < HeiFeiMideaDll.cMain.AllComputerCount)
                    {
                        //工位名称
                        tnR1 = tnR0.Nodes[station.WorkStation];
                        station.ErrorEnum.ForEach(
                            errorEnum =>
                            {
                                if (tnR1 != null)
                                {
                                    if (errorEnum.Value != null)
                                    {
                                        tnR1.Nodes.Add(CreatNode(errorEnum.Value, 2, false));
                                    }
                                }
                            });

                    }
                });
        }
        private TreeNode CreatNode(string text,int level,bool left)
        {
            TreeNode result = new TreeNode();
            result.Text = text;
            result.Name = text;
            result.Tag = level;
            switch (level)
            {
                case 0:
                    result.ImageIndex = 0;
                    break;
                case 1:
                    if (left)
                        result.ImageIndex = 1;
                    else
                        result.ImageIndex = 2;
                    break;
                case 2:
                    if (left)
                        result.ImageIndex = 3;
                    else
                        result.ImageIndex = 1;
                    break;
                case 3:
                    result.ImageIndex = 4;
                    break;
            }
            return result;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result1 = HeiFeiMideaDll.Error.Save(GetErrorSet(), frmMain.mMain.AllDataBase.LocalData);
            bool result2 = HeiFeiMideaDll.Error.Save(GetErrorStation(), frmMain.mMain.AllDataBase.LocalData);
            if (result1 || result2)
            {
                All.Window.MetroMessageBox.Show(this, "当前故障数据已成功保存到数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, "当前数据保存失败，或者无数据保存", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 取得故障设置
        /// </summary>
        /// <returns></returns>
        public List<HeiFeiMideaDll.Error.ErrorEnum> GetErrorSet()
        {
            List<HeiFeiMideaDll.Error.ErrorEnum> result = new List<HeiFeiMideaDll.Error.ErrorEnum>();
            TreeNode tn;
            HeiFeiMideaDll.Error.ErrorEnum errorEnum;
            HeiFeiMideaDll.Error.Errors errors;
            HeiFeiMideaDll.Error.ErrorFrom errorFrom;
            tn = treeError.Nodes["所有故障列表"];
            if (tn != null)
            {
                foreach (TreeNode tn1 in tn.Nodes)
                {
                    errorEnum = new HeiFeiMideaDll.Error.ErrorEnum();
                    errorEnum.Value = tn1.Text;
                    foreach (TreeNode tn2 in tn1.Nodes)
                    {
                        errors = new HeiFeiMideaDll.Error.Errors();
                        errors.Value = tn2.Text;
                        foreach (TreeNode tn3 in tn2.Nodes)
                        {
                            errorFrom = new HeiFeiMideaDll.Error.ErrorFrom();
                            errorFrom.Value = tn3.Text;
                            errors.ErrorFrom.Add(errorFrom);
                        }
                        errorEnum.Errors.Add(errors);
                    }
                    result.Add(errorEnum);
                }
            }
            return result;
        }
        /// <summary>
        /// 获取工位与故障对应表
        /// </summary>
        /// <returns></returns>
        private List<HeiFeiMideaDll.Error.ErrorStation> GetErrorStation()
        {
            List<HeiFeiMideaDll.Error.ErrorStation> result = new List<HeiFeiMideaDll.Error.ErrorStation>();
            TreeNode tn;
            HeiFeiMideaDll.Error.ErrorStation errorStation;
            HeiFeiMideaDll.Error.ErrorEnum errorEnum;
            tn = treeStation.Nodes["所有工位列表"];
            if (tn != null)
            {
                foreach (TreeNode tn1 in tn.Nodes)
                {
                    errorStation = new HeiFeiMideaDll.Error.ErrorStation();
                    errorStation.WorkStation = tn1.Index;
                    foreach (TreeNode tn2 in tn1.Nodes)
                    {
                        errorEnum = new HeiFeiMideaDll.Error.ErrorEnum();
                        errorEnum.Value = tn2.Text;
                        errorStation.ErrorEnum.Add(errorEnum);
                    }
                    result.Add(errorStation);
                }
            }

            return result;
        }
        private void btnFlush_Click(object sender, EventArgs e)
        {
        }


        private void treeError_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                treeError.ContextMenuStrip = contextMenuStrip1;
                int tag = All.Class.Num.ToInt(e.Node.Tag);
                switch (tag)
                {
                    case 0:
                        btnAddError.Visible = true;
                        btnDelError.Visible = false;
                        btnAddError.Text = "添加故障分类";
                        break;
                    case 1:
                        btnAddError.Visible = true;
                        btnDelError.Visible = true;
                        btnAddError.Text = string.Format("添加【{0}】分项", e.Node.Text);
                        btnDelError.Text = string.Format("删除【{0}】", e.Node.Text);
                        break;
                    case 2:
                        btnAddError.Visible = true;
                        btnDelError.Visible = true;
                        btnAddError.Text = string.Format("添加【{0}】原因", e.Node.Text);
                        btnDelError.Text = string.Format("删除【{0}】", e.Node.Text);
                        break;
                    case 3:
                        btnAddError.Visible = false;
                        btnDelError.Visible = true;
                        btnDelError.Text = string.Format("删除【{0}】", e.Node.Text);
                        break;
                }
            }
            else
            {
                treeError.ContextMenuStrip = null;
            }
        }

        private void btnAddError_Click(object sender, EventArgs e)
        {
            if (treeError.SelectedNode != null)
            {
                using (All.Window.frmAddTextValue ftv = new All.Window.frmAddTextValue("请输入故障"))
                {
                    if (ftv.ShowDialog() == DialogResult.Yes)
                    {
                        treeError.SelectedNode.Nodes.Add(CreatNode(ftv.Value, All.Class.Num.ToInt(treeError.SelectedNode.Tag) + 1, true));
                    }
                }
            }
        }
        private void btnDelError_Click(object sender, EventArgs e)
        {
            if (treeError.SelectedNode != null )
            {
                treeError.SelectedNode.Remove();
            }
        }

        private void treeStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                treeStation.ContextMenuStrip = contextMenuStrip2;
                int tag = All.Class.Num.ToInt(e.Node.Tag);
                switch (tag)
                {
                    case 0:
                        treeStation.ContextMenuStrip = null;
                        break;
                    case 1:
                        btnAdd.Visible = true;
                        btnDel.Visible = false;
                        btnAdd.Text = string.Format("添加【{0}】故障类", e.Node.Text);
                        break;
                    case 2:
                        btnAdd.Visible = false;
                        btnDel.Visible = true;
                        btnDel.Text = string.Format("删除【{0}】", e.Node.Text);
                        break;
                }
            }
            else
            {
                treeStation.ContextMenuStrip = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeStation.SelectedNode != null)
            {
                List<string> ss = new List<string>();

                TreeNode tnL1 = treeError.Nodes["所有故障列表"];
                if (tnL1 == null)
                {
                    return;
                }
                for (int i = 0; i < tnL1.Nodes.Count; i++)
                {
                    ss.Add(tnL1.Nodes[i].Text);
                }

                using (All.Window.frmAddComValue ftv = new All.Window.frmAddComValue("请输入故障", ss.ToArray()))
                {
                    if (ftv.ShowDialog() == DialogResult.Yes)
                    {
                        treeStation.SelectedNode.Nodes.Add(CreatNode(ftv.Value, All.Class.Num.ToInt(treeStation.SelectedNode.Tag) + 1, true));
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (treeError.SelectedNode != null)
            {
                treeError.SelectedNode.Remove();
            }
        }

    }
}
