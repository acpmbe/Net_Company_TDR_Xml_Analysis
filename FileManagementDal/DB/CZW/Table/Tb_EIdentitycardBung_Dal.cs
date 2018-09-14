using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementUtil;

namespace FileManagementDal.DB.CZW.Table
{
    public class Tb_EIdentitycardBung_Dal
    {


        #region 字段

        public string LISTID { get; set; }
        public string CARDTYPE { get; set; }
        public string CARDID { get; set; }
        public string IDENTITYCARDID { get; set; }
        public string IDENTITYCARD { get; set; }
        public string POLICECARD { get; set; }
        public string MJDEVICEID { get; set; }
        public DateTime DEVICETIME { get; set; }
        public DateTime INTIME { get; set; }
        public string STATUS { get; set; } //默认2
        public DateTime? OPERATETIME { get; set; }
        public string SOURCE { get; set; }
        public string RESERVED1 { get; set; }
        public string RESERVED2 { get; set; }
        public string RESERVED3 { get; set; }
        public string RESERVED4 { get; set; }
        public string OWERNAME { get; set; }
        public string SEX { get; set; }
        public string NATION { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public string HJADDRESS { get; set; }
        public string POLICE { get; set; }
        public string VALIDITY { get; set; }
        public string DNCODE { get; set; }
        #endregion




        public void Insert()
        {


            Database db = DataConnect.GetConnect;
            string Sql = @"INSERT INTO TB_EIDENTITYCARDBUNG
                            (LISTID, CARDTYPE, CARDID, IDENTITYCARDID, IDENTITYCARD, POLICECARD, MJDEVICEID, DEVICETIME, INTIME, STATUS, OPERATETIME, SOURCE, RESERVED1,RESERVED2, RESERVED3, RESERVED4, OWERNAME, SEX, NATION, BIRTHDAY, HJADDRESS, POLICE, VALIDITY, DNCODE)
                           VALUES                          (:LISTID, :CARDTYPE, :CARDID, :IDENTITYCARDID, :IDENTITYCARD, :POLICECARD, :MJDEVICEID, :DEVICETIME, :INTIME, :STATUS, :OPERATETIME, :SOURCE, :RESERVED1, :RESERVED2, :RESERVED3, :RESERVED4, :OWERNAME, :SEX, :NATION, :BIRTHDAY, :HJADDRESS, :POLICE, :VALIDITY, :DNCODE)";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":LISTID", DbType.String, this.LISTID);
            db.AddInParameter(cmd, ":CARDTYPE", DbType.String, this.CARDTYPE);
            db.AddInParameter(cmd, ":CARDID", DbType.String, this.CARDID);
            db.AddInParameter(cmd, ":IDENTITYCARDID", DbType.String, this.IDENTITYCARDID);
            db.AddInParameter(cmd, ":IDENTITYCARD", DbType.String, this.IDENTITYCARD);
            db.AddInParameter(cmd, ":POLICECARD", DbType.String, this.POLICECARD);
            db.AddInParameter(cmd, ":MJDEVICEID", DbType.String, this.MJDEVICEID);
            db.AddInParameter(cmd, ":DEVICETIME", DbType.Date, this.DEVICETIME);
            db.AddInParameter(cmd, ":INTIME", DbType.Date, this.INTIME);
            db.AddInParameter(cmd, ":STATUS", DbType.String, this.STATUS);
            db.AddInParameter(cmd, ":OPERATETIME", DbType.Date, this.OPERATETIME);
            db.AddInParameter(cmd, ":SOURCE", DbType.String, this.SOURCE);
            db.AddInParameter(cmd, ":RESERVED1", DbType.String, this.RESERVED1);
            db.AddInParameter(cmd, ":RESERVED2", DbType.String, this.RESERVED2);
            db.AddInParameter(cmd, ":RESERVED3", DbType.String, this.RESERVED3);
            db.AddInParameter(cmd, ":RESERVED4", DbType.String, this.RESERVED4);
            db.AddInParameter(cmd, ":OWERNAME", DbType.String, this.OWERNAME);
            db.AddInParameter(cmd, ":SEX", DbType.String, this.SEX);
            db.AddInParameter(cmd, ":NATION", DbType.String, this.NATION);
            db.AddInParameter(cmd, ":BIRTHDAY", DbType.Date, this.BIRTHDAY);
            db.AddInParameter(cmd, ":HJADDRESS", DbType.String, this.HJADDRESS);
            db.AddInParameter(cmd, ":POLICE", DbType.String, this.POLICE);
            db.AddInParameter(cmd, ":VALIDITY", DbType.String, this.VALIDITY);
            db.AddInParameter(cmd, ":DNCODE", DbType.String, this.DNCODE);

            db.ExecuteNonQuery(cmd);

        }


        //public static string Select(string sblx, string DianBiao, string bfState)
        //{

        //    Database db = DataConnect.GetConnect;
        //    DbCommand cmd = db.GetSqlStringCommand("select roomid from tb_deviceinfo where devicetype=:pi_devicetype and devicecode=:pi_devicecode");
        //    db.AddInParameter(cmd, ":pi_devicetype", DbType.String, sblx);
        //    db.AddInParameter(cmd, ":pi_devicecode", DbType.String, DianBiao);
        //    DataSet result = db.ExecuteDataSet(cmd);
        //    if (result.Tables[0].Rows.Count == 0)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        return result.Tables[0].Rows[0][0].ToString();
        //    }

        //}


        public  bool Select_IdCard(string identitycardId)
        {

            Database db = DataConnect.GetConnect;
            string Sql = @"SELECT COUNT(1) FROM TB_EIDENTITYCARDBUNG WHERE IDENTITYCARDID=:IDENTITYCARDID";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":IDENTITYCARDID", DbType.String, identitycardId);




            object ddd = db.ExecuteScalar(cmd);

            int rrr = Convert.ToInt32(ddd);


            return rrr > 0;

        }

        public void Update()
        {

            Database db = DataConnect.GetConnect;
            string Sql = @"UPDATE TB_EIDENTITYCARDBUNG
                           SET IDENTITYCARD = :IDENTITYCARD,
                               MJDEVICEID = :MJDEVICEID,
                               DEVICETIME = :DEVICETIME,
                               INTIME = :INTIME,
                               OWERNAME = :OWERNAME,
                               SEX = :SEX,
                               NATION = :NATION,
                               BIRTHDAY = :BIRTHDAY,
                               HJADDRESS = :HJADDRESS,
                               POLICE = :POLICE,
                               VALIDITY = :VALIDITY
                           WHERE IDENTITYCARDID = :IDENTITYCARDID";
            DbCommand cmd = db.GetSqlStringCommand(Sql);
            db.AddInParameter(cmd, ":IDENTITYCARD", DbType.String, this.IDENTITYCARD);
            db.AddInParameter(cmd, ":MJDEVICEID", DbType.String, this.MJDEVICEID);
            db.AddInParameter(cmd, ":DEVICETIME", DbType.Date, this.DEVICETIME);
            db.AddInParameter(cmd, ":INTIME", DbType.Date, this.INTIME);
            db.AddInParameter(cmd, ":OWERNAME", DbType.String, this.OWERNAME);
            db.AddInParameter(cmd, ":SEX", DbType.String, this.SEX);
            db.AddInParameter(cmd, ":NATION", DbType.String, this.NATION);
            db.AddInParameter(cmd, ":BIRTHDAY", DbType.Date, this.BIRTHDAY);
            db.AddInParameter(cmd, ":HJADDRESS", DbType.String, this.HJADDRESS);
            db.AddInParameter(cmd, ":POLICE", DbType.String, this.POLICE);
            db.AddInParameter(cmd, ":VALIDITY", DbType.String, this.VALIDITY);
            db.AddInParameter(cmd, ":IDENTITYCARDID", DbType.String, this.IDENTITYCARDID);
            db.ExecuteNonQuery(cmd);

        }



    }
}
