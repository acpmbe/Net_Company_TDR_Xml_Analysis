using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.QiangZhiGuanKong;


namespace FileManagement.Factory
{
    public class QiangZhiGuanKongFactory : ICommandFactory
    {

        public IXmlFormat xmlFormat { get; set; }
        public QiangZhiGuanKongFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }
        private string Name { get { return "枪支管控"; } }
        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;
           // string CmdId = info.CommandID;
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

                case "177":
                    cmd = new QZGK_177(CmdId,_content, StationId, PlatformTime);
                    break;
                case "178":
                    cmd = new QZGK_178(CmdId, _content, StationId, PlatformTime);
                    break;
                case "61443":
                    cmd = new QZGK_61443(_content, StationId, PlatformTime);
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
