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
    public class Pro_IndateBase_Sec_Dal
    {
    
        /// <summary>
        /// 执行过程。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="resultNo"></param>
        /// <param name="reason"></param>
        /// <param name="status"></param>
        /// <param name="wechatId"></param>
        /// <param name="alarmcontent"></param>
        public static void Exec(Pro_IndateBase_Sec_Mod info, out int resultNo, out string reason, out int status, out string wechatId, out string alarmcontent)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_indatebase_sec");
            db.AddInParameter(cmd, ":pi_bigtype", DbType.String, info.pi_bigtype);
            db.AddInParameter(cmd, ":pi_devicetime", DbType.Date, info.pi_devicetime);
            db.AddInParameter(cmd, ":pi_devicetype", DbType.String, info.pi_devicetype);
            db.AddInParameter(cmd, ":pi_devicecode", DbType.String, info.pi_devicecode);
            db.AddInParameter(cmd, ":pi_protocoltype", DbType.String, info.pi_protocoltype);
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
            db.AddInParameter(cmd, ":pi_stationno", DbType.String, info.pi_stationno);
            db.AddInParameter(cmd, ":pi_version", DbType.String, info.pi_version);
            db.AddInParameter(cmd, ":pi_relayno", DbType.String, info.pi_relayno);
            db.AddInParameter(cmd, ":pi_servicetime", DbType.Date, info.pi_servicetime);


            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 512);
            db.AddOutParameter(cmd, ":po_status", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_wechatid", DbType.String, 8192);
            db.AddOutParameter(cmd, ":po_alarmcontent", DbType.String, 512);
            db.ExecuteNonQuery(cmd);
            string resultNum = db.GetParameterValue(cmd, ":po_resultnum").ToString();
            if (resultNum != null && resultNum != "")
            {
                resultNo = Convert.ToInt16(resultNum);
            }
            else
            {
                resultNo = 0;
            }
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();
            string poStatus = db.GetParameterValue(cmd, ":po_status").ToString();
            if (poStatus != null && poStatus.ToString() != "")
            {
                status = Convert.ToInt16(poStatus);
            }
            else
            {
                status = 0;
            }
            wechatId = db.GetParameterValue(cmd, ":po_wechatid").ToString().Replace(" ", "");
            alarmcontent = db.GetParameterValue(cmd, ":po_alarmcontent").ToString();
        }
    }
}
