using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Pro_InDatabase_NFC_Bll
    {

        private Pro_InDatabase_NFC_Mod Info;
        public Pro_InDatabase_NFC_Bll(Pro_InDatabase_NFC_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {

            Pro_InDatabase_NFC_Dal.OutMod OutInfo = Pro_InDatabase_NFC_Dal.Exec(Info);
            if (OutInfo.resultnum == 0)
            {
                return "0";
            }
            else
            {
                return OutInfo.reason;
            }
        }
    }
}
