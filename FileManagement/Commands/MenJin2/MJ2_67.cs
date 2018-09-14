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
    public class MJ2_67 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_67(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
  

        public const string NAME = "SIM卡上传";
        public bool Execute()
        {

            try
            {
                if (_content.Length != 10)
                {
                    MyLibrary.Log.Debug(NAME + "长度错误：" + " 原始代码:" + OriginalCode);
                    return true;
                }
   
                string SimCardNum = ConverUtil.ByteToStr_Q(_content, 0, 10);   //SIM卡串号

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "67";   //0x0043    
                info.pi_devicetime = PlatformTime;
                info.pi_devicetype = "";
                info.pi_devicecode = StationId.ToString();
                info.pi_param1 = SimCardNum;
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
