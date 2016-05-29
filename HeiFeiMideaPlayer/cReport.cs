using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class cReport
    {
        /// <summary>
        /// 保存生产数据
        /// </summary>
        /// <param name="barcode"></param>
        public static void Save(string barcode)
        {
            if (barcode.Length <= 12)
            {
                return;
            }
            string sql = string.Format("insert into TestAll (BarCode,TestTime,TestYear,TestMonth,TestDay,TestHour,Mode,IsPass,IsReturn) Values('{0}','{1:yyyy-MM-dd HH:mm:ss}',{1:yyyy},{1:MM},{1:dd},{1:HH},'{2}','true','false')",
                barcode, DateTime.Now, barcode.Substring(0, barcode.Length - 12));
            frmMain.mMain.AllDataBase.LenNingQi.Write(sql);
        }
        /// <summary>
        /// 返修
        /// </summary>
        /// <param name="barcode"></param>
        public static void Repair(string barcode)
        {
            if (barcode.Length <= 12)
            {
                return;
            }
            frmMain.mMain.AllDataBase.LenNingQi.Write(string.Format("update TestAll Set IsReturn='true' where BarCode='{0}'", barcode));
        }
        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="barcode"></param>
        public static void Error(string barcode)
        {
            if (barcode.Length <= 12)
            {
                return;
            }
            string sql = string.Format("update TestAll Set IsPass='false' where BarCode='{0}'",barcode);
            frmMain.mMain.AllDataBase.LenNingQi.Write(sql);
        }
        /// <summary>
        /// 刷新小时产量与总产量
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="count"></param>
        public static void ReadEveryHour(out List<string> hour,out List<int> count,out int AllCount)
        {
            hour = new List<string>();
            count = new List<int>();
            AllCount = 0;
            string sql = string.Format("select Count(TestHour) as Count ,TestHour from TestAll where TestYear={0:yyyy} and TestMonth={0:MM} and TestDay={0:dd} Group By TestHour order by testHour", DateTime.Now);
            using (DataTable dt = frmMain.mMain.AllDataBase.LenNingQi.Read(sql))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hour.Add(string.Format("{0}时->{1}时", All.Class.Num.ToInt(dt.Rows[i]["TestHour"]), All.Class.Num.ToInt(dt.Rows[i]["TestHour"]) + 1));
                        count.Add(All.Class.Num.ToInt(dt.Rows[i]["Count"]));
                        AllCount = All.Class.Num.ToInt(dt.Rows[i]["Count"]) + AllCount;
                    }
                }
            }
        }
        public static void GetReport(DateTime start, DateTime end,out DataTable dtAll,out DataTable dtMonth, out DataTable dtDay, out DataTable dtPass, out DataTable dtRepair)
        {
            dtPass = new DataTable();
            dtRepair = new DataTable();
            DataRow dr;
            int allCount = 0;

            //详情
            dtAll = frmMain.mMain.AllDataBase.LenNingQi.Read(string.Format("select BarCode,TestTime,Mode,IsPass,IsReturn from TestAll where TestTime>'{0:yyyy-MM-dd} 00:00:00' and TestTime<'{1:yyyy-MM-dd} 23:59:59'", start, end));
            if (dtAll != null && dtAll.Rows.Count > 0)
            {
                allCount = dtAll.Rows.Count;
            }
            //月报表
            dtMonth = frmMain.mMain.AllDataBase.LenNingQi.Read(string.Format("select Count(TestDay) as ShowValue,TestDay as ShowTime from TestAll where TestYear={0:yyyy} and TestMonth={0:MM} Group By TestDay", start));
            //日报表
            dtDay = frmMain.mMain.AllDataBase.LenNingQi.Read(string.Format("select Count(TestHour) as ShowValue,TestHour as ShowTime from TestAll where TestYear={0:yyyy} and TestMonth={0:MM} and TestDay={0:dd} Group by TestHour", start));

            //报废率
            dtPass.Columns.Add("ShowValue", typeof(float));
            dtPass.Columns.Add("ShowTime", typeof(string));
            int errorCount = 0;
            int passCount = 0;
            using (DataTable dt = frmMain.mMain.AllDataBase.LenNingQi.Read(string.Format("select IsPass From TestAll where IsPass='false' and TestTime>'{0:yyyy-MM-dd} 00:00:00' and TestTime<'{1:yyyy-MM-dd} 23:59:59'", start, end)))
            {
                if (dt.Rows.Count > 0)
                {
                    errorCount = dt.Rows.Count;
                }
                passCount = Math.Max(0, allCount - errorCount);
                if (allCount > 0)
                {
                    dr = dtPass.NewRow();
                    dr["ShowTime"] = "报废率";
                    dr["ShowValue"]= (float)errorCount / allCount;
                    dtPass.Rows.Add(dr);
                    dr = dtPass.NewRow();
                    dr["ShowTime"] = "通过率";
                    dr["ShowValue"] = (float)passCount / allCount;
                    dtPass.Rows.Add(dr);
                }
            }
            //返修率

            dtRepair.Columns.Add("ShowValue", typeof(float));
            dtRepair.Columns.Add("ShowTime", typeof(string));
            errorCount = 0;
            passCount = 0;
            using (DataTable dt = frmMain.mMain.AllDataBase.LenNingQi.Read(string.Format("select isReturn From TestAll where IsReturn='true' and TestTime>'{0:yyyy-MM-dd} 00:00:00' and TestTime<'{1:yyyy-MM-dd} 23:59:59'", start, end)))
            {
                if (dt.Rows.Count > 0)
                {
                    errorCount = dt.Rows.Count;
                }
                passCount = Math.Max(0, allCount - errorCount);
                if (allCount > 0)
                {
                    dr = dtRepair.NewRow();
                    dr["ShowTime"] = "返修率";
                    dr["ShowValue"] = (float)errorCount / allCount;
                    dtRepair.Rows.Add(dr);
                    dr = dtRepair.NewRow();
                    dr["ShowTime"] = "通过率";
                    dr["ShowValue"] = (float)passCount / allCount;
                    dtRepair.Rows.Add(dr);
                }
            }

        }
    }
}
