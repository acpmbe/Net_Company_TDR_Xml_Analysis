using System;
using FileManagementDal.QiYeKaoQing;
using FileManagementUtil;
using FileManagementModel.QiYeKaoQing;

namespace FileManagement.Commands.QiYeKaoQing
{
    public class QYKQ_02 : ICommand
    {

        private string QYCode;
        private string Content;
        private DateTime Time;

        public QYKQ_02(string _QYCode, string _content, DateTime _time)
        {
            this.QYCode = _QYCode;
            this.Content = _content;
            this.Time = _time;
        }
        private string Name
        {
            get { return "企业考勤_刷卡"; }
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

           
                QYKQ_02_Info CardInfo = MyLibrary.Json.DeserializeObject(Content, typeof(QYKQ_02_Info)) as QYKQ_02_Info;
       
                QykqInfo info = new QykqInfo();
                info.pi_CmdId = "02";
                info.pi_EnterpriseID = CardInfo.QYCODE;
                info.pi_RecordTime = Time;
                info.pi_RecordType = CardInfo.OPERATETYPE;
                info.pi_IdentityCardNo = CardInfo.IDENTITYNO.ToUpper();
                info.pi_DeviceTime = CardInfo.OPERATETIME;
                info.pi_StaffName ="";
                info.pi_UploadType = CardInfo.UploadType;
                info.pi_Upload = CardInfo.Upload;

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
