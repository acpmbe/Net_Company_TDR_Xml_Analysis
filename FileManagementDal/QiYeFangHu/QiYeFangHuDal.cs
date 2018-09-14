using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementUtil;

namespace FileManagementDal.QiYeFangHu
{
    public class QiYeFangHuDal
    {

        public static void Insert_XinTiao(string vDeviceType, string vDeviceid, string vParam1, string vParam2, string vDeviceTime, string vAlarmState)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_insertdevicedata");
            db.AddInParameter(cmd, ":vDeviceType", DbType.String, vDeviceType);
            db.AddInParameter(cmd, ":vDeviceid", DbType.String, vDeviceid);
            db.AddInParameter(cmd, ":vParam1", DbType.String, vParam1);
            db.AddInParameter(cmd, ":vParam2", DbType.String, vParam2);
            db.AddInParameter(cmd, ":vDeviceTime", DbType.String, vDeviceTime);
            db.AddInParameter(cmd, ":vAlarmState", DbType.String, vAlarmState);
            db.AddOutParameter(cmd, ":OUT_Param", DbType.String, 256);    
            db.ExecuteNonQuery(cmd);


        }
     
        public static string update_XinTiao(string devid,DateTime time)
        {

            int IsOk = select_IsXinTiao(devid);
            if(IsOk==1)
            {
                Database db = DataConnect.GetConnect;
                DbCommand cmd = db.GetSqlStringCommand("update TB_GATEWAY set lastupdatetime=:lastupdatetime where gatewayid=:gatewayid");
                db.AddInParameter(cmd, ":lastupdatetime", DbType.Date, time);    
                db.AddInParameter(cmd, ":gatewayid", DbType.String, devid);                 
                db.ExecuteNonQuery(cmd);
                return "1";
            }
            else
            {
                return "0";
            }
         
        }

        static int select_IsXinTiao(string devid)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand("select gatewayid from TB_GATEWAY where gatewayid=:gatewayid");
            db.AddInParameter(cmd, ":gatewayid", DbType.String, devid);
            var result = db.ExecuteDataSet(cmd);
            if (result.Tables[0].Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }





    }
}
