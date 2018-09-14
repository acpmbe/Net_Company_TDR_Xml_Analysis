using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileManagementUtil.XmlConfig;


namespace FileManagementUtil
{
    public class Config
    {
      


     

      



        public readonly static string Path = @"Config\Config.xml";
        public readonly static string FileType = ConfigurationManager.AppSettings["FileType"];
        public readonly static string ThreadType = ConfigurationManager.AppSettings["ThreadType"];
        public readonly static int MaxDegreeOfParallelism = Convert.ToInt16(ConfigurationManager.AppSettings["MaxDegreeOfParallelism"]);
        public readonly static string XmlFilesPath = ConfigurationManager.AppSettings["XmlFilesPath"].ToString();
        public readonly static string NewXmlFilesPath = ConfigurationManager.AppSettings["NewXmlFilesPath"].ToString();
        public readonly static string ErrorXmlFilesPath = ConfigurationManager.AppSettings["ErrorXmlFilesPath"].ToString();
        public readonly static string SearchPattern = ConfigurationManager.AppSettings["SearchPattern"].ToString();

        public readonly static string CmdIdType = ConfigurationManager.AppSettings["CmdIdType"].ToString();

        public readonly static string InvalidPath = ConfigurationManager.AppSettings["InvalidPath"].ToString();




        public readonly static BPush_Config.BPush_Config_Mod BPushConfig = BPush_Config.GetConfig(Path, "百度云推送");
        public readonly static Sms_Config.Sms_Config_Mod SmsConfig = Sms_Config.GetConfig(Path, "短信");
        public readonly static JPush_Config.JPushConfig_Mod JPushConfig = JPush_Config.GetConfig(Path, "极光推送");
        public readonly static RedoData_Config.RedoData_Config_Mod RedoDataConfig = RedoData_Config.GetConfig(Path, "过滤重复数据");
        public readonly static Wechat_Config.Wechat_Config_Mod WechatConfig = Wechat_Config.GetConfig(Path, "微信");



    }
}
