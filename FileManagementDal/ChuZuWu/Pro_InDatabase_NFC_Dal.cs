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
    public class Pro_InDatabase_NFC_Dal
    {

        public static OutMod Exec(Pro_InDatabase_NFC_Mod info)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_INDATABASE_NFC");

            db.AddInParameter(cmd, ":PI_DEVICECODE", DbType.String, info.PI_DEVICECODE);
            db.AddInParameter(cmd, ":PI_DEVICETYPE", DbType.String, info.PI_DEVICETYPE);
            db.AddInParameter(cmd, ":PI_PROTOCOLTYPE", DbType.String, info.PI_PROTOCOLTYPE);
            db.AddInParameter(cmd, ":PI_STATIONNO", DbType.String, info.PI_STATIONNO);
            db.AddInParameter(cmd, ":PI_RELAYNO", DbType.String, info.PI_RELAYNO);
            db.AddInParameter(cmd, ":PI_DEVICETIME", DbType.Date, info.PI_DEVICETIME);
            db.AddInParameter(cmd, ":PI_SERVICETIME", DbType.Date, info.PI_SERVICETIME);
            db.AddInParameter(cmd, ":PI_VERSION", DbType.String, info.PI_VERSION);
            db.AddInParameter(cmd, ":PI_RSSI", DbType.String, info.PI_RSSI);
            db.AddInParameter(cmd, ":PI_CARDTYPE", DbType.String, info.PI_CARDTYPE);
            db.AddInParameter(cmd, ":PI_CARDID", DbType.String, info.PI_CARDID);
            db.AddInParameter(cmd, ":PI_OPERATE", DbType.String, info.PI_OPERATE);
            db.AddInParameter(cmd, ":PI_BATTERY", DbType.String, info.PI_BATTERY);

            db.AddOutParameter(cmd, ":PO_RESULTNUM", DbType.String, 256);
            db.AddOutParameter(cmd, ":PO_REASON", DbType.String, 512);
            db.AddOutParameter(cmd, ":PO_STATUS", DbType.String, 256);
            db.AddOutParameter(cmd, ":PO_MESSAGE", DbType.String, 512);
            db.ExecuteNonQuery(cmd);

            OutMod OutInfo = new OutMod();

            var ResultNum = db.GetParameterValue(cmd, ":PO_RESULTNUM");
            if (ResultNum != null && ResultNum.ToString() != "")
            {
                OutInfo.resultnum = Convert.ToInt16(ResultNum);
            }
            else
            {
                OutInfo.resultnum = 0;
            }
            OutInfo.reason = db.GetParameterValue(cmd, ":PO_REASON").ToString();

            var poStatus = db.GetParameterValue(cmd, ":PO_STATUS").ToString();
            if (poStatus != null && poStatus.ToString() != "")
            {
                OutInfo.status = Convert.ToInt16(poStatus);
            }
            else
            {
                OutInfo.status = 0;
            }

            OutInfo.message = db.GetParameterValue(cmd, ":PO_MESSAGE").ToString().Replace(" ", "");

            return OutInfo;


        }


        public class OutMod
        {
            public int resultnum { get; set; }
            public string reason { get; set; }
            public int status { get; set; }
            public string message { get; set; }


        }
    }
}
