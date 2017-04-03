using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class FlushStationTestTime:All.Class.FlushAll.FlushMethor
    {
        DataTable InfoStationTestTime
        { get; set; }
        public override void Load()
        {
            DateTime lastTime = frmMain.mMain.AllDataXml.LocalSet.TodayStart;
            //检查日期
            using (DataTable dt = frmMain.mMain.AllDataBase.TestTimeData.Read("select * from TodayTime"))
            {
                if (dt == null || dt.Rows.Count <= 0)
                {
                    frmMain.mMain.AllDataBase.TestTimeData.Write(string.Format("insert into TodayTime values(#{0:yyyy-MM-dd HH:mm:ss}#)",
                        frmMain.mMain.AllDataXml.LocalSet.TodayStart));
                }
                else
                {
                    lastTime = All.Class.Num.ToDateTime(dt.Rows[0]["TestTime"]);
                    if (lastTime.Year != frmMain.mMain.AllDataXml.LocalSet.TodayStart.Year ||
                        lastTime.Month != frmMain.mMain.AllDataXml.LocalSet.TodayStart.Month ||
                        lastTime.Day != frmMain.mMain.AllDataXml.LocalSet.TodayStart.Day)
                    {
                        frmMain.mMain.AllDataBase.TestTimeData.Write(string.Format("update TodayTime Set TestTime=#{0:yyyy-MM-dd HH:mm:ss}#", frmMain.mMain.AllDataXml.LocalSet.TodayStart));
                    }
                }
            }
            //检查数据
            InfoStationTestTime = frmMain.mMain.AllDataBase.TestTimeData.Read("select * from tmpInfoStationTestTime order by WorkStation");
            if (InfoStationTestTime == null || InfoStationTestTime.Rows.Count != HeiFeiMideaDll.cMain.AllStopStationCount)
            {
                InfoStationTestTime = new DataTable("tmpInfoStationTestTime");
                InfoStationTestTime.Columns.Add("WorkStation", typeof(int));
                InfoStationTestTime.Columns.Add("StationName", typeof(string));
                InfoStationTestTime.Columns.Add("TimeCount", typeof(int));
                InfoStationTestTime.Columns.Add("OperaCount", typeof(int));
                DataRow dr;
                for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
                {
                    dr = InfoStationTestTime.NewRow();
                    dr["WorkStation"] = i + 1;
                    dr["StationName"] = frmMain.mMain.AllCars.AllInfoLineStation[i].StationName;
                    dr["TimeCount"] = 0;
                    dr["OperaCount"] = 0;
                    InfoStationTestTime.Rows.Add(dr);
                }
            }
            else
            {
                if (lastTime != frmMain.mMain.AllDataXml.LocalSet.TodayStart)//日期不是最新,则更新数据库
                {
                    for (int i = 0; i < InfoStationTestTime.Rows.Count; i++)
                    {
                        if (frmMain.mMain.AllCars.AllInfoLineStation[i].TestStation)
                        {
                            frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into AllTestStationTime (TestTime,TestYear,TestMonth,TestDay,WorkStation,StationName,TimeCount,OperaCount) values('{0:yyyy-MM-dd HH:mm:ss}',{0:yyyy},{0:MM},{0:dd},{1},'{2}',{3},{4})",
                                lastTime, InfoStationTestTime.Rows[i]["WorkStation"], InfoStationTestTime.Rows[i]["StationName"],
                                InfoStationTestTime.Rows[i]["TimeCount"], InfoStationTestTime.Rows[i]["OperaCount"]));
                        }
                        InfoStationTestTime.Rows[i]["TimeCount"] = 0;
                        InfoStationTestTime.Rows[i]["OperaCount"] = 0;
                    }
                }
            }
            InfoStationTestTime.TableName = "tmpInfoStationTestTime";
            frmMain.mMain.AllPCs.AllStatueTestTime.HaveTestMachine += AllStatueTestTime_HaveTestMachine;
        }

        private void AllStatueTestTime_HaveTestMachine(DateTime arg1, int arg2, int arg3, string arg4)
        {
            frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into AllTestStationTimeEveryHour (TestTime,UseTime,WorkStation,StationName) values('{0:yyyy-MM-dd HH:mm:ss}',{1},{2},'{3}')",
                arg1, arg2, arg3, arg4));
        }
        public override void Flush()
        {
            frmMain.mMain.AllPCs.AllStatueTestTime.FlushTodayTestTime(InfoStationTestTime);
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
            {
                frmMain.mMain.AllPCs.AllStatueTestTime.TodayStatueTestTime[i].FlushLineStationToTestTime(frmMain.mMain.FlushData.StopAllStopTime,InfoStationTestTime.TableName);
                InfoStationTestTime.Rows[i]["TimeCount"] = frmMain.mMain.AllPCs.AllStatueTestTime.TodayStatueTestTime[i].TimeCount;
                InfoStationTestTime.Rows[i]["OperaCount"] = frmMain.mMain.AllPCs.AllStatueTestTime.TodayStatueTestTime[i].OperaCount;
            }
            frmMain.mMain.AllDataBase.TestTimeData.BlockCommand(InfoStationTestTime);
        }
    }
}
