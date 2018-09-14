using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Sms_Bll
    {

        private SmsMod Info;

        public Sms_Bll(SmsMod info)
        {
            this.Info = info;
        }

        public string Handle()
        {
            try
            {
                string Result = "";      
                bool IsSend = Send(Info.Phone, Info.Content, out Result);
                Insert(Info.Content, IsSend, Result);
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



		private bool Send(string phone, string content, out string result)
		{
			SmsSend.SmsSendMod info = new SmsSend.SmsSendMod();
			info.ServerUrl = Config.SmsConfig.ServerUrl;
			info.AppId = Convert.ToInt32(Config.SmsConfig.AppId);
			info.AppKey = Config.SmsConfig.AppKey;
			info.Phone = phone;
			info.Content = content;
			SmsSend ss = new SmsSend(info);
			return ss.Send(out result);
		}

		private void Insert(string content, bool IsSend, string SendResult)
        {
            Tb_WechatMessage_Mod log = new Tb_WechatMessage_Mod();
            log.ListId = Guid.NewGuid().ToString("N");
            log.WechatId = Info.Phone;
            log.MessageType = 1;
            log.ProtocolType = Convert.ToInt32(Info.SubCmd);
            log.SourceId = Info.Reason;
            log.Message = content;
            log.Reserved2 = Info.UserId;
            log.PushType = "2";
            log.IsSuccess = IsSend ? "1" : "2";
            if (SendResult.Length >= 100)
            {
                SendResult = SendResult.Substring(0, 100);
            }
            log.Reserved1 = log.IsSuccess == "1" ? "" : SendResult;
            Tb_WechatMessage_Dal.Insert(log);


        }

        public class SmsMod
        {

            /// <summary>
            /// 电话号码。
            /// </summary>
            public string Phone { get; set; }


            /// <summary>
            /// 发送内容。
            /// </summary>
            public string Content { get; set; }

            /// <summary>
            /// 用户Id。
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// 报警内容。
            /// </summary>
            public string AlarmContent { get; set; }

            /// <summary>
            /// 设备时间。
            /// </summary>
            public DateTime DeviceTime { get; set; }

            /// <summary>
            /// 命令字。
            /// </summary>
            public string SubCmd { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Reason { get; set; }
        }
    }
}
