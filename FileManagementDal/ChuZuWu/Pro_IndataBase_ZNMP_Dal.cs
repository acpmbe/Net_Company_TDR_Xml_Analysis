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
    public class Pro_IndataBase_ZNMP_Dal
    {

        public static void Exec(Pro_IndataBase_ZNMP_Mod info, out int resultnum, out string reason, out int status, out string message)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_INDATABASE_ZNMP");
            db.AddInParameter(cmd, ":PI_DEVICECODE", DbType.String, info.Pi_DeviceCode);
            db.AddInParameter(cmd, ":PI_DEVICETYPE", DbType.String, info.Pi_DeviceType);
            db.AddInParameter(cmd, ":PI_PROTOCOLTYPE", DbType.String, info.Pi_ProtocolType);
            db.AddInParameter(cmd, ":PI_STATIONNO", DbType.String, info.Pi_StationNo);
            db.AddInParameter(cmd, ":PI_RELAYNO", DbType.String, info.Pi_RelayNo);
            db.AddInParameter(cmd, ":PI_DEVICETIME", DbType.Date, info.Pi_DeviceTime);
            db.AddInParameter(cmd, ":PI_SERVICETIME", DbType.Date, info.Pi_ServiceTime);
            db.AddInParameter(cmd, ":PI_VERSION", DbType.String, info.Pi_Version);
            db.AddInParameter(cmd, ":PI_RSSI", DbType.String, info.Pi_Rssi);
            db.AddInParameter(cmd, ":PI_PARAM1", DbType.String, info.Pi_Param1);
            db.AddInParameter(cmd, ":PI_PARAM2", DbType.String, info.Pi_Param2);
            db.AddInParameter(cmd, ":PI_PARAM3", DbType.String, info.Pi_Param3);
            db.AddInParameter(cmd, ":PI_PARAM4", DbType.String, info.Pi_Param4);
            db.AddInParameter(cmd, ":PI_PARAM5", DbType.String, info.Pi_Param5);
            db.AddInParameter(cmd, ":PI_PARAM6", DbType.String, info.Pi_Param6);
            db.AddInParameter(cmd, ":PI_PARAM7", DbType.String, info.Pi_Param7);
            db.AddInParameter(cmd, ":PI_PARAM8", DbType.String, info.Pi_Param8);
            db.AddInParameter(cmd, ":PI_PARAM9", DbType.String, info.Pi_Param9);
            db.AddInParameter(cmd, ":PI_PARAM10", DbType.String, info.Pi_Param10);
            db.AddInParameter(cmd, ":PI_PARAM11", DbType.String, info.Pi_Param11);
            db.AddInParameter(cmd, ":PI_PARAM12", DbType.String, info.Pi_Param12);
            db.AddInParameter(cmd, ":PI_PARAM13", DbType.String, info.Pi_Param13);
            db.AddInParameter(cmd, ":PI_PARAM14", DbType.String, info.Pi_Param14);
            db.AddInParameter(cmd, ":PI_PARAM15", DbType.String, info.Pi_Param15);
            db.AddInParameter(cmd, ":PI_PARAM16", DbType.String, info.Pi_Param16);
            db.AddInParameter(cmd, ":PI_PARAM17", DbType.String, info.Pi_Param17);
            db.AddInParameter(cmd, ":PI_PARAM18", DbType.String, info.Pi_Param18);
            db.AddInParameter(cmd, ":PI_PARAM19", DbType.String, info.Pi_Param19);
            db.AddInParameter(cmd, ":PI_PARAM20", DbType.String, info.Pi_Param20);
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


            message = db.GetParameterValue(cmd, ":PO_MESSAGE").ToString().Replace(" ", "");





        }
    }
}
