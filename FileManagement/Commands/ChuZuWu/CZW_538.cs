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
    public class CZW_538 : ICommand
    {

        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        private Pro_IndateBase_MJNew_Mod Info;
        public CZW_538(string _cmdId,byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "上传添加门戒设备"; } }


        public bool Execute()
        {

            try
            {

                if (_content.Length == 4)
                {
                    Info = GetInfo_Old();

                }
                else if (_content.Length == 14)
                {
                    Info = GetInfo_New();
                }
                else
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Other.ChuZuWu.Pro_IndateBase_MJNew_Bll c = new Other.ChuZuWu.Pro_IndateBase_MJNew_Bll(Info);
                string Result = c.Exec();
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

        private Pro_IndateBase_MJNew_Mod GetInfo_New()
        {
            Pro_IndateBase_MJNew_Mod info = new Pro_IndateBase_MJNew_Mod();
            info.pi_bigtype = "3";
            info.pi_protocoltype = CmdId;
            info.pi_devicetime = ConverUtil.Time(_content, 0);               //设备时间。
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 6);    //门戒ID。                       
            info.pi_relayno = ConverUtil.ByteToStr_4(_content, 10);       //中继器ID。          
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;
        }
        private Pro_IndateBase_MJNew_Mod GetInfo_Old()
        {
            Pro_IndateBase_MJNew_Mod info = new Pro_IndateBase_MJNew_Mod();
            info.pi_bigtype = "3";
            info.pi_protocoltype = CmdId;
            info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 0);    //门戒ID。                  
            info.pi_devicetime = PlatformTime;
            info.pi_stationno = StationId.ToString();
            info.pi_servicetime = PlatformTime;
            return info;

        }
    }
}
