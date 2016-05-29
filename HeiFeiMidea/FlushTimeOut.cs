using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新所有工位的超时
    /// </summary>
    public class FlushTimeOut : All.Class.FlushAll.FlushMethor
    {
        public StatueTimeOut[] AllStatueTimeOut
        { get; set; }
        DataTable dtStatueTimeOut;
        public FlushTimeOut()
        {
            AllStatueTimeOut = new StatueTimeOut[HeiFeiMideaDll.cMain.AllStopStationCount];
            for (int i = 0; i < AllStatueTimeOut.Length; i++)
            {
                AllStatueTimeOut[i] = new StatueTimeOut(i + 1, false);
            }
        }
        public override void Flush()
        {
            DataToClass(dtStatueTimeOut,false);
            for (int i = 0; i < AllStatueTimeOut.Length; i++)
            {
                dtStatueTimeOut.Rows[i]["Statue"] = (frmMain.mMain.AllPCs.AllStatueTestTime.AllStatueTestTime[i].TestTime > frmMain.mMain.AllCars.AllInfoLineStation[i].TimeOut);
            }
            frmMain.mMain.AllDataBase.WriteData.BlockCommand(dtStatueTimeOut);
        }
        private void DataToClass(DataTable dt,bool Init)
        {
            if (dt == null || dt.Rows.Count != AllStatueTimeOut.Length)
            {
                return;
            }
            int workStation = 0;
            bool statue = false;
            for (int i = 0; i < AllStatueTimeOut.Length; i++)
            {
                workStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                statue = All.Class.Num.ToBool(dt.Rows[i]["Statue"]);
                if ((i + 1) == workStation)
                {
                    AllStatueTimeOut[i].SetStatue(statue,Init);
                }
                else
                {
                    All.Class.Log.Add("StatueTimeOut表中的停车工位序号不正确", Environment.StackTrace);
                }
            }
        }
        public override void Load()
        {
            using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read("select WorkStation From StatueTimeOut Order by WorkStation"))
            {
                if (dt == null || dt.Rows.Count != AllStatueTimeOut.Length)
                {
                    frmMain.mMain.AllDataBase.WriteData.Write("delete from StatueTimeOut");
                    for (int i = 0; i < AllStatueTimeOut.Length; i++)
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueTimeOut (WorkStation,Statue) values ({0},'false')", AllStatueTimeOut[i].WorkStation));
                    }
                }
            }
            dtStatueTimeOut = frmMain.mMain.AllDataBase.ReadData.Read("select * from StatueTimeOut Order by WorkStation");
            dtStatueTimeOut.TableName = "StatueTimeOut";
            DataToClass(dtStatueTimeOut, true);
        }
        public class StatueTimeOut
        {
            public int WorkStation
            { get; set; }
            public bool Statue
            { get; set; }
            public StatueTimeOut(int workStation, bool statue)
            {
                this.WorkStation = workStation;
                this.Statue = statue;
            }
            public void SetStatue(bool statue,bool Init)
            {
                if (this.Statue == statue)//同状态返回
                {
                    return;
                }
                this.Statue = statue;
                if (Init)
                {
                    return;
                }
                if (this.Statue)
                {
                    if (!frmMain.mMain.AllCars.AllInfoLineStation[this.WorkStation - 1].TestStation)//自动工位返回
                    {
                        return;
                    }
                    if (!frmMain.mMain.AllCars.AllStatueLineStation[this.WorkStation - 1].HaveCar && this.WorkStation != 2)//空车返回
                    {
                        return;
                    }
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.超时, this.WorkStation,
                       frmMain.mMain.AllCars.AllInfoLineStation[this.WorkStation - 1].StationName,
                       FlushAllError.ChangeList.Add,this.WorkStation);//添加检测影响
                    //报警灯响
                    ChangeLed(true);
                }
                else
                {
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.超时, this.WorkStation,
                       frmMain.mMain.AllCars.AllInfoLineStation[this.WorkStation - 1].StationName,
                       FlushAllError.ChangeList.Del,this.WorkStation);//删除检测影响
                    //报警灯关闭
                    ChangeLed(false);
                }
            }
            /// <summary>
            /// 开关报警灯提示
            /// </summary>
            /// <param name="statue"></param>
            private void ChangeLed(bool statue)
            {
                    switch (this.WorkStation)
                    {
                        case 2:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警1, (ushort)(statue ? 1 : 0));
                            break;
                        case 4:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警2, (ushort)(statue ? 1 : 0));
                            break;
                        case 6:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警3, (ushort)(statue ? 1 : 0));
                            break;
                        case 8:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警4, (ushort)(statue ? 1 : 0));
                            break;
                        case 10:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警5, (ushort)(statue ? 1 : 0));
                            break;
                        case 12:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警6, (ushort)(statue ? 1 : 0));
                            break;
                        case 14:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警7, (ushort)(statue ? 1 : 0));
                            break;
                        case 16:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警8, (ushort)(statue ? 1 : 0));
                            break;
                        case 18:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警9, (ushort)(statue ? 1 : 0));
                            break;
                        case 20:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警10, (ushort)(statue ? 1 : 0));
                            break;
                        case 22:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警11, (ushort)(statue ? 1 : 0));
                            break;
                        case 26:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警12, (ushort)(statue ? 1 : 0));
                            break;
                        case 30:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警13, (ushort)(statue ? 1 : 0));
                            break;
                        case 31:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警14, (ushort)(statue ? 1 : 0));
                            break;
                        case 37:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警15, (ushort)(statue ? 1 : 0));
                            break;
                        case 39:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警16, (ushort)(statue ? 1 : 0));
                            break;
                        case 41:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警17, (ushort)(statue ? 1 : 0));
                            break;
                        case 42:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警18, (ushort)(statue ? 1 : 0));
                            break;
                        case 44:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警19, (ushort)(statue ? 1 : 0));
                            break;
                        case 46:
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.报警20, (ushort)(statue ? 1 : 0));
                            break;
                    }
            }
        }
    }
}
