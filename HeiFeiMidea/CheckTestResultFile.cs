using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HeiFeiMidea
{
    public static class CheckTestResultFile
    {
        /// <summary>
        /// 数据文件路径
        /// </summary>
        public static string DirectoryFile = string.Format("{0}\\Data\\TestData\\", All.Class.FileIO.GetNowPath());
        public static string DataFile = string.Format("{0}\\Data\\", All.Class.FileIO.GetNowPath());
        public const string TestDirectoryName = "TestFile";
        public const string LenNingDirectoryName = "LenNingFile";

        public static void CheckDirectory()
        {
            if (!Directory.Exists(DirectoryFile))
            {
                Directory.CreateDirectory(DirectoryFile);
            }
            if (!Directory.Exists(string.Format("{0}\\{1}\\", DirectoryFile, TestDirectoryName)))
            {
                Directory.CreateDirectory(string.Format("{0}\\{1}\\", DirectoryFile, TestDirectoryName));
            }
            if (!Directory.Exists(string.Format("{0}\\{1}\\", DirectoryFile, LenNingDirectoryName)))
            {
                Directory.CreateDirectory(string.Format("{0}\\{1}\\", DirectoryFile, LenNingDirectoryName));
            }
        }
        public static string CheckLenNingFile(string barcode)
        {
            string tmpBarcode = "";
            barcode = All.Class.Num.GetVisableStr(barcode);
            barcode.Replace("\\", "");
            barcode.Replace("/","");
            barcode.Replace("<", "");
            barcode.Replace(">", "");
            barcode.Replace("|", "");
            barcode.Replace("\"", "");
            barcode.Replace(":", "");
            barcode.Replace("?", "");
            barcode.Replace("*", "");
            if (barcode == "")
            {
                return "";
            }
            try
            {
                CheckDirectory();
                //条码路径
                tmpBarcode = string.Format("{0}\\{1}\\{2}", DirectoryFile, LenNingDirectoryName, barcode);
                if (!Directory.Exists(tmpBarcode))
                {
                    Directory.CreateDirectory(tmpBarcode);
                }
                //检测是否已拷贝文件
                if (!File.Exists(string.Format("{0}\\AllLenNingValue.sdf", tmpBarcode)))
                {
                    File.Copy(string.Format("{0}\\AllLenNingValue.sdf", DataFile), string.Format("{0}\\AllLenNingValue.sdf", tmpBarcode));
                }
            }
            catch (Exception e)
            {
                All.Class.Error.Add(e);
                All.Class.Error.Add(barcode,e.StackTrace);
                All.Class.Error.Add(string.Format("更新条码:{0}", tmpBarcode),e.StackTrace);
            }
            return tmpBarcode;
        }
        public static string CheckTestFile(string barcode)
        {
            string tmpBarcode = "";
            barcode = All.Class.Num.GetVisableStr(barcode);
            barcode.Replace("\\", "");
            barcode.Replace("/","");
            barcode.Replace("<", "");
            barcode.Replace(">", "");
            barcode.Replace("|", "");
            barcode.Replace("\"", "");
            barcode.Replace(":", "");
            barcode.Replace("?", "");
            barcode.Replace("*", "");
            if (barcode == "")
            {
                return "";
            }
            try
            {
                CheckDirectory();
                //条码路径
                tmpBarcode = string.Format("{0}\\{1}\\{2}", DirectoryFile, TestDirectoryName, barcode);
                if (!Directory.Exists(tmpBarcode))
                {
                    Directory.CreateDirectory(tmpBarcode);
                }
                //检测是否已拷贝文件
                if (!File.Exists(string.Format("{0}\\AllTestValue.sdf", tmpBarcode)))
                {
                    File.Copy(string.Format("{0}\\AllTestValue.sdf", DataFile), string.Format("{0}\\AllTestValue.sdf", tmpBarcode));
                }
            }
            catch (Exception e)
            {
                All.Class.Error.Add(e);
                All.Class.Error.Add(barcode, e.StackTrace);
                All.Class.Error.Add(string.Format("更新条码:{0}", tmpBarcode), e.StackTrace);
            }
            return tmpBarcode;
        }
        /// <summary>
        /// 添加操作记录
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="userName"></param>
        /// <param name="workStation"></param>
        //public void AddTestResult(string barcode, FlushTestResult.AddTestResult.TestResult.AllValue testResult)
        //{
        //    string curBarcode = barcode;// All.Class.Num.GetVisableHex(barcode);
        //    if (curBarcode == "")
        //    {
        //        return;
        //    }
        //    All.Class.Sqlce sql = new All.Class.Sqlce();

        //    switch(testResult.WorkStation)
        //    {
        //        case 11:
        //            CheckLenNingFile(curBarcode);
        //            if (!sql.Login(string.Format("{0}\\{1}\\{2}\\", DirectoryFile, LenNingDirectoryName, curBarcode), "AllLenNingValue.sdf", "", ""))
        //            {
        //                return;
        //            }
        //            sql.Write(string.Format("insert into TestAnZhuang values({0},'{1}','{2}','{3:yyyy-MM-dd HH:mm:ss}')",
        //                testResult.WorkStation, frmMain.mMain.AllCars.AllInfoStation[testResult.WorkStation].StationName,testResult.UserName, testResult.TestTime));
        //            break;
        //        default:
        //            CheckTestFile(curBarcode);
        //            if (!sql.Login(string.Format("{0}\\{1}\\{2}\\", DirectoryFile, TestDirectoryName, curBarcode), "AllTestValue.sdf", "", ""))
        //            {
        //                return;
        //            }
        //            sql.Write(string.Format("insert into TestAnZhuang values({0},'{1}','{2}','{3:yyyy-MM-dd HH:mm:ss}')",
        //                testResult.WorkStation, frmMain.mMain.AllCars.AllInfoStation[testResult.WorkStation].StationName, testResult.UserName, testResult.TestTime));
        //            break;
        //    }
        }
}
