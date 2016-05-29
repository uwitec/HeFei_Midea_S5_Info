using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class FlushNiuJu
    {
        public int CountOne
        { get; set; }
        public int CountTwo
        { get; set; }
        public int CountThree
        { get; set; }
        //public delegate void NiuJuCountChangeHandle(int index, int count,int oldCount);
        //public event NiuJuCountChangeHandle NiuJuCountChange;
        public FlushNiuJu()
        {
            CountOne = 0;
            CountTwo = 0;
            CountThree = 0;
        }
        public void Flush(All.Class.DataReadAndWrite conn)
        {
            bool readOne = false;
            bool readTwo = false;
            bool readThree = false;
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2 ||
                frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7)
            {
                using (DataTable dt = conn.Read("select LuoSi as AllCount,Space from StatueNiuJu order by Space"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int index = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            index = All.Class.Num.ToInt(dt.Rows[i]["Space"]);
                            switch (index)
                            {
                                case 0:
                                    CountOne = All.Class.Num.ToInt(dt.Rows[i]["AllCount"]);
                                    readOne = true;
                                    break;
                                case 1:
                                    CountTwo = All.Class.Num.ToInt(dt.Rows[i]["AllCount"]);
                                    readTwo = true;
                                    break;
                                case 2:
                                    CountThree = All.Class.Num.ToInt(dt.Rows[i]["AllCount"]);
                                    readThree = true;
                                    break;
                            }
                            //if ((frmMain.mMain.AllDataXml.LocalSettings.TestNo == 2 && index == 0)
                            //    || (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7 && index == 1)
                            //    || (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 7 && index == 2))
                            //{
                            //    SetCount(index, All.Class.Num.ToInt(dt.Rows[i]["AllCount"]));
                            //}
                        }
                    }
                }
            }
            if (!readOne)
                CountOne = 0;
            if (!readTwo)
                CountTwo = 0;
            if (!readThree)
                CountThree = 0;
        }
        private void SetCount(int index, int count)
        {
            switch (index)
            {
                case 0:
                    //if (NiuJuCountChange != null)
                    //{
                    //    NiuJuCountChange(index, count, CountOne);
                    //}
                    CountOne = count;
                    break;
                case 1:
                    //if (NiuJuCountChange != null)
                    //{
                    //    NiuJuCountChange(index, count, CountTwo);
                    //}
                    CountTwo = count;
                    break;
                case 2:
                    //if (NiuJuCountChange != null)
                    //{
                    //    NiuJuCountChange(index, count, CountThree);
                    //}
                    CountThree = count;
                    break;
            }
        }
    }
}