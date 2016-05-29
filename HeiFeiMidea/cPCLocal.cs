using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class cPCLocal
    {
        #region//所有MCGS状态
        public class AllMcgsStatue
        {
            /// <summary>
            /// 所有MCGS设备
            /// </summary>
            public McgsStatue[] Mcgs
            {
                get;
                set;
            }
            public class McgsStatue
            {
                /// <summary>
                /// MCGS工位号
                /// </summary>
                public int WorkStation
                { get; set; }

                bool connect = true;
                /// <summary>
                /// 连接状态
                /// </summary>
                public bool Connect
                {
                    get
                    {
                        return connect;
                    }
                }
                /// <summary>
                /// 此处在FlushAllError里面刷新
                /// </summary>
                public void Flush()
                {
                    if (connect != frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + WorkStation - 1].Sons[0].Conn)
                    {
                        frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.工位屏, WorkStation, frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + WorkStation - 1].Sons[0].Conn ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add);
                        frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}  通讯故障", frmMain.mMain.AllCars.AllInfoStation[WorkStation].StationName), (connect ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                    }
                    connect = frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + WorkStation - 1].Sons[0].Conn;
                        
                }
                public McgsStatue(int workIndex)
                {
                    this.WorkStation = workIndex;
                }
            }
            public AllMcgsStatue()
            {
                Mcgs = new McgsStatue[HeiFeiMideaDll.cMain.AllTestComputer];
                for (int i = 0; i < Mcgs.Length; i++)
                {
                    Mcgs[i] = new McgsStatue(i + 1);
                }
            }
        }

        #endregion
        #region//瓶颈岗位
        /// <summary>
        /// 瓶颈岗位刷新数据
        /// </summary>
        public class StatueTick
        {
            /// <summary>
            /// 停车工位时间 
            /// </summary>
            public List<string> StationName
            { get; set; }
            /// <summary>
            /// 停车工位平均时间
            /// </summary>
            public List<int> AverageTime
            { get; set; }
            /// <summary>
            /// 停车工位最快时间
            /// </summary>
            public List<int> MinTime
            { get; set; }
            /// <summary>
            /// 停车工位最慢时间
            /// </summary>
            public List<int> MaxTime
            { get; set; }

            /// <summary>
            /// 停车工位最慢三强
            /// </summary>
            public List<string> SlowName
            { get; set; }
            /// <summary>
            /// 停车工位最慢三强时间
            /// </summary>
            public List<int> SlowAverageTime
            { get; set; }
            public StatueTick()
            {
                StationName = new List<string>();
                AverageTime = new List<int>();
                MinTime = new List<int>();
                MaxTime = new List<int>();
                SlowName = new List<string>();
                SlowAverageTime = new List<int>();
            }
        }
        #endregion
        #region//订单数量
        public class OrderCount
        {
            /// <summary>
            /// 总的订单数量
            /// </summary>
            public int AllOrderCount
            { get; set; }
            /// <summary>
            /// 所有订单加起来的产量数量
            /// </summary>
            public int AllNeedCount
            { get; set; }
           /// <summary>
           /// 实际完成产量数量 
           /// </summary>
            public int CurOverCount
            { get; set; }
            /// <summary>
            /// 显示订单
            /// </summary>
            public class OrderShow
            {
                /// <summary>
                /// 订单名称
                /// </summary>
                public string OrderName
                { get; set; }
                /// <summary>
                /// 单个订单产量
                /// </summary>
                public int OrderCount
                { get; set; }
                /// <summary>
                /// 单个订单完成产量
                /// </summary>
                public int OverCount
                { get; set; }
                public OrderShow()
                {
                    OrderName = "";
                    OrderCount = 0;
                    OverCount = 0;
                }
            }
            /// <summary>
            /// 所有要显示的订单
            /// </summary>
            public List<OrderShow> OrderShows
            { get; set; }
            public OrderCount()
            {
                this.AllNeedCount = 0;
                this.AllOrderCount = 0;
                this.CurOverCount = 0;
                this.OrderShows = new List<OrderShow>();
            }
        }
        #endregion
        #region//小时生产产量
        public class CountPerHour
        {
            /// <summary>
            /// 每小时产量
            /// </summary>
            public class EveryHour
            {
                /// <summary>
                /// 时间
                /// </summary>
                public int Hour
                { get; set; }
                /// <summary>
                /// 产量
                /// </summary>
                public int OutLineCount
                { get; set; }
                /// <summary>
                /// 小时上半个小时产量
                /// </summary>
                public int OutLineHourUp
                { get; set; }
                /// <summary>
                /// 小时下半个小时产量
                /// </summary>
                public int OutLineHourDown
                { get; set; }
                /// <summary>
                /// 是否使用
                /// </summary>
                public bool Use
                { get; set; }
                /// <summary>
                /// 上线数量
                /// </summary>
                public int InLineCount
                { get; set; }
                /// <summary>
                /// 显示时间
                /// </summary>
                public string HourShow
                {
                    get
                    {
                        return string.Format("{0}时->{1}时", Hour, Hour + 1);
                    }
                }
                public EveryHour(int hour)
                {
                    this.Hour = hour;
                    this.OutLineCount = 0;
                    this.InLineCount = 0;
                    this.OutLineHourDown = 0;
                    this.OutLineHourUp = 0;
                    if (hour >= 7 && hour <= 19)
                        Use = true;
                    else
                        Use = false;
                }
            }
            /// <summary>
            /// 总目标
            /// </summary>
            public int AllCount
            {
                get 
                {
                    if (frmMain.mMain.AllPCs.AllOrderCount == null)
                    {
                        return 0;
                    }
                    return frmMain.mMain.AllPCs.AllOrderCount.AllNeedCount;
                }
            }
            /// <summary>
            /// 上线数量
            /// </summary>
            public int InLineCount
            {
                get
                {
                    if (AllHour == null || AllHour.Length != 24)
                    {
                        return 0;
                    }
                    int result = 0;
                    for (int i = 0; i < AllHour.Length; i++)
                    {
                        if (AllHour[i].Use)
                        {
                            result += AllHour[i].InLineCount;
                        }
                    }
                    return result;
                }
            }
            /// <summary>
            /// 下线数量
            /// </summary>
            public int OutLineCount
            {
                get
                {
                    if (AllHour == null || AllHour.Length != 24)
                    {
                        return 0;
                    }
                    int result = 0;
                    for (int i = 0; i < AllHour.Length; i++)
                    {
                        if (AllHour[i].Use)
                        {
                            result += AllHour[i].OutLineCount;
                        }
                    }
                    return result;
                }
            }
            /// <summary>
            /// 二十四小时记录
            /// </summary>
            public EveryHour[] AllHour
            { get; set; }
            public List<string> TimeXLine
            {
                get 
                {
                    List<string> timeXLine = new List<string>();
                    y = new List<int>();
                    z = new List<int>();
                    if (AllHour == null || AllHour.Length != 24)
                    {
                        return timeXLine;
                    }
                    for (int i = 0; i < AllHour.Length; i++)
                    {
                        if (AllHour[i].Use)
                        {
                            timeXLine.Add(string.Format("{0}时-{1}时", AllHour[i].Hour, AllHour[i].Hour + 1));
                            y.Add(AllHour[i].InLineCount);
                            z.Add(AllHour[i].OutLineCount);
                        }
                    }
                    return timeXLine;
                }
            }
            List<int> y = new List<int>();
            /// <summary>
            /// 上线数量数组
            /// </summary>
            public List<int> InCountLine
            {
                get { return y; }
            }
            List<int> z = new List<int>();
            /// <summary>
            /// 下线数量数组
            /// </summary>
            public List<int> Z
            {
                get { return z; }
            }
            public CountPerHour()
            {
                AllHour = new EveryHour[24];
                for (int i = 0; i < AllHour.Length; i++)
                {
                    AllHour[i] = new EveryHour(i);
                }
            }
            /// <summary>
            /// 将读取值写入到显示类
            /// </summary>
            /// <param name="hour"></param>
            /// <param name="outLineCount"></param>
            /// <param name="use"></param>
            public void SetValue(int hour,int outLineCount,int inLineCount, bool use,int outLineHourUp,int outLineHourDown)
            {
                if (hour < 0 && hour > 23)
                {
                    return;
                }
                if (AllHour == null || hour >= AllHour.Length)
                {
                    return;
                }
                AllHour[hour].Hour = hour;
                AllHour[hour].OutLineCount = outLineCount;
                AllHour[hour].OutLineHourUp = outLineHourUp;
                AllHour[hour].OutLineHourDown = outLineHourDown;
                AllHour[hour].InLineCount = inLineCount;
                AllHour[hour].Use = use;
            }
        }
        #endregion
        /// <summary>
        /// 所有工位生产效率表，显示用
        /// </summary>
        public StatueTick AllStatueTick
        { get; set; }
        /// <summary>
        /// 所有工位生产效率表，内部刷新用
        /// </summary>
        public cAllStatueTestTime AllStatueTestTime
        { get; set; }
        /// <summary>
        /// 所有订单信息，显示用
        /// </summary>
        public OrderCount AllOrderCount
        { get; set; }
        /// <summary>
        /// 所有小时产量
        /// </summary>
        public CountPerHour AllCountPerHour
        { get; set; }
        /// <summary>
        /// 所有MCGS工位
        /// </summary>
        public AllMcgsStatue AllMcgs
        { get; set; }
        public cPCLocal()
        {
            AllStatueTick = new StatueTick();
            AllOrderCount = new OrderCount();
            AllCountPerHour = new CountPerHour();
            AllMcgs = new AllMcgsStatue();
            AllStatueTestTime = new cAllStatueTestTime();
        }
    }
}
