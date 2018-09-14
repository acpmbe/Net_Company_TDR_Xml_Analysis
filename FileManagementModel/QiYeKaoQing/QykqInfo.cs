using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.QiYeKaoQing
{
    public class QykqInfo
    {


        /// <summary>
        /// 命令字。
        /// </summary>
        public string pi_CmdId { get; set; }

        /// <summary>
        /// 企业Id。
        /// </summary>
        public string pi_EnterpriseID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string pi_StaffName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string pi_IdentityCardNo { get; set; }

        /// <summary>
        /// 关联卡号。
        /// </summary>
        public string pi_CardID { get; set; }

        /// <summary>
        /// 登记时间。
        /// </summary>
        public DateTime pi_RegistrationTime { get; set; }

        /// <summary>
        /// 数据完整性。
        /// </summary>
        public string pi_Dataintegrity { get; set; }

        /// <summary>
        /// 上传类型。
        /// </summary>
        public string pi_UploadType { get; set; }

        /// <summary>
        /// 考勤记录时间。
        /// </summary>
        public DateTime pi_RecordTime { get; set; }

        /// <summary>
        /// 设备时间。
        /// </summary>
        public DateTime pi_DeviceTime { get; set; }

        /// <summary>
        /// 考勤类型。
        /// </summary>
        public string pi_RecordType { get; set; }

        /// <summary>
        /// 上传。
        /// </summary>
        public string pi_Upload { get; set; }


        /// <summary>
        /// 现住地标准地址。
        /// </summary>
        public string pi_ResidenceAddress { get; set; }


        /// <summary>
        /// 现住地标准地址代码。
        /// </summary>
        public string pi_ResidenceCode { get; set; }

    }
}
