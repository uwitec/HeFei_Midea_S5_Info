using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
    public class cBoShi
    {
        public class BoShiValue
        {
            public string ID
            { get; set; }
            public string Mode
            { get; set; }
            public BoShiValue(string iD, string mode)
            {
                this.ID = iD;
                this.Mode = mode;
            }
        }
        /// <summary>
        /// 获取所有美的与博世机型对应
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static Dictionary<string, BoShiValue> GetAllMode(All.Class.DataReadAndWrite conn)
        {
            Dictionary<string, BoShiValue> result = new Dictionary<string, BoShiValue>();
            string midea = "";
            BoShiValue boshi = new BoShiValue("", "");
            using (DataTable dt = conn.Read("select * from SetMideaToBoShi Order by BoShi"))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    midea = All.Class.Num.ToString(dt.Rows[i]["Midea"]);
                    boshi = new BoShiValue(All.Class.Num.ToString(dt.Rows[i]["BoSHi"]),
                                            All.Class.Num.ToString(dt.Rows[i]["BoShiJiXing"]));
                    if (!result.ContainsKey(midea))
                    {
                        result.Add(midea, boshi);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 保存所有对应关系
        /// </summary>
        /// <param name="allMode"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static bool SaveAllMode(Dictionary<string, BoShiValue> allMode, All.Class.DataReadAndWrite conn)
        {
            bool result = true;
            allMode.Keys.ToList().ForEach(
                mode =>
                {
                    conn.Write(string.Format("delete from SetMideaToBoshi where Midea='{0}'", mode));
                    result = (result && (conn.Write(string.Format("insert into SetMideaToBoShi values('{0}','{1}','{2}')", mode, allMode[mode].ID,allMode[mode].Mode)) == 1));
                });
            return result;
        }
    }
}
