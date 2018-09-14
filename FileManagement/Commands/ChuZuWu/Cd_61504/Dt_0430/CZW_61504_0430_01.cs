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

namespace FileManagement.Commands.ChuZuWu.Cd_61504.Dt_0430
{
    public class CZW_61504_0430_01 : ICommand
    {



        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61504_0430_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "智慧刷卡门戒_心跳"; } }
        public bool Execute()
        {
            try
            {



                Pro_IndateBase_ZHMJ_Mod info = new Pro_IndateBase_ZHMJ_Mod();
                info.pi_bigtype = "1";
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                info.pi_protocoltype = _content[13].ToString();
                info.pi_param1 = _content[14].ToString();   //门状态
                info.pi_param2 = _content[15].ToString();   //房间内人数
                info.pi_param3 = _content[16].ToString();  //每天开门次数    
                info.pi_param4 = (Convert.ToInt32(_content[17].ToString()) * 0.02).ToString("0.00");  //电池电压。  
                info.pi_param5 = ((_content[18] >> 7) & 01).ToString();  //配置标志
                info.pi_version = _content[26].ToString();
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;

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
    }
}
