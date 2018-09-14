using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.DengJiJi;

namespace FileManagementDal.DengJiJi
{

    /// <summary>
    /// 数据处理（登记机_有源卡ID信息上报）
    /// </summary>
    public class DJJ_2049_Dal
    {

        public static DJJ_2049_Mod GetMod(byte[] content)
        {


            DJJ_2049_Mod info = new DJJ_2049_Mod();
   
            info.有源卡ID = ConverUtil.ByteToStr_4(content, 0);

            return info;


        }

        public static Pro_InDatabase_LY_Mod Get_Pro_Mod(DJJ_2049_Mod info, string cmdId)
        {

            Pro_InDatabase_LY_Mod m = new Pro_InDatabase_LY_Mod();

            m.PI_DEVICETIME = info.平台时间;
            m.PI_SERVICETIME = info.平台时间;
            m.PI_DEVICECODE = info.基站编号.ToString();
            m.PI_DEVICETYPE = ""; 
            m.PI_PROTOCOLTYPE = cmdId;
            m.PI_CARDID = info.有源卡ID;

            return m;


        }
    }
}
