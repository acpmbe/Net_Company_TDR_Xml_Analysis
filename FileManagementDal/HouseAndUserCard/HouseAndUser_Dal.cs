using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.HouseAndUserCard;

namespace FileManagementDal.HouseAndUserCard
{
    public class HouseAndUser_Dal
    {

        public static string Exec(Pro_IndateBase_MjSec_Mod info)
        {
            ushort resultnum;
            string reason;
            Pro_IndateBase_MjSec_Dal.Exec(info, out resultnum, out reason);
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
