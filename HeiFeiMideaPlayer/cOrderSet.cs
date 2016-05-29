using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMideaPlayer
{
    public class cOrderSet
    {
        /// <summary>
        /// 今日订单
        /// </summary>
        public List<HeiFeiMideaDll.OrderSet> TodayOrder
        { get; set; }
        /// <summary>
        /// 当前订单编号 
        /// </summary>
        public int nowIndex
        { get; set; }
        public cOrderSet()
        {
            TodayOrder = new List<HeiFeiMideaDll.OrderSet>();
            nowIndex = -1;
        }
        public void Load()
        {
            switch (frmMain.mMain.AllDataXml.LocalSettings.TestNo)
            {
                case 1:
                case 11:
                    TodayOrder = HeiFeiMideaDll.OrderSet.GetOrder(
                        HeiFeiMideaDll.OrderSet.GetOrder(50, frmMain.mMain.AllDataBase.FlushData), DateTime.Now);
                    break;
            }
        }
        /// <summary>
        /// 获取下一条码
        /// </summary>
        /// <returns></returns>
        public string[] GetNextBarCode(bool NextOrder,bool NextBar)
        {
            Load();
            string[] result = new string[2];
            result[0] = "";
            result[1] = "";
            if (TodayOrder == null || TodayOrder.Count == 0)
            {
                return result;
            }
            if (NextOrder)
            {
                //下一订单，则循环打所有订单中没生产完的
                for (int i = 0; i < TodayOrder.Count; i++)
                {
                    nowIndex++;
                    nowIndex = (nowIndex % TodayOrder.Count);
                    result[0] = HeiFeiMideaDll.OrderSet.GetNextBarCode(TodayOrder[nowIndex], frmMain.mMain.AllDataXml.LocalSettings.TestNo, frmMain.mMain.AllDataBase.FlushData);
                    result[1] = TodayOrder[nowIndex].OrderName;
                    if (result[0] != "")
                    {
                        break;
                    }
                }
            }
            if (NextBar)
            {
                //下一条码，则先找当前订单中没生产完成的。
                if (nowIndex < 0)
                {
                    nowIndex = 0;
                }
                result[0] = HeiFeiMideaDll.OrderSet.GetNextBarCode(TodayOrder[nowIndex], frmMain.mMain.AllDataXml.LocalSettings.TestNo,frmMain.mMain.AllDataBase.FlushData);
                result[1] = TodayOrder[nowIndex].OrderName;
                //如果当前订单都做完了
                if (result[0] == "")
                {
                    //则循环打订单中没做完的
                    for (int i = 0; i < TodayOrder.Count; i++)
                    {
                        nowIndex++;
                        nowIndex = (nowIndex % TodayOrder.Count);
                        result[0] = HeiFeiMideaDll.OrderSet.GetNextBarCode(TodayOrder[nowIndex], frmMain.mMain.AllDataXml.LocalSettings.TestNo, frmMain.mMain.AllDataBase.FlushData);
                        result[1] = TodayOrder[nowIndex].OrderName;
                        if (result[0] != "")
                        {
                            break;
                        }
                    }
                }
            }
            if (result[0] == "")
            {
                result[1] = "";
            }
            return result;
        }
    }
}
