using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新单个小屏工位所须要的数据
    /// </summary>
    public class FlushStatueStation : All.Class.FlushAll.FlushMethor
    {
        int start = 0;
        public override void Flush()
        {
            start = Environment.TickCount;
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllComputerShowCount; i++)
            {
                frmMain.mMain.AllCars.AllStatueStation[i].FlushStatue(false);
            }
            if ((Environment.TickCount - start) > 1000)
            {
                All.Class.Log.Add(string.Format("警告：FlushStatueStation.Flush刷新数据库响应时间过长,可能影响数据实时性,响应时间,{0}ms", (Environment.TickCount - start)), Environment.StackTrace);
            }
        }
        public override void Load()
        {
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllComputerShowCount; i++)
            {
                frmMain.mMain.AllCars.AllStatueStation[i].FlushStatue(true);
            }
        }
    }
}
