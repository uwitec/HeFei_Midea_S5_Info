using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
        #region//机型 折弯
        public class ModeZheWangSet
        {
            /// <summary>
            /// 机型ID
            /// </summary>
            public string ID
            { get; set; }
            /// <summary>
            /// 机型 
            /// </summary>
            public string Mode
            { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Info
            { get; set; }
            /// <summary>
            /// 播放文件
            /// </summary>
            public string PlayFile
            { get; set; }
            /// <summary>
            /// 播放起点
            /// </summary>
            public int Start
            { get; set; }
            /// <summary>
            /// 播放终点
            /// </summary>
            public int End
            { get; set; }
            
            public ModeZheWangSet()
            {
                ID = "";
                Mode = "";
                Info = "";
                PlayFile = "";
                Start = 0;
                End = 0;
            }
            #region//机型与字符串互转
            ///// <summary>
            ///// 机型转化为可传递的字符串
            ///// </summary>
            ///// <returns></returns>
            //public string ClassToStr()
            //{
            //    Dictionary<string, string> buff = new Dictionary<string, string>();
            //    buff.Add("ID", this.ID);
            //    buff.Add("Mode", this.Mode);
            //    buff.Add("Info", this.Info);
            //    buff.Add("PlayFile1", PlayFile);
            //    buff.Add("Star1", Start.ToString());
            //    buff.Add("End1", End.ToString());

            //    return All.Class.SSFile.Dictionary2Text(buff);
            //}
            ///// <summary>
            ///// 字符串还原为机型
            ///// </summary>
            ///// <param name="str"></param>
            ///// <returns></returns>
            //public static ModeZheWangSet StrToClass(string str)
            //{
            //    ModeZheWangSet result = new ModeZheWangSet();
            //    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(str);
            //    result.ID = buff["ID"];
            //    result.Mode = buff["Mode"];
            //    result.Info = buff["Info"];
            //    result.PlayFile = buff["PlayFile1"];
            //    result.Start = All.Class.Num.ToInt(buff["Start1"]);
            //    result.End = All.Class.Num.ToInt(buff["End1"]);
            //    return result;
            //}
            #endregion

            /// <summary>
            /// 根据机型ID得到机型
            /// </summary>
            /// <param name="modeID"></param>
            /// <returns></returns>
            public static ModeZheWangSet GetMode(string modeID, All.Class.DataReadAndWrite Conn)
            {
                ModeZheWangSet result = new ModeZheWangSet();
                using (DataTable dt = Conn.Read(string.Format("select * from SetZheWang where ModeID='{0}'", modeID)))
                {
                    if (dt != null && dt.Rows.Count >= 1)
                    {
                        result.ID = All.Class.Num.ToString(dt.Rows[0]["ModeID"]);
                        result.Mode = All.Class.Num.ToString(dt.Rows[0]["Mode"]);
                        result.Info = All.Class.Num.ToString(dt.Rows[0]["ModeInfo"]);
                        result.PlayFile = All.Class.Num.ToString(dt.Rows[0]["PlayFile1"]);
                        result.Start = All.Class.Num.ToInt(dt.Rows[0]["Start1"]);
                        result.End = All.Class.Num.ToInt(dt.Rows[0]["End1"]);

                    }
                }
                return result;
            }
            /// <summary>
            /// 获取所有机型
            /// </summary>
            /// <returns></returns>
            public static List<ModeZheWangSet> GetModeList(All.Class.DataReadAndWrite Conn)
            {
                List<ModeZheWangSet> result = new List<ModeZheWangSet>();
                using (DataTable dt = Conn.Read("select ModeId,Mode,ModeInfo from SetZheWang order by ID desc"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ModeZheWangSet tmpModeZheWangSet;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmpModeZheWangSet = new ModeZheWangSet();
                            tmpModeZheWangSet.ID = All.Class.Num.ToString(dt.Rows[i]["ModeID"]);
                            tmpModeZheWangSet.Mode = All.Class.Num.ToString(dt.Rows[i]["Mode"]);
                            tmpModeZheWangSet.Info = All.Class.Num.ToString(dt.Rows[i]["ModeInfo"]);
                            result.Add(tmpModeZheWangSet);
                        }
                    }
                }
                return result;
            }
            ///// <summary>
            ///// 根据条码获取机型
            ///// </summary>
            ///// <param name="barCode"></param>
            ///// <returns></returns>
            //public static string GetModeIDFromBar(string barCode, string[] formatStr)
            //{
            //    if (barCode.Length < 10 || formatStr == null || formatStr.Length == 0)
            //    {
            //        All.Class.Log.Add("当前条码长度不足或无机型列表或无条码格式，无法查找机型");
            //        return "";
            //    }
            //    string formatValue = "";
            //    for (int i = 0; i < formatStr.Length; i++)
            //    {
            //        if (formatStr[i].Length == barCode.Length)
            //        {
            //            formatValue = formatStr[i];
            //            break;
            //        }
            //    }
            //    if (formatValue == "")
            //    {
            //        All.Class.Log.Add(string.Format("当前条码没有找到相应的条码格式\r\n当前条码  ->  {0}", barCode), Environment.StackTrace);
            //        return "";
            //    }
            //    int startX = formatValue.IndexOf('#');
            //    int endX = formatValue.LastIndexOf('#');
            //    if (startX < 0 || endX < 0)
            //    {
            //        All.Class.Log.Add(string.Format("当前条码格式没有机型位\r\n当前格式  ->  {0}", formatValue), Environment.StackTrace);
            //        return "";
            //    }
            //    return barCode.Substring(startX, endX - startX + 1);
            //}
            /// <summary>
            /// 删除机型
            /// </summary>
            /// <param name="ModeId"></param>
            /// <returns></returns>
            public static bool Delete(string ModeId, All.Class.DataReadAndWrite Conn)
            {
                return Conn.Write(string.Format("delete from SetZheWang Where ModeID='{0}'", ModeId.Trim())) == 1;
            }
            /// <summary>
            /// 将机型保存到数据库
            /// </summary>
            /// <param name="mode"></param>
            /// <returns></returns>
            public static bool Save(ModeZheWangSet mode, All.Class.DataReadAndWrite Conn)
            {
                Delete(mode.ID, Conn);
                //字符串
                string sql = "insert into SetZheWang ({0}) values ({1})";
                string title = "ModeId,Mode,ModeInfo {0}{1}{2}";
                string value = "'{0}','{1}','{2}'{3}{4}{5}";
                //标题
                string playFile = ",PlayFile1";
                string start = ",Start1";
                string end = ",End1";

                title = string.Format(title, playFile, start, end);
                //值

                playFile = string.Format(",'{0}'", mode.PlayFile);
                start = string.Format(",{0}", mode.Start);
                end = string.Format(",{0}", mode.End);


                value = string.Format(value, mode.ID, mode.Mode, mode.Info, playFile, start, end);
                //组合后写入数据库
                sql = string.Format(sql, title, value);
                return Conn.Write(sql) == 1;
            }
        }
        #endregion
}
