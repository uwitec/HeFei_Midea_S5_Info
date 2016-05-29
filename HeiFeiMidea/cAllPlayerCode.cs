using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiFeiMidea
{
    /// <summary>
    /// 所有下位机文件的版本号
    /// </summary>
    public class cAllPlayerCode
    {
        public class Player
        {
            public int Index
            { get; set; }
            public List<string> FileName
            { get; set; }
            public List<string> Code
            { get; set; }
            public Player()
            {
                FileName = new List<string>();
                Code = new List<string>();
            }
        }
        public List<Player> AllPlay
        { get; set; }
        public cAllPlayerCode()
        {
            AllPlay = new List<Player>();
        }
        public void Save()
        {
            //lock (LockAllPlayFile.LockOjbect)
            //{
            //    All.Class.XmlHelp.SaveXml(string.Format("{0}\\Data\\Code.txt", System.Windows.Forms.Application.StartupPath), typeof(cAllPlayerCode), this);
            //}
        }
        public void SetCode(int index, Dictionary<string, string> buff)
        {
            //foreach (Player p in AllPlay)
            //{
            //    if (p.Index == index)
            //    {
            //        AllPlay.Remove(p);
            //        break;
            //    }
            //}
            //Player player = new Player();
            //player.Index = index;
            //List<string> allKeys = buff.Keys.ToList();
            //for (int i = 0; i < allKeys.Count; i++)
            //{
            //    player.Code.Add(buff[allKeys[i]]);
            //    player.FileName.Add(allKeys[i]);
            //}
            //AllPlay.Add(player);
            //Save();
        }
    }
    public class LockAllPlayFile
    {
        public static cAllPlayerCode AllPlayCode = new cAllPlayerCode();
        public static object LockOjbect = new object();
    }
}
