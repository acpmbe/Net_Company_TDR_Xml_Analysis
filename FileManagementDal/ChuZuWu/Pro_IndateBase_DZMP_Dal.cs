using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;

namespace FileManagementDal.ChuZuWu
{
    public class Pro_IndateBase_DZMP_Dal
    {

        public static void Exec(Pro_IndateBase_DZMP_Mod info, out int resultnum, out string reason)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_indatebase_dzmp");
            db.AddInParameter(cmd, ":pi_bigtype", DbType.String, info.pi_bigtype);
            db.AddInParameter(cmd, ":pi_devicetime", DbType.Date, info.pi_devicetime);
            db.AddInParameter(cmd, ":pi_devicecode", DbType.String, info.pi_devicecode);
            db.AddInParameter(cmd, ":pi_devicetype", DbType.String, info.pi_devicetype);
            db.AddInParameter(cmd, ":pi_protocoltype", DbType.String, info.pi_protocoltype);
            db.AddInParameter(cmd, ":pi_roomno", DbType.String, info.pi_roomno);
            db.AddInParameter(cmd, ":pi_cardtype", DbType.String, info.pi_cardtype);
            db.AddInParameter(cmd, ":pi_cardid", DbType.String, info.pi_cardid);
            db.AddInParameter(cmd, ":pi_identitycardid", DbType.String, info.pi_identitycardid);
            db.AddInParameter(cmd, ":pi_lordidentitycardid", DbType.String, info.pi_lordidentitycardid);
            db.AddInParameter(cmd, ":pi_activecardid", DbType.String, info.pi_activecardid);
            db.AddInParameter(cmd, ":pi_status", DbType.String, info.pi_status);
            db.AddInParameter(cmd, ":pi_stationno", DbType.String, info.pi_stationno);
            db.AddInParameter(cmd, ":pi_version", DbType.String, info.pi_version);
            db.AddInParameter(cmd, ":pi_servicetime", DbType.Date, info.pi_servicetime);
            db.AddInParameter(cmd, ":pi_param1", DbType.String, info.pi_param1);
            db.AddInParameter(cmd, ":pi_param2", DbType.String, info.pi_param2);
            db.AddInParameter(cmd, ":pi_param3", DbType.String, info.pi_param3);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 512);
            db.ExecuteNonQuery(cmd);

            var resultNum = db.GetParameterValue(cmd, ":po_resultnum");
            if (resultNum != null && resultNum.ToString() != "")
            {
                resultnum = Convert.ToInt16(resultNum);
            }
            else
            {
                resultnum = 0;
            }
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();



        }
    }
}
