using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.QiangZhiGuanKong;
using FileManagementDal.QiangZhiGuanKong;
using FileManagementUtil;
using FileManagementDal;
using System.Data;



namespace FileManagement.Commands.QiangZhiGuanKong
{
    public class QZGK_61443_8040_01 : ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;

        private string StationAddress;  //基站地址。
        private string StationLng;      //基站经度。
        private string StationLat;      //基站维度。

        public QZGK_61443_8040_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private string Name { get { return "840通讯协议"; } }
        public bool Execute()
        {

            try
            {
     
                if (_content.Length != 19)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }
                DateTime time = ConverUtil.Time(_content, 0);  //设备时间。
                string DeviceType = ConverUtil.ByteToStr_2(_content, 7);  //设备类型。
                string DeviceCode = ConverUtil.ByteToStr_4(_content, 9);  //设备编码。
                string cmdid = _content[13].ToString();   //命令字。
                string Sheng = _content[14].ToString();  //省。
                string Shi = _content[15].ToString();   //市。


               // GetStationInfo(StationId.ToString());

                Pro_QiangZhiGuanKong_Mod info = new Pro_QiangZhiGuanKong_Mod();
                info.pi_CmdType = "2";
                info.pi_ListId = Guid.NewGuid().ToString("N");
                info.pi_DeviceCode = DeviceCode;
                info.pi_StationNo = StationId.ToString();
                info.pi_DeviceTime = time;
                info.pi_ServiceTime = PlatformTime;
                info.pi_InTime = DateTime.Now;

                string Result = QiangZhiGuanKongDal.Handle(info);
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


      
        private void GetStationInfo(string deviceId)
        {
            DataTable table = TB_DEVICE_Dal.GetInfo(deviceId);
            if (table.Rows.Count != 0)
            {
                StationAddress = table.Rows[0]["NAME"].ToString();
                StationLng = table.Rows[0]["lng"].ToString();
                StationLat = table.Rows[0]["lat"].ToString();
            }
            else
            {
                StationAddress = "";
                StationLng = "";
                StationLat = "";
            }




        }

    }
}
