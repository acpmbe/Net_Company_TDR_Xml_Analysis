using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;

namespace FileManagement.Commands.CeXie
{
    public class CeXie_61443 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;

        public CeXie_61443(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;

        }
        public bool Execute()
        {
            try
            {

                int length = 19;
                int count = _content.Length / length;
                byte[] DeviceType;
                byte[] content;
                for (int i = 0; i < count; i++)
                {
                    DeviceType = new byte[2];
                    Array.Copy(_content, 7 + length * i, DeviceType, 0, 2);
                    content = new byte[19];
                    Array.Copy(_content, length * i, content, 0, length);
                    ICommand cmd;
                    switch (ConverUtil.ByteToStr_A(DeviceType))
                    {
                        case "0444":
                            cmd = new CeXie_61443_0444(content, StationId, PlatformTime);
                            break;
                        default:
                            cmd = new IgnoreCommand();
                            break;
                    }
                    cmd.Execute();
                }


            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error("处理协议格式命令错误：" + ex.Message);
            }

            return true;
        }
    }
}
