using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_01 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "电子防盗门牌_心跳";
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
                info.pi_bigtype = "1";
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                info.pi_protocoltype = _content[13].ToString();
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                info.pi_param1 = _content[14].ToString();   //门状态。        
                info.pi_param2 = ConverUtil.ZF_Value(_content[15]);   //房间内人数
                info.pi_param3 = _content[16].ToString();   //每天开门次数 
                info.pi_param4 = Battery(_content[17]);     //电池电压。
                info.pi_param5 = _content[18].ToString();   //防拆。
                info.pi_param6 = ConverUtil.ZF_Value(_content[19]);  //温度。
                info.pi_version = _content[34].ToString();  //版本号。
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
