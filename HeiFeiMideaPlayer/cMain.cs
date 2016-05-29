using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class cMain
    {
        /// <summary>
        /// 所有检查版本的文件
        /// </summary>
        public static string[] AllFile =
            new string[] { 
                "HeiFeiMideaPlayer.Exe", 
                "All.Dll", 
                "zxing.dll", 
                "DataMatrix.net.dll", 
                "Interop.Illustrator.dll", 
                "MediaPlayerControl.cs.dll", 
                "HeiFeiMideaDll.Dll", 
                "Data\\MeterConnect.mdb",
                "Data\\DataConnect.mdb", 
                "Data\\PrintBarCode.sdf", 
                "Data\\LenNingQi.sdf",
                "DirectShow.dll", 
                "RspMediaPlayer.dll", 
                "rsp_new_media_player.dll" ,
                "System.Data.SqlServerCe.dll",
                "sqlceer40CN.dll",
                "sqlceme40.dll",
                "sqlceca40.dll",
                "sqlcecompact40.dll",
                "sqlceoledb40.dll",
                "sqlceqp40.dll",
                "sqlcese40.dll"
            };
        /// <summary>
        /// 只下载一次的文件
        /// </summary>
        public static string[] DownOnlyOneTime =
            new string[] {
            "Data\\PrintBarCode.sdf",
            "Data\\LenNingQi.sdf"};
        public const string MediaFile = "E:\\";
        public static string RemotFtp
        {
            get
            {
                if (All.Class.HardInfo.MyTestComputer())
                {
                    return "Ftp://127.0.0.1";
                }
                return "Ftp://192.168.1.100";
            }
        }
        /// <summary>
        /// 自动刷新
        /// </summary>
        public All.Class.FlushAll FlushAll = new All.Class.FlushAll();
        public All.Class.FlushAll FlushTmp = new All.Class.FlushAll();
        /// <summary>
        /// 硬件数据读取
        /// </summary>
        public All.Communite.DataReadAndWrite AllMeterData = new All.Communite.DataReadAndWrite();
        /// <summary>
        /// 硬件刷新
        /// </summary>
        public FlushMeter FlushMeter;
        /// <summary>
        /// 刷新折弯
        /// </summary>
        public FlushZheWang FlushZheWang;
        /// <summary>
        /// 刷新扭矩
        /// </summary>
        public FlushNiuJu FlushNiuJu;
        /// <summary>
        /// 必须写成功的数据写入方法
        /// </summary>
        public cWriteRootID WriteRootID;
        
        /// <summary>
        /// 刷新数据
        /// </summary>
        public FlushData FlushData
        { get; set; }
        /// <summary>
        /// 所有数据类
        /// </summary>
        public cData AllDataBase = new cData();
        /// <summary>
        /// 本地文件类
        /// </summary>
        public cDataXml AllDataXml = new cDataXml();
        /// <summary>
        /// 工位设置
        /// </summary>
        public HeiFeiMideaDll.cDataLocal.InfoStation StationSet;
        /// <summary>
        /// 所有的停车工位设置，用于显示故障源中的故障源
        /// </summary>
        public List<HeiFeiMideaDll.cDataLocal.InfoLineStation> AllStationSet;
        /// <summary>
        /// 本地订单数据
        /// </summary>
        public cOrderSet OrderSet = new cOrderSet();
        /// <summary>
        /// 本地机器数据
        /// </summary>
        public cCarLocal CarLocal;
        /// <summary>
        /// 美的转博世条码
        /// </summary>
        public MideaToBoShi MideaToBoShi = new MideaToBoShi();
        /// <summary>
        /// 替换规则
        /// </summary>
        public cAiReplace AiReplace = new cAiReplace();
        /// <summary>
        /// AI写入文件
        /// </summary>
        public cAiWrite AiWrite = new cAiWrite();
        /// <summary>
        /// 所有用户
        /// </summary>
        public FlushAllUser FlushAllUser;

        public delegate void AddInfoHandle(string value);
        /// <summary>
        /// 显示信息
        /// </summary>
        public event AddInfoHandle AddInfoValue;

        /// <summary>
        /// 本地行加载设置
        /// </summary>
        public void LoadLocal()
        {
            //加载本地文件
            AllDataXml.Load();
            AiReplace.Load();
            AiWrite.Load();
            //加载设备类
            AllMeterData.RemoveTextError = true;
            AllMeterData.SaveToAccess = false;
            AllMeterData.SaveToFile = false;
            AllMeterData.Load();
            AllMeterData.AllReadValue.StringValue.RaiseChangeEveryTime[0] = true;//读取到条码
            AllMeterData.AllReadValue.StringValue.RaiseChangeEveryTime[1] = true;//读取到条码

            //只有上压缩机工位，才连接机器人1号PLC
            if (AllMeterData.AllCommuniteFile.Count > 4)
            {
                if (AllMeterData.AllCommuniteFile[4].Attribute.ContainsKey("Use"))
                {
                    AllMeterData.AllCommuniteFile[4].Attribute["Use"] = string.Format("{0}", (AllDataXml.LocalSettings.TestNo == 2));
                }
                else
                {
                    AllMeterData.AllCommuniteFile[4].Attribute.Add("Use", string.Format("{0}", (AllDataXml.LocalSettings.TestNo == 2)));
                }
            }
            //只有折弯工位，才连接折弯机PLC
            if (AllMeterData.AllCommuniteFile.Count > 5)
            {
                if (AllMeterData.AllCommuniteFile[5].Attribute.ContainsKey("Use"))
                {
                    AllMeterData.AllCommuniteFile[5].Attribute["Use"] = string.Format("{0}", (AllDataXml.LocalSettings.TestNo == 11));
                }
                else
                {
                    AllMeterData.AllCommuniteFile[5].Attribute.Add("Use", string.Format("{0}", (AllDataXml.LocalSettings.TestNo == 11)));
                }
            }

            if (AllMeterData.AllCommunite[2].Text == "上位机通讯端口")
            {
                AllMeterData.AllCommuniteFile[2].AllMeter[0].Attribute["RemotPort"] = string.Format("{0}", AllDataXml.LocalSettings.TestNo + 6300);//只读
            }
            else
            {
                All.Class.Error.Add("上下位机通讯口位置变化了，修改相应的位置");
            }

            if (AllMeterData.AllCommunite[3].Text == "上位机通讯端口")
            {
                AllMeterData.AllCommuniteFile[3].AllMeter[0].Attribute["RemotPort"] = string.Format("{0}", AllDataXml.LocalSettings.TestNo + 6100);//只写
            }
            else
            {
                All.Class.Error.Add("上下位机通讯口位置变化了，修改相应的位置");
            }
            //下面的不要搞，问题一堆
            if (All.Class.HardInfo.MyTestComputer())
            {
                for (int i = 1; i < AllMeterData.AllCommunite.Count; i++)
                {
                    if (AllMeterData.AllCommuniteFile[i].Attribute.ContainsKey("Use"))
                    {
                        AllMeterData.AllCommuniteFile[i].Attribute["Use"] = "false";
                    }
                    else
                    {
                        AllMeterData.AllCommuniteFile[i].Attribute.Add("Use", "false");
                    }
                }
            }

            WriteRootID = new cWriteRootID();//这个里面有用到FlushMeter,所以要在FlushMeter后面才能初始化
            FlushTmp.Add(WriteRootID);
        }
        /// <summary>
        /// 刷新本地
        /// </summary>
        public void FlushLocal()
        {
            FlushTmp.Run();
            //设备类开跑
            AllMeterData.Run();
        }
        /// <summary>
        /// 加载远程设置
        /// </summary>
        public void LoadRemot()
        {
            //加载数据库
            AllDataBase.Load();
            //加载工位设置
            AllStationSet = AllDataBase.Local.GetTestInfoLineStation();
            StationSet = AllDataBase.Local.GetStation(AllDataXml.LocalSettings.TestNo);
            //初始化机器
            CarLocal = new cCarLocal();
            FlushNiuJu = new HeiFeiMideaPlayer.FlushNiuJu();
            //加载刷新类
            FlushMeter = new HeiFeiMideaPlayer.FlushMeter();
            FlushAll.Add(FlushMeter);
            //刷新登陆用户
            FlushAllUser = new HeiFeiMideaPlayer.FlushAllUser();
            FlushAll.Add(FlushAllUser);

            //初始化折弯机
            if (frmMain.mMain.AllDataXml.LocalSettings.TestNo == 11)
            {
                FlushZheWang = new FlushZheWang();
                FlushAll.Add(FlushZheWang);
            }

            FlushData = new FlushData();
            FlushAll.Add(FlushData);

           
        }
        /// <summary>
        /// 运行远程
        /// </summary>
        public void RunRemot()
        {
            //刷新类开跑
            FlushAll.Run();
        }
      
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="value"></param>
        public void AddInfo(string value)
        {
            if (AddInfoValue != null)
            {
                AddInfoValue(value);
            }
        }
    }
}
