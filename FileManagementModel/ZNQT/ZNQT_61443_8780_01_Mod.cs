using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ZNQT
{
    public class ZNQT_61443_8780_01_Mod
    {

        public uint 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public UInt16 SN号 { get; set; }
        public UInt16 中继编号 { get; set; }
        public UInt16 设备类型 { get; set; }
        public UInt32 设备编号 { get; set; }
        public byte 命令字 { get; set; }
        public byte 版本号 { get; set; }
        public string 内容 { get; set; }
        public byte 内容长度 { get; set; }


    }
}
