using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 将主机的数据状态刷新到折弯机工位
    /// </summary>
    public class FlushLengNinQiStatueToStation:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 冷凝器线体处，各工位的状态
        /// </summary>
        public AllStatue Statues
        { get; set; }
        public FlushLengNinQiStatueToStation()
        {
            Statues = new AllStatue();
        }
        public override void Load()
        {
        }
        public override void Flush()
        {
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllLengNinQiCount; i++)
            {
                Statues.Board[i] = frmMain.mMain.AllCars.AllStatueLengNinQi.AllLengNinStation[i].HaveMachine;
            }
            Statues.PCAndPlc[0] = !frmMain.mMain.FlushSingleZheWang.Blink;
            Statues.PCAndPlc[1] = frmMain.mMain.AllPCs.AllMcgs.Mcgs[10].Connect;
            Statues.PCAndPlc[2] = frmMain.mMain.AllCars.AllStatueLengNinQi.Connect;
            Statues.PCAndPlc[3] = !frmMain.mMain.FlushSingleJianLou.Blink;
            frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + 10].Sons[0].Write<bool>(
                Statues.Statue.ToList(), 1, 13);
        }
        public class AllStatue
        {
            /// <summary>
            /// 总体状态
            /// </summary>
            public bool[] Statue
            {
                get
                {
                    if (Board == null || PCAndPlc == null)
                    {
                        return null;
                    }
                    bool[] All = new bool[Board.Length + PCAndPlc.Length];
                    Array.Copy(Board, 0, All, 0, Board.Length);
                    Array.Copy(PCAndPlc, 0, All, Board.Length, PCAndPlc.Length);
                    return All;
                }
                set
                {
                    if (value.Length != (Board.Length + PCAndPlc.Length))
                    {
                        return;
                    }
                    Array.Copy(value, 0, Board, 0, Board.Length);
                    Array.Copy(value, Board.Length, PCAndPlc, 0, PCAndPlc.Length);
                }
            }
            /// <summary>
            /// 工装板
            /// </summary>
            public bool[] Board
            { get; set; }
            /// <summary>
            /// 按上线的顺序，折弯机+折弯屏+PLC+检漏
            /// </summary>
            public bool[] PCAndPlc
            { get; set; }
            public AllStatue()
            {
                Board = new bool[HeiFeiMideaDll.cMain.AllLengNinQiCount];
                PCAndPlc = new bool[4];
                for (int i = 0; i < Board.Length; i++)
                {
                    Board[i] = false;
                }
                for (int i = 0; i < PCAndPlc.Length; i++)
                {
                    PCAndPlc[i] = false;
                }
            }
        }
    }
    #region//冷凝器线状态
    public class StatueLengNinQi
    {
        public System.Drawing.Color Color
        { get; set; }
        public bool Blink
        {
            get
            {
                if (!frmMain.mMain.AllMeterData.AllCommunite[26].Sons[0].Conn)
                {
                    this.Color = System.Drawing.Color.Purple;
                }
                return !frmMain.mMain.AllMeterData.AllCommunite[26].Sons[0].Conn;
            }
        }
        public bool Connect
        { get; set; }
        public bool Error
        { get; set; }
        /// <summary>
        /// 冷凝器线状态
        /// </summary>
        public class StatueLengNinStation
        {
            /// <summary>
            /// 工位号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 是否有板
            /// </summary>
            public bool HaveMachine
            { get; set; }
            /// <summary>
            /// 对应条码
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 显示颜色
            /// </summary>
            public System.Drawing.Color Color
            {
                get
                {
                    return HaveMachine ? System.Drawing.Color.Green : System.Drawing.Color.FromArgb(255, 40, 40, 40);
                }
            }
            public StatueLengNinStation(int index)
            {
                this.WorkStation = index;
                this.HaveMachine = false;
                this.BarCode = "";
            }
            public void SetStatue(bool haveMachine, string barCode)
            {
                if (this.WorkStation == 9 && this.BarCode != barCode)
                {
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.检大漏, barCode);
                    //frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].Write<string>(barCode, 104);
                }
                this.HaveMachine = haveMachine;
                this.BarCode = barCode;

            }
        }
        /// <summary>
        /// 所有冷凝器工位
        /// </summary>
        public StatueLengNinStation[] AllLengNinStation
        { get; set; }
        public StatueLengNinQi()
        {
            Connect = true;
            Error = false;
            AllLengNinStation = new StatueLengNinStation[HeiFeiMideaDll.cMain.AllLengNinQiCount];
            for (int i = 0; i < AllLengNinStation.Length; i++)
            {
                AllLengNinStation[i] = new StatueLengNinStation(i + 1);
            }
            this.Color = System.Drawing.Color.Green;
        }
        public void SetStatue(bool[] statue)
        {
            if (statue[1])
            {
                this.Color = System.Drawing.Color.Yellow;
            }
            if (statue[3])
            {
                this.Color = System.Drawing.Color.Green;
            }
            if (statue[4])
            {
                this.Color = System.Drawing.Color.Purple;
            }
            if (statue[4] != Error)
            {
                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.冷凝器线体))
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("冷凝器线体出现故障", (statue[4] ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                }
                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.冷凝器线体, statue[4] ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                Error = statue[4];
            }
            if (this.Connect != frmMain.mMain.AllMeterData.AllCommunite[26].Sons[0].Conn)
            {
                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.冷凝器线体))
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("冷凝器线体通讯失败", (this.Connect ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                }
                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.冷凝器线体, this.Connect ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
            }
            this.Connect = frmMain.mMain.AllMeterData.AllCommunite[26].Sons[0].Conn;
        }
    }
    #endregion
}
