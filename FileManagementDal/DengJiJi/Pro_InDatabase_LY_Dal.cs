using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.DengJiJi;
using FileManagementUtil;

namespace FileManagementDal.DengJiJi
{
    public class Pro_InDatabase_LY_Dal
    {

        public static OutMod Exec(Pro_InDatabase_LY_Mod info)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_INDATABASE_LY");


            db.AddInParameter(cmd, ":PI_DEVICECODE", DbType.String, info.PI_DEVICECODE);
            db.AddInParameter(cmd, ":PI_DEVICETYPE", DbType.String, info.PI_DEVICETYPE);
            db.AddInParameter(cmd, ":PI_PROTOCOLTYPE", DbType.String, info.PI_PROTOCOLTYPE);
            db.AddInParameter(cmd, ":PI_IDENTITYTYPE", DbType.String, info.PI_IDENTITYTYPE);
            db.AddInParameter(cmd, ":PI_IDENTITYCARD", DbType.String, info.PI_IDENTITYCARD);
            db.AddInParameter(cmd, ":PI_IDENTITYNAME", DbType.String, info.PI_IDENTITYNAME);
            db.AddInParameter(cmd, ":PI_NATION", DbType.String, info.PI_NATION);
            db.AddInParameter(cmd, ":PI_CARDTYPE", DbType.String, info.PI_CARDTYPE);
            db.AddInParameter(cmd, ":PI_CARDID", DbType.String, info.PI_CARDID);    
            db.AddInParameter(cmd, ":PI_OUTTYPE", DbType.String, info.PI_OUTTYPE);
            db.AddInParameter(cmd, ":PI_PROVINCE", DbType.String, info.PI_PROVINCE);
            db.AddInParameter(cmd, ":PI_CITY", DbType.String, info.PI_CITY);
            db.AddInParameter(cmd, ":PI_KINESTATE", DbType.String, info.PI_KINESTATE);
            db.AddInParameter(cmd, ":PI_BLACKTYPE", DbType.String, info.PI_BLACKTYPE);
            db.AddInParameter(cmd, ":PI_ELECTRIC", DbType.String, info.PI_ELECTRIC);
            db.AddInParameter(cmd, ":PI_SOFEVERSION", DbType.String, info.PI_SOFEVERSION);
            db.AddInParameter(cmd, ":PI_HARDVERSION", DbType.String, info.PI_HARDVERSION);
            db.AddInParameter(cmd, ":PI_DEVICETIME", DbType.Date, info.PI_DEVICETIME);
            db.AddInParameter(cmd, ":PI_SERVICETIME", DbType.Date, info.PI_SERVICETIME);
            db.AddOutParameter(cmd, ":PO_RESULTNUM", DbType.String, 256);
            db.AddOutParameter(cmd, ":PO_REASON", DbType.String, 512);
            db.ExecuteNonQuery(cmd);

            OutMod OutInfo = new OutMod();

            var ResultNum = db.GetParameterValue(cmd, ":PO_RESULTNUM");
            if (ResultNum != null && ResultNum.ToString() != "")
            {
                OutInfo.resultnum = Convert.ToInt16(ResultNum);
            }
            else
            {
                OutInfo.resultnum = 0;
            }
            OutInfo.reason = db.GetParameterValue(cmd, ":PO_REASON").ToString();

            return OutInfo;


        }


        public class OutMod
        {
            public int resultnum { get; set; }
            public string reason { get; set; }



        }
    }
}
