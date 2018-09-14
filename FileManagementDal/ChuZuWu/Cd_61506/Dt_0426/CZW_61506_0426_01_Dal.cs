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
    /// 数据处理（NFC_心跳）
    /// </summary>
    public class CZW_61506_0426_01_Dal
    {

        public static Pro_InDatabase_NFC_Mod Get_Pro_Mod(CZW_61506_0426_01_Mod info)
        {
            Pro_InDatabase_NFC_Mod m = new Pro_InDatabase_NFC_Mod();

            m.PI_STATIONNO = info.基站编号.ToString();
            m.PI_SERVICETIME = info.平台时间;

            m.PI_DEVICETIME = info.设备时间;
            m.PI_RELAYNO = info.中继号;
            m.PI_DEVICETYPE = info.设备类型.ToString();
            m.PI_DEVICECODE = info.设备编号.ToString();
            m.PI_PROTOCOLTYPE = info.命令字.ToString();

            m.PI_BATTERY = info.电池电量.ToString();
            m.PI_VERSION = info.软件版本号.ToString();
            m.PI_RSSI = info.RSSI.ToString();

            return m;

        }






        /// <summary>
        /// 得到195（H:C3）实体
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static CZW_61506_0426_01_Mod GetMod(byte[] content)
        {


            CZW_61506_0426_01_Mod info = new CZW_61506_0426_01_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];

            info.电池电量 = content[14];
            info.软件版本号 = content[33];
            info.RSSI = content[34];



        

            return info;



        }

    }
}
