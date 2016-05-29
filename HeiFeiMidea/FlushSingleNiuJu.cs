using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新 压缩机处和风机处扭矩枪状态
    /// </summary>
    public class FlushSingleNiuJu:All.Class.FlushAll.FlushMethor
    {
        int startTime = 0;
        CheckFengJiNiuJu fengJiNiuJu = new CheckFengJiNiuJu();
        YaSuoJiNiuJu yaSuoJiNiuJu = new YaSuoJiNiuJu();
        public override void Load()
        {
            frmMain.mMain.AllCars.BarCodeChange += AllCars_BarCodeChange;
        }
        public override void Flush()
        {
            //bool[] tmpBool;
            startTime = Environment.TickCount;
            using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read("select LuoSi as AllCount,Space from StatueNiuJu order by Space"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    int index = 0;
                    int count = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        index = All.Class.Num.ToInt(dt.Rows[i]["Space"]);
                        count = All.Class.Num.ToInt(dt.Rows[i]["AllCount"]);
                        switch (index)
                        {
                            case 0:
                                yaSuoJiNiuJu.Flush(index, count);
                                break;
                            case 1:
                            case 2:
                                fengJiNiuJu.Flush(index, count);
                                break;
                        }
                    }
                }
            }
            if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[195] > 0)//下去之后
            {
                fengJiNiuJu.Run();
            }
            else
            {
                fengJiNiuJu.Stop();
            }
            if (fengJiNiuJu.Statue)
            {
                fengJiNiuJu.SetStatue(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194]);
                //tmpBool = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194]);
                //fengJiNiuJu.SetStatue(tmpBool[0]);
            }
            if (yaSuoJiNiuJu.Statue)
            {
                yaSuoJiNiuJu.SetStatue(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[167]);
               // tmpBool = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[168]);
               // yaSuoJiNiuJu.SetStatue(tmpBool[0]);
            }
            if ((Environment.TickCount - startTime) > 1000)
            {
                All.Class.Log.Add("刷新扭矩枪时间过长");
            }
            //Dictionary<string, string> parm;
            //bool[] tmp;
            ////压缩机处扭矩枪
            //if (AllNiuJu[0].Change)//条码改变后，将扭矩数据发送到PLC
            //{
            //    AllNiuJu[0].Change = false;
            //    if (AllNiuJu[0].ModeSet != null && AllNiuJu[0].ModeSet.ID != "")
            //    {
            //        frmMain.mMain.AllDataBase.WriteData.Write("delete from StatueNiuJu Where Space=0");
            //        frmMain.mMain.AllMeterData.AllCommunite[27].Sons[0].Write<ushort>((ushort)AllNiuJu[0].ModeSet.NiuJuIDOne, 10);
            //    }
            //}
            //if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[193] > 0)
            //{
            //    tmp = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[193]);
            //    if (tmp[0] && !AllNiuJu[0].OK)//OK
            //    {
            //        frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values ('true',0)");
            //    }
            //    if (tmp[4] && !AllNiuJu[0].NG)
            //    {
            //        AddErrorSpace("压缩机");
            //    }
            //    AllNiuJu[0].OK = tmp[0];
            //    AllNiuJu[0].NG = tmp[4];
            //}
            //if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[195] > 0)//下除之后
            //{
            //    if (AllNiuJu[1].Change)
            //    {
            //        AllNiuJu[1].Change = false;
            //        if (AllNiuJu[1].ModeSet != null && AllNiuJu[1].ModeSet.ID != "")
            //        {
            //            frmMain.mMain.AllDataBase.WriteData.Write("delete from StatueNiuJu where Space =1");
            //            parm = new Dictionary<string, string>();
            //            parm.Add("Start", "774");
            //            parm.Add("End", "774");
            //            parm.Add("Block", "100");
            //            frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>((new ushort[] { (ushort)AllNiuJu[1].ModeSet.NiuJuIDTwo }).ToList(), parm);
            //        }
            //    }
            //    if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194] > 0)
            //    {
            //        tmp = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194]);
            //        if (tmp[0])
            //        {
            //            frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values ('true',1)");
            //        }
            //        if (tmp[4])
            //        {
            //            AddErrorSpace("风机");
            //        }
            //    }
            //}
            //if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[195] == 2)
            //{
            //    if (AllNiuJu[2].Change)
            //    {
            //        AllNiuJu[2].Change = false;
            //        if (AllNiuJu[2].ModeSet != null && AllNiuJu[2].ModeSet.ID != "")
            //        {
            //            frmMain.mMain.AllDataBase.WriteData.Write("delete from StatueNiuJu where Space =2");
            //            parm = new Dictionary<string, string>();
            //            parm.Add("Start", "774");
            //            parm.Add("End", "774");
            //            parm.Add("Block", "100");
            //            frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>((new ushort[] { (ushort)AllNiuJu[1].ModeSet.NiuJuIDTwo }).ToList(), parm);
            //        }
            //    }
            //    if (frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194] > 0)
            //    {
            //        tmp = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[194]);
            //        if (tmp[0])
            //        {
            //            frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values ('true',2)");
            //        }
            //        if (tmp[4])
            //        {
            //            AddErrorSpace("风机");
            //        }
            //    }
            //}
        }
        //private void AddErrorSpace(string space)
        //{
        //    frmMain.mMain.AddAllMeterInfo(string.Format("{0:HH:mm:ss}  {1}扭矩枪 打螺丝故障", DateTime.Now, space));
        //}

        private void AllCars_BarCodeChange(int ID, int LineWorkStation, string BarCode, string Order, HeiFeiMideaDll.ModeSet ModeSet, HeiFeiMideaDll.ModeZheWangSet ModeZheWangSet)
        {
            if (ModeSet == null || BarCode == "")
            {
                return;
            }
            switch (LineWorkStation)
            {
                case 6:
                    yaSuoJiNiuJu.ModeSet = ModeSet;
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu set LuoSi=0 where Space=0"));
                    yaSuoJiNiuJu.Run();
                    break;
                case 26:
                    fengJiNiuJu.ModeSet[0] = ModeSet;
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu set LuoSi=0 where Space=1"));
                    break;
                case 27:
                    fengJiNiuJu.ModeSet[1] = ModeSet;
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu set LuoSi=0 where Space=2"));
                    break;
            }
        }
        public class YaSuoJiNiuJu
        {
            public HeiFeiMideaDll.cNiuJu NiuJuSet
            { get; set; }
            public HeiFeiMideaDll.ModeSet ModeSet
            { get; set; }
            /// <summary>
            /// 扭矩枪是否完成一次OK
            /// </summary>
            public bool OK
            { get; set; }
            /// <summary>
            /// 是否开始检测扭矩枪状态
            /// </summary>
            public bool Statue
            { get; set; }
            /// <summary>
            /// 写入完成数量
            /// </summary>
            /// <param name="value"></param>
            public void SetStatue(ushort value)
            {
                frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu Set LuoSi= {0} where Space=0",value));

            }
            /// <summary>
            /// 写入完成数量
            /// </summary>
            /// <param name="value"></param>
            public void SetStatue(bool value)
            {
                if (value && !OK)
                {
                    frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values (0,0)");
                }
                OK = value;
            }
            /// <summary>
            /// 循环检测完成状态
            /// </summary>
            /// <param name="index"></param>
            /// <param name="count"></param>
            public void Flush(int index, int count)
            {
                if (!Statue)
                {
                    return;
                }
                if (count == NiuJuSet.Sons.Count)
                {
                    Statue = false;
                    //发送完成号
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.压缩机扭矩枪完成信号, 1);
                    //Dictionary<string, string> parm = new Dictionary<string, string>();
                    //parm.Add("Start", "786");
                    //parm.Add("End", "786");
                    //parm.Add("Block", "100");
                    //ushort[] sendValue = new ushort[1];
                    //sendValue[0] = 1;
                    //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                }
            }
           /// <summary>
           /// 初始化
           /// </summary>
            public void Run()
            {
                NiuJuSet = HeiFeiMideaDll.cNiuJu.Read(true, false, ModeSet.NiuJuIDOne, frmMain.mMain.AllDataBase.WriteData);
                Statue = true;
                //写入PLC程序号，位置没定
                //Dictionary<string, string> parm = new Dictionary<string, string>();
                //parm.Add("Start", "784");
                //parm.Add("End", "784");
                //parm.Add("Block", "100");
                //ushort[] sendValue = new ushort[1];
                //sendValue[0] = (ushort)ModeSet.NiuJuIDOne;
                //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.压缩机扭矩程序号, (ushort)ModeSet.NiuJuIDOne);
            }
        }
        public class CheckFengJiNiuJu
        {
            enum RunList
            {
                One,
                Two,
                Stop
            }
            RunList runList = RunList.Stop;
            /// <summary>
            /// 当前是否下降测试状态
            /// </summary>
            public bool Statue
            { get; set; }
            /// <summary>
            /// 扭矩对应机型 
            /// </summary>
            public HeiFeiMideaDll.ModeSet[] ModeSet
            { get; set; }
           /// <summary>
           /// 扭矩设置
           /// </summary>
            public HeiFeiMideaDll.cNiuJu[] NiuJuSet;
            /// <summary>
            /// 扭矩完成状态
            /// </summary>
            public bool[] Over
            { get; set; }
            /// <summary>
            /// 扭矩开始状态
            /// </summary>
            public bool[] Start
            { get; set; }
            /// <summary>
            /// 扭矩枪实时的OK状态
            /// </summary>
            public bool Ok
            { get; set; }
            public CheckFengJiNiuJu()
            {
                Statue = false;
                ModeSet = new HeiFeiMideaDll.ModeSet[2];
                ModeSet[0] = new HeiFeiMideaDll.ModeSet();
                ModeSet[1] = new HeiFeiMideaDll.ModeSet();
                NiuJuSet = new HeiFeiMideaDll.cNiuJu[2];
                NiuJuSet[0] = new HeiFeiMideaDll.cNiuJu();
                NiuJuSet[1] = new HeiFeiMideaDll.cNiuJu();
                Over = new bool[2];
                Over[0] = frmMain.mMain.AllDataXml.LocalSingleFlush.OverFirstNiuJu;
                Over[1] = frmMain.mMain.AllDataXml.LocalSingleFlush.OverSecondNiuJu;
                Start = new bool[2];
                Start[0] = false;
                Start[1] = false;
            }
            /// <summary>
            /// 打螺丝前初始化
            /// </summary>
            public void Run()
            {
                if (Statue)
                {
                    return;
                }
                Statue = true;
                Start[0] = false;
                Start[1] = false;
                if (!Over[0])
                {
                    Start[0] = true;
                }
                if (!Over[1])
                {
                    Start[1] = true;
                }
                CheckNum();
            }
            public void Stop()
            {
                if (!Statue)
                {
                    return;
                }
                Over[0] = false;
                Over[1] = false;
                Start[0] = false;
                Start[1] = false;
                frmMain.mMain.AllDataXml.LocalSingleFlush.OverFirstNiuJu = false;
                frmMain.mMain.AllDataXml.LocalSingleFlush.OverSecondNiuJu = false;
                frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                Statue = false;
            }
            /// <summary>
            /// 检查台子上的数量，先打26号位置的，再打27号位置的
            /// </summary>
            private void CheckNum()
            {
                runList = RunList.Stop;
                //检查先测哪一台
                if (frmMain.mMain.AllCars.AllStatueLineStation[25].HaveCar && !Over[0] && ModeSet[0] != null)
                {
                    runList = RunList.One;
                    NiuJuSet[0] = HeiFeiMideaDll.cNiuJu.Read(false, true, ModeSet[0].NiuJuIDTwo, frmMain.mMain.AllDataBase.WriteData);
                }
                else if (frmMain.mMain.AllCars.AllStatueLineStation[26].HaveCar && Over[1] && ModeSet[1] != null)
                {
                    runList = RunList.Two;
                    NiuJuSet[1] = HeiFeiMideaDll.cNiuJu.Read(false, true, ModeSet[1].NiuJuIDTwo, frmMain.mMain.AllDataBase.WriteData);
                }
                //发送程序号
                Dictionary<string, string> parm = new Dictionary<string, string>();
                //parm.Add("Start", "774");
                //parm.Add("End", "774");
                //parm.Add("Block", "100");
                //ushort[] sendValue = new ushort[1];
                switch (runList)
                {
                    case RunList.Stop:
                        return;
                    case RunList.One:
                        Start[0] = true;
                        //sendValue[0] = (ushort)ModeSet[0].NiuJuIDTwo;
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.风机扭矩程序号, (ushort)ModeSet[0].NiuJuIDTwo);
                        break;
                    case RunList.Two:
                        Start[1] = true;
                        //sendValue[0] = (ushort)ModeSet[1].NiuJuIDTwo;
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.风机扭矩程序号, (ushort)ModeSet[1].NiuJuIDTwo);
                        break;
                }
                //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
            }
            /// <summary>
            /// 写入完成数量
            /// </summary>
            /// <param name="value"></param>
            public void SetStatue(ushort value)
            {
                if (Start[0] && !Over[0])
                {
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu set luosi={0} where space=1",value));
                    return;
                }
                if (Start[1] && !Over[1])
                {
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueNiuJu set luosi={0} where space=2", value));
                    return;
                }
            }
            /// <summary>
            /// 写入完成状态
            /// </summary>
            /// <param name="value"></param>
            public void SetStatue(bool value)
            {
                if (value && !Ok)
                {
                    if (Start[0] && !Over[0])
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values (0,1)");
                        Ok = value;
                        return;
                    }
                    if (Start[1] && !Over[1])
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write("insert into StatueNiuJu (LuoSi,Space) values (0,2)");
                        Ok = value;
                        return;
                    }
                }
                Ok = value;
            }
            /// <summary>
            /// 循环检测是否打螺丝完成
            /// </summary>
            /// <param name="index"></param>
            /// <param name="count"></param>
            public void Flush(int index,int count)
            {
                if (!Statue)
                {
                    return;
                }
                switch (index)
                {
                    case 1:
                        if (count == NiuJuSet[0].Sons.Count)
                        {
                            if (!Over[0])
                            {
                                Over[0] = true;
                                frmMain.mMain.AllDataXml.LocalSingleFlush.OverFirstNiuJu = true;
                                frmMain.mMain.AllDataXml.LocalSingleFlush.Save();

                                //发送完成号
                                frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.风机扭矩结果, 1);
                                //Dictionary<string, string> parm = new Dictionary<string, string>();
                                //parm.Add("Start", "776");
                                //parm.Add("End", "776");
                                //parm.Add("Block", "100");
                                //ushort[] sendValue = new ushort[1];
                                //sendValue[0] = 1;
                                //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                            }
                            if (!Start[1])
                            {
                                CheckNum();
                            }
                        }
                        break;
                    case 2:
                        if (count == NiuJuSet[1].Sons.Count)
                        {
                            if (!Over[1])
                            {
                                Over[1] = true;
                                frmMain.mMain.AllDataXml.LocalSingleFlush.OverSecondNiuJu = true;
                                frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                                //发送完成信号
                                frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.风机扭矩结果, 1);
                                //Dictionary<string, string> parm = new Dictionary<string, string>();
                                //parm.Add("Start", "776");
                                //parm.Add("End", "776");
                                //parm.Add("Block", "100");
                                //ushort[] sendValue = new ushort[1];
                                //sendValue[0] = 1;
                                //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                           
                            }
                        }
                        break;
                }
            }
        }
    }
}
