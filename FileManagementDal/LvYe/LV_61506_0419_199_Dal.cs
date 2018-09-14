using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementUtil;
using FileManagementUtil.Data;

namespace FileManagementDal.LvYe
{
    public class LV_61506_0419_199_Dal
    {



        public static Pro_IndataBase_ZNMP_Mod Get_Pro_Mod(LV_61506_0419_199_Mod info)
        {
            Pro_IndataBase_ZNMP_Mod m = new Pro_IndataBase_ZNMP_Mod();

            m.PI_STATIONNO = info.基站编号.ToString();
            m.PI_SERVICETIME = info.平台时间;
            m.PI_DEVICETIME = info.设备时间;
            m.PI_RELAYNO = info.中继号;
            m.PI_DEVICETYPE = info.设备类型.ToString();
            m.PI_DEVID = info.设备编号.ToString();
            m.PI_PROTOCOLTYPE = info.命令字.ToString();


            m.PI_PARAM1 = info.进出几人次.ToString();

            m.PI_PARAM2 = info.进出方向标识_信息.Merge();


            m.PI_PARAM3 = info.每个人身高_信息.Merge();
            m.PI_PARAM4 = info.进出结果1_信息.Merge();

            m.PI_PARAM5 = info.进出结果2_信息.Merge();

            m.PI_PARAM6 = info.进出结果2_信息.开始门状态.ToString();
            m.PI_PARAM7 = info.进出结果2_信息.最后门状态.ToString();


            m.PI_PARAM8 = info.进出结果2_信息.关门标志.ToString();
            m.PI_PARAM9 = info.进出结果2_信息.开门标志.ToString();



            m.PI_PARAM10 = info.进门累计统计.ToString();
            m.PI_PARAM11 = info.出门累计统计.ToString();
            m.PI_PARAM12 = info.门状态信息2.ToString();


            m.PI_VERSION = info.版本号.ToString();


            return m;


        }







        /// <summary>
        /// 得到195（H:C3）实体
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static LV_61506_0419_199_Mod GetMod(byte[] content)
        {


            LV_61506_0419_199_Mod info = new LV_61506_0419_199_Mod();
            info.设备时间 = ConverUtil.Time(content, 0);
            info.中继号 = content[6].ToString();
            info.设备类型 = ConverUtil.ByteToInt_2(content, 7);
            info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
            info.命令字 = content[13];
            info.进出几人次 = content[14];

            info.进出方向标识_信息 = Get_进出方向标识(content[15]);
            info.每个人身高_信息 = Get_每个人身高(content.Skip(16).Take(8).ToArray());

            info.进出结果1_信息 = Get_进出结果1(content[24]);
            info.进出结果2_信息 = Get_进出结果2(content[25]);


            info.进门累计统计 = content[26];
            info.出门累计统计 = content[27];
            info.门状态信息2 = Bit.GetBin(content[28], 0);

            info.RSSI值 = content[33];
            info.版本号 = content[34];

            return info;



        }


        private static LV_61506_0419_199_Mod.每个人身高 Get_每个人身高(byte[] content)
        {
            LV_61506_0419_199_Mod.每个人身高 info = new LV_61506_0419_199_Mod.每个人身高();



            info.第1个人身高 = content[0];
            info.第2个人身高 = content[1];
            info.第3个人身高 = content[2];
            info.第4个人身高 = content[3];
            info.第5个人身高 = content[4];
            info.第6个人身高 = content[5];
            info.第7个人身高 = content[6];
            info.第8个人身高 = content[7];






            return info;
        }

        private static LV_61506_0419_199_Mod.进出方向标识 Get_进出方向标识(byte content)
        {
            LV_61506_0419_199_Mod.进出方向标识 info = new LV_61506_0419_199_Mod.进出方向标识();



            info.第1个人的进出方向 = Bit.GetBin(content, 0);
            info.第2个人的进出方向 = Bit.GetBin(content, 1);
            info.第3个人的进出方向 = Bit.GetBin(content, 2);
            info.第4个人的进出方向 = Bit.GetBin(content, 3);
            info.第5个人的进出方向 = Bit.GetBin(content, 4);
            info.第6个人的进出方向 = Bit.GetBin(content, 5);
            info.第7个人的进出方向 = Bit.GetBin(content, 6);
            info.第8个人的进出方向 = Bit.GetBin(content, 7);




            return info;
        }

        private static LV_61506_0419_199_Mod.进出结果1 Get_进出结果1(byte content)
        {

            LV_61506_0419_199_Mod.进出结果1 info = new LV_61506_0419_199_Mod.进出结果1();

            info.算法1进门标志 = Bit.GetBin(content, 0);
            info.算法1出门标志 = Bit.GetBin(content, 1);
            info.算法1_1进门标志 = Bit.GetBin(content, 2);
            info.算法1_1出门标志 = Bit.GetBin(content, 3);
            info.算法1_2进门标志 = Bit.GetBin(content, 4);
            info.算法1_2出门标志 = Bit.GetBin(content, 5);
            info.算法1_3进门标志 = Bit.GetBin(content, 6);
            info.算法1_3出门标志 = Bit.GetBin(content, 7);

            return info;
        }

        private static LV_61506_0419_199_Mod.进出结果2 Get_进出结果2(byte content)
        {

            LV_61506_0419_199_Mod.进出结果2 info = new LV_61506_0419_199_Mod.进出结果2();

            info.算法2进门标志 = Bit.GetBin(content, 0);
            info.算法2出门标志 = Bit.GetBin(content, 1);
            info.算法1使能标志 = Bit.GetBin(content, 2);
            info.算法2使能标志 = Bit.GetBin(content, 3);
            info.开始门状态 = Bit.GetBin(content, 4);
            info.最后门状态 = Bit.GetBin(content, 5);
            info.关门标志 = Bit.GetBin(content, 6);
            info.开门标志 = Bit.GetBin(content, 7);


            return info;
        }

    }
}
