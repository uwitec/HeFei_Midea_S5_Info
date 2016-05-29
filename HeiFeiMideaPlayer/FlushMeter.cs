using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class FlushMeter:All.Class.FlushAll.FlushMethor
    {
        public FlushMeter()
        {
        }
        public override void Load()
        {
            frmMain.mMain.AllMeterData.AllReadValue.UshortValue.ChangeValue += UshortValue_ChangeValue;
            frmMain.mMain.AllMeterData.AllReadValue.ByteValue.ChangeValue += ByteValue_ChangeValue;
        }

        void ByteValue_ChangeValue(byte Value, byte OldValue, string Info, int index)
        {
            switch (index)
            {
                case 52://复位压缩机比对结果
                    if (Value == 0)
                    {
                        return;
                    }
                    frmMain.mMain.WriteRootID.AllWrite[(int)cWriteRootID.AllSpace.条码比对信号1].Add((ushort)(All.Class.Num.GetRandom(3, 10000)));
                    //frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<ushort>((ushort)(All.Class.Num.GetRandom(3,10000)), 0);
                    break;
                case 53://写入压缩机比对结果
                    if (Value == 0)
                    {
                        return;
                    }
                    if (frmMain.mMain.CarLocal.ModeSet[1] == null || frmMain.mMain.CarLocal.ModeSet[1].ID == "")
                    {
                        frmMain.mMain.AddInfo(string.Format("当前机型为空，无法判断当前给定的压缩机判断信号"));
                        return;
                    }
                    if (frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[51] <= 0 || frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[51] > 4)
                    {
                        frmMain.mMain.AddInfo(string.Format("当前给定压缩机安装序号[{0}]不正确", frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[51]));
                        return;
                    }
                    string yaSuoJiBar = All.Class.Num.GetVisableStr(Encoding.ASCII.GetString(frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value.ToArray(), 0, 50));
                    
                    frmMain.mMain.AddInfo(yaSuoJiBar);
                    if (yaSuoJiBar.Length < 10)
                    {
                        frmMain.mMain.AddInfo(string.Format("当前条码过短,无法比对"));
                        return;
                    }
                    //frmMain.mMain.AddInfo(yaSuoJiBar);
                    Dictionary<string, string> buff;
                    if (yaSuoJiBar.IndexOf(frmMain.mMain.CarLocal.ModeSet[1].YaSuoJiID[frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[51] - 1]) >= 0)
                    {
                        //上传压缩机比对OK信号                   
                        frmMain.mMain.WriteRootID.AllWrite[(int)cWriteRootID.AllSpace.条码比对信号1].Add(1);

                        buff = new Dictionary<string, string>();
                        buff.Add("YaSuoJiBarCode", yaSuoJiBar);
                        buff.Add("BarCode", frmMain.mMain.CarLocal.AllStatueStation[1].BarCode);
                        buff.Add("Index", frmMain.mMain.AllMeterData.AllReadValue.ByteValue.Value[51].ToString());
                        buff.Add("Result", "true");
                        frmMain.mMain.WriteRootID.AllWrite[(int)cWriteRootID.AllSpace.条码比对信号2].Add(All.Class.SSFile.Dictionary2Text(buff));
                        //frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<string>(All.Class.SSFile.Dictionary2Text(buff), 0);
                        frmMain.mMain.AddInfo("压缩机条码判断通过");
                    }
                    else
                    {
                        //上传压缩机比对NG信号
                        frmMain.mMain.WriteRootID.AllWrite[(int)cWriteRootID.AllSpace.条码比对信号1].Add(2);
                        //frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<ushort>(2, 0);
                        frmMain.mMain.AddInfo("压缩机条码判断失败");
                    }
                    break;

            }
        }

        void UshortValue_ChangeValue(ushort Value, ushort OldValue, string Info, int index)
        {
        }
        private void BoolValue_ChangeValue(bool Value, bool OldValue, string Info, int index)
        {
            //switch (index)
            //{
            //    case 0:
            //        frmMain.mMain.AddInfo("主机发送关机命令，电脑即将自动关闭");
            //        break;
            //}
        }
        public override void Flush()
        {
            frmMain.mMain.AllMeterData.AllCommunite[3].Sons[0].Write<float>((float)All.Class.Num.GetRandom(0, 1000),0);// frmMain.mMain.AllDataXml.LocalSettings.TestNo - 1);
        }
    }
}
