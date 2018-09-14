using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;


namespace FileManagementUtil
{
    /// <summary>
    /// 百度云推送。
    /// </summary>
    public class BaiDuPush
    {


        private static string WebSite = ConfigurationManager.AppSettings["WebSite"];

        private static string UsernameAndPassword = ConverUtil.StrToBase64(ConfigurationManager.AppSettings["UserName"] + ":" + ConfigurationManager.AppSettings["PassWord"]);


        private string SendContent;

        private PushType PushType;
        private string channel_id;
        private string ApiKey;
        private string SecretKey;

        private string title;
        private string MessageID;
        private string MessageText;
        private DateTime MessageTime;
        private string TergetID;



        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="_pushType">推送的手机类型。</param>
        /// <param name="_channel_id">通道Id</param>
        /// <param name="_title">通知标题。</param>
        /// <param name="_messageID">消息编号（插入微信日志的guid）。</param>
        /// <param name="_messageText">消息文本（推送微信的信息）。</param>
        /// <param name="_messageTime">报警发生时间。</param>
        /// <param name="_tergetID">对象编号（存储过程返回的po_reason）。</param>
        public BaiDuPush(PushType _pushType, string _ApiKey, string _SecretKey, string _channel_id, string _title, string _messageID, string _messageText, DateTime _messageTime, string _tergetID)
        {

            this.PushType = _pushType;
            this.ApiKey = _ApiKey;
            this.SecretKey = _SecretKey;
            this.channel_id = _channel_id;
            this.title = _title;
            this.MessageID = _messageID;
            this.MessageText = _messageText;
            this.MessageTime = _messageTime;
            this.TergetID = _tergetID;
            switch (_pushType)
            {
                case PushType.Android:
                    InitialAndroid();
                    break;
                case PushType.Ios:
                    InitialIos();
                    break;
            }

        }

        public BaiDuPush(BaiDuPushInfo info)
        {

            this.PushType = info.PushType;
            this.channel_id = info.Channel_id;
            this.ApiKey = info.ApiKey;
            this.SecretKey = info.SecretKey;
            this.title = info.Title;
            this.MessageID = info.MessageID;
            this.MessageText = info.MessageText;
            this.MessageTime = info.MessageTime;
            this.TergetID = info.TergetID;
            switch (this.PushType)
            {
                case PushType.Android:
                    InitialAndroid();
                    break;
                case PushType.Ios:
                    InitialIos();
                    break;
            }


        }
        void InitialAndroid()  //推送安卓手机初始化。
        {
            CustomContent c = new CustomContent();
            c.MessageID = MessageID;
            c.MessageText = MessageText;
            c.MessageType = "1";
            c.MessageTime = MessageTime.ToString("yyyy-MM-dd HH:mm:ss");
            c.Level = "1";
            c.TergetType = "ALARM";
            c.TergetID = TergetID;

            messageAndroid m = new messageAndroid();
            m.title = title;  //
            m.description = MessageText;
            m.notification_builder_id = 0;
            m.notification_basic_style = 1;
            m.custom_content = c;

            content t = new content();
            t.channel_id = channel_id;
            t.ApiKey = this.ApiKey;
            t.SecretKey = this.SecretKey;
            t.msg_type = "1";
            t.device_type = "3"; // （Android = 3 ，Ios = 4）
            t.msg = m.ToString();

            SendContent = t.ToString();
        }

        void InitialIos()  //推送苹果手机初始化。
        {

            aps aps = new BaiDuPush.aps();
            aps.alert = title;
            aps.sound = "default";
            aps.badge = "0";
            aps.contentAvailable = 1;

            messageIos m = new messageIos();
            m.aps = aps;
            m.MessageID = MessageID;
            m.MessageText = MessageText;
            m.MessageType = "1";
            m.MessageTime = MessageTime.ToString("yyyy-MM-dd HH:mm:ss");
            m.Level = "1";
            m.TergetType = "ALARM";
            m.TergetID = TergetID;

            content t = new content();
            t.channel_id = channel_id;
            t.ApiKey = this.ApiKey;
            t.SecretKey = this.SecretKey;
            t.msg_type = "1";
            t.device_type = "4"; // （Android = 3 ，Ios = 4）
            t.msg = m.ToString();

            SendContent = t.ToString();


        }

        /// <summary>
        /// 发送百度云推送。
        /// </summary>
        /// <returns>处理结果（0：成功 其它：出错信息）</returns>
        public string SendPush()
        {
            try
            {


                if (SendContent != "")
                {
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    client.Headers.Add("Authorization", "Basic " + UsernameAndPassword);//base64(账号:密码)
                    client.Encoding = Encoding.UTF8;
                    string RequestContent = client.UploadString(WebSite, "post", SendContent);
                    BaiDuResponseValue responseValue =MyLibrary.Json.Deserialize< BaiDuResponseValue >(RequestContent);
                    if (responseValue.error_code == null)  //发送成功
                    {
                        return "0";
                    }
                    else
                    {
                        return "接口_" + responseValue.error_msg;
                    }
                }
                else
                {
                    return "初始化出错。";
                }
            }
            catch (Exception ex)
            {
                return "系统_" + ex.Message;
            }

        }

        private class content
        {
            public string channel_id { get; set; }
            public string ApiKey { get; set; }
            public string SecretKey { get; set; }
            public string msg_type { get; set; }
            public string device_type { get; set; }
            public string msg { get; set; }


            public override string ToString()
            {
                return MyLibrary.Json.Serialize<content>(this);
            }
        }
        private class messageAndroid
        {
            /// <summary>
            /// 通知标题。
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// 通知文本内容，不能为空。
            /// </summary>
            public string description { get; set; }
            public int notification_builder_id { get; set; }
            public int notification_basic_style { get; set; }
            public int open_type { get; set; }
            public string pkg_content { get; set; }
            public string url { get; set; }

            /// <summary>
            /// 自定义内容。
            /// </summary>
            public CustomContent custom_content { get; set; }
            public override string ToString()
            {
                return MyLibrary.Json.Serialize<messageAndroid>(this);
            }
        }
        private class messageIos
        {

            /// <summary>
            /// 消息编号（插入微信日志的guid）。
            /// </summary>
            public string MessageID { get; set; }

            /// <summary>
            /// 消息文本（推送微信的信息）。
            /// </summary>
            public string MessageText { get; set; }

            /// <summary>
            /// 消息类型（固定值1）。
            /// </summary>
            public string MessageType { get; set; }


            /// <summary>
            /// 报警发生时间。
            /// </summary>
            public string MessageTime { get; set; }


            /// <summary>
            /// 消息等级（固定值1）。
            /// </summary>
            public string Level { get; set; }


            /// <summary>
            /// 对象类型（固定值"ALARM"）。
            /// </summary>
            public string TergetType { get; set; }


            /// <summary>
            /// 对象编号（存储过程返回的po_reason）。
            /// </summary>
            public string TergetID { get; set; }
            /// <summary>
            /// 自定义内容。
            /// </summary>
            public aps aps { get; set; }


            public override string ToString()
            {
                return MyLibrary.Json.Serialize<messageIos>(this);
            }
        }
        private class aps
        {
            public string alert { get; set; }

     
            [ Newtonsoft.Json.JsonProperty("content-available")]
            public uint? contentAvailable { get; set; }
            public string badge { get; set; }
            public string sound { get; set; }


        }
        private class CustomContent
        {


            /// <summary>
            /// 消息编号（插入微信日志的guid）。
            /// </summary>
            public string MessageID { get; set; }

            /// <summary>
            /// 消息文本（推送微信的信息）。
            /// </summary>
            public string MessageText { get; set; }

            /// <summary>
            /// 消息类型（固定值1）。
            /// </summary>
            public string MessageType { get; set; }


            /// <summary>
            /// 报警发生时间。
            /// </summary>
            public string MessageTime { get; set; }


            /// <summary>
            /// 消息等级（固定值1）。
            /// </summary>
            public string Level { get; set; }


            /// <summary>
            /// 对象类型（固定值"ALARM"）。
            /// </summary>
            public string TergetType { get; set; }


            /// <summary>
            /// 对象编号（存储过程返回的po_reason）。
            /// </summary>
            public string TergetID { get; set; }
        }
        private class BaiDuResponseValue
        {
            /// <summary>
            /// 请求Id。
            /// </summary>
            public string request_id { get; set; }

            /// <summary>
            /// 错误编号。
            /// </summary>
            public string error_code { get; set; }

            /// <summary>
            /// 错误信息。
            /// </summary>
            public string error_msg { get; set; }
            public ResponseParams response_params { get; set; }

        }
        private class ResponseParams
        {
            /// <summary>
            /// 该条消息id。
            /// </summary>
            public string msg_id { get; set; }

            /// <summary>
            /// 消息的实际推送时间。
            /// </summary>
            public string send_time { get; set; }

        }

        public class BaiDuPushInfo
        {


            /// <summary>
            /// 推送的手机类型。
            /// </summary>
            public PushType PushType { get; set; }

            /// <summary>
            /// 通道Id
            /// </summary>
            public string Channel_id { get; set; }


            /// <summary>
            /// 每个应用对应的ApiKey。
            /// </summary>
            public string ApiKey { get; set; }

            /// <summary>
            /// 每个应用对应的SecretKey。
            /// </summary>
            public string SecretKey { get; set; }

            /// <summary>
            /// 通知标题。
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// 消息编号。
            /// </summary>
            public string MessageID { get; set; }

            /// <summary>
            /// 消息文本。
            /// </summary>
            public string MessageText { get; set; }

            /// <summary>
            /// 报警发生时间。
            /// </summary>
            public DateTime MessageTime { get; set; }

            /// <summary>
            /// 对象编号（存储过程返回的po_reason）。
            /// </summary>
            public string TergetID { get; set; }
        }
    }

    /// <summary>
    /// 百度云推送类型。
    /// </summary>
    public enum PushType
    {
        /// <summary>
        /// 推送到安卓手机。
        /// </summary>
        Android,

        /// <summary>
        /// 推送到苹果手机。
        /// </summary>
        Ios
    }
}
