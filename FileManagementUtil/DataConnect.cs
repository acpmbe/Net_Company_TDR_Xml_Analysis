using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FileManagementUtil
{
    public class DataConnect
    {

        private static Database dataConnect;
        private static readonly object syncRoot = new object();

        private static Database dataConnect_StationInfo;
        private static readonly object syncRoot_StationInfo = new object();

   
  
   
        private DataConnect()
        {
           
        }

        /// <summary>
        /// 得到数据库连接OracleDb。
        /// </summary>
        public static Database GetConnect
        {
            get
            {
                if (dataConnect == null)
                {
                    lock (syncRoot)
                    {                      
                        if (dataConnect == null)
                        {
                            dataConnect = new DatabaseProviderFactory().Create("OracleDb");
                        }
                    }
                }
                return dataConnect;

            }
        }

        /// <summary>
        /// 得到数据库连接OracleDb_StationInfo。
        /// </summary>
        public static Database GetConnect_StationInfo
        {
            get
            {
                if (dataConnect_StationInfo == null)
                {
                    lock (syncRoot_StationInfo)
                    {
                        if (dataConnect_StationInfo == null)
                        {
                            dataConnect_StationInfo = new DatabaseProviderFactory().Create("OracleDb_StationInfo");
                        }
                    }
                }
                return dataConnect_StationInfo;
            }
        }

   
    }
}
