using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.QiYeKaoQing;
using FileManagementUtil;

namespace FileManagementDal.QiYeKaoQing
{
    public class QYKQDal
    {


        public static void Insert_Pro(QykqInfo info, out UInt16 resultNum, out string reason)
        {

           
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("pro_Qykq");
            db.AddInParameter(cmd, ":pi_CmdId", DbType.String, info.pi_CmdId);
            db.AddInParameter(cmd, ":pi_EnterpriseID", DbType.String, info.pi_EnterpriseID);
            db.AddInParameter(cmd, ":pi_StaffName", DbType.String, info.pi_StaffName);
            db.AddInParameter(cmd, ":pi_IdentityCardNo", DbType.String, info.pi_IdentityCardNo);
            db.AddInParameter(cmd, ":pi_CardID", DbType.String, info.pi_CardID);
            db.AddInParameter(cmd, ":pi_RegistrationTime", DbType.Date, info.pi_RegistrationTime);
            db.AddInParameter(cmd, ":pi_Dataintegrity", DbType.String, info.pi_Dataintegrity);
            db.AddInParameter(cmd, ":pi_UploadType", DbType.String, info.pi_UploadType);
            db.AddInParameter(cmd, ":pi_RecordTime", DbType.Date, info.pi_RecordTime);
            db.AddInParameter(cmd, ":pi_DeviceTime", DbType.Date, info.pi_DeviceTime);
            db.AddInParameter(cmd, ":pi_RecordType", DbType.String, info.pi_RecordType);
            db.AddInParameter(cmd, ":pi_Upload", DbType.String, info.pi_Upload);
            db.AddInParameter(cmd, ":pi_ResidenceAddress", DbType.String, info.pi_ResidenceAddress);
            db.AddInParameter(cmd, ":pi_ResidenceCode", DbType.String, info.pi_ResidenceCode);
            db.AddOutParameter(cmd, ":po_resultnum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_reason", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_resultnum"));
            reason = db.GetParameterValue(cmd, ":po_reason").ToString();

        }

        public static List<StaffInfo> GetUsers(string qiYeCode)
        {

            MyLibrary.Log.Warn("开始查询；企业代码：" + qiYeCode);

            DataTable table = Select(qiYeCode);

            MyLibrary.Log.Warn("结束查询；企业代码：" + qiYeCode);


            List<StaffInfo> list = new List<StaffInfo>();
            StaffInfo info;      
            foreach(DataRow dr in table.Rows)
            {
                info = new StaffInfo();
                info.ID = dr["IDENTITYCARDNO"].ToString();
                info.Name = dr["STAFFNAME"].ToString();
                list.Add(info);
            } 
            return list;
        }


        //public static List<StaffInfo> GetUsers(string QIYECOOD)
        //{
        //    Database db = DataConnect.GetConnect;

        //    //string sql = "select STAFFNAME,IDENTITYCARDNO from TB_QIYEKAOQINSTAFFINFO where ENTERPRISEID=:ENTERPRISEID";

        //    string sql = "SELECT STAFFNAME,IDENTITYCARDNO FROM TB_QIYEKAOQINSTAFFINFO WHERE ENTERPRISEID=:ENTERPRISEID";
        //    DbCommand cmd = db.GetSqlStringCommand(sql);
        //    db.AddInParameter(cmd, ":ENTERPRISEID", DbType.String, QIYECOOD);
        //    DataSet tb = db.ExecuteDataSet(cmd);

        //    List<StaffInfo> res = new List<StaffInfo>();
        //    StaffInfo item;
        //    foreach (DataRow dr in tb.Tables[0].Rows)
        //    {
        //        item = new StaffInfo();
        //        item.ID = dr["IDENTITYCARDNO"].ToString();
        //        item.Name = dr["STAFFNAME"].ToString();
        //        res.Add(item);
        //    }
        //    return res;
        //}



        private static DataTable Select(string qiYeCode)
        {
            Database db = DataConnect.GetConnect;
            string sqlText = "SELECT STAFFNAME,IDENTITYCARDNO FROM TB_QIYEKAOQINSTAFFINFO WHERE ENTERPRISEID=:ENTERPRISEID";
            DbCommand cmd = db.GetSqlStringCommand(sqlText);
            db.AddInParameter(cmd, ":ENTERPRISEID", DbType.String, qiYeCode);
            return db.ExecuteDataSet(cmd).Tables[0];
        }


        public static void UpdateLastTime(string EnterpriseID)
        {
            Database db = DataConnect.GetConnect;
            string sql = "update TB_QIYEKAOQINLIST set LASTUPDATETIME=sysdate where ENTERPRISEID='" + EnterpriseID + "'";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.ExecuteNonQuery(cmd);

        }

    }
}
