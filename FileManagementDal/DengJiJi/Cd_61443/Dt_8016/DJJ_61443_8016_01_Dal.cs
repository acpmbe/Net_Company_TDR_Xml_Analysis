using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementUtil.Data;
using FileManagementModel.DengJiJi;
using FileManagementModel.DengJiJi.Cd_61443.Dt_8016;

namespace FileManagementDal.DengJiJi.Cd_61443.Dt_8016
{


    /// <summary>
    /// 数据处理（登记机_心跳）
    /// </summary>
    public class DJJ_61443_8016_01_Dal
    {

        public static DJJ_61443_8016_01_Mod GetMod(byte[] content)
        {


            DJJ_61443_8016_01_Mod info = new DJJ_61443_8016_01_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];

            info.省 = content[14].ToString();
            info.市 = content[15].ToString();
            info.卡类型 = (Bit.GetBitR(content[16], 4, 7)).ToString();
            info.运动状态 = (Bit.GetBin(content[16], 0)).ToString() ;
            info.电量 = (Convert.ToDouble(content[17]) / 10).ToString(); ;
            info.版本号 = content[18].ToString();

            return info;


        }

        public static Pro_InDatabase_LY_Mod Get_Pro_Mod(DJJ_61443_8016_01_Mod info)
        {
            Pro_InDatabase_LY_Mod m = new Pro_InDatabase_LY_Mod();


     

            m.PI_DEVICETIME = info.设备时间;
            m.PI_SERVICETIME = info.平台时间;
            m.PI_DEVICECODE = info.基站编号.ToString();
            m.PI_DEVICETYPE = "1";  //暂时传1，聪聪确认。
            m.PI_PROTOCOLTYPE = info.命令字.ToString();
        
            m.PI_CARDTYPE = info.设备类型.ToString();
            m.PI_CARDID = info.设备编号.ToString();

            m.PI_PROVINCE = info.省;
            m.PI_CITY = info.市;
            m.PI_KINESTATE = info.运动状态;
            m.PI_ELECTRIC = info.电量;
            m.PI_SOFEVERSION = info.版本号;

            return m;


        }
    }
}
