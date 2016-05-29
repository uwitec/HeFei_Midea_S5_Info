using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class FlushDataWrite:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 是否须要清除小时产量
        /// </summary>
        public static bool ClearHour = false;

        public override void Load()
        {
            //每打开一次，则清除一次故障
            frmMain.mMain.AllDataBase.Write.ClearAllTmpError();
        }
        public override void Flush()
        {
            if (ClearHour)
            {
                ClearHour = false;
                frmMain.mMain.AllDataBase.Write.ClearAllCountPerHour();
                frmMain.mMain.AllDataBase.Write.ClearAllUser();
                frmMain.mMain.AllDataBase.Write.ClearOEE();
            }
        }
    }
}
