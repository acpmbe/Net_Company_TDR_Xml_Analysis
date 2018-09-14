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
    public class CZW_532 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_532(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "出租房管理终端_上传报警"; } }

        public bool Execute()
        {
            try
            {

                if (_content.Length != 11)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Pro_UploadAlarm_Mod info = new Pro_UploadAlarm_Mod();
                info.pi_protocoltype = "532";
                info.pi_devicetime = ConverUtil.Time(_content, 0);            //设备时间
                info.pi_roomnum = ConverUtil.ByteToStr_4(_content, 6);    //房间Id
                info.pi_alarmtype = _content[10].ToString();  //报警类型
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;

                Other.ChuZuWu.Pro_UploadAlarm_Bll c = new Other.ChuZuWu.Pro_UploadAlarm_Bll(info);
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
