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
    public class QYFH_61443_0602_1 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public QYFH_61443_0602_1(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public string Name
        {
            get { return "企业防护系统_粉尘检测器心跳上传"; }
        }
        public bool Execute()
        {
            try
            {
               
                DateTime time = ConverUtil.Time(_content, 0); //设备时间。 
                string DeviceTypeStr = ConverUtil.ByteToStr_2(_content, 7); //设备类型     
                string DeviceIdStr = ConverUtil.ByteToStr_4(_content, 9); // 设备Id
                string DeviceStateStr = _content[14].ToString();//设备状态
                string DustConcentrationStr = ConverUtil.ByteToStr_2(_content, 16); //粉尘浓度
                string timeStr = time.ToString("yyyy-M-d HH:mm:ss");

                QiYeFangHuDal.Insert_XinTiao(DeviceTypeStr, DeviceIdStr, DustConcentrationStr, "", timeStr, DeviceStateStr);

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);

            }

            return true;
        }
    }
}
