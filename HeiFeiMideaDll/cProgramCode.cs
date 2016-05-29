using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HeiFeiMideaDll
{
    public class cProgramCode
    {
        public static string[] ServerDirectory = new string[] { "E:\\FtpServer\\" ,"D:\\服务器"};
        public static string FileDirectory = All.Class.FileIO.GetNowPath();
        static object lockObject = new object();
        /// <summary>
        /// 指定每一个传输过来的程序版本是否要更新
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetExeUpdate(Dictionary<string, string> buff,string NullValue)
        {
            lock (lockObject)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                string code = "";
                string file = "";
                string serverDirectory = "";
                if (!System.IO.Directory.Exists(ServerDirectory[1]))
                {
                    serverDirectory = ServerDirectory[0];
                }
                else
                {
                    serverDirectory = ServerDirectory[1];
                }
                for (int i = 0; i < buff.Count; i++)
                {
                    file = buff.Keys.ToList()[i];
                    code = All.Class.FileIO.GetFileCode(string.Format("{0}\\{1}", serverDirectory, file),NullValue);
                    result.Add(file, string.Format("{0}", (code != "" && code != buff[file])));
                }
                return result;
            }
        }
        /// <summary>
        /// 指定文件的版本号
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetExeCode(string[] file,string NullValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (file != null)
            {
                for (int i = 0; i < file.Length; i++)
                {
                    result.Add(file[i], All.Class.FileIO.GetFileCode(string.Format("{0}\\{1}", FileDirectory, file[i]), NullValue));
                }
            }
            return result;
        }
    }
}
