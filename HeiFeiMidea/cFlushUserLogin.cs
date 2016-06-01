using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    public class cFlushUserLogin:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 所有本地设置
        /// </summary>
        public List<HeiFeiMideaDll.cDataLocal.InfoLineStation> InfoLineStation
        { get; set; }
        /// <summary>
        /// 所有用户状态
        /// </summary>
        public AllUserLogin[] AllUserStatue
        { get; set; }
        /// <summary>
        /// 冷凝器线体
        /// </summary>
        public List<HeiFeiMideaDll.InfoLengNin> InfoLengNin
        { get; set; }
        /// <summary>
        /// 冷凝线用户状态
        /// </summary>
        public AllUserLogin[] LengNinUserStatue
        { get; set; }
        object lockObject1 = new object();
        object lockObject2 = new object();
        public cFlushUserLogin()
        {
            AllUserStatue = new AllUserLogin[HeiFeiMideaDll.cMain.AllStopStationCount];
            for (int i = 0; i < AllUserStatue.Length; i++)
            {
                AllUserStatue[i] = new AllUserLogin(i + 1,"");
            }
            LengNinUserStatue = new AllUserLogin[HeiFeiMideaDll.cMain.AllLengNinQiCount];
            for (int i = 0; i < LengNinUserStatue.Length; i++)
            {
                LengNinUserStatue[i] = new AllUserLogin(i + 1,"");
            }
        }
        /// <summary>
        /// 检查所有用户权限，确定哪些位置是否可以登陆，从而决定是否要显示♀图标
        /// </summary>
        public void FlushAllUserForShowLineIcon()
        {
            lock (lockObject1)
            {
                //初始化所有工位
                for (int i = 0; i < AllUserStatue.Length; i++)
                {
                    AllUserStatue[i].HaveUser = false;
                    AllUserStatue[i].LoginUser = false;
                }
                //刷新所有工位
                List<HeiFeiMideaDll.UserSet> AllUserSet = HeiFeiMideaDll.UserSet.GetAllUser(frmMain.mMain.AllDataBase.LocalData);
                if (AllUserSet != null && AllUserSet.Count > 0)
                {
                    AllUserSet.ForEach(
                        userSet =>
                        {
                            if (userSet.Text == "Administrator")
                            {
                                return;
                            }
                            for (int i = 1; i < userSet.Use.Length; i++)//第一个是主机，不算在内
                            {
                                if (userSet.Use[i])
                                {
                                    AllUserStatue[i - 1].UserName = userSet.Text;
                                    AllUserStatue[i - 1].HaveUser = true;
                                }
                            }
                        });
                }
            }
        }
        /// <summary>
        /// 检查冷凝线的用户权限,确定哪些位置是否可以登陆
        /// </summary>
        public void FlushLengNinShowLineIcon()
        {
            lock (lockObject2)
            {
                for (int i = 0; i < LengNinUserStatue.Length; i++)
                {
                    LengNinUserStatue[i].HaveUser = false;
                    LengNinUserStatue[i].LoginUser = false;
                }
                //刷新所有工位
                List<HeiFeiMideaDll.LengNinUser> LengNinUserSet = HeiFeiMideaDll.LengNinUser.GetAllUser(frmMain.mMain.AllDataBase.LocalData);
                if (LengNinUserSet != null && LengNinUserSet.Count > 0)
                {
                    LengNinUserSet.ForEach(
                        userSet =>
                        {
                            if (userSet.Text == "Administrator")
                            {
                                return;
                            }
                            for (int i = 0; i < userSet.Use.Length; i++)
                            {
                                if (userSet.Use[i])
                                {
                                    LengNinUserStatue[i].UserName = userSet.Text;
                                    LengNinUserStatue[i].HaveUser = true;
                                }
                            }
                        });
                }
            }
        }
        public override void Load()
        {
            InfoLineStation = new List<HeiFeiMideaDll.cDataLocal.InfoLineStation>();
            InfoLengNin = new List<HeiFeiMideaDll.InfoLengNin>();
            FlushAllUserForShowLineIcon();
            FlushLengNinShowLineIcon();
        }
        public override void Flush()
        {
            lock (lockObject1)
            {
                //刷新用户登陆
                InfoLineStation = frmMain.mMain.AllDataBase.Local.GetAllInfoLineStation();
                for (int i = 0; i < InfoLineStation.Count; i++)
                {
                    if (InfoLineStation[i].UserName != "")//当前工位已登陆
                    {
                        if (InfoLineStation[i].WorkStation >= 1 && InfoLineStation[i].WorkStation <= HeiFeiMideaDll.cMain.AllStopStationCount)
                        {
                            AllUserStatue[InfoLineStation[i].WorkStation - 1].LoginUser = true;
                        }
                    }
                }
            }
            lock (lockObject2)
            {
                //刷新用户登陆
                InfoLengNin = HeiFeiMideaDll.InfoLengNin.Load(frmMain.mMain.AllDataBase.ReadData);
                for (int i = 0; i < InfoLengNin.Count; i++)
                {
                    if (InfoLengNin[i].UserName != "")
                    {
                        if (InfoLengNin[i].WorkStation >= 1 && InfoLengNin[i].WorkStation <= HeiFeiMideaDll.cMain.AllLengNinQiCount)
                        {
                            LengNinUserStatue[InfoLengNin[i].WorkStation - 1].LoginUser = true;
                        }
                    }
                }
            }
        }
        public class AllUserLogin
        {
            /// <summary>
            /// 停车工位
            /// </summary>
            public int LineStation
            { get; set; }
            bool haveUser = false;
            /// <summary>
            /// 是否有用户设置操作此停车工位
            /// </summary>
            public bool HaveUser
            {
                get
                {
                    return haveUser;
                }
                set
                {
                    if (haveUser != value)
                    {
                        if (value)
                        {
                            frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("[{0}]未登陆系统", this.UserName), FlushAllError.ChangeList.Add));
                        }
                    }
                    haveUser = value;
                }
            }
            /// <summary>
            /// 工位名称
            /// </summary>
            public string UserName
            { get; set; }
            bool loginUser = false;
            /// <summary>
            /// 是否有用户登陆此停车工位
            /// </summary>
            public bool LoginUser
            {
                get { return loginUser; }
                set {
                    if (loginUser != value)
                    {
                        if (value)
                        {
                            frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("[{0}]未登陆系统", this.UserName), FlushAllError.ChangeList.Del));
                        }
                    }
                    loginUser = value; }
            }
            public AllUserLogin(int lineStation,string userName)
            {
                this.UserName = userName;
                this.LineStation = lineStation;
            }
        }
    }
}
