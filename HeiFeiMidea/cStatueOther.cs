using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    /// <summary>
    /// 所有其他设备的设备状态
    /// </summary>
    public class cStatueOther
    {
        /// <summary>
        /// 所有其他设备
        /// </summary>
        public enum AllOther:int
        {
            机器人1 = 0,
            机器人2,
            机器人3,
            穿梭车,
            性能检工位1,
            性能检工位2,
            性能检工位3,
            性能检工位4,
            绕膜机,
            打包机,
            下线工位1,
            下线工位2,
            下线工位3,
            下线工位4
        }
        /// <summary>
        /// 站点
        /// </summary>
        public int WorkStation
        { get; set; }
        /// <summary>
        /// 是否有故障。
        /// </summary>
        public bool Error
        { get; set; }
        /// <summary>
        /// 是否停止运行中
        /// </summary>
        public bool Empty
        { get; set; }
        /// <summary>
        /// 小工件
        /// </summary>
        public bool TestSmall
        { get; set; }
        /// <summary>
        /// 大工件
        /// </summary>
        public bool TestMax
        { get; set; }
        /// <summary>
        /// 是否工作中
        /// </summary>
        public bool Run
        { get; set; }
        /// <summary>
        /// 新加详细故障
        /// </summary>
        public ushort E0
        { get; set; }
        /// <summary>
        /// 新回详细故障
        /// </summary>
        public ushort E1
        { get; set; }
        /// <summary>
        /// 图标是否须要闪烁
        /// </summary>
        public bool Blink
        {
            get
            {
                return Error;
            }
        }
        /// <summary>
        /// 1# 安装压缩机机器人故障码,bit0->bit7
        /// </summary>
        public string[] MachineOneError = new string[] { "相机超时", "未拍到", "未拍到", "光电进入", "条码对比失败", "缺料", "进料不到位" };
        /// <summary>
        /// 2# 加油机器人故障码,bit0->bit15,bit0
        /// </summary>
        public string[] MachineTwoError = new string[]{"油嘴上升超时","油嘴下降超时","拔堵上升超时","拔堵下降超时","架子上升超时","架子下降超时","大夹头夹紧超时","大夹头松下超时",
                                                    "夹堵头上升超时","夹堵头下降超时","小夹头夹紧超时","小夹头松开超时","拍照失败","拔塞失败","相机超时","拍照失败","加油失败","光电进入"};
        public System.Drawing.Color Color
        {
            get
            {
                System.Drawing.Color result = System.Drawing.Color.Purple;
                if (Error)
                {
                    return result;
                }
                if (Empty)
                {
                    switch (WorkStation)
                    {
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            result= System.Drawing.Color.Blue;
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 9:
                        case 10:
                            result= System.Drawing.Color.Green;
                            break;
                    }
                }
                if (TestSmall || TestMax)
                {
                    switch (WorkStation)
                    {
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                            result = System.Drawing.Color.Green;
                            break;
                        case 9:
                        case 10:
                            result = System.Drawing.Color.Yellow;
                            break;
                    }
                }
                if (Run)
                {
                    switch (WorkStation)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 9:
                        case 10:
                            result = System.Drawing.Color.Yellow;
                            break;
                    }
                }
                return result;
            }
        }
        public cStatueOther(int workStation)
        {
            this.WorkStation = workStation;
            this.Empty = true;
            this.Error = false;
            this.TestMax = false;
            this.TestSmall = false;
            this.Run = false;
            this.E0 = 0;
            this.E1 = 0;
        }
        /// <summary>
        /// 将数据解析得到当前设备状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static cStatueOther GetStatueFromPlc(int index, ushort value)
        {
            //    //0,1,2->1,2,3#机器人
            //    //4->穿梭车
            //    //5,6,7,8->性能检工位
            //    //9->绕膜机
            //    //10->打包机
            //    //11,12,13,14->下线工位
            cStatueOther result = new cStatueOther(index);
            bool[] tmpValue = All.Class.Num.Ushort2Bool(value);
            result.Error = tmpValue[8];
            result.Empty = !(tmpValue[10] || tmpValue[11] || tmpValue[12]);
            result.TestSmall = tmpValue[10];
            result.TestMax = tmpValue[11];
            result.Run = tmpValue[12];

            return result;
        }
        /// <summary>
        /// 检查机器人故障,这里只有机器人1和2的，机器人3的因为只有一个故障在cDataRead里面
        /// </summary>
        /// <param name="e0"></param>
        /// <param name="e1"></param>
        public void CheckRoobetError(AllOther space,ushort e0, ushort e1)
        {
            bool[] oldBool;
            bool[] newBool;
            switch(space)
            {
                case AllOther.机器人1:
                    oldBool = All.Class.Num.Ushort2Bool(All.Class.Num.SwitchHighAndLow(this.E0));
                    newBool = All.Class.Num.Ushort2Bool(All.Class.Num.SwitchHighAndLow(e0));
                    for (int i = 0; i < this.MachineOneError.Length; i++)
                    {
                        if (oldBool[i] != newBool[i])
                        {
                            if (newBool[i])
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("1#机器人{0}", this.MachineOneError[i]), FlushAllError.ChangeList.Add));
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.机器人, 1, this.MachineOneError[i], FlushAllError.ChangeList.Add, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.机器人, 1));
                            }
                            if (oldBool[i])
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("1#机器人{0}", this.MachineOneError[i]), FlushAllError.ChangeList.Del));
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.机器人, 1, this.MachineOneError[i], FlushAllError.ChangeList.Del, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.机器人, 1));
                            }
                        }
                    }
                    this.E0 = e0;
                    break;
                case AllOther.机器人2:
                    ushort[] allError = new ushort[2];
                    allError[0] = All.Class.Num.SwitchHighAndLow(this.E0);
                    allError[1] = All.Class.Num.SwitchHighAndLow(this.E1);
                    oldBool = All.Class.Num.Ushort2Bool(allError);
                    allError[0] = All.Class.Num.SwitchHighAndLow(e0);
                    allError[1] = All.Class.Num.SwitchHighAndLow(e1);
                    newBool = All.Class.Num.Ushort2Bool(allError);
                    for (int i = 0; i < this.MachineTwoError.Length; i++)
                    {
                        if (oldBool[i] != newBool[i])
                        {
                            if (newBool[i])
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("2#机器人{0}", this.MachineTwoError[i]), FlushAllError.ChangeList.Add));
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.机器人, 2, this.MachineTwoError[i], FlushAllError.ChangeList.Add, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.机器人, 2));
                            }
                            if (oldBool[i])
                            {
                                frmMain.mMain.FlushInfo.Change(new cFlushInfo.Info(string.Format("2#机器人{0}", this.MachineTwoError[i]), FlushAllError.ChangeList.Del));
                                frmMain.mMain.FlushAllError.Change(FlushAllError.SpaceList.机器人, 2, this.MachineTwoError[i], FlushAllError.ChangeList.Del, cSheBei.GetMachineIndexForAllError(FlushAllError.SpaceList.机器人, 2));
                            }
                        }
                    }
                    this.E0 = e0;
                    this.E1 = e1;
                    break;
            }
        }
    }
}