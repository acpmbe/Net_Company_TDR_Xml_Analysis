using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal.QiYeKaoQing;
using FileManagementUtil;
using FileManagementModel.QiYeKaoQing;

namespace FileManagement.Commands.QiYeKaoQing
{
    public class QYKQ_03 : ICommand
    {

        private string QYCode;
        private string Content;
        private DateTime Time;

        public QYKQ_03(string _QYCode, string _content, DateTime _time)
        {
            this.QYCode = _QYCode;
            this.Content = _content;
            this.Time = _time;
        }
        private string Name
        {
            get { return "企业考勤_销卡"; }
        }
        public bool Execute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Content))
                {
                    MyLibrary.Log.Debug(Name + "内容为空；企业号码：" + QYCode + " 时间：" + Time);
                    return true;
                }
                if (!QYCode.StartsWith("KQ"))
                {
                    MyLibrary.Log.Debug(Name + "文件名称没有标识符'KQ'；企业号码：" + QYCode);
                    return true;
                }

                QYKQ_03_Info DelInfo = MyLibrary.Json.DeserializeObject(Content, typeof(QYKQ_03_Info)) as QYKQ_03_Info;
    
                QykqInfo info = new QykqInfo();
                info.pi_CmdId = "03";
                info.pi_EnterpriseID = DelInfo.QYCODE;
                info.pi_IdentityCardNo = DelInfo.IDENTITYNO.ToUpper();

                UInt16 ResultNum;
                string Reason;
                QYKQDal.Insert_Pro(info, out ResultNum, out Reason);
                if (ResultNum == 1)
                {
                    MyLibrary.Log.Debug(Name + "出错；" + Reason + " 企业号码：" + QYCode + " 内容：" + Content + " 时间：" + Time);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message);

            }
            return true;
        }
    }
}
