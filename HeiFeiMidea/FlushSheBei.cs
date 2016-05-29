using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新设备维护信息
    /// </summary>
    public class FlushSheBei:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 单个设备信息
        /// </summary>
        public class SingleSheBei
        {
            /// <summary>
            /// 设备名称
            /// </summary>
            public string SheBei
            { get; set; }
            /// <summary>
            /// 上次维护时间 
            /// </summary>
            public DateTime Last
            { get; set; }
            /// <summary>
            /// 下次维护时间
            /// </summary>
            public DateTime Next
            { get; set; }
            /// <summary>
            /// 维护周期
            /// </summary>
            public int ZhouQi
            { get; set; }
            /// <summary>
            /// 周期单位
            /// </summary>
            public string DanWei
            { get; set; }
            /// <summary>
            /// 维护录像文件
            /// </summary>
            public string Video
            { get; set; }
            public SingleSheBei()
            {
                SheBei = "";
                Last = DateTime.Now;
                Next = DateTime.Now;
                ZhouQi = 1;
                DanWei = "年";
                Video = "";
            }
        }
        /// <summary>
        /// 所有设备
        /// </summary>
        public List<SingleSheBei> AllSheBei
        { get; set; }
        /// <summary>
        /// 须要维护设备
        /// </summary>
        public List<SingleSheBei> NeedWeiHu
        { get; set; }
        /// <summary>
        /// 即将要维护的设备
        /// </summary>
        public List<SingleSheBei> NextWeiHu
        { get; set; }
        /// <summary>
        /// 即将要维护的显示个数，即取维护时间最近的几个维护数
        /// </summary>
        int NextCount = 5;
        object lockObject = new object();
        public FlushSheBei()
        {
            AllSheBei = new List<SingleSheBei>();
            NeedWeiHu = new List<SingleSheBei>();
            NextWeiHu = new List<SingleSheBei>();
            if (!System.IO.Directory.Exists(string.Format("{0}\\SheBei\\", All.Class.FileIO.GetNowPath())))
            {
                System.IO.Directory.CreateDirectory(string.Format("{0}\\SheBei\\", All.Class.FileIO.GetNowPath()));
            }
        }
        public override void Load()
        {
            Read();
        }
        public bool Write(List<SingleSheBei> SheBei)
        {
            lock (lockObject)
            {
                bool result = true;
                frmMain.mMain.AllDataBase.LocalData.Write("delete from SetSheBei");
                SheBei.ForEach(
                    shebei =>
                    {
                        result = result && (frmMain.mMain.AllDataBase.LocalData.Write(string.Format("insert into SetSheBei Values('{0}','{1:yyyy-MM-dd HH:mm:ss}',{2},'{3}','{4}')",
                            shebei.SheBei, shebei.Last, shebei.ZhouQi, shebei.DanWei, shebei.Video)) == 1);
                    });
                Read();
                return result;
            }
        }
        public void Read()
        {
            lock (lockObject)
            {
                List<SingleSheBei> tmpAllSheBei = new List<SingleSheBei>();
                using (DataTable dt = frmMain.mMain.AllDataBase.ReadData.Read("select * from SetSheBei order by id"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        SingleSheBei tmpSheBei;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            tmpSheBei = new SingleSheBei();
                            tmpSheBei.SheBei = All.Class.Num.ToString(dt.Rows[i]["SheBei"]);
                            tmpSheBei.Last = All.Class.Num.ToDateTime(dt.Rows[i]["Last"]);
                            tmpSheBei.ZhouQi = All.Class.Num.ToInt(dt.Rows[i]["ZhouQi"]);
                            tmpSheBei.DanWei = All.Class.Num.ToString(dt.Rows[i]["DanWei"]);
                            tmpSheBei.Video = All.Class.Num.ToString(dt.Rows[i]["Video"]);
                            tmpAllSheBei.Add(tmpSheBei);
                        }
                    }
                }
                this.AllSheBei = tmpAllSheBei;
            }
        }
        public override void Flush()
        {
            lock (lockObject)
            {
                List<SingleSheBei> tmpNeedWeiHu = new List<SingleSheBei>();
                List<SingleSheBei> tmpNextWeiHu = new List<SingleSheBei>();
                List<int> maxTime = new List<int>();
                int tmpShiJian = 0;
                SingleSheBei tmpSheBei;
                bool insert = false;

                if (this.AllSheBei != null && this.AllSheBei.Count > 0)
                {
                    AllSheBei.ForEach(
                        sheBei =>
                        {
                            //统一单位
                            tmpShiJian = sheBei.ZhouQi;
                            switch (sheBei.DanWei)
                            {
                                case "年":
                                    tmpShiJian = tmpShiJian * 24 * 60 * 365;
                                    break;
                                case "月":
                                    tmpShiJian = tmpShiJian * 24 * 60 * 30;
                                    break;
                                case "周":
                                    tmpShiJian = tmpShiJian * 24 * 60 * 7;
                                    break;
                                case "日":
                                    tmpShiJian = tmpShiJian * 24 * 60 * 1;
                                    break;
                                case "时":
                                    tmpShiJian = tmpShiJian  * 60 * 1;
                                    break;
                            }
                            tmpSheBei = new SingleSheBei();
                            tmpSheBei.Next = sheBei.Last.AddMinutes(tmpShiJian);
                            tmpSheBei.SheBei = sheBei.SheBei;
                            tmpSheBei.Last = sheBei.Last;
                            tmpSheBei.ZhouQi = sheBei.ZhouQi;
                            tmpSheBei.DanWei = sheBei.DanWei;
                            tmpSheBei.Video = sheBei.Video;

                            if (tmpSheBei.Next < DateTime.Now)//马上维护
                            {
                                tmpNeedWeiHu.Add(tmpSheBei);
                            }
                            else//不用马上维护
                            {
                                if (maxTime.Count < NextCount)//个数不足
                                {
                                    insert = false;
                                    for (int i = 0; i < tmpNextWeiHu.Count; i++)
                                    {
                                        if (tmpNextWeiHu[i].Next > tmpSheBei.Next)
                                        {
                                            tmpNextWeiHu.Insert(i, tmpSheBei);//插入适当位置 
                                            insert = true;
                                            break;
                                        }
                                    }
                                    if (!insert)//添加到末尾
                                    {
                                        tmpNextWeiHu.Add(tmpSheBei);
                                    }
                                }
                                else
                                {
                                    insert = false;
                                    if (tmpSheBei.Next < tmpNextWeiHu[NextCount - 1].Next)
                                    {
                                        tmpNextWeiHu.RemoveAt(NextCount - 1);
                                        for (int i = 0; i < tmpNextWeiHu.Count; i++)
                                        {
                                            if (tmpNextWeiHu[i].Next > tmpSheBei.Next)
                                            {
                                                tmpNextWeiHu.Insert(i, tmpSheBei);
                                                insert = true;
                                                break;
                                            }
                                        }
                                        if (!insert)
                                        {
                                            tmpNextWeiHu.Add(tmpSheBei);
                                        }
                                    }
                                }
                            }
                        });
                }
                this.NeedWeiHu = tmpNeedWeiHu;
                this.NextWeiHu = tmpNextWeiHu;
            }
        }
       
    }
}
