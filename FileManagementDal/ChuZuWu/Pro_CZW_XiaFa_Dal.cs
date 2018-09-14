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
    public class Pro_CZW_XiaFa_Dal
    {

  
        public static void Exec(Pro_CZW_XiaFa_Mod info, out int resultnum, out string reason)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("Pro_CZW_XiaFa");
            db.AddInParameter(cmd, ":pi_Protocol", DbType.String, info.pi_Protocol);
            db.AddInParameter(cmd, ":pi_Guid", DbType.String, info.pi_Guid);
            db.AddInParameter(cmd, ":pi_CmdId", DbType.String, info.pi_CmdId);
            db.AddInParameter(cmd, ":pi_Result", DbType.String, info.pi_Result);
            db.AddOutParameter(cmd, ":po_ResultNum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_Reason", DbType.String, 512);
            db.ExecuteNonQuery(cmd);
            resultnum = Convert.ToInt16(db.GetParameterValue(cmd, ":po_ResultNum").ToString());
            reason = db.GetParameterValue(cmd, ":po_Reason").ToString();
            if (reason == null)
            {
                reason = "";
            }

        }
    }
}
