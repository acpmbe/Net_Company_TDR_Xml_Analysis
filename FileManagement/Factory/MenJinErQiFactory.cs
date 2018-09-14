using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.MenJin2;

namespace FileManagement.Factory
{
    public class MenJinErQiFactory : ICommandFactory
    {

    
        private IXmlFormat xmlFormat;
        public MenJinErQiFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }
        public ICommand Create(SyncInfo info)
        {


            ICommand cmd;
           // string CmdId = info.CommandID;
            string CmdId = Config.CmdIdType == "16" ? (Convert.ToInt32(info.CommandID, 16)).ToString() : info.CommandID;
            ulong StationId = ulong.Parse(info.EQID);
            byte[] _content = MyLibrary.ConverUtil.StrToBytes(info.Content);
            DateTime PlatformTime;
            if (!DateTime.TryParse(info.Time, out PlatformTime))
            {
                PlatformTime = DateTime.Now;
            }
            switch (CmdId)
            {

                case "5":
                    cmd = new MJ2_5(_content, StationId, PlatformTime);
                    break;
                case "67":
                    cmd = new MJ2_67(_content, StationId, PlatformTime);
                    break;
                case "61443":
                    cmd = new MJ2_61443(_content, StationId, PlatformTime);
                    break;
                case "61444":
                    cmd = new MJ2_61444(_content, StationId, PlatformTime);
                    break;
                case "61445":
                    cmd = new MJ2_61445(_content, StationId, PlatformTime);
                    break;
                case "22":
                    cmd = new MJ2_22(_content, StationId, PlatformTime);
                    break;
                case "23":
                    cmd = new MJ2_23(_content, StationId, PlatformTime);
                    break;
                case "61446":
                    cmd = new MJ2_61446(_content, StationId, PlatformTime);
                    break;
                case "25":
                    cmd = new MJ2_25(_content, StationId, PlatformTime);
                    break;
                default:
                    cmd = new IgnoreCommand();
                    break;
            }
            return cmd;
        }

        public List<ICommand> GetCommands()
        {
            List<ICommand> cmds = new List<ICommand>();
            foreach (var info in xmlFormat.GetSyncInfo())
            {
                cmds.Add(Create(info));
            }
            return cmds;
        }
    }
}
