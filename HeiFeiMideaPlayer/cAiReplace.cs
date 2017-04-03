using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class cAiReplace
    {
        public List<TextReplace> TReplace = new List<TextReplace>();
        public List<RegionReplace> RReplace = new List<RegionReplace>();
        public cAiReplace()
        { }
        public void Load()
        {
            if (System.IO.File.Exists(string.Format("{0}\\Replace.Txt", cDataXml.XMLDirectory)))
            {
                cAiReplace tmp = (cAiReplace)All.Class.XmlHelp.ReadXml(string.Format("{0}\\Replace.Txt", cDataXml.XMLDirectory), typeof(cAiReplace), null);
                if (tmp == null)
                {
                    GetDefault();
                }
                else
                {
                    this.TReplace = tmp.TReplace;
                    this.RReplace = tmp.RReplace;
                }
            }
            else
            {
                GetDefault();
            }
            Save();
        }
        private void GetDefault()
        {
            TReplace.Add(new TextReplace("00000000", TextReplace.TextList.订单_出口订单名称));
            TReplace.Add(new TextReplace("XW总000000000000", TextReplace.TextList.订单_订单名称));
            TReplace.Add(new TextReplace("8888", TextReplace.TextList.日期_年年月月));
            TReplace.Add(new TextReplace("2112000000000000000000", TextReplace.TextList.条码_美的条码));
            TReplace.Add(new TextReplace("2400000000000000000000", TextReplace.TextList.条码_美的出口条码));
            TReplace.Add(new TextReplace("9999", TextReplace.TextList.日期_年年年年));
            TReplace.Add(new TextReplace("99", TextReplace.TextList.日期_月月));
            TReplace.Add(new TextReplace("399A-000-000000-0000000000", TextReplace.TextList.条码_博世条码));
            TReplace.Add(new TextReplace("DCIV00-00-3C", TextReplace.TextList.机型_博世机型));
            TReplace.Add(new TextReplace("MDV-000", TextReplace.TextList.机型_美的机型));

            RReplace.Add(new RegionReplace(50, 50, 50, 50, RegionReplace.RegionList.二维码));
            RReplace.Add(new RegionReplace(60, 60, 60, 60, RegionReplace.RegionList.博世条码));
            RReplace.Add(new RegionReplace(70, 70, 70, 70, RegionReplace.RegionList.美的条码));
            RReplace.Add(new RegionReplace(80, 80, 80, 80, RegionReplace.RegionList.出口条码));
        }
        private void Save()
        {
            All.Class.XmlHelp.SaveXml(string.Format("{0}\\Replace.Txt", cDataXml.XMLDirectory), typeof(cAiReplace), this);
        }
        /// <summary>
        /// 文本替换
        /// </summary>
        public class TextReplace
        {
            public string OldText
            { get; set; }
            public TextList NewText
            { get; set; }
            public enum TextList
            {
                日期_年年年年,
                日期_年年,
                日期_月月,
                日期_月,
                日期_日日,
                日期_年年月月,
                日期_年年年年月月日日,
                日期_3位博世日期,
                条码_美的条码,
                条码_博世条码,
                条码_美的出口条码,
                机型_美的机型,
                机型_博世机型,
                订单_订单名称,
                订单_出口订单名称
            }
            public TextReplace()
            { }
            public TextReplace(string oldText, TextList newText)
            {
                this.OldText = oldText;
                this.NewText = newText;
            }
        }
        /// <summary>
        /// 图形替换
        /// </summary>
        public class RegionReplace
        {
            public int CValue
            { get; set; }
            public int MValue
            { get; set; }
            public int YValue
            { get; set; }
            public int KValue
            { get; set; }
            public enum RegionList
            {
                二维码,
                美的条码,
                博世条码,
                出口条码,
            }
            public RegionList NewRegion
            { get; set; }
            public RegionReplace()
                : this(50, 50, 50, 50, RegionList.二维码)
            {
                
            }
            /// <summary>
            /// 替换图形
            /// </summary>
            /// <param name="cValue"></param>
            /// <param name="mValue"></param>
            /// <param name="yValue"></param>
            /// <param name="kValue"></param>
            /// <param name="newRegion"></param>
            public RegionReplace(int cValue, int mValue, int yValue, int kValue, RegionList newRegion)
            {
                this.CValue = cValue;
                this.MValue = mValue;
                this.YValue = yValue;
                this.KValue = kValue;
                this.NewRegion = newRegion;
            }
        }
    }
}
