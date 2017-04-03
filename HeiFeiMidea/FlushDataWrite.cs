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

        bool clearAllCountPerHour = false;
        bool clearAllUser = false;
        bool clearOEE = false;
        public delegate void ClearHourOverHandle();
        /// <summary>
        /// 清除事件
        /// </summary>
        public event ClearHourOverHandle ClearHourOver;
        public override void Load()
        {
            //每打开一次，则清除一次故障
            frmMain.mMain.AllDataBase.Write.ClearAllTmpError();
        }
        public override void Flush()
        {
            if (ClearHour)
            {
                if (!clearAllCountPerHour)
                {
                    clearAllCountPerHour = frmMain.mMain.AllDataBase.Write.ClearAllCountPerHour();
                }
                if (!clearAllUser)
                {
                    clearAllUser = frmMain.mMain.AllDataBase.Write.ClearAllUser();
                }
                if (!clearOEE)
                {
                    clearOEE = frmMain.mMain.AllDataBase.Write.ClearOEE();
                }
                ClearHour = !(clearAllCountPerHour && clearAllUser && clearOEE);
                if (!ClearHour)
                {
                    if (ClearHourOver != null)
                    {
                        ClearHourOver();
                    }
                }
            }
        }
    }
}
