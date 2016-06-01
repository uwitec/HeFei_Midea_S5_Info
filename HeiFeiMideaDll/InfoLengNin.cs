using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaDll
{
    /// <summary>
    /// 冷凝器线工位信息
    /// </summary>
    public class InfoLengNin
    {
            /// <summary>
            /// 工位号
            /// </summary>
            public int WorkStation
            { get; set; }
            /// <summary>
            /// 工位名称
            /// </summary>
            public string StationName
            { get; set; }
            /// <summary>
            /// 是否检测工位
            /// </summary>
            public bool TestStation
            { get; set; }
            /// <summary>
            /// 超时时间
            /// </summary>
            public int TimeOut
            { get; set; }
            /// <summary>
            /// 登陆用户
            /// </summary>
            public string UserName
            { get; set; }
        public InfoLengNin(int workStation)
        {
                WorkStation = workStation;
                StationName = "";
                TestStation = false;
                TimeOut = 0;
                UserName = "";
        }
        /// <summary>
        /// 从数据库加载设置数据
        /// </summary>
        /// <param name="conn"></param>
        public static List<InfoLengNin> Load(All.Class.DataReadAndWrite conn)
        {
            List<InfoLengNin> result = new List<InfoLengNin>();
            InfoLengNin tmp;
            using (DataTable dt = conn.Read("select WorkStation,StationName,TestStation,TimeOut,UserName from InfoLengNinStation order by WorkStation"))
            {
                if (dt != null && dt.Rows.Count == HeiFeiMideaDll.cMain.AllLengNinQiCount)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmp = new InfoLengNin(All.Class.Num.ToInt(dt.Rows[i]["WorkStation"]));
                        tmp.StationName = All.Class.Num.ToString(dt.Rows[i]["StationName"]);
                        tmp.TestStation = All.Class.Num.ToBool(dt.Rows[i]["TestStation"]);
                        tmp.TimeOut = All.Class.Num.ToInt(dt.Rows[i]["TimeOut"]);
                        tmp.UserName = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                        result.Add(tmp);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        public static bool Save(List<InfoLengNin> infoLengNin, All.Class.DataReadAndWrite conn)
        {
            bool result = true;
            if (infoLengNin != null)
            {
                for (int i = 0; i < infoLengNin.Count; i++)
                {
                    result = result & (conn.Write(string.Format("update InfoLengNinStation Set StationName='{0}',TestStation='{1}',TimeOut={2} where WorkStation={3}", infoLengNin[i].StationName, infoLengNin[i].TestStation, infoLengNin[i].TimeOut, infoLengNin[i].WorkStation)) == 1);
                }
            }
            return result;
        }
    }
    /// <summary>
    /// 用户设置
    /// </summary>
    public class LengNinUser
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
        public LengNinUser()
            : this("", "")
        {
        }
        public LengNinUser(string text, string word)
        {
            this.Text = text;
            this.Word = word;
            Use = new bool[cMain.AllLengNinQiCount];
            Use.Initialize();
        }
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static bool InsertUser(LengNinUser user, All.Class.DataReadAndWrite conn)
        {
            string tmpUse = "";
            for (int i = 0; i < user.Use.Length; i++)
            {
                tmpUse = string.Format("{0},'{1}'", tmpUse, user.Use[i]);
            }
            return conn.Write(string.Format("insert into SetUsersLengNin values('{0}','{1}','{2:yyyy-MM-dd HH:mm:ss}'{3})",
                user.Text, user.Word, DateTime.Now, tmpUse)) >= 1;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DeleteUser(string userName, All.Class.DataReadAndWrite conn)
        {
            return conn.Write(string.Format("delete from SetUsersLengNin where UserName='{0}'", userName)) >= 1;
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static bool UpdatePassword(string user, string password, All.Class.DataReadAndWrite conn)
        {
            return conn.Write(string.Format("update SetUsersLengNin Set UserPassword='{0}' where UserName='{1}'", password, user)) >= 1;
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UpdateUser(LengNinUser user, All.Class.DataReadAndWrite conn)
        {
            DeleteUser(user.Text, conn);
            return InsertUser(user , conn);
        }
        /// <summary>
        /// 获取用户名设置
        /// </summary>
        /// <returns></returns>
        public static List<LengNinUser> GetAllUser(All.Class.DataReadAndWrite conn)
        {
            List<LengNinUser> user = new List<LengNinUser>();
            LengNinUser tmpUserSet;
            using (DataTable dt = conn.Read("select * from SetUsersLengNin order by InTime"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tmpUserSet = new LengNinUser();
                        tmpUserSet.Text = All.Class.Num.ToString(dt.Rows[i]["UserName"]);
                        tmpUserSet.Word = All.Class.Num.ToString(dt.Rows[i]["UserPassword"]);
                        for (int j = 0; j < cMain.AllLengNinQiCount; j++)
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
