using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace HeiFeiMidea
{
    /// <summary>
    /// 专写程序号
    /// </summary>
    public class cWriteRootID
    {
        public enum AllRootSpace : int
        {
            未知 = 0,
            上线条码,
            冷凝器返修条码,
            卤检条码,
            上线高度,
            风机扭矩程序号,
            风机扭矩结果,
            相机程序号,
            压缩机比对结果,
            压缩机扭矩程序号,
            冷凝器结果,
            机器人1程序号,
            机器人2程序号,
            机器人3程序号,
            冷凝器线条码1,
            冷凝器线条码2,
            报警1,
            报警2,
            报警3,
            报警4,
            报警5,
            报警6,
            报警7,
            报警8,
            报警9,
            报警10,
            报警11,
            报警12,
            报警13,
            报警14,
            报警15,
            报警16,
            报警17,
            报警18,
            报警19,
            报警20,
            压缩机扭矩枪完成信号,
            充氦回收,
            抽空抽注,
            检大漏
        }
        /// <summary>
        /// 所有数据写入位置
        /// </summary>
        RootID[] AllRootID = new RootID[38];
        object lockObject = new object();
        All.Meter.Simens1200Net plc;//主PLC
        All.Meter.NetModbusRtu plcLengNingQi;//冷凝器线PLC
        public cWriteRootID()
        {
            plc = (All.Meter.Simens1200Net)frmMain.mMain.AllMeterData.AllCommunite[1].Sons[0];
            if (plc == null)
            {
                All.Class.Error.Add("cWriteRootID.InitError,通用Meter转化为PlcMeter失败");
            }
            plcLengNingQi = (All.Meter.NetModbusRtu)frmMain.mMain.AllMeterData.AllCommunite[26].Sons[0];
            if (plcLengNingQi == null)
            {
                All.Class.Error.Add("cWriteRootID.InitError,通用Meter转化为PlcLengNingQi失败");
            }
            for (int i = 0; i < AllRootID.Length; i++)
            {
                AllRootID[i] = new RootID();
                AllRootID[i].RootSpace = (AllRootSpace)(i + 1);
            }
            new Thread(() => WriteLoop())
            {
                IsBackground = true
            }.Start();
        }

        private void WriteLoop()
        {
            while (true)
            {
                for (int i = 0; i < AllRootID.Length; i++)
                {
                    if (AllRootID[i].WriteNow)
                    {
                        lock (lockObject)
                        {
                            switch (AllRootID[i].RootSpace)
                            {
                                case AllRootSpace.上线条码:
                                case AllRootSpace.冷凝器返修条码:
                                case AllRootSpace.卤检条码:
                                    if (plc.WriteInternal<string>(AllRootID[i].BarCode, AllRootID[i].Parm))
                                    {
                                        AllRootID[i].WriteNow = false;
                                    }
                                    break;
                                case AllRootSpace.冷凝器线条码1:
                                case AllRootSpace.冷凝器线条码2:
                                    if (plcLengNingQi.WriteInternal<string>(AllRootID[i].BarCode, AllRootID[i].Parm))
                                    {
                                        AllRootID[i].WriteNow = false;
                                    }
                                    break;
                                case AllRootSpace.检大漏:
                                    if (frmMain.mMain.AllMeterData.AllCommunite[30].Sons[0].WriteInternal<string>(AllRootID[i].BarCode, AllRootID[i].Parm))
                                    {
                                        AllRootID[i].WriteNow = false;
                                    }
                                    break;
                                case AllRootSpace.充氦回收:
                                    if (frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].WriteInternal<string>(AllRootID[i].BarCode, AllRootID[i].Parm))
                                    {
                                        if (frmMain.mMain.AllMeterData.AllCommunite[31].Sons[0].WriteInternal<ushort>(1, 7))
                                        {
                                            AllRootID[i].WriteNow = false;
                                        }
                                    }
                                    break;
                                case AllRootSpace.抽空抽注:
                                    if (frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].WriteInternal<string>(AllRootID[i].BarCode, AllRootID[i].Parm))
                                    {
                                        if (frmMain.mMain.AllMeterData.AllCommunite[32].Sons[0].WriteInternal<ushort>(1, 4))
                                        {
                                            AllRootID[i].WriteNow = false;
                                        }
                                    }
                                    break;
                                case AllRootSpace.上线高度:
                                case AllRootSpace.风机扭矩程序号:
                                case AllRootSpace.风机扭矩结果:
                                case AllRootSpace.相机程序号:
                                case AllRootSpace.压缩机扭矩程序号:
                                case AllRootSpace.压缩机比对结果:
                                case AllRootSpace.冷凝器结果:
                                case AllRootSpace.机器人1程序号:
                                case AllRootSpace.机器人2程序号:
                                case AllRootSpace.机器人3程序号:
                                case AllRootSpace.报警1:
                                case AllRootSpace.报警2:
                                case AllRootSpace.报警3:
                                case AllRootSpace.报警4:
                                case AllRootSpace.报警5:
                                case AllRootSpace.报警6:
                                case AllRootSpace.报警7:
                                case AllRootSpace.报警8:
                                case AllRootSpace.报警9:
                                case AllRootSpace.报警10:
                                case AllRootSpace.报警11:
                                case AllRootSpace.报警12:
                                case AllRootSpace.报警13:
                                case AllRootSpace.报警14:
                                case AllRootSpace.报警15:
                                case AllRootSpace.报警16:
                                case AllRootSpace.报警17:
                                case AllRootSpace.报警18:
                                case AllRootSpace.报警19:
                                case AllRootSpace.报警20:
                                case AllRootSpace.压缩机扭矩枪完成信号:
                                    if (plc.WriteInternal<ushort>(AllRootID[i].Value, AllRootID[i].Parm))
                                    {
                                        AllRootID[i].WriteNow = false;
                                    }
                                    break;
                            }
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }
        public void Write(AllRootSpace space, string barCode)
        {
            if (barCode == null || barCode.Length <= 0)
            {
                return;
            }
            for (int i = 0; i < AllRootID.Length; i++)
            {
                if (AllRootID[i].RootSpace == space)
                {
                    lock (lockObject)
                    {
                        List<string> buff = new List<string>();
                        switch (space)
                        {
                            case AllRootSpace.上线条码:
                            case AllRootSpace.冷凝器返修条码:
                            case AllRootSpace.卤检条码:
                            case AllRootSpace.充氦回收:
                            case AllRootSpace.抽空抽注:
                                if (barCode.Length < 10 || barCode.Length > 30)
                                {
                                    All.Class.Error.Add(string.Format("指定的条码长度不正确，不能进行写入,当前条码为{0}", barCode));
                                    return;
                                }
                                buff.Add(barCode);
                                break;
                            case AllRootSpace.冷凝器线条码1:
                            case AllRootSpace.冷凝器线条码2:
                            case AllRootSpace.检大漏:
                                if (barCode.Length < 10 || barCode.Length > 40)
                                {
                                    All.Class.Error.Add(string.Format("指定的条码长度不正确，不能进行写入,当前条码为{0}", barCode));
                                    return;
                                }
                                buff.Add(barCode.PadRight(40, ' '));
                                break;
                            case AllRootSpace.上线高度:
                            case AllRootSpace.风机扭矩程序号:
                            case AllRootSpace.风机扭矩结果:
                            case AllRootSpace.相机程序号:
                            case AllRootSpace.压缩机扭矩程序号:
                            case AllRootSpace.压缩机比对结果:
                            case AllRootSpace.冷凝器结果:
                            case AllRootSpace.机器人1程序号:
                            case AllRootSpace.机器人2程序号:
                            case AllRootSpace.机器人3程序号:
                            case AllRootSpace.报警1:
                            case AllRootSpace.报警2:
                            case AllRootSpace.报警3:
                            case AllRootSpace.报警4:
                            case AllRootSpace.报警5:
                            case AllRootSpace.报警6:
                            case AllRootSpace.报警7:
                            case AllRootSpace.报警8:
                            case AllRootSpace.报警9:
                            case AllRootSpace.报警10:
                            case AllRootSpace.报警11:
                            case AllRootSpace.报警12:
                            case AllRootSpace.报警13:
                            case AllRootSpace.报警14:
                            case AllRootSpace.报警15:
                            case AllRootSpace.报警16:
                            case AllRootSpace.报警17:
                            case AllRootSpace.报警18:
                            case AllRootSpace.报警19:
                            case AllRootSpace.报警20:
                            case AllRootSpace.压缩机扭矩枪完成信号:
                                All.Class.Error.Add("数字不能用此方法写入");
                                return;
                        }
                        AllRootID[i].BarCode = buff;
                        AllRootID[i].WriteNow = true;
                    }
                }
            }
        }
        public void Write(AllRootSpace space, ushort ID)
        {
            for (int i = 0; i < AllRootID.Length; i++)
            {
                if (AllRootID[i].RootSpace == space)
                {
                    lock (lockObject)
                    {
                        switch (space)
                        {
                            case AllRootSpace.上线条码:
                            case AllRootSpace.冷凝器返修条码:
                            case AllRootSpace.卤检条码:
                            case AllRootSpace.冷凝器线条码1:
                            case AllRootSpace.冷凝器线条码2:
                            case AllRootSpace.检大漏:
                            case AllRootSpace.充氦回收:
                            case AllRootSpace.抽空抽注:
                                All.Class.Error.Add("条码不能用此方法写入");
                                return;
                            case AllRootSpace.上线高度:
                            case AllRootSpace.风机扭矩程序号:
                            case AllRootSpace.风机扭矩结果:
                            case AllRootSpace.相机程序号:
                            case AllRootSpace.压缩机扭矩程序号:
                            case AllRootSpace.压缩机比对结果:
                            case AllRootSpace.冷凝器结果:
                            case AllRootSpace.机器人1程序号:
                            case AllRootSpace.机器人2程序号:
                            case AllRootSpace.机器人3程序号:
                            case AllRootSpace.报警1:
                            case AllRootSpace.报警2:
                            case AllRootSpace.报警3:
                            case AllRootSpace.报警4:
                            case AllRootSpace.报警5:
                            case AllRootSpace.报警6:
                            case AllRootSpace.报警7:
                            case AllRootSpace.报警8:
                            case AllRootSpace.报警9:
                            case AllRootSpace.报警10:
                            case AllRootSpace.报警11:
                            case AllRootSpace.报警12:
                            case AllRootSpace.报警13:
                            case AllRootSpace.报警14:
                            case AllRootSpace.报警15:
                            case AllRootSpace.报警16:
                            case AllRootSpace.报警17:
                            case AllRootSpace.报警18:
                            case AllRootSpace.报警19:
                            case AllRootSpace.报警20:
                            case AllRootSpace.压缩机扭矩枪完成信号:
                                break;
                        }
                        List<ushort> buff = new List<ushort>();
                        buff.Add(ID);
                        AllRootID[i].Value = buff;
                        AllRootID[i].WriteNow = true;
                    }
                    break;
                }
            }
        }
        public class RootID
        {
            AllRootSpace rootSpace = AllRootSpace.未知;

            public AllRootSpace RootSpace
            {
                get { return rootSpace; }
                set
                {
                    Init(value);
                    rootSpace = value;
                }
            }
            public bool WriteNow
            { get; set; }
            public Dictionary<string, string> Parm
            { get; set; }
            public List<ushort> Value
            { get; set; }
            public List<string> BarCode
            { get; set; }
            public RootID()
            {
                WriteNow = false;
                this.Parm = new Dictionary<string, string>();
                Value = new List<ushort>();
                BarCode = new List<string>();
            }
            private void Init(AllRootSpace value)
            {
                int start = 0;
                switch (value)
                {
                    case AllRootSpace.上线条码:
                        start = 0;
                        break;
                    case AllRootSpace.冷凝器返修条码:
                        start = 30;
                        break;
                    case AllRootSpace.卤检条码:
                        start = 60;
                        break;
                    case AllRootSpace.上线高度:
                        start = 530;
                        break;
                    case AllRootSpace.风机扭矩程序号:
                        start = 774;
                        break;
                    case AllRootSpace.风机扭矩结果:
                        start = 776;
                        break;
                    case AllRootSpace.相机程序号:
                        start = 778;
                        break;
                    case AllRootSpace.压缩机扭矩程序号:
                        start = 784;
                        break;
                    case AllRootSpace.压缩机比对结果:
                        start = 782;
                        break;
                    case AllRootSpace.冷凝器结果:
                        start = 786;
                        break;
                    case AllRootSpace.机器人1程序号:
                        start = 788;
                        break;
                    case AllRootSpace.机器人2程序号:
                        start = 790;
                        break;
                    case AllRootSpace.机器人3程序号:
                        start = 792;
                        break;
                    case AllRootSpace.冷凝器线条码1:
                        start = 0;//直接写冷凝器PLC
                        break;
                    case AllRootSpace.冷凝器线条码2:
                        start = 60;//直接定冷凝器PLC
                        break;
                    case AllRootSpace.报警1:
                        start = 874;
                        break;
                    case AllRootSpace.报警2:
                        start = 876;
                        break;
                    case AllRootSpace.报警3:
                        start = 878;
                        break;
                    case AllRootSpace.报警4:
                        start = 880;
                        break;
                    case AllRootSpace.报警5:
                        start = 882;
                        break;
                    case AllRootSpace.报警6:
                        start = 884;
                        break;
                    case AllRootSpace.报警7:
                        start = 886;
                        break;
                    case AllRootSpace.报警8:
                        start = 888;
                        break;
                    case AllRootSpace.报警9:
                        start = 890;
                        break;
                    case AllRootSpace.报警10:
                        start = 892;
                        break;
                    case AllRootSpace.报警11:
                        start = 894;
                        break;
                    case AllRootSpace.报警12:
                        start = 896;
                        break;
                    case AllRootSpace.报警13:
                        start = 898;
                        break;
                    case AllRootSpace.报警14:
                        start = 900;
                        break;
                    case AllRootSpace.报警15:
                        start = 902;
                        break;
                    case AllRootSpace.报警16:
                        start = 904;
                        break;
                    case AllRootSpace.报警17:
                        start = 906;
                        break;
                    case AllRootSpace.报警18:
                        start = 908;
                        break;
                    case AllRootSpace.报警19:
                        start = 910;
                        break;
                    case AllRootSpace.报警20:
                        start = 912;
                        break;
                    case AllRootSpace.压缩机扭矩枪完成信号:
                        start = 914;
                        break;
                    case AllRootSpace.充氦回收:
                        start = 104;
                        break;
                    case AllRootSpace.抽空抽注:
                        start = 40;
                        break;
                    case AllRootSpace.检大漏:
                        start = 104;
                        break;
                }
                this.Parm.Add("Start", string.Format("{0}", (int)start));
                this.Parm.Add("End", string.Format("{0}", (int)start));
                this.Parm.Add("Block", "100");
            }
        }
    }
}
