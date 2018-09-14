using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal;
using FileManagement.Commands.HouseAndUserCard;

namespace FileManagement.Commands.HouseAndUserCard
{
    public class HU_3 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;

        public HU_3(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;

        }
        public bool Execute()
        {
            string SubCmd = _content[0].ToString();
            int Length = Convert.ToInt32(ConverUtil.ByteToStr_2(_content, 1));
            byte[] Content = new byte[Length];
            Array.Copy(_content, 3, Content, 0, Length);
            ICommand cmd;
            switch (SubCmd)
            {
                case "1":
                    cmd = new HU_3_1(Content, StationId, PlatformTime);
                    break;
                default:
                    cmd = new IgnoreCommand();
                    break;
            }
            cmd.Execute();
            return true;
        }
    }
}
