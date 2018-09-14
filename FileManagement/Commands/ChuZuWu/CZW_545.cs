using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_545 : ICommand
    {

        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;

        public CZW_545(string _cmdId, byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "下发结果回传"; } }
        public bool Execute()
        {

            try
            {
                if (_content.Length != 23)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Pro_CZW_XiaFa_Mod info = new Pro_CZW_XiaFa_Mod();
                info.pi_Protocol = "1";
                info.pi_Guid = ConverUtil.ByteToStr_Q(_content, 4, 16);  //Guid
                info.pi_CmdId = ConverUtil.ByteToStr_2(_content, 20); //命令字。
                info.pi_Result = _content[22].ToString();  //结果。




                string Result = "";
                int resultnum;
                string reason;
                Pro_CZW_XiaFa_Dal.Exec(info, out resultnum, out reason);
                if (resultnum == 0)
                {
                    Result = "0";
                }
                else
                {
                    Result = reason;
                }
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }


            return true;
        }
    }
}
