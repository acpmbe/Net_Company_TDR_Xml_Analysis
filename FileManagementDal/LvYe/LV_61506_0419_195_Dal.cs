using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementUtil;

namespace FileManagementDal.LvYe
{
  public  class LV_61506_0419_195_Dal
    {


        /// <summary>
        /// 得到智能门牌过程实体
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Pro_IndataBase_ZNMP_Mod Get_Pro_Mod(LV_61506_0419_195_Mod info)
        {
            Pro_IndataBase_ZNMP_Mod m = new Pro_IndataBase_ZNMP_Mod();

            m.PI_STATIONNO = info.基站编号.ToString();
            m.PI_SERVICETIME = info.平台时间;
            m.PI_DEVICETIME = info.设备时间;
            m.PI_RELAYNO = info.中继号;
            m.PI_DEVICETYPE = info.设备类型.ToString();
            m.PI_DEVID = info.设备编号.ToString();
            m.PI_PROTOCOLTYPE = info.命令字.ToString();
            m.PI_PARAM1 = info.最大身高.ToString();

            m.PI_PARAM2 = info.头部信息.进出门标志.ToString();
            m.PI_PARAM3 = info.头部信息.关门标志.ToString();
            m.PI_PARAM4 = info.头部信息.开关标志.ToString();
            m.PI_PARAM5 = info.头部信息.是否有多人进入.ToString();

            m.PI_PARAM6 = info.腿部信息.Merge();
            m.PI_PARAM7 = info.手臂信息.Merge();
            m.PI_PARAM8 = info.肩膀信息.Merge();
            m.PI_PARAM9 = info.面部信息.Merge();
            m.PI_PARAM10 = info.头部信息.Merge();

            m.PI_VERSION = info.版本号.ToString();
       
            return m;


        }



        /// <summary>
        /// 得到195（H:C3）实体
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static LV_61506_0419_195_Mod GetMod(byte[] content)
        {


            LV_61506_0419_195_Mod info = new LV_61506_0419_195_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];
            info.最大身高 = content[14];
            info.腿部信息 = GetLegMod(content.Skip(15).Take(2).ToArray());
            info.手臂信息 = GetArmMod(content.Skip(17).Take(3).ToArray());
            info.肩膀信息 = GetShoulderMod(content.Skip(20).Take(4).ToArray());
            info.面部信息 = GetFaceMod(content.Skip(24).Take(3).ToArray());
            info.头部信息 = GetHeadMod(content.Skip(27).Take(6).ToArray());
            info.RSSI值 = content[33];
            info.版本号 = content[34];

            return info;



        }


        private static LV_61506_0419_195_Mod.腿部实体 GetLegMod(byte[] content)
        {
            LV_61506_0419_195_Mod.腿部实体 info = new LV_61506_0419_195_Mod.腿部实体();
            if (content.Length == 2)
            {
                info.拐点时间 = content[0];
                info.对地波动次数 = GetByteR(content[1], 0, 3);
                info.小波动次数 = GetByteR(content[1], 4, 7);
            }
            return info;
        }

        private static LV_61506_0419_195_Mod.手臂实体 GetArmMod(byte[] content)
        {
            LV_61506_0419_195_Mod.手臂实体 info = new LV_61506_0419_195_Mod.手臂实体();
            if (content.Length == 3)
            {
                info.拐点时间 = content[0];
                info.对地波动次数 = GetByteR(content[1], 5, 7);
                info.小波动最大波动幅度 = GetByteR(content[1], 0, 4);
                info.小波动次数 = GetByteR(content[2], 4, 7);
                info.曲线变化级别 = GetByteR(content[2], 0, 3);
            }
            return info;
        }

        private static LV_61506_0419_195_Mod.肩膀实体 GetShoulderMod(byte[] content)
        {
            LV_61506_0419_195_Mod.肩膀实体 info = new LV_61506_0419_195_Mod.肩膀实体();
            if (content.Length == 4)
            {
                info.拐点时间 = content[0];

                info.对地波动次数 = GetByteR(content[1], 4, 7);
                info.小波动次数 = GetByteR(content[1], 0, 3);

                info.肩膀高度 = content[2];

                info.小波动最大波动幅度 = GetByteR(content[3], 3, 7);
                info.运行速度 = GetByteR(content[3], 0, 2);

            }
            return info;
        }

        private static LV_61506_0419_195_Mod.面部实体 GetFaceMod(byte[] content)
        {
            LV_61506_0419_195_Mod.面部实体 info = new LV_61506_0419_195_Mod.面部实体();
            if (content.Length == 3)
            {
                info.拐点时间 = content[0];

                info.对地波动次数 = GetByteR(content[1], 4, 7);
                info.小波动次数 = GetByteR(content[1], 0, 3);

                info.小波动最大值 = content[2];

            }
            return info;
        }

        private static LV_61506_0419_195_Mod.头部实体 GetHeadMod(byte[] content)
        {
            LV_61506_0419_195_Mod.头部实体 info = new LV_61506_0419_195_Mod.头部实体();
            if (content.Length == 6)
            {


                info.对地波动次数 = GetByteR(content[0], 4, 7);
                info.小波动次数 = GetByteR(content[0], 0, 3);

                // info.门下驻停时间 = (double)content[1] / 10;
                info.门下驻停时间 = content[1];

                info.开门到关门时间 = content[2];

                info.进门肩膀高度 = content[3];

                info.关门震动级别 = content[4];

                info.手上是否有物品 = GetBin(content[5], 0);
                info.低头次数 = GetByteR(content[5], 1, 2);
                info.是否复杂波形 = GetBin(content[5], 3);
                info.是否有多人进入 = GetBin(content[5], 4);
                info.开关标志 = GetBin(content[5], 5);
                info.关门标志 = GetBin(content[5], 6);
                info.进出门标志 = GetBin(content[5], 7);

            }
            return info;
        }


        /// <summary>
        /// 返回位的值（顺序:左往右）
        /// </summary>
        /// <param name="content"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static byte GetByteL(byte content, int start, int end)
        {

            string BinaryStr = Convert.ToString(content, 2).PadLeft(8, '0');
            int Lenght;
            if (start == 0)
            {
                Lenght = end + 1;
            }
            else
            {
                Lenght = (end - start) + 1;
            }
            string SelectStr = BinaryStr.Substring(start, Lenght);
            return Convert.ToByte(SelectStr, 2);

        }

        /// <summary>
        /// 返回位的值（顺序:右往左）
        /// </summary>
        /// <param name="content"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static byte GetByteR(byte content, int start, int end)
        {

            string BinaryStr = Convert.ToString(content, 2).PadLeft(8, '0');
            BinaryStr = ReverseStr(BinaryStr);
            int Lenght;
            if (start == 0)
            {
                Lenght = end + 1;
            }
            else
            {
                Lenght = (end - start) + 1;
            }
            string SelectStr = BinaryStr.Substring(start, Lenght);
            SelectStr = ReverseStr(SelectStr);
            return Convert.ToByte(SelectStr, 2);

        }


        /// <summary>
        /// 字符串反转
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string ReverseStr(string text)
        {
            string reverse = string.Empty;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse += text[i];
            }

            return reverse;
        }

        /// <summary>
        /// 取位的值
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="start">开始</param>
        /// <returns></returns>
        private static byte GetBin(byte content, int start)
        {

            string BinaryStr = Convert.ToString(content, 2).PadLeft(8, '0');
            BinaryStr = ReverseStr(BinaryStr);
            string SelectStr = BinaryStr.Substring(start, 1);
            return Convert.ToByte(SelectStr, 2);

        }
    }
}
