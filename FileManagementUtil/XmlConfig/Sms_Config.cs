using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagementUtil.XmlConfig
{
	public class Sms_Config
	{

		public static Sms_Config_Mod GetConfig(string path, string name)
		{
			Sms_Config_Mod info = new Sms_Config_Mod();
			info.IsOpen = IsOpen(path, name);		
			if (info.IsOpen)
			{
				Sms_Config_Mod Temp = GetValue(path, name);
				info.ServerUrl = Temp.ServerUrl;
				info.AppId = Temp.AppId;
				info.AppKey = Temp.AppKey;
			}
			return info;
		}
		private static bool IsOpen(string path, string name)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(path);
			XmlNode xn = xmlDoc.SelectSingleNode("configuration");
			XmlNodeList XmlList = xn.ChildNodes;
			foreach (XmlNode xnf in XmlList)
			{

				XmlElement xe122 = (XmlElement)xnf;
				if (xe122.GetAttribute("Name") == name)
				{
					string Str = xe122.GetAttribute("IsOpen");
					return Convert.ToBoolean(Str);
				}

			}
			return false;

		}

		private static Sms_Config_Mod GetValue(string path, string name)
		{

			Sms_Config_Mod info = new Sms_Config_Mod();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(path);
			XmlNode xn = xmlDoc.SelectSingleNode("configuration");
			XmlNodeList XmlList = xn.ChildNodes;
			foreach (XmlNode xnf in XmlList)
			{
				XmlElement xe122 = (XmlElement)xnf;
				if (xe122.GetAttribute("Name") == name)
				{
					XmlElement xe = (XmlElement)xnf;
					if (xe.Name == "Config")
					{
						foreach (XmlNode t in xnf.ChildNodes)
						{
							XmlElement xe1 = (XmlElement)t;
							if (xe1.Name == "ServerUrl")
							{
								info.ServerUrl = xe1.InnerText;
							}
							if (xe1.Name == "AppId")
							{
								info.AppId = xe1.InnerText;
							}
							if (xe1.Name == "AppKey")
							{
								info.AppKey = xe1.InnerText;
							}

						}

						return info;

					}
				}

			}

			return info;


		}

		public class Sms_Config_Mod
		{
		

			/// <summary>
			/// 是否开启。
			/// </summary>
			public bool IsOpen { get; set; }

			public string ServerUrl { get; set; }
			public string AppId { get; set; }
			public string AppKey { get; set; }



		}

	}
}
