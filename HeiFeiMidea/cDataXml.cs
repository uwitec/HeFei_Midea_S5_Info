using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class cDataXml
    {
        public static string XMLDirectory = string.Format("{0}\\Data\\XML\\", All.Class.FileIO.GetNowPath());
        /// <summary>
        /// 所有播放设置
        /// </summary>
        public PlaySets AllPlaySet
        { get; set; }
        /// <summary>
        /// 本地设置
        /// </summary>
        public LocalSets LocalSet
        { get; set; }
        /// <summary>
        /// 单机设备最后刷新数据 ID
        /// </summary>
        public LocalSingleFlushID LocalSingleFlush
        { get; set; }
        public cDataXml()
        {
            if (!System.IO.Directory.Exists(XMLDirectory))
            {
                System.IO.Directory.CreateDirectory(XMLDirectory);
            }
            AllPlaySet = new PlaySets();
            LocalSet = new LocalSets();
            LocalSingleFlush = new LocalSingleFlushID();
        }
        public void Load()
        {
            All.Class.Error.DelMoreError(DateTime.Now.AddDays(-5));
            All.Class.Log.DelMoreLog(DateTime.Now.AddDays(-5));
            AllPlaySet.Load();
            LocalSet.Load();
            LocalSingleFlush.Load();
        }
        /// <summary>
        /// 单机设备刷新ID
        /// </summary>
        public class LocalSingleFlushID
        {
            const string FileName = "单机刷新.txt";
            /// <summary>
            /// 注油机最后刷新数据
            /// </summary>
            public int OilIndex
            { get; set; }
            /// <summary>
            /// 检测最后刷新数据
            /// </summary>
            public int TestIndex
            { get; set; }
            /// <summary>
            /// 安规最后刷新数据
            /// </summary>
            public int AnGuiIndex
            { get; set; }
            /// <summary>
            /// 故障最后刷新
            /// </summary>
            public int ErrorIndex
            { get; set; }
            /// <summary>
            /// 物料呼叫最后刷新
            /// </summary>
            public int MaterialIndex
            { get; set; }
            /// <summary>
            /// 本地记录最后一个物料刷新
            /// </summary>
            public int MaterialIndexReport
            { get; set; }
            /// <summary>
            /// 风机1#扭矩完成
            /// </summary>
            public bool OverFirstNiuJu
            { get; set; }
            /// <summary>
            /// 风机2#扭矩完成
            /// </summary>
            public bool OverSecondNiuJu
            { get; set; }
            object lockObject = new object();
            public LocalSingleFlushID()
            {
                OilIndex = 0;
                TestIndex = 0;
                AnGuiIndex = 0;
                ErrorIndex = 0;
                MaterialIndex = 0;
                MaterialIndexReport = 0;
                OverFirstNiuJu = false;
                OverSecondNiuJu = false;
            }
            public void Load()
            {

                if (System.IO.File.Exists(string.Format("{0}\\{1}", XMLDirectory, FileName)))
                {
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(string.Format("{0}\\{1}", XMLDirectory, FileName)));
                    if (buff.ContainsKey("OilIndex"))
                        OilIndex = All.Class.Num.ToInt(buff["OilIndex"]);
                    if (buff.ContainsKey("TestIndex"))
                        TestIndex = All.Class.Num.ToInt(buff["TestIndex"]);
                    if (buff.ContainsKey("AnGuiIndex"))
                        AnGuiIndex = All.Class.Num.ToInt(buff["AnGuiIndex"]);
                    if (buff.ContainsKey("ErrorIndex"))
                        ErrorIndex = All.Class.Num.ToInt(buff["ErrorIndex"]);
                    if (buff.ContainsKey("MaterialIndex"))
                        MaterialIndex = All.Class.Num.ToInt(buff["MaterialIndex"]);
                    if (buff.ContainsKey("MaterialIndexReport"))
                        MaterialIndexReport = All.Class.Num.ToInt(buff["MaterialIndexReport"]);
                    if (buff.ContainsKey("OverFirstNiuJu"))
                        OverFirstNiuJu = All.Class.Num.ToBool(buff["OverFirstNiuJu"]);
                    if (buff.ContainsKey("OverSecondNiuJu"))
                        OverSecondNiuJu = All.Class.Num.ToBool(buff["OverSecondNiuJu"]);
                }
                Save();
            }
            /// <summary>
            /// 保存数据
            /// </summary>
            public void Save()
            {
                lock (lockObject)
                {
                    Dictionary<string, string> buff = new Dictionary<string, string>();
                    buff.Add("OilIndex", OilIndex.ToString());
                    buff.Add("TestIndex", TestIndex.ToString());
                    buff.Add("AnGuiIndex", AnGuiIndex.ToString());
                    buff.Add("ErrorIndex", ErrorIndex.ToString());
                    buff.Add("MaterialIndex", MaterialIndex.ToString());
                    buff.Add("MaterialIndexReport", MaterialIndexReport.ToString());
                    buff.Add("OverFirstNiuJu", OverFirstNiuJu.ToString());
                    buff.Add("OverSecondNiuJu", OverSecondNiuJu.ToString());
                    All.Class.FileIO.Write(string.Format("{0}\\{1}", XMLDirectory, FileName), All.Class.SSFile.Dictionary2Text(buff),System.IO.FileMode.Create);
                }
            }
        }
        /// <summary>
        /// 本地设置
        /// </summary>
        public class LocalSets
        {
            const string FileName="本地设置.txt";
            /// <summary>
            /// 视频文件夹
            /// </summary>
            public string VideoDirectory
            { get; set; }
            /// <summary>
            /// 条码格式
            /// </summary>
            public string[] FormatBarStr
            { get; set; }
            /// <summary>
            /// 今天开始
            /// </summary>
            public DateTime TodayStart
            { get; set; }
            /// <summary>
            /// 扭矩底图文件 
            /// </summary>
            public string NiuJuDirectory
            { get; set; }
            /// <summary>
            /// AI文件夹
            /// </summary>
            public string AiDirectory
            { get; set; }
            /// <summary>
            /// OEE最小数量，即小于此数量显示不开心
            /// </summary>
            public float OEECount
            { get; set; }
            /// <summary>
            /// 笑脸
            /// </summary>
            public float OEEGreet
            { get; set; }
            /// <summary>
            /// 合格
            /// </summary>
            public float OEEPass
            { get; set; }
            public LocalSets()
            {
                VideoDirectory = "E:\\FtpServer\\Video\\";
                NiuJuDirectory = "E:\\FtpServer\\NiuJu\\";
                AiDirectory = "E:\\FtpServer\\Ai\\";
                FormatBarStr = new string[2];
                FormatBarStr[0] = "000000000000****";
                FormatBarStr[1] = "000-0000-******-0000000000";
                DateTime now = DateTime.Now.AddHours(-5);
                TodayStart = DateTime.Parse(string.Format("{0:yyyy-MM-dd }05:00:00", now));
                OEECount = 5;
                OEEGreet = 80;
                OEEPass = 65;
            }
            public void Load()
            {
                if (System.IO.File.Exists(string.Format("{0}\\{1}", XMLDirectory, FileName)))
                {
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(string.Format("{0}\\{1}", XMLDirectory, FileName)));
                    if(buff.ContainsKey("VideoDirectory"))
                        VideoDirectory = buff["VideoDirectory"];
                    if (buff.ContainsKey("NiuJuDirectory"))
                        NiuJuDirectory = buff["NiuJuDirectory"];
                    if (buff.ContainsKey("AiDirectory"))
                        AiDirectory = buff["AiDirectory"];
                    if (buff.ContainsKey("OEECount"))
                        OEECount = All.Class.Num.ToFloat(buff["OEECount"]);
                    if (buff.ContainsKey("OEEGreet"))
                        OEEGreet = All.Class.Num.ToFloat(buff["OEEGreet"]);
                    if (buff.ContainsKey("OEEPass"))
                        OEEPass = All.Class.Num.ToFloat(buff["OEEPass"]);
                    List<string> tmpFormatBarStr = new List<string>();
                    for (int i = 0; i < 20; i++)
                    {
                        if (buff.ContainsKey(string.Format("FormatBarStr{0}", i)) && buff[string.Format("FormatBarStr{0}", i)] != "")
                            tmpFormatBarStr.Add(buff[string.Format("FormatBarStr{0}", i)]);
                    }
                    if (tmpFormatBarStr.Count > 0)
                    {
                        FormatBarStr = tmpFormatBarStr.ToArray();
                    }
                    if (buff.ContainsKey("TodayStart"))
                    {
                        DateTime tmp = All.Class.Num.ToDateTime(buff["TodayStart"]);
                        TimeSpan ts = TodayStart - tmp;
                        if (ts.TotalHours >= 24)
                        {
                            FlushDataWrite.ClearHour = true;
                        }
                    }
                    else
                    {
                        FlushDataWrite.ClearHour = true;
                    }
                }
                if (!System.IO.Directory.Exists(VideoDirectory))
                {
                    System.IO.Directory.CreateDirectory(VideoDirectory);
                }
                if (!System.IO.Directory.Exists(NiuJuDirectory))
                {
                    System.IO.Directory.CreateDirectory(NiuJuDirectory);
                }
                if (!System.IO.Directory.Exists(AiDirectory))
                {
                    System.IO.Directory.CreateDirectory(AiDirectory);
                }
                Save();
            }
            public  void Save()
            {
                Dictionary<string, string> buff = new Dictionary<string, string>();
                buff.Add("VideoDirectory", this.VideoDirectory);
                buff.Add("NiuJuDirectory", this.NiuJuDirectory);
                buff.Add("AiDirectory", this.AiDirectory);
                buff.Add("OEECount", this.OEECount.ToString("F3"));
                buff.Add("OEEGreet", this.OEEGreet.ToString("F3"));
                buff.Add("OEEPass", this.OEEPass.ToString("F3"));
                for (int i = 0; i < FormatBarStr.Length; i++)
                {
                    buff.Add(string.Format("FormatBarStr{0}", i), FormatBarStr[i]);
                }
                buff.Add("TodayStart", string.Format("{0:yyyy-MM-dd HH:mm:ss}", TodayStart));
                All.Class.FileIO.Write(string.Format("{0}\\{1}", XMLDirectory, FileName), All.Class.SSFile.Dictionary2Text(buff), System.IO.FileMode.Create);
            }
        }
        public class PlaySets
        {
            /// <summary>
            /// 所有播放类
            /// </summary>
            public PlaySet[] AllPlay
            { get; set; }
            /// <summary>
            /// 加载所有播放类
            /// </summary>
            /// <returns></returns>
            public void Load()
            {
                List<PlaySet> result = new List<PlaySet>();
                PlaySet tmpPlaySet;
                string[] AllPlayLists = Enum.GetNames(typeof(PlaySet.PlayList));
                for (int i = 0; i < AllPlayLists.Length; i++)
                {
                    tmpPlaySet = new PlaySet();
                    tmpPlaySet.Load((PlaySet.PlayList)i);
                    result.Add(tmpPlaySet);
                }
                AllPlay = result.ToArray();
            }
        }

        /// <summary>
        /// 播放设置
        /// </summary>
        public class PlaySet
        {
            /// <summary>
            /// 是否显示播放
            /// </summary>
            public bool Play
            { get; set; }
            /// <summary>
            /// 播放电视序号
            /// </summary>
            public int TVIndex
            { get; set; }
            /// <summary>
            /// 停留时间
            /// </summary>
            public int DelayTime
            { get; set; }
            /// <summary>
            /// 附加信息
            /// </summary>
            public string[] Info
            { get; set; }
            /// <summary>
            /// 播放列表
            /// </summary>
            public enum PlayList:int
            {
                订单 = 0,
                总装线,
                部装线,
                小时产量,
                生产瓶颈,
                停线信息,
                管理信息,
                媒体信息
            }
            /// <summary>
            /// 播放文件
            /// </summary>
            public PlayList Player
            { get; set; }
            public PlaySet()
            {
                Play = true;
                TVIndex = 0;
                DelayTime = 3;
                Info = new string[10];
                Player = PlayList.订单;
                for (int i = 0; i < Info.Length; i++)
                {
                    Info[i] = "";
                }
            }
            /// <summary>
            /// 加载指定播放类
            /// </summary>
            /// <param name="player"></param>
            public void Load(PlayList player)
            {
                this.Player = player;
                if (System.IO.File.Exists(string.Format("{0}{1}.txt", cDataXml.XMLDirectory, player)))
                {
                    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(string.Format("{0}{1}.txt", cDataXml.XMLDirectory, player)));
                    if (buff.ContainsKey("Play"))
                        this.Play = All.Class.Num.ToBool(buff["Play"]);
                    if (buff.ContainsKey("TVIndex"))
                        this.TVIndex = All.Class.Num.ToInt(buff["TVIndex"]);
                    if (buff.ContainsKey("DelayTime"))
                        this.DelayTime = All.Class.Num.ToInt(buff["DelayTime"]);
                    for (int i = 0; i < Info.Length; i++)
                    {
                        if (buff.ContainsKey(string.Format("Info{0}", i)))
                        {
                            this.Info[i] = buff[string.Format("Info{0}", i)];
                        }
                    }
                }
                Save();
            }
            /// <summary>
            /// 保存播放类
            /// </summary>
            public void Save()
            {
                Dictionary<string, string> buff = new Dictionary<string, string>();
                buff.Add("Play", Play.ToString());
                buff.Add("TVIndex", TVIndex.ToString());
                buff.Add("DelayTime", DelayTime.ToString());
                buff.Add("Player", Player.ToString());
                for (int i = 0; i < Info.Length; i++)
                {
                    buff.Add(string.Format("Info{0}", i), Info[i]);
                }
                All.Class.FileIO.Write(string.Format("{0}{1}.txt", cDataXml.XMLDirectory, Player), All.Class.SSFile.Dictionary2Text(buff),System.IO.FileMode.Create);
            }
        }
    }
}
