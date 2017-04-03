using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 记录所有故障，用于品质分析
    /// </summary>
    public class FlushAllError : All.Class.FlushAll.FlushMethor
    {
        public DataTable ShowErrorTable
        { get; set; }
        public FlushAllError()
        {
            ShowErrorTable = null;
        }
        /// <summary>
        /// 故障源
        /// </summary>
        public enum SpaceList:int
        {
            折弯机 = 0,
            冷凝器线体,
            真空氦检,
            小车,
            工位屏,
            机器人,
            注油机,
            氦检回收,
            抽空充注,
            性能检,
            物料网络,
            绕膜机,
            打包机,
            线体,
            物料,
            超时
        }
        /// <summary>
        /// 操作方法
        /// </summary>
        public enum ChangeList
        {
            Add,
            Del
        }
        public override void Flush()
        {
            for (int i = 0; i < frmMain.mMain.AllPCs.AllMcgs.Mcgs.Length; i++)
            {
                frmMain.mMain.AllPCs.AllMcgs.Mcgs[i].Flush();
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read(string.Format("select top 3 Count(Error) as AllErrors,Error from StatueError where workstation>0 and  ErrorTime>'{0:yyyy-MM-dd HH:mm:ss}' group by Error order by AllErrors desc", frmMain.mMain.AllDataXml.LocalSet.TodayStart)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    ShowErrorTable = dt.Copy();
                }
            }
        }
        public override void Load()
        {
        }
        public void Change(SpaceList space, string Error, ChangeList change)
        {
            switch (space)
            {
                case SpaceList.抽空充注:
                    Change(space, 0, Error, change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.氦检回收:
                    Change(space, 0, Error, change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.真空氦检:
                    Change(space, 0, Error, change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
            }
        }
        public void Change(SpaceList space,ChangeList change)
        {
            switch (space)
            {
                case SpaceList.打包机:
                    Change(space, 0, "打包机故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.冷凝器线体:
                    Change(space, 0, "冷凝器线体通讯故障或设备故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.折弯机:
                    Change(space, 0, "折弯机通讯故障或设备故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.物料网络:
                    Change(space, 0, "物料网络故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.绕膜机:
                    Change(space, 0, "绕膜机故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.注油机:
                    Change(space, 0, "注油机通讯故障或设备故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
                case SpaceList.线体:
                    Change(space, 0, "线体故障", change, cSheBei.GetMachineIndexForAllError(space, 0));
                    break;
            }
        }
        public void Change(SpaceList space, int index,ChangeList change)
        {
            switch (space)
            {
                case SpaceList.工位屏:
                    Change(space, 0, string.Format("{0}通讯故障", frmMain.mMain.AllCars.AllInfoStation[index].StationName), change, cSheBei.GetMachineIndexForAllError(space, index));
                    break;
            }
        }
        /// <summary>
        /// 故障状态改变
        /// </summary>
        /// <param name="space">位置</param>
        /// <param name="index">设备序号</param>
        /// <param name="error">故障名称</param>
        /// <param name="change">添加或删除</param>
        public void Change(SpaceList space,int index,string error,ChangeList change,int errorSpace)
        {
            string errorText = error;
            int errorEnum = 0;
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            DataTable dt = null;
            switch (space)
            {
                case SpaceList.机器人:
                    errorEnum = 1;
                    errorText = string.Format("{0}#机器人,{1}", index, errorText);
                    break;
                case SpaceList.小车:
                    errorEnum = 1;
                    errorText = string.Format("{0}#小车,{1}", index, errorText);
                    break;
                case SpaceList.性能检:
                    errorEnum = 1;//设备故障
                    errorText = string.Format("{0}#性能检工位,{1}", index, error);
                    break;
                case SpaceList.物料:
                    errorEnum = 2;//物料呼叫
                    errorText = string.Format("呼叫物料:{0}", error);
                    break;
                case SpaceList.超时:
                    errorEnum = 3;//超时
                    errorText = string.Format("操作超时,位置:{0}", error);
                    break;
                default:
                    errorEnum = 1;
                    if (index > 0)
                    {
                        errorText = string.Format("{0}#{1}", index, error);
                    }
                    break;
            }
            dt = frmMain.mMain.AllDataBase.ReadData.Read(string.Format("select ErrorText,ErrorEnum,StartTime from StatueErrorAllTmp where ErrorText='{0}' and ErrorEnum={1}", errorText, errorEnum));
            switch (change)
            {
                case ChangeList.Add:
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dt.Dispose();
                        //return;//此处不返回，对于已有的记录，重新更新。防止关机前的问题设备，开机后恢复的情况下不能正确删除的情况
                        frmMain.mMain.AllDataBase.WriteData.Write(string.Format("update StatueErrorAllTmp Set StartTime='{0:yyyy-MM-dd HH:mm:ss}' where ErrorText='{1}' and ErrorEnum={2}", DateTime.Now, errorText, errorEnum));
                    }
                    else
                    {
                        frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueErrorAllTmp (ErrorText,ErrorEnum,StartTime,ErrorSpace) values ('{0}',{1},'{2:yyyy-MM-dd HH:mm:ss}',{3})",
                            errorText, errorEnum, startTime,errorSpace));
                    }
                    break;
                case ChangeList.Del:
                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        return;
                    }
                    startTime = All.Class.Num.ToDateTime(dt.Rows[0]["StartTime"]);
                    TimeSpan ts = endTime - startTime;
                    long ErrorTime = (long)ts.TotalSeconds;
                    dt.Dispose();
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("delete from StatueErrorAllTmp where ErrorText='{0}' and ErrorEnum={1}", errorText, errorEnum));
                    frmMain.mMain.AllDataBase.WriteData.Write(string.Format("insert into StatueErrorAll (ErrorText,ErrorEnum,StartTime,EndTime,ErrorTime) values ('{0}',{1},'{2:yyyy-MM-dd HH:mm:ss}','{3:yyyy-MM-dd HH:mm:ss}',{4})",
                        errorText, errorEnum, startTime, endTime, ErrorTime));
                    break;
            }
        }
    }
}
