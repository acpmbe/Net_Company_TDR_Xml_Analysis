using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.QiYeFangHu;

namespace FileManagement.Commands.QiYeFangHu
{
    public class QYFH_61443 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;

        public QYFH_61443(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;

        }
        public bool Execute()
        {
            int length = 19;
            int count = _content.Length / length;
            byte[] DeviceType;
            string commandid;
            byte[] SubContent;
            for (int i = 0; i < count; i++)
            {
                DeviceType = new byte[2];
                Array.Copy(_content, 7 + length * i, DeviceType, 0, 2);
                commandid = _content[13 + i * length].ToString();
                SubContent = new byte[19];
                Array.Copy(_content, length * i, _content, 0, length);
                ICommand cmd;
                switch (ConverUtil.ByteToStr_A(DeviceType))
                {
                    case "0406":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new QYFH_61443_0406_1(SubContent, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0600":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new QYFH_61443_0600_1(SubContent, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0601":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new QYFH_61443_0601_1(SubContent, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0602":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new QYFH_61443_0602_1(SubContent, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    default:
                        cmd = new IgnoreCommand();
                        break;
                }
                cmd.Execute();
            }
            return true;
        }
    }
}
