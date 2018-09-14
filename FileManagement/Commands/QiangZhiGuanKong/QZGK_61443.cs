using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.QiangZhiGuanKong;


namespace FileManagement.Commands.QiangZhiGuanKong
{
    public class QZGK_61443:ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        public QZGK_61443(byte[] _content, ulong _StationId, DateTime _PlatformTime)
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

                    case "8040":
                        cmd = new QZGK_61443_8040_01(content, StationId, PlatformTime);               
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
