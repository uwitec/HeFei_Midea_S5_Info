using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class FlushData:All.Class.FlushAll.FlushMethor
    {
        int start = 0;
        DataTable dtStatueTestTime;
        public DataTable dtStatueStation
        { get; set; }
        /// <summary>
        /// 是否清除所有计时
        /// </summary>
        public bool InitAllStopTime
        { get; set; }
        /// <summary>
        /// 是否停止所有计时
        /// </summary>
        public bool StopAllStopTime
        { get; set; }
        public FlushData()
        {
            InitAllStopTime = false;
            StopAllStopTime = false;
        }
        public override void Load()
        {
            dtStatueTestTime = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueTestTime Order by WorkStation");
            dtStatueTestTime.TableName = "StatueTestTime";
            dtStatueStation = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueStation Order By ID");
            dtStatueStation.TableName = "StatueStation";
        }
        public override void Flush()
        {
            start = Environment.TickCount;
            //刷新停机操作时间
            if (InitAllStopTime)//清除所有计时
            {
                InitAllStopTime = false;
                for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
                {
                    dtStatueTestTime.Rows[i]["TestTime"] = 0;
                    dtStatueTestTime.Rows[i]["TimeCount"] = 0;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].TimeCount;
                    dtStatueTestTime.Rows[i]["MinTime"] = 999999;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].MinTime;
                    dtStatueTestTime.Rows[i]["MaxTime"] = 0;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].MaxTime;
                    dtStatueTestTime.Rows[i]["AverageTime"] = 0;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].AverageTime;
                    dtStatueTestTime.Rows[i]["OperaCount"] = 0;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].OperaCount;
                    dtStatueTestTime.Rows[i]["RunTime"] = false;// frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].RunTime;
                }
            }
            frmMain.mMain.AllPCs.AllStatueTestTime.FlushAllTestTime(dtStatueTestTime);
            //写入停机操作时间
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
            {
                frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].FlushLineStationToTestTime(StopAllStopTime, dtStatueTestTime.TableName);
                dtStatueTestTime.Rows[i]["TestTime"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].TestTime;
                dtStatueTestTime.Rows[i]["TimeCount"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].TimeCount;
                dtStatueTestTime.Rows[i]["MinTime"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].MinTime;
                dtStatueTestTime.Rows[i]["MaxTime"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].MaxTime;
                dtStatueTestTime.Rows[i]["AverageTime"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].AverageTime;
                dtStatueTestTime.Rows[i]["OperaCount"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].OperaCount;
                dtStatueTestTime.Rows[i]["RunTime"] = frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].RunTime;
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueTestTime);
            //刷新工位
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllComputerShowCount; i++)
            {
                dtStatueStation.Rows[i]["WorkStation"] = frmMain.mMain.AllCars.AllStatueStation[i].WorkStation;
                dtStatueStation.Rows[i]["LineWorkStation"] = frmMain.mMain.AllCars.AllStatueStation[i].LineWorkStation;
                dtStatueStation.Rows[i]["BarCode"] = frmMain.mMain.AllCars.AllStatueStation[i].BarCode;
                dtStatueStation.Rows[i]["TestTime"] = frmMain.mMain.AllCars.AllStatueStation[i].TestTime;
                dtStatueStation.Rows[i]["OrderName"] = frmMain.mMain.AllCars.AllStatueStation[i].OrderName;
                dtStatueStation.Rows[i]["OrderMode"] = frmMain.mMain.AllCars.AllStatueStation[i].OrderMode;
                dtStatueStation.Rows[i]["TestResult"] = frmMain.mMain.AllCars.AllStatueStation[i].TestResult;
                dtStatueStation.Rows[i]["ModeID"] = frmMain.mMain.AllCars.AllStatueStation[i].ModeID;
                if (frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[63 + i] != "")
                {
                    dtStatueStation.Rows[i]["UserName"] = frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[63 + i];
                }
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueStation);
            if ((Environment.TickCount - start) > 1000)
            {
                All.Class.Log.Add(string.Format("警告：FlushData.Flush刷新数据库响应时间过长,可能影响数据实时性,响应时间,{0}ms", (Environment.TickCount - start)), Environment.StackTrace);
            }
        }
    }
}
