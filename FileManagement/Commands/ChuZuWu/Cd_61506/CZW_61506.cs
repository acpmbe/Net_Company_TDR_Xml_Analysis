using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411;
using FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0426;

namespace FileManagement.Commands.ChuZuWu.Cd_61506
{
  public  class CZW_61506:ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        public CZW_61506(byte[] content, ulong stationId, DateTime platformTime)
        {
            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
        }

        private readonly string Name = "电子防盗门牌";

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
                        case "0411":
                            switch (CommandId)
                            {
                                case "1":
                                    cmd = new CZW_61506_0411_01(SubContent, StationId, PlatformTime);
                                    break;
                                case "2":
                                    cmd = new CZW_61506_0411_02(SubContent, StationId, PlatformTime);
                                    break;
                                case "3":
                                    cmd = new CZW_61506_0411_03(SubContent, StationId, PlatformTime);
                                    break;
                                case "17":
                                    cmd = new CZW_61506_0411_17(SubContent, StationId, PlatformTime);
                                    break;
                                case "19":
                                    cmd = new CZW_61506_0411_19(SubContent, StationId, PlatformTime);
                                    break;
                                case "21":
                                    cmd = new CZW_61506_0411_21(SubContent, StationId, PlatformTime);
                                    break;
                                //case "33":
                                //    cmd = new CZW_61506_0411_33(SubContent, StationId, PlatformTime);
                                //    break;
                                case "35":
                                    cmd = new CZW_61506_0411_35(SubContent, StationId, PlatformTime);
                                    break;
                                case "37":
                                    cmd = new CZW_61506_0411_37(SubContent, StationId, PlatformTime);
                                    break;
                                case "51":
                                    cmd = new CZW_61506_0411_51(SubContent, StationId, PlatformTime);
                                    break;
                                case "53":
                                    cmd = new CZW_61506_0411_53(SubContent, StationId, PlatformTime);
                                    break;
                                case "67":
                                    cmd = new CZW_61506_0411_67(SubContent, StationId, PlatformTime);
                                    break;
                                case "69":
                                    cmd = new CZW_61506_0411_69(SubContent, StationId, PlatformTime);
                                    break;
                                case "177":
                                    cmd = new CZW_61506_0411_177(SubContent, StationId, PlatformTime);
                                    break;
                                case "195":
                                    cmd = new CZW_61506_0411_195(SubContent, StationId, PlatformTime);
                                    break;
                                case "197":
                                    cmd = new CZW_61506_0411_197(SubContent, StationId, PlatformTime);
                                    break;
                                case "199":
                                    cmd = new CZW_61506_0411_199(SubContent, StationId, PlatformTime);
                                    break;
                                case "201":
                                    cmd = new CZW_61506_0411_201(SubContent, StationId, PlatformTime);
                                    break;                
                                default:
                                    cmd = new IgnoreCommand();
                                    break;
                            }
                            break;
                        case "0426":
                            switch (CommandId)
                            {
                                case "1":
                                    cmd = new CZW_61506_0426_01(SubContent, StationId, PlatformTime);
                                    break;
                                case "2":
                                    cmd = new CZW_61506_0426_02(SubContent, StationId, PlatformTime);
                                    break;
                                case "3":
                                    cmd = new CZW_61506_0426_03(SubContent, StationId, PlatformTime);
                                    break;
                                case "4":
                                    cmd = new CZW_61506_0426_04(SubContent, StationId, PlatformTime);
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
                MyLibrary.Log.Fatal(Name + "长度出错；原始代码：" + MyLibrary.ConverUtil.ByteToHStr(Content));
            }

            return true;
        }
    }
}
