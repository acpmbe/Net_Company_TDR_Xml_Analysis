using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.YiKaGuanChuan
{
    public class Pro_CrewregistDevice_Beat_Mod
    {


        public string Pi_DevId { get; set; }
        public DateTime Pi_DevTime { get; set; }
        public string Pi_StateTFT { get; set; }
        public string Pi_State433 { get; set; }
        public string Pi_StateReader { get; set; }
        public string Pi_StateCard { get; set; }

        public string Pi_StatePrint { get; set; }
        public string Pi_StateSd { get; set; }
    }
}
