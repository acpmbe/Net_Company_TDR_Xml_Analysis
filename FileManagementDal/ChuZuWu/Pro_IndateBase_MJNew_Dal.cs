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
    public class Pro_IndateBase_MJNew_Dal
    {

        public static void Exec(Pro_IndateBase_MJNew_Mod info, out int resultnum, out string reason)
        {



            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_indatebase_mjnew");
            db.AddInParameter(cmd, ":pi_bigtype", DbType.String, info.pi_bigtype);
            db.AddInParameter(cmd, ":pi_devicetype", DbType.String, info.pi_devicetype);
            db.AddInParameter(cmd, ":pi_protocoltype", DbType.String, info.pi_protocoltype);
            db.AddInParameter(cmd, ":pi_devicecode", DbType.String, info.pi_devicecode);
            db.AddInParameter(cmd, ":pi_newdevicecode", DbType.String, info.pi_newdevicecode);
            db.AddInParameter(cmd, ":pi_devicetime", DbType.Date, info.pi_devicetime);
            db.AddInParameter(cmd, ":pi_cardtype", DbType.String, info.pi_cardtype);
            db.AddInParameter(cmd, ":pi_cardid", DbType.String, info.pi_cardid);
            db.AddInParameter(cmd, ":pi_houseno", DbType.String, info.pi_houseno);
            db.AddInParameter(cmd, ":pi_activecardid", DbType.String, info.pi_activecardid);
            db.AddInParameter(cmd, ":pi_policecard", DbType.String, info.pi_policecard);
            db.AddInParameter(cmd, ":pi_status", DbType.String, info.pi_status);
            db.AddInParameter(cmd, ":pi_stationno", DbType.String, info.pi_stationno);
            db.AddInParameter(cmd, ":pi_relayno", DbType.String, info.pi_relayno);
            db.AddInParameter(cmd, ":pi_version", DbType.String, info.pi_version);
            db.AddInParameter(cmd, ":pi_servicetime", DbType.Date, info.pi_servicetime);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 1024);
            db.ExecuteNonQuery(cmd);
            resultnum = Convert.ToInt16(db.GetParameterValue(cmd, ":po_resultnum").ToString());
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();
            if (reason == null)
            {
                reason = "";
            }

        }
    }
}
