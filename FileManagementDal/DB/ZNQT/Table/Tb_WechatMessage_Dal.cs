using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementDal.DB.ZNQT.Table
{
    //public class Tb_WechatMessage_Dal
    //{


    //    #region 字段
    //    /// <summary>
    //    /// 主键
    //    /// </summary>
    //    public string LISTID { get; set; }

    //    /// <summary>
    //    /// 用户ID
    //    /// </summary>
    //    public string USERID { get; set; }

    //    /// <summary>
    //    /// 煤气罐ID
    //    /// </summary>
    //    public string GASTANKID { get; set; }

    //    /// <summary>
    //    /// 微信号
    //    /// </summary>
    //    public string WECHATID { get; set; }

    //    /// <summary>
    //    /// 信息类型（报警信息:1）
    //    /// </summary>
    //    public string MESSAGETYPE { get; set; }

    //    /// <summary>
    //    /// 消息内容
    //    /// </summary>
    //    public string MESSAGE { get; set; }

    //    /// <summary>
    //    /// 数据来源编号
    //    /// </summary>
    //    public string SOURCEID { get; set; }

    //    /// <summary>
    //    /// 推送时间
    //    /// </summary>
    //    public DateTime PUSHTIME { get; set; }

    //    /// <summary>
    //    /// 推送次数
    //    /// </summary>
    //    public string PUSHCNT { get; set; }

    //    /// <summary>
    //    /// 推送结果（成功:1，出错:0）
    //    /// </summary>
    //    public string ISSUCCESS { get; set; }

    //    /// <summary>
    //    /// 推送类型（微信号推送(默认):1，短信推送:2，语音推送:3，极光推送:4）
    //    /// </summary>
    //    public string PUSHTYPE { get; set; }

    //    /// <summary>
    //    /// 推送失败原因
    //    /// </summary>
    //    public string FAILEDRESEAON { get; set; }

    //    #endregion


    //    private static DB_ZNQT DB = DB_ZNQT.DB;


    //    public bool Insert()
    //    {
    //        string sql = @"INSERT INTO TB_WECHATMESSAGE
    //                        (LISTID, USERID, GASTANKID, WECHATID, MESSAGETYPE, MESSAGE, SOURCEID, 
    //                         PUSHTIME, PUSHCNT, ISSUCCESS, PUSHTYPE, FAILEDRESEAON)
    //                       VALUES
    //                        (:LISTID, :USERID, :GASTANKID, :WECHATID, :MESSAGETYPE, :MESSAGE,
    //                         :SOURCEID, :PUSHTIME, :PUSHCNT, :ISSUCCESS, :PUSHTYPE, :FAILEDRESEAON)";
    //        List<OracleParameter> paramList = new List<OracleParameter>();
    //        paramList.Add(new OracleParameter("LISTID", this.LISTID));
    //        paramList.Add(new OracleParameter("USERID", this.USERID));
    //        paramList.Add(new OracleParameter("GASTANKID", this.GASTANKID));
    //        paramList.Add(new OracleParameter("WECHATID", this.WECHATID));
    //        paramList.Add(new OracleParameter("MESSAGETYPE", this.MESSAGETYPE));
    //        paramList.Add(new OracleParameter("MESSAGE", this.MESSAGE));
    //        paramList.Add(new OracleParameter("SOURCEID", this.SOURCEID));
    //        paramList.Add(new OracleParameter("PUSHTIME", this.PUSHTIME));
    //        paramList.Add(new OracleParameter("PUSHCNT", this.PUSHCNT));
    //        paramList.Add(new OracleParameter("ISSUCCESS", this.ISSUCCESS));
    //        paramList.Add(new OracleParameter("PUSHTYPE", this.PUSHTYPE));
    //        paramList.Add(new OracleParameter("FAILEDRESEAON", this.FAILEDRESEAON));
    //        return DB.ExecuteNonQuery(sql, paramList.ToArray()) > 0;
    //    }


    //}
}
