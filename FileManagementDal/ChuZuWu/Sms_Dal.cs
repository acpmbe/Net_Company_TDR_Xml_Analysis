using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;

namespace FileManagementDal.ChuZuWu
{
    //public class Sms_Dal
    //{
    //    private SmsMod Info;

    //    public Sms_Dal(SmsMod info)
    //    {
    //        this.Info = info;
    //    }

    //    public string Handle()
    //    {
    //        try
    //        {
    //            string Result = "";
    //            string Content = "\n告警：" + Info.AlarmContent + "\n" + Info.DeviceTime.ToString("MM月dd日HH时mm分");
    //            bool IsSend = SmsSend.Send(Info.Phone, Content, out Result);
    //            Insert(Content, IsSend, Result);
    //            return "0";
    //        }
    //        catch (Exception ex)
    //        {
    //            return ex.Message;
    //        }
    //    }

    //    private void Insert(string content, bool IsSend, string SendResult)
    //    {
    //        Tb_WechatMessage_Mod log = new Tb_WechatMessage_Mod();
    //        log.ListId = Guid.NewGuid().ToString("N");
    //        log.WechatId = Info.Phone;
    //        log.MessageType = 1;
    //        log.ProtocolType = Convert.ToInt32(Info.SubCmd);
    //        log.SourceId = Info.Reason;
    //        log.Message = content;
    //        log.Reserved2 = Info.UserId;
    //        log.PushType = "2";
    //        log.IsSuccess = IsSend ? "1" : "2";
    //        if (SendResult.Length >= 100)
    //        {
    //            SendResult = SendResult.Substring(0, 100);
    //        }
    //        log.Reserved1 = log.IsSuccess == "1" ? "" : SendResult;
    //        Tb_WechatMessage_Dal.Insert(log);


    //    }

    //    public class SmsMod
    //    {

    //        /// <summary>
    //        /// 电话号码。
    //        /// </summary>
    //        public string Phone { get; set; }

    //        /// <summary>
    //        /// 用户Id。
    //        /// </summary>
    //        public string UserId { get; set; }

    //        /// <summary>
    //        /// 报警内容。
    //        /// </summary>
    //        public string AlarmContent { get; set; }

    //        /// <summary>
    //        /// 设备时间。
    //        /// </summary>
    //        public DateTime DeviceTime { get; set; }

    //        /// <summary>
    //        /// 命令字。
    //        /// </summary>
    //        public string SubCmd { get; set; }

    //        /// <summary>
    //        /// 
    //        /// </summary>
    //        public string Reason { get; set; }
    //    }
    //}
}
