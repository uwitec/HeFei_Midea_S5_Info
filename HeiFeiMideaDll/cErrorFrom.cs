using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
    public class cErrorFrom
    {
        /// <summary>
        /// 故障源类
        /// </summary>
        public class ErrorFrom
        {
            /// <summary>
            /// 故障源
            /// </summary>
            public string Text
            {set;get;}
            public ErrorFrom(string text)
            {
                this.Text = text;
            }
        }
        /// <summary>
        /// 获取所有故障源
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static List<ErrorFrom> GetAllErrorFrom(All.Class.DataReadAndWrite conn)
        {
            List<ErrorFrom> result = new List<ErrorFrom>();
            using (DataTable dt = conn.Read("select ErrorFrom from SetErrorFrom")) 
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        result.Add(new ErrorFrom(All.Class.Num.ToString(dt.Rows[i]["ErrorFrom"])));
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 保存所有故障源
        /// </summary>
        /// <param name="allErrorFrom"></param>
        /// <returns></returns>
        public static bool SaveAllErrorFrom(List<ErrorFrom> allErrorFrom,All.Class.DataReadAndWrite conn)
        {
            bool result = true;
            WriteAllErrorFrom(conn);
            allErrorFrom.ForEach(
               errorFrom =>
               {
                   result = result && (conn.Write(string.Format("insert into SetErrorFrom (ErrorFrom) Values ('{0}')", errorFrom.Text)) == 1);
               });
            return result;
        }
        /// <summary>
        /// 删除所有故障源
        /// </summary>
        /// <param name="conn"></param>
        public static void WriteAllErrorFrom(All.Class.DataReadAndWrite conn)
        {
            conn.Write("delete from SetErrorFrom");
        }
    }
}
