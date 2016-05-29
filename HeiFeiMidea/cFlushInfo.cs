using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    /// <summary>
    /// 专用于处理PlayLine界面的List文件中的数据增减
    /// </summary>
    public  class cFlushInfo
    {
        public delegate void AddInfoHandle(string value);
        public event AddInfoHandle AddInfo;
        public delegate void DelInfoHandle(string value);
        public event DelInfoHandle DelInfo;
        /// <summary>
        /// 所有信息列表
        /// </summary>
        public List<Info> AllInfo
        { get; set; }
        public cFlushInfo()
        {
            this.AllInfo = new List<Info>();
        }
        /// <summary>
        /// 添加或删除提示信息
        /// </summary>
        /// <param name="info"></param>
        public void Change(Info info)
        {
            int index = AllInfo.FindIndex(
                tmpInfo =>
                {
                    return tmpInfo.Value == info.Value;
                });
            if (index < 0 && info.Change == FlushAllError.ChangeList.Add)
            {
                AllInfo.Add(info);
                if (AddInfo != null)
                {
                    AddInfo(info.GetShowValue());
                }
                return;
            }
            if (index >= 0 && info.Change == FlushAllError.ChangeList.Del)
            {
                if (DelInfo != null)
                {
                    DelInfo(AllInfo[index].GetShowValue());
                }
                AllInfo.RemoveAt(index);
                return;
            }
        }
        /// <summary>
        /// 提示信息类
        /// </summary>
        public class Info
        {
            public string Value
            { get; set; }
            public FlushAllError.ChangeList Change
            { get; set; }
            public DateTime Time
            { get; set; }
            public Info()
                : this("", FlushAllError.ChangeList.Del)
            {

            }
            public Info(string value, FlushAllError.ChangeList change)
            {
                this.Value = value;
                this.Change = change;
                this.Time = DateTime.Now;
            }
            public string GetShowValue()
            {
                return string.Format("{0:HH:mm:ss} {1}", Time, Value);
            }
        }
    }
}
