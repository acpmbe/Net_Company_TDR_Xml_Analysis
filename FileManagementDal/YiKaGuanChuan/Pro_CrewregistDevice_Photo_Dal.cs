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
    public class Pro_CrewregistDevice_Photo_Dal
    {

        public static void Exec(Pro_CrewregistDevice_Photo_Mod info, out UInt16 resultNum, out string reason)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_CREWREGISTDEVICE_PHOTO");
            db.AddInParameter(cmd, ":pi_devid", DbType.String, info.Pi_DevId);
            db.AddInParameter(cmd, ":pi_devtime", DbType.Date, info.Pi_DevTime);
            db.AddInParameter(cmd, ":pi_index", DbType.String, info.Pi_Index);
            db.AddInParameter(cmd, ":pi_photo", DbType.Binary, info.Pi_Photo);
            db.AddOutParameter(cmd, ":po_ret", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_content", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_ret"));
            reason = db.GetParameterValue(cmd, ":po_content").ToString();

        }
    }
}
