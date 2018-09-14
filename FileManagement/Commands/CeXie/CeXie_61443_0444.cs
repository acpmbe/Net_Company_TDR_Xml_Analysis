using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.CeXie;
using FileManagementDal.CeXie;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.CeXie
{
    public class CeXie_61443_0444 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CeXie_61443_0444(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime; 
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public string Name
        {
            get { return "测斜"; }
        }


        public bool Execute()
        {

            try
            {

                #region 测斜统计

 
           
                DateTime time = ConverUtil.Time(_content, 0); //设备时间。  
                string ZhongJiId = _content[6].ToString();   //中继号         
                string DeviceType = ConverUtil.ByteToStr_2(_content, 7);     
                string DeviceId = ConverUtil.ByteToStr_4(_content, 9); // 设备Id
                string CommandWord = _content[13].ToString();     //命令字  

                byte[] XAxisAngleValueByte = new byte[2];                                 //X轴值
                Array.Copy(_content, 14, XAxisAngleValueByte, 0, 2);
                string XAxisAngleValue = DataJM.GetAngleValue(ConverUtil.ByteToStr_A(XAxisAngleValueByte));

                byte[] YAxisAngleValueByte = new byte[2];                                 //Y轴值
                Array.Copy(_content, 16, YAxisAngleValueByte, 0, 2);
                string YAxisAngleValue = DataJM.GetAngleValue(ConverUtil.ByteToStr_A(YAxisAngleValueByte));

                string Version = _content[18].ToString();                    //版本号。

                CeXieInfo info = new CeXieInfo();
                info.DeviceTime = time;
                info.DeviceType = DeviceType;
                info.DeviceId = DeviceId;
                info.ProtocolType = CommandWord;
                info.Reserved1 = XAxisAngleValue;
                info.Reserved2 = YAxisAngleValue;
                info.Version = Version;
                info.StationNo = StationId.ToString();
                info.ServiceTime = PlatformTime;
                CeXieDal.AgreementFormat_Insert(info);

                #endregion




                #region 处理后发送短信

                //byte[] timeByte = new byte[6];                                 //设备时间
                //Array.Copy(_content, 0, timeByte, 0, 6);
                //DateTime time = Utils.GetTime(timeByte);
                //string ZhongJiId = _content[6].ToString();                     //中继号
                //byte[] DeviceTypeByte = new byte[2];                           //设备类型
                //Array.Copy(_content, 7, DeviceTypeByte, 0, 2);
                //string DeviceType = Convert.ToUInt64(ConverUtil.ByteToStr_A(DeviceTypeByte), 16).ToString();
                //byte[] DeviceIdByte = new byte[4];                             //设备Id
                //Array.Copy(_content, 9, DeviceIdByte, 0, 4);
                //string DeviceId = Convert.ToUInt64(ConverUtil.ByteToStr_A(DeviceIdByte), 16).ToString();
                //string CommandWord = _content[13].ToString();                  //命令字  

                //byte[] XAxisAngleValueByte = new byte[2];                                 //X轴值
                //Array.Copy(_content, 14, XAxisAngleValueByte, 0, 2);
                //string XAxisAngleValue = Utils.GetAngleValue(ConverUtil.ByteToStr_A(XAxisAngleValueByte));

                //byte[] YAxisAngleValueByte = new byte[2];                                 //Y轴值
                //Array.Copy(_content, 16, YAxisAngleValueByte, 0, 2);
                //string YAxisAngleValue = Utils.GetAngleValue(ConverUtil.ByteToStr_A(YAxisAngleValueByte));

                //string Version = _content[18].ToString();                      //版本号。

                //CeXieInfo info = new CeXieInfo();
                //info.DeviceTime = time;
                //info.DeviceType = DeviceType;
                //info.DeviceId = DeviceId;
                //info.ProtocolType = CommandWord;
                //info.Reserved1 = XAxisAngleValue;
                //info.Reserved2 = YAxisAngleValue;
                //info.Version = Version;
                //info.StationNo = StationId.ToString();
                //info.ServiceTime = PlatformTime;

                //ICeXieDal.Handle(Name, OriginalCode, info);

          



                #endregion
        

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
            }

            return true;

        }
    }
}
