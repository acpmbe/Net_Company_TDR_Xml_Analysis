using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.MenJin2;

namespace FileManagement.Commands.MenJin2
{
    public class MJ2_61443 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;

        public MJ2_61443(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;

        }
        public bool Execute()
        {
            int length = 42;
            int count = _content.Length / length;
            string commandId = "";
            byte[] content;
            for (int i = 0; i < count; i++)
            {
                commandId = _content[i * length].ToString();
                content = new byte[40];
                Array.Copy(_content, 2 + (length * i), content, 0, 40);
                ICommand cmd;
                switch (commandId)
                {

                    case "1":
                        cmd = new MJ2_61443_1(content, StationId, PlatformTime);
                        break;
                    case "2":
                        cmd = new MJ2_61443_2(content, StationId, PlatformTime);
                        break;
                    case "3":
                        cmd = new MJ2_61443_3(content, StationId, PlatformTime);
                        break;
                    case "4":
                        cmd = new MJ2_61443_4(content, StationId, PlatformTime);
                        break;
                    case "5":
                        cmd = new MJ2_61443_5(content, StationId, PlatformTime);
                        break;
                    case "6":
                        cmd = new MJ2_61443_6(content, StationId, PlatformTime);
                        break;
                    case "7":
                        cmd = new MJ2_61443_7(content, StationId, PlatformTime);
                        break;
                    case "8":
                        cmd = new MJ2_61443_8(content, StationId, PlatformTime);
                        break;
                    case "9":
                        cmd = new MJ2_61443_9(content, StationId, PlatformTime);
                        break;
                    case "10":
                        cmd = new MJ2_61443_10(content, StationId, PlatformTime);
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
