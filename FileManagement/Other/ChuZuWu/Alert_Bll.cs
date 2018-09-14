using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;
using MyLibrary;
using FileManagementDal.ChuZuWu;
namespace FileManagement.Other.ChuZuWu
{
    public class Alert_Bll
    {
	

        private Alert_Mod Info;
        private string IsPush;

		private readonly string Name = "报警";
        public Alert_Bll(Alert_Mod info)
        {

            this.Info = info;
        }
		public string handle()
		{

			List<ReturnDalInfo> ListInfo = new List<ReturnDalInfo>();
			ListInfo = Json.Deserialize<List<ReturnDalInfo>>(Info.WechatId);
			Log.Warn("Wechatid：" + Info.WechatId);
			if (ListInfo.Count != 0)
			{
				foreach (var v in ListInfo)
				{
					Single(v, Info.AlarmContent);
				}
				return "0";
			}
			else
			{
				return "存储过程返回的警报内容为空。";
			}

		}

		private void Single(ReturnDalInfo info, string alarmContent)
		{
			bool IsOk = true;
		//	bool IsOk_N = false;
			if (Config.JPushConfig.IsOpen)
			{
            

                string R = Verify(info);
				if (R == "0")
				{
					IsOk = JPush(info, alarmContent, out R);
					IsPush = IsOk ? "1" : "2";
					JPush_Insert(info, alarmContent, IsPush, R);
				}
				else
				{
					Log.Warn(Name + "出错；" + R);
				}

				//R = Verify_N(info);
				//if (R == "0")
				//{
				//	IsOk_N = JPush_New(info, alarmContent, out R);
				//	IsPush = IsOk_N ? "1" : "2";
				//	JPush_Insert(info, alarmContent, IsPush, R);

				//}
				//else
				//{
				//	MyLog.Warn(Name + "出错；" + R);
				//}

			}

			//if (Config.SmsConfig.IsOpen)
			//{
			//	if (!IsOk && !IsOk_N)
			//	{
			//		SendSms(info.Phone, info.Identitycard);
			//	}
			//}

            if (Config.SmsConfig.IsOpen)
            {
                if (!IsOk )
                {
                    SendSms(info.Phone, info.Identitycard);
                }
            }


        }



		private bool JPush(ReturnDalInfo info, string alarmContent, out string result)
		{

			JPush.SendMod j = JPushMod(info, alarmContent);
			Log.Warn("UserToken：" + info.UserToken + " AppcardType：" + j.Content.CardCode + " 通信令牌：" + j.Token);
			JPush jp = new JPush(j);
			return jp.Send(out result);

		}

		private bool JPush_New(ReturnDalInfo info, string alarmContent, out string result)
		{

			JPush.SendMod j = JPushMod_New(info, alarmContent);
			Log.Warn("UserToken：" + info.UserToken + " AppcardType：" + j.Content.CardCode + " 通信令牌：" + j.Token);
			JPush jp = new JPush(j);
			return jp.Send(out result);

		}


		private string Verify(ReturnDalInfo info)
		{
	
			if(string.IsNullOrEmpty(info.UserToken))
			{
				return "UserToken不能为空";
			}
			else
			{
				if(string.IsNullOrEmpty(info.AppcardType))
				{
					return "AppcardType不能为空";
				}
			}		
			return "0";
		}


		private string Verify_N(ReturnDalInfo info)
		{
	
			if(!String.IsNullOrEmpty(info.SYSTEMNAME))
			{
				if(info.SYSTEMNAME== "Android" || info.SYSTEMNAME== "iOS")
				{
					if(!string.IsNullOrEmpty(info.PUSHAPPID))
					{
						if(info.PUSHAPPID!="-1")
						{
							return "0";
						}
						else
						{
							return "字段PUSHAPPID中内容出错";
						}
					}
					else
					{
						return "字段PUSHAPPID不能为空";
					}
				}
				else
				{
					return "字段SYSTEMNAME中内容出错";
				}

			}
			else
			{
				return "字段SYSTEMNAME不能为空";
			}



		}

        private void SendSms(string phone, string userId)
        {
            if (!string.IsNullOrEmpty(phone))
            {

                Sms_Bll.SmsMod info = new Sms_Bll.SmsMod();
                info.AlarmContent = Info.AlarmContent;
                info.DeviceTime = Info.DeviceTime;
                info.Phone = phone;
                info.Content = "\n告警：" + Info.AlarmContent + "\n" + Info.DeviceTime.ToString("MM月dd日HH时mm分");
                info.Reason = Info.Reason;
                info.SubCmd = Info.ProtocolType;
                info.UserId = userId;
                Sms_Bll d = new Sms_Bll(info);
                string Result = d.Handle();
                if (Result != "0")
                {
                    Log.Warn("短信发送错误；电话号码：" + info.Phone + " 内容：" + info.AlarmContent);
                }

            }

        }


        private void JPush_Insert(ReturnDalInfo info, string alarmContent, string isPush, string errInfo)
        {
            Tb_WechatMessage_Mod w = new Tb_WechatMessage_Mod();
            w.ListId = Guid.NewGuid().ToString("N");
            w.WechatId = info.UserToken;
            w.MessageType = 1;
            w.ProtocolType = Convert.ToInt32(Info.ProtocolType);
            w.Message = alarmContent;
            w.IsSuccess = isPush;
            w.PushType = "4";
            w.SourceId = Info.Reason;
            w.Reserved1 = errInfo;
            w.Reserved2 = info.Identitycard;
            w.Reserved4 = GetName(info.AppcardType);
            Tb_WechatMessage_Dal.Insert(w);

        }

        private JPush.SendMod JPushMod(ReturnDalInfo info, string content)
        {
            JPush.SendMod j = new JPush.SendMod();
            j.Token = Token(info.AppcardType);
            j.DataTypeCode = "SendPush";
            j.Content.MessageId = Guid.NewGuid().ToString("N"); ;  //自己生成的guid 
            j.Content.OpenId = info.UserToken; //就是接芳的传过来的usertoken 
     
            j.Content.CardCode = info.AppcardType; //接芳传过来的 appcardtype。
            j.Content.Message = content;  //发送内容。
            j.Content.MessageType = "2";
            j.Content.Extras = Info.Reason;
            j.Content_Json = Json.Serialize<JPush.SendMod.content>(j.Content);
            return j;
        }

        private JPush.SendMod JPushMod_New(ReturnDalInfo info, string content)
        {
            JPush.SendMod j = new JPush.SendMod();

			j.Content.App_Key = Config.JPushConfig.AppKeyList[0].AppKey;       //通过过程取得。
			j.Content.Master_Secret = Config.JPushConfig.AppKeyList[0].MasterSecret;  //通过过程取得。
            j.Content.ChannelID = info.PUSHAPPID;       //通过过程取得。
            j.Token = "";
            j.DataTypeCode = "SendPush_CM";
            j.Content.MessageId = Guid.NewGuid().ToString("N"); ;  //自己生成的guid 
            j.Content.OpenId = info.UserToken; //就是接芳的传过来的usertoken 
       
            j.Content.CardCode = info.AppcardType; //接芳传过来的 appcardtype。
            j.Content.Message = content;  //发送内容。
            j.Content.MessageType = "2";
            j.Content.Extras = Info.Reason;
            j.Content_Json = Json.Serialize<JPush.SendMod.content>(j.Content);
            return j;
        }




        private string Token(string appCardType)
        {
            foreach (var v in Config.JPushConfig.TokenLit)
            {
                if (v.Type == appCardType)
                {
                    return v.Token;
                }
            }
            return "";
        }


        private string GetName(string appCardType)
        {
            foreach (var v in Config.JPushConfig.TokenLit)
            {
                if (v.Type == appCardType)
                {
                    return v.Name;
                }
            }
            return "";
        }



        public class Alert_Mod
        {
            public string ProtocolType { get; set; }
            public DateTime DeviceTime { get; set; }
            public string Reason { get; set; }
            public string WechatId { get; set; }
            public string AlarmContent { get; set; }

        }
    }
}
