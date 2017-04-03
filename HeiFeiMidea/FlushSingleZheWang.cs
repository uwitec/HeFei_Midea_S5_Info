using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新折弯机状态
    /// </summary>
    public class FlushSingleZheWang:All.Class.FlushAll.FlushMethor
    {
        ZheWang zheWang = new ZheWang();
        public bool Blink
        {
            get
            {
                return !zheWang.Connect;
            }
        }
        public System.Drawing.Color Color
        {
            get
            {
                if (!zheWang.Connect )
                {
                    return System.Drawing.Color.Purple;
                }
                if (zheWang.Error)
                {
                    return System.Drawing.Color.Red;
                }
                if (zheWang.Hold)
                {
                    return System.Drawing.Color.Yellow;
                }
                return System.Drawing.Color.Green;
            }
        }
        public override void Flush()
        {
            if (zheWang.Connect != frmMain.mMain.AllMeterData.AllCommunite[33].Sons[0].Conn)
            {
                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.折弯机))
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info("折弯机通讯故障", (zheWang.Connect ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del)));
                }
                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.折弯机, zheWang.Connect ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
            }
            zheWang.Connect = frmMain.mMain.AllMeterData.AllCommunite[33].Sons[0].Conn;
            if (zheWang.Connect)
            {
                zheWang.SetValue(frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[0]);
            }

        }
        public override void Load()
        {

        }
        public class ZheWang
        {
            public bool Connect
            { get; set; }
            public bool Error
            { get; set; }
            public bool Run
            { get; set; }
            public bool Hold
            { get; set; }
            public ZheWang()
            {
                Connect = true;
                Error = false;
                Run = false;
                Hold = false;
            }
            public void SetValue(byte value)
            {
                bool[] tmpBool = All.Class.Num.Byte2Bool(new byte[]{ value });
                Run = tmpBool[0];
                Hold = tmpBool[2];
                if (Error != tmpBool[1])
                {
                    frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.折弯机, tmpBool[0] ? FlushAllError.ChangeList.Add : FlushAllError.ChangeList.Del);
                }
                Error = tmpBool[1];
            }
        }
    }
}
