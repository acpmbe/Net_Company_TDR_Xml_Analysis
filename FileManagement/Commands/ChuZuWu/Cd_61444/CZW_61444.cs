using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0406;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0407;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0408;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0409;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_040A;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_040B;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_040C;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_040D;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0417;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0440;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0441;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0480;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0410;
using FileManagement.Commands.ChuZuWu.Cd_61444.Dt_0442;

namespace FileManagement.Commands.ChuZuWu.Cd_61444
{
    public class CZW_61444 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        public CZW_61444(byte[] _content, ulong _StationId, DateTime _PlatformTime)
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
            byte[] content;
            for (int i = 0; i < count; i++)
            {
                DeviceType = new byte[2];
                Array.Copy(_content, 7 + (length * i), DeviceType, 0, 2);
                commandid = _content[13 + (i * length)].ToString();
                content = new byte[19];
                Array.Copy(_content, length * i, content, 0, length);
                ICommand cmd;
                switch (ConverUtil.ByteToStr_A(DeviceType))
                {

                    case "0410":
                        cmd = new CZW_61444_0410(content, StationId, PlatformTime);
                        break;
                    case "0406":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0406_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0406_02(content, StationId, PlatformTime);
                                break;
                            case "4":
                                cmd = new CZW_61444_0406_04(content, StationId, PlatformTime);
                                break;
                            case "10":
                                cmd = new CZW_61444_0406_10(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0407":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0407_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0407_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0408":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0408_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0408_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0409":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0409_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0409_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0480":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0480_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0480_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "040A":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_040A_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_040A_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "040C":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_040C_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_040C_02(content, StationId, PlatformTime);
                                break;
                            case "4":
                                cmd = new CZW_61444_040C_04(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "040D":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_040D_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_040D_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "040B":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_040B_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_040B_02(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0440":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0440_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0440_02(content, StationId, PlatformTime);
                                break;
                            case "3":
                                cmd = new CZW_61444_0440_03(content, StationId, PlatformTime);
                                break;
                            case "4":
                                cmd = new CZW_61444_0440_04(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0441":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0441_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0441_02(content, StationId, PlatformTime);
                                break;
                            case "3":
                                cmd = new CZW_61444_0441_03(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0442":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0442_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0442_02(content, StationId, PlatformTime);
                                break;
                            case "3":
                                cmd = new CZW_61444_0442_03(content, StationId, PlatformTime);
                                break;
                            case "4":
                                cmd = new CZW_61444_0442_04(content, StationId, PlatformTime);
                                break;
                            default:
                                cmd = new IgnoreCommand();
                                break;
                        }
                        break;
                    case "0417":
                        switch (commandid)
                        {
                            case "1":
                                cmd = new CZW_61444_0417_01(content, StationId, PlatformTime);
                                break;
                            case "2":
                                cmd = new CZW_61444_0417_02(content, StationId, PlatformTime);
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
