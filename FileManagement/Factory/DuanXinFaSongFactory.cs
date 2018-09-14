using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.DuanXinFaSongCommand;

namespace FileManagement.Factory
{
    public class DuanXinFaSongFactory : ICommandFactory
    {
           
        public IXmlFormat xmlFormat { get; set; }         
        public DuanXinFaSongFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }
        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;

            ushort _command = 0;
            byte[] _cmds = MyLibrary.ConverUtil.StrToBytes(info.CommandID);
            _command = (ushort)(_cmds[0] << 8 | _cmds[1]);

            string EQID = info.EQID;
            string Content = info.Content;
          
            DateTime _time;
            DateTime.TryParse(info.Time, out _time);

            switch (_command)
            {
            
                default:
                    cmd = new DuanXinFaSongCommand(EQID, Content, _time);
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
