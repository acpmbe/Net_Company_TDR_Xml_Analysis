using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_21 : ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_21(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "电子防盗门牌_一次出门数据上传";
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
                info.Pi_StationNo = StationId.ToString();
                info.Pi_ServiceTime = PlatformTime;
                info.Pi_DeviceTime = ConverUtil.Time(_content, 0);
                info.Pi_RelayNo = _content[6].ToString();
                info.Pi_DeviceType = ConverUtil.ByteToStr_2(_content, 7);
                info.Pi_DeviceCode = ConverUtil.ByteToStr_4(_content, 9);
                info.Pi_ProtocolType = _content[13].ToString();

                info.Pi_Param1 = _content[14].ToString(); //出门人数
                info.Pi_Param2 = (Convert.ToDouble(_content[15]) / 10).ToString(); //进超声波时刻（热释电触发始）
                info.Pi_Param3 = (Convert.ToDouble(_content[16]) / 10).ToString(); //门下驻停离开时刻（热释电触发始）
                info.Pi_Param4 = (Convert.ToDouble(_content[17]) / 10).ToString(); //最大身高发生时刻（热释电触发始）
                info.Pi_Param5 = (Convert.ToDouble(_content[18]) / 10).ToString(); //离开超声波范围时刻（热释电触发始）
                info.Pi_Param6 = (Convert.ToDouble(_content[19]) / 10).ToString(); //关门最初震动时刻（热释电触发始）
                info.Pi_Param7 = (Convert.ToDouble(_content[20]) / 10).ToString(); //关门最大震动时刻（热释电触发始）
                info.Pi_Param8 = (Convert.ToDouble(_content[21]) / 10).ToString(); //关门最后震动时刻（热释电触发始）
                info.Pi_Param9 = ConverUtil.ByteToStr_2(_content, 22);  //开门震动值
                info.Pi_Param10 = _content[24].ToString(); //本次进出门中最大身高（计算值）
                info.Pi_Param11 = _content[25].ToString(); //本次进出门中最大身高(实测值)     
                info.Pi_Param12 = _content[26].ToString(); //对地校准值，近似门框高度。
                info.Pi_Rssi = _content[33].ToString(); //RSSI值。
                info.Pi_Version = _content[34].ToString(); //版本号。

                Pro_IndataBase_ZNMP_Bll c = new Pro_IndataBase_ZNMP_Bll(info);
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


        /// <summary>
        /// 电池电压。
        /// </summary>
        /// <param name="value">byte值。</param>
        /// <returns></returns>
        private string Battery(byte value)
        {
            int IntValue = (Convert.ToInt32(value.ToString())) * 20;
            return ((double)IntValue / 1000).ToString();

        }
    }
}
