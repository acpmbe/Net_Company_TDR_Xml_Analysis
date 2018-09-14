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
    public class Pro_ShipDevice_Sail_Dal
    {
        public static void Exec(Pro_ShipDevice_Sail_Mod info, out UInt16 resultNum, out string reason)
        {


            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_SHIPDEVICE_SAIL");
            db.AddInParameter(cmd, ":pi_devid", DbType.String, info.Pi_DevId);
            db.AddInParameter(cmd, ":pi_devtime", DbType.Date, info.Pi_DevTime);
            db.AddInParameter(cmd, ":pi_lng", DbType.String,info.Pi_Lng);
            db.AddInParameter(cmd, ":pi_lat", DbType.String, info.Pi_Lat);
            db.AddInParameter(cmd, ":pi_azimuth", DbType.String, info.Pi_Azimuth);
            db.AddInParameter(cmd, ":pi_speed", DbType.String,info.Pi_Speed);
            db.AddInParameter(cmd, ":pi_starnum", DbType.String,info.Pi_StarNum);
            db.AddInParameter(cmd, ":pi_temperswitch", DbType.String, info.Pi_Temperswitch);
            db.AddOutParameter(cmd, ":po_ret", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_content", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
     
            string Result = db.GetParameterValue(cmd, ":po_ret").ToString();
            if (string.IsNullOrEmpty(Result))
            {
                resultNum = 1;
            }
            else
            {
                resultNum = Convert.ToUInt16(Result);
            }
            reason = db.GetParameterValue(cmd, ":po_content").ToString();

        }
    }
}
