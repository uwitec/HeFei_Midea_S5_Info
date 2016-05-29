using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
        /// <summary>
        /// 用户设置
        /// </summary>
        public class UserSet
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public string Text
            { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public string Word
            { get; set; }
            /// <summary>
            /// 使用权限
            /// </summary>
            public bool[] Use
            { get; set; }
            public UserSet()
                : this("", "")
            {
            }
            public UserSet(string text, string word)
            {
                this.Text = text;
                this.Word = word;
                Use = new bool[cMain.AllStopStationCount + 1];
                Use.Initialize();
            }
            /// <summary>
            /// 插入用户
            /// </summary>
            /// <param name="userName"></param>
            /// <param name="passWord"></param>
            /// <returns></returns>
            public static  bool InsertUser(UserSet user,All.Class.DataReadAndWrite conn)
            {
                string tmpUse = "";
                for (int i = 0; i < user.Use.Length; i++)
                {
                    tmpUse = string.Format("{0},'{1}'",tmpUse, user.Use[i]);
                }
                return conn.Write(string.Format("insert into SetUsers values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}'{3})",
                    user.Text, user.Word, DateTime.Now, tmpUse)) >= 1;
            }
            /// <summary>
            /// 删除用户
            /// </summary>
            /// <param name="userName"></param>
            /// <returns></returns>
            public static bool DeleteUser(string userName, All.Class.DataReadAndWrite conn)
            {
                return conn.Write(string.Format("delete from SetUsers where UserName='{0}'", userName)) >= 1;
            }
            /// <summary>
            /// 更新用户
            /// </summary>
            /// <param name="user"></param>
            /// <returns></returns>
            public static bool UpdateUser(UserSet user, All.Class.DataReadAndWrite conn)
            {
                DeleteUser(user.Text,conn);
                return InsertUser(user, conn);
            }
            /// <summary>
            /// 获取用户名设置
            /// </summary>
            /// <returns></returns>
            public static List<UserSet> GetAllUser(All.Class.DataReadAndWrite conn)
            {
                List<UserSet> user = new List<UserSet>();
                UserSet tmpUserSet;
                using (DataTable dt = conn.Read("select * from SetUsers order by InTime"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmpUserSet = new UserSet();
                            tmpUserSet.Text = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                            tmpUserSet.Word = All.Class.Num.ToString(dt.Rows[i]["UserPassword"]);
                            for (int j = 0; j < cMain.AllStopStationCount + 1; j++)
                            {
                                tmpUserSet.Use[j] = All.Class.Num.ToBool(dt.Rows[i][string.Format("use{0}", j)]);
                            }
                            user.Add(tmpUserSet);
                        }
                    }
                }
                return user;
            }
        }
}
