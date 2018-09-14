using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using FileManagementModel.JingXie;
using FileManagementUtil;

namespace FileManagementDal.JingXie
{
    public class Pro_TagData_Dal
    {


        public static void Exec(Pro_TagData_Mod info, out int resultnum)
        {
            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetStoredProcCommand("PRO_TAGDATA");
            db.AddInParameter(cmd, ":TagID", DbType.String, info.TagID);
            db.AddInParameter(cmd, ":StationID", DbType.String, info.StationID);
            db.AddInParameter(cmd, ":TagTime", DbType.Date, info.TagTime);
            db.AddInParameter(cmd, ":PlateTime", DbType.Date, info.PlateTime);
            db.AddInParameter(cmd, ":TagType", DbType.String, info.TagType);
            db.AddOutParameter(cmd, ":Ret", DbType.String, 256);
            db.ExecuteNonQuery(cmd);

            var ResultNum = db.GetParameterValue(cmd, ":Ret");
            if (ResultNum != null && ResultNum.ToString() != "")
            {
                resultnum = Convert.ToInt16(ResultNum);
            }
            else
            {
                resultnum = 0;
            }


        }
    }
}
