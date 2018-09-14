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
    public class CZW_524 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_524(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "出租房管理终端_上传租客1"; } }
        public bool Execute()
        {

            try
            {

                if (_content.Length != 38)
                {
                  
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }



                Pro_IndateBase_DZMP_Mod info = new Pro_IndateBase_DZMP_Mod();
                info.pi_bigtype = "2";
                info.pi_devicetype = "1029";
                info.pi_protocoltype = "524";
                info.pi_devicetime = ConverUtil.Time(_content, 32);  //设备时间         
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 0);  //电子门牌ID
                info.pi_lordidentitycardid = ConverUtil.ByteToStr_Q(_content, 4, 8); //房东身份证ID
                info.pi_identitycardid = ConverUtil.ByteToStr_Q(_content, 12, 8); //租客身份证ID
                info.pi_cardid = ConverUtil.ByteToStr_4(_content, 20); // e居住卡ID
                info.pi_activecardid = ConverUtil.ByteToStr_4(_content, 24);  // 有源卡ID
                info.pi_roomno = ConverUtil.ByteToStr_4(_content, 28); // 房间ID
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
