using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
        #region//订单信息
        /// <summary>
        /// 订单信息
        /// </summary>
        public class OrderSet
        {
            /// <summary>
            /// 订单名称
            /// </summary>
            public string OrderName
            { get; set; }
            /// <summary>
            /// 条码前段
            /// </summary>
            public string BarCode
            { get; set; }
            /// <summary>
            /// 条码起始号
            /// </summary>
            public int BarStart
            { get; set; }
            /// <summary>
            /// 条码结束号
            /// </summary>
            public int BarEnd
            { get; set; }
            /// <summary>
            /// 条码前段
            /// </summary>
            public string LenNingCode
            { get; set; }
            /// <summary>
            /// 条码起始号
            /// </summary>
            public int LenNingStart
            { get; set; }
            /// <summary>
            /// 条码结束号
            /// </summary>
            public int LenNingEnd
            { get; set; }
            /// <summary>
            /// 订单日期
            /// </summary>
            public DateTime OrderTime
            { get; set; }
            /// <summary>
            /// 订单日期
            /// </summary>
            public int OrderYear
            { get; set; }
            /// <summary>
            /// 订单日期
            /// </summary>
            public int OrderMonth
            { get; set; }
            /// <summary>
            /// 订单日期
            /// </summary>
            public int OrderDay
            { get; set; }
            /// <summary>
            /// 打印文件 
            /// </summary>
            public string PrintFile
            { get; set; }
            /// <summary>
            /// 是否博世机器，博世机器要打印
            /// </summary>
            public string BoShi
            { get; set; }
            public OrderSet()
            {
                this.OrderName = "";
                this.LenNingCode = "";
                this.LenNingStart = 0;
                this.LenNingEnd = 0;
                this.BarCode = "";
                this.BarStart = 0;
                this.BarEnd = 0;
                this.PrintFile = "";
                this.OrderTime = DateTime.Now;
                this.OrderYear = this.OrderTime.Year;
                this.OrderMonth = this.OrderTime.Month;
                this.OrderDay = this.OrderTime.Day;
                this.BoShi = "";
            }
            /// <summary>
            /// 获取所有订单名称
            /// </summary>
            /// <param name="conn"></param>
            /// <returns></returns>
            public static List<string> GetOrder(All.Class.DataReadAndWrite conn)
            {
                List<string> result = new List<string>();
                using (DataTable dt = conn.Read(string.Format("select OrderName From SetOrder Order by OrderTime desc")))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            result.Add(All.Class.Num.ToString(dt.Rows[i]["OrderName"]));
                        }
                    }
                }
                return result;
            }
            private static List<OrderSet> GetOrder(All.Class.DataReadAndWrite conn,string sql)
            {
                List<OrderSet> result = new List<OrderSet>();
                using (DataTable dt = conn.Read(sql))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        OrderSet tmpOrder;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmpOrder = new OrderSet();
                            tmpOrder.OrderName = All.Class.Num.ToString(dt.Rows[i]["OrderName"]);
                            tmpOrder.LenNingCode = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["LenNingCode"]));
                            tmpOrder.LenNingStart = All.Class.Num.ToInt(dt.Rows[i]["LenNingStart"]);
                            tmpOrder.LenNingEnd = All.Class.Num.ToInt(dt.Rows[i]["LenNingEnd"]);
                            tmpOrder.BarCode = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["BarCode"]));
                            tmpOrder.BarStart = All.Class.Num.ToInt(dt.Rows[i]["BarStart"]);
                            tmpOrder.BarEnd = All.Class.Num.ToInt(dt.Rows[i]["BarEnd"]);
                            tmpOrder.OrderTime = All.Class.Num.ToDateTime(dt.Rows[i]["OrderTime"]);
                            tmpOrder.OrderYear = All.Class.Num.ToInt(dt.Rows[i]["OrderYear"]);
                            tmpOrder.OrderMonth = All.Class.Num.ToInt(dt.Rows[i]["OrderMonth"]);
                            tmpOrder.OrderDay = All.Class.Num.ToInt(dt.Rows[i]["OrderDay"]);
                            tmpOrder.PrintFile = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["PrintFile"]));
                            tmpOrder.BoShi = All.Class.Num.ToString(dt.Rows[i]["BoShi"]);
                            result.Add(tmpOrder);
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// 获取最近100条所有订单
            /// </summary>
            /// <returns></returns>
            public static List<OrderSet> GetOrder(int lastCount,All.Class.DataReadAndWrite conn)
            {
                return GetOrder(conn,string.Format("select Top {0} * from SetOrder order by ID desc", lastCount));
            }
            /// <summary>
            /// 根据订单名称得到订单设置
            /// </summary>
            /// <param name="orderName"></param>
            /// <param name="conn"></param>
            /// <returns></returns>
            public static OrderSet GetOrder(string orderName, All.Class.DataReadAndWrite conn)
            {
                List<OrderSet> result = GetOrder(conn, string.Format("select * from SetOrder Where OrderName='{0}'", orderName));
                if (result == null || result.Count <= 0)
                {
                    return null;
                }
                return result[0];
            }
            /// <summary>
            /// 根据条码从已知的订单中查询对应的订单
            /// </summary>
            /// <param name="orderSet"></param>
            /// <param name="barCode"></param>
            /// <returns></returns>
            public static  OrderSet GetOrder(List<OrderSet> orderSet, string barCode, int workStation)
            {
                if (barCode.Length < 10)
                {
                    return null;
                }
                return orderSet.Find(
                    order =>
                    {
                        bool result = true;
                        string orderFormatBar = "";
                        int start = 0;
                        int end = 0;
                        switch (workStation)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                                orderFormatBar = order.BarCode;
                                start = order.BarStart;
                                end = order.BarEnd;
                                break;
                            case 11:
                                orderFormatBar = order.LenNingCode;
                                start = order.LenNingStart;
                                end = order.LenNingEnd;
                                break;
                        }
                        if (orderFormatBar.Length != barCode.Length)
                        {
                            return false;
                        }
                        int startX = orderFormatBar.IndexOf('*');
                        int endX = orderFormatBar.LastIndexOf('*');

                        int index = All.Class.Num.ToInt(
                            barCode.Substring(
                            startX,
                            endX - startX + 1));
                        for (int i = 0; i < barCode.Length && i < orderFormatBar.Length; i++)
                        {
                            if (i < startX || i > endX)
                            {
                                result = result & (barCode.Substring(i, 1) == orderFormatBar.Substring(i, 1));
                            }
                        }
                        return result && start <= index && index <= end;
                    }
                );
            }
            /// <summary>
            /// 找到此日期之前的最后所有订单
            /// </summary>
            /// <param name="orderSet"></param>
            /// <param name="beforeTime"></param>
            /// <returns></returns>
            public static List<OrderSet> GetOrder(List<OrderSet> orderSet, DateTime beforeTime)
            {
                List<OrderSet> result = new List<OrderSet>();
                if (orderSet.Count > 0)
                {
                    orderSet.ForEach(
                        order =>
                        {
                            if (order.OrderTime <= beforeTime)
                            {
                                result.Add(order);
                            }
                        });
                    if (result.Count > 0)
                    {
                        DateTime tmpTime = result[0].OrderTime;
                        result.RemoveAll(
                            order =>
                            {
                                return order.OrderTime != tmpTime;
                            });
                    }
                }
                return result;
            }
            /// <summary>
            /// 删除订单
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            public static bool DeleteOrder(OrderSet order, All.Class.DataReadAndWrite conn)
            {
                return conn.Write(string.Format("delete from SetOrder where OrderName='{0}'", order.OrderName)) == 1;
            }
            /// <summary>
            /// 插入订单
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            public static bool InsertOrder(OrderSet order, All.Class.DataReadAndWrite conn)
            {
                string sql = "insert into SetOrder ({0}) values ({1})";
                string title = "OrderName,BarCode,BarStart,BarEnd,LenNingCode,LenNingStart,LenNingEnd,PrintFile,OrderTime,OrderYear,OrderMonth,OrderDay,BoShi";
                string value = string.Format("'{0}','{1}',{2},{3},'{4}',{5},{6},'{7}','{8:yyyy-MM-dd HH:mm:ss}',{9},{10},{11},'{12}'",
                    order.OrderName, order.BarCode, order.BarStart, order.BarEnd, order.LenNingCode, order.LenNingStart, order.BarEnd,
                    order.PrintFile, order.OrderTime, order.OrderYear, order.OrderMonth, order.OrderDay,order.BoShi);
                return conn.Write(string.Format(sql, title, value)) == 1;
            }
            /// <summary>
            /// 保存订单
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            public static bool SaveOrder(List<OrderSet> order, All.Class.DataReadAndWrite conn)
            {
                bool result = true;
                order.ForEach(
                    tmpOrder =>
                    {
                        DeleteOrder(tmpOrder,conn);
                        result &= InsertOrder(tmpOrder,conn);
                    });

                return result;
            }
            /// <summary>
            /// 从条码找到对应机型
            /// </summary>
            /// <param name="barCode"></param>
            /// <param name="formatStr">已知的格式化字符串</param>
            /// <returns></returns>
            public static OrderSet GetOrder(string barCode, int workStation, string[] formatStr, All.Class.DataReadAndWrite conn)
            {
                OrderSet result = null;
                if (formatStr == null || formatStr.Length <= 0)
                {
                    All.Class.Log.Add("当前条码格式为空，无法查找对应的订单");
                    return result;
                }
                //将条码还原为格式化的条码即  0000000000000000还原为0000-000-******-00000这种
                string formatValue = "";
                string orderBar = barCode;
                for (int i = 0; i < formatStr.Length; i++)
                {
                    if (All.Class.Num.GetVisableStr(formatStr[i]).Length == barCode.Length)
                    {
                        formatValue = formatStr[i];
                        break;
                    }
                }
                if (formatValue == "")
                {
                    All.Class.Log.Add(string.Format("当前条码没有找到相应的条码格式\r\n当前条码  ->  {0}", barCode), Environment.StackTrace);
                    return result;
                }

                byte[] buff = Encoding.ASCII.GetBytes(formatValue);
                int startX = -1;
                int endX = -1;
                for (int i = 0; i < buff.Length; i++)
                {
                    if (buff[i] == Convert.ToByte('*'))
                    {
                        endX = i;
                        if (startX < 0)
                        {
                            startX = i;
                        }
                        continue;
                    }
                    //barCode = barCode.Insert(i, Encoding.ASCII.GetString(new byte[] { buff[i] }));
                }
                if (startX < 0 || endX < 0)
                {
                    All.Class.Log.Add(string.Format("当前条码格式没有找到流水号的位置\r\n当前格式  ->  {0}", formatValue), Environment.StackTrace);
                    return result;
                }
                int index = All.Class.Num.ToInt(barCode.Substring(startX, endX - startX + 1));
                orderBar = barCode.Substring(0, startX).PadRight(endX + 1, '*') + barCode.Substring(endX + 1);
                //找数据库的条码源列
                string sourceColumnName = "";
                switch (workStation)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        sourceColumnName = "BarCode";
                        break;
                    case 11:
                        sourceColumnName = "LenNingCode";
                        break;
                }
                using (DataTable dt = conn.Read(string.Format("select * from SetOrder where {0}='{1}'", sourceColumnName, orderBar)))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int start = 0;
                        int end = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            start = All.Class.Num.ToInt(dt.Rows[i]["BarStart"]);
                            end = All.Class.Num.ToInt(dt.Rows[i]["BarEnd"]);
                            if (start <= index && index <= end)
                            {
                                result = new OrderSet();
                                result.OrderName = All.Class.Num.ToString(dt.Rows[i]["OrderName"]);
                                result.LenNingCode = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["LenNingCode"]));
                                result.LenNingStart = All.Class.Num.ToInt(dt.Rows[i]["LenNingStart"]);
                                result.LenNingEnd = All.Class.Num.ToInt(dt.Rows[i]["LenNingEnd"]);
                                result.BarCode = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["BarCode"]));
                                result.BarStart = All.Class.Num.ToInt(dt.Rows[i]["BarStart"]);
                                result.BarEnd = All.Class.Num.ToInt(dt.Rows[i]["BarEnd"]);
                                result.OrderTime = All.Class.Num.ToDateTime(dt.Rows[i]["OrderTime"]);
                                result.OrderYear = All.Class.Num.ToInt(dt.Rows[i]["OrderYear"]);
                                result.OrderMonth = All.Class.Num.ToInt(dt.Rows[i]["OrderMonth"]);
                                result.OrderDay = All.Class.Num.ToInt(dt.Rows[i]["OrderDay"]);
                                result.PrintFile = All.Class.Num.GetVisableStr(All.Class.Num.ToString(dt.Rows[i]["PrintFile"]));
                                result.BoShi = All.Class.Num.ToString(dt.Rows[i]["BoShi"]);
                                break;
                            }
                        }
                    }
                }
                return result;
            }
            //public static string GetZheWangNextBarCode(List<OrderSet> orderSet, string modeID, All.Class.DataReadAndWrite conn)
            //{
            //    string result = "";
                //int StartX = 0;
                //int EndX = 0;
                //int orderIndex = orderSet.FindIndex(
                //    order =>
                //    {
                //        if (order.LenNingCode != modeID)
                //        {
                //            return false;
                //        }

                //        string sql = string.Format("select Top 1 LenNingCode from PrintLenNing where orderName='{0}' order by id  Desc" ,order.OrderName);
                //        using (DataTable dt = conn.Read(sql))
                //        {
                //            if (dt != null && dt.Columns.Count > 0)
                //            {

                //                int index = All.Class.Num.ToInt(All.Class.Num.ToString(dt.Rows[0]["LenNingCode"]).Substring(startX, endX - startX + 1)) + 1;
                //                if (index >= start && index <= end)
                //                {
                //                    result = code.Replace("".PadLeft(endX - startX + 1, '*'), string.Format(string.Format("{0}{1}{2}", "{0:D", endX - startX + 1, "}"), index));
                //                }

                //                else
                //                {
                //                    result = code.Replace("".PadLeft(endX - startX + 1, '*'), string.Format(string.Format("{0}{1}{2}", "{0:D", endX - startX + 1, "}"), start));
                //                }
                //            }
                //            else
                //            {
                //                All.Class.Log.Add(string.Format("读取数据库失败\r\n读取语句  ->  ", sql), Environment.StackTrace);
                //            }
                //        }
                //        return true;
                //    });


            //    return result;
            //}
            /// <summary>
            /// 获取指定工位的下一条码
            /// </summary>
            /// <param name="orderSet"></param>
            /// <param name="workIndex"></param>
            /// <returns></returns>
            public static string GetNextBarCode(OrderSet orderSet, int workIndex, All.Class.DataReadAndWrite conn)
            {
                if (orderSet.BoShi != "博世")
                {
                    return "";
                }
                string result = "";//返回结果
                string columnName = "";//查表的列名
                string tableName = "";//查询的表名
                int startX = 0;//*号的开始位置
                int endX = 0;//*号的结束位置
                int start = 0;//条码的起始号
                int end = 0;//条码的结束号
                string code = "";//条码号
                switch (workIndex)
                {
                    case 1:
                        columnName = "BarCode";
                        tableName = "PrintMachine";
                        startX = orderSet.BarCode.IndexOf('*');
                        endX = orderSet.BarCode.LastIndexOf('*');
                        code = orderSet.BarCode;
                        start = orderSet.BarStart;
                        end = orderSet.BarEnd;
                        break;
                    case 11:
                        columnName = "LenNingCode";
                        tableName = "PrintLenNing";
                        startX = orderSet.LenNingCode.IndexOf('*');
                        endX = orderSet.LenNingCode.LastIndexOf('*');
                        code = orderSet.LenNingCode;
                        start = orderSet.LenNingStart;
                        end = orderSet.LenNingEnd;
                        break;
                }
                string sql = string.Format("select  {0} from {1} where orderName='{2}' order by {0}", columnName, tableName, orderSet.OrderName);
                using (DataTable dt = conn.Read(sql))
                {
                    if (dt != null && dt.Columns.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            List<int> allOrderIndex = new List<int>();//所有订单中要打印的序号
                            for (int i = start; i <= end; i++)
                            {
                                allOrderIndex.Add(i);
                            }
                            int index = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                index = All.Class.Num.ToInt(All.Class.Num.ToString(dt.Rows[i][columnName]).Substring(startX, endX - startX + 1));
                                if (allOrderIndex.Contains(index))
                                {
                                    allOrderIndex.Remove(index);//从所有要打印的序号中移除已打印的序号
                                }
                            }
                            for (int i = 0; i < allOrderIndex.Count; i++)
                            {
                                if (allOrderIndex[i] >= start && allOrderIndex[i] <= end)
                                {
                                    result = code.Replace("".PadLeft(endX - startX + 1, '*'), string.Format(string.Format("{0}{1}{2}", "{0:D", endX - startX + 1, "}"), allOrderIndex[i]));
                                    break;
                                }
                            }
                        }
                        else
                        {
                            result = code.Replace("".PadLeft(endX - startX + 1, '*'), string.Format(string.Format("{0}{1}{2}", "{0:D", endX - startX + 1, "}"), start));
                        }
                    }
                    else
                    {
                        All.Class.Log.Add(string.Format("读取数据库失败\r\n读取语句  ->  ", sql), Environment.StackTrace);
                    }
                }
                //DateTime now = DateTime.Now;
                //result = result.ToUpper();
                //result = result.Replace("YYYY", string.Format("{0:yyyy}", now));
                //result = result.Replace("YY", string.Format("{0:yy}", now));
                //result = result.Replace("MM", string.Format("{0:MM}", now));
                //result = result.Replace("DD", string.Format("{0:dd}", now));
                return result;// = All.Class.Num.GetVisableHex(result);
            }
        }
        #endregion
}
