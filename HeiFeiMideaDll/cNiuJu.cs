using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace HeiFeiMideaDll
{
    public class cNiuJu
    {
        
        public bool YaSuoJi
        { get; set; }
        public bool FengJi
        { get; set; }
        public int ChengXuHao
        { get; set; }
        public string BackImage
        { get; set; }
        public int BackWidth
        { get; set; }
        public int BackHeight
        { get; set; }
        public string Info
        { get; set; }
        public List<System.Drawing.Rectangle> Sons
        { get; set; }
        public cNiuJu()
        {
            YaSuoJi = false;
            FengJi = false;
            ChengXuHao = 0;
            BackImage = "";
            BackWidth = 0;
            BackHeight = 0;
            Info = "";
            Sons = new List<System.Drawing.Rectangle>();
        }
        public bool Save(All.Class.DataReadAndWrite conn)
        {
            bool result = true;
            conn.Write(string.Format("delete from SetNiuJu Where YaSuoJi='{0}'and FengJi='{1}' and ChengXuHao={2}",
                YaSuoJi, FengJi, ChengXuHao));
            for (int i = 0; i < Sons.Count; i++)
            {
                result = result && (conn.Write(string.Format("insert into SetNiuJu (YaSuoJi,FengJi,ChengXuHao,Info,BackImage,BackWidth,BackHeight,SonLeft,SonTop,SonWidth,SonHeight) Values ('{0}','{1}',{2},'{3}','{4}',{5},{6},{7},{8},{9},{10})",
                    YaSuoJi, FengJi, ChengXuHao,Info, BackImage, BackWidth, BackHeight, Sons[i].Left, Sons[i].Top, Sons[i].Width, Sons[i].Height)) == 1);
            }
            return result;
        }
        public static cNiuJu Read(bool yaSuoJi, bool fengJi, int chengXuHao,All.Class.DataReadAndWrite conn)
        {
            cNiuJu result = new cNiuJu();
            using (DataTable dt = conn.Read(string.Format("select * from SetNiuJu where YaSuoJi='{0}'and FengJi='{1}' and ChengXuHao={2} order by ID", yaSuoJi, fengJi, chengXuHao)))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.YaSuoJi = yaSuoJi;
                    result.FengJi = fengJi;
                    result.ChengXuHao = chengXuHao;
                    result.BackImage = All.Class.Num.ToString(dt.Rows[0]["BackImage"]);
                    result.BackWidth = All.Class.Num.ToInt(dt.Rows[0]["BackWidth"]);
                    result.BackHeight = All.Class.Num.ToInt(dt.Rows[0]["BackHeight"]);
                    result.Info = All.Class.Num.ToString(dt.Rows[0]["Info"]);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        System.Drawing.Rectangle r = new System.Drawing.Rectangle();
                        r.X = All.Class.Num.ToInt(dt.Rows[i]["SonLeft"]);
                        r.Y = All.Class.Num.ToInt(dt.Rows[i]["SonTop"]);
                        r.Width = All.Class.Num.ToInt(dt.Rows[i]["SonWidth"]);
                        r.Height = All.Class.Num.ToInt(dt.Rows[i]["SonHeight"]);
                        result.Sons.Add(r);
                    }
                }
            }
            return result;
        }
        public static string[] AllYaSuoJi(All.Class.DataReadAndWrite conn)
        {
            List<string> result = new List<string>();
            using (DataTable dt = conn.Read("select DISTINCT ChengXuHao,Info from SetNiuJu where YaSuoJi='True'"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(string.Format("{0}#程序->{1}", dt.Rows[i]["ChengXuHao"], dt.Rows[i]["info"]));
                    }
                }
            }
            return result.ToArray();
        }
        public static string[] AllFengJi(All.Class.DataReadAndWrite conn)
        {
            List<string> result = new List<string>();
            using (DataTable dt = conn.Read("select DISTINCT ChengXuHao,Info from SetNiuJu where FengJi='True'"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(string.Format("{0}#程序->{1}", dt.Rows[i]["ChengXuHao"], dt.Rows[i]["info"]));
                    }
                }
            }
            return result.ToArray();
        }
    }
}
