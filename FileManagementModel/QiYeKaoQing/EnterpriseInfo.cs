using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.QiYeKaoQing
{
    public class EnterpriseInfo
    {

        /// <summary>
        /// 企业号码。
        /// </summary>
        public string QIYECODE { get; set; }

        /// <summary>
        /// MD5。
        /// </summary>
        public string MD5 { get; set; }

        /// <summary>
        /// 员工姓名和身份证号。
        /// </summary>
        public List<string> users { get; set; }
    }
}
