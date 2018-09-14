using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Tb_AutoDeployLog_Mod
    {

        public string NewListId { get; set; }
        public string OldListId { get; set; }
        public string OtherType { get; set; }
        public string OtherId { get; set; }
        public string DeployType { get; set; }
        public string DeployState { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string IsNextAlarm { get; set; }
        public DateTime StopTime { get; set; }
        public string AlarmInterval { get; set; }
        public DateTime NextTime { get; set; }
        public string Operator { get; set; }
        public string OperateType { get; set; }

        public DateTime OperaTime { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }


    }
}
