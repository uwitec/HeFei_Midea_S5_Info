using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新性能检测数据结果
    /// </summary>
    public class FlushSingleTest:All.Class.FlushAll.FlushMethor
    {
        bool[] oldConnect = new bool[4];
        /// <summary>
        /// 连接状态
        /// </summary>
        public bool[] Connect
        {
            get 
            {
                bool[] result = new bool[4];
                for (int i = 0; i < result.Length && i < AllTest.Length; i++)
                {
                    if (oldConnect[i] != AllTest[i].Connect)
                    {
                        if ((DateTime.Now - cMain.StartTime).TotalSeconds > 8)
                        {
                            if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.性能检))
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("性能检测 {0}号工位 通讯出现故障", i + 1), (AllTest[i].Connect ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add)));
                            }
                            frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.性能检, i + 1, "通讯失败", (AllTest[i].Connect ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add), cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.性能检, i + 1));
                            oldConnect[i] = AllTest[i].Connect;
                        }
                    }
                    if (AllTest[i].Connect && AllTest[i].Plc && AllTest[i].Ft2010 && AllTest[i].M7017_1 &&
                        AllTest[i].M7017_2 && AllTest[i].M7017_3 && AllTest[i].M7017_4)
                    {
                        result[i] = true;
                    }
                    else
                    {
                        result[i] = false;
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 显示颜色
        /// </summary>
        public Color[] ShowColor
        {
            get
            {
                Color[] result = new Color[4];
                for (int i = 0; i < result.Length && i < AllTest.Length; i++)
                {
                    if (AllTest[i].Connect && AllTest[i].Plc && AllTest[i].Ft2010 && AllTest[i].M7017_1 &&
                        AllTest[i].M7017_2 && AllTest[i].M7017_3 && AllTest[i].M7017_4)
                    {
                        switch (AllTest[i].NowStatue)
                        {
                            case 0:
                                result[i] = Color.Blue;
                                break;
                            case 1:
                                result[i] = Color.Yellow;
                                break;
                            case 2:
                                result[i] = Color.Red;
                                break;
                            case 3:
                                result[i] = Color.Green;
                                break;
                        }
                    }
                    else
                    {
                        result[i] = Color.Purple;
                    }
                }
                return result;
            }
        }
        EveryTest[] AllTest = new EveryTest[4];
        string dataFile = "";
        public FlushSingleTest()
        {
            oldConnect[0] = true;
            oldConnect[1] = true;
            oldConnect[2] = true;
            oldConnect[3] = true;
            for (int i = 0; i < AllTest.Length; i++)
            {
                AllTest[i] = new EveryTest(i + 1);
            }
        }
        public override  void Flush()
        {
            if (frmMain.mMain.AllDataBase.TestData != null
                && frmMain.mMain.AllDataBase.TestData.Conn.State == System.Data.ConnectionState.Open)
            {
                int start = Environment.TickCount;
                ConnectOkFlushData();
                Console.WriteLine(Environment.TickCount - start);
            }
            else
            {
                frmMain.mMain.AllDataBase.TestData = All.Class.DataReadAndWrite.GetData(dataFile, "TestData");
            }
        }
        private void ConnectOkFlushData()
        {
            using (DataTable dt = frmMain.mMain.AllDataBase.TestData.Read("select * from AllTestStatue order by TestNo"))
            {
                if (dt != null && dt.Rows.Count == 4)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AllTest[i].RandomValue = All.Class.Num.ToInt(dt.Rows[i]["RandomValue"]);
                        AllTest[i].NowStatue = All.Class.Num.ToInt(dt.Rows[i]["NowStatue"]);
                        AllTest[i].Plc = All.Class.Num.ToBool(dt.Rows[i]["Plc"]);
                        AllTest[i].Ft2010 = All.Class.Num.ToBool(dt.Rows[i]["Ft2010"]);
                        AllTest[i].M7017_1 = All.Class.Num.ToBool(dt.Rows[i]["Mod7017_1"]);
                        AllTest[i].M7017_2 = All.Class.Num.ToBool(dt.Rows[i]["Mod7017_2"]);
                        AllTest[i].M7017_3 = All.Class.Num.ToBool(dt.Rows[i]["Mod7017_3"]);
                        AllTest[i].M7017_4 = All.Class.Num.ToBool(dt.Rows[i]["Mod7017_4"]);
                        AllTest[i].AnGui7440 = All.Class.Num.ToBool(dt.Rows[i]["AnGui7440"]);
                        AllTest[i].AnGui7623 = All.Class.Num.ToBool(dt.Rows[i]["AnGui7623"]);
                        AllTest[i].ChouKong = All.Class.Num.ToBool(dt.Rows[i]["ChouKong"]);
                    }
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.TestData.Read(string.Format("select Top 1 * from AllTestAnGui Where Id>{0} order by ID", frmMain.mMain.AllDataXml.LocalSingleFlush.AnGuiIndex)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    AnGui anGui = new AnGui();
                    anGui.BarCode = All.Class.Num.ToString(dt.Rows[0]["BarCode"]);
                    for (int i = 0; i < anGui.d.Length; i++)
                    {
                        anGui.d[i] = All.Class.Num.ToFloat(dt.Rows[0][string.Format("d{0}", i)]);
                    }
                    for (int i = 0; i < anGui.b.Length; i++)
                    {
                        anGui.b[i] = All.Class.Num.ToBool(dt.Rows[0][string.Format("b{0}", i)]);
                    }
                    anGui.Save();
                    frmMain.mMain.AllDataXml.LocalSingleFlush.AnGuiIndex = All.Class.Num.ToInt(dt.Rows[0]["ID"]);
                    frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                }
            }
            using (DataTable dt = frmMain.mMain.AllDataBase.TestData.Read(string.Format("select top 1 * from AllTestData where DataId>{0} order by DataID", frmMain.mMain.AllDataXml.LocalSingleFlush.TestIndex)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Test test = new Test();
                    test.TestTime = All.Class.Num.ToDateTime(dt.Rows[0]["TestTime"]);
                    test.BarCode = All.Class.Num.ToString(dt.Rows[0]["Bar"]);
                    test.ID = All.Class.Num.ToString(dt.Rows[0]["ID"]);
                    test.Mode = All.Class.Num.ToString(dt.Rows[0]["Mode"]);
                    test.TestNo = All.Class.Num.ToInt(dt.Rows[0]["TestNo"]);
                    test.JiQi = All.Class.Num.ToInt(dt.Rows[0]["JiQi"]);
                    test.IsPass = All.Class.Num.ToBool(dt.Rows[0]["IsPass"]);
                    test.StepID = All.Class.Num.ToInt(dt.Rows[0]["StepID"]);
                    test.Step = All.Class.Num.ToString(dt.Rows[0]["Step"]);
                    for (int i = 0; i < test.D.Length; i++)
                    {
                        test.D[i] = All.Class.Num.ToFloat(dt.Rows[0][string.Format("d{0}", i)]);
                    }
                    for (int i = 0; i < test.B.Length; i++)
                    {
                        test.B[i] = All.Class.Num.ToBool(dt.Rows[0][string.Format("b{0}", i)]);
                    }
                    test.Save();
                    frmMain.mMain.AllDataXml.LocalSingleFlush.TestIndex = All.Class.Num.ToInt(dt.Rows[0]["DataID"]);
                    frmMain.mMain.AllDataXml.LocalSingleFlush.Save();
                }
            }
        }
        public override void Load()
        {
            dataFile = string.Format("{0}\\Data\\DataConnect.Mdb", All.Class.FileIO.GetNowPath());
        }
        #region//安规检测结果
        public class AnGui
        {
            public string BarCode
            { get; set; }
            public float[] d
            { get; set; }
            public bool[] b
            { get; set; }
            public AnGui()
            {
                BarCode = "";
                d = new float[4];
                b = new bool[4];
                for (int i = 0; i < d.Length; i++)
                {
                    d[i] = 0;
                }
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = true;
                }
            }
            public void Save()
            {
                if (BarCode == "")
                {
                    return;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(BarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                sql.Write(string.Format("insert into TestAnGui Values('{0}',{1:F3},{2:F3},{3:F3},{4:F3},'{5}','{6}','{7}','{8}')",
                    BarCode, d[0], d[1], d[2], d[3], b[0], b[1], b[2], b[3]));
                sql.Close();
            }
        }
        #endregion
        #region//性能检测结果
        public class Test
        {
            public DateTime TestTime
            { get; set; }
            public string BarCode
            { get; set; }
            public string ID
            { get; set; }
            public string Mode
            { get; set; }
            public int TestNo
            { get; set; }
            public int JiQi
            { get; set; }
            public bool IsPass
            { get; set; }
            public int StepID
            { get; set; }
            public string Step
            { get; set; }
            public float[] D
            { get; set; }
            public bool[] B
            { get; set; }
            public Test()
            {
                this.TestTime = DateTime.Now;
                this.BarCode = "";
                this.ID = "";
                this.Mode = "";
                this.TestNo = 0;
                this.JiQi = 0;
                this.IsPass = true;
                this.StepID = 0;
                this.Step = "";
                D = new float[60];
                B = new bool[60];
                for (int i = 0; i < D.Length; i++)
                {
                    D[i] = 0;
                }
                for (int i = 0; i < B.Length; i++)
                {
                    B[i] = true;
                }
            }
            /// <summary>
            /// 保存实时数据
            /// </summary>
            public void SaveTmp()
            {
                Save("TestJianCeTmp");
            }
            /// <summary>
            /// 保存结果数据
            /// </summary>
            public void Save()
            {
                Save("TestJianCe");
            }
            private void Save(string tableName)
            {
                if (BarCode == "")
                {
                    return;
                }
                All.Class.Sqlce sql = new All.Class.Sqlce();

                if (!sql.Login(CheckTestResultFile.CheckTestFile(BarCode), "AllTestValue.sdf", "", ""))
                {
                    return;
                }
                string sqlstr = "Insert into {0} values('{1:yyyy-MM-dd HH:mm:ss}','{2}','{3}','{4}',{5},{6},'{7}',{8},'{9}'{10}{11})";
                string d = "";
                string b = "";
                for (int i = 0; i < D.Length; i++)
                {
                    d = string.Format("{0},{1:F3}", d, this.D[i]);
                }
                for (int i = 0; i < B.Length; i++)
                {
                    b = string.Format("{0},'{1}'", b, B[i]);
                }
                sql.Write(string.Format(sqlstr,tableName,
                    TestTime, BarCode, ID, Mode, TestNo, JiQi, IsPass, StepID, Step, d, b));
                sql.Close();
            }
        }
        #endregion
        #region//每一工位连接状态
        public class EveryTest
        {
            public int TestNo
            { get; set; }
            public int RandomValue
            { get; set; }
            public int NowStatue
            { get; set; }

            int lastRandomValue = 0;
            int startTime = 0;
            public bool Connect
            {
                get
                {
                    if (lastRandomValue != RandomValue)
                    {
                        lastRandomValue = RandomValue;
                        startTime = Environment.TickCount;
                        return true;
                    }
                    else
                    {
                        if ((Environment.TickCount - startTime) < 5000)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            bool plc = true;

            public bool Plc
            {
                get { return plc; }
                set {
                    if (value != plc)
                    {
                        AddInfo("西门子PLC ", value);
                    }
                    plc = value; }
            }
            bool ft2010 = true;

            public bool Ft2010
            {
                get { return ft2010; }
                set {
                    if (value != ft2010)
                    {
                        AddInfo("电参数模块", value);
                    }
                    ft2010 = value;
                }
            }
            bool m7017_1 = true;

            public bool M7017_1
            {
                get { return m7017_1; }
                set {
                    if (value != m7017_1)
                    {
                        AddInfo("1#7017模块", value);
                    } m7017_1 = value;
                }
            }
            bool m7017_2 = true;

            public bool M7017_2
            {
                get { return m7017_2; }
                set
                {
                    if (value != m7017_2)
                    {
                        AddInfo("2#7017模块", value);
                    } m7017_2 = value;
                }
            }
            bool m7017_3 = true;

            public bool M7017_3
            {
                get { return m7017_3; }
                set
                {
                    if (value != m7017_3)
                    {
                        AddInfo("3#7017模块", value);
                    } m7017_3 = value;
                }
            }
            bool m7017_4 = true;

            public bool M7017_4
            {
                get { return m7017_4; }
                set
                {
                    if (value != m7017_4)
                    {
                        AddInfo("4#7017模块", value);
                    } m7017_4 = value;
                }
            }
            bool anGui7440 = true;

            public bool AnGui7440
            {
                get {
                    if (TestNo == 1)
                    {
                        return anGui7440;
                    }
                    return true;
                }
                set
                {
                    if (value != anGui7440 && TestNo == 1)
                    {
                        AddInfo("SE7440安检仪", value);
                    } anGui7440 = value;
                }
            }
            bool anGui7623 = true;

            public bool AnGui7623
            {
                get
                {
                    if (TestNo == 1)
                    {
                        return anGui7623;
                    }
                    return true;
                }
                set
                {
                    if (value != anGui7623 && TestNo == 1)
                    {
                        //AddInfo("ESC125安检仪", value);
                    } anGui7623 = value;
                }
            }
            bool chouKong = true;

            public bool ChouKong
            {
                get
                {
                    if (TestNo == 1)
                    {
                        return chouKong;
                    }
                    return true;
                }
                set
                {
                    if (value != chouKong && TestNo == 1)
                    {
                        AddInfo("抽真空PLC", value);
                    } chouKong = value;
                }
            }
            public EveryTest(int testNo)
            {
                this.TestNo = testNo;
                this.NowStatue = 0;
                this.RandomValue = 0;
            }
            public void AddInfo(string Space, bool connect)
            {
                if (frmMain.mMain.AllDataXml.ErrorShow.Show(FlushAllError.SpaceList.性能检))
                {
                    frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("性能检测 {0}号工位 {1}  出现故障", TestNo, Space), (connect ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add)));
                }
                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.性能检, this.TestNo, string.Format("{0}故障", Space), (connect ? FlushAllError.ChangeList.Del : FlushAllError.ChangeList.Add), TestNo);
            }
        }
        #endregion
    }
}
