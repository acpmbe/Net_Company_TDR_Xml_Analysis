using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.DengJiJi.Cd_61443.Dt_8016
{


    /// <summary>
    /// 输入实体（登记机_心跳）
    /// </summary>
    public class DJJ_61443_8016_01_Mod
    {

        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }

        public string 省 { get; set; }
        public string 市 { get; set; }
        public string 卡类型 { get; set; }
        public string 运动状态 { get; set; }
        public string 电量 { get; set; }
        public string 版本号 { get; set; }
    
    }
}
