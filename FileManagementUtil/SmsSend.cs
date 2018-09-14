using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManagementUtil
{
	public class SmsSend
	{

		private SmsSendMod Info;
		public SmsSend(SmsSendMod info)
		{
			this.Info = info;
		}


		public bool Send(out string msg)
		{


			TDR.OpenMasSMSLib.SMSSender sender = new TDR.OpenMasSMSLib.SMSSender(Info.ServerUrl, Info.AppId, Info.AppKey);
			return sender.SendSms(Info.Phone, Info.Content, out msg);


		}

		public class SmsSendMod
		{
			public string ServerUrl { get; set; }
			public int AppId { get; set; }
			public string AppKey { get; set; }
			public string Phone { get; set; }
			public string Content { get; set; }
		}


	}
}
