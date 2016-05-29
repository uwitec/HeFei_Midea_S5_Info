using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class FlushAllUser:All.Class.FlushAll.FlushMethor
    {
        /// <summary>
        /// 所有停车工位信息
        /// </summary>
        public List<HeiFeiMideaDll.cDataLocal.InfoLineStation> allLineStation;
        public FlushAllUser()
        {
            allLineStation = new List<HeiFeiMideaDll.cDataLocal.InfoLineStation>();
        }
        public override void Flush()
        {
            allLineStation = frmMain.mMain.AllDataBase.Local.GetAllInfoLineStation();
        }
        public override void Load()
        {
        }
    }
}
