using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class cDataXml
    {
        public static string XMLDirectory = string.Format("{0}\\Data\\XML\\", All.Class.FileIO.GetNowPath());
        /// <summary>
        /// 本地数据文件
        /// </summary>
        public LocalSetting LocalSettings
        { get; set; }
        /// <summary>
        /// 本地折弯数据
        /// </summary>
        public LocalZheWang LocalZheWangs
        { get; set; }
        /// <summary>
        /// 博世数据
        /// </summary>
        public LocalBoShi LocalBoShis
        { get; set; }
        /// <summary>
        /// 美的转博世转换关系
        /// </summary>
        public MideaToBoShi Midea2BoShi
        { get; set; }
        public cDataXml()
        {
            if (!System.IO.Directory.Exists(XMLDirectory))
            {
                System.IO.Directory.CreateDirectory(XMLDirectory);
            }
            LocalSettings = new LocalSetting();
            LocalZheWangs = new LocalZheWang();
            LocalBoShis = new LocalBoShi();
            Midea2BoShi = new MideaToBoShi();
        }
        public void Load()
        {
            All.Class.Error.DelMoreError(DateTime.Now.AddDays(-5));
            All.Class.Log.DelMoreLog(DateTime.Now.AddDays(-5));
            LocalSettings.Load();
            LocalZheWangs.Load();
            LocalBoShis.Load();
            Midea2BoShi.Load();
        }
        #region//每天折弯机计数
        /// <summary>
        /// 本地折弯数据
        /// </summary>
        public class LocalZheWang
        {
            string fileName = "";
            public DateTime TodayStart
            { get; set; }
            public int ZheWangIndex
            { get; set; }
            object lockObject = new object();
            public LocalZheWang()
            {
                fileName = string.Format("{0}\\LocalZheWang.txt", XMLDirectory);
                DateTime now = DateTime.Now.AddHours(-5);
                TodayStart = DateTime.Parse(string.Format("{0:yyyy-MM-dd }05:00:00", now));
            }
            public void Load()
            {
                if (System.IO.File.Exists(fileName))
                {
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(fileName));
                    if (buff.ContainsKey("ZheWangIndex"))
                        ZheWangIndex = All.Class.Num.ToInt(buff["ZheWangIndex"]);
                    if (buff.ContainsKey("TodayStart"))
                    {
                        DateTime tmp = All.Class.Num.ToDateTime(buff["TodayStart"]);
                        TimeSpan ts = TodayStart - tmp;
                        if (ts.TotalHours >= 24)
                        {
                            ZheWangIndex = 0;
                        }
                    }
                }
                Save();
            }
            public void Save()
            {
                lock (lockObject)
                {
                    Dictionary<string, string> buff = new Dictionary<string, string>();
                    buff.Add("TodayStart", string.Format("{0:yyyy-MM-dd HH:mm:ss}", TodayStart));
                    buff.Add("ZheWangIndex", this.ZheWangIndex.ToString());
                    All.Class.FileIO.Write(fileName, All.Class.SSFile.Dictionary2Text(buff), System.IO.FileMode.Create);
                }
            }
        }
        #endregion
        #region//美的机型转博世机型
        #endregion
        #region//博世的每月下标计数
        /// <summary>
        /// 博世每月生产计数
        /// </summary>
        public class LocalBoShi
        {
            string directory = "";
            string fileName = "";

            object lockObject = new object();
            public LocalBoShi()
            {
                fileName = string.Format("{0}\\LocalBoShi.txt", XMLDirectory);
                directory = string.Format("{0}\\BoShiIndex\\", XMLDirectory);
            }
            /// <summary>
            /// 加载指定值
            /// </summary>
            public void Load()
            {
                if (!System.IO.File.Exists(fileName))
                {
                    Dictionary<string, string> AllIndex = new Dictionary<string, string>();
                    for (int i = 2010; i < 2040; i++)
                    {
                        for (int j = 1; j < 12; j++)
                        {
                            AllIndex.Add(string.Format("{0:D4}-{1:D2}", i, j), "1");
                        }
                    }
                    All.Class.FileIO.Write(fileName, All.Class.SSFile.Dictionary2Text(AllIndex), System.IO.FileMode.Create);
                }
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
            /// <summary>
            /// 给指定日期添加一条记录
            /// </summary>
            /// <param name="time"></param>
            public void Add(DateTime time, string boshiID)
            {
                string tmpFileName = string.Format("{0}\\{1}.txt", directory, boshiID);
                if (!System.IO.File.Exists(tmpFileName))
                {
                    System.IO.File.Copy(fileName, tmpFileName);
                }
                Dictionary<string, string> AllIndex = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(tmpFileName));
                string key = string.Format("{0:yyyy}-{0:MM}",time);
                AllIndex[key] = string.Format("{0}", All.Class.Num.ToInt(AllIndex[key]) + 1);
                All.Class.FileIO.Write(tmpFileName, All.Class.SSFile.Dictionary2Text(AllIndex),System.IO.FileMode.Create);
            }
            /// <summary>
            /// 从指定日期找到对应的记录
            /// </summary>
            /// <param name="time"></param>
            /// <param name="boshiID">博世机型</param>
            /// <returns></returns>
            public int GetIndex(DateTime time,string boshiID)
            {
                string tmpFileName = string.Format("{0}\\{1}.txt", directory, boshiID);
                if (!System.IO.File.Exists(tmpFileName))
                {
                    System.IO.File.Copy(fileName, tmpFileName);
                }
                Dictionary<string, string> AllIndex = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(tmpFileName));
                return All.Class.Num.ToInt(AllIndex[string.Format("{0:yyyy}-{0:MM}", time)]);
            }
        }
        #endregion
        /// <summary>
        /// 本地设置
        /// </summary>
        public class LocalSetting
        {
            string fileName = "";
            /// <summary>
            /// 本地IP
            /// </summary>
            public string IpAddress
            { get; set; }
            /// <summary>
            /// 本地序号
            /// </summary>
            public int TestNo
            { get; set; }
            /// <summary>
            /// 打印机名称
            /// </summary>
            public string PrintName
            { get; set; }
            /// <summary>
            /// 影像文件夹
            /// </summary>
            public string YinXiangFile
            { get; set; }
            object lockObject = new object();
            public LocalSetting()
            {
                fileName = string.Format("{0}\\LocalSetting.txt", XMLDirectory);
                IpAddress = All.Class.HardInfo.GetIpAddress("192.168.1");
                if (IpAddress != "")
                {
                    TestNo = (All.Class.Num.ToInt(IpAddress.Split('.')[3]) % 100);
                }
                PrintName = "ZDesigner 105SLPlus-300dpi ZPL";
                YinXiangFile = "E:\\Photo\\";
            }
            /// <summary>
            /// 加载本地数据
            /// </summary>
            public void Load()
            {
                if (System.IO.File.Exists(fileName))
                {
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(fileName));
                    if (buff.ContainsKey("IpAddress"))
                    {
                        this.IpAddress = buff["IpAddress"];
                    }
                    if (buff.ContainsKey("TestNo"))
                    {
                        this.TestNo = All.Class.Num.ToInt(buff["TestNo"]);
                    }
                    if (buff.ContainsKey("PrintName"))
                    {
                        this.PrintName = buff["PrintName"];
                    }
                    if (buff.ContainsKey("YinXiangFile"))
                        this.YinXiangFile = buff["YinXiangFile"];
                    All.Class.FileIO.CheckFileDirectory(this.YinXiangFile);

                }
                Save();
            }
            /// <summary>
            /// 保存本地数据
            /// </summary>
            public void Save()
            {
                lock (lockObject)
                {
                    Dictionary<string, string> buff = new Dictionary<string, string>();
                    buff.Add("IpAddress", IpAddress);
                    buff.Add("TestNo", TestNo.ToString());
                    buff.Add("PrintName", this.PrintName);
                    buff.Add("YinXiangFile", this.YinXiangFile);
                    All.Class.FileIO.Write(fileName, All.Class.SSFile.Dictionary2Text(buff), System.IO.FileMode.Create);
                }
            }
        }
    }
}
