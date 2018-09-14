using FileManagementUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Commands.QiYeKaoQing;

namespace FileManagement
{
    public class QykqCommandFactory : ICommandFactory
    {
        private IXmlFormat xmlFormat;

        public QykqCommandFactory(IXmlFormat xmlFormat)
        {
      
            this.xmlFormat = xmlFormat;
        }
        public ICommand Create(SyncInfo info)
        {
            ICommand cmd;    
            string QYCode = info.EQID;
            string Content = info.Content;
            DateTime _time = DateTime.Now;
            switch (info.CommandID)
            {
                case "01":
                    cmd = new QYKQ_01(QYCode, Content, _time);
                    break;
                case "02":
                    cmd = new QYKQ_02(QYCode, Content, _time);
                    break;
                case "03":
                    cmd = new QYKQ_03(QYCode, Content, _time);
                    break;
                case "04":
                    cmd = new QYKQ_04(QYCode, Content, _time);
                    break;
                default:
                    cmd = new IgnoreCommand();
                    break;
            }
            return cmd;

            #region 注释

            //ICommand cmd;
            //ushort _command = 0;
            //if (info.CommandID.Length != 4)
            //    info.CommandID = info.CommandID.PadLeft(4, '0');
            //byte[] _cmds = Utils.StrToBytes(info.CommandID);
            //_command = (ushort)(_cmds[0] << 8 | _cmds[1]);
            //string json = info.Content;

            //DateTime _time = DateTime.Now;
            //switch (_command)
            //{
            //    case 0x0001:
            //        cmd = new FaKaCommand(info.EQID, json, _time);
            //        break;
            //    case 0x0002:
            //        cmd = new ShuaKaCommand(info.EQID, json, _time);
            //        break;
            //    case 0x0003:
            //        cmd = new XiaoKaCommand(info.EQID, json, _time);
            //        break;
            //    case 0x0004:
            //        cmd = new AllFaKaCommand(info.EQID, json, _time);
            //        break;
            //    default:
            //        cmd = new NotImplementedCommand(_command.ToString(), null, null, _time.ToString());
            //        break;
            //}
            //return cmd;

            #endregion


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
