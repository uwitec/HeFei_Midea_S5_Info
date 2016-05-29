using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
        #region//机型
        public class ModeSet
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
            public string[] PlayFile
            { get; set; }
            /// <summary>
            /// 播放起点
            /// </summary>
            public int[] Start
            { get; set; }
            /// <summary>
            /// 播放终点
            /// </summary>
            public int[] End
            { get; set; }
            /// <summary>
            /// 压缩机识别码
            /// </summary>
            public string[] YaSuoJiID
            { get; set; }
            /// <summary>
            /// 条码联开头
            /// </summary>
            public string[] StrBar
            { get; set; }
            /// <summary>
            /// 扭矩ID
            /// </summary>
            public int NiuJuIDOne
            { get; set; }
            /// <summary>
            /// 扭矩ID
            /// </summary>
            public int NiuJuIDTwo
            { get; set; }
            /// <summary>
            /// 机器人ID
            /// </summary>
            public int MachineID
            { get; set; }
            /// <summary>
            /// 风机ID
            /// </summary>
            public string[] FengJiID
            { get; set; }
            /// <summary>
            /// 电控ID
            /// </summary>
            public string DianKongID
            { get; set; }
            /// <summary>
            /// 折弯机型
            /// </summary>
            public string ZheWangID
            { get; set; }
            public ModeSet()
            {
                ID = "";
                Mode = "";
                Info = "";
                PlayFile = new string[cMain.AllTestComputer];
                Start = new int[cMain.AllTestComputer];
                End = new int[cMain.AllTestComputer];
                for (int i = 0; i < Start.Length; i++)
                {
                    PlayFile[i] = "";
                    Start[i] = 0;
                    End[i] = 0;
                }
                YaSuoJiID = new string[5];
                for (int i = 0; i < YaSuoJiID.Length; i++)
                {
                    YaSuoJiID[i] = "";
                }
                StrBar = new string[15];
                for (int i = 0; i < StrBar.Length; i++)
                {
                    StrBar[i] = "";
                }
                FengJiID = new string[4];
                for (int i = 0; i < FengJiID.Length; i++)
                {
                    FengJiID[i] = "";
                }
                DianKongID = "";
                NiuJuIDOne = 0;
                NiuJuIDTwo = 0;
                MachineID = 0;
                ZheWangID = "";
            }
            #region//机型转字符
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
            //    for (int i = 0; i < PlayFile.Length; i++)
            //    {
            //        buff.Add(string.Format("PlayFile{0}", i + 1), PlayFile[i]);
            //        buff.Add(string.Format("Start{0}", i + 1), Start[i].ToString());
            //        buff.Add(string.Format("End{0}", i + 1), End[i].ToString());
            //    }
            //    for (int i = 0; i < YaSuoJiID.Length; i++)
            //    {
            //        buff.Add(string.Format("YaSuoJiID{0}", i + 1), YaSuoJiID[i]);
            //    }
            //    return All.Class.SSFile.Dictionary2Text(buff);
            //}
            ///// <summary>
            ///// 字符串还原为机型
            ///// </summary>
            ///// <param name="str"></param>
            ///// <returns></returns>
            //public static ModeSet StrToClass(string str)
            //{
            //    ModeSet result = new ModeSet();
            //    Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(str);
            //    result.ID = buff["ID"];
            //    result.Mode = buff["Mode"];
            //    result.Info = buff["Info"];
            //    for (int i = 0; i < result.PlayFile.Length; i++)
            //    {
            //        result.PlayFile[i] = buff[string.Format("PlayFile{0}", i + 1)];
            //        result.Start[i] = All.Class.Num.ToInt(buff[string.Format("Start{0}", i + 1)]);
            //        result.End[i] = All.Class.Num.ToInt(buff[string.Format("End{0}", i + 1)]);
            //    }
            //    for (int i = 0; i < result.YaSuoJiID.Length; i++)
            //    {
            //        result.YaSuoJiID[i] = buff[string.Format("YaSuoJiID{0}", i + 1)];
            //    }
            //    return result;
            //}
            #endregion
            /// <summary>
            /// 根据机型ID得到机型
            /// </summary>
            /// <param name="modeID"></param>
            /// <returns></returns>
            public static ModeSet GetMode(string modeID, All.Class.DataReadAndWrite Conn)
            {
                ModeSet result = new ModeSet();
                using (DataTable dt = Conn.Read(string.Format("select * from SetMode where ModeID='{0}'", modeID)))
                {
                    if (dt != null && dt.Rows.Count >= 1)
                    {
                        result.ID = All.Class.Num.ToString(dt.Rows[0]["ModeID"]);
                        result.Mode = All.Class.Num.ToString(dt.Rows[0]["Mode"]);
                        result.Info = All.Class.Num.ToString(dt.Rows[0]["ModeInfo"]);
                        for (int i = 0; i < HeiFeiMideaDll.cMain.AllTestComputer; i++)
                        {
                            result.PlayFile[i] = All.Class.Num.ToString(dt.Rows[0][string.Format("PlayFile{0}", i + 1)]);
                            result.Start[i] = All.Class.Num.ToInt(dt.Rows[0][string.Format("Start{0}", i + 1)]);
                            result.End[i] = All.Class.Num.ToInt(dt.Rows[0][string.Format("End{0}", i + 1)]);
                        }
                        for (int i = 0; i <result.YaSuoJiID.Length; i++)
                        {
                            result.YaSuoJiID[i] = All.Class.Num.ToString(dt.Rows[0][string.Format("YaSuoJiID{0}", i + 1)]);
                        }
                        for (int i = 0; i < result.StrBar.Length; i++)
                        {
                            result.StrBar[i] = All.Class.Num.ToString(dt.Rows[0][string.Format("StrBar{0}", i + 1)]);
                        }
                        result.NiuJuIDOne = All.Class.Num.ToInt(dt.Rows[0]["NiuJuID1"]);
                        result.NiuJuIDTwo = All.Class.Num.ToInt(dt.Rows[0]["NiuJuID2"]);
                        result.MachineID = All.Class.Num.ToInt(dt.Rows[0]["MachineID"]);
                        for (int i = 0; i < result.FengJiID.Length; i++)
                        {
                            result.FengJiID[i] = All.Class.Num.ToString(dt.Rows[0][string.Format("FengJiID{0}", i + 1)]);
                        }
                        result.DianKongID = All.Class.Num.ToString(dt.Rows[0]["DianKongID"]);
                        result.ZheWangID = All.Class.Num.ToString(dt.Rows[0]["ZheWangID"]);
                    }
                }
                return result;
            }
            /// <summary>
            /// 获取所有机型
            /// </summary>
            /// <returns></returns>
            public static List<ModeSet> GetModeList(All.Class.DataReadAndWrite Conn)
            {
                List<ModeSet> result = new List<ModeSet>();
                using (DataTable dt = Conn.Read("select ModeID,Mode,ModeInfo from SetMode order by ID desc"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ModeSet tmpModeSet;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmpModeSet = new ModeSet();
                            tmpModeSet.ID = All.Class.Num.ToString(dt.Rows[i]["ModeID"]);
                            tmpModeSet.Mode = All.Class.Num.ToString(dt.Rows[i]["Mode"]);
                            tmpModeSet.Info = All.Class.Num.ToString(dt.Rows[i]["ModeInfo"]);
                            result.Add(tmpModeSet);
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// 根据条码获取机型ID
            /// </summary>
            /// <param name="barCode"></param>
            /// <param name="formatStr"></param>
            /// <returns></returns>
            public static string GetModeIDFromBar(string barCode, string[] formatStr)
            {
                if (barCode.Length < 10 || formatStr == null || formatStr.Length == 0)
                {
                    All.Class.Log.Add("当前条码长度不足或无机型列表或无条码格式，无法查找机型");
                    return "";
                }
                string formatValue = "";
                for (int i = 0; i < formatStr.Length; i++)
                {
                    if (formatStr[i].Length == barCode.Length)
                    {
                        formatValue = formatStr[i];
                        break;
                    }
                }
                if (formatValue == "")
                {
                    All.Class.Log.Add(string.Format("当前条码没有找到相应的条码格式\r\n当前条码  ->  {0}", barCode), Environment.StackTrace);
                    return "";
                }
                int startX = formatValue.IndexOf('#');
                int endX = formatValue.LastIndexOf('#');
                if (startX < 0 || endX < 0)
                {
                    All.Class.Log.Add(string.Format("当前条码格式没有机型位\r\n当前格式  ->  {0}", formatValue), Environment.StackTrace);
                    return "";
                }
                return barCode.Substring(startX, endX - startX + 1);
            }
            ///// <summary>
            ///// 根据条码获取机型
            ///// </summary>
            ///// <param name="barCode"></param>
            ///// <returns></returns>
            //public ModeSet GetMode(List<ModeSet> modeSet, string barCode, string[] formatStr)
            //{
            //    if (barCode.Length < 10 || modeSet == null || formatStr == null
            //        || modeSet.Count == 0 || formatStr.Length == 0)
            //    {
            //        All.Class.Log.Add("当前条码长度不足或无机型列表或无条码格式，无法查找机型");
            //        return null;
            //    }
            //    return modeSet.Find(
            //        mode =>
            //        {
            //            return mode.ID==ModeID;
            //        });
            //}
            /// <summary>
            /// 删除机型
            /// </summary>
            /// <param name="ModeId"></param>
            /// <returns></returns>
            public static bool Delete(string ModeId,All.Class.DataReadAndWrite Conn)
            {
                return Conn.Write(string.Format("delete from SetMode Where ModeID='{0}'", ModeId.Trim())) == 1;
            }
            /// <summary>
            /// 将机型保存到数据库
            /// </summary>
            /// <param name="mode"></param>
            /// <returns></returns>
            public static bool Save(ModeSet mode,All.Class.DataReadAndWrite Conn)
            {
                Delete(mode.ID,Conn);
                //字符串
                string sql = "insert into SetMode ({0}) values ({1})";
                string title = "ModeId,Mode,ModeInfo {0}{1}{2}{3}{4}{5}{6}";
                string value = "'{0}','{1}','{2}'{3}{4}{5}{6}{7}{8}{9}";
                //标题
                string playFile = "";
                string start = "";
                string end = "";
                string yaSuoJiID = "";
                string strBar = "";
                string niuJu = "";
                string fengJi = "";
                for (int i = 0; i < mode.PlayFile.Length; i++)
                {
                    playFile = string.Format("{0},PlayFile{1}", playFile, i + 1);
                    start = string.Format("{0},Start{1}", start, i + 1);
                    end = string.Format("{0},End{1}", end, i + 1);
                }
                for (int i = 0; i < mode.YaSuoJiID.Length; i++)
                {
                    yaSuoJiID = string.Format("{0},YaSuoJiID{1}", yaSuoJiID, i + 1);
                }
                for (int i = 0; i < mode.StrBar.Length; i++)
                {
                    strBar = string.Format("{0},StrBar{1}", strBar, i + 1);
                }
                niuJu = ",NiuJuID1,NiuJuID2,MachineID,DianKongID,ZheWangID";
                for (int i = 0; i < mode.FengJiID.Length; i++)
                {
                    fengJi = string.Format("{0},FengJiID{1}", fengJi, i + 1);
                }
                title = string.Format(title, playFile, start, end, yaSuoJiID,strBar,niuJu,fengJi);
                //值
                playFile = "";
                start = "";
                end = "";
                yaSuoJiID = "";
                strBar = "";
                niuJu = "";
                fengJi = "";
                for (int i = 0; i < mode.PlayFile.Length; i++)
                {
                    playFile = string.Format("{0},'{1}'", playFile, mode.PlayFile[i]);
                    start = string.Format("{0},{1}", start, mode.Start[i]);
                    end = string.Format("{0},{1}", end, mode.End[i]);
                }
                for (int i = 0; i < mode.YaSuoJiID.Length; i++)
                {
                    yaSuoJiID = string.Format("{0},'{1}'", yaSuoJiID, mode.YaSuoJiID[i]);
                }
                for (int i = 0; i < mode.StrBar.Length; i++)
                {
                    strBar = string.Format("{0},'{1}'", strBar, mode.StrBar[i]);
                }
                niuJu = string.Format("{0},{1},{2},{3},'{4}','{5}'", niuJu, mode.NiuJuIDOne, mode.NiuJuIDTwo,mode.MachineID,mode.DianKongID,mode.ZheWangID);
                for (int i = 0; i < mode.FengJiID.Length; i++)
                {
                    fengJi = string.Format("{0},'{1}'", fengJi, mode.FengJiID[i]);
                }
                value = string.Format(value, mode.ID, mode.Mode, mode.Info, playFile, start, end, yaSuoJiID,strBar,niuJu,fengJi);
                //组合后写入数据库
                sql = string.Format(sql, title, value);
                return Conn.Write(sql) == 1;
            }
        }
        #endregion
}
