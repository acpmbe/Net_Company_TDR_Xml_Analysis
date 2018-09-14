using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.CeXie
{
    public class PushAlarmListInfo
    {

        public string DeviceId { get; set; }
        public string DeviceCode { get; set; }
        public string Description { get; set; }
        public string AngleX { get; set; }
        public string AngleY { get; set; }
        public string StandardX { get; set; }
        public string StandardY { get; set; }
        public DateTime AlarmTime { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Issuccess { get; set; }
    }
}
