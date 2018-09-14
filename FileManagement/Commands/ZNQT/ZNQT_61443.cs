using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.ZNQT;


namespace FileManagement.Commands.ZNQT
{
  //public  class ZNQT_61443:ICommand
  //  {

  //      private byte[] Content;
  //      private ulong StationId;
  //      private DateTime PlatformTime;
  //      public ZNQT_61443(byte[] content, ulong stationId, DateTime platformTime)
  //      {
  //          this.Content = content;
  //          this.StationId = stationId;
  //          this.PlatformTime = platformTime;
  //      }


  //      public const string NAME = "智能气体CmdId：61056";
  //      public bool Execute()
  //      {
  //          int length = 19;
  //          if (Content.Length % length == 0)
  //          {
  //              int Count = Content.Length / length;
  //              string DeviceType;
  //              string CommandId;
  //              byte[] SubContent;
  //              for (int i = 0; i < Count; i++)
  //              {
  //                  DeviceType = ConverUtil.ByteToStr_Q(Content, 7 + (length * i), 2);
  //                  CommandId = Content[13 + (i * length)].ToString();
  //                  SubContent = ConverUtil.Byte_Q(Content, length * i, length);
  //                  ICommand cmd;
  //                  switch (DeviceType)
  //                  {
  //                      case "8780":
  //                          switch (CommandId)
  //                          {
                        
  //                              case "1":
  //                                  cmd = new ZNQT_61443_8780_01(SubContent, StationId, PlatformTime);
  //                                  break;
  //                              case "2":
  //                                  cmd = new ZNQT_61443_8780_02(SubContent, StationId, PlatformTime);
  //                                  break;
  //                              default:
  //                                  cmd = new IgnoreCommand();
  //                                  break;
  //                          }
  //                          break;
  //                      default:
  //                          cmd = new IgnoreCommand();
  //                          break;
  //                  }
  //                  cmd.Execute();
  //              }
  //          }
  //          else
  //          {
  //              MyLibrary.Log.Fatal(NAME + "长度出错；原始代码：" + MyLibrary.ConverUtil.ByteToHStr(Content));
  //          }

  //          return true;
  //      }
  //  }
}
