
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HeiFeiMideaPlayer
{
    public class cData
    {
        /// <summary>
        /// 刷新连接
        /// </summary>
        public All.Class.DataReadAndWrite FlushData
        { get; set; }
        /// <summary>
        /// 本地数据方法
        /// </summary>
        public HeiFeiMideaDll.cDataLocal Local
        { get; set; }
        /// <summary>
        /// 条码打印方法
        /// </summary>
        public All.Class.DataReadAndWrite DataBarCode
        { get; set; }
        /// <summary>
        /// 冷凝器条码
        /// </summary>
        public All.Class.DataReadAndWrite LenNingQi
        { get; set; }
        public cData()
        {
            if (!System.IO.Directory.Exists(string.Format("{0}\\Data\\", All.Class.FileIO.GetNowPath())))
            {
                System.IO.Directory.CreateDirectory(string.Format("{0}\\Data\\", All.Class.FileIO.GetNowPath()));
            }
        }
        /// <summary>
        /// 加载数据库连接
        /// </summary>
        public void Load()
        {
            int start = Environment.TickCount;
            string dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());
            
            FlushData = All.Class.DataReadAndWrite.GetData(dataFile, "FlushData");

            Local = new HeiFeiMideaDll.cDataLocal(FlushData);

            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 1)
            {
                DataBarCode = All.Class.DataReadAndWrite.GetData(dataFile, "BarCode");
            }
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 11)
            {
                LenNingQi = All.Class.DataReadAndWrite.GetData(dataFile, "LenNingQi");
            }
        }
    }
}
