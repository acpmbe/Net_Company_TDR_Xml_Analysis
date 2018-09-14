using System;
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
    /// 数据处理（单人进出协议数据上传）
    /// </summary>
    public class CZW_61506_0411_177_Dal
    {

        public static Pro_IndataBase_ZNMP_Mod Get_Pro_Mod(CZW_61506_0411_177_Mod info)
        {
            Pro_IndataBase_ZNMP_Mod m = new Pro_IndataBase_ZNMP_Mod();

            m.Pi_StationNo = info.基站编号.ToString();
            m.Pi_ServiceTime = info.平台时间;
            m.Pi_DeviceTime = info.设备时间;
            m.Pi_RelayNo = info.中继号;
            m.Pi_DeviceType = info.设备类型.ToString();
            m.Pi_DeviceCode = info.设备编号.ToString();
            m.Pi_ProtocolType = info.命令字.ToString();


            m.Pi_Param1 = info.环境状态.ToString();
            m.Pi_Param2 = info.环境值.ToString();
            m.Pi_Param3 = info.对地校准值.ToString();
            m.Pi_Param4 = info.工作状态.ToString();
            m.Pi_Param5 = info.当前环境温度.ToString();
            m.Pi_Param6 = info.防拆报警和当前门状态_信息.Merge();
            m.Pi_Param7 = info.电池电压.ToString();
            m.Pi_Param8 = info.热视电触发次数.ToString();
            m.Pi_Param9 = info.超声波总工作时间.ToString();
            m.Pi_Param10 = info.热释电总触发次数.ToString();
            m.Pi_Param11 = info.总震动次数.ToString();
            m.Pi_Param12 = info.门左右倾斜角度.ToString();
            m.Pi_Param13 = info.设备状态_信息.Merge();
            m.Pi_Param14 = info.门上下倾斜角度.ToString();
            m.Pi_Param15 = info.激光关门值.ToString();
            m.Pi_Param16 = info.烟感和激光使能_信息.Merge();


            m.Pi_Version = info.版本号.ToString();
            m.Pi_Rssi = info.RSSI值.ToString();

            return m;


        }

        public static CZW_61506_0411_177_Mod GetMod(byte[] content)
        {


            CZW_61506_0411_177_Mod info = new CZW_61506_0411_177_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];


            info.环境状态 = content[14];
            info.环境值 = content[15];
            info.对地校准值 = content[16];
            info.工作状态 = content[17];
            info.当前环境温度 = ConverUtil.ByteToInt16(content[18]);
            info.防拆报警和当前门状态_信息 = GetJC_1(content[19]);
            info.电池电压 = content[20];
            info.热视电触发次数 = content[21];
            info.超声波总工作时间 = ConverUtil.ByteToUint16(content.Skip(22).Take(2).ToArray());
            info.热释电总触发次数 = ConverUtil.ByteToUint16(content.Skip(24).Take(2).ToArray());
            info.总震动次数= ConverUtil.ByteToUint16(content.Skip(26).Take(2).ToArray());
            info.门左右倾斜角度 = ConverUtil.ByteToInt16(content[28]);
            info.设备状态_信息 = GetJC_2(content[29]);
            info.门上下倾斜角度 = ConverUtil.ByteToInt16(content[30]);
            info.激光关门值 = content[31];
            info.烟感和激光使能_信息 = GetJC_3(content[32]);
            info.版本号 = content[33];
            info.RSSI值 = content[34];
     
            return info;


        }

     

        private static CZW_61506_0411_177_Mod.防拆报警和当前门状态 GetJC_1(byte content)
        {
            CZW_61506_0411_177_Mod.防拆报警和当前门状态 info = new CZW_61506_0411_177_Mod.防拆报警和当前门状态();


            info.防拆报警 = Bit.GetBin(content, 0);
            info.当前门状态 = Bit.GetBin(content, 1);
     

            return info;
        }

        private static CZW_61506_0411_177_Mod.设备状态 GetJC_2(byte content)
        {
            CZW_61506_0411_177_Mod.设备状态 info = new CZW_61506_0411_177_Mod.设备状态();


            info.超声波 = Bit.GetBin(content, 0);
            info.热释电 = Bit.GetBin(content, 1);


            return info;
        }

        private static CZW_61506_0411_177_Mod.烟感和激光使能 GetJC_3(byte content)
        {
            CZW_61506_0411_177_Mod.烟感和激光使能 info = new CZW_61506_0411_177_Mod.烟感和激光使能();


            info.烟感级别 = Bit.GetBitR(content, 1,7);
            info.激光使能 = Bit.GetBitR(content, 0,1);


            return info;
        }


    }
}
