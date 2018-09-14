using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.CeXie
{
    public class CeXieInfo
    {

        public DateTime DeviceTime { get; set; }
        public string DeviceType { get; set; }
        public string DeviceId { get; set; }
        public string ProtocolType { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string Reserved5 { get; set; }
        public string Version { get; set; }
        public string StationNo { get; set; }
        public DateTime ServiceTime { get; set; }
    }
}
