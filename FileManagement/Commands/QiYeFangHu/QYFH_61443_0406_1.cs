using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal.QiYeFangHu;
using FileManagementDal;

namespace FileManagement.Commands.QiYeFangHu
{
    public class QYFH_61443_0406_1 : ICommand
    {



        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public QYFH_61443_0406_1(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        public string Name
        {
            get { return "企业防护系统_用电管控终端A型心跳上传"; }
        }


        public bool Execute()
        {
            try
            {

            
                DateTime time = ConverUtil.Time(_content, 0); //设备时间。
                string DeviceTypeStr = ConverUtil.ByteToStr_2(_content, 7); //设备类型
                string DeviceIdStr = ConverUtil.ByteToStr_4(_content, 9);  //设备Id

                byte DeviceState = _content[14];  //设备状态       
                string[] BitStr = DataJM.GetBitStr(DeviceState);
                string OpenCloseState = BitStr[0];
                string HLW8012State = BitStr[1];

                string PowerNumStr = _content[15].ToString();  //功率因素    

                string timeStr = time.ToString("yyyy-M-d HH:mm:ss");
                QiYeFangHuDal.Insert_XinTiao(DeviceTypeStr, DeviceIdStr, PowerNumStr, "", timeStr, HLW8012State);

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);

            }

            return true;
        }

    }
}
