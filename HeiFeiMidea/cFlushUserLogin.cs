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
        public cFlushUserLogin()
        {
            AllUserStatue = new AllUserLogin[HeiFeiMideaDll.cMain.AllStopStationCount];
            for (int i = 0; i < AllUserStatue.Length; i++)
            {
                AllUserStatue[i] = new AllUserLogin(i + 1);
            }
        }
        /// <summary>
        /// 检查所有用户权限，确定哪些位置是否可以登陆，从而决定是否要显示♀图标
        /// </summary>
        public void FlushAllUserForShowLineIcon()
        {
            //初始化所有工位
            for (int i = 0; i < AllUserStatue.Length; i++)
            {
                AllUserStatue[i].HaveUser = false;
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
                                AllUserStatue[i - 1].HaveUser = true;
                            }
                        }
                    });
            }
        }
        public override void Load()
        {
            FlushAllUserForShowLineIcon();
            InfoLineStation = new List<HeiFeiMideaDll.cDataLocal.InfoLineStation>();
        }
        public override void Flush()
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
        public class AllUserLogin
        {
            /// <summary>
            /// 停车工位
            /// </summary>
            public int LineStation
            { get; set; }
            /// <summary>
            /// 是否有用户设置操作此停车工位
            /// </summary>
            public bool HaveUser
            { get; set; }
            /// <summary>
            /// 是否有用户登陆此停车工位
            /// </summary>
            public bool LoginUser
            { get; set; }
            public AllUserLogin(int lineStation)
            {
                this.LineStation = lineStation;
                this.HaveUser = false;
                this.LoginUser = false;
            }
        }
    }
}
