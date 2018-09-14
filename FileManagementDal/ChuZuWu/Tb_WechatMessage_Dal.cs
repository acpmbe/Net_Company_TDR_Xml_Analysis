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
    public class Tb_WechatMessage_Dal
    {

        public static void Insert(Tb_WechatMessage_Mod info)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand("insert into TB_WECHATMESSAGE (listid,wechatid,messagetype,protocoltype,message,pushtime,issuccess,sourceid,isalarm,reserved1,reserved2,reserved3,reserved4,PushType)values(:listid,:wechatid,:messagetype,:protocoltype,:message,sysdate,:issuccess,:sourceid,:isalarm,:reserved1,:reserved2,:reserved3,:reserved4,:PushType)");
            db.AddInParameter(cmd, ":listid", DbType.String, info.ListId);
            db.AddInParameter(cmd, ":wechatid", DbType.String, info.WechatId);
            db.AddInParameter(cmd, ":messagetype", DbType.String, info.MessageType);
            db.AddInParameter(cmd, ":protocoltype", DbType.String, info.ProtocolType);
            db.AddInParameter(cmd, ":message", DbType.String, info.Message);
            db.AddInParameter(cmd, ":issuccess", DbType.String, info.IsSuccess);
            db.AddInParameter(cmd, ":sourceid", DbType.String, info.SourceId);
            db.AddInParameter(cmd, ":isalarm", DbType.String, info.IsAlarm);
            db.AddInParameter(cmd, ":reserved1", DbType.String, info.Reserved1);
            db.AddInParameter(cmd, ":reserved2", DbType.String, info.Reserved2);
            db.AddInParameter(cmd, ":reserved3", DbType.String, info.Reserved3);
            db.AddInParameter(cmd, ":reserved4", DbType.String, info.Reserved4);
            db.AddInParameter(cmd, ":PushType", DbType.String, info.PushType);
            db.ExecuteNonQuery(cmd);

        }
    }
}
