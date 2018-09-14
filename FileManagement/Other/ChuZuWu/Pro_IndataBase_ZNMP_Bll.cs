using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Pro_IndataBase_ZNMP_Bll
    {

        private Pro_IndataBase_ZNMP_Mod Info;
        public Pro_IndataBase_ZNMP_Bll(Pro_IndataBase_ZNMP_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {
            int resultnum;
            string reason;
            int status;
            string message;
            Pro_IndataBase_ZNMP_Dal.Exec(Info, out resultnum, out reason, out status, out message);
            if (resultnum == 0)
            {
                return "0";
            }
            else
            {
                return reason;
            }
        }

    }
}
