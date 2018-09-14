using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    public class Tb_WechatMessage_Mod
    {
        public string ListId { get; set; }
        public string WechatId { get; set; }
        public int MessageType { get; set; }
        public int ProtocolType { get; set; }
        public string Message { get; set; }
        public DateTime PushTime { get; set; }
        public string IsSuccess { get; set; }
        public string SourceId { get; set; }
        public int IsAlarm { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
        public string Reserved3 { get; set; }
        public string Reserved4 { get; set; }
        public string PushType { get; set; }
    }
}
