using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;

namespace FileManagement.Commands.DuanXinFaSongCommand
{
    public class DuanXinFaSongCommand : ICommand
    {

        public static string SmsType { get; set; }
        public static bool IsSend = Config.SmsConfig.IsOpen;

        string EQID { get; set; }
        string Content { get; set; }
        DateTime DeviceTime { get; set; }
        public DuanXinFaSongCommand(string _EQID,string _Content,DateTime _DeviceTime)
        {
            this.EQID = _EQID;
            this.Content = _Content;
            this.DeviceTime = _DeviceTime;
        }
        public bool Execute()
        {
            try
            {
                if(IsSend)
                {
                    string NeiRong = "设备时间: "+this.DeviceTime+"  内容: "+this.Content;           
                    string[] phoneList = this.EQID.Split(',');
                    string Msg = "";
                    bool IsOk;             
                    foreach (string phone in phoneList)
                    {
                        IsOk = Send(phone, NeiRong, out Msg);                       
                        if(IsOk)
                        {
                            MyLibrary.Log.Debug("电话: " + phone + " 设备时间: " + this.DeviceTime + " 内容: " + this.Content + " ---  发送成功");
                        }
                        else
                        {
                            MyLibrary.Log.Debug("电话: " + phone + " 设备时间: " + this.DeviceTime + " 内容: " + this.Content + " ---  发送出错："+Msg);
                        }
                      
                    }
                }     
            }
            catch(Exception ex)
            {
                MyLibrary.Log.Error("发送出错:" + ex.Message + " 电话:" + this.EQID+" 设备时间:" + this.DeviceTime  + " 内容:" + this.Content);
            }      
            return true;
        }



		private  bool Send(string phone, string content, out string result)
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
