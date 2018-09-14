using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.CeXie;
using FileManagementUtil;

namespace FileManagementDal.CeXie
{
    public class CeXieDal
    {



        public static void AgreementFormat_Insert(CeXieInfo info)
        {


            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand(@"insert into tb_agreementformat
            (listid, devicetime, devicetype, deviceid, protocoltype, reserved1, reserved2, reserved3, reserved4, reserved5, version, stationno, servicetime, intime)
            values
            (sys_guid(), :devicetime, :devicetype, :deviceid, :protocoltype, :reserved1, :reserved2, :reserved3, :reserved4, :reserved5, 
            :version, :stationno, :servicetime, sysdate)");
            db.AddInParameter(cmd, ":devicetime", DbType.Date, info.DeviceTime);
            db.AddInParameter(cmd, ":devicetype", DbType.String, info.DeviceType);
            db.AddInParameter(cmd, ":deviceid", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":protocoltype", DbType.String, info.ProtocolType);
            db.AddInParameter(cmd, ":reserved1", DbType.String, info.Reserved1);
            db.AddInParameter(cmd, ":reserved2", DbType.String, info.Reserved2);
            db.AddInParameter(cmd, ":reserved3", DbType.String, info.Reserved3);
            db.AddInParameter(cmd, ":reserved4", DbType.String, info.Reserved4);
            db.AddInParameter(cmd, ":reserved5", DbType.String, info.Reserved5);
            db.AddInParameter(cmd, ":version", DbType.String, info.Version);
            db.AddInParameter(cmd, ":stationno", DbType.String, info.StationNo);
            db.AddInParameter(cmd, ":servicetime", DbType.Date, info.ServiceTime);
            db.ExecuteNonQuery(cmd);

        }

        public static void GetDeviceInfo(CeXieInfo info, out UInt16 resultNum, out string reason)
        {


            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_CeXie");
            db.AddInParameter(cmd, ":Pi_DeviceCode", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":Pi_DeviceTime", DbType.Date, info.DeviceTime);
            db.AddInParameter(cmd, ":Pi_AngleX", DbType.String, info.Reserved1);
            db.AddInParameter(cmd, ":Pi_AngleY", DbType.String, info.Reserved2);
            db.AddOutParameter(cmd, ":po_ResultNum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_Reason", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_ResultNum"));
            reason = db.GetParameterValue(cmd, ":po_Reason").ToString();



        }

        public static List<SendInfo> GetSendList()
        {

        
            List<SendInfo> info = new List<SendInfo>();
            SendInfo send;
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand(@"select NAME,PHONE from TB_PUSHALARMSET");
            DataTable dt = db.ExecuteDataSet(cmd).Tables[0];
            int Count = dt.Rows.Count;
            if (Count == 0)
            {
                return info;
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    send = new SendInfo();
                    send.Name = dt.Rows[i]["NAME"].ToString();
                    send.Phone = dt.Rows[i]["PHONE"].ToString();
                    info.Add(send);
                }
                return info;
            }

        }

        public static void PushAlarmList_Insert(PushAlarmListInfo info)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand(@"insert into tb_pushalarmlist
            (listid, deviceid, devicecode, description, anglex, angley, standardx, standardy, alarmtime, pushtime, name, phone, issuccess)
            values
            (sys_guid(), :deviceid, :devicecode, :description, :anglex, :angley, :standardx, :standardy, :alarmtime, sysdate,:name, :phone, :issuccess)");
            db.AddInParameter(cmd, ":deviceid", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":devicecode", DbType.String, info.DeviceCode);
            db.AddInParameter(cmd, ":description", DbType.String, info.Description);
            db.AddInParameter(cmd, ":anglex", DbType.String, info.AngleX);
            db.AddInParameter(cmd, ":angley", DbType.String, info.AngleY);
            db.AddInParameter(cmd, ":standardx", DbType.String, info.StandardX);
            db.AddInParameter(cmd, ":standardy", DbType.String, info.StandardY);
            db.AddInParameter(cmd, ":alarmtime", DbType.Date, info.AlarmTime);
            db.AddInParameter(cmd, ":name", DbType.String, info.Name);
            db.AddInParameter(cmd, ":phone", DbType.String, info.Phone);
            db.AddInParameter(cmd, ":issuccess", DbType.String, info.Issuccess);
            db.ExecuteNonQuery(cmd);

        }
    }
}
