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
    public class Pro_UploadAlarm_Dal
    {

        public static void Exec(Pro_UploadAlarm_Mod info, out int resultNo, out string reason, out string wechatId, out string alarmcontent)
        {


            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_Uploadalarm");
            db.AddInParameter(cmd, ":pi_protocoltype", DbType.String, info.pi_protocoltype);
            db.AddInParameter(cmd, ":pi_stationno", DbType.String, info.pi_stationno);
            db.AddInParameter(cmd, ":pi_roomnum", DbType.String, info.pi_roomnum);
            db.AddInParameter(cmd, ":pi_alarmtype", DbType.String, info.pi_alarmtype);
            db.AddInParameter(cmd, ":pi_devicetime", DbType.Date, info.pi_devicetime);
            db.AddInParameter(cmd, ":pi_servicetime", DbType.Date, info.pi_servicetime);
            db.AddOutParameter(cmd, ":po_wechatid", DbType.String, 8192);
            db.AddOutParameter(cmd, ":po_alarmcontent", DbType.String, 512);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 512);
            db.ExecuteNonQuery(cmd);
            string po_status = db.GetParameterValue(cmd, ":po_resultnum").ToString();
            if (po_status != null && po_status != "")
            {
                resultNo = Convert.ToUInt16(po_status);
            }
            else
            {
                resultNo = 0;
            }

            reason = db.GetParameterValue(cmd, ":po_reason").ToString();
            wechatId = db.GetParameterValue(cmd, ":po_wechatid").ToString().Replace(" ", "");
            alarmcontent = db.GetParameterValue(cmd, ":po_alarmcontent").ToString();

        }
    }
}
