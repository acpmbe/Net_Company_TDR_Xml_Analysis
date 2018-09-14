using System;
using System.Collections.Generic;
using System.Data;
using FileManagementUtil;
using Oracle.ManagedDataAccess.Client;

namespace FileManagementDal.DB.ZNQT
{
    public class DB_ZNQT
    {

        private static OracleConnection dataConnect;
        private static readonly object syncRoot = new object();

        private static OracleConnection GetConnect
        {
            get
            {
                if (dataConnect == null)
                {
                    lock (syncRoot)
                    {
                        if (dataConnect == null)
                        {
                            dataConnect = new OracleConnection(ConnectStr);
                            dataConnect.Open();
                        }
                    }
                }
                return dataConnect;

            }
        }



        /// <summary>
        /// 数据库实例
        /// </summary>
        public static DB_ZNQT DB = new DB_ZNQT();



        /// <summary>
        /// 连接字符串
        /// </summary>
        public readonly static string ConnectStr = "";


        #region NonQuery
        /// <summary>
        /// 非查询SQL语句执行
        /// </summary> 
        /// <param name="sqlText">sql语句</param> 
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(string sqlText, OracleParameter[] cmdParameters)
        {
            return ExecuteNonQuery(CommandType.Text, sqlText, cmdParameters);
        }

        public int ExcuteProc(string sqlText)
        {

            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, GetConnect, null, CommandType.StoredProcedure, sqlText, null);
            return cmd.ExecuteNonQuery();

        }
        public OracleCommand ExcuteProc(string cmdTxt, OracleParameter[] list)
        {

            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, GetConnect, null, CommandType.StoredProcedure, cmdTxt, list);
            cmd.ExecuteNonQuery();
            return cmd;
        }


        /// <summary>
        /// 非查询语句执行
        /// </summary> 
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名orSQL</param> 
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {

            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, GetConnect, null, cmdType, cmdText, cmdParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }


        public int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection connection = new OracleConnection(ConnectStr))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, null);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 非查询语句执行
        /// </summary> 
        /// <param name="cmdType">命令类型</param>
        /// <param name="sqlText">SQL</param>
        /// <param name="cmdParameters">oracle 参数</param>
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(OracleTransaction myTrans, string sqlText, OracleParameter[] cmdParameters)
        {
            return ExecuteNonQuery(myTrans, CommandType.Text, sqlText, cmdParameters);
        }

        /// <summary>
        /// 对已存在的时候执行非查询语句
        /// </summary>
        /// <remarks>
        /// e.g.: int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders", new OracleParameter(":prodid", 24));
        /// </remarks>
        /// <param name="myTrans">已存在的事务</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名orSQL</param>
        /// <param name="cmdParameters">参数</param>
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(OracleTransaction myTrans, CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {
            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, myTrans.Connection, myTrans, cmdType, cmdText, cmdParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region Reader

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名orSQL</param>
        /// <param name="cmdParameters">oracle 参数</param>
        /// <returns></returns>
        public OracleDataReader ExecuteReader(CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {

            OracleCommand cmd = new OracleCommand();
            OracleConnection conn = new OracleConnection(ConnectStr);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);

                OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region Scaler
        /// <summary>
        /// 返回第一行第一列数据
        /// </summary>
        /// <param name="sqlText">SQL</param> 
        /// <returns>Convert.To{Type}</returns>
        public object ExecuteScalar(string sqlText, OracleParameter[] cmdParameters)
        {

            return ExecuteScalar(CommandType.Text, sqlText, cmdParameters);
        }
        /// <summary>
        /// 返回第一行第一列数据
        /// </summary> 
        /// <param name="connString">连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名orSQL</param>
        /// <param name="cmdParameters">oracle 参数</param>
        /// <returns>Convert.To{Type}</returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection conn = new OracleConnection(ConnectStr))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);

                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }


        ///	<summary>
        /// 返回第一行第一列数据
        ///	</summary>
        /// <param name="sqlText">SQL</param> 
        /// <returns>Convert.To{Type}</returns>
        public object ExecuteScalar(OracleTransaction myTrans, string sqlText, OracleParameter[] cmdParameters)
        {
            return ExecuteScalar(myTrans, CommandType.Text, sqlText, cmdParameters);
        }

        ///	<summary>
        /// 返回第一行第一列数据
        ///	</summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">存储过程名orSQL</param>
        /// <param name="cmdParameters">oracle 参数</param>
        /// <returns>Convert.To{Type}</returns>
        public object ExecuteScalar(OracleTransaction myTrans, CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {
            if (myTrans == null)
                throw new ArgumentNullException("transaction");
            if (myTrans != null && myTrans.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please provide an open transaction.", "transaction");

            OracleCommand cmd = new OracleCommand();

            PrepareCommand(cmd, myTrans.Connection, myTrans, cmdType, cmdText, cmdParameters);

            object retval = cmd.ExecuteScalar();

            cmd.Parameters.Clear();
            return retval;
        }
        #endregion

        #region Scaler -- Int
        /// <summary>
        /// 返回第一行第一列int数据
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlText">CommandType.Text</param>
        /// <param name="cmdParameters"></param>
        /// <returns></returns>


        public int ExecuteInt(string sqlText, OracleParameter[] cmdParameters)
        {

            return Convert.ToInt32(ExecuteScalar(sqlText, cmdParameters));
        }


        /// <summary>
        /// 返回第一行第一列string数据
        /// </summary>
        /// <param name="sqlText"></param>
        /// <param name="cmdParameters"></param>
        /// <returns></returns>
        public string ExecuteStr(string sqlText, OracleParameter[] cmdParameters)
        {
            object obj = ExecuteScalar(sqlText, cmdParameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }

        }

        /// <summary>
        /// 返回第一行第一列int数据
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sqlText">CommandType.Text</param>
        /// <param name="cmdParameters"></param>
        /// <returns></returns>
        public int ExecuteInt(OracleTransaction myTrans, string sqlText, OracleParameter[] cmdParameters)
        {
            return Convert.ToInt32(ExecuteScalar(myTrans, CommandType.Text, sqlText, cmdParameters));
        }
        #endregion

        #region DataTable
        public DataTable ExecuteTable(string sqlText, OracleParameter[] cmdParameters)
        {
            using (OracleConnection conn = new OracleConnection(ConnectStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sqlText, conn);
                PrepareCommand(cmd, conn, null, CommandType.Text, sqlText, cmdParameters);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                cmd.Parameters.Clear();
                return dt;
            }
        }

        public DataTable ExecuteTable_N(string sqlText)
        {
            using (OracleConnection conn = new OracleConnection(ConnectStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sqlText, conn);
                PrepareCommand_N(cmd, conn, null, CommandType.Text, sqlText);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                cmd.Parameters.Clear();
                return dt;
            }
        }

        public DataTable ExecuteTable(CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {
            using (OracleConnection conn = new OracleConnection(ConnectStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(cmdText, conn);
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                cmd.Parameters.Clear();
                return dt;
            }
        }


        public DataTable ExecuteTable(OracleTransaction myTrans, CommandType cmdType, string commandText, OracleParameter[] cmdParameters)
        {
            if (myTrans == null)
                throw new ArgumentNullException("transaction");
            if (myTrans != null && myTrans.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");

            OracleCommand cmd = new OracleCommand();

            PrepareCommand(cmd, myTrans.Connection, myTrans,
                cmdType, commandText, cmdParameters);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.Parameters.Clear();
            return dt;
        }

        #endregion

        #region DataSet
        /// <summary>
        /// 未测试
        /// </summary>

        public DataSet ExecuteDataSet(string cmdText, OracleParameter[] cmdParameters)
        {

            return ExecuteDataSet(CommandType.Text, cmdText, cmdParameters);
        }






        /// <summary>
        /// 未测试
        /// </summary>
        //public DataSet ExecuteDataSet(CommandType cmdType, string cmdText,List<Parm> cmdParameters)
        //{

        //    OracleCommand cmd = new OracleCommand();

        //    using (OracleConnection conn = new OracleConnection(ConnectStr))
        //    {
        //        PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
        //        OracleDataAdapter adapter = new OracleDataAdapter(cmd);

        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            adapter.FillSchema(ds, SchemaType.Source);

        //            // Fill data
        //            adapter.Fill(ds);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            cmd.Parameters.Clear();
        //            cmd.Dispose();
        //        }
        //        return ds;
        //    }
        //}

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText, OracleParameter[] cmdParameters)
        {

            OracleCommand cmd = new OracleCommand();
            PrepareCommand(cmd, GetConnect, null, cmdType, cmdText, cmdParameters);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                adapter.FillSchema(ds, SchemaType.Source);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return ds;
        }


        #endregion

        #region PrepareCommand
        private void PrepareCommand(OracleCommand cmd, OracleConnection conn,
            OracleTransaction trans, CommandType cmdType,
            string cmdText, OracleParameter[] cmdParmsList)
        {


            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;//cmdType;
            cmd.BindByName = true;
            if (cmdParmsList != null)
            {
                foreach (OracleParameter parm in cmdParmsList)
                    cmd.Parameters.Add(parm);
            }
        }




        private void PrepareCommand_N(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;//cmdType;
            cmd.BindByName = true;

        }

        #endregion
    }
}
