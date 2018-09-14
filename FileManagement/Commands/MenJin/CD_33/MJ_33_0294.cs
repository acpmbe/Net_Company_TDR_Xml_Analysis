using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal.MenJin;

namespace FileManagement.Commands.MenJin.CD_33
{
    public class MJ_33_0294 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33_0294(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "刷IC卡";


        public bool Execute()
        {
            try
            {



                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                DateTime DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                string CardId = ConverUtil.ByteToStr_4(_content, 6);
                string CardType = _content[10].ToString();
                string IsOpenByCard = _content[11].ToString();
                string Identitycard = ConverUtil.ByteToStr_Q(_content, 12, 9);


                MJInfo info = new MJInfo();
                info.Protocol = "660";
                info.DeviceId = StationId.ToString();
                info.DeviceTime = DeviceTime;
                info.CardId = CardId;
                info.CardType = CardType;
                info.IsOpenByCard = IsOpenByCard;
                info.Identitycard = Identitycard;

                IMjDal.Handle(NAME, OriginalCode, info);



            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误；" + ex.Message + " 原始代码：" + OriginalCode);
            }

            return true;
        }
    }
}
