using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManagementUtil.Push.WeChat
{

    /// <summary>
    /// 微信正式平台
    /// </summary>
    public class Real
    {



        private string Title;
        private string Reason;
        private DateTime DeviceTime;

        public Real(string title, string reason, DateTime deviceTime)
        {
            this.Title = title;
            this.Reason = reason;
            this.DeviceTime = deviceTime;
        }


        /// <summary>
        /// 发送（返回结果：成功:null，出错:信息说明）
        /// </summary>
        /// <param name="opeinid">手机唯一标识符</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public string Send(string opeinid, string content)
        {
            string linkUrl = string.Format("http://wechat.iotone.cn/alarms/devicealarm.aspx?listid={0}", Reason);
            ServiceReference1.WxServiceSoap soap = new ServiceReference1.WxServiceSoapClient();
            ServiceReference1.SendMessageRequestBody body = new ServiceReference1.SendMessageRequestBody("123456",
              "dY-6Lwh7W2yEw32odCxRF3RCyG9JIKwwNwncehFIONk", Title, opeinid, content, DeviceTime.ToString("yyyy-MM-dd HH:mm:ss"), "",
              linkUrl);
            ServiceReference1.SendMessageRequest request = new ServiceReference1.SendMessageRequest(body);
            return soap.SendMessage(request).Body.SendMessageResult;
        }

    }
}
