using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagementUtil.XmlConfig
{
	public class Wechat_Config
	{

		public static Wechat_Config_Mod GetConfig(string path, string name)
		{
			Wechat_Config_Mod info = new Wechat_Config_Mod();
			info.IsOpen = IsOpen(path, name);
			if (info.IsOpen)
			{
				Wechat_Config_Mod Temp = GetValue(path, name);
				info.ChuZuWu_F002 = Temp.ChuZuWu_F002;
				info.ChuZuWu_F004 = Temp.ChuZuWu_F004;
	
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

		private static Wechat_Config_Mod GetValue(string path, string name)
		{

			Wechat_Config_Mod info = new Wechat_Config_Mod();

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
							if (xe1.Name == "ChuZuWu_F002")
							{
								info.ChuZuWu_F002 = xe1.InnerText;
							}
							if (xe1.Name == "ChuZuWu_F004")
							{
								info.ChuZuWu_F004 = xe1.InnerText;
							}
					

						}

						return info;

					}
				}

			}

			return info;


		}

		public class Wechat_Config_Mod
		{


			/// <summary>
			/// 是否开启。
			/// </summary>
			public bool IsOpen { get; set; }

			public string ChuZuWu_F002 { get; set; }
			public string ChuZuWu_F004 { get; set; }



		}
	}
}
