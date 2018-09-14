﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Pro_IndateBase_MJNew_Bll
    {
        private Pro_IndateBase_MJNew_Mod Info;

        public Pro_IndateBase_MJNew_Bll(Pro_IndateBase_MJNew_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {
            int resultnum;
            string reason;
            Pro_IndateBase_MJNew_Dal.Exec(Info, out resultnum, out reason);
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
