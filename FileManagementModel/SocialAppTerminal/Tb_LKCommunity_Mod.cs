using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.SocialAppTerminal
{
    public class Tb_LKCommunity_Mod
    {

//        select deviceid, devicename, devicetype, address, lat, ip, pcs, installtime, uint, remark, devicetime, lastupdatetime, 
//softversion, signal, hardwareversion from tb_lkcommunity

        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Ip { get; set; }
        public string Pcs { get; set; }
        public DateTime InstallTime { get; set; }
        public string Uint { get; set; }
        public string Remark { get; set; }
        public DateTime DeviceTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string SoftVersion { get; set; }
        public string Signal { get; set; }
        public string HardwareVersion { get; set; }


    }
}
