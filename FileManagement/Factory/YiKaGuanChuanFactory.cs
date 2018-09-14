using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Commands.YiKaGuanChuan;
using FileManagementUtil;


namespace FileManagement.Factory
{
    public class YiKaGuanChuanFactory : ICommandFactory
    {
        public IXmlFormat xmlFormat { get; set; }
        public YiKaGuanChuanFactory(IXmlFormat xmlFormat)
        {
            this.xmlFormat = xmlFormat;

        }

        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;
            string CmdId = Config.CmdIdType == "16" ? (Convert.ToInt32(info.CommandID, 16)).ToString() : info.CommandID;
            byte[] _content=null;
            string Content="";
            if (CmdId != "2_1")
            {
                _content = MyLibrary.ConverUtil.StrToBytes(info.Content.Trim().Replace(" ", ""));
            }
            else
            {
                Content = info.Content.Trim().Replace(" ", "");
            }
           
            ulong StationId = ulong.Parse(info.EQID);
            DateTime PlatformTime;
            if (!DateTime.TryParse(info.Time, out PlatformTime))
            {
                PlatformTime = DateTime.Now;
            }
            switch (CmdId)
            {
                case "1":
                    cmd = new YKGC_01(_content, StationId, PlatformTime);
                    break;
                case "2":
                    cmd = new YKGC_02(_content, StationId, PlatformTime);
                    break;
                case "2_1": //处理下发形成的Xml文件。
                    cmd = new YKGC_02_01(Content, StationId, PlatformTime);
                    break;
                case "64":
                    cmd = new YKGC_64(_content, StationId, PlatformTime);
                    break;
                case "121":
                    cmd = new YKGC_121(_content, StationId, PlatformTime);
                    break;
                //case "129":
                //    cmd = new YKGC_129(_content, StationId, PlatformTime);
                //    break;
                case "61446":
                    cmd = new YKGC_61446(_content, StationId, PlatformTime);
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
