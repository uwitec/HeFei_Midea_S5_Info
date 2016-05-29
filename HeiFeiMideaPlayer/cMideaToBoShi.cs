using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class MideaToBoShi
    {
        string fileName = "";
        /// <summary>
        /// 所有机型转换规则
        /// </summary>
        public Dictionary<string, HeiFeiMideaDll.cBoShi.BoShiValue> AllMode
        { get; set; }

        public MideaToBoShi()
        {
            AllMode = new Dictionary<string, HeiFeiMideaDll.cBoShi.BoShiValue>();
            fileName = string.Format("{0}\\MideaToBoShi.txt", cDataXml.XMLDirectory);
        }
        /// <summary>
        /// 从文本文件中加载美的与博世的对应关系
        /// </summary>
        public void Load()
        {
            if (System.IO.File.Exists(fileName))
            {
                HeiFeiMideaDll.cBoShi.BoShiValue tmpBoShi;
                string[] tmpValue;
                Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(All.Class.FileIO.ReadFile(fileName));
                buff.Keys.ToList().ForEach(
                    tmpBuff =>
                    {
                        tmpValue = buff[tmpBuff].Split('|');
                        if (tmpValue.Length == 2)
                        {
                            tmpBoShi = new HeiFeiMideaDll.cBoShi.BoShiValue(tmpValue[0], tmpValue[1]);
                            if (!AllMode.ContainsKey(tmpBuff))
                            {
                                AllMode.Add(tmpBuff, tmpBoShi);
                            }
                        }
                    });
            }
        }
        private void Save()
        {
            Dictionary<string, string> buff = new Dictionary<string, string>();
            if (AllMode != null && AllMode.Count > 0)
            {
                AllMode.Keys.ToList().ForEach(
                    mode =>
                    {
                        buff.Add(mode, string.Format("{0}|{1}", AllMode[mode].ID, AllMode[mode].Mode));
                    });
            }
            All.Class.FileIO.Write(fileName, All.Class.SSFile.Dictionary2Text(buff), System.IO.FileMode.Create);
        }
        /// <summary>
        /// 添加一组对应关系
        /// </summary>
        /// <param name="midea"></param>
        /// <param name="boShi"></param>
        private void AddMode(string midea, HeiFeiMideaDll.cBoShi.BoShiValue boShi)
        {
            if (AllMode.Keys.ToList().FindIndex(
                str =>
                {
                    return str == midea;
                }) >= 0)
            {
                return;
            }
            AllMode.Add(midea, boShi);
            Save();
        }
        public void Midea2BoShi(string mBarCode, HeiFeiMideaDll.cMain.AllComputerList computer, out DateTime BarTime, out string bBarCode, out string bMode, out string bID,out bool FindFromOld)
        {
            BarTime = DateTime.Now;
            bBarCode = "";
            bMode = "";
            bID = "";
            FindFromOld = false;
            switch (computer)
            {
                case HeiFeiMideaDll.cMain.AllComputerList.上线:
                    Midea2BoShiInLine(mBarCode, out BarTime, out bBarCode, out bMode, out bID, out FindFromOld);
                    break;
                case HeiFeiMideaDll.cMain.AllComputerList.影像检:
                    Midea2BoShiYinXiang(mBarCode, out BarTime, out bBarCode, out bMode, out bID);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 影像处美的码转博世码
        /// </summary>
        /// <param name="mBarCode"></param>
        /// <param name="BarTime"></param>
        /// <param name="bBarCode"></param>
        /// <param name="bMode"></param>
        /// <param name="bID"></param>
        private void Midea2BoShiYinXiang(string mBarCode, out DateTime BarTime, out string bBarCode, out string bMode, out string bID)
        {
            bBarCode = "";
            bMode = "";
            bID = "";
            BarTime = DateTime.Now;
            string tmpBarCode = mBarCode.Trim();
            if (tmpBarCode.Length != 22)
            {
                frmMain.mMain.AddInfo(string.Format("当前输入的条码：{0}不是正确的22位码，不能转换成博世条码", mBarCode));
                return;
            }
            string mideaMode = tmpBarCode.Substring(6, 5);//取美的机型
            if (AllMode.ContainsKey(mideaMode))//美的机型转博世机型
            {
                bMode = AllMode[mideaMode].Mode;
                bID = AllMode[mideaMode].ID;
            }
            else//从服务器取机型转换关系
            {
                using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select BoShi,BoShiJiXing From SetMideaToBoShi where Midea='{0}'", mideaMode)))
                {
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        frmMain.mMain.AddInfo(string.Format("当前美的机型：{0}不存在与博世机型的转换关系，无法转换条码", mideaMode));
                        return;
                    }
                    bMode = All.Class.Num.ToString(dt.Rows[0]["BoShiJiXing"]);
                    bID = All.Class.Num.ToString(dt.Rows[0]["BoShi"]);
                    AddMode(mideaMode, new HeiFeiMideaDll.cBoShi.BoShiValue(
                        bID, bMode));
                }
            }
            BarTime = All.Class.MideaBarCode.GetTimeFromBar(tmpBarCode);
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select BoShiBarCode from TestAll where BarCode='{0}'", mBarCode)))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AddInfo(string.Format("当前条码:{0}没有上线记录,无法确定对应美的码,无法转换条码", mBarCode));
                    return;
                }
                bBarCode = All.Class.Num.ToString(dt.Rows[0]["BoShiBarCode"]);
            }
        }
        /// <summary>
        /// 上线处美的码转博世码
        /// </summary>
        /// <param name="mBarCode">美的条码</param>
        /// <param name="bBarCode">博世条码</param>
        /// <param name="bMode">博世机型</param>
        /// <param name="BarTime">条码上的时间</param>
        /// <param name="bID">博世机型ID</param>
        /// <param name="FindFromOld">是否为找到的已存在的数据，已存在数据则不用添加序列号</param>
        /// <returns></returns>
        private void Midea2BoShiInLine(string mBarCode, out DateTime BarTime, out string bBarCode, out string bMode, out string bID, out bool FindFromOld)
        {
            FindFromOld = false;
            bBarCode = "";
            bMode = "";
            bID = "";
            string tmpBarCode = mBarCode.Trim();
            BarTime = All.Class.MideaBarCode.GetTimeFromBar(tmpBarCode);
            if (tmpBarCode.Length != 22)
            {
                frmMain.mMain.AddInfo(string.Format("当前输入的条码：{0}不是正确的22位码，不能转换成博世条码", mBarCode));
                return;
            }
            string mideaMode = tmpBarCode.Substring(6, 5);//取美的机型
            if (AllMode.ContainsKey(mideaMode))//美的机型转博世机型
            {
                bMode = AllMode[mideaMode].Mode;
                bID = AllMode[mideaMode].ID;
            }
            else//从服务器取机型转换关系
            {
                using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select BoShi,BoShiJiXing From SetMideaToBoShi where Midea='{0}'", mideaMode)))
                {
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        frmMain.mMain.AddInfo(string.Format("当前美的机型：{0}不存在与博世机型的转换关系，无法转换条码", mideaMode));
                        return;
                    }
                    bMode = All.Class.Num.ToString(dt.Rows[0]["BoShiJiXing"]);
                    bID = All.Class.Num.ToString(dt.Rows[0]["BoShi"]);
                    AddMode(mideaMode, new HeiFeiMideaDll.cBoShi.BoShiValue(
                        bID, bMode));
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.DataBarCode.Read(string.Format("select Midea,Boss,Mode,OrderName from AllBarCode where Midea='{0}'", mBarCode)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    bBarCode = All.Class.Num.ToString(dt.Rows[0]["Boss"]);
                    FindFromOld = true;
                }
                else
                {
                    bBarCode = string.Format("399A-{0}-{1:D6}-{2}", All.Class.BoShi.GetBoShiTime(BarTime),  frmMain.mMain.AllDataXml.LocalBoShis.GetIndex(BarTime, bID), bID);
                }
            }
        }
    }
}
