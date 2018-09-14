using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_542 : ICommand
    {

        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        private Pro_IndateBase_MJNew_Mod Info;
        public CZW_542(string _cmdId, byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "删除租客授权"; } }
        public bool Execute()
        {

            try
            {
                if(_content.Length ==17)
                {
                    Info = GetInfo_Old();
                }
                else  if(_content.Length ==23)
                {
                    Info = GetInfo_New();

                }
                else
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }


                Other.ChuZuWu.Pro_IndateBase_MJNew_Bll c = new Other.ChuZuWu.Pro_IndateBase_MJNew_Bll(Info);
                string Result = c.Exec();
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

        private Pro_IndateBase_MJNew_Mod GetInfo_New()
        {
            Pro_IndateBase_MJNew_Mod info = new Pro_IndateBase_MJNew_Mod();
            int IsIdentitycard = Convert.ToInt32(_content[22].ToString());   //有无身份证（128：无身份证）          
            string CardType = "";
            string ICCard = "";
            string HouseNum = "";      //房东编号。
            if (IsIdentitycard >= 128)
            {
                CardType = _content[13].ToString();
                ICCard = ConverUtil.ByteToStr_4(_content, 14);  //IC卡。
                HouseNum = (IsIdentitycard - 128).ToString();
            }
            else
            {
                CardType = "0";
                ICCard = ConverUtil.ByteToStr_Q(_content, 10, 8);  //租客身份证。         
                HouseNum = IsIdentitycard.ToString();
            }
            info.pi_bigtype = "2";
            info.pi_devicetime = ConverUtil.Time(_content, 0);
            info.pi_protocoltype = CmdId;
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 6);  //门戒编号。         
            info.pi_cardtype = CardType;
            info.pi_cardid = ICCard;
            info.pi_houseno = HouseNum;
            info.pi_activecardid = ConverUtil.ByteToStr_4(_content, 18);  //有源卡。
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;
        }
        private Pro_IndateBase_MJNew_Mod GetInfo_Old()
        {
           
           
            Pro_IndateBase_MJNew_Mod info = new Pro_IndateBase_MJNew_Mod();
            int IsIdentitycard = Convert.ToInt32(_content[16].ToString());   //有无身份证（128：无身份证）          
            string CardType = "";
            string ICCard = "";
            string HouseNum = "";      //房东编号。
            if (IsIdentitycard >= 128)
            {
                CardType = _content[7].ToString();
                ICCard = ConverUtil.ByteToStr_4(_content, 8);  //IC卡。
                HouseNum = (IsIdentitycard - 128).ToString();
            }
            else
            {
                CardType = "0";
                ICCard = ConverUtil.ByteToStr_Q(_content, 4, 8);  //租客身份证。         
                HouseNum = IsIdentitycard.ToString();
            }
            info.pi_bigtype = "2";
            info.pi_protocoltype = CmdId;
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 0);  //门戒ID。
            info.pi_devicetime = PlatformTime;
            info.pi_cardtype = CardType;
            info.pi_cardid = ICCard;
            info.pi_houseno = HouseNum;
            info.pi_activecardid = ConverUtil.ByteToStr_4(_content, 12);  //有源卡。
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;

        }
    }
}
