using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.DengJiJi;
using FileManagement.Commands.DengJiJi.Cd_61443;

namespace FileManagement.Factory
{
    /// <summary>
    /// 登记机工厂
    /// </summary>
    public class DengJiJiFactory: ICommandFactory
    {

        private IXmlFormat xmlFormat;
        public DengJiJiFactory(IXmlFormat xmlFormat)
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
                    cmd = new DJJ_61443(_content, StationId, PlatformTime);
                    break;
                case "2049":
                    cmd = new DJJ_2049(_content, StationId, PlatformTime);
                    break;
                case "2050":
                    cmd = new DJJ_2050(_content, StationId, PlatformTime);
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
