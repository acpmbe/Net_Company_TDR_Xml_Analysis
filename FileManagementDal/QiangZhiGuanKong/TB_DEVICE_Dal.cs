using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementUtil;

namespace FileManagementDal.QiangZhiGuanKong
{
    public class TB_DEVICE_Dal
    {

        public static DataTable GetInfo(string DeviceId)
        {
            Database db = DataConnect.GetConnect_StationInfo;
            string sql = "SELECT * FROM TB_DEVICE WHERE deviceid =:DEVICEID";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, ":DEVICEID", DbType.String, DeviceId);
            DataTable dt = db.ExecuteDataSet(cmd).Tables[0];
            return dt;
        }
    }
}
