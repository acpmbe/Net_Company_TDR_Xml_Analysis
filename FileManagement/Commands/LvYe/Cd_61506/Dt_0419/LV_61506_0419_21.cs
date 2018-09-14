using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementUtil;

namespace FileManagement.Commands.LvYe.Cd_61506.Dt_0419
{ 
    public class LV_61506_0419_21 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public LV_61506_0419_21(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "一次出门习惯数据采集上传";

        public bool Execute()
        {

            try
            {

                if (FileManagementDal.RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                Pro_IndataBase_ZNMP_Mod info = new Pro_IndataBase_ZNMP_Mod();
                info.PI_DEVICETIME = ConverUtil.Time(_content, 0);
                info.PI_RELAYNO = _content[6].ToString();
                info.PI_DEVICETYPE = ConverUtil.ByteToStr_2(_content, 7);
                info.PI_DEVID = ConverUtil.ByteToStr_4(_content, 9);
                info.PI_PROTOCOLTYPE = _content[13].ToString();
                info.PI_STATIONNO = StationId.ToString();
                info.PI_SERVICETIME = PlatformTime;

                info.PI_PARAM1 = _content[14].ToString(); //出门人数
                info.PI_PARAM2 = (Convert.ToDouble(_content[15]) / 10).ToString(); //进超声波时刻（热释电触发始）
                info.PI_PARAM3 = (Convert.ToDouble(_content[16]) / 10).ToString(); //门下驻停离开时刻（热释电触发始）
                info.PI_PARAM4 = (Convert.ToDouble(_content[17]) / 10).ToString(); //最大身高发生时刻（热释电触发始）
                info.PI_PARAM5 = (Convert.ToDouble(_content[18]) / 10).ToString(); //离开超声波范围时刻（热释电触发始）
                info.PI_PARAM6 = (Convert.ToDouble(_content[19]) / 10).ToString(); //关门最初震动时刻（热释电触发始）                                   
                info.PI_PARAM7 = (Convert.ToDouble(_content[20]) / 10).ToString(); //关门最大震动时刻（热释电触发始）
                info.PI_PARAM8 = (Convert.ToDouble(_content[21]) / 10).ToString(); //关门最后震动时刻（热释电触发始）
                info.PI_PARAM9 = ConverUtil.ByteToStr_2(_content, 22); ; //关门震动值
                info.PI_PARAM10 = _content[24].ToString(); //本次进出门中最大身高（计算值）
                info.PI_PARAM11 = _content[25].ToString(); //本次进出门中最大身高(实测值)
                info.PI_PARAM12 = _content[26].ToString(); //对地校准值       
                info.PI_VERSION = _content[34].ToString(); //版本号
                Other.LvYe.Pro_IndataBase_ZNMP_Bll c = new Other.LvYe.Pro_IndataBase_ZNMP_Bll(info);
                string Result = c.Exec();
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }
    }
}
