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
    public class Tb_LKCommunityRecord_Dal
    {

        public static void Insert(Tb_LKCommunityRecord_Mod info)
        {
            Database db = DataConnect.GetConnect;
            string Sql = "Insert into tb_lkcommunityrecord(recordid,DeviceId, RecordTime, DeviceTime, CardId, IdCard, CardType, Reserve)values(SEQ_COMMUNITYID.nextval,:DeviceId, :RecordTime, :DeviceTime, :CardId,:IdCard, :CardType, :Reserve)";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":DeviceId", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":RecordTime", DbType.Date, info.RecordTime);
            db.AddInParameter(cmd, ":DeviceTime", DbType.Date, info.DeviceTime);
            db.AddInParameter(cmd, ":CardId", DbType.String, info.CardId);
            db.AddInParameter(cmd, ":IdCard", DbType.String, info.IdCard);
            db.AddInParameter(cmd, ":CardType", DbType.String, info.CardType);
            db.AddInParameter(cmd, ":Reserve", DbType.String, info.Reserve);
            db.ExecuteNonQuery(cmd);
        }
    }
}
