using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.DengJiJi
{

    /// <summary>
    /// 过程实体
    /// </summary>
    public class Pro_InDatabase_LY_Mod
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
        /// 证件类型
        /// </summary>
        public string PI_IDENTITYTYPE { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string PI_IDENTITYCARD { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PI_IDENTITYNAME { get; set; }


        /// <summary>
        /// 民族
        /// </summary>
        public string PI_NATION { get; set; }
        /// <summary>
        /// 有源卡类型
        /// </summary>
        public string PI_CARDTYPE { get; set; }

        /// <summary>
        /// 有源卡号
        /// </summary>
        public string PI_CARDID { get; set; }

   
        /// <summary>
        /// 退住类型，1-手动，2-自动
        /// </summary>
        public string PI_OUTTYPE { get; set; }

        /// <summary>
        /// 省代码
        /// </summary>
        public string PI_PROVINCE { get; set; }

        /// <summary>
        /// 城代码
        /// </summary>
        public string PI_CITY { get; set; }

        /// <summary>
        /// 运动状态
        /// </summary>
        public string PI_KINESTATE { get; set; }

        /// <summary>
        /// 黑名单类型
        /// </summary>
        public string PI_BLACKTYPE { get; set; }

        /// <summary>
        /// 电量
        /// </summary>
        public string PI_ELECTRIC { get; set; }

        /// <summary>
        /// 软件版本号
        /// </summary>
        public string PI_SOFEVERSION { get; set; }

        /// <summary>
        /// 硬件版本号
        /// </summary>
        public string PI_HARDVERSION { get; set; }

        /// <summary>
        /// 设备时间
        /// </summary>
        public DateTime? PI_DEVICETIME { get; set; }

        /// <summary>
        /// 平台时间
        /// </summary>
        public DateTime? PI_SERVICETIME { get; set; }
    }
}
