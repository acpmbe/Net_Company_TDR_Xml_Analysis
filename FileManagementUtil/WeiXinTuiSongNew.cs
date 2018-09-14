using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil
{
    public class WeiXinTuiSongNew
    {

        private string Opeinid;
        private string Title;
        private string Content;
        private string Reason;
        private DateTime DeviceTime;
        public WeiXinTuiSongNew(string _Opeinid, string _Title, string _Content, string _Reason, DateTime _DeviceTime)
        {
            this.Opeinid = _Opeinid;
            this.Title = _Title;
            this.Content = _Content;
            this.Reason = _Reason;
            this.DeviceTime = _DeviceTime;
        }
        public string Send()
        {
            string linkUrl = "";
            switch (Config.WechatConfig.ChuZuWu_F004)
            {
                case "1":  //正式平台

                    linkUrl = string.Format("http://wechat.iotone.cn/alarms/devicealarm.aspx?listid={0}", Reason);
                    ServiceReference1.WxServiceSoap soap = new ServiceReference1.WxServiceSoapClient();
                    ServiceReference1.SendMessageRequestBody body = new ServiceReference1.SendMessageRequestBody("123456",
                     "dY-6Lwh7W2yEw32odCxRF3RCyG9JIKwwNwncehFIONk", Title, Opeinid, Content, DeviceTime.ToString("yyyy-MM-dd HH:mm:ss"), "",
                     linkUrl);
                    ServiceReference1.SendMessageRequest request = new ServiceReference1.SendMessageRequest(body);
                    return soap.SendMessage(request).Body.SendMessageResult;

                case "2":  //亲情宝

                    linkUrl = string.Format("http://test.iotone.cn/alarms/devicealarm.aspx?listid={0}", Reason);
                    WeiXinService.WxServiceSoap soap2 = new WeiXinService.WxServiceSoapClient();
                    WeiXinService.SendMessageRequestBody body2 = new WeiXinService.SendMessageRequestBody("123456",
                        "Fed1LXg8b6VdZf6gsJCodDI9588zNK377xtxVBOsVnA", Title, Opeinid, Content, DeviceTime.ToString("yyyy-MM-dd HH:mm:ss"), "",
                        linkUrl);
                    WeiXinService.SendMessageRequest request2 = new WeiXinService.SendMessageRequest(body2);
                    return soap2.SendMessage(request2).Body.SendMessageResult;

                case "3":  //老平台

                    linkUrl = string.Format("http://wechat.test.iotone.cn/alarms/devicealarm.aspx?listid={0}", Reason);
                    ServiceReference2.WxServiceSoap soap3 = new ServiceReference2.WxServiceSoapClient();
                    ServiceReference2.SendMessageRequestBody body3 = new ServiceReference2.SendMessageRequestBody("123456",
                        "zhyayybUMNuRkLTOcXnGc3SWA2f2zsvCCsNjxp4QPXc", Title, Opeinid, Content, DeviceTime.ToString("yyyy-MM-dd HH:mm:ss"), "",
                        linkUrl);
                    ServiceReference2.SendMessageRequest request3 = new ServiceReference2.SendMessageRequest(body3);
                    return soap3.SendMessage(request3).Body.SendMessageResult;

                case "4":   //郑州

                    //  linkUrl = string.Format("http://wechat.zhengzhou.iotone.cn/WxService.asmx?listid={0}", reason);
                    linkUrl = string.Format("http://wechat.zhengzhou.iotone.cn/alarms/devicealarm.aspx?listid={0}", Reason);
                    ServiceReference3.WxServiceSoap soap4 = new ServiceReference3.WxServiceSoapClient();
                    ServiceReference3.SendMessageRequestBody body4 = new ServiceReference3.SendMessageRequestBody("123456",
                        "mB-dz5IcTitzOgY-Cz-yY2cxp1UQyBmkdROhHAOJ4EA", Title, Opeinid, Content, DeviceTime.ToString("yyyy-MM-dd HH:mm:ss"), "",
                        linkUrl);
                    ServiceReference3.SendMessageRequest request4 = new ServiceReference3.SendMessageRequest(body4);
                    return soap4.SendMessage(request4).Body.SendMessageResult;

                default:
                    return "微信类型配置错误.";

            }
        }

    }
}
