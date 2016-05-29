using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class cCarLocal
    {
        #region//小车状态,StatueCar
        /// <summary>
        /// 单个小车状态
        /// </summary>
        public class StatueCar
        {
            /// <summary>
            /// 小车号
            /// </summary>
            public int TestNo
            { get; set; }
            /// <summary>
            /// 前一停车位
            /// </summary>
            public int PrevWorkLineStation
            { get; set; }
            /// <summary>
            /// 小车停机工位
            /// </summary>
            public int WorkLineStation
            { get; set; }
            /// <summary>
            /// 小车状态
            /// </summary>
            public ushort S0
            { get; set; }
            /// <summary>
            /// 小车状态
            /// </summary>
            public ushort S1
            { get; set; }
            /// <summary>
            /// 小车故障
            /// </summary>
            public ushort E0
            { get; set; }
            /// <summary>
            /// 小车条码
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 小车故障列表
            /// </summary>
            static string[] ErrorList = new string[]{"伺服报警","升降电机异常","出料电机异常",
                "小车无大小","等待下行","防撞异常","急停","读卡不成功","通讯故障"};
            public StatueCar()
            {
                this.TestNo = 0;
                this.PrevWorkLineStation = 0;
                this.WorkLineStation = 0;
                this.S0 = 0;
                this.S1 = 0;
                this.E0 = 0;
                this.BarCode = "";
            }
            /// <summary>
            /// 改变小车状态，并关联改变工位状态
            /// </summary>
            /// <param name="s0"></param>
            /// <param name="s1"></param>
            /// <param name="e0"></param>
            /// <param name="barCode"></param>
            /// <param name="workLineStation"></param>
            public void SetStatue(int testNo, ushort s0, ushort s1, ushort e0, string barCode, int workLineStation, int prevLineWorkStation,bool Init)
            {
                bool[] oldBool;
                bool[] newBool;
                if (!Init)
                {
                    switch (workLineStation)
                    {
                        case 2://添加上线
                            oldBool = All.Class.Num.Ushort2Bool(this.S0);
                            newBool = All.Class.Num.Ushort2Bool(s0);
                            if (this.BarCode.Length == 0 && barCode.Length >= 10 && newBool[10])
                            {
                                frmMain.mMain.AllDataBase.Write.AddInLineCountPerHour();
                            }
                            break;    
                        //case 47:
                        //case 48:
                        //case 49:
                        //case 50:
                        //case 51:
                        //case 52:
                        //case 53:
                        case 46://添加下线
                            oldBool = All.Class.Num.Ushort2Bool(this.S0);
                            newBool = All.Class.Num.Ushort2Bool(s0);
                            //(this.BarCode.Length >= 10 && oldBool[10] && !newBool[10]) //正常下线时，先清条码，可能条码清完了，机器没下完。造成无法计数
                            //(this.BarCode.Length >= 10 && barCode.Length == 0 && oldBool[10]))//有时候无法正常清条码
                            //(this.BarCode.Length >= 10 && barCode.Length == 0)//条码无法清除
                            if (oldBool[10] && this.WorkLineStation == 45 && this.BarCode.Length >=10)
                            {
                                frmMain.mMain.AllDataBase.Write.AddOutLineCountPerHour(this.BarCode);
                            }
                            break;
                        case 18://发给氦检的条码
                            if (this.WorkLineStation == 17)//小车从上一位置切换到当前位置时，发送条码
                            {
                                frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.充氦回收, barCode);
                                //frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Write<string>(barCode, 104);
                                //frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].Write<ushort>(1, 7);
                            }
                            break;
                        case 29://发给抽空的条码
                            if (this.WorkLineStation == 28)//小车从上一位置切换到当前位置时，发送条码
                            {
                                frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.抽空抽注, barCode);
                                //frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Write<string>(barCode, 40);
                                //frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].Write<ushort>(1, 4);
                            }
                            break;
                    }
                }
                if (this.E0 != e0)
                {
                    if (this.E0 <= ErrorList.Length && e0 <= ErrorList.Length)
                    {
                        if (this.E0 > 0)
                        {
                            frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.小车, testNo + 1, ErrorList[this.E0 - 1], FlushAllError.ChangeList.Del, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.小车, this.TestNo + 1));
                        }
                        if (e0 > 0)
                        {
                            frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.小车, testNo + 1, ErrorList[e0 - 1], FlushAllError.ChangeList.Add, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.小车, this.TestNo + 1));
                        }
                    }
                    //frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.小车, testNo + 1, (e0 > 0) ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                }
                this.TestNo = testNo;
                this.S0 = s0;
                this.S1 = s1;
                this.E0 = e0;
                this.BarCode = barCode;
                this.PrevWorkLineStation = prevLineWorkStation;
                this.WorkLineStation = workLineStation;

            }
        }
        #endregion
        #region//工位状态,StatueLineStation
        public class StatueLineStation
        {
            /// <summary>
            /// 工位ID号
            /// </summary>
            public int LineStationIndex
            { get; set; }
            /// <summary>
            /// 是否有小车
            /// </summary>
            public bool HaveCar
            { get; set; }
            /// <summary>
            /// 是否出现故障
            /// </summary>
            public bool Error
            { get; set; }
            /// <summary>
            /// 是否有机器
            /// </summary>
            public bool HaveMachine
            { get; set; }
            /// <summary>
            /// 测试是否NG
            /// </summary>
            public bool NG
            {
                get { return !OK; }
                set { OK = !value; }
            }
            /// <summary>
            /// 是否正常
            /// </summary>
            public bool OK
            { get; set; }
            /// <summary>
            /// 是否离开中
            /// </summary>
            public bool Level
            { get; set; }
            /// <summary>
            /// 是否占位测试装配中
            /// </summary>
            public bool Test
            { get; set; }
            /// <summary>
            /// 是否占位测试装配完成
            /// </summary>
            public bool TestOver
            { get; set; }
            /// <summary>
            /// 条码
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 是否闪烁
            /// </summary>
            public bool Blink
            {
                get
                {
                    return (Error || Level);
                }
            }
            /// <summary>
            /// 颜色
            /// </summary>
            public System.Drawing.Color Color
            {
                get
                {
                    if (Error)
                    {
                        return System.Drawing.Color.Purple;
                    }
                    if (!HaveMachine)
                    {
                        return System.Drawing.Color.Blue;
                    }
                    if (!OK)
                    {
                        return System.Drawing.Color.Red;
                    }
                    return System.Drawing.Color.Green;
                }
            }
            public StatueLineStation()
                : this(0)
            {
            }
            public StatueLineStation(int lineStationIndex)
            {
                LineStationIndex = lineStationIndex;
                HaveCar = false;
                Error = false;
                HaveMachine = false;
                OK = true;
                Level = false;
                Test = false;
                TestOver = true;
                BarCode = "";
            }
            /// <summary>
            /// 将读取到的小车状态转化为工位状态
            /// </summary>
            /// <param name="car"></param>
            public static StatueLineStation GetStatueFromCar(StatueCar car)
            {
                StatueLineStation ss = new StatueLineStation();
                if (car.WorkLineStation > 0)
                {
                    ss.HaveCar = true;
                }
                bool[] tmpBool = All.Class.Num.Ushort2Bool(car.S0);
                ss.LineStationIndex = car.WorkLineStation;
                ss.Error = (car.E0 > 0);
                ss.HaveMachine = tmpBool[10];
                ss.OK = !tmpBool[8];
                ss.Level = tmpBool[9];
                ss.Test = tmpBool[5];
                ss.TestOver = tmpBool[6];
                ss.BarCode = car.BarCode;

                return ss;
            }
            /// <summary>
            /// 改变工位状态，并关联改变小屏状态
            /// </summary>
            public void SetStatue(bool init,bool haveCar, bool error, bool haveMachine, bool ok, bool carLevel, bool test, bool testOver, string barcode)
            {
                if (!init && this.OK != ok && this.LineStationIndex > 0 && this.LineStationIndex < 48 && frmMain.mMain.AllCars.AllInfoLineStation[this.LineStationIndex - 1].TestStation)
                {
                    string errorText = string.Format("{0}{1}", frmMain.mMain.AllCars.AllInfoLineStation[this.LineStationIndex - 1].StationName.Trim(), (ok ? "小车输入NG" : "小车输入NG"));
                    if (ok)
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueError Values({0},'{1}','{2}',{3},'{4:yyyy-MM-dd HH:mm:ss}','true','{4:yyyy-MM-dd HH:mm:ss}','小车NG',100)",
                            0 - this.LineStationIndex, barcode, errorText, 0, DateTime.Now));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from StatueError where Barcode='{0}' and Error='{1}'", barcode, error));

                        frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueError Values({0},'{1}','{2}',{3},'{4:yyyy-MM-dd HH:mm:ss}','false','{4:yyyy-MM-dd HH:mm:ss}','小车NG',100)",
                            0 - this.LineStationIndex, barcode, errorText, 0, DateTime.Now));
                    }
                }
                this.HaveCar = haveCar;
                this.Error = error;
                this.HaveMachine = haveMachine;
                this.OK = ok;
                this.Level = carLevel;
                this.TestOver = testOver;
                this.BarCode = barcode;
                this.Test = test;
            }
        }
        #endregion
        #region//小屏状态,StatueStation
        /// <summary>
        /// 小屏状态
        /// </summary>
        public class StatueStation
        {
            /// <summary>
            /// 序号
            /// </summary>
            public int ID
            { get; set; }
            /// <summary>
            /// 小屏工位号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 小屏上的选项卡对应停车工位号
            /// </summary>
            public int LineWorkStation
            { get; set; }
            /// <summary>
            /// 小屏条码
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 工位测试时间 
            /// </summary>
            public int TestTime
            { get; set; }
            /// <summary>
            /// 订单号
            /// </summary>
            public string OrderName
            { get; set; }
            /// <summary>
            /// 机型
            /// </summary>
            public string OrderMode
            { get; set; }
            /// <summary>
            /// 机型ID
            /// </summary>
            public string ModeID
            { get; set; }
            /// <summary>
            /// 当前检测状态
            /// </summary>
            public bool TestResult
            { get; set; }
            /// <summary>
            /// 用户 名
            /// </summary>
            public string UserName
            { get; set; }
            /// <summary>
            /// 机型设置
            /// </summary>
            public HeiFeiMideaDll.ModeSet ModeSet
            { get; set; }
            /// <summary>
            /// 折弯机型
            /// </summary>
            public HeiFeiMideaDll.ModeZheWangSet ModeZheWangSet
            { get; set; }

            public delegate void BarCodeChangeHandle(int ID, int LineWorkStation, string BarCode, string Order, HeiFeiMideaDll.ModeSet ModeSet, HeiFeiMideaDll.ModeZheWangSet ModeZheWangSet);
            /// <summary>
            /// 条码改变事件 
            /// </summary>
            public event BarCodeChangeHandle BarCodeChange;
            public StatueStation(int id)
            {
                this.ID = id;
                BarCode = "";
                UserName = "";
                OrderName = "";
                OrderMode = "";
                this.ModeID = "";
                this.ModeSet = new HeiFeiMideaDll.ModeSet();
            }
            /// <summary>
            /// 将MCGS工位状态刷新过来
            /// </summary>
            public void FlushStatue(bool Init)
            {
                this.WorkStation = (int)(Math.Floor(this.ID / 3.0f)) + 1;
                switch (this.ID % 3)
                {
                    case 0:
                        this.LineWorkStation = frmMain.mMain.AllCars.AllInfoStation[this.WorkStation].TestOne;
                        break;
                    case 1:
                        this.LineWorkStation = frmMain.mMain.AllCars.AllInfoStation[this.WorkStation].TestTwo;
                        break;
                    case 2:
                        this.LineWorkStation = frmMain.mMain.AllCars.AllInfoStation[this.WorkStation].TestThree;
                        break;
                }
                if (this.LineWorkStation == 0)
                {
                    return;
                }
                string tmpBarCode = "";
                switch (this.WorkStation)
                {
                    default:
                        tmpBarCode = frmMain.mMain.AllCars.AllStatueLineStation[this.LineWorkStation - 1].BarCode;
                        break;
                    case 11:
                        Dictionary<string, string> tmpLenNingCode = All.Class.SSFile.Text2Dictionary(frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[30 + this.ID]);
                        if (tmpLenNingCode.ContainsKey("BarCode"))
                        {
                            tmpBarCode = tmpLenNingCode["BarCode"];
                        }
                        break;
                }
                switch (this.WorkStation)
                {
                    default:
                        this.TestResult = frmMain.mMain.AllCars.AllStatueLineStation[this.LineWorkStation - 1].OK;
                        this.TestTime = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[this.LineWorkStation - 1].TestTime;
                        break;
                    case 11:
                        this.TestResult = true;
                        this.TestTime = 0;
                        break;
                }
                if (this.BarCode == tmpBarCode)
                {
                    return;
                }
                if (tmpBarCode == "")
                {
                    this.BarCode = "";
                    this.OrderMode = "";
                    this.OrderName = "";
                    this.ModeID = "";
                    //this.ModeSet = new HeiFeiMideaDll.ModeSet();
                    if (BarCodeChange != null)
                    {
                        BarCodeChange(this.ID, this.WorkStation, this.BarCode, this.OrderName, null, null);
                    }
                    //CheckRootID();//清机器人ID
                    return;
                }
                this.BarCode = tmpBarCode;
                if (this.WorkStation == 11)//冷凝器上线处没有订单
                { this.OrderName = ""; }
                else
                {
                    HeiFeiMideaDll.OrderSet tmpOrder = HeiFeiMideaDll.OrderSet.GetOrder(frmMain.mMain.AllOrder, this.BarCode, this.WorkStation);
                    if (tmpOrder == null)
                    {
                        tmpOrder = HeiFeiMideaDll.OrderSet.GetOrder(this.BarCode, this.WorkStation, frmMain.mMain.AllDataXml.LocalSet.FormatBarStr, frmMain.mMain.AllDataBase.ReadData);
                    }
                    if (tmpOrder == null)
                    {
                        this.OrderName = "当前条码无订单";
                    }
                    else
                    {
                        this.OrderName = tmpOrder.OrderName;
                    }
                }
                switch (this.WorkStation)
                {
                    default:
                        ModeSet = HeiFeiMideaDll.ModeSet.GetMode(
                            HeiFeiMideaDll.ModeSet.GetModeIDFromBar(this.BarCode, frmMain.mMain.AllDataXml.LocalSet.FormatBarStr),
                            frmMain.mMain.AllDataBase.ReadData);
                        if (ModeSet == null)
                        {
                            this.OrderMode = "";
                            this.ModeID = "";
                        }
                        else
                        {
                            this.OrderMode = ModeSet.Mode;
                            this.ModeID = ModeSet.ID;
                        }
                        if (!Init)
                        {
                            CheckRootID();
                        }
                        break;
                    case 11:
                        string tmpModeID = "";
                        if (this.BarCode.Length > 12)//折弯条码组成为【型号】+8位日期+4位流水
                        {
                            tmpModeID = this.BarCode.Substring(0, this.BarCode.Length - 12);
                        }
                        ModeZheWangSet = HeiFeiMideaDll.ModeZheWangSet.GetMode(tmpModeID ,frmMain.mMain.AllDataBase.ReadData);
                        if (ModeZheWangSet == null)
                        {
                            this.OrderMode = "";
                            this.ModeID = "";
                        }
                        else
                        {
                            this.OrderMode = ModeZheWangSet.Mode;
                            this.ModeID = ModeZheWangSet.ID;
                        }
                        break;
                }
                if (BarCodeChange != null)
                {
                    BarCodeChange(this.ID, this.LineWorkStation, this.BarCode, this.OrderName, ModeSet, ModeZheWangSet);
                }
            }
            private void CheckRootID()
            {
                if (ModeSet == null)
                {
                    //frmMain.mMain.AddAllMeterInfo("当前条码没有机型设置，无法选择正确的程序号");
                    return;
                }
                if (this.LineWorkStation == 2)
                {
                    using (DataTable dt = frmMain.mMain.AllDataBase.DataBarCode.Read(string.Format("select Midea,Boss,Mode,OrderName from AllBarCode where Midea='{0}'", this.BarCode)))
                    {
                        //此处有可能将前一天晚上的数据再次保存一次，造成在报表中多一次上线，不影响，不要改
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            frmMain.mMain.AllDataBase.Write.AddInLine(1, All.Class.Num.ToString(dt.Rows[0]["Midea"]),
                                All.Class.Num.ToString(dt.Rows[0]["Boss"]),
                                All.Class.Num.ToString(dt.Rows[0]["Mode"]),
                                All.Class.Num.ToString(dt.Rows[0]["OrderName"]));
                        }
                        else
                        {
                            frmMain.mMain.AllDataBase.Write.AddInLine(1, this.BarCode, "", this.ModeSet.Mode, this.OrderName);
                        }
                    }
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.上线高度, (ushort)ModeSet.MachineID);
                }
                if (this.LineWorkStation == 4)
                {
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.机器人1程序号, (ushort)ModeSet.MachineID);
                }
                if (this.LineWorkStation == 8)
                {
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.机器人2程序号, (ushort)ModeSet.MachineID);
                }
                if (this.LineWorkStation == 16)
                {
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.机器人3程序号, (ushort)ModeSet.MachineID);
                }
                if (this.LineWorkStation == 42)
                {
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.相机程序号, (ushort)ModeSet.MachineID);
                }
            }
        }

        #endregion

        #region//字段
        /// <summary>
        /// 所有小车状态
        /// </summary>
        public StatueCar[] AllStatueCar
        { get; set; }
        /// <summary>
        /// 所有工位状态，即53工位
        /// </summary>
        public StatueLineStation[] AllStatueLineStation
        { get; set; }
        /// <summary>
        /// 所有停车工位信息,即要显示到屏上的工位，53工位，这里是原始信息
        /// </summary>
        public HeiFeiMideaDll.cDataLocal.InfoLineStation[] AllInfoLineStation
        { get; set; }
        /// <summary>
        /// 所有电脑工位信息，即11工位,这里是原始信息
        /// </summary>
        public HeiFeiMideaDll.cDataLocal.InfoStation[] AllInfoStation
        { get; set; }
        /// <summary>
        /// 所有工位信息，11工位的1，2，3位置拆开
        /// </summary>
        public StatueStation[] AllStatueStation
        { get; set; }
        /// <summary>
        /// 所有冷凝器状态
        /// </summary>
        public StatueLengNinQi AllStatueLengNinQi
        { get; set; }
        /// <summary>
        /// 其他设备状态
        /// </summary>
        public cStatueOther[] AllStatueOther
        { get; set; }
        /// <summary>
        /// 33个检测工位，数据改变事件 
        /// </summary>
        public event StatueStation.BarCodeChangeHandle BarCodeChange;
        #endregion
        public cCarLocal()
        {
            AllStatueCar = new StatueCar[HeiFeiMideaDll.cMain.AllCarCount];
            for (int i = 0; i < AllStatueCar.Length; i++)
            {
                AllStatueCar[i] = new StatueCar();
            }
            AllStatueLineStation = new StatueLineStation[HeiFeiMideaDll.cMain.AllStopStationCount];
            for (int i = 0; i < AllStatueLineStation.Length; i++)
            {
                AllStatueLineStation[i] = new StatueLineStation();
                AllStatueLineStation[i].LineStationIndex = i + 1;
            }
            AllInfoLineStation = new HeiFeiMideaDll.cDataLocal.InfoLineStation[HeiFeiMideaDll.cMain.AllStopStationCount];
            for (int i = 0; i < AllInfoLineStation.Length; i++)
            {
                AllInfoLineStation[i] = new HeiFeiMideaDll.cDataLocal.InfoLineStation();
                AllInfoLineStation[i].WorkStation = i + 1;
            }
            AllStatueStation = new StatueStation[HeiFeiMideaDll.cMain.AllComputerShowCount];
            for (int i = 0; i < AllStatueStation.Length; i++)
            {
                AllStatueStation[i] = new StatueStation(i);
                AllStatueStation[i].BarCodeChange += cCarLocal_BarCodeChange;
            }
            AllStatueOther = new cStatueOther[HeiFeiMideaDll.cMain.AllOtherMachineCount];
            for (int i = 0; i < AllStatueOther.Length; i++)
            {
                AllStatueOther[i] = new cStatueOther(i + 1);
            }
            AllStatueLengNinQi = new StatueLengNinQi();
        }

        void cCarLocal_BarCodeChange(int ID, int LineWorkStation, string BarCode, string Order, HeiFeiMideaDll.ModeSet ModeSet, HeiFeiMideaDll.ModeZheWangSet ModeZheWangSet)
        {
            if (BarCodeChange != null)
            {
                BarCodeChange(ID, LineWorkStation, BarCode, Order, ModeSet, ModeZheWangSet);
            }
        }
        /// <summary>
        /// 加载工位与停车位数据
        /// </summary>
        public void Load()
        {
            //加载停车工位信息
            List<HeiFeiMideaDll.cDataLocal.InfoLineStation> tmpInfoLineStation = frmMain.mMain.AllDataBase.Local.GetAllInfoLineStation();
            tmpInfoLineStation.ForEach(
                infoLineStation =>
                {
                    if (infoLineStation.WorkStation > 0)
                    {
                        AllInfoLineStation[infoLineStation.WorkStation - 1] = infoLineStation;
                    }
                }
            );
            //加载小屏工位信息
            AllInfoStation = frmMain.mMain.AllDataBase.Local.GetStation().ToArray();
        }
        /// <summary>
        /// 从停车工位号反算小车号，用于显示
        /// </summary>
        /// <param name="workLineStation"></param>
        /// <returns></returns>
        public StatueCar GetCarFromLineStationIndex(int workLineStation)
        {
            return AllStatueCar.ToList().Find(
                carStatue =>
                {
                    return carStatue.WorkLineStation == workLineStation;
                }
            );
        }
        ///// <summary>
        ///// 从停车工位号计算显示屏号，用于发送数据到显示屏数据
        ///// </summary>
        ///// <param name="workLineStation"></param>
        ///// <returns></returns>
        //public HeiFeiMideaDll.cDataLocal.InfoStation GetStationFromLineLineIndex(int workLineStation)
        //{
        //    return AllInfoStation.ToList().Find(
        //        infoStation =>
        //        {
        //            return infoStation.TestOne == workLineStation ||
        //                infoStation.TestTwo == workLineStation ||
        //                infoStation.TestThree == workLineStation;
        //        }
        //    );
        //}
    }
}
