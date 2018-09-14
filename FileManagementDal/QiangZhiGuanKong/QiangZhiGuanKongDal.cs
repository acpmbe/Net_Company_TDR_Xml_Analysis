using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.QiangZhiGuanKong;
using FileManagementDal.QiangZhiGuanKong;

namespace FileManagementDal.QiangZhiGuanKong
{
    public class QiangZhiGuanKongDal
    {
        public static string Handle(Pro_QiangZhiGuanKong_Mod info)
        {
            ushort resultnum;
            string reason;
            Pro_QiangZhiGuanKong_Dal.Insert(info, out resultnum, out reason);
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
