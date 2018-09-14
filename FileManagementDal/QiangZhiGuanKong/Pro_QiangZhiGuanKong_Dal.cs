using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementModel.QiangZhiGuanKong;
using FileManagementUtil;



namespace FileManagementDal.QiangZhiGuanKong
{
    public class Pro_QiangZhiGuanKong_Dal
    {

        public static void Insert(Pro_QiangZhiGuanKong_Mod info, out ushort resultNo, out string reason)
        {
        

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("Pro_QiangZhiGuanKong");
            db.AddInParameter(cmd, ":pi_CmdType", DbType.String, info.pi_CmdType);
            db.AddInParameter(cmd, ":pi_ListId", DbType.String, info.pi_ListId);
            db.AddInParameter(cmd, ":pi_DeviceTime", DbType.Date, info.pi_DeviceTime);
            db.AddInParameter(cmd, ":pi_DeviceCode", DbType.String, info.pi_DeviceCode);
            db.AddInParameter(cmd, ":pi_StationAddress", DbType.String, info.pi_StationAddress);
            db.AddInParameter(cmd, ":pi_StationLng", DbType.String, info.pi_StationLng);
            db.AddInParameter(cmd, ":pi_StationLat", DbType.String, info.pi_StationLat);
            db.AddInParameter(cmd, ":pi_param1", DbType.String, info.pi_param1);
            db.AddInParameter(cmd, ":pi_param2", DbType.String, info.pi_param2);
            db.AddInParameter(cmd, ":pi_param3", DbType.String, info.pi_param3);
            db.AddInParameter(cmd, ":pi_param4", DbType.String, info.pi_param4);
            db.AddInParameter(cmd, ":pi_param5", DbType.String, info.pi_param5);
            db.AddInParameter(cmd, ":pi_param6", DbType.String, info.pi_param6);
            db.AddInParameter(cmd, ":pi_param7", DbType.String, info.pi_param7);
            db.AddInParameter(cmd, ":pi_param8", DbType.String, info.pi_param8);
            db.AddInParameter(cmd, ":pi_param9", DbType.String, info.pi_param9);
            db.AddInParameter(cmd, ":pi_param10", DbType.String, info.pi_param10);
            db.AddInParameter(cmd, ":pi_StationNo", DbType.String, info.pi_StationNo);
            db.AddInParameter(cmd, ":pi_ServiceTime", DbType.Date, info.pi_ServiceTime);
            db.AddInParameter(cmd, ":pi_InTime", DbType.Date, info.pi_InTime);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNo = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_resultnum"));
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();

        }
    }
}
