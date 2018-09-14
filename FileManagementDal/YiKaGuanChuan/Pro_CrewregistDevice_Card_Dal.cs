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
    public class Pro_CrewregistDevice_Card_Dal
    {

        public static void Exec(Pro_CrewregistDevice_Card_Mod info, out UInt16 resultNum, out string reason)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_CREWREGISTDEVICE_CARD");
            db.AddInParameter(cmd, ":pi_devid", DbType.String, info.Pi_DevId);
            db.AddInParameter(cmd, ":pi_devtime", DbType.Date, info.Pi_DevTime);
            db.AddInParameter(cmd, ":pi_identity", DbType.String, info.Pi_Identity);
            db.AddInParameter(cmd, ":pi_cardid", DbType.String, info.Pi_CardId);
            db.AddInParameter(cmd, ":pi_name", DbType.String, info.Pi_Name);
            db.AddInParameter(cmd, ":pi_sex", DbType.String, info.Pi_Sex);
            db.AddInParameter(cmd, ":pi_nation", DbType.String, info.Pi_Nation);
            db.AddInParameter(cmd, ":pi_birthday", DbType.Date, info.Pi_Birthday);
            db.AddInParameter(cmd, ":pi_address", DbType.String, info.Pi_Address);
            db.AddInParameter(cmd, ":pi_signunit", DbType.String, info.Pi_SignUnit);
            db.AddInParameter(cmd, ":pi_starttime", DbType.Date, info.Pi_StartTime);
            db.AddInParameter(cmd, ":pi_endtime", DbType.Date, info.Pi_EndTime);
            db.AddOutParameter(cmd, ":po_ret", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_content", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_ret"));
            reason = db.GetParameterValue(cmd, ":po_content").ToString();

        }
    }
}
