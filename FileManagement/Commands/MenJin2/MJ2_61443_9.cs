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
    public class MJ2_61443_9 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_61443_9(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
  

        public const string NAME = "替换一级房东卡";
        public bool Execute()
        {

            try
            {


                DateTime DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                string RoomCardType = _content[6].ToString();  //房卡类型。
                string OldIdentitycardId = ConverUtil.ByteToStr_Q(_content, 7, 8); //原身份证Id.
                string NewCardType = _content[15].ToString();  //房卡类型。
                string NewIdentitycardId = ConverUtil.ByteToStr_Q(_content, 16, 8); //新身份证Id.
                string NewIdentitycard = SFZUtil.ByteToStr(_content, 24);  //新身份证。

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "61443";  //0xF003
                info.pi_devicetime = DeviceTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_protocoltype = "9"; //0x01
                info.pi_lordcardtype = RoomCardType;
                info.pi_lordidentitycardid = OldIdentitycardId;
                info.pi_cardtype = NewCardType;
                info.pi_identitycardid = NewIdentitycardId;
                info.pi_identitycard = NewIdentitycard;
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
