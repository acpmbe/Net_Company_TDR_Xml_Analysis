using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;

namespace FileManagementDal.ChuZuWu
{
    public class Tb_AutoDeployLog_Dal
    {

        public static void Insert(Tb_AutoDeployLog_Mod info)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand("INSERT INTO TB_AUTODEPLOYLOG (NEWLISTID,Oldlistid,Othertype,Otherid,Deploytype,Deploystate,Status,Operatime,OPERATETYPE)VALUES(:NEWLISTID,:Oldlistid,:Othertype,:Otherid,:Deploytype,:Deploystate,:Status, :Operatime,:OPERATETYPE )");
            db.AddInParameter(cmd, ":NEWLISTID", DbType.String, info.NewListId);
            db.AddInParameter(cmd, ":Oldlistid", DbType.String, info.OldListId);
            db.AddInParameter(cmd, ":Othertype", DbType.String, info.OtherType);
            db.AddInParameter(cmd, ":Otherid", DbType.String, info.OtherId);
            db.AddInParameter(cmd, ":Deploytype", DbType.String, info.DeployType);
            db.AddInParameter(cmd, ":Deploystate", DbType.String, info.DeployState);
            db.AddInParameter(cmd, ":Status", DbType.String, info.Status);
            db.AddInParameter(cmd, ":Operatime", DbType.Date, info.OperaTime);
            db.AddInParameter(cmd, ":OPERATETYPE", DbType.String,info.OperateType);
            db.ExecuteNonQuery(cmd);


        }

    
    }
}
