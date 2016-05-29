using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新性能检测实时数据
    /// </summary>
    public class FlushSingleTestTmp:All.Class.FlushAll.FlushMethor
    {
        string dataFile = "";
        public FlushSingleTestTmp()
        {
        }
        public override  void Flush()
        {
            if (frmMain.mMain.AllDataBase.TestDataTmp != null
                && frmMain.mMain.AllDataBase.TestDataTmp.Conn.State == System.Data.ConnectionState.Open)
            {
            //frmMain.mMain.AllDataBase.TestDataTmp.Write(string.Format("update AllTestStatue Set RandomValue={0}",(int)( All.Class.Num.GetRandom(0, 100))));
                ConnectOkFlushData();
            }
            else
            {
                frmMain.mMain.AllDataBase.TestDataTmp = All.Class.DataReadAndWrite.GetData(dataFile, "TestDataTmp");
            }
        }
        private void ConnectOkFlushData()
        {
            string sqlTmpValue = "";
            for (int i = 0; i < frmMain.mMain.FlushSingleTest.ShowColor.Length; i++)
            {
                if (frmMain.mMain.FlushSingleTest.ShowColor[i] == System.Drawing.Color.Yellow)
                {
                    sqlTmpValue = string.Format("{0} or TestNo={1} or TestNo={2}", sqlTmpValue, i + 1, i + 161);
                }
            }
            if (sqlTmpValue != "")//有机器正在测试，保存临时数据
            {
                using (DataTable dt = frmMain.mMain.AllDataBase.TestDataTmp.Read(string.Format("select * from AllTestDataTmp where 1=2 {0}", sqlTmpValue)))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        FlushSingleTest.Test test;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            test = new FlushSingleTest.Test();
                            test.TestTime = All.Class.Num.ToDateTime(dt.Rows[i]["TestTime"]);
                            test.BarCode = All.Class.Num.ToString(dt.Rows[i]["Bar"]);
                            test.ID = All.Class.Num.ToString(dt.Rows[i]["ID"]);
                            test.Mode = All.Class.Num.ToString(dt.Rows[i]["Mode"]);
                            test.TestNo = All.Class.Num.ToInt(dt.Rows[i]["TestNo"]);
                            test.JiQi = All.Class.Num.ToInt(dt.Rows[i]["JiQi"]);
                            test.IsPass = All.Class.Num.ToBool(dt.Rows[i]["IsPass"]);
                            test.StepID = All.Class.Num.ToInt(dt.Rows[i]["StepID"]);
                            test.Step = All.Class.Num.ToString(dt.Rows[i]["Step"]);
                            for (int j = 0; j < test.D.Length; j++)
                            {
                                test.D[j] = All.Class.Num.ToFloat(dt.Rows[i][string.Format("d{0}", j)]);
                            }
                            for (int j = 0; j < test.B.Length; j++)
                            {
                                test.B[j] = All.Class.Num.ToBool(dt.Rows[i][string.Format("b{0}", j)]);
                            }
                            test.SaveTmp();
                        }
                    }
                }
            }
        }
        public override void Load()
        {
            dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());
        }
    }
}
