using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.MenJin
{
    public class MJInfo
    {

        /// <summary>
        /// 协议命令字。
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// 设备编号。
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 卡Id。
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 卡类型。
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// 身份证号。
        /// </summary>
        public string Identitycard { get; set; }

        /// <summary>
        /// 身份证Id。
        /// </summary>
        public string IdentitycardId { get; set; }

        /// <summary>
        /// 中文名称。
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// 删除类型。
        /// </summary>
        public string DeleteType { get; set; }

        /// <summary>
        /// 警察卡。
        /// </summary>
        public string PoliceCard { get; set; }
        /// <summary>
        /// 数据完整性。
        /// </summary>
        public string DataIntegrity { get; set; }

        /// <summary>
        /// 用户电话号码。
        /// </summary>
        public string UserPhoneNum { get; set; }

        /// <summary>
        /// 用户房间。
        /// </summary>
        public string UserRoom { get; set; }

        /// <summary>
        /// 门是否打开。
        /// </summary>
        public string IsOpenDoor { get; set; }

        /// <summary>
        /// 卡是否有效。
        /// </summary>
        public string IsOpenByCard { get; set; }

        /// <summary>
        /// Sim卡号。
        /// </summary>
        public string SimNum{get;set;}

        /// <summary>
        /// 设备时间。
        /// </summary>
        public DateTime DeviceTime { get; set; }


    }
}
