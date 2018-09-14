using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Pro_InDatabase_NFC_Mod
    {


        /// <summary>
        /// 设备号码
        /// </summary>
        public string PI_DEVICECODE { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string PI_DEVICETYPE { get; set; }

        /// <summary>
        /// 命令字
        /// </summary>
        public string PI_PROTOCOLTYPE { get; set; }

        /// <summary>
        /// 基站号码
        /// </summary>
        public string PI_STATIONNO { get; set; }

        /// <summary>
        /// 中继编号
        /// </summary>
        public string PI_RELAYNO { get; set; }

        /// <summary>
        /// 设备时间
        /// </summary>
        public DateTime PI_DEVICETIME { get; set; }

        /// <summary>
        /// 大数据时间
        /// </summary>
        public DateTime PI_SERVICETIME { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string PI_VERSION { get; set; }

        /// <summary>
        /// RSSI值
        /// </summary>
        public string PI_RSSI { get; set; }

        /// <summary>
        /// 卡类型（8：主管卡，9：身份证，7：IC卡）
        /// </summary>
        public string PI_CARDTYPE { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string PI_CARDID { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public string PI_OPERATE { get; set; }


        /// <summary>
        /// 电池电量
        /// </summary>
        public string PI_BATTERY { get; set; }
    }
}
