using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FileManagementDal.QiYeKaoQing
{
    public class QYKQDal_BeiFen
    {

        //public static void Insert(string EnterpriseID, string StaffName, string IdentityCardNo, string CardID, DateTime RegistrationTime, string UploadType)
        //{
        //    Database db = DatabaseConnect.GetConnect;

        //    string sql = @"merge INTO TB_QIYEKAOQINSTAFFINFO T
        //                   USING(SELECT 1 FROM DUAL) S
        //                   ON (T.IDENTITYCARDNO=:sfz AND T.ENTERPRISEID=:eqid) 
        //                   WHEN matched THEN UPDATE 
        //                   SET STAFFNAME=:staffname,CARDID=:cardid
        //                   WHEN NOT matched THEN 
        //                   INSERT(STAFFID,ENTERPRISEID,STAFFNAME,IDENTITYCARDNO,CARDID,STAFFSTATUS,REGISTRATIONTIME,DATAINTEGRITY,UploadType) 
        //                   VALUES(SEQ_QIYEKAOQINSTAFFINFO.nextval,:eqid,:staffname,:sfz,:cardid,0,:RegistrationTime,:DATAINTEGRITY,:UploadType)";

        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    db.AddInParameter(cmd, ":sfz", DbType.String, IdentityCardNo);
        //    db.AddInParameter(cmd, ":eqid", DbType.String, EnterpriseID);
        //    db.AddInParameter(cmd, ":staffname", DbType.String, StaffName);
        //    db.AddInParameter(cmd, ":cardid", DbType.String, CardID);
        //    db.AddInParameter(cmd, ":eqid", DbType.String, EnterpriseID);
        //    db.AddInParameter(cmd, ":staffname", DbType.String, StaffName);
        //    db.AddInParameter(cmd, ":sfz", DbType.String, IdentityCardNo);
        //    db.AddInParameter(cmd, ":cardid", DbType.String, CardID);
        //    db.AddInParameter(cmd, ":RegistrationTime", DbType.Date, RegistrationTime);
        //    db.AddInParameter(cmd, ":DATAINTEGRITY", DbType.String, string.IsNullOrWhiteSpace(IdentityCardNo) ? "1" : "0");
        //    db.AddInParameter(cmd, ":UploadType", DbType.String, UploadType);
        //    db.ExecuteNonQuery(cmd);

        //}

        //public static List<User> GetUsers(string QIYECOOD)
        //{
        //    Database db = DatabaseConnect.GetConnect;

        //    string sql = @"select STAFFNAME,IDENTITYCARDNO from TB_QIYEKAOQINSTAFFINFO where ENTERPRISEID=:ENTERPRISEID";

        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    db.AddInParameter(cmd, ":ENTERPRISEID", DbType.String, QIYECOOD);
        //    DataSet tb = db.ExecuteDataSet(cmd);

        //    List<User> res = new List<User>();
        //    foreach (DataRow dr in tb.Tables[0].Rows)
        //    {
        //        User item = new User();
        //        item.ID = dr["IDENTITYCARDNO"].ToString();
        //        item.Name = dr["STAFFNAME"].ToString();
        //        res.Add(item);
        //    }
        //    return res;
        //}

        //public static bool StaffLeave(string p_cardid, string p_IDENTITYNO, string p_QYCODE, DateTime time, string UploadType, string Upload)
        //{
        //    Database db = DatabaseConnect.GetConnect;

        //    DbCommand cmd = db.GetStoredProcCommand("SP_QIYESTAFF_LEAVE");
        //    db.AddInParameter(cmd, ":p_cardid", DbType.String, p_cardid);
        //    db.AddInParameter(cmd, ":p_IDENTITYNO", DbType.String, p_IDENTITYNO);
        //    db.AddInParameter(cmd, ":p_QYCODE", DbType.String, p_QYCODE);
        //    db.AddInParameter(cmd, ":p_time", DbType.DateTime, time);
        //    db.AddInParameter(cmd, ":p_UploadType", DbType.String, UploadType);
        //    db.AddInParameter(cmd, ":p_Upload", DbType.String, Upload);
        //    db.AddOutParameter(cmd, ":p_result", DbType.String, 255);
        //    db.ExecuteNonQuery(cmd);
        //    var result = db.GetParameterValue(cmd, ":p_result");
        //    if (result == null || string.IsNullOrWhiteSpace(result.ToString()))
        //    { return true; }
        //    return false;
        //}

        //public static bool InsertStaffKQ(string EnterpriseID, string CardID, DateTime RecordTime, string RecordType, string IdentityCardNo, DateTime DeviceTime, string StaffName, string UploadType, string Upload)
        //{
        //    Database db = DatabaseConnect.GetConnect;
        //    string sql = "INSERT INTO TB_QIYEKAOQINRECORD(RECORDID,ENTERPRISEID,RECORDTIME,RECORDTYPE,IDENTYTYCARDNO,DEVICETIME,STAFFNAME,UploadType,Upload)VALUES(SEQ_QIYEKAOQINRECORD.NEXTVAL,:v1,:v3,:v4,:v5,:v6,:v7,:v8,:v9)";


        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    db.AddInParameter(cmd, ":v1", DbType.String, EnterpriseID);
        //    db.AddInParameter(cmd, ":v3", DbType.DateTime, RecordTime);
        //    db.AddInParameter(cmd, ":v4", DbType.String, RecordType);
        //    db.AddInParameter(cmd, ":v5", DbType.String, IdentityCardNo);
        //    db.AddInParameter(cmd, ":v6", DbType.DateTime, DeviceTime);
        //    db.AddInParameter(cmd, ":v7", DbType.String, StaffName);
        //    db.AddInParameter(cmd, ":v8", DbType.String, UploadType);
        //    db.AddInParameter(cmd, ":v9", DbType.String, Upload);
        //    return db.ExecuteNonQuery(cmd) > 0;
        //}

        //public static bool UpdateLastTime(string EnterpriseID, DateTime lastTime)
        //{
        //    Database db = DatabaseConnect.GetConnect;
        //    string sql = "update TB_QIYEKAOQINLIST set LASTUPDATETIME=sysdate where ENTERPRISEID='" + EnterpriseID + "'";

        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    db.ExecuteNonQuery(cmd);
        //    return true;
        //}
    }
}
