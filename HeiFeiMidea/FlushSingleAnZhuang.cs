using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新安装数据
    /// </summary>
    public class FlushSingleAnZhuang:All.Class.FlushAll.FlushMethor
    {
        string[] AllOldBarCode = new string[HeiFeiMideaDll.cMain.AllStopStationCount];
        public override void Flush()
        {
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllStopStationCount; i++)
            {
                if (frmMain.mMain.AllCars.AllInfoLineStation[i].TestStation &&
                    frmMain.mMain.AllCars.AllStatueLineStation[i].BarCode != null &&
                    AllOldBarCode[i] != frmMain.mMain.AllCars.AllStatueLineStation[i].BarCode &&
                    frmMain.mMain.AllCars.AllStatueLineStation[i].BarCode.Length > 10)
                {
                    AllValue value = new AllValue();
                    value.BarCode = frmMain.mMain.AllCars.AllStatueLineStation[i].BarCode;
                    value.StationName = frmMain.mMain.AllCars.AllInfoLineStation[i].StationName;
                    value.WorkStation = frmMain.mMain.AllCars.AllInfoLineStation[i].WorkStation;
                    value.TestTime = DateTime.Now;
                    value.Save();
                    AllOldBarCode[i] = frmMain.mMain.AllCars.AllStatueLineStation[i].BarCode;
                }
            }
        }
        public override void Load()
        {
            for (int i = 0; i < AllOldBarCode.Length; i++)
            {
                AllOldBarCode[i] = "";
            }
        }
        #region//安装记录
        public class AllValue
        {
            public string BarCode
            { get; set; }
            public string UserName
            { get; set; }
            public int WorkStation
            { get; set; }
            public string StationName
            { get; set; }
            public DateTime TestTime
            { get; set; }
            public void Save()
            {
                if (BarCode == "")
                {
                    return;
                }
                if (frmMain.mMain.FlushUserLogin.InfoLineStation.Count >= this.WorkStation)
                {
                    this.UserName = frmMain.mMain.FlushUserLogin.InfoLineStation[this.WorkStation - 1].UserName;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();
                switch (WorkStation)
                {
                    case 11:
                        if (!sql.Login(CheckTestResultFile.CheckLenNingFile(BarCode), "AllLenNingValue.sdf", "", ""))
                        {
                            return;
                        }
                        break;
                    default:
                        if (!sql.Login(CheckTestResultFile.CheckTestFile(BarCode), "AllTestValue.sdf", "", ""))
                        {
                            return;
                        }
                        break;
                }
                sql.Write(string.Format("insert into TestAnZhuang Values({0},'{1}','{2}','{3:yyyy-MM-dd HH:mm:ss}')",
                    WorkStation, StationName, UserName, TestTime));
                sql.Close();
            }
        }
        #endregion
    }
}
