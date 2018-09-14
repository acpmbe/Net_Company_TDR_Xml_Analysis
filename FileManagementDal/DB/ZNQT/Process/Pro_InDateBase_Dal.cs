using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FileManagementDal.DB.ZNQT.Process
{
    //public class Pro_InDateBase_Dal
    //{
    //    private static DB_ZNQT DB = DB_ZNQT.DB;

    //    #region 字段


    //    /// <summary>
    //    /// 基站号码
    //    /// </summary>
    //    public string pi_stationno { get; set; }

    //    /// <summary>
    //    /// 程序版本号
    //    /// </summary>
    //    public string pi_version { get; set; }

    //    /// <summary>
    //    /// SN号
    //    /// </summary>
    //    public string pi_sn { get; set; }

    //    /// <summary>
    //    /// 中继编号
    //    /// </summary>
    //    public string pi_relayno { get; set; }

    //    /// <summary>
    //    /// 平台时间
    //    /// </summary>
    //    public DateTime pi_servicetime { get; set; }

    //    /// <summary>
    //    /// 设备时间
    //    /// </summary>
    //    public DateTime pi_devicetime { get; set; }


    //    /// <summary>
    //    /// 设备类型
    //    /// </summary>
    //    public string pi_devicetype { get; set; }

    //    /// <summary>
    //    /// 设备号码
    //    /// </summary>
    //    public string pi_devicecode { get; set; }

    //    /// <summary>
    //    /// 命令字
    //    /// </summary>
    //    public string pi_cmdid { get; set; }

    //    /// <summary>
    //    /// 内容
    //    /// </summary>
    //    public string pi_content { get; set; }

    //    /// <summary>
    //    /// 内容长度
    //    /// </summary>
    //    public string pi_length { get; set; }


    //    #endregion



    //    public class OutMod
    //    {
    //        public int resultNum { get; set; }
    //        public string reason { get; set; }
    //        public int status { get; set; }
    //        public string wechatId { get; set; }
    //        public string alarmContent { get; set; }
    //        public string gastankid { get; set; }
    //    }

    //    public OutMod Exec()
    //    {

    //        string CmdTxt = "PRO_INDATEBASE";
    //        List<OracleParameter> list = new List<OracleParameter>();
    //        list.Add(new OracleParameter("pi_stationno", this.pi_stationno));
    //        list.Add(new OracleParameter("pi_version", this.pi_version));
    //        list.Add(new OracleParameter("pi_sn", this.pi_sn));
    //        list.Add(new OracleParameter("pi_relayno", this.pi_relayno));
    //        list.Add(new OracleParameter("pi_servicetime", this.pi_servicetime));
    //        list.Add(new OracleParameter("pi_devicetime", this.pi_devicetime));
    //        list.Add(new OracleParameter("pi_devicetype", this.pi_devicetype));
    //        list.Add(new OracleParameter("pi_devicecode", this.pi_devicecode));
    //        list.Add(new OracleParameter("pi_cmdid", this.pi_cmdid));
    //        list.Add(new OracleParameter("pi_content", this.pi_content));
    //        list.Add(new OracleParameter("pi_length", this.pi_length));

    //        list.Add(new OracleParameter("po_resultnum", OracleDbType.Int32, ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_reason", OracleDbType.Varchar2, 520, "", ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_status", OracleDbType.Int32, ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_wechatid", OracleDbType.Varchar2, 520, "", ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_alarmcontent", OracleDbType.Varchar2, 520, "", ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_gastankid", OracleDbType.Varchar2, 520, "", ParameterDirection.Output));

    //        OracleCommand ocm = DB.ExcuteProc(CmdTxt, list.ToArray());
    //        OutMod outmod = new OutMod();

    //        object Result;
    //        Result = ocm.Parameters["po_resultnum"].Value;
    //        if (Result != null && Result.ToString() != "")
    //        {
    //            outmod.resultNum = Convert.ToInt32(Result.ToString());
    //        }
    //        else
    //        {
    //            outmod.resultNum = 1;
    //        }

    //        outmod.reason = ocm.Parameters["po_reason"].Value.ToString();

    //        Result = ocm.Parameters["po_status"].Value;
    //        if (Result != null && Result.ToString() != "" && Result.ToString() != "null")
    //        {
    //            outmod.status = Convert.ToInt32(Result.ToString());
    //        }
    //        else
    //        {
    //            outmod.status = 0;
    //        }

    //        outmod.wechatId = ocm.Parameters["po_wechatid"].Value.ToString();
    //        outmod.alarmContent = ocm.Parameters["po_alarmcontent"].Value.ToString();
    //        outmod.gastankid = ocm.Parameters["po_gastankid"].Value.ToString();

    //        ocm.Parameters.Clear();

    //        return outmod;


    //    }


    //}
}
