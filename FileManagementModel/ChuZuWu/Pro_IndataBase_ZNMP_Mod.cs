using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Pro_IndataBase_ZNMP_Mod
    {

        /// <summary>
        /// 设备号码。
        /// </summary>
        public string Pi_DeviceCode { get; set; }

        /// <summary>
        /// 设备类型。
        /// </summary>
        public string Pi_DeviceType { get; set; }

        /// <summary>
        /// 命令字。
        /// </summary>
        public string Pi_ProtocolType { get; set; }

        /// <summary>
        /// 基站号码。
        /// </summary>
        public string Pi_StationNo { get; set; }

        /// <summary>
        /// 中继编号。
        /// </summary>
        public string Pi_RelayNo { get; set; }

        /// <summary>
        /// 设备时间。
        /// </summary>
        public DateTime Pi_DeviceTime { get; set; }

        /// <summary>
        /// 大数据时间。
        /// </summary>
        public DateTime Pi_ServiceTime { get; set; }

        /// <summary>
        /// 版本号。
        /// </summary>
        public string Pi_Version { get; set; }

        /// <summary>
        /// RSSI值。
        /// </summary>
        public string Pi_Rssi { get; set; }


        /// <summary>
        /// 参数。
        /// </summary>
        public string Pi_Param1 { get; set; }
        public string Pi_Param2 { get; set; }
        public string Pi_Param3 { get; set; }
        public string Pi_Param4 { get; set; }
        public string Pi_Param5 { get; set; }
        public string Pi_Param6 { get; set; }
        public string Pi_Param7 { get; set; }
        public string Pi_Param8 { get; set; }
        public string Pi_Param9 { get; set; }
        public string Pi_Param10 { get; set; }
        public string Pi_Param11 { get; set; }
        public string Pi_Param12 { get; set; }
        public string Pi_Param13 { get; set; }
        public string Pi_Param14 { get; set; }
        public string Pi_Param15 { get; set; }
        public string Pi_Param16 { get; set; }
        public string Pi_Param17 { get; set; }
        public string Pi_Param18 { get; set; }
        public string Pi_Param19 { get; set; }
        public string Pi_Param20 { get; set; }



        public Pro_IndataBase_ZNMP_Mod Clone()
        {
            return (Pro_IndataBase_ZNMP_Mod)base.MemberwiseClone();
        }


    }
}
