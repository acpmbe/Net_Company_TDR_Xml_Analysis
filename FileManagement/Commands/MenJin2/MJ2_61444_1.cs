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
    public class MJ2_61444_1 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_61444_1(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
   

        public const string NAME = "刷卡成功";
        public bool Execute()
        {
            try
            {

                DateTime DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                string CardType = _content[6].ToString();  //卡类型。
                byte[] CardNum = new byte[8];
                Array.Copy(_content, 7, CardNum, 0, 8);
                string CardId = "";
                if (CardType == "9")
                {
                    CardId = ConverUtil.ByteToStr_A(CardNum);
                }
                else
                {
                    CardId = Convert.ToUInt64(ConverUtil.ByteToStr_A(CardNum), 16).ToString();
                }
                string Identitycard = SFZUtil.ByteToStr(_content, 15); //身份证号码。          
                string HomeNum = _content[24].ToString();   //房东编号
                string RoomNum = ConverUtil.ByteToStr_2(_content, 25);  //房间号。


                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "61444";  //0xF004
                info.pi_devicetime = DeviceTime;
                info.pi_devicecode = StationId.ToString();
                info.pi_protocoltype = "1"; //0x01
                info.pi_cardtype = CardType;
                info.pi_cardid = CardId;
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
