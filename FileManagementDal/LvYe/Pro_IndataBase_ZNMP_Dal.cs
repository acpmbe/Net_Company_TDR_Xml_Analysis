using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.LvYe;
using FileManagementUtil;

namespace FileManagementDal.LvYe
{
    public class Pro_IndataBase_ZNMP_Dal
    {

        public static void Exec(Pro_IndataBase_ZNMP_Mod info, out int resultnum, out string reason, out int status, out string message)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_INDATABASE_ZNMP");
            db.AddInParameter(cmd, ":PI_DEVID", DbType.String, info.PI_DEVID);
            db.AddInParameter(cmd, ":PI_DEVICETYPE", DbType.String, info.PI_DEVICETYPE);
            db.AddInParameter(cmd, ":PI_PROTOCOLTYPE", DbType.String, info.PI_PROTOCOLTYPE);
            db.AddInParameter(cmd, ":PI_STATIONNO", DbType.String, info.PI_STATIONNO);
            db.AddInParameter(cmd, ":PI_RELAYNO", DbType.String, info.PI_RELAYNO);    
            db.AddInParameter(cmd, ":PI_DEVICETIME", DbType.Date, info.PI_DEVICETIME);
            db.AddInParameter(cmd, ":PI_SERVICETIME", DbType.Date, info.PI_SERVICETIME);
            db.AddInParameter(cmd, ":PI_VERSION", DbType.String, info.PI_VERSION);
            db.AddInParameter(cmd, ":PI_PARAM1", DbType.String, info.PI_PARAM1);
            db.AddInParameter(cmd, ":PI_PARAM2", DbType.String, info.PI_PARAM2);
            db.AddInParameter(cmd, ":PI_PARAM3", DbType.String, info.PI_PARAM3);
            db.AddInParameter(cmd, ":PI_PARAM4", DbType.String, info.PI_PARAM4);
            db.AddInParameter(cmd, ":PI_PARAM5", DbType.String, info.PI_PARAM5);
            db.AddInParameter(cmd, ":PI_PARAM6", DbType.String, info.PI_PARAM6);
            db.AddInParameter(cmd, ":PI_PARAM7", DbType.String, info.PI_PARAM7);
            db.AddInParameter(cmd, ":PI_PARAM8", DbType.String, info.PI_PARAM8);
            db.AddInParameter(cmd, ":PI_PARAM9", DbType.String, info.PI_PARAM9);
            db.AddInParameter(cmd, ":PI_PARAM10", DbType.String, info.PI_PARAM10);
            db.AddInParameter(cmd, ":PI_PARAM11", DbType.String, info.PI_PARAM11);
            db.AddInParameter(cmd, ":PI_PARAM12", DbType.String, info.PI_PARAM12);
            db.AddInParameter(cmd, ":PI_PARAM13", DbType.String, info.PI_PARAM13);
            db.AddInParameter(cmd, ":PI_PARAM14", DbType.String, info.PI_PARAM14);
            db.AddInParameter(cmd, ":PI_PARAM15", DbType.String, info.PI_PARAM15);
            db.AddInParameter(cmd, ":PI_PARAM16", DbType.String, info.PI_PARAM16);
            db.AddInParameter(cmd, ":PI_PARAM17", DbType.String, info.PI_PARAM17);
            db.AddInParameter(cmd, ":PI_PARAM18", DbType.String, info.PI_PARAM18);
            db.AddInParameter(cmd, ":PI_PARAM19", DbType.String, info.PI_PARAM19);
            db.AddInParameter(cmd, ":PI_PARAM20", DbType.String, info.PI_PARAM20);
            db.AddOutParameter(cmd, ":PO_RESULTNUM", DbType.String, 256);
            db.AddOutParameter(cmd, ":PO_REASON", DbType.String, 512);
            db.AddOutParameter(cmd, ":PO_STATUS", DbType.String, 256);
            db.AddOutParameter(cmd, ":PO_MESSAGE", DbType.String, 512);
            db.ExecuteNonQuery(cmd);

            var ResultNum = db.GetParameterValue(cmd, ":PO_RESULTNUM");
            if (ResultNum != null && ResultNum.ToString() != "")
            {
                resultnum = Convert.ToInt16(ResultNum);
            }
            else
            {
                resultnum = 0;
            }
            reason = db.GetParameterValue(cmd, ":PO_REASON").ToString();

            var poStatus = db.GetParameterValue(cmd, ":PO_STATUS").ToString();
            if (poStatus != null && poStatus.ToString() != "")
            {
                status = Convert.ToInt16(poStatus);
            }
            else
            {
                status = 0;
            }

            message = db.GetParameterValue(cmd, ":PO_MESSAGE").ToString();


        }
    }
}
