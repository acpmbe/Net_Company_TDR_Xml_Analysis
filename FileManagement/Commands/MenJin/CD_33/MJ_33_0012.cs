using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal;
using FileManagementUtil;
using FileManagementDal.MenJin;

namespace FileManagement.Commands.MenJin.CD_33
{
    public class MJ_33_0012 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33_0012(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        public const string NAME = "异常开门";
        public bool Execute()
        {
            try
            {

       
                if (_content.Length < 28)
                {
                    MyLibrary.Log.Debug(NAME + "数据长度无效：原始代码：" + OriginalCode);
                    return true;
                }


                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                DateTime time = ConverUtil.Time(_content, 0); //设备时间。           
                string CardId = ConverUtil.ByteToStr_4(_content, 6);  //卡Id

                byte[] IdentytyCardNoByte = new byte[9];  //身份证
                Array.Copy(_content, 11, IdentytyCardNoByte, 0, 9);
                string IdCardReplace = ConverUtil.ByteToStr_A(IdentytyCardNoByte).Replace('b', 'B').Replace('c', 'C').Replace('d', 'D').Replace('e', 'E').Replace('f', 'F');
                string IdentytyCardNo = IdCardReplace.Replace('A', 'X').TrimStart('0');

                //byte[] phoneByte = new byte[6];  //电话
                //Array.Copy(_content, 20, phoneByte, 0, 6);
                //string phone = ConverUtil.ByteToStr_A(phoneByte).Replace("F", "");

                //byte[] roomIdByte = new byte[2];  //房间Id
                //Array.Copy(_content, 26, roomIdByte, 0, 2);
                MJInfo info = new MJInfo();
                info.Protocol = "18";
                info.DeviceId = StationId.ToString();
                info.CardId = CardId;
                info.CardType = _content[10].ToString();
                info.Identitycard = IdentytyCardNo;
                info.IsOpenDoor = "0";
                info.IsOpenByCard = "1";
                info.DataIntegrity = "0";
                info.DeviceTime = time;

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
