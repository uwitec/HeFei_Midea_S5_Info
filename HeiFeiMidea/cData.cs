using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace HeiFeiMidea
{
    public class cData
    {
        /// <summary>
        /// 普通设置连接
        /// </summary>
        public All.Class.DataReadAndWrite LocalData
        { get; set; }
        /// <summary>
        /// 报表连接
        /// </summary>
        public All.Class.DataReadAndWrite ReportData
        { get; set; }
        /// <summary>
        /// 刷新连接
        /// </summary>
        public All.Class.DataReadAndWrite ReadData
        { get; set; }
        /// <summary>
        /// 写入数据连接
        /// </summary>
        public All.Class.DataReadAndWrite WriteData
        { get; set; }
        /// <summary>
        /// 注油机数据连接
        /// </summary>
        public All.Class.DataReadAndWrite OilData
        { get; set; }
        /// <summary>
        /// 物料呼叫连接
        /// </summary>
        public All.Class.DataReadAndWrite MaterialData
        { get; set; }
        /// <summary>
        /// 性能检数据连接
        /// </summary>
        public All.Class.DataReadAndWrite TestData
        { get; set; }
        /// <summary>
        /// 性能检实时数据连接
        /// </summary>
        public All.Class.DataReadAndWrite TestDataTmp
        { get; set; }
        /// <summary>
        /// 本地数据方法
        /// </summary>
        public HeiFeiMideaDll.cDataLocal Local
        { get; set; }
        /// <summary>
        /// 刷新时读取数据库方法
        /// </summary>
        public cDataRead Read
        { get; set; }
        /// <summary>
        /// 刷新时写入数据库方法
        /// </summary>
        public cDataWrite Write
        { get; set; }
        /// <summary>
        /// 条码数据
        /// </summary>
        public All.Class.DataReadAndWrite DataBarCode
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
            string dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());

            LocalData = All.Class.DataReadAndWrite.GetData(dataFile, "LocalData");

            ReportData = All.Class.DataReadAndWrite.GetData(dataFile, "ReportData");

            ReadData = All.Class.DataReadAndWrite.GetData(dataFile, "ReadData");

            WriteData = All.Class.DataReadAndWrite.GetData(dataFile, "WriteData");

            DataBarCode = All.Class.DataReadAndWrite.GetData(dataFile, "BarCode");

            Local = new HeiFeiMideaDll.cDataLocal();

            Local.LocalData = LocalData;
            Local.ReadData = ReadData;
            Local.WriteData = WriteData;

            Read = new cDataRead(ReadData);

            Write = new cDataWrite(WriteData);

            All.Class.DataReadAndWrite tmp = All.Class.DataReadAndWrite.GetData(dataFile, "TmpData");
        }
    }
}
