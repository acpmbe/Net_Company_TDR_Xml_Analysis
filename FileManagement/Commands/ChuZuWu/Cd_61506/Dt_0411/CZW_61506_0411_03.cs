using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_03 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_03(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "电子防盗门牌_进出门采集";
        public bool Execute()
        {

            try
            {
                if (FileManagementDal.RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }

                Pro_IndateBase_ZHMJ_Mod info = new Pro_IndateBase_ZHMJ_Mod();
                info.pi_bigtype = "2";
                info.pi_devicetime = ConverUtil.Time(_content, 0); //设备时间。
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7); //设备类型。
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9); //设备编号。
                info.pi_protocoltype = _content[13].ToString();  //命令字。
                info.pi_stationno = StationId.ToString();  //基站编号。
                info.pi_servicetime = PlatformTime;   //基站时间。

                info.pi_param1 = _content[14].ToString();   //身高。
                info.pi_param2 = Value_Num_1(_content[15]);   //进出门时间。  
                info.pi_param3 = ConverUtil.ZF_Value(_content[16]);   //单次进出人数.
                info.pi_param4 = ConverUtil.ByteToStr_2(_content, 17);  //开门震动值。
                info.pi_param5 = ConverUtil.ByteToStr_2(_content, 19);  //关门震动值。
                info.pi_param6 = _content[21].ToString();   //房间内人数。
                info.pi_param7 = ConverUtil.ZF_Value(_content[22]);   //温度。
                info.pi_param8 = ConverUtil.ByteToStr_2(_content, 23);  //红外触发总次数。
                info.pi_param9 = _content[25].ToString();  //一天红外触发次数。
                info.pi_param10 = ConverUtil.ByteToStr_2(_content, 26);  //总震动次数。
                info.pi_houseno = ConverUtil.ByteToStr_2(_content, 28);  //超声波工作时间。
                info.pi_identitycardid = _content[30].ToString();    //空旷距离
                info.pi_policecard = Battery(_content[31]);   //剩余电量。
                info.pi_version = _content[32].ToString();   //版本号。

                Other.ChuZuWu.Pro_IndateBase_ZHMJ_Bll c = new Other.ChuZuWu.Pro_IndateBase_ZHMJ_Bll(info);
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


        private string Value_Num_1(byte value)
        {

            double d = Convert.ToDouble(value.ToString());
            return (d / 10).ToString();

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
