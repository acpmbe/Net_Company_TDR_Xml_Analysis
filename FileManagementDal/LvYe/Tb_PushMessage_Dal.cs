using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.LvYe;
using FileManagementUtil;

namespace FileManagementDal.LvYe
{
    /// <summary>
    /// 推送信息表
    /// </summary>
    public class Tb_PushMessage_Dal
    {

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info"></param>
        public static void Insert(Tb_PushMessage_Mod info)
        {


            Database db = DataConnect.GetConnect;
            string sql = @"INSERT INTO TB_PUSHMESSAGE
                            (LISTID, PUSHTYPE, PUSHNUMBER, MESSAGETYPE, PROTOCOLTYPE, MESSAGE, PUSHTIME, ISSUCCESS, 
                             SOURCEID, ISALARM, REASON, RESERVED1, RESERVED2, RESERVED3, RESERVED4)
                          VALUES
                            (:LISTID, :PUSHTYPE, :PUSHNUMBER, :MESSAGETYPE, :PROTOCOLTYPE, :MESSAGE, :PUSHTIME,
                             :ISSUCCESS, :SOURCEID, :ISALARM, :REASON, :RESERVED1, :RESERVED2, :RESERVED3, :RESERVED4)";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, ":LISTID", DbType.String, info.LISTID);
            db.AddInParameter(cmd, ":PUSHTYPE", DbType.String, info.PUSHTYPE);
            db.AddInParameter(cmd, ":PUSHNUMBER", DbType.String, info.PUSHNUMBER);
            db.AddInParameter(cmd, ":MESSAGETYPE", DbType.String, info.MESSAGETYPE);
            db.AddInParameter(cmd, ":PROTOCOLTYPE", DbType.String, info.PROTOCOLTYPE);
            db.AddInParameter(cmd, ":MESSAGE", DbType.String, info.MESSAGE);
            db.AddInParameter(cmd, ":PUSHTIME", DbType.Date, info.PUSHTIME);
            db.AddInParameter(cmd, ":ISSUCCESS", DbType.String, info.ISSUCCESS);
            db.AddInParameter(cmd, ":SOURCEID", DbType.String, info.SOURCEID);
            db.AddInParameter(cmd, ":ISALARM", DbType.String, info.ISALARM);
            db.AddInParameter(cmd, ":REASON", DbType.String, info.REASON);
            db.AddInParameter(cmd, ":RESERVED1", DbType.String, info.RESERVED1);
            db.AddInParameter(cmd, ":RESERVED2", DbType.String, info.RESERVED2);
            db.AddInParameter(cmd, ":RESERVED3", DbType.String, info.RESERVED3);
            db.AddInParameter(cmd, ":RESERVED4", DbType.String, info.RESERVED4);
            db.ExecuteNonQuery(cmd);

        }

   


      
    }
}
