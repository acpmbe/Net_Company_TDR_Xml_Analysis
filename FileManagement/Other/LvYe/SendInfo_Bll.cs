using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.LvYe;
using FileManagementDal.LvYe;

namespace FileManagement.Other.LvYe
{
    /// <summary>
    /// 发送信息。
    /// </summary>
    public class SendInfo_Bll
    {
   

        private string Content;
        private Pro_IndataBase_ZNMP_Mod Info;

        public SendInfo_Bll(string content, Pro_IndataBase_ZNMP_Mod info)
        {
            this.Content = content;
            this.Info = info;
        }

        /// <summary>
        /// 发送.
        /// </summary>
        public void Send()
        {
            try
            {
                List<Send_Mod> SendList = GeList();
                foreach (var v in SendList)
                {
                    string Result = SendInfo(v);
                    if (Result == "0")
                    {
                        SendRight(v);
                    }
                    else
                    {
                        SendErr(v, Result);
                    }
                }
              
            }
            catch(Exception ex)
            {

                MyLibrary.Log.Error("发送信息错误；" + ex.Message + " 设备Id：" +Info.PI_DEVID +" 命令字" + Info.PI_PROTOCOLTYPE);
             
            }
      

        }

        /// <summary>
        /// 得到发送列表。
        /// </summary>
        /// <returns></returns>
        private List<Send_Mod> GeList()
        {
            Msg_Mod Mm = MyLibrary.Json.Deserialize<Msg_Mod>(Content);
            Mm.message= "警告：" + Mm.message + ".";    
            List<Send_Mod> SendList = new List<Send_Mod>();
            Send_Mod sm;
            string[] PhoneArray = Mm.phone.Split(',');
            foreach (var v in PhoneArray)
            {
                sm = new Send_Mod();
                sm.Phone = v;
                sm.Content = Mm.message;
                sm.SourceId = Mm.sourceid;
                SendList.Add(sm);

            }
            return SendList;
        }

        /// <summary>
        /// 处理发送结果正确。
        /// </summary>
        /// <param name="v"></param>
        private void SendRight(Send_Mod v)
        {

            Tb_PushMessage_Mod info = new Tb_PushMessage_Mod();
            info.LISTID = MyGuid.Create();
            info.PUSHTYPE = "2";
            info.PUSHNUMBER = v.Phone;
            info.MESSAGETYPE = "1";
            info.PROTOCOLTYPE = Info.PI_PROTOCOLTYPE;
            info.MESSAGE = v.Content;
            info.PUSHTIME = DateTime.Now;
            info.ISSUCCESS = "1";
            info.SOURCEID = v.SourceId;
            info.ISALARM = "0";
            Tb_PushMessage_Dal.Insert(info);
        }

        /// <summary>
        /// 处理发送信息错误。
        /// </summary>
        /// <param name="v"></param>
        /// <param name="sendResult"></param>
        private void SendErr(Send_Mod v, string sendResult)
        {

            Tb_PushMessage_Mod info = new Tb_PushMessage_Mod();
            info.LISTID = MyGuid.Create();
            info.PUSHTYPE = "2";
            info.PUSHNUMBER = v.Phone;
            info.MESSAGETYPE = "1";
            info.PROTOCOLTYPE = Info.PI_PROTOCOLTYPE;
            info.MESSAGE = v.Content;
            info.PUSHTIME = DateTime.Now;
            info.ISSUCCESS = "2";
            info.SOURCEID = v.SourceId;
            info.ISALARM = "0";
            info.REASON = sendResult;
            Tb_PushMessage_Dal.Insert(info);
        }


        /// <summary>
        /// 发送信息。
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        private string SendInfo(Send_Mod sm)
        {
            SmsSend.SmsSendMod info = new SmsSend.SmsSendMod();
            info.ServerUrl = Config.SmsConfig.ServerUrl;
            info.AppId = Convert.ToInt32(Config.SmsConfig.AppId);
            info.AppKey = Config.SmsConfig.AppKey;
            info.Phone = sm.Phone;
            info.Content = sm.Content;
            SmsSend ss = new SmsSend(info);
            string msg;
            bool IsOk = ss.Send(out msg);
            if (IsOk)
            {
                return "0";
            }
            else
            {
                return msg;
            }

        }

        /// <summary>
        /// 信息实体。
        /// </summary>
        private class Msg_Mod
        {
            public string phone { get; set; }
            public string message { get; set; }
            public string sourceid { get; set; }
        }

        /// <summary>
        /// 发送信息实体。
        /// </summary>
        private class Send_Mod
        {
            public string Phone { get; set; }
            public string Content { get; set; }
            public string SourceId { get; set; }
        }
    }
}
