using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagement.Commands.MenJin;

namespace FileManagement.Commands.MenJin.CD_33
{
    public class MJ_33 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public bool Execute()
        {
            try
            {

          
                int CycleNum = 0;
                string CommandIdStr;
                UInt16 lengthInt;
                byte[] CommandId = new byte[2];
                byte[] length = new byte[2];
                byte[] SubContent;
                for (int i = 0; i < _content.Length; i += CycleNum)
                {
                 
                    Array.Copy(_content, i, CommandId, 0, 2);
                    Array.Copy(_content, 2 + i, length, 0, 2);
                    CommandIdStr = ConverUtil.ByteToStr_A(CommandId);
                    lengthInt = Convert.ToUInt16(ConverUtil.ByteToStr_A(length), 16);
                    SubContent = new byte[lengthInt];
                    Array.Copy(_content, 4 + i, SubContent, 0, lengthInt);
                    ICommand cmd;
                    switch (CommandIdStr)
                    {
                        case "0001":
                            cmd = new MJ_33_0001(SubContent, StationId, PlatformTime); //小写的b到f转成大写的B到F。
                            break;
                        case "0002":
                            cmd = new MJ_33_0002(SubContent, StationId, PlatformTime);
                            break;
                        case "0003":
                            cmd = new MJ_33_0003(SubContent, StationId, PlatformTime);
                            break;
                        case "0012":
                            cmd = new MJ_33_0012(SubContent, StationId, PlatformTime); //12
                            break;
                        case "0046":
                            cmd = new MJ_33_0046(SubContent, StationId, PlatformTime);
                            break;
                        case "0291":
                            cmd = new MJ_33_0291(SubContent, StationId, PlatformTime);
                            break;
                        case "0292":
                            cmd = new MJ_33_0292(SubContent, StationId, PlatformTime);
                            break;
                        case "0293":
                            cmd = new MJ_33_0293(SubContent, StationId, PlatformTime);
                            break;
                        case "0294":
                            cmd = new MJ_33_0294(SubContent, StationId, PlatformTime);
                            break;
                        case "0295":
                            cmd = new MJ_33_0295(SubContent, StationId, PlatformTime);
                            break;
                        case "0296":
                            cmd = new MJ_33_0296(SubContent, StationId, PlatformTime);
                            break;
                        default:
                            cmd = new IgnoreCommand();
                            break;
                    }
                    cmd.Execute();
                    CycleNum = 4 + lengthInt;

                }

         

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error("解析命令：" + ex.Message + " 原始代码：" + ConverUtil.ByteToStr_A(_content));
            }
            return true;

        }
    }
}
