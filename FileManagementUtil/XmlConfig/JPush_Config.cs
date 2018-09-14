using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace FileManagementUtil.XmlConfig
{
	public class JPush_Config
	{

		public static JPushConfig_Mod GetConfig(string path, string name)
		{
			JPushConfig_Mod info = new JPushConfig_Mod();
			info.IsOpen = IsOpen(path, name);
			if (info.IsOpen)
			{
				info.TokenLit = ListToken(path, name);
				info.AppKeyList = ListAppKey(path, name);
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

		private static List<JPushConfig_Mod.TokenInfo> ListToken(string path, string name)
		{
			List<JPushConfig_Mod.TokenInfo> list = new List<JPushConfig_Mod.TokenInfo>();
			JPushConfig_Mod.TokenInfo info;
			List<string> listStr = new List<string>();
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
							if (xe1.Name == "Tokens")
							{
								foreach (XmlNode v in t.ChildNodes)
								{
									XmlElement xe2 = (XmlElement)v;
									if (xe2.Name == "Token")
									{
										info = new JPushConfig_Mod.TokenInfo();
										foreach (XmlNode Xe2_c in xe2.ChildNodes)
										{

											if (Xe2_c.Name == "Type")
											{
												info.Type = Xe2_c.InnerText;
											}
                                            if (Xe2_c.Name == "Name")
                                            {
                                                info.Name = Xe2_c.InnerText;
                                            }
                                            if (Xe2_c.Name == "Token")
											{
												info.Token = Xe2_c.InnerText;
											}

										}
										list.Add(info);
									}

								}
								return list;
							}

						}
					}
				}

			}
			return list;

		}


		private static List<JPushConfig_Mod.AppKeyInfo> ListAppKey(string path, string name)
		{
			List<JPushConfig_Mod.AppKeyInfo> list = new List<JPushConfig_Mod.AppKeyInfo>();
			JPushConfig_Mod.AppKeyInfo info;
			List<string> listStr = new List<string>();
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
							if (xe1.Name == "AppKeys")
							{
								foreach (XmlNode v in t.ChildNodes)
								{
									XmlElement xe2 = (XmlElement)v;
									if (xe2.Name == "AppKey")
									{
										info = new JPushConfig_Mod.AppKeyInfo();
										foreach (XmlNode Xe2_c in xe2.ChildNodes)
										{

											if (Xe2_c.Name == "AppKey")
											{
												info.AppKey = Xe2_c.InnerText;
											}
											if (Xe2_c.Name == "MasterSecret")
											{
												info.MasterSecret = Xe2_c.InnerText;
											}

										}
										list.Add(info);
									}

								}
								return list;
							}

						}
					}
				}

			}
			return list;

		}



		public class JPushConfig_Mod
		{
			public JPushConfig_Mod()
			{
				TokenLit = new List<TokenInfo>();
				AppKeyList = new List<AppKeyInfo>();

			}


			/// <summary>
			/// 是否开启推送。
			/// </summary>
			public bool IsOpen { get; set; }


			/// <summary>
			/// Type和Token配置列表。
			/// </summary>
			public List<TokenInfo> TokenLit { get; set; }

			/// <summary>
			/// AppKey和MasterSecret配置列表。
			/// </summary>
			public List<AppKeyInfo> AppKeyList { get; set; }


			public class TokenInfo
			{
				public string Type { get; set; }
				public string Token { get; set; }
                public string Name { get; set; }
			}

			public class AppKeyInfo
			{
				public string AppKey { get; set; }
				public string MasterSecret { get; set; }
			}
		}




	}
}
