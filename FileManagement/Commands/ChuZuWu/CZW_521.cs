using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_521 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_521(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "出租房管理终端_撤布防状态上传"; } }
        public bool Execute()
        {

            try
            {
                if (_content.Length != 14)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }


                string HomeId = ConverUtil.ByteToStr_4(_content, 0);   //房间ID
                DateTime time = ConverUtil.Time(_content, 4);   //撤布防时间
                string OrganizeDefenceState = ConverUtil.ByteToStr_4(_content, 10);  //撤布防状态

                Pro_IndateBase_DZMP_Mod info = new Pro_IndateBase_DZMP_Mod();
                info.pi_bigtype = "1";
                info.pi_devicetime = time;
                info.pi_devicetype = "1029";
                info.pi_protocoltype = "521";
                info.pi_roomno = HomeId;
                info.pi_status = OrganizeDefenceState;
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;

                Other.ChuZuWu.Pro_IndateBase_DZMP_Bll c = new Other.ChuZuWu.Pro_IndateBase_DZMP_Bll(info);
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
    }
}
