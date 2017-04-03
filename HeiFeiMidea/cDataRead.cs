using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class cDataRead
    {        
        /// <summary>
        /// 刷新读取操作数据库连接
        /// </summary>
        public All.Class.DataReadAndWrite ReadData
        { get; set; }

        public cDataRead(All.Class.DataReadAndWrite readData)
        {
            this.ReadData = readData;
        }
        #region//小车
        /// <summary>
        /// 读取所有小车状态,并将小车状态转化工位状态
        /// </summary>
        /// <returns></returns>
        public void FlushAllCarStatue(DataTable dt,bool Init)
        {
            int index = 0;
            int workLineStation = 0;
            int prevWorkLineStation = 0;

                if (dt.Rows.Count == HeiFeiMideaDll.cMain.AllCarCount)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        index = All.Class.Num.ToInt(dt.Rows[i]["TestNo"]);
                        workLineStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        prevWorkLineStation = All.Class.Num.ToInt(dt.Rows[i]["PrevWorkStation"]);
                        //小车号故障
                        if (index < 0 || index >= HeiFeiMideaDll.cMain.AllCarCount)
                        {
                            continue;
                        }
                        //停车号故障
                        if (workLineStation <= 0 || workLineStation > HeiFeiMideaDll.cMain.AllStopStationCount)
                        {
                            if (workLineStation == 0)//小车中间下线，直接清除临时变量
                            {
                                frmMain.mMain.AllCars.AllStatueCar[index].SetStatue(
                                    i, 0, 0, 0, "", 0, 0, Init);
                            }
                            continue;
                        }
                        frmMain.mMain.AllCars.AllStatueCar[index].SetStatue(
                            All.Class.Num.ToInt(dt.Rows[i]["TestNo"]),
                            All.Class.Num.ToUshort(dt.Rows[i]["S0"]),
                            All.Class.Num.ToUshort(dt.Rows[i]["S1"]),
                            All.Class.Num.ToUshort(dt.Rows[i]["E0"]),
                            All.Class.Num.ToString(dt.Rows[i]["BarCode"]),
                            workLineStation,
                            prevWorkLineStation,Init);
                    }
                }
                else
                {
                    All.Class.Error.Add("读取到的小车状态数量与实际小车数据不匹配", Environment.StackTrace);
                }
            
        }
        /// <summary>
        /// 读取所有停机工位状态
        /// </summary>
        /// <returns></returns>
        public void FlushAllStationStatue(DataTable dt,bool init)
        {
            int index = 0;
            if (dt.Rows.Count == HeiFeiMideaDll.cMain.AllStopStationCount)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]) - 1;
                    if (index < 0 || index >= HeiFeiMideaDll.cMain.AllStopStationCount)
                    {
                        continue;
                    }
                    frmMain.mMain.AllCars.AllStatueLineStation[index].SetStatue(init,
                        All.Class.Num.ToBool(dt.Rows[i]["HaveCar"]),
                        All.Class.Num.ToBool(dt.Rows[i]["Error"]),
                        All.Class.Num.ToBool(dt.Rows[i]["HaveMachine"]),
                        All.Class.Num.ToBool(dt.Rows[i]["Ok"]),
                        All.Class.Num.ToBool(dt.Rows[i]["CarLevel"]),
                        All.Class.Num.ToBool(dt.Rows[i]["Test"]),
                        All.Class.Num.ToBool(dt.Rows[i]["TestOver"]),
                        All.Class.Num.ToString(dt.Rows[i]["BarCode"]));
                }
            }
            else
            {
                All.Class.Error.Add("读取到的停机工位数量和实际停机工位数量不匹配", Environment.StackTrace);
            }
        }
        #endregion
        #region//冷凝器状态
        public void FlushLengNinQi(DataTable dt)
        {
            int index = 0;
            if (dt.Rows.Count == HeiFeiMideaDll.cMain.AllLengNinQiCount)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]) - 1;
                    if (index < 0 || index >= HeiFeiMideaDll.cMain.AllLengNinQiCount)
                    {
                        continue;
                    }
                    frmMain.mMain.AllCars.AllStatueLengNinQi.AllLengNinStation[index].SetStatue(
                        All.Class.Num.ToBool(dt.Rows[i]["HaveMachine"]),
                        All.Class.Num.ToString(dt.Rows[i]["BarCode"]));
                }
            }
        }
        #endregion
        #region//读其他设备状态
        public void FlushOther(DataTable dt)
        {

            int index = 0;
            if (dt.Rows.Count == HeiFeiMideaDll.cMain.AllOtherMachineCount)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]) - 1;
                    if (index < 0 || index >= HeiFeiMideaDll.cMain.AllOtherMachineCount)
                    {
                        continue;
                    }
                    //普通故障
                    if (frmMain.mMain.AllCars.AllStatueOther[i].Error != All.Class.Num.ToBool(dt.Rows[i]["Error"]))
                    {
                        switch (frmMain.mMain.AllCars.AllStatueOther[i].WorkStation)
                        {
                            case 3:
                                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.机器人))
                                {
                                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("{0}#机器人故障", frmMain.mMain.AllCars.AllStatueOther[i].WorkStation), All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                                }
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.机器人, frmMain.mMain.AllCars.AllStatueOther[i].WorkStation,
                                    All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                                break;
                            case 9://绕膜机
                                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.绕膜机))
                                {
                                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("绕膜机出现故障", All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                                }
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.绕膜机, All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                                break;
                            case 10://打包机
                                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.打包机))
                                {
                                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("打包机出现故障", All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del));
                                }
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.打包机, All.Class.Num.ToBool(dt.Rows[i]["Error"]) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                                break;
                        }
                    }
                    //机器人故障
                    switch (frmMain.mMain.AllCars.AllStatueOther[i].WorkStation)
                    {
                        case 1://机器人
                            frmMain.mMain.AllCars.AllStatueOther[(int)cStatueOther.AllOther.机器人1].CheckRoobetError(cStatueOther.AllOther.机器人1, frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[165], 0);
                            break;
                        case 2:
                            frmMain.mMain.AllCars.AllStatueOther[(int)cStatueOther.AllOther.机器人2].CheckRoobetError(
                                cStatueOther.AllOther.机器人2,
                                frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[202],
                                frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[203]);
                            break;
                    }
                    
                    frmMain.mMain.AllCars.AllStatueOther[i].Error = All.Class.Num.ToBool(dt.Rows[i]["Error"]);
                    frmMain.mMain.AllCars.AllStatueOther[i].Empty = All.Class.Num.ToBool(dt.Rows[i]["Empty"]);
                    frmMain.mMain.AllCars.AllStatueOther[i].TestSmall = All.Class.Num.ToBool(dt.Rows[i]["TestSmall"]);
                    frmMain.mMain.AllCars.AllStatueOther[i].TestMax = All.Class.Num.ToBool(dt.Rows[i]["TestMax"]);
                    frmMain.mMain.AllCars.AllStatueOther[i].Run = All.Class.Num.ToBool(dt.Rows[i]["Run"]);
                }
            }
        }
        #endregion
        #region//工位
        /// <summary>
        /// 将数据库中的计时数据读取到界面显示数据
        /// </summary>
        public void FlushPcTickShow()
        {
            cPCLocal.StatueTick tmpTickStatue = new cPCLocal.StatueTick();
            int index = 0;
            frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime.ToList().ForEach(
                statueTestTime =>
                {
                    index = statueTestTime.LineWorkStation - 1;
                    if (frmMain.mMain.AllCars.AllInfoLineStation[index].TestStation)
                    {
                        //添加平均值数据
                        tmpTickStatue.StationName.Add(frmMain.mMain.AllCars.AllInfoLineStation[index].StationName);
                        tmpTickStatue.SetTime.Add(frmMain.mMain.AllCars.AllInfoLineStation[index].TimeOut);
                        tmpTickStatue.AverageTime.Add((int)statueTestTime.AverageTime);
                        tmpTickStatue.MinTime.Add(statueTestTime.MinTime);
                        tmpTickStatue.MaxTime.Add(statueTestTime.MaxTime);

                        //判断最慢的三个位置
                        if (tmpTickStatue.SlowAverageTime.Count < 3)
                        {
                            bool insert = false;
                            for (int i = 0; i < tmpTickStatue.SlowAverageTime.Count; i++)
                            {
                                if (statueTestTime.AverageTime > tmpTickStatue.SlowAverageTime[i])
                                {
                                    tmpTickStatue.SlowName.Insert(i, frmMain.mMain.AllCars.AllInfoLineStation[index].StationName);
                                    tmpTickStatue.SlowAverageTime.Insert(i, (int)statueTestTime.AverageTime);
                                    insert = true;
                                    break;
                                }
                            }
                            if (!insert)
                            {
                                tmpTickStatue.SlowName.Add(frmMain.mMain.AllCars.AllInfoLineStation[index].StationName);
                                tmpTickStatue.SlowAverageTime.Add((int)statueTestTime.AverageTime);
                            }
                        }
                        else
                        {
                            bool insert = false;
                            if ((int)statueTestTime.AverageTime > tmpTickStatue.SlowAverageTime[2])//当前值 比最慢的还要慢，就替换最慢的
                            {
                                tmpTickStatue.SlowName.RemoveAt(2);
                                tmpTickStatue.SlowAverageTime.RemoveAt(2);
                                for (int i = 0; i < tmpTickStatue.SlowAverageTime.Count; i++)
                                {
                                    if (statueTestTime.AverageTime > tmpTickStatue.SlowAverageTime[i])
                                    {
                                        tmpTickStatue.SlowName.Insert(i, frmMain.mMain.AllCars.AllInfoLineStation[index].StationName);
                                        tmpTickStatue.SlowAverageTime.Insert(i, (int)statueTestTime.AverageTime);
                                        insert = true;
                                        break;
                                    }
                                }
                                if (!insert)
                                {
                                    tmpTickStatue.SlowName.Add(frmMain.mMain.AllCars.AllInfoLineStation[index].StationName);
                                    tmpTickStatue.SlowAverageTime.Add((int)statueTestTime.AverageTime);
                                }
                            }
                        }
                    }
                }
            );
            frmMain.mMain.AllPCs.AllStatueTick = tmpTickStatue;
        }
        #endregion
        #region//刷新主机订单
        public void FlushPcOrderShow()
        {
            List<HeiFeiMideaDll.OrderSet> todayOrder = HeiFeiMideaDll.OrderSet.GetOrder(
                frmMain.mMain.AllOrder, DateTime.Now);
            cPCLocal.OrderCount tmpOrderCount = new cPCLocal.OrderCount();
            cPCLocal.OrderCount.OrderShow orderShow;
            if (todayOrder != null && todayOrder.Count > 0)
            {
                todayOrder.ForEach(
                    order =>
                    {
                        if (order.OrderMonth == DateTime.Now.Month && order.OrderDay == DateTime.Now.Day)
                        {
                            orderShow = new cPCLocal.OrderCount.OrderShow();
                            orderShow.OrderName = order.OrderName;
                            orderShow.OrderCount = order.BarEnd - order.BarStart + 1;
                            using (DataTable dt = ReadData.Read(string.Format("select Count(ID) as OrderOverNum from TestAll where OrderName='{0}' and OutLine='True'", order.OrderName)))
                            {
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    orderShow.OverCount = All.Class.Num.ToInt(dt.Rows[0]["OrderOverNum"]);
                                    tmpOrderCount.CurOverCount += All.Class.Num.ToInt(dt.Rows[0]["OrderOverNum"]);
                                }
                            }
                            tmpOrderCount.AllOrderCount++;
                            tmpOrderCount.AllNeedCount += order.BarEnd - order.BarStart + 1;
                            tmpOrderCount.OrderShows.Add(orderShow);
                        }
                    });
            }
            frmMain.mMain.AllPCs.AllOrderCount = tmpOrderCount;
        }
        #endregion
        #region//刷新主机小时产量
        /// <summary>
        /// 刷新显示用的小时产量
        /// </summary>
        public void FlushPcHourCountShow()
        {
            using (DataTable dt = ReadData.Read(string.Format("select Hour,OutLineCount,InLineCount,UseNow,OutLineHourUp,OutLineHourDown from StatueCountPerHour order by Hour")))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        frmMain.mMain.AllPCs.AllCountPerHour.SetValue(
                            All.Class.Num.ToInt(dt.Rows[i]["Hour"]),
                            All.Class.Num.ToInt(dt.Rows[i]["OutLineCount"]),
                            All.Class.Num.ToInt(dt.Rows[i]["InLineCount"]),
                            All.Class.Num.ToBool(dt.Rows[i]["UseNow"]),
                            All.Class.Num.ToInt(dt.Rows[i]["OutLineHourUp"]),
                            All.Class.Num.ToInt(dt.Rows[i]["OutLineHourDown"]));
                    }
                }
            }
        }
        #endregion
    }
}
