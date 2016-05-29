using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HeiFeiMideaPlayer
{
    public class FlushZheWang:All.Class.FlushAll.FlushMethor
    {
        public ZheWang ZheWangJi = new ZheWang(frmMain.mMain.AllDataBase.FlushData);
        public override void Flush()
        {
            ZheWangJi.Flush(frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[54]);
        }
        public override void Load()
        {
        }
        public class ZheWang
        {
            /// <summary>
            /// 折弯机折弯状态
            /// </summary>
            public bool TestOver
            {get;set;}
            /// <summary>
            /// 当前使用折弯机型
            /// </summary>
            public string ZheWangJiXing
            {get;set;}
            /// <summary>
            /// 折弯完成
            /// </summary>
            /// <param name="Mode"></param>
            public delegate void ZheWangOverHandle(string Mode);
            /// <summary>
            /// 折弯完成,出机
            /// </summary>
            public event ZheWangOverHandle ZheWangOver;

            All.Class.DataReadAndWrite sql;

            DataTable dtZheWang;

            bool testOver = true;
            public ZheWang(All.Class.DataReadAndWrite SQL)
            {
                sql = SQL;
                dtZheWang = sql.Read("Select * from StatueZheWang");
                dtZheWang.TableName = "StatueZheWang";
                Data2Class(true);
            }
            public void Flush(byte StatueValue)
            {
                bool[] tmpBool = All.Class.Num.Byte2Bool(new byte[] { StatueValue });

                dtZheWang.Rows[0]["Run"] = tmpBool[0];
                dtZheWang.Rows[0]["Error"] = tmpBool[1];
                dtZheWang.Rows[0]["Hold"] = tmpBool[2];//待机
                dtZheWang.Rows[0]["TestOver"] = tmpBool[3];

                if (tmpBool[3])
                {
                    List<byte> buff = new List<byte>();
                    Dictionary<string, string> parm = new Dictionary<string, string>();
                    parm.Add("Start", "206");
                    parm.Add("End", "216");
                    if (frmMain.mMain.AllMeterData.AllCommunite[5].Sons[0].Read<byte>(out buff, parm))
                    {
                        dtZheWang.Rows[0]["ZheWangJiXing"] = Encoding.ASCII.GetString(buff.ToArray());
                    }
                }

                Data2Class(false);

                sql.BlockCommand(dtZheWang);

            }
            private void Data2Class(bool init)
            {
                if (dtZheWang != null && dtZheWang.Rows.Count > 0)
                {
                    TestOver = All.Class.Num.ToBool(dtZheWang.Rows[0]["TestOver"]);
                    ZheWangJiXing = All.Class.Num.ToString(dtZheWang.Rows[0]["ZheWangJiXing"]);
                    if (TestOver != testOver && TestOver)
                    {
                        if (ZheWangOver != null)
                        {
                            ZheWangOver(ZheWangJiXing);
                        }
                    }
                    testOver = TestOver;
                }
            }
        }
    }
}
