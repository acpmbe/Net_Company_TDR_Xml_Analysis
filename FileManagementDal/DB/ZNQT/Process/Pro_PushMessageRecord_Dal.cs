using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace FileManagementDal.DB.ZNQT.Process
{
    //public class Pro_PushMessageRecord_Dal
    //{
    //    private static DB_ZNQT DB = DB_ZNQT.DB;

    //    #region 字段




    //    /// <summary>
    //    /// 调用类型（推送后调用:1，普通调用:0）
    //    /// </summary>
    //    public string pi_calltype { get; set; }
    //    /// <summary>
    //    /// 推送的微信号
    //    /// </summary>
    //    public string pi_wechatid { get; set; }

    //    /// <summary>
    //    /// 关联的煤气罐ID
    //    /// </summary>
    //    public string pi_gastankid { get; set; }

    //    /// <summary>
    //    /// 消息类型（预警推送:1）
    //    /// </summary>
    //    public string pi_messagetype { get; set; }

    //    /// <summary>
    //    /// 推送的消息内容，对应alarmcontent
    //    /// </summary>
    //    public string pi_message { get; set; }

    //    /// <summary>
    //    /// 消息关联的数据ID 报警对应的是alarmrecordid
    //    /// </summary>
    //    public string pi_sourceid { get; set; }

    //    /// <summary>
    //    /// 推送时间
    //    /// </summary>
    //    public DateTime pi_pushtime { get; set; }

    //    /// <summary>
    //    /// 推送类型：目前只支持（微信:1）
    //    /// </summary>
    //    public string pi_pushtype { get; set; }

    //    /// <summary>
    //    ///推送结果（ 推送成功:1，推送出错:0）
    //    /// </summary>
    //    public string pi_issuccess { get; set; }

    //    /// <summary>
    //    /// 失败原因
    //    /// </summary>
    //    public string pi_failedreseaon { get; set; }

    //    #endregion


    //    public class OutMod
    //    {
    //        public int resultNum { get; set; }
    //        public string reason { get; set; }

    //    }
    //    public OutMod Exec()
    //    {

    //        string CmdTxt = "PRO_PUSHMESSAGERECORD";
    //        List<OracleParameter> list = new List<OracleParameter>();
    //        list.Add(new OracleParameter("pi_calltype", this.pi_calltype));
    //        list.Add(new OracleParameter("pi_wechatid", this.pi_wechatid));
    //        list.Add(new OracleParameter("pi_gastankid", this.pi_gastankid));
    //        list.Add(new OracleParameter("pi_messagetype", this.pi_messagetype));
    //        list.Add(new OracleParameter("pi_message", this.pi_message));
    //        list.Add(new OracleParameter("pi_sourceid", this.pi_sourceid));
    //        list.Add(new OracleParameter("pi_pushtime", this.pi_pushtime));
    //        list.Add(new OracleParameter("pi_pushtype", this.pi_pushtype));
    //        list.Add(new OracleParameter("pi_issuccess", this.pi_issuccess));
    //        list.Add(new OracleParameter("pi_failedreseaon", this.pi_failedreseaon));
    //        list.Add(new OracleParameter("po_resultnum", OracleDbType.Int32, ParameterDirection.Output));
    //        list.Add(new OracleParameter("po_reason", OracleDbType.Varchar2, 520, "", ParameterDirection.Output));
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

    //        ocm.Parameters.Clear();

    //        return outmod;


    //    }

    //}
}
