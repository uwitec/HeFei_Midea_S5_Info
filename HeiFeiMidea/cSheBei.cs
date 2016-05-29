using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class cSheBei
    {
        public cSheBei()
        {
 
        }
        /// <summary>
        /// 获取指定设备的实时故障
        /// </summary>
        /// <param name="space"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string[] GetMachineError(FlushAllError.SpaceList space, int index)
        {
            List<string> result = new List<string>();
            using (DataTable dt = frmMain.mMain.AllDataBase.ReportData.Read(string.Format("select * from StatueErrorAllTmp where ErrorSpace={0}", GetMachineIndexForAllError(space, index))))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(All.Class.Num.ToString(dt.Rows[i]["ErrorText"]));
                    }
                }
            }
            return result.ToArray();
        }
        public static string[] GetMachineError(string controlName)
        {
            if (controlName == "iconZheWang")
            {
                return GetMachineError(FlushAllError.SpaceList.折弯机, 0);
            }
            if (controlName == "iconLengNingQiPlc")
            {
                return GetMachineError(FlushAllError.SpaceList.冷凝器线体, 0);
            }
            if (controlName == "iconHaiJian")
            {
                return GetMachineError(FlushAllError.SpaceList.真空氦检, 0);
            }
            if (controlName.IndexOf("mcgs") >= 0)
            {
                return GetMachineError(FlushAllError.SpaceList.工位屏, All.Class.Num.ToInt(controlName.Replace("mcgs", "")));
            }
            if (controlName.IndexOf("StationOther") >= 0)
            {
                switch(All.Class.Num.ToInt(controlName.Replace("StationOther", "")))
                {
                    case 1:
                        return GetMachineError(FlushAllError.SpaceList.机器人, 1);
                    case 2:
                        return GetMachineError(FlushAllError.SpaceList.机器人, 2);
                    case 3:
                        return GetMachineError(FlushAllError.SpaceList.机器人, 2);
                    case 9:
                        return GetMachineError(FlushAllError.SpaceList.绕膜机, 0);
                    case 10:
                        return GetMachineError(FlushAllError.SpaceList.打包机, 0);
                }
            }
            if (controlName == "iconChongHaiHuiShou")
            {
                return GetMachineError(FlushAllError.SpaceList.氦检回收, 0);
            }
            if (controlName == "IconEmptyOne" || controlName == "IconEmptyTwo")
            {
                return GetMachineError(FlushAllError.SpaceList.抽空充注, 0);
            }
            if (controlName.IndexOf("Test") >= 0)
            {
                return GetMachineError(FlushAllError.SpaceList.性能检, All.Class.Num.ToInt(controlName.Replace("Test", "")));
            }
            if (controlName == "iconPlc")
            {
                return GetMachineError(FlushAllError.SpaceList.线体, 0);
            }
            if (controlName.IndexOf("LittleStation") >= 0)
            {
                return GetMachineError(FlushAllError.SpaceList.小车, All.Class.Num.ToInt(controlName.Replace("LittleStation", "")));
            }
            if (controlName == "iconOil")
            {
                return GetMachineError(FlushAllError.SpaceList.注油机, 0);
            }
            return GetMachineError(FlushAllError.SpaceList.超时, 0);
        }
        /// <summary>
        /// 取设备识别号
        /// </summary>
        /// <param name="space"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetMachineIndexForAllError(FlushAllError.SpaceList space, int index)
        {
            return index + 1000 * (int)space;
        }
    }
}
