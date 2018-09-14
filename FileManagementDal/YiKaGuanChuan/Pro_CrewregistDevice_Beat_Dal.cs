using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementModel.YiKaGuanChuan;
using FileManagementUtil;

namespace FileManagementDal.YiKaGuanChuan
{
    public class Pro_CrewregistDevice_Beat_Dal
    {

        public static void Exec(Pro_CrewregistDevice_Beat_Mod info, out UInt16 resultNum, out string reason)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_CREWREGISTDEVICE_BEAT");
            db.AddInParameter(cmd, ":pi_devid", DbType.String, info.Pi_DevId);
            db.AddInParameter(cmd, ":pi_devtime", DbType.Date, info.Pi_DevTime);
            db.AddInParameter(cmd, ":pi_STATETFT", DbType.String, info.Pi_StateTFT);
            db.AddInParameter(cmd, ":pi_STATE433", DbType.String, info.Pi_State433);
            db.AddInParameter(cmd, ":pi_STATEREADER", DbType.String, info.Pi_StateReader);
            db.AddInParameter(cmd, ":pi_STATECARD", DbType.String, info.Pi_StateCard);
            db.AddInParameter(cmd, ":pi_STATEPRINT", DbType.String, info.Pi_StatePrint);
            db.AddInParameter(cmd, ":pi_STATESD", DbType.String, info.Pi_StateSd);
            db.AddOutParameter(cmd, ":po_ret", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_content", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_ret"));
            reason = db.GetParameterValue(cmd, ":po_content").ToString();

        }
    }
}
