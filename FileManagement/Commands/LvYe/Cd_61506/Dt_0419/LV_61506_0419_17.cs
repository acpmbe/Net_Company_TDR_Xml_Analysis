using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementUtil;
using FileManagementDal;


namespace FileManagement.Commands.LvYe.Cd_61506.Dt_0419
{
    public class LV_61506_0419_17 : ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public LV_61506_0419_17(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
  
        
        public const string NAME = "心跳数据";
        public bool Execute()
        {

            try
            {


                if (RepeatData.IsRepeatData(_content))
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
                info.PI_PARAM1 = _content[14].ToString(); //环境状态
                info.PI_PARAM2 = _content[15].ToString(); //对人校准身高
                info.PI_PARAM3 = _content[16].ToString(); //对地校准值
                info.PI_PARAM4 = _content[17].ToString(); //工作状态
                info.PI_PARAM5 = ConverUtil.ZF_Value(_content[18]); //当前环境温度
                info.PI_PARAM6  = ConverUtil.GetBin( _content[19],1); //防拆     
                info.PI_PARAM7 = ( Convert.ToInt32( _content[20])* 20 ).ToString(); //电池电压
                info.PI_PARAM8 = _content[21].ToString(); //热视电触发次数（从上次心跳到这次心跳之间）
                info.PI_PARAM9 = ConverUtil.ByteToStr_2(_content, 22) ; //超声波总工作时间
                info.PI_PARAM10 = ConverUtil.ByteToStr_2(_content, 24); //热释电总触发次数
                info.PI_PARAM11 = ConverUtil.ByteToStr_2(_content, 26); //总震动次数
                info.PI_PARAM12 = _content[28].ToString(); //每月按键触发次数
                info.PI_PARAM13 = ConverUtil.GetBin(_content[29], 1); //设备状态_超声波故障
                info.PI_PARAM14 = ConverUtil.GetBin(_content[29], 2); //设备状态_热释电故障
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
