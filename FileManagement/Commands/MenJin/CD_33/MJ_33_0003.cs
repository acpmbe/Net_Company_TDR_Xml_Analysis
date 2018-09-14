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
    public class MJ_33_0003 : ICommand
    {

        private ulong _devid;
        private byte[] _content;
        private DateTime _time;
        private string OriginalCode;
        public MJ_33_0003(byte[] _content, ulong _devid, DateTime _time)
        {

            this._devid = _devid;
            this._content = _content;
            this._time = _time;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);

        }
  

        public const string NAME = "刷卡";

       
        public bool Execute()
        {
            try
            {

     
                if (_content.Length < 11)
                {
                    MyLibrary.Log.Debug(NAME + "数据长度无效：原始代码：" + OriginalCode);
                    return true;
                }


                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + this._devid.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                DateTime time = ConverUtil.Time(_content, 0); //设备时间。  
                string CardId = ConverUtil.ByteToStr_4(_content, 6);  //卡Id

                MJInfo info = new MJInfo();
                info.Protocol = "3";
                info.DeviceId = _devid.ToString();
                info.CardId = CardId;
                info.CardType = _content[10].ToString();
                info.IsOpenDoor = "1";
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
