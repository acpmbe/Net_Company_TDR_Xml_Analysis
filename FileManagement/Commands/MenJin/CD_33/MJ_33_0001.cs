using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal;
using FileManagementUtil;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal.MenJin;


namespace FileManagement.Commands.MenJin.CD_33
{
    public class MJ_33_0001:ICommand
    {



        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33_0001(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "增卡";
        public bool Execute()
        {
            try
            {
    
                if (_content.Length != 50)
                {
                    MyLibrary.Log.Debug(NAME + "数据长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


            //    DateTime time = ConverUtil.Time(_content, 0); //设备时间。  
              //  string CardId = ConverUtil.ByteToStr_4(_content,6);   //IC卡

                byte[] IdentytyCardNoByte = new byte[9];  //身份证
                Array.Copy(_content, 11, IdentytyCardNoByte, 0, 9);
                string IdCardReplace = ConverUtil.ByteToStr_A(IdentytyCardNoByte).Replace('b', 'B').Replace('c', 'C').Replace('d', 'D').Replace('e', 'E').Replace('f', 'F');
                string IdentytyCardNo = IdCardReplace.Replace('A', 'X').TrimStart('0');

                byte[] phoneByte = new byte[6];  //电话
                Array.Copy(_content, 20, phoneByte, 0, 6);
                string Phone = ConverUtil.ByteToStr_A(phoneByte).Replace("F", "");

                byte[] addressByte = new byte[24];
                Array.Copy(_content, 26, addressByte, 0, 24);
                string UserRoom = BitConverter.ToString(addressByte).Replace("-", "");

                MJInfo info = new MJInfo();
                info.Protocol = "1";
                info.DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                info.CardId = ConverUtil.ByteToStr_4(_content, 6);   //IC卡
                info.CardType = _content[10].ToString();
                info.ChineseName = "";
                info.Identitycard = IdentytyCardNo;
                info.DeviceId = StationId.ToString();

                info.DataIntegrity = string.IsNullOrWhiteSpace(IdentytyCardNo) ? "0" : "1";
                info.UserPhoneNum = Phone;
                info.UserRoom = UserRoom;

                IMjDal.Handle(NAME, OriginalCode, info);


        


            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码：" + OriginalCode);

            }
            return true;
        }
    }
}
