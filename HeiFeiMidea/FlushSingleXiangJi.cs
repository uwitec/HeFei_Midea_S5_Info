using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HeiFeiMidea
{
    /// <summary>
    /// 刷新影像检图片
    /// </summary>
    public class FlushSingleXiangJi:All.Class.FlushAll.FlushMethor
    {
        XiangJi xiangJi = new XiangJi();
        public override void Flush()
        {
            bool[] tmpBool = All.Class.Num.Ushort2Bool(frmMain.mMain.AllMeterData.AllReadValue.UshortValue.Value[200]);
            xiangJi.SetStatue(tmpBool[1]);
        }
        public override void Load()
        {
        }
        public class XiangJi
        {
            bool oldSave = false;
            public void SetStatue(bool Save)
            {
                if (!oldSave && Save)
                {
                    try
                    {
                        string fileList = All.Class.DownLoadFile.FtpFileList("ftp://192.168.1.109//Photo//", "admin", "");
                        string[] buff = fileList.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                        if (buff.Length > 0)
                        {
                            string testFile = CheckTestResultFile.CheckTestFile(frmMain.mMain.AllCars.AllStatueLineStation[41].BarCode);
                            for (int i = 0; i < buff.Length; i++)
                            {
                                if (buff[i] == "." || buff[i] == "..")
                                {
                                    continue;
                                }
                                All.Class.DownLoadFile.FtpDownLoad(string.Format("ftp://192.168.1.109//Photo//{0}", buff[i]),
                                    "admin",
                                    "",
                                   string.Format("{0}\\{1}", testFile,buff[i]));
                            }
                        }
                    }
                    catch
                    { }
                }
                oldSave = Save;
            }
        }
    }
}
