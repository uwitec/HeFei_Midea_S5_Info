using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class FlushMeter : All.Class.FlushAll.FlushMethor
    {
        public FlushMeter()
        {
        }
        public override void Load()
        {
            frmMain.mMain.AllMeterData.AllReadValue.StringValue.ChangeValue += StringValue_ChangeValue;
            frmMain.mMain.AllMeterData.ReadMeterOnce += AllMeterData_ReadMeterOnce;
            frmMain.mMain.AllMeterData.AllReadValue.UshortValue.ChangeValue += UshortValue_ChangeValue;
        }

        private void UshortValue_ChangeValue(ushort Value, ushort OldValue, string Info, int index)
        {
            //Dictionary<string, string> parm;
            //ushort[] sendValue;
            switch (index)
            {
                case 196://工位2上传的压缩机复位信号
                    //parm = new Dictionary<string, string>();
                    //parm.Add("Start", "782");
                    //parm.Add("End", "782");
                    //parm.Add("Block", "100");
                    //sendValue = new ushort[1];
                    if (Value > 2)//所有大于2的数都是复位信号
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.压缩机比对结果, 0);
                        //sendValue[0] = 0;
                    }
                    else//小于2的数，是比对结果
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.压缩机比对结果, Value);
                        //sendValue[0] = Value;
                    }
                    //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                    break;
                case 200://相机结果
                    frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + 8].Sons[0].Write<ushort>(Value, 0);
                    break;
                case 181://当工位5的机器人读到冷凝器比对信号后，复位远程PLC比对结果
                    if (Value <= 0)
                    {
                        return;
                    }
                    frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.冷凝器结果, 0);
                    //parm = new Dictionary<string, string>();
                    //parm.Add("Start", "786");
                    //parm.Add("End", "786");
                    //parm.Add("Block", "100");
                    //sendValue = new ushort[1];
                    //sendValue[0] = 0;
                    //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                    
                    break;
                case 201://工位5上传冷凝器信号,往远程PLC写入比对结果
                    if (Value == 0)
                    {
                        return;
                    }
                    //parm = new Dictionary<string, string>();
                    //parm.Add("Start", "786");
                    //parm.Add("End", "786");
                    //parm.Add("Block", "100");
                    //sendValue = new ushort[1];
                    switch (Value)
                    {
                        case 1:
                        case 2:
                            //sendValue[0] = Value;
                            frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.冷凝器结果, Value);
                            break;
                    }
                    //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<ushort>(sendValue.ToList(), parm);
                    break;
            }
        }

        private void AllMeterData_ReadMeterOnce(All.Communite.Communite communite, All.Meter.Meter meter, int communiteIndex)
        {
        }
        private void StringValue_ChangeValue(string Value, string OldValue, string Info, int index)
        {
            //Dictionary<string, string> parm;
            Dictionary<string, string> buff;
            //index 0~29  小车号的条码，从PLC上传
            //index 30~62 11个小屏上传的条码
            //index 63~95 11个小屏上传的用户名
            //index 96~106 11个小屏上传的版本号
            switch (index)
            {
                case 30://上线工位上传条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.上线条码, buff["BarCode"]);

                        if (frmMain.mMain.AllCars.AllStatueStation[0].BarCode != buff["BarCode"] 
                            && buff.ContainsKey("BoShiBarCode")
                            && buff.ContainsKey("Mode")
                            && buff.ContainsKey("OrderName"))
                        {
                            if (buff["BoShiBarCode"].Length > 20)
                            {
                                frmMain.mMain.AllDataBase.DataBarCode.Write(string.Format("delete from AllBarCode where Midea='{0}'", buff["BarCode"]));
                                frmMain.mMain.AllDataBase.DataBarCode.Write(string.Format("insert into AllBarCode (Midea,Boss,Mode,OrderName) values ('{0}','{1}','{2}','{3}')", buff["BarCode"], buff["BoShiBarCode"], buff["Mode"], buff["OrderName"]));
                                frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart].Sons[0].Write<string>(string.Format("{0}{1:HH:mm:ss}", All.Class.Num.GetRandom(0, 1), DateTime.Now), 1);//复位下一生成条码指令
                            }
                        }
                    }
                    break;
                case 33://压缩机上传条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("YaSuoJiBarCode") && buff.ContainsKey("BarCode") && buff.ContainsKey("Result") && buff.ContainsKey("Index"))
                    {
                        bool result = All.Class.Num.ToBool(buff["Result"]);
                        int yaSuoJiIndex = All.Class.Num.ToInt(buff["Index"]);
                        frmMain.mMain.FlushSingleYaSuoJi.Save(yaSuoJiIndex, buff["YaSuoJiBarCode"], result, buff["BarCode"]);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 42://冷凝器处工位上传条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.冷凝器返修条码, buff["BarCode"]);
                        //parm = new Dictionary<string, string>();
                        //parm.Add("Start", "30");
                        //parm.Add("End", "0");
                        //parm.Add("Block", "100");
                        //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<string>(
                        //   (new string[] { buff["BarCode"] }).ToList(), parm);
                    }
                    break;
                case 43://冷凝器上线，数据合并
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("LengNingBarCode") && buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.AllDataBase.Write.BindTwoBar(buff["LengNingBarCode"]);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 48://电控条码 
                case 49://风机条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode") && buff.ContainsKey("TestBarCode"))
                    {
                        FlushSingleYaSuoJi.FengJiYaSuoJiDianKong tmp = new FlushSingleYaSuoJi.FengJiYaSuoJiDianKong();
                        tmp.TestBar = buff["TestBarCode"];
                        tmp.BarCode = buff["BarCode"];
                        tmp.Result = true;
                        tmp.TestName = (index == 48 ? "电控" : "风机");
                        tmp.Save();
                    }
                    else
                    { return; }
                    break;
                case 51://卤检工位上传条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.卤检条码, buff["BarCode"]);
                        //parm = new Dictionary<string, string>();
                        //parm.Add("Start", "60");
                        //parm.Add("End", "0");
                        //parm.Add("Block", "100");
                        //frmMain.mMain.AllMeterData.AllCommunite[0].Sons[0].Write<string>(
                        //   (new string[] { buff["BarCode"] }).ToList(), parm);
                    }
                    break;
                case 60://折弯上线1工位条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.冷凝器线条码1, buff["BarCode"]);
                    }
                    break;
                case 61://折弯工位补3工位条码
                    buff = All.Class.SSFile.Text2Dictionary(Value);
                    if (buff.ContainsKey("BarCode"))
                    {
                        frmMain.mMain.WriteRootID.Write(cWriteRootID.AllRootSpace.冷凝器线条码2, buff["BarCode"]);
                    }
                    break;
                //版本号
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                case 104:
                case 105:
                case 106:
                    LockAllPlayFile.AllPlayCode.SetCode(index - 96, All.Class.SSFile.Text2Dictionary(Value));
                        frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + index - 96]
                            .Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(HeiFeiMideaDll.cProgramCode.GetExeUpdate(All.Class.SSFile.Text2Dictionary(Value),"")), 0);
                    break;
            }
        }
        public override void Flush()
        {
            for (int i = 0; i < HeiFeiMideaDll.cMain.AllTestComputer; i++)
            {
                if (i != 9)//打包工位，给美的用了。不用再操作了。
                {
                    frmMain.mMain.AllMeterData.AllCommunite[HeiFeiMideaDll.cMain.RemotWriteStart + i].
                        Sons[0].Write<float>((float)All.Class.Num.GetRandom(0, 1000), 0);
                }
            }
        }
    }
}
