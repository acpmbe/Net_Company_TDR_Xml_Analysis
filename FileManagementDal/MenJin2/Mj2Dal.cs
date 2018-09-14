using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementModel.MenJin2;
using FileManagementUtil;

namespace FileManagementDal.MenJin2
{
    public class Mj2Dal
    {

        public static void Insert(MenJinInfo info, out ushort resultNo, out string reason)
        {



            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_indatebase_mjsec");
            db.AddInParameter(cmd, ":pi_bigtype", DbType.String, info.pi_bigtype);
            db.AddInParameter(cmd, ":pi_devicetime", DbType.Date, info.pi_devicetime);
            db.AddInParameter(cmd, ":pi_devicetype", DbType.String, info.pi_devicetype);
            db.AddInParameter(cmd, ":pi_devicecode", DbType.String, info.pi_devicecode);
            db.AddInParameter(cmd, ":pi_protocoltype", DbType.String, info.pi_protocoltype);
            db.AddInParameter(cmd, ":pi_lordcardtype", DbType.String, info.pi_lordcardtype);
            db.AddInParameter(cmd, ":pi_lordcardid", DbType.String, info.pi_lordcardid);
            db.AddInParameter(cmd, ":pi_lordidentitycard", DbType.String, info.pi_lordidentitycard);
            db.AddInParameter(cmd, ":pi_lordidentitycardid", DbType.String, info.pi_lordidentitycardid);
            db.AddInParameter(cmd, ":pi_cardtype", DbType.String, info.pi_cardtype);
            db.AddInParameter(cmd, ":pi_cardid", DbType.String, info.pi_cardid);
            db.AddInParameter(cmd, ":pi_identitycard", DbType.String, info.pi_identitycard);
            db.AddInParameter(cmd, ":pi_identitycardid", DbType.String, info.pi_identitycardid);
            db.AddInParameter(cmd, ":pi_houseno", DbType.String, info.pi_houseno);
            db.AddInParameter(cmd, ":pi_roomno", DbType.String, info.pi_roomno);
            db.AddInParameter(cmd, ":pi_param1", DbType.String, info.pi_param1);
            db.AddInParameter(cmd, ":pi_param2", DbType.String, info.pi_param2);
            db.AddInParameter(cmd, ":pi_param3", DbType.String, info.pi_param3);
            db.AddInParameter(cmd, ":pi_param4", DbType.String, info.pi_param4);
            db.AddInParameter(cmd, ":pi_param5", DbType.String, info.pi_param5);
            db.AddInParameter(cmd, ":pi_stationno", DbType.String, info.pi_stationno);
            db.AddInParameter(cmd, ":pi_version", DbType.String, info.pi_version);
            db.AddInParameter(cmd, ":pi_relayno", DbType.String, info.pi_relayno);
            db.AddInParameter(cmd, ":pi_servicetime", DbType.Date, info.pi_servicetime);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 256);
            db.ExecuteNonQuery(cmd);

            resultNo = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_resultnum"));
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();

        }
    }
}
