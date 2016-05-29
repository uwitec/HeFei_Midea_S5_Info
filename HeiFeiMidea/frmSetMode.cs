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
    public partial class frmSetMode : All.Window.MainWindow
    {
        int start = 0;
        int end = 0;
        TextBox[] txtBar = new TextBox[15];

        public frmSetMode()
        {
            InitializeComponent();
        }

        private void frmSetMode_Load(object sender, EventArgs e)
        {
            InitFrm();
            InitData();
        }
        private void InitFrm()
        {
            for (int i = 0; i < txtBar.Length; i++)
            {
                txtBar[i] = (TextBox)this.Controls.Find(string.Format("txtBar{0}", i + 1), true)[0];
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.Columns["colWorkStation"].DataPropertyName = "WorkStation";
            dataGridView1.Columns["colStart"].DataPropertyName = "Start";
            dataGridView1.Columns["colEnd"].DataPropertyName = "End";
            dataGridView1.Columns["colFile"].DataPropertyName = "PlayFile";

            dataGridView1.Columns["colStart"].Visible = false;
            dataGridView1.Columns["colEnd"].Visible = false;


            for (int i = 0; i < 16; i++)
            {
                cbbMachineID.Items.Add(i.ToString());
            }
            cbbMachineID.Text = "0";

            cbbYaJi.Items.Clear();
            string[] tmp = HeiFeiMideaDll.cNiuJu.AllYaSuoJi(frmMain.mMain.AllDataBase.LocalData);
            if (tmp != null && tmp.Length > 0)
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    cbbYaJi.Items.Add(tmp[i]);
                }
            }
            cbbFengJi.Items.Clear();
            tmp = HeiFeiMideaDll.cNiuJu.AllFengJi(frmMain.mMain.AllDataBase.LocalData);
            if (tmp != null && tmp.Length > 0)
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    cbbFengJi.Items.Add(tmp[i]);
                }
            }
            cbbZheWangID.Items.Clear();
            List<HeiFeiMideaDll.ModeZheWangSet> allZheWang = HeiFeiMideaDll.ModeZheWangSet.GetModeList(frmMain.mMain.AllDataBase.LocalData);
            allZheWang.ForEach(
                zheWang =>
                {
                    cbbZheWangID.Items.Add(zheWang.ID);
                }) ;
        }
        private void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("WorkStation", typeof(string));
            dt.Columns.Add("Start", typeof(int));
            dt.Columns.Add("End", typeof(int));
            dt.Columns.Add("PlayFile", typeof(string));
            DataRow dr;
            frmMain.mMain.AllCars.AllInfoStation.ToList().ForEach(
                allStation =>
                {
                    if (allStation.TestStation && allStation.WorkStation != 11)
                    {
                        if (lblWorkStation.Text == "")
                        {
                            lblWorkStation.Text = allStation.StationName;
                        }
                        dr = dt.NewRow();
                        dr["WorkStation"] = allStation.StationName;
                        dr["Start"] = 0;
                        dr["End"] = 0;
                        dr["PlayFile"] = "";
                        dt.Rows.Add(dr);
                    }
                }
            );
            dataGridView1.DataSource = dt;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmSetModeList fsm = new frmSetModeList(frmSetModeList.ModeLists.Mode);
            if (fsm.ShowDialog() == DialogResult.Yes)
            {
                ClassToFrm(HeiFeiMideaDll.ModeSet.GetMode(fsm.ModeID,frmMain.mMain.AllDataBase.LocalData));
            }
            fsm.Dispose();
        }
        /// <summary>
        /// 将机型设置显示到界面
        /// </summary>
        /// <param name="ms"></param>
        private void ClassToFrm(HeiFeiMideaDll.ModeSet ms)
        {
            if (ms != null)
            {
                txtID.Text = ms.ID;
                txtMode.Text = ms.Mode;
                txtInfo.Text = ms.Info;

                DataTable dt = (DataTable)dataGridView1.DataSource;

                for (int i = 0; i < dt.Rows.Count && i < ms.PlayFile.Length && i < ms.Start.Length && i < ms.End.Length; i++)
                {
                    dt.Rows[i]["Start"] = ms.Start[i];
                    dt.Rows[i]["End"] = ms.End[i];
                    dt.Rows[i]["PlayFile"] = ms.PlayFile[i];
                }
                dataGridView1.DataSource = dt;
                txtYaSuoJiID1.Text = ms.YaSuoJiID[0];
                txtYaSuoJiID2.Text = ms.YaSuoJiID[1];
                txtYaSuoJiID3.Text = ms.YaSuoJiID[2];
                txtYaSuoJiID4.Text = ms.YaSuoJiID[3];

                
                cbbMachineID.Text = ms.MachineID.ToString();

                txtFengJi1.Text = ms.FengJiID[0];
                txtFengJi2.Text = ms.FengJiID[1];
                txtFengJi3.Text = ms.FengJiID[2];
                txtFengJi4.Text = ms.FengJiID[3];

                txtDianKong.Text = ms.DianKongID;

                for (int i = 0; i < cbbYaJi.Items.Count; i++)
                {
                    if (cbbYaJi.Items[i].ToString().IndexOf(ms.NiuJuIDOne.ToString()) == 0)
                    {
                        cbbYaJi.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < cbbFengJi.Items.Count; i++)
                {
                    if (cbbFengJi.Items[i].ToString().IndexOf(ms.NiuJuIDTwo.ToString()) == 0)
                    {
                        cbbFengJi.SelectedIndex = i;
                        break;
                    }
                }
                cbbZheWangID.Text = ms.ZheWangID;

            }
        }
        private HeiFeiMideaDll.ModeSet FrmToClass()
        {
            HeiFeiMideaDll.ModeSet result = new HeiFeiMideaDll.ModeSet();
            result.ID = txtID.Text.Trim();
            result.Mode = txtMode.Text.Trim();
            result.Info = txtInfo.Text;
            dataGridView1.EndEdit();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.PlayFile[i] = All.Class.Num.ToString(dt.Rows[i]["PlayFile"]);
                result.Start[i] = All.Class.Num.ToInt(dt.Rows[i]["Start"]);
                result.End[i] = All.Class.Num.ToInt(dt.Rows[i]["End"]);
            }
            result.YaSuoJiID[0] = txtYaSuoJiID1.Text;
            result.YaSuoJiID[1] = txtYaSuoJiID2.Text;
            result.YaSuoJiID[2] = txtYaSuoJiID3.Text;
            result.YaSuoJiID[3] = txtYaSuoJiID4.Text;
            for (int i = 0; i < result.StrBar.Length; i++)
            {
                result.StrBar[i] = txtBar[i].Text;
            }
            result.MachineID = cbbMachineID.SelectedIndex;

            if (cbbYaJi.Text != "")
            {
                result.NiuJuIDOne = All.Class.Num.ToInt(cbbYaJi.Text.Split('#')[0]);
            }
            if (cbbFengJi.Text != "")
            {
                result.NiuJuIDTwo = All.Class.Num.ToInt(cbbFengJi.Text.Split('#')[0]);
            }
            result.DianKongID = txtDianKong.Text;
            result.FengJiID[0] = txtFengJi1.Text;
            result.FengJiID[1] = txtFengJi2.Text;
            result.FengJiID[2] = txtFengJi3.Text;
            result.FengJiID[3] = txtFengJi4.Text;
            result.ZheWangID = cbbZheWangID.Text;
            return result;
        }
        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            ofdVideo.Filter = string.Format("{0}", All.Control.MediaPlayerLocal.FileFilter);
            ofdVideo.Title = "请选择机型视频文件";
            ofdVideo.InitialDirectory = frmMain.mMain.AllDataXml.LocalSet.VideoDirectory;
            ofdVideo.Multiselect = false;
            ofdVideo.FileName = "";
            if (ofdVideo.ShowDialog() == DialogResult.OK)
            {
                if (ofdVideo.FileName.IndexOf(frmMain.mMain.AllDataXml.LocalSet.VideoDirectory) < 0)
                {
                    All.Window.MetroMessageBox.Show(this, string.Format("视频文件位置错误，只能指定存放于文件夹{0}内的视频文件", frmMain.mMain.AllDataXml.LocalSet.VideoDirectory), "错误的路径",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtVideoFile.Text = ofdVideo.FileName.Replace(frmMain.mMain.AllDataXml.LocalSet.VideoDirectory, "");
                PlayFile();
                PlaySet ps = GetPlaySet(dataGridView1, lblWorkStation.Text);
                if (ps != null)
                {
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    dt.Rows[ps.RowIndex]["PlayFile"] = txtVideoFile.Text;
                    dt.Rows[ps.RowIndex]["Start"] = 0;
                    dt.Rows[ps.RowIndex]["End"] = 0;
                    dataGridView1.DataSource = dt;
                }
            }
        }
        bool playing = false;
        bool pause = false;
        private void PlayFile()
        {
            string fileName = string.Format("{0}\\{1}", frmMain.mMain.AllDataXml.LocalSet.VideoDirectory, txtVideoFile.Text);
            if (System.IO.File.Exists(fileName))
            {
                try
                {
                    mediaPlayer1.SetFile(fileName);
                    btnPlay.BackImage = HeiFeiMidea.Properties.Resources.Circle_Pause;
                    Application.DoEvents();
                    mediaPlayer1.Play();
                    lblTime.Text = string.Format("{0:D3}/{1:D3}", mediaPlayer1.Position, mediaPlayer1.NaturalDuration);
                    tbPlay.Value = mediaPlayer1.Position;
                    playing = true;
                    timVideo.Enabled = true;
                    return;
                }
                catch(Exception e)
                {
                    All.Class.Error.Add(e);
                }
            }
            playing = false;
        }
        private void timVideo_Tick(object sender, EventArgs e)
        {
            if (playing)
            {
                using (DataTable dt = (DataTable)dataGridView1.DataSource)
                {
                    PlaySet ps = GetPlaySet(dataGridView1, lblWorkStation.Text);
                    if (ps != null)
                    {
                        start = ps.Start;
                        end = ps.End;
                    }
                }
                if ((mediaPlayer1.NaturalDuration <= 0 || mediaPlayer1.Position < mediaPlayer1.NaturalDuration) &&
                    (end <= 0 || mediaPlayer1.Position < end))
                {
                    lblTime.Text = string.Format("{0:D3}/{1:D3}", mediaPlayer1.Position, mediaPlayer1.NaturalDuration);
                    tbPlay.Maximum = mediaPlayer1.NaturalDuration;
                    tbPlay.Value = mediaPlayer1.Position;
                }
                else
                {
                    tbPlay.Value = mediaPlayer1.Position;
                    lblTime.Text = string.Format("{0:D3}/{1:D3}", mediaPlayer1.Position, mediaPlayer1.NaturalDuration);
                    //mediaPlayer1.Stop();
                    btnPlay.BackImage = HeiFeiMidea.Properties.Resources.Cirlce_Play;
                    playing = false;
                    timVideo.Enabled = false;
                }
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                if (!pause)
                {
                    PlayFile();
                }
                else
                {
                    pause = false;
                    playing = true;
                    timVideo.Enabled = true;
                    btnPlay.BackImage = HeiFeiMidea.Properties.Resources.Circle_Pause;
                    mediaPlayer1.Play();
                }
            }
            else
            {
                btnPlay.BackImage = HeiFeiMidea.Properties.Resources.Cirlce_Play;
                timVideo.Enabled = false;
                playing = false;
                mediaPlayer1.Pause();
                pause = true;
            }
        }

        private void tbPlay_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (tbPlay.Maximum > 0)
                {
                    //mediaPlayer1.Position = tbPlay.Value;
                }
            }
            catch { }
        }


        Rectangle oldRect = Rectangle.Empty;
        private void mediaPlayer1_MediaMouseDoubleClick()
        {
            if (gpVideo.Controls.Contains(panVideo))
            {
                oldRect = new Rectangle(panVideo.Location, panVideo.Size);
                gpVideo.Controls.Remove(panVideo);
                this.Controls.Add(panVideo);
                panVideo.BringToFront();
                panVideo.Location = new Point(0, 0);
                panVideo.Size = new Size(this.Width, this.Height);
            }
            else
            {
                panVideo.Size = oldRect.Size;
                panVideo.Location = oldRect.Location;
                this.Controls.Remove(panVideo);
                gpVideo.Controls.Add(panVideo);
                oldRect = Rectangle.Empty;
            }
        }

        private void frmSetMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            mediaPlayer1.Stop();
            timVideo.Enabled = false;
            timVideo.Stop();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView1.Columns.Count
                && e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                lblWorkStation.Text = All.Class.Num.ToString(dt.Rows[e.RowIndex]["WorkStation"]);
                if (txtVideoFile.Text != All.Class.Num.ToString(dt.Rows[e.RowIndex]["PlayFile"]) ||
                    !playing)
                {
                    txtVideoFile.Text = All.Class.Num.ToString(dt.Rows[e.RowIndex]["PlayFile"]);

                    mediaPlayer1.Stop();
                    timVideo.Enabled = false;
                    tbPlay.Value = 0;
                    lblTime.Text = "000/000";

                    PlayFile();
                }
            }
        }
        private  PlaySet GetPlaySet(DataGridView dg, string workStation)
        {
            PlaySet result = null;
            using (DataTable dt = (DataTable)dg.DataSource)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (All.Class.Num.ToString(dt.Rows[i]["WorkStation"]) ==
                            workStation)
                        {
                            result = new PlaySet();
                            result.Text = All.Class.Num.ToString(dt.Rows[i]["WorkStation"]);
                            result.Start = All.Class.Num.ToInt(dt.Rows[i]["Start"]);
                            result.End = All.Class.Num.ToInt(dt.Rows[i]["End"]);
                            result.PlayFile = All.Class.Num.ToString(dt.Rows[i]["PlayFile"]);
                            result.RowIndex = i;
                            break;
                        }
                    }
                }
            }
            return result;
        }
        private class PlaySet
        {
            public string Text
            { get; set; }
            public int Start
            { get; set; }
            public int End
            { get; set; }
            public string PlayFile
            { get; set; }
            public int RowIndex
            { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (HeiFeiMideaDll.ModeSet.Save(FrmToClass(),frmMain.mMain.AllDataBase.LocalData))
            {
                All.Window.MetroMessageBox.Show(this, string.Format("【{0}】此机型数据已成功保存至数据库", txtID.Text), "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                All.Window.MetroMessageBox.Show(this, string.Format("【{0}】此机型数据保存出现错误，请查看错误文档", txtID.Text), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (All.Window.MetroMessageBox.Show(this, string.Format("是否确认删除当前选中机型【{0}】", txtID.Text), "是否确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (HeiFeiMideaDll.ModeSet.Delete(txtID.Text,frmMain.mMain.AllDataBase.LocalData))
                {
                    All.Window.MetroMessageBox.Show(this, string.Format("当前选中机型【{0}】已成功删除", txtID.Text), "删除成功 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    All.Window.MetroMessageBox.Show(this, string.Format("当前选中机型【{0}】删除失败，机型不存在或已删除", txtID.Text), "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            btnVideo.BackColor = SystemColors.Control;
            btnOther.BackColor = SystemColors.ControlDark;
            panVideo.Visible = true;
            panOther.Visible = false;
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            btnOther.BackColor = SystemColors.Control;
            btnVideo.BackColor = SystemColors.ControlDark;
            panOther.Location = gpVideo.Location;
            panOther.Visible = true;
            panVideo.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
