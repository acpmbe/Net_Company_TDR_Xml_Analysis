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
    public class MJ2_61445_12:ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ2_61445_12(byte[] content, ulong _StationId, DateTime _PlatformTime)
        {

            this.Content = content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }

        public const string Name = "添加用户卡信息（3代）";

        public bool Execute()
        {

            try
            {
 
                MenJinInfo info = new MenJinInfo();
                info.pi_bigtype = "61443";     
                info.pi_devicetime = ConverUtil.Time(Content, 0);                    //设备时间。  
                info.pi_protocoltype = "12";
                info.pi_lordcardtype = Data(Type.房东卡类型, Content);              //房东卡类型。
                info.pi_lordidentitycardid = Data(Type.房东卡身份证ID, Content);    //房东卡身份证ID。
                info.pi_cardtype = Data(Type.E居卡卡类型, Content);                 //E居卡卡类型。
                info.pi_cardid = Data(Type.E居卡卡号, Content);                     //E居卡卡号。
                info.pi_identitycardid = Data(Type.用户身份证ID, Content);          //用户身份证ID。
                info.pi_identitycard = Data(Type.用户身份证号码, Content);          //用户身份证号码。
                info.pi_param2 = Data(Type.用户卡类型, Content);                    //用户卡类型。
                info.pi_param1 = Data(Type.用户卡卡号, Content);                    //用户卡卡号。
                info.pi_houseno = Data(Type.房东编号, Content);                     //房东编号。
                info.pi_roomno = Data(Type.房间号, Content);                        //房间号。
                info.pi_devicecode = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                string Result = IMj2Dal.Insert(info);
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }

        private enum Type
        {
            房东卡类型,
            房东卡身份证ID,
            E居卡卡类型,
            E居卡卡号,
            用户身份证ID,
            用户身份证号码,
            用户卡类型,
            用户卡卡号,
            房东编号,
            房间号
        }

        private string Data(Type type,byte[] content)
        {
            string Str = "";
            string Content ="";
            switch (type)
            {
                case Type.房东卡类型:
                    Str = content[6].ToString();
                    Content = Str != "FF" ? Str : "-1";
                    break;                            
                case Type.房东卡身份证ID:                
                    Str = ConverUtil.ByteToStr_Q(content, 7, 8);
                    Content = Str != "FFFFFFFFFFFFFFFF" ? Str : "-1";
                    break;                                 
                case Type.E居卡卡类型:
                    Str = content[15].ToString();
                    Content = Str != "FF" ? Str : "-1";
                    break;                 
                case Type.E居卡卡号:
                    Str = ConverUtil.ByteToStr_Q(content, 16, 4);
                    Content = Str != "FFFFFFFF" ? ConverUtil.ByteToStr_4(content, 16) : "-1";
                    break;               
                case Type.用户身份证ID:              
                    Str = ConverUtil.ByteToStr_Q(content, 20, 8);
                    Content = Str != "FFFFFFFFFFFFFFFF" ? Str : "-1";
                    break;
                case Type.用户身份证号码:
                    Str = ConverUtil.ByteToStr_Q(content, 28, 9);
                    Content = Str != "FFFFFFFFFFFFFFFFFF" ? SFZUtil.ByteToStr(content, 28) : "-1";                  
                    break;
                case Type.用户卡类型:
                    Str = content[37].ToString();
                    Content = Str != "FF" ? Str : "-1";
                    break;
                case Type.用户卡卡号:
                    Str = ConverUtil.ByteToStr_Q(content, 38, 4);
                    Content = Str != "FFFFFFFF" ? ConverUtil.ByteToStr_4(content, 38) : "-1";             
                    break;
                case Type.房东编号:
                    Str = content[42].ToString();
                    Content = Str != "FF" ? Str : "-1";
                    break;
                case Type.房间号:
                    Str = ConverUtil.ByteToStr_Q(content, 43, 2);
                    Content = Str != "FFFF" ? ConverUtil.ByteToStr_2(content, 43) : "-1";
                    break;
                default:
                    break;
            }
            return Content;
        }

   
    }
}
