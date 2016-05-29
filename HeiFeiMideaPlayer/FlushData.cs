using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class FlushData:All.Class.FlushAll.FlushMethor
    {

        public override void Load()
        {
        }
        public override void Flush()
        {
            frmMain.mMain.CarLocal.Flush(frmMain.mMain.AllDataBase.FlushData);
            frmMain.mMain.FlushNiuJu.Flush(frmMain.mMain.AllDataBase.FlushData);
        }
    }
}
