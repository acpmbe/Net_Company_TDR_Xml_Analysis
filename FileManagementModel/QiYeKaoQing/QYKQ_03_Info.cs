using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.QiYeKaoQing
{
    public class QYKQ_03_Info
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
        /// 销卡类型
        /// </summary>
        public string UploadType { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Upload { get; set; }
    }
}
