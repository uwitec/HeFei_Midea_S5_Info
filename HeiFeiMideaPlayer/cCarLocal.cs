using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class cCarLocal
    {
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
            public StatueStation(int id)
            {
                this.ID = id;
                BarCode = "";
                UserName = "";
                OrderName = "";
                OrderMode = "";
                this.TestResult = true;
                this.TestTime = 0;
            }
        }

        /// <summary>
        /// 本机数据
        /// </summary>
        public StatueStation[] AllStatueStation
        { get; set; }
        public HeiFeiMideaDll.ModeSet[] ModeSet
        { get; set; }
        public int[] FengJiNowID
        { get; set; }
        public HeiFeiMideaDll.ModeZheWangSet ModeZheWangSet
        { get; set; }
        public HeiFeiMideaDll.cNiuJu[] NiuJu
        { get; set; }
        /// <summary>
        /// 机型改变，要改变播放
        /// </summary>
        public bool ModeIDChangeOne
        { get; set; }
        public bool ModeIDChangeTwo
        { get; set; }


        string oldBarCodeOne = "";
        string oldBarCodeTwo = "";

        public delegate void GetOrderFromChangeBarHandle(StatueStation statueStation,HeiFeiMideaDll.ModeSet modeSet);
        /// <summary>
        /// 条码改变时切换订单，影像专用
        /// </summary>
        //public event GetOrderFromChangeBarHandle GetOrderFromChangeBar;
        public cCarLocal()
        {
            ModeIDChangeOne = false;
            ModeIDChangeTwo = false;

            AllStatueStation = new StatueStation[3];
            for (int i = 0; i < AllStatueStation.Length; i++)
            {
                AllStatueStation[i] = new StatueStation(frmMain.mMain.AllDataXml.LocalSettings.TestNo * 3 - 3 + i);
            }
            switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
            {
                case 11:
                    ModeZheWangSet = new HeiFeiMideaDll.ModeZheWangSet();
                    break;
                default:
                    ModeSet = new HeiFeiMideaDll.ModeSet[3];
                    for (int i = 0; i < ModeSet.Length; i++)
                    {
                        ModeSet[i] = new HeiFeiMideaDll.ModeSet();
                    }
                    break;
            }
            NiuJu = new HeiFeiMideaDll.cNiuJu[3];
            for (int i = 0; i < NiuJu.Length; i++)
            {
                NiuJu[i] = new HeiFeiMideaDll.cNiuJu();
            }
            FengJiNowID = new int[3];
            for (int i = 0; i < FengJiNowID.Length; i++)
            {
                FengJiNowID[i] = 0;
            }
        }
        public void Flush(All.Class.DataReadAndWrite data)
        {
            //读取工位数据
            using (DataTable dt = data.Read(string.Format("select * from StatueStation where WorkStation={0} order by ID", frmMain.mMain.AllDataXml.LocalSettings.TestNo)))
            {
                if (dt != null && dt.Rows.Count == AllStatueStation.Length)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AllStatueStation[i].BarCode = All.Class.Num.ToString(dt.Rows[i]["BarCode"]);
                        AllStatueStation[i].OrderName = All.Class.Num.ToString(dt.Rows[i]["OrderName"]);
                        AllStatueStation[i].TestTime = All.Class.Num.ToInt(dt.Rows[i]["TestTime"]);
                        AllStatueStation[i].TestResult = All.Class.Num.ToBool(dt.Rows[i]["TestResult"]);
                        AllStatueStation[i].UserName = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                        AllStatueStation[i].ModeID = All.Class.Num.ToString(dt.Rows[i]["ModeID"]);
                    }
                }
            }
            //第一工位状态
            if (AllStatueStation.Length > 0)
            {
                if (AllStatueStation[0].ModeID != null  && AllStatueStation[0].BarCode != oldBarCodeOne)
                {
                    switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
                    {
                        case 11:
                            ModeZheWangSet = HeiFeiMideaDll.ModeZheWangSet.GetMode(AllStatueStation[0].ModeID, frmMain.mMain.AllDataBase.FlushData);
                            break;
                        default:
                            ModeSet[0] = HeiFeiMideaDll.ModeSet.GetMode(AllStatueStation[0].ModeID, frmMain.mMain.AllDataBase.FlushData);
                            FengJiNowID[0] = 0;
                            if (ModeSet != null && frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2)//扭矩1号
                            {
                                NiuJu[0] = HeiFeiMideaDll.cNiuJu.Read(true, false, ModeSet[0].NiuJuIDOne, data);
                            }
                            if (ModeSet != null && frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
                            {
                                NiuJu[0] = HeiFeiMideaDll.cNiuJu.Read(false, true, ModeSet[0].NiuJuIDTwo, data);
                            }
                               if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 9)//清除影像检图像
                            {
                                if (System.IO.Directory.Exists(frmMain.mMain.AllDataXml.LocalSettings.YinXiangFile))
                                {
                                    try
                                    {
                                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(frmMain.mMain.AllDataXml.LocalSettings.YinXiangFile);
                                        foreach (System.IO.FileInfo fi in di.GetFiles())
                                        {
                                            fi.Delete();
                                        }
                                    }
                                    catch { }
                                }
                            }
                            break;
                    }
                    ModeIDChangeOne = true;
                }
                oldBarCodeOne = AllStatueStation[0].BarCode;
            }
            if (AllStatueStation.Length > 1)
            {
                if (AllStatueStation[1].ModeID != null  && AllStatueStation[1].BarCode !=oldBarCodeTwo)
                {
                    switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
                    {
                        case 2://机器人上压缩机处，要机器人程序号
                            ModeSet[1] = HeiFeiMideaDll.ModeSet.GetMode(AllStatueStation[1].ModeID, frmMain.mMain.AllDataBase.FlushData);
                            break;
                        case 7://风机处
                            FengJiNowID[1] = 0;
                            ModeSet[1] = HeiFeiMideaDll.ModeSet.GetMode(AllStatueStation[1].ModeID, frmMain.mMain.AllDataBase.FlushData);
                            if (ModeSet != null)
                            {
                                NiuJu[1] = HeiFeiMideaDll.cNiuJu.Read(false, true, ModeSet[1].NiuJuIDTwo, data);
                            }
                            break;
                        case 9://标贴处，用于打印
                            frmMain.mMain.AiWrite.PrintBar(AllStatueStation[1].BarCode,HeiFeiMideaDll.cMain.AllComputerList.影像检);
                            break;
                    }
                    ModeIDChangeTwo = true;
                }
                oldBarCodeTwo = AllStatueStation[1].BarCode;
            }
        }
    }
}
