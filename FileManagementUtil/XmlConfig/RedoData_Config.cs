using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagementUtil.XmlConfig
{
	public class RedoData_Config
	{

		public static RedoData_Config_Mod GetConfig(string path, string name)
		{

			RedoData_Config_Mod info = new RedoData_Config_Mod();		
			info.IsOpen = IsOpen(path, name);
			if (info.IsOpen)
			{
				RedoData_Config_Mod Temp = GetValue(path, name);
				info.DataMark = Temp.DataMark;
				info.BufferTime = Temp.BufferTime;	
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

		private static RedoData_Config_Mod GetValue(string path, string name)
		{

			RedoData_Config_Mod info = new RedoData_Config_Mod();

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
							if (xe1.Name == "DataMark")
							{
								info.DataMark = xe1.InnerText;
							}
							if (xe1.Name == "BufferTime")
							{
								info.BufferTime = Convert.ToUInt32(xe1.InnerText);
							}

						}
						return info;
					}
				}

			}

			return info;

		}

		public class RedoData_Config_Mod
		{


			/// <summary>
			/// 是否开启。
			/// </summary>
			public bool IsOpen { get; set; }


			/// <summary>
			/// 数据标识
			/// </summary>
			public string DataMark { get; set; }

			/// <summary>
			/// 缓存时间
			/// </summary>
			public UInt32 BufferTime { get; set; }


		}
	}
}
