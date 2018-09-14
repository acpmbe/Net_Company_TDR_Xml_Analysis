using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal.DengJiJi;
using FileManagementModel.DengJiJi;


namespace FileManagement.Other.DengJiJi
{
 public   class Pro_InDatabase_LY_Bll
    {

        private Pro_InDatabase_LY_Mod Info;
        public Pro_InDatabase_LY_Bll(Pro_InDatabase_LY_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {

            Pro_InDatabase_LY_Dal.OutMod OutInfo = Pro_InDatabase_LY_Dal.Exec(Info);
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
