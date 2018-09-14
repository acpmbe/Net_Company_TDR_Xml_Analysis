using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.LvYe.Cd_61506.Dt_0419;

namespace FileManagement.Commands.LvYe.Cd_61506
{
    public class LY_61056:ICommand
    {
        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        public LY_61056(byte[] content, ulong stationId, DateTime platformTime)
        {
            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
        }

 
        public const string NAME = "旅业CmdId：61056";
        public bool Execute()
        {
            int length = 35;
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
                        case "0419":
                            switch (CommandId)
                            {
                                case "17":
                                    cmd = new LV_61506_0419_17(SubContent, StationId, PlatformTime);
                                    break;
                                case "19":
                                    cmd = new LV_61506_0419_19(SubContent, StationId, PlatformTime);
                                    break;
                                case "21":
                                    cmd = new LV_61506_0419_21(SubContent, StationId, PlatformTime);
                                    break;
                                //case "195":
                                //    cmd = new LV_61506_0419_195(SubContent, StationId, PlatformTime);
                                //    break;
                                //case "197":
                                //    cmd = new LV_61506_0419_197(SubContent, StationId, PlatformTime);
                                //    break;
                                //case "199":
                                //    cmd = new LV_61506_0419_199(SubContent, StationId, PlatformTime);
                                //    break;
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
