using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin2;
using FileManagementUtil;
using MyLibrary;

namespace FileManagementDal.MenJin2
{
    public class IMj2Dal
    {


        public static void Insert(string Name, string OriginalCode, MenJinInfo info)
        {

            UInt16 resultNum;
            string reason;
            Mj2Dal.Insert(info, out resultNum, out reason);
            if (resultNum == 1)
            {
                MyLibrary.Log.Debug(Name + "出错；" + reason + " 原始代码：" + OriginalCode);
            }
        }

        public static string Insert(MenJinInfo info)
        {
            UInt16 resultnum;
            string reason;
            Mj2Dal.Insert(info, out resultnum, out reason);
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
