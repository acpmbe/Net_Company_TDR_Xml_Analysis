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
    public class Tb_LKCommunity_Dal
    {

        public static void Update(Tb_LKCommunity_Mod info)
        {
            Database db = DataConnect.GetConnect;
            string Sql = @"Update Tb_LKCommunity set DeviceTime= :DeviceTime, LastUpdateTime= :LastUpdateTime, SoftVersion=:SoftVersion,
                HardwareVersion=:HardwareVersion , Signal=:Signal where DeviceId=:DeviceId";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":DeviceTime", DbType.Date, info.DeviceTime);
            db.AddInParameter(cmd, ":LastUpdateTime", DbType.Date, info.LastUpdateTime);
            db.AddInParameter(cmd, ":SoftVersion", DbType.String, info.SoftVersion);
            db.AddInParameter(cmd, ":HardwareVersion", DbType.String, info.HardwareVersion);
            db.AddInParameter(cmd, ":Signal", DbType.String, info.Signal);
            db.AddInParameter(cmd, ":DeviceId", DbType.String, info.DeviceId);
            db.ExecuteNonQuery(cmd);
        }
    }
}
