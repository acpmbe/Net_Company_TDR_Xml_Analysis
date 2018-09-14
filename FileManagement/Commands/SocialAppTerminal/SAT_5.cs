using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal;
using FileManagementUtil;
using FileManagementModel.SocialAppTerminal;

namespace FileManagement.Commands.SocialAppTerminal
{
    public class SAT_5 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public SAT_5(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        public string Name
        {
            get { return "心跳"; }
        }
        public bool Execute()
        {
            try
            {

                byte[] Data;
                Data = new byte[4];
                Array.Copy(_content, 6, Data, 0, 4);
                string SoftVersion = Version(Data);

                Data = new byte[4];
                Array.Copy(_content, 10, Data, 0, 4);
                string HardwareVersion = Version(Data);

                Tb_LKCommunity_Mod info = new Tb_LKCommunity_Mod();
                info.DeviceTime = ConverUtil.Time(_content, 0);       //设备时间。 
                info.LastUpdateTime = DateTime.Now;                  //最后更新时间。
                info.DeviceId = StationId.ToString();                //设备Id。
                info.SoftVersion = SoftVersion;                      //软件版本号。
                info.HardwareVersion = HardwareVersion;              //硬件版本号。
                info.Signal = _content[14].ToString();               //信号强度。

                FileManagementDal.SocialAppTerminal.Tb_LKCommunity_Dal.Update(info);

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

        private string Version(byte[] content)
        {

            return content[0].ToString() + "." + content[1] + "." + content[2];

        }
    }
}
