using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace FileManagementUtil.XmlConfig
{
	/// <summary>
	/// 百度云推送配置。
	/// </summary>
	public class BPush_Config
	{

		public static BPush_Config_Mod GetConfig(string path, string name)
		{
			BPush_Config_Mod info = new BPush_Config_Mod();
			info.IsOpen = IsOpen(path, name);
			if (info.IsOpen)
			{
				BPush_Config_Mod Temp = GetValue(path, name);
				info.WebSite = Temp.WebSite;
				info.UserName = Temp.UserName;
				info.PassWord = Temp.PassWord;
				info.Android = GetValue12(path, name);
				info.Ios = GetValue1222(path, name);
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

		private static BPush_Config_Mod GetValue(string path, string name)
		{

			BPush_Config_Mod info = new BPush_Config_Mod();

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
							if (xe1.Name == "WebSite")
							{
								info.WebSite = xe1.InnerText;
							}
							if (xe1.Name == "UserName")
							{
								info.UserName = xe1.InnerText;
							}
							if (xe1.Name == "PassWord")
							{
								info.PassWord = xe1.InnerText;
							}
						}
						return info;

					}
				}

			}

			return info;


		}

		private static BPush_Config_Mod.AndroidMod GetValue12(string path, string name)
		{

			BPush_Config_Mod.AndroidMod info = new BPush_Config_Mod.AndroidMod();
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
							if (xe1.Name == "Android")
							{
								foreach(XmlNode vv in t.ChildNodes)
								{
									if (vv.Name == "ApiKey")
									{
										info.ApiKey = vv.InnerText;
									}
									if (vv.Name == "SecretKey")
									{
										info.SecretKey = vv.InnerText;
									}
								}
								return info;				
							}					
						}
					}
				}

			}
			return info;

		}

		private static BPush_Config_Mod.IosMod GetValue1222(string path, string name)
		{

			BPush_Config_Mod.IosMod info = new BPush_Config_Mod.IosMod();
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
							if (xe1.Name == "Ios")
							{
								foreach (XmlNode vv in t.ChildNodes)
								{
									if (vv.Name == "ApiKey")
									{
										info.ApiKey = vv.InnerText;
									}
									if (vv.Name == "SecretKey")
									{
										info.SecretKey = vv.InnerText;
									}
								}
								return info;
							}
						}
					}
				}

			}
			return info;

		}

		public class BPush_Config_Mod
		{


			/// <summary>
			/// 是否开启。
			/// </summary>
			public bool IsOpen { get; set; }
			public string WebSite { get; set; }
			public string UserName { get; set; }
			public string PassWord { get; set; }
			public AndroidMod Android { get; set; }
			public IosMod Ios { get; set; }
			public class AndroidMod
			{
				public string ApiKey { get; set; }
				public string SecretKey { get; set; }
			}

			public class IosMod
			{
				public string ApiKey { get; set; }
				public string SecretKey { get; set; }
			}



		}


	}
}
