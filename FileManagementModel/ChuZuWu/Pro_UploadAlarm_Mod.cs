using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Pro_UploadAlarm_Mod
    {

        public string pi_protocoltype { get; set; }
        public string pi_stationno { get; set; }
        public string pi_roomnum { get; set; }
        public string pi_alarmtype { get; set; }
        public DateTime pi_devicetime { get; set; }
        public DateTime pi_servicetime { get; set; }
    }
}
