using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.MenJin;
using System.Data.Common;
using System.Data;
using FileManagementUtil;

namespace FileManagementDal.MenJin
{
    public class MjDal
    {

        public static void InsertXinTiao(XinTiaoInfo info)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd;
            cmd = db.GetSqlStringCommand(@"UPDATE TB_MJDEVICEINFO set POWERSTATE = :POWERSTATE,CARDREADERSTATE = :CARDREADERSTATE,SDCARDSTATE = :SDCARDSTATE,SIGHLEVEL = :SIGHLEVEL,USERCARDCOUNT = :USERCARDCOUNT,LASTUPDATETIME = :LASTUPDATETIME,LANDROADCARDCOUNT = :LANDROADCARDCOUNT,POLICECARDCOUNT = :POLICECARDCOUNT
            ,EQUIPMENTTIME = :EQUIPMENTTIME,VERSION = :VERSION WHERE MJDEVICEID = :MJDEVICEID");
            db.AddInParameter(cmd, ":POWERSTATE", DbType.String, info.POWERSTATE_Update);
            db.AddInParameter(cmd, ":CARDREADERSTATE", DbType.String, info.CARDREADERSTATE_Update);
            db.AddInParameter(cmd, ":SDCARDSTATE", DbType.String, info.SDCARDSTATE_Update);
            db.AddInParameter(cmd, ":SIGHLEVEL", DbType.String, info.SighLevel_Update);
            db.AddInParameter(cmd, ":USERCARDCOUNT", DbType.String, info.USERCARDCOUNT);
            db.AddInParameter(cmd, ":LASTUPDATETIME", DbType.Date, info.LASTUPDATETIME_Update);
            db.AddInParameter(cmd, ":LANDROADCARDCOUNT", DbType.String, info.LandroadCardCount_Update);
            db.AddInParameter(cmd, ":POLICECARDCOUNT", DbType.String, info.POLICECARDCOUNT);
            db.AddInParameter(cmd, ":EQUIPMENTTIME", DbType.Date, info.EQUIPMENTTIME);
            db.AddInParameter(cmd, ":VERSION", DbType.String, info.VERSION);
            db.AddInParameter(cmd, ":MJDEVICEID", DbType.String, info.MJDEVICEID);
            db.ExecuteNonQuery(cmd);

            cmd = db.GetSqlStringCommand(@"insert into tb_mjdeviceheart(LISTID, MJDEVICEID, LASTUPDATETIME, EQUIPMENTTIME, POLICECARDCOUNT, VERSION, USERCARDCOUNT, CARDREADERSTATE, LOCKSTATE,                                         SDCARDSTATE, HOARESTATE, POWERSTATE, CAMERA1STATE, CAMERA2STATE, MODULE433STATE)
                                                  values                                            (:LISTID, :MJDEVICEID, :LASTUPDATETIME, :EQUIPMENTTIME, :POLICECARDCOUNT, :VERSION, :USERCARDCOUNT, :CARDREADERSTATE, :LOCKSTATE, :SDCARDSTATE,:HOARESTATE,:POWERSTATE,:CAMERA1STATE,:CAMERA2STATE,:MODULE433STATE )");
            db.AddInParameter(cmd, ":LISTID", DbType.String, info.LISTID);
            db.AddInParameter(cmd, ":MJDEVICEID", DbType.String, info.MJDEVICEID);
            db.AddInParameter(cmd, ":LASTUPDATETIME", DbType.Date, info.LASTUPDATETIME);
            db.AddInParameter(cmd, ":EQUIPMENTTIME", DbType.Date, info.EQUIPMENTTIME);
            db.AddInParameter(cmd, ":POLICECARDCOUNT", DbType.String, info.POLICECARDCOUNT);
            db.AddInParameter(cmd, ":VERSION", DbType.String, info.VERSION);
            db.AddInParameter(cmd, ":USERCARDCOUNT", DbType.String, info.USERCARDCOUNT);
            db.AddInParameter(cmd, ":CARDREADERSTATE", DbType.String, info.CARDREADERSTATE);
            db.AddInParameter(cmd, ":LOCKSTATE", DbType.String, info.LOCKSTATE);
            db.AddInParameter(cmd, ":SDCARDSTATE", DbType.String, info.SDCARDSTATE);
            db.AddInParameter(cmd, ":HOARESTATE", DbType.String, info.HOARESTATE);
            db.AddInParameter(cmd, ":POWERSTATE", DbType.String, info.POWERSTATE);
            db.AddInParameter(cmd, ":CAMERA1STATE", DbType.String, info.CAMERA1STATE);
            db.AddInParameter(cmd, ":CAMERA2STATE", DbType.String, info.CAMERA2STATE);
            db.AddInParameter(cmd, ":MODULE433STATE", DbType.String, info.MODULE433STATE);
            db.ExecuteNonQuery(cmd);


        }

        public static void HandleMenJin(MJInfo info, out UInt16 resultNum, out string reason)
        {
            Database db = DataConnect.GetConnect;

            DbCommand cmd = db.GetStoredProcCommand("pro_truncmendevice");
            db.AddInParameter(cmd, ":pi_Protocol", DbType.String, info.Protocol);
            db.AddInParameter(cmd, ":pi_DeviceId", DbType.String, info.DeviceId);
            db.AddInParameter(cmd, ":pi_CardId", DbType.String, info.CardId);
            db.AddInParameter(cmd, ":pi_CardType", DbType.String, info.CardType);
            db.AddInParameter(cmd, ":pi_Identitycard", DbType.String, info.Identitycard);
            db.AddInParameter(cmd, ":pi_IdentitycardId", DbType.String, info.IdentitycardId);
            db.AddInParameter(cmd, ":pi_ChineseName", DbType.String, info.ChineseName);
            db.AddInParameter(cmd, ":pi_DeleteType", DbType.String, info.DeleteType);
            db.AddInParameter(cmd, ":pi_PoliceCard", DbType.String, info.PoliceCard);
            db.AddInParameter(cmd, ":pi_DataIntegrity", DbType.String, info.DataIntegrity);
            db.AddInParameter(cmd, ":pi_UserPhoneNum", DbType.String, info.UserPhoneNum);
            db.AddInParameter(cmd, ":pi_UserRoom", DbType.String, info.UserRoom);
            db.AddInParameter(cmd, ":pi_IsOpenDoor", DbType.String, info.IsOpenDoor);
            db.AddInParameter(cmd, ":pi_IsOpenByCard", DbType.String, info.IsOpenByCard);
            db.AddInParameter(cmd, ":pi_SimNum", DbType.String, info.SimNum);
            db.AddInParameter(cmd, ":pi_DeviceTime", DbType.Date, info.DeviceTime);
            db.AddOutParameter(cmd, ":po_ResultNum", DbType.String, 256);
            db.AddOutParameter(cmd, ":po_Reason", DbType.String, 256);
            db.ExecuteNonQuery(cmd);
            resultNum = Convert.ToUInt16(db.GetParameterValue(cmd, ":po_ResultNum"));
            reason = db.GetParameterValue(cmd, ":po_Reason").ToString();

        }
    }
}
