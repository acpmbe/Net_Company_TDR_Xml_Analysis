using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.MenJinShouQuanCommand;

namespace FileManagement.Factory
{
    public class MenJinShouQuanFactory : ICommandFactory
    {       
        public IXmlFormat xmlFormat { get; set; }         
        public MenJinShouQuanFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }
        public ICommand Create(SyncInfo info)
        {
 
            ICommand cmd;        
            string CmdId = info.CommandID;
            byte[] _content = MyLibrary.ConverUtil.StrToBytes(info.Content);
            string _devid = info.EQID;

            switch (CmdId)
            {
                case "0007":
                    cmd = new MenJinKaShouQuanCommand(_devid, _content);
                    break;
                case "0008":
                    cmd = new MenJinKaShanChuCommand(_devid, _content);
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
