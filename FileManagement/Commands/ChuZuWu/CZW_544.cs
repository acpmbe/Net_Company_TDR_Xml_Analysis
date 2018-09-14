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
    public class CZW_544 : ICommand
    {

        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        private Pro_IndateBase_MJNew_Mod Info;
        public CZW_544(string _cmdId, byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "离线租客授权批量上传"; } }
        public bool Execute()
        {

            try
            {


                if ((_content.Length - 4) % 13 == 0)
                {
                    Info = GetInfo_Old();
                }
                else if ((_content.Length - 10) % 13 == 0)
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
            int Count = (_content.Length - 10) / 13;
            string[] CardTypeArray = new string[Count];  //卡类型数组。
            string[] CardIdArray = new string[Count]; //是身份证或Ic卡数组。
            string[] HouseNumArray = new string[Count];  //房东号数组。
            string[] ActivecArray = new string[Count];  //有源卡数组。
            byte[] Data;
            int IsIdentitycard;
            for (int i = 0; i < Count; i++)
            {
                Data = new byte[13];
                Array.Copy(_content, (i * 13) + 10, Data, 0, 13);
                IsIdentitycard = Convert.ToInt32(Data[0].ToString());
                if (IsIdentitycard >= 128)
                {                 
                    CardTypeArray[i] = Data[4].ToString();
                    CardIdArray[i] = ConverUtil.ByteToStr_4(Data, 5);
                    HouseNumArray[i] = (IsIdentitycard - 128).ToString();
                }
                else
                {           
                    CardTypeArray[i] = "0";
                    CardIdArray[i] = ConverUtil.ByteToStr_Q(Data, 1, 8);
                    HouseNumArray[i] = IsIdentitycard.ToString();
                }
                ActivecArray[i] = ConverUtil.ByteToStr_4(Data, 9);

            }
            info.pi_bigtype = "2";
            info.pi_protocoltype = CmdId;
            info.pi_devicetime = ConverUtil.Time(_content, 0);
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 6);  //门戒Id。
            info.pi_cardtype = ConverUtil.GetArrayToStr(CardTypeArray);
            info.pi_cardid = ConverUtil.GetArrayToStr(CardIdArray);
            info.pi_houseno = ConverUtil.GetArrayToStr(HouseNumArray);
            info.pi_activecardid = ConverUtil.GetArrayToStr(ActivecArray);
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;
        }
        private Pro_IndateBase_MJNew_Mod GetInfo_Old()
        {
            Pro_IndateBase_MJNew_Mod info = new Pro_IndateBase_MJNew_Mod();
            int Count = (_content.Length - 4) / 13;
            string[] CardTypeArray = new string[Count];  //卡类型数组。
            string[] CardIdArray = new string[Count]; //是身份证或Ic卡数组。
            string[] HouseNumArray = new string[Count];  //房东号数组。
            string[] ActivecArray = new string[Count];  //有源卡数组。
            byte[] Data;
            int IsIdentitycard;
            for (int i = 0; i < Count; i++)
            {
                Data = new byte[13];
                Array.Copy(_content, (i * 13) + 4, Data, 0, 13);
                IsIdentitycard = Convert.ToInt32(Data[0].ToString());
                if (IsIdentitycard >= 128)
                {         
                    CardTypeArray[i] = Data[4].ToString();
                    CardIdArray[i] = ConverUtil.ByteToStr_4(Data, 5);
                    HouseNumArray[i] = (IsIdentitycard - 128).ToString();
                }
                else
                {            
                    CardTypeArray[i] = "0";
                    CardIdArray[i] = ConverUtil.ByteToStr_Q(Data, 1, 8);
                    HouseNumArray[i] = IsIdentitycard.ToString();
                }
                ActivecArray[i] = ConverUtil.ByteToStr_4(Data, 9);

            }
            info.pi_bigtype = "2";
            info.pi_protocoltype = CmdId;
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 0);  //门戒Id。
            info.pi_cardtype = ConverUtil.GetArrayToStr(CardTypeArray);
            info.pi_cardid = ConverUtil.GetArrayToStr(CardIdArray);
            info.pi_houseno = ConverUtil.GetArrayToStr(HouseNumArray);
            info.pi_activecardid = ConverUtil.GetArrayToStr(ActivecArray);
            info.pi_devicetime = PlatformTime;
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;
        }
    }
}
