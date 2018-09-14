using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu.Cd_61504.Dt_0430
{
    public class CZW_61504_0430_48 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61504_0430_48(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private readonly string Name = "新开关门数据";
        public bool Execute()
        {

            try
            {

                if (RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                Pro_IndateBase_ZHMJ_Mod info = new Pro_IndateBase_ZHMJ_Mod();
                info.pi_bigtype = "2";
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                info.pi_protocoltype = _content[13].ToString();
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                info.pi_param1 = _content[14].ToString();       //每天开门次数
                string[] DataArray = DoorInfo(_content[15]);   //门状态及数据标志
                info.pi_param2 = DataArray[0];                 //门状态
                info.pi_param3 = DataArray[1];                //数据标志
                info.pi_param4 = _content[16].ToString();     //开门动作时间
                info.pi_param5 = _content[17].ToString();     //开门最大角度

                byte[] Data = new byte[6];
                Array.Copy(_content, 18, Data, 0, 6);
     
                info.pi_param6 = stttt(Data);                //三个加速度。
                info.pi_param7 = _content[24].ToString();    //开盖报警等
                info.pi_version = _content[26].ToString();  //版本号

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





    

        private string[] DoorInfo(byte value)
        {
            string[] array = new string[2];
            UInt16 IntValue = Convert.ToUInt16(value.ToString());
            string Binary = Convert.ToString(IntValue, 2).PadLeft(8, '0');
            array[0] = Binary.Substring(Binary.Length - 1, 1);
            array[1] = Binary.Substring(Binary.Length - 2, 1);
            return array;

        }


        private string stttt(byte[] array)
        {
            string ArrayStr = MyLibrary.ConverUtil.ByteToHStr(array);
            string Data = "";
            UInt16 IntValue;
            string Binary = "";
            string Data_Z = "";
            if (ArrayStr.Length % 4 == 0)
            {
                int Count = ArrayStr.Length / 4;
                for (int i = 0; i < Count; i++)
                {
                    IntValue = Convert.ToUInt16(MyLibrary.ConverUtil.Byte2_ToDStr(array, (i * 2)));
                    Binary = Convert.ToString(IntValue, 2).PadLeft(16, '0');
                    Data_Z = (Convert.ToUInt16(Binary.Substring(1, 15), 2)).ToString();
                    if (Binary.Substring(0, 1) == "1")
                    {
                        Data_Z = "-" + Data_Z;
                    }
                    if (i == 0)
                    {
                        Data = Data_Z;
                    }
                    else
                    {
                        Data = Data + "," + Data_Z;
                    }

                }

                return Data;

            }
            else
            {
                return "";
            }


        }


    }
}
