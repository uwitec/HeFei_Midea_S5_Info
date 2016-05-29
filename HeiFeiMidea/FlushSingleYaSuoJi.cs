using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新压缩机检测结果
    /// </summary>
    public class FlushSingleYaSuoJi:All.Class.FlushAll.FlushMethor
    {
        public override void Flush()
        {
        }
        public override void Load()
        {
        }
        /// <summary>
        /// 检查压缩机条码是否匹配
        /// </summary>
        /// <param name="index"></param>
        /// <param name="yaSuoJiCode"></param>
        /// <returns></returns>
        public void Save(int index, string yaSuoJiCode,bool result,string barCode)
        {
            FengJiYaSuoJiDianKong tmp = new FengJiYaSuoJiDianKong();
            tmp.Index = index;
            tmp.Result = result;
            tmp.TestBar = yaSuoJiCode;
            tmp.TestName = "压缩机";
            tmp.BarCode = barCode;
            tmp.Save();
        }
        public class FengJiYaSuoJiDianKong
        {
            public string BarCode
            { get; set; }
            public int Index
            { get; set; }
            public string TestBar
            { get; set; }
            public bool Result
            { get; set; }
            public string TestName
            { get; set; }
            public FengJiYaSuoJiDianKong()
            {
                this.BarCode = "";
                this.Index = 0;
                this.TestBar = "";
                this.Result = true;
                this.TestName = "";
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
                sql.Write(string.Format("insert into TestYaSuoJi values({0},'{1}','{2}','{3}')",
                    this.Index, this.TestBar, this.Result,this.TestName));
                sql.Close();
            }
        }
    }
}
