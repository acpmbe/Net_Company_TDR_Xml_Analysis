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
    public class QYKQ_04 : ICommand
    {

        private string QYCode;
        private string Content;
        private DateTime Time;

        public QYKQ_04(string qYCode, string content, DateTime time)
        {
            this.QYCode = qYCode;
            this.Content = content;
            this.Time = time;

        }
    
        private readonly string Name = "企业考勤_全部发卡";
        public bool Execute()
        {
            try
            {
                if (!QYCode.StartsWith("KQ"))
                {
                    MyLibrary.Log.Debug(Name + "_文件名称没有标识符'KQ'；企业号码：" + QYCode);
                    return true;
                }

                EnterpriseInfo NewUserList = MyLibrary.Json.DeserializeObject(Content, typeof(EnterpriseInfo)) as EnterpriseInfo;

                QYKQ_04_Dal q = new QYKQ_04_Dal(Name,NewUserList, Time);
                string Result = q.Handle();
                if (Result != "0")
                {
                    MyLibrary.Log.Error(Name + "错误；" + Result + " 企业号码：" + QYCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误；" + ex.Message + " 企业号码：" + QYCode);

            }
            return true;


        


        }



    }
}
