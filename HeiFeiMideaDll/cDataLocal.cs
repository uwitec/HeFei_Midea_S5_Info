using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
    public class cDataLocal
    {
        /// <summary>
        /// 本地界面操作数据库连接
        /// </summary>
        public All.Class.DataReadAndWrite LocalData
        { get; set; }
        public All.Class.DataReadAndWrite ReadData
        { get; set; }
        public All.Class.DataReadAndWrite WriteData
        { get; set; }
        
        public cDataLocal()
        {
        }
        public cDataLocal(All.Class.DataReadAndWrite allData)
        {
            this.LocalData = allData;
            this.ReadData = allData;
            this.WriteData = allData;
        }
        #region//本地界面操作
        #region//物料呼叫
        /// <summary>
        /// 获取当前呼叫物料
        /// </summary>
        /// <param name="WorkStation"></param>
        /// <returns></returns>
        public List<StatueMaterial> GetStatueMaterial(int WorkStation)
        {
            List<StatueMaterial> result = new List<StatueMaterial>();
            using (DataTable dt = ReadData.Read(string.Format("select * from StatueMaterial Where WorkStation={0} and CallOver='False'", WorkStation)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    StatueMaterial tmp;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmp = new StatueMaterial(0, "", 0);
                        tmp.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        tmp.Material = All.Class.Num.ToString(dt.Rows[i]["Material"]);
                        tmp.MaterialNum = All.Class.Num.ToInt(dt.Rows[i]["MaterialNum"]);
                        tmp.MaterialCount = All.Class.Num.ToInt(dt.Rows[i]["MaterialCount"]);
                        tmp.SendTime = All.Class.Num.ToDateTime(dt.Rows[i]["SendTime"]);
                        result.Add(tmp);
                    }
                }
            }
            return result;
        }
        public class StatueMaterial
        {
            /// <summary>
            /// PC工位号,值为1到。。。包括其他厂家的呼叫，如爱华科
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 物料名称
            /// </summary>
            public string Material
            { get; set; }
            /// <summary>
            /// 物料编码
            /// </summary>
            public int MaterialNum
            { get; set; }
            /// <summary>
            /// 物料数量
            /// </summary>
            public int MaterialCount
            { get; set; }
            /// <summary>
            /// 呼叫时间
            /// </summary>
            public DateTime SendTime
            { get; set; }
            public StatueMaterial(int workStation,string material,int materialNum)
            {
                WorkStation = workStation;
                Material = material;
                MaterialNum = materialNum;
                MaterialCount = 0;
                SendTime = DateTime.Now;
            }
            /// <summary>
            /// 将类转化为字符串
            /// </summary>
            /// <returns></returns>
            public string ClassToStr()
            {
                Dictionary<string, string> buff = new Dictionary<string, string>();
                buff.Add("WorkStation", WorkStation.ToString());
                buff.Add("Material", Material);
                buff.Add("MaterialNum", MaterialNum.ToString());
                buff.Add("MaterialCount", MaterialCount.ToString());
                buff.Add("SendTime", string.Format("{0:yyyy-MM-dd HH:mm:ss}", SendTime));
                return All.Class.SSFile.Dictionary2Text(buff);
            }
            /// <summary>
            /// 将字条串解析为类
            /// </summary>
            /// <param name="value"></param>
            public static StatueMaterial StrToClass(string value)
            {
                StatueMaterial result = new StatueMaterial(0,"", 0);
                Dictionary<string, string> buff = All.Class.SSFile.Text2Dictionary(value);
                if (buff.ContainsKey("WorkStation"))
                    result.WorkStation = All.Class.Num.ToInt(buff["WorkStation"]);
                if (buff.ContainsKey("Material"))
                    result.Material = buff["Material"];
                if (buff.ContainsKey("MaterialNum"))
                    result.MaterialNum = All.Class.Num.ToInt(buff["MaterialNum"]);
                if (buff.ContainsKey("MaterialCount"))
                    result.MaterialCount = All.Class.Num.ToInt(buff["MaterialCount"]);
                if (buff.ContainsKey("SendTime"))
                    result.SendTime = All.Class.Num.ToDateTime(buff["SendTime"]);
                return result;
            }
        }
        #endregion
        #region//物料
        /// <summary>
        /// 保存物料
        /// </summary>
        /// <returns></returns>
        public bool SaveMaterial(List<Material> materials)
        {
            bool result = true;
            DeleteMaterial();
            materials.ForEach(
                mater =>
                {
                    result = result && (LocalData.Write(
                        string.Format("insert into SetMaterial values ({0},'{1}',{2})", mater.WorkStation, mater.Text, mater.Num)) >= 1);
                }
                );
            return result;
        }
        /// <summary>
        /// 删除所有物料信息
        /// </summary>
        public void DeleteMaterial()
        {
            LocalData.Write("delete from SetMaterial");
        }
        /// <summary>
        /// 获取所有工位物料信息
        /// </summary>
        /// <returns></returns>
        public List<Material> GetMaterial()
        {
            return GetMaterial(-1);
        }
        /// <summary>
        /// 获取指定工位物料
        /// </summary>
        /// <param name="workStation"></param>
        /// <returns></returns>
        public List<Material> GetMaterial(int workStation)
        {
            List<Material> material = new List<Material>();
            Material tmpMaterial;
            string sql = "select * from V_Material";
            if (workStation >= 0)
            {
                sql = string.Format("{0} where workStation={1}", sql, workStation);
            }
            sql = string.Format("{0} order by stationName", sql);
            using (DataTable dt = LocalData.Read(sql))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmpMaterial = new Material();
                        tmpMaterial.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                        tmpMaterial.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        tmpMaterial.Text = All.Class.Num.ToString(dt.Rows[i]["Material"]);
                        tmpMaterial.Num = All.Class.Num.ToInt(dt.Rows[i]["MaterialNum"]);
                        material.Add(tmpMaterial);
                    }
                }
            }
            return material;
        }
        /// <summary>
        /// 物料
        /// </summary>
        public class Material
        {
            /// <summary>
            /// 工位名称
            /// </summary>
            public string StationName
            { get; set; }
            /// <summary>
            /// 工位序号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 物料名称
            /// </summary>
            public string Text
            { get; set; }
            /// <summary>
            /// 物料编码
            /// </summary>
            public int Num
            { get; set; }
            public Material()
            {
                StationName = "";
                WorkStation = -1;
                Text = "";
                Num = 0;
            }
        }
        #endregion
        #region//工位
        /// <summary>
        /// 获取工位设置
        /// </summary>
        /// <returns></returns>
        public List<InfoStation> GetStation()
        {
            List<InfoStation> result = new List<InfoStation>();

            InfoStation tmpStationSet;
            using (DataTable dt = LocalData.Read("select * from InfoStation order by WorkStation"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmpStationSet = new InfoStation();
                        tmpStationSet.IpAddress = All.Class.Num.ToString(dt.Rows[i]["IpAddress"]);
                        tmpStationSet.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        tmpStationSet.StartForm = All.Class.Num.ToString(dt.Rows[i]["StartForm"]);
                        tmpStationSet.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                        tmpStationSet.TestStation = All.Class.Num.ToBool(dt.Rows[i]["TestStation"]);
                        tmpStationSet.MaterialShow = All.Class.Num.ToBool(dt.Rows[i]["MaterialShow"]);
                        tmpStationSet.ErrorShow = All.Class.Num.ToBool(dt.Rows[i]["ErrorShow"]);
                        tmpStationSet.RepairShow = All.Class.Num.ToBool(dt.Rows[i]["RepairShow"]);
                        tmpStationSet.TestOne = All.Class.Num.ToInt(dt.Rows[i]["TestOne"]);
                        tmpStationSet.TestTwo = All.Class.Num.ToInt(dt.Rows[i]["TestTwo"]);
                        tmpStationSet.TestThree = All.Class.Num.ToInt(dt.Rows[i]["TestThree"]);
                        tmpStationSet.InLine = All.Class.Num.ToBool(dt.Rows[i]["InLine"]);
                        tmpStationSet.PrintBar = All.Class.Num.ToBool(dt.Rows[i]["PrintBar"]);
                        result.Add(tmpStationSet);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 从所有工位设置中找指定的工位设置
        /// </summary>
        /// <param name="allInfoStation"></param>
        /// <param name="workStation"></param>
        /// <returns></returns>
        public InfoStation GetStation(List<InfoStation> allInfoStation, int workStation)
        {
            int index = allInfoStation.FindIndex(
                tmpInfoStation =>
                {
                    return tmpInfoStation.WorkStation == workStation;
                });
            if (index >= 0)
            {
                return allInfoStation[index];
            }
            return new InfoStation();
        }
        /// <summary>
        /// 获取指定工位设置
        /// </summary>
        /// <param name="workStation"></param>
        /// <returns></returns>
        public InfoStation GetStation(int workStation)
        {
            InfoStation result = new InfoStation();
            using (DataTable dt = LocalData.Read(string.Format("select * from InfoStation where WorkStation={0} order by WorkStation", workStation)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.IpAddress = All.Class.Num.ToString(dt.Rows[0]["IpAddress"]);
                    result.WorkStation = All.Class.Num.ToInt(dt.Rows[0]["WorkStation"]);
                    result.StartForm = All.Class.Num.ToString(dt.Rows[0]["StartForm"]);
                    result.StationName = All.Class.Num.ToString(dt.Rows[0]["StationName"]);
                    result.TestStation = All.Class.Num.ToBool(dt.Rows[0]["TestStation"]);
                    result.MaterialShow = All.Class.Num.ToBool(dt.Rows[0]["MaterialShow"]);
                    result.ErrorShow = All.Class.Num.ToBool(dt.Rows[0]["ErrorShow"]);
                    result.RepairShow = All.Class.Num.ToBool(dt.Rows[0]["RepairShow"]);
                    result.TestOne = All.Class.Num.ToInt(dt.Rows[0]["TestOne"]);
                    result.TestTwo = All.Class.Num.ToInt(dt.Rows[0]["TestTwo"]);
                    result.TestThree = All.Class.Num.ToInt(dt.Rows[0]["TestThree"]);
                    result.InLine = All.Class.Num.ToBool(dt.Rows[0]["InLine"]);
                    result.PrintBar = All.Class.Num.ToBool(dt.Rows[0]["PrintBar"]);
                }
            }
            return result;
        }
        public class InfoStation
        {
            /// <summary>
            /// 工位电脑IP地址
            /// </summary>
            public string IpAddress
            { get; set; }
            /// <summary>
            /// 工位序号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 工位启动界面
            /// </summary>
            public string StartForm
            { get; set; }
            /// <summary>
            /// 工位名称
            /// </summary>
            public string StationName
            { get; set; }
            /// <summary>
            /// 是否人工检测工位
            /// </summary>
            public bool TestStation
            { get; set; }
            /// <summary>
            /// 显示物料录入
            /// </summary>
            public bool MaterialShow
            { get; set; }
            /// <summary>
            /// 显示故障录入
            /// </summary>
            public bool ErrorShow
            { get; set; }
            /// <summary>
            /// 显示维修录入
            /// </summary>
            public bool RepairShow
            { get; set; }
            /// <summary>
            /// 测试1#显示
            /// </summary>
            public int TestOne
            { get; set; }
            /// <summary>
            /// 测试2#显示
            /// </summary>
            public int TestTwo
            { get; set; }
            /// <summary>
            /// 测试3#显示
            /// </summary>
            public int TestThree
            { get; set; }
            /// <summary>
            /// 显示上线
            /// </summary>
            public bool InLine
            { get; set; }
            /// <summary>
            /// 是否打印
            /// </summary>
            public bool PrintBar
            { get; set; }
            public InfoStation()
            {
                IpAddress = "";
                WorkStation = 0;
                StartForm = "";
                StationName = "";
                TestStation = true;
                MaterialShow = true;
                ErrorShow = true;
                RepairShow = true;
                TestOne = 0;
                TestTwo = 0;
                TestThree = 0;
                InLine = true;
                PrintBar = false;
            }
        }
        #endregion
        #region//停车工位信息
        /// <summary>
        /// 获取所有停车工位信息
        /// </summary>
        /// <returns></returns>
        public List<InfoLineStation> GetAllInfoLineStation()
        {
            return GetInfoLineStation(string.Format("select * from InfoLineStation order by WorkStation"));
        }
        private List<InfoLineStation> GetInfoLineStation(string sql)
        {
            List<InfoLineStation> result = new List<InfoLineStation>();
            InfoLineStation tmpInfoLineStation;
            using (DataTable dt = LocalData.Read(sql))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmpInfoLineStation = new InfoLineStation();
                        tmpInfoLineStation.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        tmpInfoLineStation.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                        tmpInfoLineStation.TestStation = All.Class.Num.ToBool(dt.Rows[i]["TestStation"]);
                        tmpInfoLineStation.TimeOut = All.Class.Num.ToInt(dt.Rows[i]["TimeOut"]);
                        tmpInfoLineStation.UserName = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                        result.Add(tmpInfoLineStation);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取检测停车工位信息
        /// </summary>
        /// <returns></returns>
        public List<InfoLineStation> GetTestInfoLineStation()
        {
            return GetInfoLineStation(string.Format("select * from InfoLineStation where TestStation='true' order by WorkStation"));
        }
        /// <summary>
        /// 保存停车工位信息
        /// </summary>
        /// <param name="infoLineStations"></param>
        /// <returns></returns>
        public bool SaveInfoLineStation(List<InfoLineStation> infoLineStations)
        {
            bool result = true;
            infoLineStations.ForEach(
                infoLineStation =>
                {
                    result = result && (LocalData.Write(string.Format("update InfoLineStation Set StationName='{0}',TestStation='{1}',TimeOut={2} where WorkStation={3}",
                        infoLineStation.StationName, infoLineStation.TestStation, infoLineStation.TimeOut, infoLineStation.WorkStation)) == 1);
                }
            );
            return result;
        }
        /// <summary>
        /// 更新用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="workStation"></param>
        /// <returns></returns>
        public bool SaveUserName(string userName, int workStation)
        {
            return LocalData.Write(string.Format("update InfoLineStation Set UserName='{0}' where WorkStation={1}", userName, workStation)) == 1;
        }
        /// <summary>
        /// 停车工位信息
        /// </summary>
        public class InfoLineStation
        {
            /// <summary>
            /// 停车工位序号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 停车工位序号名称
            /// </summary>
            public string StationName
            { get; set; }
            /// <summary>
            /// 是否手动须要计时的工位
            /// </summary>
            public bool TestStation
            { get; set; }
            /// <summary>
            /// 超时时间
            /// </summary>
            public int TimeOut
            { get; set; }
            /// <summary>
            /// 用户
            /// </summary>
            public string UserName
            { get; set; }
            public InfoLineStation()
            {
                WorkStation = 0;
                StationName = "";
                TestStation = false;
                TimeOut = 9999;
                UserName = "";
            }
            /// <summary>
            /// 将地标工位转化为测试工位即0-53转化为W01-W20
            /// </summary>
            /// <param name="LineWorkStation"></param>
            /// <returns></returns>
            public static int GetWorkFromStation(int LineWorkStation)
            {
                int result = 0;
                switch (LineWorkStation)
                {
                    case 2:
                        result = 1;
                        break;
                    case 4:
                        result = 2;
                        break;
                    case 6:
                        result = 3;
                        break;
                    case 8:
                        result = 4;
                        break;
                    case 10:
                        result = 5;
                        break;
                    case 12:
                        result = 6;
                        break;
                    case 14:
                        result = 7;
                        break;
                    case 16:
                        result = 8;
                        break;
                    case 18:
                        result = 9;
                        break;
                    case 20:
                        result = 10;
                        break;
                    case 22:
                        result = 11;
                        break;
                    case 26:
                        result = 12;
                        break;
                    case 30:
                        result = 13;
                        break;
                    case 31:
                        result = 14;
                        break;
                    case 37:
                        result = 15;
                        break;
                    case 39:
                        result = 16;
                        break;
                    case 41:
                        result = 17;
                        break;
                    case 42:
                        result = 18;
                        break;
                    case 44:
                        result = 19;
                        break;
                    case 46:
                        result = 20;
                        break;
                }
                return result;
            }
        }
#endregion
        #endregion
    }
}

