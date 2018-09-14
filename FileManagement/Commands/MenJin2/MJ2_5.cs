using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin2;
using FileManagementUtil;
using FileManagementDal.MenJin2;
using FileManagementDal;

namespace FileManagement.Commands.MenJin2
{
    public class MJ2_5 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_5(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

   
        public const string NAME = "门禁2.0心跳";

        public bool Execute()
        {

            try
            {
                if (_content.Length != 9)
                {

                    MyLibrary.Log.Debug(NAME + "长度错误：" + " 原始代码:" + OriginalCode);
                    return true;
                }

                DateTime DeviceTime = ConverUtil.Time(_content, 0);   //设备时间
                string VersionNum = ConverUtil.ByteToStr_2(_content, 6);  //版本号
                string SignalStrength = _content[8].ToString();   //信号强度

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "5";  //0x0005
                info.pi_devicetime = DeviceTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_protocoltype = "";
                info.pi_version = VersionNum;
                info.pi_param1 = SignalStrength;
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
