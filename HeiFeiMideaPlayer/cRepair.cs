using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class cRepair
    {
        /// <summary>
        /// 从条码读取待返修故障
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public static List<HeiFeiMideaDll.TestError> GetErrorFromBar(string barCode)
        {
            List<HeiFeiMideaDll.TestError> result = new List<HeiFeiMideaDll.TestError>();
            using (DataTable dt = frmMain.mMain.AllDataBase.FlushData.Read(string.Format("select * from StatueError Where BarCode='{0}' and Repair='False'", barCode)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    HeiFeiMideaDll.TestError tmp;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmp = new HeiFeiMideaDll.TestError();
                        tmp.WorkStation = All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]);
                        tmp.Barcode = All.Class.Num.ToString(dt.Rows[i]["BarCode"]);
                        tmp.Error = All.Class.Num.ToString(dt.Rows[i]["Error"]);
                        tmp.ErrorNum = All.Class.Num.ToInt(dt.Rows[i]["ErrorNum"]);
                        tmp.ErrorTime = All.Class.Num.ToDateTime(dt.Rows[i]["ErrorTime"]);
                        tmp.Repair = All.Class.Num.ToBool(dt.Rows[i]["Repair"]);
                        tmp.RepairTime = All.Class.Num.ToDateTime(dt.Rows[i]["RepairTime"]);
                        result.Add(tmp);
                    }
                }
            }
            return result;
        }
    }
}
