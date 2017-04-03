using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HeiFeiMidea
{
    public class cDataWrite
    {
        /// <summary>
        /// 刷新读取操作数据库连接
        /// </summary>
        public All.Class.DataReadAndWrite WriteData
        { get; set; }

        public cDataWrite(All.Class.DataReadAndWrite writeData)
        {
            this.WriteData = writeData;
        }
        /// <summary>
        /// 清除当天小时产量，打开软件时间与上一次打开时间超过24小时触发
        /// </summary>
        public bool ClearAllCountPerHour()
        {
            bool result = true;
            result = result && (WriteData.Write("update StatueCountPerHour Set OutLineCount=0 ,InLineCount=0 ,OutLineHourUp=0,UseNow='False' where Hour<9 or Hour>18") >= 0);
            result = result && (WriteData.Write("update StatueCountPerHour Set OutLineCount=0 ,InLineCount=0 ,OutLineHourDown=0,UseNow='True' where Hour>=9 and Hour<=18") >= 0);
            return result;
        }
        /// <summary>
        /// 清除所有登陆用户，打开软件时间与上一次打开时间超过24小时触发
        /// </summary>
        public bool ClearAllUser()
        {
            bool result = true;
            result = result && (WriteData.Write("update InfoLineStation Set UserName=''") >= 0);
            result = result && (WriteData.Write("update InfoLengNinStation Set UserName=''") >= 0);
            return result;
        }
        /// <summary>
        /// 清除当天OEE所有数据
        /// </summary>
        public bool ClearOEE()
        {
            return WriteData.Write("delete from StatueOEE") >= 0;
        }
        /// <summary>
        /// 清除所临时故障，打开软件时间与上一次打开时间超过24小时触发
        /// </summary>
        public void ClearAllTmpError()
        {
            WriteData.Write("delete from StatueErrorAllTmp");
        }
        /// <summary>
        /// 添加一台产量，下线工位打印条码时触发，在停车工位状态改变处触发
        /// </summary>
        public void AddOutLineCountPerHour(string barCode)
        {
            WriteData.Write(string.Format("update TestAll Set OutLine='true',InLineTime='{0:yyyy-MM-dd HH:mm:ss}',TestYear={0:yyyy},TestMonth={0:MM},TestDay={0:dd},TestHour={0:HH} where BarCode='{1}'", DateTime.Now, barCode));
            frmMain.mMain.FlushOEE.AddCount();
            if (frmMain.mMain.AllPCs.AllCountPerHour == null
                || frmMain.mMain.AllPCs.AllCountPerHour.AllHour.Length != 24)
            {
                return;
            }
            DateTime time = DateTime.Now;
            WriteData.Write(string.Format("update StatueCountPerHour Set OutLineCount={0},UseNow='True',OutLineHourUp={1},OutLineHourDown={2} where Hour={3}",
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[time.Hour].OutLineCount + 1,
                (time.Minute < 30 ?
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[time.Hour].OutLineHourUp + 1 :
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[time.Hour].OutLineHourUp),
                (time.Minute >= 30 ?
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[time.Hour].OutLineHourDown + 1 :
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[time.Hour].OutLineHourDown),
                time.Hour));
         }
        /// <summary>
        /// 添加一台上线，上线工位打印条码时触发,在小车状态改变处触发
        /// </summary>
        public void AddInLineCountPerHour()
        {
            if (frmMain.mMain.AllPCs.AllCountPerHour == null
                || frmMain.mMain.AllPCs.AllCountPerHour.AllHour.Length != 24)
            {
                return;
            }
            int hour = DateTime.Now.Hour;
            WriteData.Write(string.Format("update StatueCountPerHour Set InLineCount={0},UseNow='True' where Hour={1}",
                frmMain.mMain.AllPCs.AllCountPerHour.AllHour[hour].InLineCount + 1, hour));

        }
        /// <summary>
        /// 绑定冷凝器条码与主条码
        /// </summary>
        public void BindTwoBar(string lengNingBarCode)
        {
            WriteData.Write(string.Format("update TestAll Set InLineTime='{0:yyyy-MM-dd HH:mm:ss}',TestYear={0:yyyy},TestMonth={0:MM},TestDay={0:dd},TestHour={0:dd},LenNingCode='{1}',OutLine='false' where BarCode='{2}'", DateTime.Now, lengNingBarCode, frmMain.mMain.AllCars.AllStatueStation[12].BarCode));
        }
        /// <summary>
        /// 添加一条条码上线记录
        /// </summary>
        /// <param name="workStation"></param>
        public void AddInLine(int workStation,string mideaCode,string boShiCode,string mode,string orderName)
        {
            //添加上线记录
            WriteData.Write(string.Format("delete from TestAll Where BarCode='{0}' and orderName='{1}'", mideaCode, orderName));

            WriteData.Write(string.Format("insert into TestAll (orderName,BarCode,InLineTime,LenNingCode,TestYear,TestMonth,TestDay,TestHour,OutLine,BoShiBarCode) values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}',{2:yyyy},{2:MM},{2:dd},{2:HH},'false','{4}')",
                orderName, mideaCode, DateTime.Now, "", boShiCode));
            //添加打印记录

            frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("delete from PrintMachine where BarCode='{0}'", mideaCode));

            frmMain.mMain.AllDataBase.Local.WriteData.Write(string.Format("insert into PrintMachine (orderName,BarCode,InLineTime,Mode,TestYear,TestMonth,TestDay) values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}','{3}',{2:yyyy},{2:MM},{2:dd})",
                orderName, mideaCode, DateTime.Now, ""));
            
        }
    }
}
