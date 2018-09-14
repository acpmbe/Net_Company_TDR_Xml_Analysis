using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.ChuZuWu.Cd_61504.Dt_0430;

namespace FileManagement.Commands.ChuZuWu.Cd_61504
{
    public class CZW_61504 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        public CZW_61504(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
        }

        public bool Execute()
        {
            int length = 27;
            int count = _content.Length / length;
            byte[] DeviceType;
            string CommandId;
            byte[] content;
            for (int i = 0; i < count; i++)
            {
                DeviceType = new byte[2];
                Array.Copy(_content, 7 + (length * i), DeviceType, 0, 2);           
                CommandId = _content[13 + (i * length)].ToString();
                content = new byte[27];
                Array.Copy(_content, length * i, content, 0, length);            
                ICommand cmd;
                switch (ConverUtil.ByteToStr_A(DeviceType))
                {

                    case "0430":
                        switch (CommandId)
                        {
                            case "1":
                                cmd = new CZW_61504_0430_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61504_0430_02(content, StationId, PlatformTime);
                                break;
                            case "3":
                                cmd = new CZW_61504_0430_03(content, StationId, PlatformTime);
                                break;
                            //case "4":
                            //    cmd = new CZW_61504_0430_04(content, StationId, PlatformTime);  //振川说暂时不用。
                            //    break;
                            //case "5":
                            //    cmd = new CZW_61504_0430_05(content, StationId, PlatformTime);  //振川说暂时不用。
                            //    break;
                            //case "7":
                            //    cmd = new CZW_61504_0430_07(content, StationId, PlatformTime);
                            //    break;
                            //case "8":
                            //    cmd = new CZW_61504_0430_08(content, StationId, PlatformTime);
                            //    break;
                            //case "10":
                            //    cmd = new CZW_61504_0430_10(content, StationId, PlatformTime);
                            //    break;
                            //case "12":
                            //    cmd = new CZW_61504_0430_12(content, StationId, PlatformTime);
                            //    break;
                            //case "14":
                            //    cmd = new CZW_61504_0430_14(content, StationId, PlatformTime);
                            //    break;
                            case "16":
                                cmd = new CZW_61504_0430_16(content, StationId, PlatformTime);
                                break;
                            case "48":
                                cmd = new CZW_61504_0430_48(content, StationId, PlatformTime);
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
