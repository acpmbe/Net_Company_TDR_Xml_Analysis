using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin2;
using FileManagementUtil;
using FileManagementDal;
using FileManagementDal.MenJin2;

namespace FileManagement.Commands.MenJin2
{
    public class MJ2_22 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_22(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
   

        public const string NAME = "锁防盗报警心跳上传";
        public bool Execute()
        {

            try
            {

                if (_content.Length != 6)
                {
                    MyLibrary.Log.Debug(NAME + "长度错误：" + " 原始代码:" + OriginalCode);
                    return true;
                }

                string DoorState = _content[0].ToString();   //门状态。
                string DoorOpenTime = ConverUtil.ByteToStr_2(_content,1); //门敞开时间。
                string LookSpeedState = _content[3].ToString();   //锁加速度状态。
                string BigChangeValue = ConverUtil.ByteToStr_2(_content, 4); //最大变哈值。

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "22";  //0x0016      
                info.pi_devicetime = PlatformTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_param1 = DoorState;
                info.pi_param2 = DoorOpenTime;
                info.pi_param3 = LookSpeedState;
                info.pi_param4 = BigChangeValue;
                info.pi_servicetime = PlatformTime;
                string Result = IMj2Dal.Insert(info);
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;

        }
    }
}
