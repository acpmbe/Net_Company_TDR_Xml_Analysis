using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.QiYeKaoQing
{
    public class QYKQ_01_Info
    {
        /// <summary>
        /// 卡ID
        /// </summary>
        public string CARDID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDENTITYNO { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string CARDTYPE { get; set; }

        /// <summary>
        /// 企业编码
        /// </summary>
        public string QYCODE { get; set; }

        /// <summary>
        /// 上传类型
        /// </summary>
        public string UploadType { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public string RegistrationTime { get; set; }




        /// <summary>
        /// 现住地标准地址
        /// </summary>
        public string RESIDENCEADDRESS { get; set; }


        /// <summary>
        /// 现住地标准地址代码
        /// </summary>
        public string RESIDENCECODE { get; set; }
    }
}
