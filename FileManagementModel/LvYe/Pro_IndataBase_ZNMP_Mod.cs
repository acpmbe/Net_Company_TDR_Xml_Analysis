using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.LvYe
{
    public class Pro_IndataBase_ZNMP_Mod
    {
        public string PI_DEVID { get; set; }
        public string PI_DEVICETYPE { get; set; }
        public string PI_PROTOCOLTYPE { get; set; }
        public string PI_STATIONNO { get; set; }
        public string PI_RELAYNO { get; set; }
        public DateTime PI_DEVICETIME { get; set; }
        public DateTime PI_SERVICETIME { get; set; }
        public string PI_VERSION { get; set; }
        public string PI_PARAM1 { get; set; }
        public string PI_PARAM2 { get; set; }
        public string PI_PARAM3 { get; set; }
        public string PI_PARAM4 { get; set; }
        public string PI_PARAM5 { get; set; }
        public string PI_PARAM6 { get; set; }
        public string PI_PARAM7 { get; set; }
        public string PI_PARAM8 { get; set; }
        public string PI_PARAM9 { get; set; }
        public string PI_PARAM10 { get; set; }
        public string PI_PARAM11 { get; set; }
        public string PI_PARAM12 { get; set; }
        public string PI_PARAM13 { get; set; }
        public string PI_PARAM14 { get; set; }
        public string PI_PARAM15 { get; set; }
        public string PI_PARAM16 { get; set; }
        public string PI_PARAM17 { get; set; }
        public string PI_PARAM18 { get; set; }
        public string PI_PARAM19 { get; set; }
        public string PI_PARAM20 { get; set; }


        public Pro_IndataBase_ZNMP_Mod Clone()
        {
            return (Pro_IndataBase_ZNMP_Mod)base.MemberwiseClone();
        }
    }
}
