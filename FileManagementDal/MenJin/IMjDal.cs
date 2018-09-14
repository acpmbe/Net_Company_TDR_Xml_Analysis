using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementUtil;
using FileManagementDal.MenJin;
using FileManagementModel.MenJin;

namespace FileManagementDal.MenJin
{
    public class IMjDal
    {


        public static void Handle(string Name, string OriginalCode, MJInfo info)
        {

            UInt16 ResultNum;
            string Reason;
            MjDal.HandleMenJin(info, out ResultNum, out Reason);
            if (ResultNum == 1)
            {
                MyLibrary.Log.Debug(Name + "出错；" + Reason + " 原始代码：" + OriginalCode);
            }


        }
    }
}
