using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
        #region//操作计时

        /// <summary>
        /// 停机时间
        /// </summary>
        public class cAllStatueTestTime
        {
            /// <summary>
            /// 生长一台机器完成
            /// </summary>
            public event Action<DateTime, int, int, string> HaveTestMachine;
			/// <summary>
			/// 所有操作岗位停机时间 ,总停机时间
			/// </summary>
            public StatueTestTime[] AllStatueTestTime
            { get; set; }
            /// <summary>
            /// 当天的停机时间
            /// </summary>
            public StatueTestTime[] TodayStatueTestTime
            { get; set; }
            public cAllStatueTestTime()
            {
                AllStatueTestTime = new StatueTestTime[HeiFeiMideaDll.cMain.AllStopStationCount];
                for (int i = 0; i < AllStatueTestTime.Length; i++)
                {
                    AllStatueTestTime[i] = new StatueTestTime(i + 1);
                }
                TodayStatueTestTime = new StatueTestTime[HeiFeiMideaDll.cMain.AllStopStationCount];
                for (int i = 0; i < TodayStatueTestTime.Length; i++)
                {
                    TodayStatueTestTime[i] = new StatueTestTime(i + 1);
                    TodayStatueTestTime[i].HaveTestMachine += cAllStatueTestTime_HaveTestMachine;
                }
            }

            void cAllStatueTestTime_HaveTestMachine(DateTime arg1, int arg2, int arg3, string arg4)
            {
                if (HaveTestMachine != null)
                {
                    HaveTestMachine(arg1, arg2, arg3, arg4);
                }
            }
            /// <summary>
            /// 读取数据库中的操作计时
            /// </summary>
            /// <param name="dt"></param>
            public void FlushAllTestTime(DataTable dt)
            {
                int index = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                    if (index > 0 && index <=HeiFeiMideaDll.cMain.AllStopStationCount)
                    {
                        AllStatueTestTime[index - 1].TestTime = All.Class.Num.ToInt(dt.Rows[i]["TestTime"]);
                        AllStatueTestTime[index - 1].TimeCount = All.Class.Num.ToInt(dt.Rows[i]["TimeCount"]);
                        AllStatueTestTime[index - 1].MaxTime = All.Class.Num.ToInt(dt.Rows[i]["MaxTime"]);
                        AllStatueTestTime[index - 1].MinTime = All.Class.Num.ToInt(dt.Rows[i]["MinTime"]);
                        AllStatueTestTime[index - 1].AverageTime = All.Class.Num.ToFloat(dt.Rows[i]["AverageTime"]);
                        AllStatueTestTime[index - 1].OperaCount = All.Class.Num.ToInt(dt.Rows[i]["OperaCount"]);
                        AllStatueTestTime[index - 1].RunTime = All.Class.Num.ToBool(dt.Rows[i]["RunTime"]);
                    }
                }
            }
            /// <summary>
            /// 刷新数据库今日操作计时
            /// </summary>
            /// <param name="dt"></param>
            public void FlushTodayTestTime(DataTable dt)
            {
                int index = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                    if (index > 0 && index <= HeiFeiMideaDll.cMain.AllStopStationCount)
                    {
                        TodayStatueTestTime[index - 1].TimeCount = All.Class.Num.ToInt(dt.Rows[i]["TimeCount"]);
                        TodayStatueTestTime[index - 1].OperaCount = All.Class.Num.ToInt(dt.Rows[i]["OperaCount"]);
                    }
                }
            }
            public class StatueTestTime
            {
                /// <summary>
                /// 生长一台机器完成
                /// </summary>
                public event Action<DateTime, int, int, string> HaveTestMachine;
                /// <summary>
                /// 工位号
                /// </summary>
                public int LineWorkStation
                { get; set; }
                /// <summary>
                /// 当次操作时间
                /// </summary>
                public int TestTime
                { get; set; }
                /// <summary>
                /// 操作总时间
                /// </summary>
                public int TimeCount
                { get; set; }
                /// <summary>
                /// 最快的一次操作
                /// </summary>
                public int MinTime
                { get; set; }
                /// <summary>
                /// 最慢的一次操作
                /// </summary>
                public int MaxTime
                { get; set; }
                /// <summary>
                /// 平均操作时间
                /// </summary>
                public float AverageTime
                { get; set; }
                /// <summary>
                /// 今日操作次数
                /// </summary>
                public int OperaCount
                { get; set; }
                /// <summary>
                /// 当前状态，True为正在计时，False为不计时
                /// </summary>
                public bool RunTime
                { get; set; }
                public StatueTestTime()
                    : this(0)
                {
                }
                public StatueTestTime(int workStation)
                {
                    LineWorkStation = workStation;
                    TestTime = 0;
                    TimeCount = 0;
                    MaxTime = 0;
                    MinTime = 0;
                    AverageTime = 0;
                    OperaCount = 0;
                    RunTime = false;
                }
                /// <summary>
                /// 从工位状态获取操作时间状态
                /// </summary>
                /// <param name="statueLine"></param>
                /// <param name="tableName">因为有两个函数在刷新这里, 只有当刷新调用方为tmpInfoStationTestTime时才保存一次到AllStationTimeEveryHour</param>
                /// <returns></returns>
                public void FlushLineStationToTestTime(bool StopAllTime,string tableName)
                {
                    if (LineWorkStation <= 0 || LineWorkStation > HeiFeiMideaDll.cMain.AllStopStationCount)
                    {
                        return;
                    }
                    if (frmMain.mMain.AllCars.AllStatueLineStation == null)
                    {
                        return;
                    }
                    if (frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation-1] == null)
                    {
                        return;
                    }
                    if (frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation - 1].HaveCar &&
                        !frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation - 1].TestOver &&
                        !frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation - 1].Level &&
                        !this.RunTime)
                    {
                        this.OperaCount++;
                        this.RunTime = true;
                    }
                    if (frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation-1].TestOver)//每次离站时,插入一台机器完成信息,从而可以计算历史线平衡信息
                    {
                        if (this.RunTime && this.TestTime > 0 && tableName == "tmpInfoStationTestTime")
                        {
                            if (frmMain.mMain.AllCars.AllInfoLineStation != null &&
                                frmMain.mMain.AllCars.AllInfoLineStation[LineWorkStation - 1].TestStation)
                            {
                                if (HaveTestMachine != null)
                                {
                                    HaveTestMachine(DateTime.Now, this.TestTime, LineWorkStation, frmMain.mMain.AllCars.AllInfoLineStation[LineWorkStation - 1].StationName);
                                }
                            }
                        }
                        this.TestTime = 0;
                        this.RunTime = false;
                    }
                    if (this.RunTime && !StopAllTime && frmMain.mMain.AllCars.AllStatueLineStation[LineWorkStation - 1].HaveMachine)
                    {
                        this.TimeCount++;
                        this.TestTime++;
                    }
                    if (this.OperaCount > 0)
                    {
                        this.AverageTime = this.TimeCount / this.OperaCount;
                    }
                    if (this.MaxTime < this.TestTime)
                    {
                        this.MaxTime = this.TestTime;
                    }
                    if (this.MinTime > this.TestTime)
                    {
                        this.MinTime = this.TestTime;
                    }
                }
            }
        }
        #endregion
    
}
