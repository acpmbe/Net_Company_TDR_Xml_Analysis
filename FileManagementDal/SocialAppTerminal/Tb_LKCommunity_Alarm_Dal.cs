using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using FileManagementModel.SocialAppTerminal;
using FileManagementUtil;

namespace FileManagementDal.SocialAppTerminal
{
    public class Tb_LKCommunity_Alarm_Dal
    {


        public static void Insert(Tb_LKCommunity_Alarm_Mod info)
        {
            Database db = DataConnect.GetConnect;
            string Sql = @"insert into tb_lkcommunity_alarm(ListId, DeviceId, DeviceTime, Alarm, InTime)
                            values
                            (:ListId, :DeviceId, :DeviceTime, :Alarm, :InTime)";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":ListId", DbType.String, info.ListId);
            db.AddInParameter(cmd, ":DeviceId", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":DeviceTime", DbType.Date, info.DeviceTime);
            db.AddInParameter(cmd, ":Alarm", DbType.String, info.Alarm);
            db.AddInParameter(cmd, ":InTime", DbType.Date, info.InTime);
            db.ExecuteNonQuery(cmd);
        }

    }
}
