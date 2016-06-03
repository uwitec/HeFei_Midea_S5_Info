using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class FlushOEE:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 笑脸列表
        /// </summary>
        public enum SmileList
        {
            优,
            良,
            差
        }
        /// <summary>
        /// 是否显示笑脸
        /// </summary>
        public SmileList Smile
        {
            get
            {
                SmileList result = SmileList.差;
                float timeCount = 0;
                DateTime now = DateTime.Now;
                for (int i = 0; i < OEETimes.Count; i++)
                {
                    if (OEETimes[i].UseTime)
                    {
                        if ((OEETimes[i].HourEnd * 60 + OEETimes[i].MinEnd) <= (now.Hour * 60 + now.Minute))
                        {
                            //整段时间全部过去
                            timeCount += OEETimes[i].TotalTime;
                        }
                        else if ((OEETimes[i].HourStart * 60 + OEETimes[i].MinStart) <= (now.Hour * 60 + now.Minute))
                        {
                            //只是开始时间过去
                            timeCount += (((float)(now.Hour * 60 + now.Minute) - (OEETimes[i].HourStart * 60 + OEETimes[i].MinStart)) / 60.0f);
                        }
                    }
                }
                float oeevalue = 0;
                if (timeCount > 0)
                {
                    oeevalue = ((float)Count / timeCount)/frmMain.mMain.AllDataXml.LocalSet.OEECount;
                }
                if (oeevalue * 100 >= frmMain.mMain.AllDataXml.LocalSet.OEEGreet)
                {
                    result = SmileList.优;
                }
                else if (oeevalue * 100 >= frmMain.mMain.AllDataXml.LocalSet.OEEPass)
                {
                    result = SmileList.良;
                }
                else
                {
                    result = SmileList.差;
                }
                return result;
            }
        }
        /// <summary>
        /// 今日产量
        /// </summary>
        public int Count;
        /// <summary>
        /// OEE显示时间段
        /// </summary>
        public List<OEETime> OEETimes
        { get; set; }

        /// <summary>
        /// OEE显示文本段
        /// </summary>
        public List<string> OEEShow
        { get; set; }

        /// <summary>
        /// OEE时间段数据
        /// </summary>
        public List<int> OEECount
        {
            get
            {
                List<int> oeeCount = new List<int>();
                for (int i = 0; i < OEETimes.Count; i++)
                {
                    oeeCount.Add(0);
                }
                //小时OEE
                using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read("select TestHour,TestMin,TestSec from StatueOee"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int hour = 0, min = 0, index = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            hour = All.Class.Num.ToInt(dt.Rows[i]["TestHour"]);
                            min = All.Class.Num.ToInt(dt.Rows[i]["TestMin"]);
                            index = OEETimes.FindIndex(
                                oee =>
                                {
                                    return (oee.HourStart * 60 + oee.MinStart) <= (hour * 60 + min) && (hour * 60 + min) <= (oee.HourEnd * 60 + oee.MinEnd);
                                });
                            if (index >= 0 && index < oeeCount.Count)
                            {
                                oeeCount[index] = oeeCount[index] + 1;
                            }
                        }
                    }

                }
                return oeeCount;
            }
        }

        
        public FlushOEE()
        {
            Count = 0;
            OEETimes = new List<OEETime>();
            OEEShow = new List<string>();
        }
        public override void Load()
        {
            //将当天的数据写入到表格
            using (DataTable dt = frmMain.mMain.AllDataBase.WriteData.Read(string.Format("select * from TestCount where TestYear={0:yyyy} and TestMonth={0:MM}", frmMain.mMain.AllDataXml.LocalSet.TodayStart)))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    string title = "";
                    string data = "";
                    for (int i = 0; i < 31; i++)
                    {
                        title = string.Format("{0},Count{1},Time{1}", title, i + 1);
                        data = string.Format("{0},0,0", data);
                    }
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into TestCount (TestYear,TestMonth{0}) Values ({1:yyyy},{1:MM}{2})", title, frmMain.mMain.AllDataXml.LocalSet.TodayStart, data));
                }
                else
                {
                    Count = All.Class.Num.ToInt(dt.Rows[0][string.Format("Count{0}", frmMain.mMain.AllDataXml.LocalSet.TodayStart.Day)]);
                }
            }
            OEETimes = OEETime.GetAllOEETime();
            OEEShow.Clear();
            for (int i = 0; i < OEETimes.Count; i++)
            {
                OEEShow.Add(OEETimes[i].ToString());
            }
            
            CheckTime();
        }
        public override void Flush()
        {
        }
        
        /// <summary>
        /// 设置改变后，修正当天的总时间
        /// </summary>
        public void CheckTime()
        {
            float time = 0;
            for (int i = 0; i < OEETimes.Count; i++)
            {
                time += OEETimes[i].TotalTime;
            }
            frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update TestCount Set Time{0}={1} where TestYear={2:yyyy} and TestMonth={2:MM}",
                frmMain.mMain.AllDataXml.LocalSet.TodayStart.Day, (int)((float)time * 60.0f),
                frmMain.mMain.AllDataXml.LocalSet.TodayStart));
        }
        /// <summary>
        /// 添加一台下线数量，专用于OEE计算
        /// </summary>
        public void AddCount()
        {
            Count++;
            DateTime time = DateTime.Now;

            frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update TestCount Set Count{0}={1} where TestYear={2:yyyy} and TestMonth={2:MM}",
                frmMain.mMain.AllDataXml.LocalSet.TodayStart.Day, Count, frmMain.mMain.AllDataXml.LocalSet.TodayStart));
            
            frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueOEE (TestHour,TestMin,TestSec) values ({0:HH},{0:mm},{0:ss})",
                time));
        }
        #region//OEE时间段
        /// <summary>
        /// OEE时间段设置
        /// </summary>
        public class OEETime
        {
            /// <summary>
            /// 小时开始
            /// </summary>
            public int HourStart
            { get; set; }
            /// <summary>
            /// 分钟开始
            /// </summary>
            public int MinStart
            { get; set; }
            /// <summary>
            /// 小时结束
            /// </summary>
            public int HourEnd
            { get; set; }
            /// <summary>
            /// 分钟结束
            /// </summary>
            public int MinEnd
            { get; set; }
            /// <summary>
            /// 是否启用时间
            /// </summary>
            public bool UseTime
            { get; set; }
            /// <summary>
            /// 时间段持续时间
            /// </summary>
            public float TotalTime
            {
                get
                {
                    float result = 1;
                    float tmpMin = HourStart * 60 + MinStart - HourEnd * 60 - MinEnd;
                    if (tmpMin > 0)
                    {
                        result = tmpMin / 60.0f;
                    }
                    return result;
                }
            }
            public OEETime()
            {
                HourStart = 0;
                MinStart = 0;
                HourEnd = 0;
                MinEnd = 0;
                UseTime = false;
            }
            public override string ToString()
            {
                return string.Format("{0:D2}:{1:D2}-{2:D2}:{3:D2}", HourStart, MinStart, HourEnd, MinEnd);
            }
            /// <summary>
            /// 获取所有时间段
            /// </summary>
            /// <returns></returns>
            public static List<OEETime> GetAllOEETime()
            {
                List<OEETime> result = new List<OEETime>();
                OEETime tmp;
                using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read("select HourStart,MinStart,HourEnd,MinEnd,UseTime from SetTime order by HourStart,MinStart"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmp = new OEETime();
                            tmp.HourStart = All.Class.Num.ToInt(dt.Rows[i]["HourStart"]);
                            tmp.MinStart = All.Class.Num.ToInt(dt.Rows[i]["MinStart"]);
                            tmp.HourEnd = All.Class.Num.ToInt(dt.Rows[i]["HourEnd"]);
                            tmp.MinEnd = All.Class.Num.ToInt(dt.Rows[i]["MinEnd"]);
                            tmp.UseTime = All.Class.Num.ToBool(dt.Rows[i]["UseTime"]);
                            result.Add(tmp);
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// 保存OEE时间段设置
            /// </summary>
            /// <param name="allOEETimes"></param>
            /// <returns></returns>
            public static bool Save(List<OEETime> allOEETimes)
            {
                bool result = true;
                if (allOEETimes != null && allOEETimes.Count > 0)
                {
                    frmMain.mMain.AllDataBase.WriteData.Write("delete from SetTime where ID>=0");
                    allOEETimes.ForEach(
                        oee =>
                        {
                            result = result && (frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into SetTime (HourStart,MinStart,HourEnd,MinEnd,UseTime) values ({0},{1},{2},{3},'{4}')",
                                oee.HourStart, oee.MinStart, oee.HourEnd, oee.MinEnd, oee.UseTime)) == 1);
                        });
                }
                return result;
            }
        }
        #endregion
    }
}
