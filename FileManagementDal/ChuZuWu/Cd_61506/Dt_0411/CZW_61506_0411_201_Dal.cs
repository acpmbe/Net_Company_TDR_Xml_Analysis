using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;
using FileManagementUtil.Data;

namespace FileManagementDal.ChuZuWu.Cd_61506.Dt_0411
{

    /// <summary>
    /// 数据处理（电子防盗门牌_门状态改变上传）
    /// </summary>
    public class CZW_61506_0411_201_Dal
    {


        public static Pro_IndataBase_ZNMP_Mod Get_Pro_Mod(CZW_61506_0411_201_Mod info)
        {
            Pro_IndataBase_ZNMP_Mod m = new Pro_IndataBase_ZNMP_Mod();

            m.Pi_StationNo = info.基站编号.ToString();
            m.Pi_ServiceTime = info.平台时间;
            m.Pi_DeviceTime = info.设备时间;
            m.Pi_RelayNo = info.中继号;
            m.Pi_DeviceType = info.设备类型.ToString();
            m.Pi_DeviceCode = info.设备编号.ToString();
            m.Pi_ProtocolType = info.命令字.ToString();

            m.Pi_Param1 = info.门状态_信息.开始门状态.ToString();
            m.Pi_Param2 = info.门状态_信息.最后门状态.ToString();
            m.Pi_Param3 = info.门状态_信息.关门标志.ToString();
            m.Pi_Param4 = info.门状态_信息.开门标志.ToString();
            m.Pi_Param5 = info.门状态_信息.触发前门状态.ToString();

            m.Pi_Param6 = info.进门累计统计.ToString();
            m.Pi_Param7 = info.出门累计统计.ToString();

            m.Pi_Version = info.版本号.ToString();
            m.Pi_Rssi = info.RSSI值.ToString();

            return m;


        }




        /// <summary>
        /// 得到201（H:C9）实体
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static CZW_61506_0411_201_Mod GetMod(byte[] content)
        {


            CZW_61506_0411_201_Mod info = new CZW_61506_0411_201_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];


            info.门状态_信息 = Get_门状态(content[14]);
            info.进门累计统计 = content[15];
            info.出门累计统计 = content[16];
            info.版本号 = content[33];
            info.RSSI值 = content[34];
       
            return info;



        }


        private static CZW_61506_0411_201_Mod.门状态 Get_门状态(byte content)
        {

            CZW_61506_0411_201_Mod.门状态 info = new CZW_61506_0411_201_Mod.门状态();
            info.开始门状态 = Bit.GetBin(content, 0);
            info.最后门状态 = Bit.GetBin(content, 1);
            info.关门标志 = Bit.GetBin(content, 2);
            info.开门标志 = Bit.GetBin(content, 3);
            info.触发前门状态 = Bit.GetBin(content, 4);

            return info;
        }



  

    }
}
