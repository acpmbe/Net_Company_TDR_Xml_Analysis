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
    public class CZW_518 : ICommand
    {


        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_518(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "撤布防状态"; } }

        public bool Execute()
        {
            try
            {
                if (_content.Length != 17)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Pro_IndateBase_Sec_Mod info = new Pro_IndateBase_Sec_Mod();
                info.pi_bigtype = "9";
                info.pi_protocoltype = "518";
                info.pi_devicetime = ConverUtil.Time(_content, 6);   //设备时间
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 0);  //设备类型
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 2);  //设备Id             
                info.pi_param1 = ConverUtil.ByteToStr_4(_content, 12);  //房间号
                info.pi_param2 = _content[16].ToString();  //模块状态  
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
