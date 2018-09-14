using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.CeXie;
using MyLibrary;



namespace FileManagementDal.CeXie
{
	public class ICeXieDal
	{

		/// <summary>
		/// 处理测斜数据。
		/// </summary>
		/// <param name="Name">命令名称。</param>
		/// <param name="OriginalCode">原始数据。</param>
		/// <param name="info">测斜信息。</param>
		public static void Handle(string Name, string OriginalCode, CeXieInfo info)
		{


			UInt16 ResultNum;
			string Reason;
			CeXieDal.GetDeviceInfo(info, out ResultNum, out Reason);
			if (ResultNum == 0)
			{
				MyLibrary.Log.Debug(Name + "正常信息：" + Reason + " 设备编号：" + info.DeviceId);
			}
			else if (ResultNum == 1)
			{
				MyLibrary.Log.Debug(Name + "出错：" + Reason + " 设备编号：" + info.DeviceId + " 原始代码：" + OriginalCode);
			}
			else
			{
				string[] InfoArray = Reason.Split(',');
				string m_DeviceId = InfoArray[0];
				string m_DESCRIPTION = InfoArray[1];
				string m_StandardX = InfoArray[2];
				string m_StandardY = InfoArray[3];
				List<SendInfo> sendInfo = CeXieDal.GetSendList();
				if (sendInfo.Count != 0)
				{
					string RetrunMsg = "";
					string content = "";
					PushAlarmListInfo listInfo;
					for (int i = 0; i < sendInfo.Count; i++)
					{
						//content = "警告：" + sendInfo[i].Name + "你好，[" + info.DeviceTime + "][" + m_DESCRIPTION + "]监测到倾斜角度位移超过5°，正常X轴" + m_StandardX + "°Y轴" + m_StandardY + "°，目前X轴" + info.Reserved1 + "°Y轴" + info.Reserved2 + "°，请尽快排查处理！";

						content = "【天地人科技】警告：" + sendInfo[i].Name + "您好，" + info.DeviceTime.ToString("yyyy - MM - dd") + "，我公司监测到设备" + info.DeviceId + "，安装位置为" + m_DESCRIPTION + "，边坡结构发生倾斜，存在滑坡险情，请尽快排查处理、";

						listInfo = new PushAlarmListInfo();
						bool IsOk = Send(sendInfo[i].Phone, content, out RetrunMsg);
						listInfo.Issuccess = IsOk?"1":"2";


						listInfo.DeviceId = m_DeviceId;
						listInfo.DeviceCode = info.DeviceId;
						listInfo.Description = m_DESCRIPTION;
						listInfo.AngleX = info.Reserved1;
						listInfo.AngleY = info.Reserved2;
						listInfo.StandardX = m_StandardX;
						listInfo.StandardY = m_StandardY;
						listInfo.AlarmTime = info.DeviceTime;
						listInfo.Name = sendInfo[i].Name;
						listInfo.Phone = sendInfo[i].Phone;
						CeXieDal.PushAlarmList_Insert(listInfo);
						MyLibrary.Log.Debug(RetrunMsg + " 设备编号：" + listInfo.DeviceCode);

					}
				}
				else
				{
					MyLibrary.Log.Debug(Name + "；推送预警配置表（TB_PUSHALARMSET）没有任何内容 设备编号：" + info.DeviceId);
				}


			}
		}


		private static bool Send(string phone, string content, out string result)
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


	}
}
