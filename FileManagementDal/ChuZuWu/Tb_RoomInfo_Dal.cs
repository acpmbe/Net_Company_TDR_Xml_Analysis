using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementUtil;


namespace FileManagementDal.ChuZuWu
{
    public class Tb_RoomInfo_Dal
    {

        public static void Update(string fjh, string bfState)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand("update tb_roominfo set deploystatus=:bfState where roomid=:roomid");
            db.AddInParameter(cmd, ":bfState", DbType.String, bfState);
            db.AddInParameter(cmd, ":roomid", DbType.String, fjh);
            db.ExecuteNonQuery(cmd);

        }
    }
}
