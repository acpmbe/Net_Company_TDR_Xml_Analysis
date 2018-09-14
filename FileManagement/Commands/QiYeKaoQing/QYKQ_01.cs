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
    public class QYKQ_01 : ICommand
    {

        private string QYCode;
        private string Content;
        private DateTime Time;

        public QYKQ_01(string _QYCode, string _content, DateTime _time)
        {
            this.QYCode = _QYCode;
            this.Content = _content;
            this.Time = _time;
        }

        private string Name
        {
            get { return "企业考勤_发卡"; }
        }
        public bool Execute()
        {
            try
            {
                if (!QYCode.StartsWith("KQ"))
                {
                    MyLibrary.Log.Debug(Name + "文件名称没有标识符'KQ'；企业号码：" + QYCode);
                    return true;
                }

                QYKQ_01_Info AddInfo =  MyLibrary.Json.DeserializeObject(Content, typeof(QYKQ_01_Info)) as QYKQ_01_Info;                         
                QykqInfo info = new QykqInfo();
                info.pi_CmdId = "01";
                info.pi_EnterpriseID = AddInfo.QYCODE;
                info.pi_StaffName = AddInfo.NAME;
                info.pi_IdentityCardNo = AddInfo.IDENTITYNO.ToUpper();
                info.pi_RegistrationTime = Time;
                info.pi_Dataintegrity = string.IsNullOrWhiteSpace(info.pi_IdentityCardNo) ? "1" : "0";
                info.pi_UploadType = AddInfo.UploadType;
                info.pi_ResidenceAddress = AddInfo.RESIDENCEADDRESS;
                info.pi_ResidenceCode = AddInfo.RESIDENCECODE;

                UInt16 ResultNum;
                string Reason;
                QYKQDal.Insert_Pro(info, out ResultNum, out Reason);
                if (ResultNum == 1)
                {
                    MyLibrary.Log.Debug(Name + "出错；" + Reason + " 企业号码：" + QYCode + " 员工姓名：" + info.pi_StaffName + " 身份证号：" + info.pi_IdentityCardNo);
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
