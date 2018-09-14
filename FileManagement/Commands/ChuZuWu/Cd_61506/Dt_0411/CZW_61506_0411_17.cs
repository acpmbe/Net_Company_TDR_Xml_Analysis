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
    public class CZW_61506_0411_17 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_17(byte[] _content, ulong _StationId, DateTime _PlatformTime)
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

                Pro_IndataBase_ZNMP_Mod info = new Pro_IndataBase_ZNMP_Mod();
                info.Pi_StationNo = StationId.ToString();
                info.Pi_ServiceTime = PlatformTime;
                info.Pi_DeviceTime = ConverUtil.Time(_content, 0);
                info.Pi_RelayNo = _content[6].ToString();
                info.Pi_DeviceType = ConverUtil.ByteToStr_2(_content, 7);
                info.Pi_DeviceCode = ConverUtil.ByteToStr_4(_content, 9);
                info.Pi_ProtocolType = _content[13].ToString();
                info.Pi_Param1 = _content[14].ToString();  //环境状态
                info.Pi_Param2 = _content[15].ToString(); //对人校准身高
                info.Pi_Param3 = _content[16].ToString();  //对地校准值
                info.Pi_Param4 = _content[17].ToString();  //工作状态
                info.Pi_Param5 = ConverUtil.ZF_Value(_content[18]); //当前环境温度
                info.Pi_Param6 = _content[19].ToString();  //防拆
                info.Pi_Param7 = Battery(_content[20]);  //电池电压
                info.Pi_Param8 = (Convert.ToUInt16(_content[21]) * 3).ToString();  //热视电触发次数（从上次心跳到这次心跳之间）
                info.Pi_Param9 = ConverUtil.ByteToStr_2(_content, 22); ;  //超声波总工作时间
                info.Pi_Param10 = (Convert.ToUInt16(ConverUtil.ByteToStr_2(_content, 24)) * 10).ToString();  //热释电总触发次数  
                info.Pi_Param11 = (Convert.ToUInt16(ConverUtil.ByteToStr_2(_content, 26)) * 10).ToString();  //总震动次数
                info.Pi_Param12 = _content[28].ToString();   //每月按键触发次数
                char[] array = DevState(_content[29]);
                info.Pi_Param13 = array[0].ToString();      //超声波故障
                info.Pi_Param14 = array[1].ToString();      //热释电故障
                info.Pi_Rssi = _content[33].ToString();      //RSSI值
                info.Pi_Version = _content[34].ToString();      //版本号

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

        private char[] DevState(byte value)
        {

            int v_Int = Convert.ToInt32(value);
            string V_S = Convert.ToString(v_Int, 2);
            string Str_8 = Convert.ToInt32(V_S).ToString("D8");
            return Str_8.ToCharArray();


        }
    }
}
