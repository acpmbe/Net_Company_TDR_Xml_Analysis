using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using FileManagementUtil;


namespace FileManagementDal.MenJinShouQuan
{
    public class MenJinShouQuanDal
    {

     
        public static void Insert(string SheBeiId, string sqkNumberInt,int DelInfo,out int result,out string ResultInfo)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_delmjmen");
            db.AddInParameter(cmd, ":pi_mjdeviceid", DbType.String, SheBeiId);
            db.AddInParameter(cmd, ":pi_cardid", DbType.String, sqkNumberInt);
            db.AddInParameter(cmd, ":pi_issuccess", DbType.String, DelInfo);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.Int32, 256);
            db.AddOutParameter(cmd, ":po_result", DbType.String, 256);         
            db.ExecuteNonQuery(cmd);
            var resultNum = db.GetParameterValue(cmd, ":po_resultnum");
            if (resultNum != null && resultNum.ToString() != "")
            {
                result = Convert.ToInt16(resultNum);
            }
            else
            {
                result = 0;
            }
            ResultInfo = db.GetParameterValue(cmd, ":po_result").ToString();

        
        }


    }
}
