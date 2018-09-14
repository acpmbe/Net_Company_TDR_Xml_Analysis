using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Commands.JingXie;
using FileManagementUtil;

namespace FileManagement.Factory
{
 public   class JingXieFactory: ICommandFactory
    {

        public IXmlFormat xmlFormat { get; set; }
        public JingXieFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }

        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;
            string CmdId = Config.CmdIdType == "16" ? (Convert.ToInt32(info.CommandID, 16)).ToString() : info.CommandID;
            byte[] _content = MyLibrary.ConverUtil.StrToBytes(info.Content);
            ulong StationId = ulong.Parse(info.EQID);
            DateTime PlatformTime;
            if (!DateTime.TryParse(info.Time, out PlatformTime))
            {
                PlatformTime = DateTime.Now;
            }
            switch (CmdId)
            {
                case "61443":
                    cmd = new JX_61443(_content, StationId, PlatformTime);
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
