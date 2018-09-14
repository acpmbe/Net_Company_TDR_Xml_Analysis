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
    public class Tb_DeviceInfo_Dal
    {

        public static string Select(string sblx, string DianBiao, string bfState)
        {

            Database db = DataConnect.GetConnect;
            DbCommand cmd = db.GetSqlStringCommand("select roomid from tb_deviceinfo where devicetype=:pi_devicetype and devicecode=:pi_devicecode");
            db.AddInParameter(cmd, ":pi_devicetype", DbType.String, sblx);
            db.AddInParameter(cmd, ":pi_devicecode", DbType.String, DianBiao);
            DataSet result = db.ExecuteDataSet(cmd);
            if (result.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return result.Tables[0].Rows[0][0].ToString();
            }

        }
    }
}
