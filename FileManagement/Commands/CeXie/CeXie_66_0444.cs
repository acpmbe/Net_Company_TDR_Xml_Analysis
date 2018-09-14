using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.CeXie;
using FileManagementDal.CeXie;
using FileManagementUtil;
using FileManagementModel;
using FileManagementDal;

namespace FileManagement.Commands.CeXie
{
    public class CeXie_66_0444 : ICommand
    {

         private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CeXie_66_0444(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "测斜"; } }

        public bool Execute()
        {

            try
            {


                byte[] DeviceTypeByte = new byte[2];                           //设备类型
                Array.Copy(_content, 1, DeviceTypeByte, 0, 2);
                string DeviceType = Convert.ToUInt16(ConverUtil.ByteToStr_A(DeviceTypeByte), 16).ToString();

                byte[] DeviceIdByte = new byte[4];                             //设备Id
                Array.Copy(_content, 3, DeviceIdByte, 0, 4);
                string DeviceId = Convert.ToUInt32(ConverUtil.ByteToStr_A(DeviceIdByte), 16).ToString();

                string CommandWord = _content[7].ToString();                  //命令字  

                byte[] XAxisAngleValueByte = new byte[2];                                 //X轴值
                Array.Copy(_content, 8, XAxisAngleValueByte, 0, 2);
                string XAxisAngleValue = DataJM.GetAngleValue(ConverUtil.ByteToStr_A(XAxisAngleValueByte));

                byte[] YAxisAngleValueByte = new byte[2];                                 //Y轴值
                Array.Copy(_content, 10, YAxisAngleValueByte, 0, 2);
                string YAxisAngleValue = DataJM.GetAngleValue(ConverUtil.ByteToStr_A(YAxisAngleValueByte));

                string Version = _content[12].ToString();                      //版本号。

                CeXieInfo info = new CeXieInfo();
                info.DeviceTime = DateTime.Now;
                info.DeviceType = DeviceType;
                info.DeviceId = DeviceId;
                info.ProtocolType = CommandWord;
                info.Reserved1 = XAxisAngleValue;
                info.Reserved2 = YAxisAngleValue;         
                info.Version = Version;
                info.StationNo = StationId.ToString();
                info.ServiceTime = PlatformTime;

                ICeXieDal.Handle(Name, OriginalCode, info);

             
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
            }

            return true;
        }
    }
}
