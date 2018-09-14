using FileManagementUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Commands.MenJin;
using FileManagement.Commands.MenJin.CD_33;


namespace FileManagement
{
    public class WxmjCommandFactory : ICommandFactory
    {

        private IXmlFormat xmlFormat;
        public WxmjCommandFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }
        public ICommand Create(SyncInfo info)
        {

            ICommand cmd;
           // string CmdId = info.CommandID;
            string CmdId = Config.CmdIdType == "16" ? (Convert.ToInt32(info.CommandID, 16)).ToString() : info.CommandID;
            ulong _devid = ulong.Parse(info.EQID);
            byte[] _content = MyLibrary.ConverUtil.StrToBytes(info.Content);
            DateTime _time;
            if (!DateTime.TryParse(info.Time, out _time))
            {
                _time = DateTime.Now;
            }
            switch (CmdId)
            {

                case "5":
                    cmd = new MJ_5(_content, _devid, _time); //放到新的生成XML程序里Heartbeat_COL
                    break;
                case "33":
                    cmd = new MJ_33(_content, _devid, _time);
                    break;
                case "67":
                    cmd = new MJ_67(_content, _devid, _time);  //放到新的生成XML程序里SIMSN_COL
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
