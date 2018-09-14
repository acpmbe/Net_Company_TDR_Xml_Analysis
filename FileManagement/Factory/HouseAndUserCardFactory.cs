using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.HouseAndUserCard;

namespace FileManagement.Factory
{
    public class HouseAndUserCardFactory : ICommandFactory
    {

        private IXmlFormat xmlFormat;
        public HouseAndUserCardFactory(IXmlFormat xmlFormat)
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

                case "3":
                    cmd = new HU_3(_content, StationId, PlatformTime);
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
