using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;


namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_531 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_531(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "出租房管理终端_上传刷卡"; } }


        public bool Execute()
        {

            try
            {

                if (_content.Length != 21)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Pro_IndateBase_DZMP_Mod info = new Pro_IndateBase_DZMP_Mod();
                info.pi_bigtype = "2";
                info.pi_protocoltype = "531";
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_cardtype = _content[6].ToString();    //卡类型
                info.pi_cardid = info.pi_cardtype == "0" ? ConverUtil.ByteToStr_Q(_content, 7, 8) : ConverUtil.ByteToStr_4(_content, 11);//设备时间  
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 15);  //设备类型   
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 17); //设备Id                       
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                Other.ChuZuWu.Pro_IndateBase_DZMP_Bll c = new Other.ChuZuWu.Pro_IndateBase_DZMP_Bll(info);
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
    }
}
