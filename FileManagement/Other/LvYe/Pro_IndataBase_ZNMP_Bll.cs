using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementDal.LvYe;

namespace FileManagement.Other.LvYe
{
    public class Pro_IndataBase_ZNMP_Bll
    {

        private Pro_IndataBase_ZNMP_Mod Info;
        public Pro_IndataBase_ZNMP_Bll(Pro_IndataBase_ZNMP_Mod info)
        {
            this.Info = info;
        }

        public const string NAME = "Pro_IndataBase_ZNMP过程";
        public string Exec()
        {
            int resultnum;
            string reason;
            int status;
            string message;
            Pro_IndataBase_ZNMP_Dal.Exec(Info, out resultnum, out reason, out status, out message);
            if (resultnum == 0)
            {
                if (status == 1)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        SendInfo_Bll ss = new SendInfo_Bll(message, Info);
                        ss.Send();
                    }
                    else
                    {
                        MyLibrary.Log.Debug(NAME + "调用出错；" + "返回Message字段为空");              
                    }
                }
                return "0";
            }
            else
            {
                return reason;
            }
        }


    }
}
