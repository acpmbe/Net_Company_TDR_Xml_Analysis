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
    public class MJ2_25 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_25(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

    
        public const string NAME = "手机MAC地址数据上传";

        public bool Execute()
        {

            try
            {
                int length = 12;
                int count = _content.Length / length;
                DateTime DeviceTime;
                string MacAddress = "";
                for (int i = 0; i < count; i++)
                {
                    DeviceTime = ConverUtil.Time(_content, i * length); //设备时间。
                    MacAddress = ConverUtil.ByteToStr_Q(_content, 6 + (i * length), 6);   //Mac地址。 

                    MenJinInfo info = new MenJinInfo();
                    info.pi_bigtype = "61446";  //0xF006
                    info.pi_devicetime = DeviceTime;
                    info.pi_devicecode = StationId.ToString();
                    info.pi_param1 = MacAddress;
                    info.pi_servicetime = PlatformTime;
                    string Result = IMj2Dal.Insert(info);
                    if (Result != "0")
                    {
                        MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                    }

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
