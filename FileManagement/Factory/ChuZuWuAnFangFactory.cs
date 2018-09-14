using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.ChuZuWu;
using FileManagement.Commands.ChuZuWu.Cd_61444;
using FileManagement.Commands.ChuZuWu.Cd_61504;
using FileManagement.Commands.ChuZuWu.Cd_61506;



namespace FileManagement.Factory
{
    public class ChuZuWuAnFangFactory : ICommandFactory
    {
        public IXmlFormat xmlFormat { get; set; }
        public ChuZuWuAnFangFactory(IXmlFormat xmlFormat)
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

                case "61444":
                    cmd = new CZW_61444(_content, StationId, PlatformTime);
                    break;
                case "61443":
                    cmd = new CZW_61444(_content, StationId, PlatformTime);
                    break;
                case "61504":
                    cmd = new CZW_61504(_content, StationId, PlatformTime);
                    break;
                case "61506":
                    cmd = new CZW_61506(_content, StationId, PlatformTime);
                    break;
                case "2":
                    cmd = new CZW_2_Bll(_content, StationId, PlatformTime);
                    break;
                case "23":
                    cmd = new CZW_23(_content, StationId, PlatformTime);
                    break;
                case "33":
                    cmd = new CZW_33(_content, StationId, PlatformTime);
                    break;
                case "518":
                    cmd = new CZW_518(_content, StationId, PlatformTime);
                    break;
                case "519":
                    cmd = new CZW_519(_content, StationId, PlatformTime);
                    break;
                case "521":
                    cmd = new CZW_521(_content, StationId, PlatformTime);
                    break;
                case "522":
                    cmd = new CZW_522(_content, StationId, PlatformTime);
                    break;
                case "524":
                    cmd = new CZW_524(_content, StationId, PlatformTime);
                    break;
                case "526":
                    cmd = new CZW_526(_content, StationId, PlatformTime);
                    break;
                case "529":
                    cmd = new CZW_529(_content, StationId, PlatformTime);
                    break;
                case "531":
                    cmd = new CZW_531(_content, StationId, PlatformTime);
                    break;
                case "532":
                    cmd = new CZW_532(_content, StationId, PlatformTime);
                    break;
                case "538":
                    cmd = new CZW_538(CmdId, _content, StationId, PlatformTime);
                    break;
                case "539":
                    cmd = new CZW_539(CmdId, _content, StationId, PlatformTime);
                    break;
                case "540":
                    cmd = new CZW_540(CmdId, _content, StationId, PlatformTime);
                    break;
                case "541":
                    cmd = new CZW_541(CmdId, _content, StationId, PlatformTime);
                    break;
                case "542":
                    cmd = new CZW_542(CmdId, _content, StationId, PlatformTime);
                    break;
                case "543":
                    cmd = new CZW_543(CmdId, _content, StationId, PlatformTime);
                    break;
                case "544":
                    cmd = new CZW_544(CmdId, _content, StationId, PlatformTime);
                    break;
                case "545":
                    cmd = new CZW_545(CmdId, _content, StationId, PlatformTime);
                    break;
                case "548":
                    cmd = new CZW_61504(_content, StationId, PlatformTime);
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
