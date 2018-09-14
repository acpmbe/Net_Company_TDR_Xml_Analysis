using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{

    /// <summary>
    /// 输入实体（NFC_刷卡记录）
    /// </summary>
    public class CZW_61506_0426_04_Mod
    {

        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }


        public byte? 操作结果 { get; set; }
        public byte? 卡类型 { get; set; }
        public string 卡号 { get; set; }
        public byte? 软件版本号 { get; set; }
        public byte? RSSI { get; set; }
    }
}
