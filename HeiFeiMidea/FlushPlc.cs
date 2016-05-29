using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
namespace HeiFeiMidea
{
    public class FlushPlc:All.Class.FlushAll.FlushMethor
    {
        int start = 0;
        DataTable dtStatueCar;
        DataTable dtStatueLineStation;
        DataTable dtStatueLengNinQi;
        DataTable dtStatueOther;
        public override void Load()
        {
            dtStatueCar = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueCar Order by TestNo");
            dtStatueCar.TableName = "StatueCar";
            frmMain.mMain.AllDataBase.Read.FlushAllCarStatue(dtStatueCar,true);

            dtStatueLineStation = frmMain.mMain.AllDataBase.ReadData.Read("select * from  StatueLineStation order by WorkStation");
            dtStatueLineStation.TableName = "StatueLineStation";
            frmMain.mMain.AllDataBase.Read.FlushAllStationStatue(dtStatueLineStation,true);

            dtStatueLengNinQi = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueLengNinQi Order By WorkStation");
            dtStatueLengNinQi.TableName = "StatueLengNinQi";
            frmMain.mMain.AllDataBase.Read.FlushLengNinQi(dtStatueLengNinQi);

            dtStatueOther = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueOther Order by WorkStation");
            dtStatueOther.TableName = "StatueOther";
            frmMain.mMain.AllDataBase.Read.FlushOther(dtStatueOther);
        }

        public override void Flush()
        {
            start = Environment.TickCount;
            string tmpBarCode = "";
            int index = 0;
            bool[] tmpStatue;
            List<int> allLineStation = new List<int>();
            //写小车数据
            allLineStation.Clear();
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllCarCount; i++)
            {
                allLineStation.Add(i + 1);
            }
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllCarCount; i++)
            {
                index = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[i * 5 + 500];
                if (index > 0 && index <= HeiFeiMideaDll.cMain.AllCarCount)
                {
                    allLineStation.Remove(index);
                    dtStatueCar.Rows[index - 1]["WorkStation"] = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[i * 5 + 1 + 500];
                    dtStatueCar.Rows[index - 1]["S0"] = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[i * 5 + 2 + 500];
                    dtStatueCar.Rows[index - 1]["S1"] = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[i * 5 + 3 + 500];
                    dtStatueCar.Rows[index - 1]["E0"] = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[i * 5 + 4 + 500];
                    dtStatueCar.Rows[index - 1]["PrevWorkStation"] = frmMain.mMain.AllMeterData.AllReadValue.UshortValue.OldValue[i * 5 + 500];
                    tmpBarCode=All.Class.Num.GetVisableStr(
                        Encoding.ASCII.GetString(All.Class.Num.Ushort2Byte(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value.ToArray(),
                        650 + i * 15, 15)));
                    dtStatueCar.Rows[index - 1]["BarCode"] = ((tmpBarCode.Length <= 10) ? "" : tmpBarCode);
                }
            }
            for (int i = 0; i < allLineStation.Count; i++)//没有读到的小车，数据清零
            {
                index = allLineStation[i];
                dtStatueCar.Rows[index - 1]["WorkStation"] = 0;
                dtStatueCar.Rows[index - 1]["S0"] = 0;
                dtStatueCar.Rows[index - 1]["S1"] = 0;
                dtStatueCar.Rows[index - 1]["E0"] = 0;
                dtStatueCar.Rows[index - 1]["PrevWorkStation"] = 0;
                dtStatueCar.Rows[index - 1]["BarCode"] = "";
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueCar);
            //读取小车数据
            frmMain.mMain.AllDataBase.Read.FlushAllCarStatue(dtStatueCar,false);


            //写停车工位状态
            allLineStation.Clear();
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
            {
                allLineStation.Add(i + 1);
            }
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllCarCount; i++)
            {
                cCarLocal.StatueLineStation ss = cCarLocal.StatueLineStation.GetStatueFromCar(frmMain.mMain.AllCars.AllStatueCar[i]);
                index = ss.LineStationIndex;
                if (index > 0 && index <= HeiFeiMideaDll.cMain.AllStopStationCount)
                {
                    allLineStation.Remove(index);
                    dtStatueLineStation.Rows[index - 1]["HaveCar"] = ss.HaveCar;
                    dtStatueLineStation.Rows[index - 1]["Error"] = ss.Error;
                    dtStatueLineStation.Rows[index - 1]["HaveMachine"] = ss.HaveMachine ;
                    dtStatueLineStation.Rows[index - 1]["Ok"] = ss.OK;
                    dtStatueLineStation.Rows[index - 1]["CarLevel"] = ss.Level;
                    dtStatueLineStation.Rows[index - 1]["Test"] = ss.Test;
                    dtStatueLineStation.Rows[index - 1]["TestOver"] = ss.TestOver;
                    dtStatueLineStation.Rows[index - 1]["BarCode"] = ss.BarCode;
                }
            }
            for (int i = 0; i < allLineStation.Count; i++)//没有小车的工位，所有数据复位
            {
                index = allLineStation[i];
                dtStatueLineStation.Rows[index - 1]["HaveCar"] = false; ;
                dtStatueLineStation.Rows[index - 1]["Error"] = false; ;
                dtStatueLineStation.Rows[index - 1]["HaveMachine"] = false; ;
                dtStatueLineStation.Rows[index - 1]["Ok"] = true; ;
                dtStatueLineStation.Rows[index - 1]["CarLevel"] = true; ;
                dtStatueLineStation.Rows[index - 1]["Test"] = false;
                dtStatueLineStation.Rows[index - 1]["TestOver"] = true;
                dtStatueLineStation.Rows[index - 1]["BarCode"] = "";
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueLineStation);
            //读停车工位状态
            frmMain.mMain.AllDataBase.Read.FlushAllStationStatue(dtStatueLineStation,false);

            //写冷凝器状态
            tmpStatue = All.Class.Num.Byte2Bool(All.Class.Num.Ushort2Byte(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value.ToArray(), 150, 1));
            frmMain.mMain.AllCars.AllStatueLengNinQi.SetStatue(tmpStatue);
            for (int i = 0, j = 5, k = 107; i < HeiFeiMideaDll.cMain.AllLengNinQiCount; i++, j++, k++)
            {
                dtStatueLengNinQi.Rows[i]["WorkStation"] = frmMain.mMain.AllCars.AllStatueLengNinQi.AllLengNinStation[i].WorkStation;
                dtStatueLengNinQi.Rows[i]["HaveMachine"] = tmpStatue[j];
                dtStatueLengNinQi.Rows[i]["BarCode"] = frmMain.mMain.AllMeterData.AllReadValue.StringValue.Value[k].Trim();
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueLengNinQi);
            //读冷凝器状态
            frmMain.mMain.AllDataBase.Read.FlushLengNinQi(dtStatueLengNinQi);


            //写入其他设备
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllOtherMachineCount; i++)
            {
                cStatueOther so = cStatueOther.GetStatueFromPlc(i + 1, frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[151 + i]);
                dtStatueOther.Rows[i]["Error"] = so.Error;
                dtStatueOther.Rows[i]["Empty"] = so.Empty;
                dtStatueOther.Rows[i]["TestSmall"] = so.TestSmall;
                dtStatueOther.Rows[i]["TestMax"] = so.TestMax;
                dtStatueOther.Rows[i]["Run"] = so.Run;
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueOther);
            //读其他设备状态
            frmMain.mMain.AllDataBase.Read.FlushOther(dtStatueOther);
            //解析压缩机的读取数据
            if ((Environment.TickCount - start) > 1000)
            {
                All.Class.Log.Add(string.Format("警告：FlushPlc.Flush刷新数据库响应时间过长,可能影响数据实时性,响应时间,{0}ms", (Environment.TickCount - start)), Environment.StackTrace);
            }
        }
    }
}
