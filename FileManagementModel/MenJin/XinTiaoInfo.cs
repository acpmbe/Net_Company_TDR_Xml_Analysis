using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.MenJin
{
    public class XinTiaoInfo
    {

        public string LISTID { get; set; }  //guid
        public string MJDEVICEID { get; set; }  //门禁设备编号
        public DateTime LASTUPDATETIME { get; set; }  //更新时间
        public DateTime LASTUPDATETIME_Update { get; set; }  //插入平台时间
        public string SighLevel_Update { get; set; } //Gprs信号。
        public string LandroadCardCount_Update { get; set; } //房东卡数量。    
        public DateTime EQUIPMENTTIME { get; set; }  //设备时间
        public string USERCARDCOUNT { get; set; } //用户卡数量
        public string POLICECARDCOUNT { get; set; }   //警察卡数
        public string VERSION { get; set; }   //版本           
        public string CARDREADERSTATE { get; set; }  //读卡器状态（1、正常，2：故障）
        public string CARDREADERSTATE_Update { get; set; }  //读卡器状态（1、正常，2：故障）
        public string LOCKSTATE { get; set; }   //门锁状态（0:开门1：关门）
        public string SDCARDSTATE { get; set; }  //SD卡状态（1、有卡，2、无卡）
        public string SDCARDSTATE_Update { get; set; }  //SD卡状态（1、有卡，2、无卡）
        public string HOARESTATE { get; set; }   //霍尔状态（0:正常1：异常）
        public string POWERSTATE { get; set; }  //电源状态(1、电源供电、2：电池供电)
        public string POWERSTATE_Update { get; set; }  //电源状态(1、电源供电、2：电池供电)
        public string CAMERA1STATE { get; set; }  //摄像头1（0:连接1：断开）
        public string CAMERA2STATE { get; set; }  //摄像头2（0:连接1：断开）
        public string MODULE433STATE { get; set; }  //433模块状态（0:正常1：异常）
       

    }
}
