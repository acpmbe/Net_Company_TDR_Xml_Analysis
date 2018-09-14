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
    public class MJ2_23 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_23(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
  

        public const string NAME = "设备防拆报警上传";
        public bool Execute()
        {

            try
            {

                if (_content.Length != 1)
                {
                    MyLibrary.Log.Debug(NAME + "长度错误：" + " 原始代码:" + OriginalCode);
                    return true;
                }
                string AlarmState = _content[0].ToString();  //报警状态

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "23";  //0x0017    
                info.pi_devicetime = PlatformTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_param1 = AlarmState;
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
