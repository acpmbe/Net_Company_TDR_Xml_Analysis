using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;


namespace FileManagement.Commands.MenJin2
{
    public class MJ2_61444 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;

        public MJ2_61444(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;

        }
        public bool Execute()
        {
            int length = 29;
            int count = _content.Length / length;
            string commandId = "";
            byte[] content;
            for (int i = 0; i < count; i++)
            {

                commandId = _content[i * length].ToString();
                content = new byte[27];
                Array.Copy(_content, 2 + (length * i), content, 0, 27);
                ICommand cmd;
                switch (commandId)
                {

                    case "1":
                        cmd = new MJ2_61444_1(content, StationId, PlatformTime);
                        break;
                    case "2":
                        cmd = new MJ2_61444_2(content, StationId, PlatformTime);
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
