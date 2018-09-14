using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Pro_IndateBase_MJNew_Mod
    {

        /// <summary>
        /// 协议大类。
        /// </summary>
        public string pi_bigtype { get; set; }

        /// <summary>
        /// 设备类型。
        /// </summary>
        public string pi_devicetype { get; set; }

        /// <summary>
        /// 命令协议。
        /// </summary>
        public string pi_protocoltype { get; set; }
        /// <summary>
        /// 设备号码。
        /// </summary>
        public string pi_devicecode { get; set; }

        /// <summary>
        /// 新设备号码。
        /// </summary>
        public string pi_newdevicecode { get; set; }

        /// <summary>
        /// 设备时间。
        /// </summary>
        public DateTime pi_devicetime { get; set; }

        /// <summary>
        /// 卡类型。
        /// </summary>
        public string pi_cardtype { get; set; }

        /// <summary>
        /// 卡号。
        /// </summary>
        public string pi_cardid { get; set; }

        /// <summary>
        /// 房东编号。
        /// </summary>
        public string pi_houseno { get; set; }

        /// <summary>
        /// 有源卡ID。
        /// </summary>
        public string pi_activecardid { get; set; }

        /// <summary>
        /// 警察卡。
        /// </summary>
        public string pi_policecard { get; set; }

        /// <summary>
        /// 撤布防状态。
        /// </summary>
        public string pi_status { get; set; }

        /// <summary>
        /// 基站号码。
        /// </summary>
        public string pi_stationno { get; set; }

        /// <summary>
        /// 中继号。
        /// </summary>
        public string pi_relayno { get; set; }

        /// <summary>
        /// 程序版本号。
        /// </summary>
        public string pi_version { get; set; }

        /// <summary>
        /// 平台时间。
        /// </summary>
        public DateTime pi_servicetime { get; set; }

    }
}
