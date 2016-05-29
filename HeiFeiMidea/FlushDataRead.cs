using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class FlushDataRead:All.Class.FlushAll.FlushMethor
    {
        public override void Load()
        {
        }
        public override void Flush()
        {
            int start = Environment.TickCount;
            //读取主机须要的计时数据
            frmMain.mMain.AllDataBase.Read.FlushPcTickShow();
            //读取主机须要的订单数据
            frmMain.mMain.AllDataBase.Read.FlushPcOrderShow();
            //读取主机须要显示的小时产量
            frmMain.mMain.AllDataBase.Read.FlushPcHourCountShow();

            if ((Environment.TickCount - start) > 1000)
            {
                All.Class.Log.Add(string.Format("警告：FlushDataRead.Flush刷新数据库响应时间过长,可能影响数据实时性,响应时间,{0}ms", (Environment.TickCount - start)),Environment.StackTrace);
            }
        }
    }
}
