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
    public class MJ2_61443_8 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_61443_8(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
   

        public const string NAME = "删卡（身份证号）";


        public bool Execute()
        {

            try
            {


                DateTime DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                string HomeCardType = _content[6].ToString();  //房东卡类型。
                string HomeIdentitycardId = ConverUtil.ByteToStr_Q(_content, 7, 8); //房东身份证Id.
                string CardType = _content[15].ToString();  //卡类型。
                string Identitycard = SFZUtil.ByteToStr(_content, 16); //身份证。
                string HomeNum = _content[25].ToString();  //房东编号。
                string RoomNum = ConverUtil.ByteToStr_2(_content, 26);  //房间号。

                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "61443";  //0xF003
                info.pi_devicetime = DeviceTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_protocoltype = "8"; //0x01
                info.pi_lordcardtype = HomeCardType;
                info.pi_lordidentitycardid = HomeIdentitycardId;
                info.pi_cardtype = CardType;
                info.pi_identitycard = Identitycard;
                info.pi_houseno = HomeNum;
                info.pi_roomno = RoomNum;
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
