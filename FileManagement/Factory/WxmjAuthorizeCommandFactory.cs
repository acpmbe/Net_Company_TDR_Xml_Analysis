
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public class WxmjAuthorizeCommandFactory : ICommandFactory
    {
        private IXmlFormat xmlFormat;

        public WxmjAuthorizeCommandFactory(IXmlFormat xmlFormat)
        {
            // TODO: Complete member initialization
            this.xmlFormat = xmlFormat;
        }
        public ICommand Create(SyncInfo info)
        {
            throw new NotImplementedException();
        }


        public List<ICommand> GetCommands()
        {
            List<ICommand> cmds = new List<ICommand>();
          //  cmds.Add(new SheBeiKaXinXiCommand(xmlFormat.GetSyncInfo()));
            return cmds;
        }
    }
}
