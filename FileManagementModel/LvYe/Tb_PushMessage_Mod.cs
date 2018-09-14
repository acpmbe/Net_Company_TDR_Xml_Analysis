using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.LvYe
{
    public class Tb_PushMessage_Mod
    {



        /// <summary>
        /// 推送主键
        /// </summary>
        public string LISTID { get; set; }

        /// <summary>
        /// 推送类型，1：微信号推送，2：短信推送，3,语音推送，4：极光推送
        /// </summary>
        public string PUSHTYPE { get; set; }

        /// <summary>
        /// 推送号码，如手机号
        /// </summary>
        public string PUSHNUMBER { get; set; }

        /// <summary>
        /// 协议命令类型
        /// </summary>
        public string MESSAGETYPE { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string PROTOCOLTYPE { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string MESSAGE { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime PUSHTIME { get; set; }

        /// <summary>
        /// 是否发送成功 1：成功 2：是失败
        /// </summary>
        public string ISSUCCESS { get; set; }

        /// <summary>
        /// 数据来源编号
        /// </summary>
        public string SOURCEID { get; set; }

        /// <summary>
        /// 是否发送至公安，0：未报警，1：发送报警
        /// </summary>
        public string ISALARM { get; set; }

        /// <summary>
        /// 发送失败原因
        /// </summary>
        public string REASON { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string RESERVED1 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string RESERVED2 { get; set; }


        /// <summary>
        /// 预留字段
        /// </summary>
        public string RESERVED3 { get; set; }

        /// <summary>
        /// 预留字段
        /// </summary>
        public string RESERVED4 { get; set; }


    }
}
