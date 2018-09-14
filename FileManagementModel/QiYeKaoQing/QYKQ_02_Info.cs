using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.QiYeKaoQing
{
    public class QYKQ_02_Info
    {

        /// <summary>
        /// 卡ID
        /// </summary>
        public string CARDID { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDENTITYNO { get; set; }

        /// <summary>
        /// 企业编码
        /// </summary>
        public string QYCODE { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OPERATETIME { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OPERATETYPE { get; set; }

        /// <summary>
        /// 上传类型
        /// </summary>
        public string UploadType { get; set; }

        /// <summary>
        /// 上传类型
        /// </summary>
        public string Upload { get; set; }

    }
}
