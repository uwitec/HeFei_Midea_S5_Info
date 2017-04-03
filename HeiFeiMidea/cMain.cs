using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    public class cMain
    {
        public static DateTime StartTime = DateTime.Now;
        /// <summary>
        /// 自动刷新
        /// </summary>
        public All.Class.FlushAll FlushAll = new All.Class.FlushAll();
        /// <summary>
        /// 硬件数据读取
        /// </summary>
        public All.Communite.DataReadAndWrite AllMeterData = new All.Communite.DataReadAndWrite();
        /// <summary>
        /// 硬件刷新
        /// </summary>
        public FlushMeter FlushMeter;
        /// <summary>
        /// 刷新所有数据库读出
        /// </summary>
        public FlushDataRead FlushDataRead;
        /// <summary>
        /// 刷新所有数据库写入
        /// </summary>
        public FlushDataWrite FlushDataWrite;
        /// <summary>
        /// 刷新各显示屏工位
        /// </summary>
        public FlushStatueStation FlushStatueStation;
        /// <summary>
        /// 刷新数据库
        /// </summary>
        public FlushData FlushData;
        /// <summary>
        /// 刷新用户登陆
        /// </summary>
        public cFlushUserLogin FlushUserLogin;
        /// <summary>
        /// 刷新压缩机
        /// </summary>
        public FlushSingleYaSuoJi FlushSingleYaSuoJi;
        /// <summary>
        /// 读性能检数据库
        /// </summary>
        public FlushSingleTest FlushSingleTest;
        /// <summary>
        /// 读性能检实时数据库
        /// </summary>
        public FlushSingleTestTmp FlushSingleTestTmp;
        /// <summary>
        /// 读注油数据库
        /// </summary>
        public FlushSingleOil FlushSingleOil;
        /// <summary>
        /// 读取安装记录
        /// </summary>
        public FlushSingleAnZhuang FlushSingleAnZhuang;
        /// <summary>
        /// 读取故障记录
        /// </summary>
        public FlushSingleError FlushSingleError;
        /// <summary>
        /// 读取物料呼叫记录
        /// </summary>
        public FlushSingleMaterial FlushSingleMaterial;
        /// <summary>
        /// 刷新检漏数据
        /// </summary>
        public FlushSingleJianLou FlushSingleJianLou;
        /// <summary>
        /// 刷新充氦回收数据
        /// </summary>
        public FlushSingleChongHaiHuiShou FlushSingleChongHaiHuiShou;
        /// <summary>
        /// 刷新抽空充注数据
        /// </summary>
        public FlushSingleChouKongChongZhu FlushSingleChouKongChongZhu;
        /// <summary>
        /// 刷新扭矩
        /// </summary>
        public FlushSingleNiuJu FlushSingleNiuJu;
        /// <summary>
        /// 刷新OEE数据
        /// </summary>
        public FlushOEE FlushOEE;
        /// <summary>
        /// 刷新相机图片
        /// </summary>
        public FlushSingleXiangJi FlushSingleXiangJi;
        /// <summary>
        /// 刷新折弯数据
        /// </summary>
        public FlushSingleZheWang FlushSingleZheWang;
        /// <summary>
        /// 刷新11号工位屏的工装板颜色
        /// </summary>
        public FlushLengNinQiStatueToStation FlushLengNinQiStatueToStation;
        /// <summary>
        /// 刷新设备维护
        /// </summary>
        public FlushSheBei FlushSheBei;
        /// <summary>
        /// 刷新超时时间
        /// </summary>
        public FlushTimeOut FlushTimeOut;
        /// <summary>
        /// 刷新今日工位作业时间
        /// </summary>
        public FlushStationTestTime FlushStationTestTime;
        /// <summary>
        /// 刷新 PLC
        /// </summary>
        public FlushPlc FlushPlc;
        /// <summary>
        /// 写PLC数据专用类
        /// </summary>
        public cWriteRootID WriteRootID
        { get; set; }
        /// <summary>
        /// 所有数据库连接
        /// </summary>
        public cData AllDataBase = new cData();
        /// <summary>
        /// 所有文本数据
        /// </summary>
        public cDataXml AllDataXml = new cDataXml();
        /// <summary>
        /// 所有小车数据
        /// </summary>
        public cCarLocal AllCars = new cCarLocal();
        /// <summary>
        /// 所有PC数据
        /// </summary>
        public cPCLocal AllPCs = new cPCLocal();
        /// <summary>
        /// 所有故障。
        /// </summary>
        public FlushAllError FlushAllError = new FlushAllError();
        /// <summary>
        /// 所有订单数据
        /// </summary>
        public List<HeiFeiMideaDll.OrderSet> AllOrder = new List<HeiFeiMideaDll.OrderSet>();
        /// <summary>
        /// 所有PlayLine界面显示数据刷新
        /// </summary>
        public cFlushInfo FlushInfo = new cFlushInfo();
        public void Load()
        {
            //加载本地文件数据库
            AllDataXml.Load();
            //加载数据库
            AllDataBase.Load();
            //加载订单数据
            AllOrder =HeiFeiMideaDll.OrderSet.GetOrder(1000,AllDataBase.LocalData);
            //加载工位与停车位的数据
            AllCars.Load();
            //加载设备类
            AllMeterData.SaveToAccess = false;
            AllMeterData.Load();
            //下面的不要搞，问题一堆
            if (All.Class.HardInfo.MyTestComputer())
            {
                for (int i = 0; i < AllMeterData.AllCommunite.Count; i++)
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
            //AllMeterData.AllReadValue.StringValue.RaiseChangeEveryTime[30] = true;//上线条码可重复触发
            //AllMeterData.AllReadValue.StringValue.RaiseChangeEveryTime[42] = true;//上线条码可重复触发
            //AllMeterData.AllReadValue.StringValue.RaiseChangeEveryTime[51] = true;//上线条码可重复触发

            //AllMeterData.AllReadValue.UshortValue.RaiseChangeEveryTime[196] = true;//2号工位上传压缩机比对结果

            AllMeterData.SaveToFile = false;
            //for (int i = 0; i < HeiFeiMideaDll.cMain.AllCarCount; i++)
            //{
            //    AllMeterData.AllReadValue.UshortValue.RaiseChangeEveryTime[i * 5 + 1] = true;
            //}

            //加载刷新类
            FlushMeter = new FlushMeter();
            FlushAll.Add(FlushMeter);

            FlushOEE = new HeiFeiMidea.FlushOEE();
            FlushAll.Add(FlushOEE);

            FlushDataRead = new FlushDataRead();
            FlushDataRead.FlushTick = 200;
            FlushAll.Add(FlushDataRead);

            FlushDataWrite = new FlushDataWrite();
            FlushDataWrite.FlushTick = 500;
            FlushAll.Add(FlushDataWrite);

            FlushData = new HeiFeiMidea.FlushData();
            FlushAll.Add(FlushData);

            FlushPlc = new HeiFeiMidea.FlushPlc();
            FlushPlc.FlushTick = 500;
            FlushAll.Add(FlushPlc);

            FlushSingleAnZhuang = new HeiFeiMidea.FlushSingleAnZhuang();
            FlushSingleAnZhuang.FlushTick = 300;
            FlushAll.Add(FlushSingleAnZhuang);

            FlushSingleOil = new HeiFeiMidea.FlushSingleOil();
            FlushAll.Add(FlushSingleOil);

            FlushSingleError = new HeiFeiMidea.FlushSingleError();
            FlushAll.Add(FlushSingleError);

            FlushSingleJianLou = new HeiFeiMidea.FlushSingleJianLou();
            FlushAll.Add(FlushSingleJianLou);

            FlushSingleXiangJi = new HeiFeiMidea.FlushSingleXiangJi();
            FlushAll.Add(FlushSingleXiangJi);

            FlushTimeOut = new HeiFeiMidea.FlushTimeOut();
            FlushAll.Add(FlushTimeOut);

            FlushSingleChongHaiHuiShou = new HeiFeiMidea.FlushSingleChongHaiHuiShou();
            FlushAll.Add(FlushSingleChongHaiHuiShou);

            FlushSingleChouKongChongZhu = new HeiFeiMidea.FlushSingleChouKongChongZhu();
            FlushAll.Add(FlushSingleChouKongChongZhu);

            FlushSingleNiuJu = new HeiFeiMidea.FlushSingleNiuJu();
            FlushSingleNiuJu.FlushTick = 100;
            FlushAll.Add(FlushSingleNiuJu);

            FlushLengNinQiStatueToStation = new HeiFeiMidea.FlushLengNinQiStatueToStation();
            FlushAll.Add(FlushLengNinQiStatueToStation);

            FlushStatueStation = new HeiFeiMidea.FlushStatueStation();
            FlushStatueStation.FlushTick = 100;
            FlushAll.Add(FlushStatueStation);

            FlushSheBei = new HeiFeiMidea.FlushSheBei();
            FlushAll.Add(FlushSheBei);

            FlushSingleZheWang = new HeiFeiMidea.FlushSingleZheWang();
            FlushSingleZheWang.FlushTick = 500;
            FlushAll.Add(FlushSingleZheWang);

            FlushSingleTest = new HeiFeiMidea.FlushSingleTest();
            FlushSingleTest.FlushTick = 500;
            FlushAll.Add(FlushSingleTest);

            FlushSingleMaterial = new HeiFeiMidea.FlushSingleMaterial();
            FlushSingleMaterial.FlushTick = 1000;
            FlushAll.Add(FlushSingleMaterial);

            FlushUserLogin = new cFlushUserLogin();
            FlushAll.Add(FlushUserLogin);

            FlushSingleTestTmp = new FlushSingleTestTmp();
            FlushSingleTestTmp.FlushTick = 1000;
            FlushAll.Add(FlushSingleTestTmp);

            FlushSingleYaSuoJi = new FlushSingleYaSuoJi();
            FlushSingleYaSuoJi.FlushTick = 100;
            FlushAll.Add(FlushSingleYaSuoJi);

            FlushStationTestTime = new HeiFeiMidea.FlushStationTestTime();
            FlushStationTestTime.FlushTick = 1000;
            FlushAll.Add(FlushStationTestTime);

            FlushAll.Add(FlushAllError);

            WriteRootID = new cWriteRootID();
        }
        public void Run()
        {
            //刷新类开跑
            FlushAll.Run();
            //设备类开跑
            AllMeterData.Run();
        }
    }
}
