using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.CeXie;

namespace FileManagement.Factory
{
    public class AgreementFormatFactory : ICommandFactory
    {

        private IXmlFormat xmlFormat;
      
        public AgreementFormatFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;
       
        }
        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;
            ulong StationId = ulong.Parse(info.EQID);
            byte[] _content =MyLibrary.ConverUtil.StrToBytes(info.Content);
           // string CmdId = info.CommandID;
            string CmdId = Config.CmdIdType == "16" ? (Convert.ToInt32(info.CommandID, 16)).ToString() : info.CommandID;
            DateTime PlatformTime;
            if (!DateTime.TryParse(info.Time, out PlatformTime))
            {
                PlatformTime = DateTime.Now;
            }
            switch (CmdId)
            {
                case "61443":
                    cmd = new CeXie_61443(_content, StationId, PlatformTime);
                    break;
                case "66":
                    cmd = new CeXie_66(_content, StationId, PlatformTime);
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
