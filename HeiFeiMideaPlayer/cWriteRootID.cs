using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class cWriteRootID:All.Class.FlushAll.FlushMethor
    {
        public enum AllSpace:int
        {
            /// <summary>
            /// 复位比对结果与写入比对失败
            /// </summary>
            条码比对信号1 = 0,
            /// <summary>
            /// 写入比对成功
            /// </summary>
            条码比对信号2
        }
        public class RootID
        {
            public AllSpace Space
            { get; set; }
            /// <summary>
            /// 是否写入
            /// </summary>
            public bool WriteNow
            { get; set; }
            public ushort UshortValue
            { get; set; }
            public string StringValue
            { get; set; }
            public RootID(AllSpace space)
            {
                this.Space = space;
                WriteNow = false;
                UshortValue = 0;
                StringValue = "";
            }
            public void Write()
            {
                if (WriteNow)
                {
                    switch (Space)
                    {
                        case AllSpace.条码比对信号1:
                            if (frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].WriteInternal<ushort>(UshortValue, 0))
                            {
                                WriteNow = false;
                            }
                            break;
                        case AllSpace.条码比对信号2:
                            if (frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].WriteInternal<string>(StringValue, 0))
                            {
                                WriteNow = false;
                            }
                            break;
                    }
                }
            }
            public void Add(string value)
            {
                this.StringValue = value;
                WriteNow = true;
            }
            public void Add(ushort value)
            {
                this.UshortValue = value;
                WriteNow = true;
            }
        }
        public List<RootID> AllWrite
        { get; set; }
        public cWriteRootID()
        {
            AllWrite = new List<RootID>();
            string[] allSpace = Enum.GetNames(typeof(AllSpace));
            for (int i = 0; i < allSpace.Length; i++)
            {
                AllWrite.Add(new RootID((AllSpace)Enum.Parse(typeof(AllSpace), allSpace[i])));
            }
        }
        public override void Load()
        {
            //throw new NotImplementedException();
        }
        public override void Flush()
        {
            for (int i = 0; i < AllWrite.Count; i++)
            {
                AllWrite[i].Write();
            }
        }
    }
}
