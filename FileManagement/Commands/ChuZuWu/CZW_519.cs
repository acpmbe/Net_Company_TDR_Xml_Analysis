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
    public class CZW_519 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_519(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "上传身份证ID"; } }


        public bool Execute()
        {
            try
            {
                if (_content.Length != 20)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                string DeviceType = ConverUtil.ByteToStr_2(_content, 0);  //设备类型
                string DeviceId = ConverUtil.ByteToStr_4(_content, 2);  //设备Id
                DateTime time = ConverUtil.Time(_content, 6);   //设备时间
                string IdentityId = ConverUtil.ByteToStr_Q(_content, 12, 8); //身份证Id


                Pro_IndateBase_Sec_Mod info = new Pro_IndateBase_Sec_Mod();
                info.pi_bigtype = "10";
                info.pi_devicetime = time;
                info.pi_devicetype = DeviceType;
                info.pi_devicecode = DeviceId;
                info.pi_protocoltype = "519";
                info.pi_param1 = IdentityId;
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;

                Other.ChuZuWu.Pro_IndateBase_Sec_Bll c = new Other.ChuZuWu.Pro_IndateBase_Sec_Bll(info);
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
