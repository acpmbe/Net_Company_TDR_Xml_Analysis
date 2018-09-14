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
    public class MJ_33_0002 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33_0002(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "删卡";


        public bool Execute()
        {
            try
            {
    
                if (_content.Length < 12)
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
                string CardId = ConverUtil.ByteToStr_4(_content,6);  //卡Id

                MJInfo info = new MJInfo();
                info.Protocol = "2";
                info.DeviceId = StationId.ToString();
                info.CardId = CardId;
                info.DeviceTime = time;
                info.CardType = _content[10].ToString();

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
