using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;
using FileManagementUtil.Data;

namespace FileManagementDal.ChuZuWu.Cd_61506.Dt_0426
{

    /// <summary>
    /// 数据处理（NFC_刷卡记录）
    /// </summary>
    public class CZW_61506_0426_04_Dal
    {

        public static Pro_InDatabase_NFC_Mod Get_Pro_Mod(CZW_61506_0426_04_Mod info)
        {
            Pro_InDatabase_NFC_Mod m = new Pro_InDatabase_NFC_Mod();

            m.PI_STATIONNO = info.基站编号.ToString();
            m.PI_SERVICETIME = info.平台时间;

            m.PI_DEVICETIME = info.设备时间;
            m.PI_RELAYNO = info.中继号;
            m.PI_DEVICETYPE = info.设备类型.ToString();
            m.PI_DEVICECODE = info.设备编号.ToString();
            m.PI_PROTOCOLTYPE = info.命令字.ToString();

            m.PI_OPERATE = info.操作结果.ToString();
            m.PI_CARDTYPE = info.卡类型.ToString();

            if (m.PI_CARDTYPE == "9")
            {
                m.PI_CARDID = info.卡号;
            }
            else if (m.PI_CARDTYPE == "10")
            {
                m.PI_CARDID = info.卡号;
            }
            else if (m.PI_CARDTYPE == "0")
            {
                m.PI_CARDID = info.卡号;
            }
            else
            {
                m.PI_CARDID = GetCardId(info.卡号);
            }



            m.PI_VERSION = info.软件版本号.ToString();
            m.PI_RSSI = info.RSSI.ToString();

            return m;

        }

        /// <summary>
        /// 取前面4字节并转10进制
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static string GetCardId(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return "";
            }

            return (Convert.ToUInt32(content, 16)).ToString();

        }






        public static CZW_61506_0426_04_Mod GetMod(byte[] content)
        {


            CZW_61506_0426_04_Mod info = new CZW_61506_0426_04_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];


            info.操作结果 = content[14];
            info.卡类型 = content[15];
            info.卡号 = ConverUtil.ByteToStr_Q(content, 16, 8);
            info.软件版本号 = content[33];
            info.RSSI = content[34];

            return info;


        }
    }
}
