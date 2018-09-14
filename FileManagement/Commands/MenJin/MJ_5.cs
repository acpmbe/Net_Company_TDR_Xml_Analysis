using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal;
using FileManagementUtil;
using FileManagementDal.MenJin;

namespace FileManagement.Commands.MenJin
{
    public class MJ_5 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_5(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "心跳上传";

        public bool Execute()
        {
            try
            {
     
                if (_content.Length < 14)
                {
                    MyLibrary.Log.Debug(NAME + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }
       
                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }
             
                DateTime time = ConverUtil.Time(_content, 0);
                string devstatus = Convert.ToString(_content[6], 2).PadLeft(8, '0');//设备状态[1]     
                //各类型卡库的数量[6]
                int xj_cardNum = (int)(_content[7] << 8 | _content[8]);//协警卡数量[2]
                int fd_cardNum = 1;//(int)(_content[9] << 8 | _content[10]);//房东卡数量[2]
                int yh_cardNum = (int)(_content[11] << 8 | _content[12]);//用户卡数量[2]
                int version = (int)(_content[9] << 8 | _content[10]);//版本号
                int gprs = _content[13];//GPRS信号[1]

                XinTiaoInfo xtInfo = new XinTiaoInfo();
                xtInfo.LISTID = Guid.NewGuid().ToString("N");
                xtInfo.MJDEVICEID = StationId.ToString();          //设备编号
                xtInfo.LASTUPDATETIME = time;                   //更新时间
                xtInfo.EQUIPMENTTIME = time;                    //设备时间
                xtInfo.POLICECARDCOUNT = xj_cardNum.ToString();  //警察卡数
                xtInfo.VERSION = version.ToString();            //版本     
                xtInfo.USERCARDCOUNT = yh_cardNum.ToString();   //用户卡数量
                xtInfo.CARDREADERSTATE = devstatus.Substring(7, 1);  //读卡器状态
                xtInfo.LOCKSTATE = devstatus.Substring(6, 1);        //门锁状态
                xtInfo.SDCARDSTATE = devstatus.Substring(5, 1);     //SD卡状态
                xtInfo.HOARESTATE = devstatus.Substring(4, 1);      //霍尔状态
                xtInfo.POWERSTATE = devstatus.Substring(3, 1);      //电源状态
                xtInfo.CAMERA1STATE = devstatus.Substring(2, 1);    //摄像头1
                xtInfo.CAMERA2STATE = devstatus.Substring(1, 1);    //摄像头2
                xtInfo.MODULE433STATE = devstatus.Substring(0, 1);  //433模块状态

                xtInfo.LASTUPDATETIME_Update = PlatformTime;
                xtInfo.POWERSTATE_Update = (devstatus[3] - 48).ToString();
                xtInfo.CARDREADERSTATE_Update = (devstatus[6] - 48).ToString();
                xtInfo.SDCARDSTATE_Update = (devstatus[4] - 48).ToString();
                xtInfo.SighLevel_Update = gprs.ToString();
                xtInfo.LandroadCardCount_Update = fd_cardNum.ToString();

                MjDal.InsertXinTiao(xtInfo);

               

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码：" + OriginalCode);

            }
            return true;
        }
    }
}
