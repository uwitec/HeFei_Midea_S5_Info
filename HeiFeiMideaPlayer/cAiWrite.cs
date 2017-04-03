using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class cAiWrite
    {
        public Illustrator.Application App;
        string fileDirectory = "";
        public delegate void PrintOverOKHandle(string mBarCode,string bBarCode,string mMode);
        public event PrintOverOKHandle PrintOverShangXianOK;
        public delegate void PrintAllOverHandle();
        public event PrintAllOverHandle PrintAllOver;
        public cAiWrite()
        {
            fileDirectory = string.Format("{0}\\PNG\\", All.Class.FileIO.GetNowPath());
            if (System.IO.Directory.Exists(fileDirectory))//如果存在，则删除后重建，用于清空里面数据
            {
                try
                {
                    System.IO.Directory.Delete(fileDirectory, true);
                }
                catch (Exception e)
                {
                    All.Class.Error.Add(e);
                }
            }
            System.IO.Directory.CreateDirectory(fileDirectory);
        }
        class RectangleDouble
        {
            public double Left
            { get; set; }
            public double Top
            { get; set; }
            public double Width
            { get; set; }
            public double Height
            { get; set; }
            public cAiReplace.RegionReplace.RegionList Region
            { get; set; }
            public RectangleDouble(double l, double t, double w, double h,cAiReplace.RegionReplace.RegionList region)
            {
                this.Left = l;
                this.Top = t;
                this.Width = w;
                this.Height = h;
                this.Region = region;
            }
        }
        public void Load()
        {
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 1 ||
                frmMain.mMain.AllDataXml.LocalSettings.TestNo == 9 ||
                frmMain.mMain.AllDataXml.LocalSettings.TestNo == 11)
            {
                System.Diagnostics.Process[] AllProcess = System.Diagnostics.Process.GetProcesses();
                AllProcess.ToList().ForEach(
                    process =>
                    {
                        if (process.ProcessName == "Illustrator")
                        {
                            process.Kill();
                        }
                    }
                );
                System.Threading.Thread.Sleep(1000);
                if (App == null)
                {
                    App = new Illustrator.Application();
                }
            }
        }
        /// <summary>
        /// 手动打印的时候,手动调用打开程序
        /// </summary>
        public void OpenApp()
        {
            if (App == null)
            {
                App = new Illustrator.Application();
            }
        }
        /// <summary>
        /// 打印文件
        /// </summary>
        /// <param name="FileName">原始文件名</param>
        /// <param name="BarCode">美的条码</param>
        /// <param name="JiXing">美的机型</param>
        /// <param name="DingDan">订单名称</param>
        /// <param name="barTime">条码时间</param>
        /// <param name="boshiBarCode">博世条码</param>
        /// <param name="boshiMode">博世机型</param>
        public bool PrintFile(string FileName, string BarCode, string JiXing, string DingDan, string boshiBarCode, string boshiMode, DateTime barTime,string boshiOrder,string waiXiaoBarCode)
        {
            bool result = false;
            if (App == null)
            {
                Load();
            }
            if (App == null)
            {
                frmMain.mMain.AddInfo("当前启动Ai失败，请关闭尝试重启程序");
            }
            //替换字符
            if (frmMain.mMain.AiReplace == null ||
                (frmMain.mMain.AiReplace.RReplace == null && frmMain.mMain.AiReplace.TReplace == null))
            {
                frmMain.mMain.AddInfo("AI文件替换方案不存在，不能找到须要替换的内容");
                return result;
            }
            if ((frmMain.mMain.AiReplace.RReplace == null || frmMain.mMain.AiReplace.RReplace.Count <= 0) &&
               (frmMain.mMain.AiReplace.TReplace == null || frmMain.mMain.AiReplace.TReplace.Count <= 0))
            {
                frmMain.mMain.AiReplace.Load();
            }
            if ((frmMain.mMain.AiReplace.RReplace == null || frmMain.mMain.AiReplace.RReplace.Count <= 0) &&
               (frmMain.mMain.AiReplace.TReplace == null || frmMain.mMain.AiReplace.TReplace.Count <= 0))
            {
                frmMain.mMain.AddInfo("AI文件替换方案为空，不能进行替换指定内容");
                return result;
            }
            try
            {
                //生成二维码
                if (!System.IO.File.Exists(string.Format("{0}\\DEMO{1}.png", fileDirectory, boshiBarCode)) && boshiBarCode.Length > 0)
                {
                    DataMatrix.net.DmtxImageEncoder de = new DataMatrix.net.DmtxImageEncoder();
                    DataMatrix.net.DmtxImageEncoderOptions dme = new DataMatrix.net.DmtxImageEncoderOptions();
                    dme.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAscii;
                    dme.MarginSize = 0;
                    dme.SizeIdx = DataMatrix.net.DmtxSymbolSize.DmtxSymbol16x36;
                    Image datamatrix = de.EncodeImage(string.Format("DEMO{0}", boshiBarCode), dme);
                    datamatrix.Save(string.Format("{0}\\DEMO{1}.png", fileDirectory, boshiBarCode), System.Drawing.Imaging.ImageFormat.Png);
                    datamatrix.Dispose();
                    dme = null;
                    de = null;
                }
                //生成条码
                ZXing.BarcodeWriter bw;
                ZXing.Common.EncodingOptions eo;
                //生成美的条码
                if (!System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, BarCode)) && BarCode.Length > 0)
                {
                    bw = new ZXing.BarcodeWriter();
                    bw.Format = ZXing.BarcodeFormat.CODE_128;
                    eo = new ZXing.Common.EncodingOptions();
                    eo.PureBarcode = true;
                    eo.Width = 45;
                    eo.Height = 20;
                    eo.Margin = 0;
                    bw.Options = eo;
                    bw.Write(BarCode).Save(string.Format("{0}\\{1}.png", fileDirectory, BarCode));
                }
                //生成博世条码
                if (!System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, boshiBarCode)) && boshiBarCode.Length > 0)
                {
                    bw = new ZXing.BarcodeWriter();
                    bw.Format = ZXing.BarcodeFormat.CODE_128;
                    eo = new ZXing.Common.EncodingOptions();
                    eo.PureBarcode = true;
                    eo.Width = 45;
                    eo.Height = 20;
                    eo.Margin = 0;
                    bw.Options = eo;
                    bw.Write(boshiBarCode).Save(string.Format("{0}\\{1}.png", fileDirectory, boshiBarCode));
                }
                //生成美的出口条码
                if (!System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, waiXiaoBarCode)) && waiXiaoBarCode.Length > 0)
                {
                    bw = new ZXing.BarcodeWriter();
                    bw.Format = ZXing.BarcodeFormat.CODE_128;
                    eo = new ZXing.Common.EncodingOptions();
                    eo.PureBarcode = true;
                    eo.Width = 45;
                    eo.Height = 20;
                    eo.Margin = 0;
                    bw.Options = eo;
                    bw.Write(waiXiaoBarCode).Save(string.Format("{0}\\{1}.png", fileDirectory, waiXiaoBarCode));
                }
                //打开AI进行替换文件
                Illustrator.Document doc = App.Open(FileName, Illustrator.AiDocumentColorSpace.aiDocumentRGBColor,null);
                if (doc == null)
                {
                    frmMain.mMain.AddInfo(string.Format("打开指定AI文件{0}失败，无法打印标贴", FileName));
                    return result;
                }
                //替换图形
                Dictionary<int, RectangleDouble> allReplace = new Dictionary<int, RectangleDouble>();
                List<Illustrator.PathItem> allRemovePath = new List<Illustrator.PathItem>();
                int allReplaceIndex = 0;
                if (frmMain.mMain.AiReplace.RReplace != null)
                {
                    double c = 0, m = 0, y = 0, k = 0;
                    foreach (Illustrator.PathItem pi in doc.PathItems)
                    {
                        if (pi.Filled && pi.FillColor != null)
                        {
                            Illustrator.CMYKColor rgb = pi.FillColor as Illustrator.CMYKColor;
                            if (rgb != null)
                            {
                                c = Convert.ToInt16(rgb.Cyan);
                                m = Convert.ToInt16(rgb.Magenta);
                                y = Convert.ToInt16(rgb.Yellow);
                                k = Convert.ToInt16(rgb.Black);
                                for (int i = 0; i < frmMain.mMain.AiReplace.RReplace.Count; i++)
                                {
                                    if (c == frmMain.mMain.AiReplace.RReplace[i].CValue &&
                                        m == frmMain.mMain.AiReplace.RReplace[i].MValue &&
                                        y == frmMain.mMain.AiReplace.RReplace[i].YValue &&
                                        k == frmMain.mMain.AiReplace.RReplace[i].KValue)
                                    {
                                        allReplace.Add(allReplaceIndex, new RectangleDouble(pi.Left, pi.Top, pi.Width, pi.Height,frmMain.mMain.AiReplace.RReplace[i].NewRegion));
                                        allReplaceIndex++;
                                        allRemovePath.Add(pi);
                                        break;
                                    }
                                }
                                if (allReplaceIndex > 0 && frmMain.mMain.AllDataXml.LocalSettings.TestNo == 9)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    allRemovePath.ForEach(//删除所有原始路径
                        path =>
                        {
                            path.Delete();
                        });
                    for (int i = 0; i < allReplaceIndex; i++)
                    {
                        if (allReplace.ContainsKey(i))
                        {
                            Illustrator.PlacedItem placeitem = doc.PlacedItems.Add();
                            switch (allReplace[i].Region)
                            {
                                case cAiReplace.RegionReplace.RegionList.博世条码:
                                    if (System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, boshiBarCode)))
                                    {
                                        placeitem.File = string.Format("{0}\\{1}.png", fileDirectory, boshiBarCode);
                                    }
                                    break;
                                case cAiReplace.RegionReplace.RegionList.美的条码:
                                    if (System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, BarCode)))
                                    {
                                        placeitem.File = string.Format("{0}\\{1}.png", fileDirectory, BarCode);
                                    }
                                    break;
                                case cAiReplace.RegionReplace.RegionList.二维码:
                                    if (System.IO.File.Exists(string.Format("{0}\\DEMO{1}.png", fileDirectory, boshiBarCode)))
                                    {
                                        placeitem.File = string.Format("{0}\\DEMO{1}.png", fileDirectory, boshiBarCode);
                                    }
                                    break;
                                case cAiReplace.RegionReplace.RegionList.出口条码:
                                    if (System.IO.File.Exists(string.Format("{0}\\{1}.png", fileDirectory, waiXiaoBarCode)))
                                    {
                                        placeitem.File = string.Format("{0}\\{1}.png", fileDirectory, waiXiaoBarCode);
                                    }
                                    break;
                            }
                            placeitem.Left = allReplace[i].Left;
                            placeitem.Top = allReplace[i].Top;
                            placeitem.Width = allReplace[i].Width;
                            placeitem.Height = allReplace[i].Height;
                            placeitem.Embed();
                        }
                    }
                }
                //替换文本
                if (frmMain.mMain.AiReplace.TReplace != null)
                {
                    foreach (Illustrator.TextFrame tf in doc.TextFrames)
                    {
                        Console.WriteLine(tf.Contents);
                        for (int i = 0; i < frmMain.mMain.AiReplace.TReplace.Count; i++)
                        {
                            if (tf.Contents != null && tf.Contents == frmMain.mMain.AiReplace.TReplace[i].OldText)
                            {
                                switch (frmMain.mMain.AiReplace.TReplace[i].NewText)
                                {
                                    case cAiReplace.TextReplace.TextList.订单_订单名称:
                                        tf.Contents = DingDan;
                                        break;
                                    case cAiReplace.TextReplace.TextList.机型_博世机型:
                                        tf.Contents = boshiMode;
                                        break;
                                    case cAiReplace.TextReplace.TextList.机型_美的机型:
                                        tf.Contents = JiXing;
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_3位博世日期:
                                        tf.Contents = All.Class.BoShi.GetBoShiTime(barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_年年:
                                        tf.Contents = string.Format("{0:yy}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_年年年年:
                                        tf.Contents = string.Format("{0:yyyy}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_年年年年月月日日:
                                        tf.Contents = string.Format("{0:yyyyMMdd}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_年年月月:
                                        tf.Contents = string.Format("{0:yyMM}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_日日:
                                        tf.Contents = string.Format("{0:dd}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_月:
                                        tf.Contents = string.Format("{0:X}", barTime.Month);
                                        break;
                                    case cAiReplace.TextReplace.TextList.日期_月月:
                                        tf.Contents = string.Format("{0:MM}", barTime);
                                        break;
                                    case cAiReplace.TextReplace.TextList.条码_博世条码:
                                        tf.Contents = boshiBarCode;
                                        break;
                                    case cAiReplace.TextReplace.TextList.条码_美的条码:
                                        tf.Contents = BarCode;
                                        break;
                                    case cAiReplace.TextReplace.TextList.订单_出口订单名称:
                                        tf.Contents = boshiOrder;
                                        break;
                                    case cAiReplace.TextReplace.TextList.条码_美的出口条码:
                                        tf.Contents = waiXiaoBarCode;
                                        break;
                                }
                                break;
                            }
                        }
                    }
                }
                doc.SaveAs(string.Format("{0}\\{1}.Ai", fileDirectory, boshiBarCode));
                doc.PrintOut();
                doc.Close(Illustrator.AiSaveOptions.aiDoNotSaveChanges);
                doc = null;
                result = true;
            }
            catch (Exception e)
            {
                result = false;
                frmMain.mMain.AddInfo("打印标贴失败，请稍后重新尝试");
                All.Class.Error.Add(e);
            }
            return result;
        }
        /// <summary>
        /// 为了实现补打功能，所有打印从条码开始反算
        /// </summary>
        /// <param name="barCode"></param>
        public void PrintBar(string barCode,HeiFeiMideaDll.cMain.AllComputerList computer)
        {
            new System.Threading.Thread(() => RunPrint(barCode, computer))
            {
                IsBackground = true,
                Priority = System.Threading.ThreadPriority.AboveNormal

            }
            .Start();
        }
        /// <summary>
        /// 多线程打印图形
        /// </summary>
        /// <param name="mBarCode"></param>
        private void RunPrint(string mBarCode, HeiFeiMideaDll.cMain.AllComputerList computer)
        {
            All.Class.Error.Add("RunPrint");
            switch (computer)
            {
                case HeiFeiMideaDll.cMain.AllComputerList.上线:
                    RunPrintInLine(mBarCode);
                    if (PrintAllOver != null)
                    {
                        PrintAllOver();
                    }
                    break;
                case HeiFeiMideaDll.cMain.AllComputerList.影像检:
                    RunPrintYinXiang(mBarCode);
                    break;
                case HeiFeiMideaDll.cMain.AllComputerList.折弯机:
                    if (mBarCode.Length > 12)
                    {
                        RunPrintZheWang(mBarCode, mBarCode.Substring(0, mBarCode.Length - 12));
                    }
                    break;
            }
        }
        private void RunPrintZheWang(string mBarCode,string mMode)
        {
            string curFile = string.Format("{0}\\AI\\{1}", cMain.MediaFile, "ZheWang.AI");
            if (!System.IO.File.Exists(curFile))
            {
                DownLoad("ZheWang.AI", "AI");
            }
            else
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(curFile);
                long localLast = fi.Length;
                fi = null;
                long remotLast = All.Class.DownLoadFile.FtpFileLength(string.Format("{0}//AI//{1}", cMain.RemotFtp, "ZheWang.AI"), "", "");
                if (localLast != remotLast)
                {
                    DownLoad("ZheWang.AI", "AI");
                }
            }
            if (!System.IO.File.Exists(curFile))
            {
                frmMain.mMain.AddInfo("下载AI文件失败，无法打印标贴");
                return;
            }
            frmMain.mMain.AiWrite.PrintFile(curFile, mBarCode, mMode, "", "", "", DateTime.Now, "", "");
        }
        private void RunPrintInLine(string mBarCode)
        {
            All.Class.Error.Add("RunPrintInLine");
            string orderName = "";
            string mModeName = "";
            string bModeName = "";
            string bBarCode = "";
            bool FindFromOld = false;
            string printFile = "InLine.AI";
            DateTime printTime = DateTime.Now;
            string bID = "";
            if (mBarCode.Length != 22)
            {
                frmMain.mMain.AddInfo("当前条码长度不正确，不能进行打印");
                return;
            }
            switch (All.Class.MideaBarCode.GetMachine(mBarCode))
            {
                case All.Class.MideaBarCode.MachineLists.内销:
                    printFile = "InLine.AI";
                    break;
                case All.Class.MideaBarCode.MachineLists.外销:
                    printFile = "InLine2.AI";
                    break;
            }
            All.Class.Error.Add("RunPrintInLine_BeginGetCode");
            string tmpSetBarCode = All.Class.MideaBarCode.GetPadFromBar(mBarCode);
            int tmpBarCodeIndex = All.Class.MideaBarCode.GetIndexFromBar(mBarCode);
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from SetOrder where BarCode='{0}' and BarStart<={1} and BarEnd>={1}", tmpSetBarCode, tmpBarCodeIndex)))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AddInfo("没有找到当前条码对应的订单信息，不能进行打印");
                    return;
                }
                orderName = All.Class.Num.ToString(dt.Rows[0]["OrderName"]);
                if (All.Class.Num.ToString(dt.Rows[0]["BoShi"]) != "博世")
                {
                    frmMain.mMain.AddInfo("当前订单设置不是博世订单，不能进行打印");
                    return;
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from SetMode where ModeID='{0}'",All.Class.MideaBarCode.GetModeFromBar( mBarCode))))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AddInfo("没有找到当前条码对应的机型信息，不能进行打印");
                    return;
                }
                mModeName = All.Class.Num.ToString(dt.Rows[0]["Mode"]);
            }
            All.Class.Error.Add("RunPrintInLine_BeginDownLoad");
            string curFile = string.Format("{0}\\AI\\{1}", cMain.MediaFile, printFile);
            if (!System.IO.File.Exists(curFile))
            {
                DownLoad(printFile, "AI");
            }
            else
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(curFile);
                long localLast = fi.Length;
                fi = null;
                long remotLast = All.Class.DownLoadFile.FtpFileLength(string.Format("{0}//AI//{1}", cMain.RemotFtp, printFile), "", "");
                if (localLast != remotLast)
                {
                    DownLoad(printFile, "AI");
                }
            }
            All.Class.Error.Add("RunPrintInLine_DownLoadOver");
            if (!System.IO.File.Exists(curFile))
            {
                frmMain.mMain.AddInfo("下载AI文件失败，无法打印标贴");
                return;
            }
            All.Class.Error.Add("RunPrintInLine_Midea2BoShi_Start");
            frmMain.mMain.AllDataXml.Midea2BoShi.Midea2BoShi(mBarCode, HeiFeiMideaDll.cMain.AllComputerList.上线, out printTime, out bBarCode, out bModeName, out bID, out FindFromOld);
            if (bBarCode == "")
            {
                return;
            }
            All.Class.Error.Add("RunPrintInLine_Midea2BoShi_End");
            if (bBarCode.Length != 26)
            {
                frmMain.mMain.AddInfo("转换后，博世条码不正确，请检查程序");
                return;
            }
            All.Class.Error.Add("RunPrintInLine_BeginPrint");
            if (frmMain.mMain.AiWrite.PrintFile(curFile, mBarCode, mModeName, orderName, bBarCode, bModeName, printTime, All.Class.BoShi.WaiXiaoOrderChange(orderName),
                All.Class.MideaBarCode.WaiXiaoBarChange(mBarCode, orderName)))
            {
                All.Class.Error.Add("RunPrintInLine_PrintOk");
                if (!FindFromOld)//不是找到的已存在的，则添加序号，如果是找到的之前存在的，则不用添加
                {
                    frmMain.mMain.AllDataXml.LocalBoShis.Add(printTime, bID);
                }
                if (PrintOverShangXianOK != null)
                {
                    PrintOverShangXianOK(mBarCode, bBarCode, mModeName);
                }
            }
        }
        private void RunPrintYinXiang(string mBarCode)
        {
            bool FindFromOld = false;
            string orderName = "";
            string mModeName = "";
            string bModeName = "";
            string bBarCode = "";
            string printFile = "";
            DateTime printTime = DateTime.Now;
            string bID = "";
            if (mBarCode == "")//空车跳过
            {
                return;
            }
            if (mBarCode.Length != 22)
            {
                frmMain.mMain.AddInfo("当前条码长度不正确，不能进行打印");
                return;
            }
            string tmpSetBarCode = All.Class.MideaBarCode.GetPadFromBar(mBarCode);
            int tmpBarCodeIndex = All.Class.MideaBarCode.GetIndexFromBar(mBarCode);
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from SetOrder where BarCode='{0}' and BarStart<={1} and BarEnd>={1}", tmpSetBarCode, tmpBarCodeIndex)))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AddInfo("没有找到当前条码对应的订单信息，不能进行打印");
                    return;
                }
                orderName = All.Class.Num.ToString(dt.Rows[0]["OrderName"]);
                printFile = All.Class.Num.ToString(dt.Rows[0]["PrintFile"]);
                if (All.Class.Num.ToString(dt.Rows[0]["BoShi"]) != "博世")
                {
                    frmMain.mMain.AddInfo("当前订单设置不是博世订单，跳过标贴打印");
                    return;
                }
                if (printFile == "")
                {
                    frmMain.mMain.AddInfo("当前订单指定的AI文件为空，不能进行打印");
                    return;
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from SetMode where ModeID='{0}'", All.Class.MideaBarCode.GetModeFromBar(mBarCode))))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AddInfo("没有找到当前条码对应的机型信息，不能进行打印");
                    return;
                }
                mModeName = All.Class.Num.ToString(dt.Rows[0]["Mode"]);
            }
            string curFile = string.Format("{0}\\AI\\{1}", cMain.MediaFile, printFile);
            if (!System.IO.File.Exists(curFile))
            {
                DownLoad(printFile, "AI");
            }
            else
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(curFile);
                long localLast = fi.Length;
                fi = null;
                long remotLast = All.Class.DownLoadFile.FtpFileLength(string.Format("{0}//AI//{1}", cMain.RemotFtp, printFile), "", "");
                if (localLast != remotLast)
                {
                    DownLoad(printFile, "AI");
                }
            }
            if (!System.IO.File.Exists(curFile))
            {
                frmMain.mMain.AddInfo("下载AI文件失败，无法打印标贴");
                return;
            }
            frmMain.mMain.AllDataXml.Midea2BoShi.Midea2BoShi(mBarCode, HeiFeiMideaDll.cMain.AllComputerList.影像检, out printTime, out bBarCode, out bModeName, out bID, out FindFromOld);
            if (bBarCode == "")
            {
                return;
            }
            if (bBarCode.Length != 26)
            {
                frmMain.mMain.AddInfo("转换后，博世条码不正确，请检查程序");
                return;
            }
            frmMain.mMain.AiWrite.PrintFile(curFile, mBarCode, mModeName, orderName, bBarCode, bModeName, printTime, All.Class.BoShi.WaiXiaoOrderChange(orderName),
                All.Class.MideaBarCode.WaiXiaoBarChange(mBarCode, orderName));
                   
        }
        private void DownLoad(string file, string directory)
        {
            All.Class.DownLoadFile.FtpDownLoad(string.Format("{0}//{1}//{2}", cMain.RemotFtp, directory, file), string.Format("{0}\\{1}\\{2}", cMain.MediaFile, directory, file));
        }
    }
}
