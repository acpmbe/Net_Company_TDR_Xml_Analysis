using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.DengJiJi.Cd_61443.Dt_8016;

namespace FileManagement.Commands.DengJiJi.Cd_61443
{
    public class DJJ_61443 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        public DJJ_61443(byte[] content, ulong stationId, DateTime platformTime)
        {
            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
        }


        public const string NAME = "登记机CmdId：61443";
        public bool Execute()
        {
            int length = 19;
            if (Content.Length % length == 0)
            {
                int Count = Content.Length / length;
                string DeviceType;
                string CommandId;
                byte[] SubContent;
                for (int i = 0; i < Count; i++)
                {
                    DeviceType = ConverUtil.ByteToStr_Q(Content, 7 + (length * i), 2);
                    CommandId = Content[13 + (i * length)].ToString();
                    SubContent = ConverUtil.Byte_Q(Content, length * i, length);
                    ICommand cmd;
                    switch (DeviceType)
                    {
                        case "8016":
                            switch (CommandId)
                            {
                                case "1":
                                    cmd = new DJJ_61443_8016_01(SubContent, StationId, PlatformTime);
                                    break;                         
                                default:
                                    cmd = new IgnoreCommand();
                                    break;
                            }
                            break;
                        default:
                            cmd = new IgnoreCommand();
                            break;
                    }
                    cmd.Execute();
                }
            }
            else
            {
                MyLibrary.Log.Fatal(NAME + "长度出错；原始代码：" + MyLibrary.ConverUtil.ByteToHStr(Content));
            }

            return true;
        }
    }
}
