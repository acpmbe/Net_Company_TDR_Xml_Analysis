using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil
{
    public class JPush
    {

        private SendMod Info;
        public JPush(SendMod info)
        {
            this.Info = info;
        }

     
        public bool Send(out string replyStr)
        {

            ServiceReference_JPush.WebCardHolderSoapClient c = new ServiceReference_JPush.WebCardHolderSoapClient();
            string Result = c.CardHolder(Info.Token, Info.CardType, Info.TaskId, Info.Encryption, Info.DataTypeCode, Info.Content_Json);


    //        string CardHolder(string token, string cardType, string taskId, string encryption, string DataTypeCode, string content)
    //FileManagementUtil.ServiceReference_JPush.WebCardHolderSoap 的成员



            ReturnMod rm = MyLibrary.Json.Deserialize<ReturnMod>(Result);
            if (rm.ResultCode == "0")
            {
                replyStr = rm.ResultText;
                return true;
            }
            else
            {
                replyStr = rm.ResultText;
                return false;
            }

        }

        public class SendMod
        {
            public SendMod()
            {
                Content = new content();
            }

            /// <summary>
            /// 通信令牌。
            /// </summary>
            public string Token { get; set; }

            /// <summary>
            /// 卡包中的类型。
            /// </summary>
            public string CardType { get; set; }

            /// <summary>
            /// 用户字自定义数据,数据返回时,返回相同的数据。
            /// </summary>
            public string TaskId { get; set; }

            /// <summary>
            /// 加密方式。
            /// </summary>
            public string Encryption { get; set; }

            /// <summary>
            /// 请求数据类别。
            /// </summary>
            public string DataTypeCode { get; set; }

            /// <summary>
            /// 数据内容。
            /// </summary>
            public content Content { get; set; }

            /// <summary>
            /// 把内容序列化存储。
            /// </summary>
            public string Content_Json { get; set; }


            /// <summary>
            /// 内容类。
            /// </summary>
            public class content
            {

                public string App_Key { get; set; }
                public string Master_Secret { get; set; }

                /// <summary>
                /// 卡代码。
                /// </summary>
                public string CardCode { get; set; }


                /// <summary>
                /// 城市编码。
                /// </summary>
                public string CityCode { get; set; }

                /// <summary>
                /// 用户userid。
                /// </summary>
                public string OpenId { get; set; }


     

                public string ChannelID { get; set; }


                /// <summary>
                /// 发送内容。
                /// </summary>
                public string Message { get; set; }

            
                /// <summary>
                /// 自己生成的Guid。
                /// </summary>
                public string MessageId { get; set; }

              
                /// <summary>
                /// 命令字。
                /// </summary>
                public string Cmd { get; set; }

                /// <summary>
                /// 消息类型（1普通 2报警 3广告）。
                /// </summary>
                public string MessageType { get; set; }

                /// <summary>
                /// 扩展字段。
                /// </summary>
                public string Extras { get; set; }


            }


        }

        private class ReturnMod
        {


            /// <summary>
            ///0：表示成功，1：发送失败， 2：异常错误
            /// </summary>
            public string ResultCode { get; set; }

            /// <summary>
            /// 返回文本。
            /// </summary>
            public string ResultText { get; set; }
            public string DataTypeCode { get; set; }
            public string TaskID { get; set; }
            public content Content { get; set; }

            public class content
            {
                public string MessageID { get; set; }
                public result Result { get; set; }

                public class result
                {
                    public string msg_id { get; set; }
                    public string sendno { get; set; }
                    public responseResult ResponseResult { get; set; }

                    public class responseResult
                    {
                        public string jpushError { get; set; }
                        public string responseCode { get; set; }
                        public string rateLimitQuota { get; set; }
                        public string rateLimitRemaining { get; set; }
                        public string rateLimitReset { get; set; }
                        public string exceptionString { get; set; }

                        public string responseContent { get; set; }


                    }

                }


            }

        }
    }
}
