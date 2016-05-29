using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HeiFeiMideaDll
{
    public class cMain
    {
        /// <summary>
        /// 当前值12，电脑工位总量
        /// </summary>
        public const int AllComputerCount = 12;
        /// <summary>
        /// 当前值30，小车工位总量
        /// </summary>
        public const int AllCarCount = 30;
        /// <summary>
        /// 当前值8，所有播放界面
        /// </summary>
        public const int AllPlays = 8;
        /// <summary>
        /// 当前值53，所有停车工位
        /// </summary>
        public const int AllStopStationCount = 53;
        /// <summary>
        /// 当前值33，所有小屏应该显示的工位数量，暂时按个小屏对应三个工位来算
        /// </summary>
        public const int AllComputerShowCount = 33;
        /// <summary>
        /// 当前值11，所有测试电脑数量，当前值为11
        /// </summary>
        public const int AllTestComputer = 11;
        /// <summary>
        /// 当前值14，写入远程数据的开始通讯位置 
        /// </summary>
        public const int RemotWriteStart = 14;
        /// <summary>
        /// 当前值9，冷凝器工位数量
        /// </summary>
        public const int AllLengNinQiCount = 9;
        /// <summary>
        /// 当前值14，所有其他工位数量,机器人3个，性能检工位5，绕膜1个，打包1个，码垛4个
        /// </summary>
        public const int AllOtherMachineCount = 14;
        /// <summary>
        /// 当前值20，所有带灯的位置数量
        /// </summary>
        public const int AllLedSpace = 20;
        /// <summary>
        /// 所有须要登陆的位置，当前共有21个，带灯的20个，性能检1个。
        /// </summary>
        public const int AllUserSpace = 21;
        /// <summary>
        /// 所有电脑列表
        /// </summary>
        public enum AllComputerList
        {
            主机,
            上线,
            上压缩机,
            插管,
            整管,
            装冷凝器,
            装侧板,
            装风机,
            卤检,
            影像检,
            打包,
            折弯机
        }
    }
}
