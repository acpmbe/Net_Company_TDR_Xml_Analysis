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
    public class CZW_61504_0430_03 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61504_0430_03(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "智慧刷卡门戒_人数变化和开关门上传"; } }
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
                info.pi_param1 = _content[14].ToString();   //变化方向
                info.pi_param2 = _content[15].ToString();   //房间内人数
                info.pi_param3 = _content[16].ToString();   //每天开门次数 
                info.pi_param4 = _content[17].ToString();   //门状态  
                info.pi_param5 = _content[18].ToString();   //自动撤布防。
                info.pi_param6 = _content[19].ToString();   //布防报警。
                info.pi_param7 = ((_content[20] >> 7) & 01).ToString();    //开门超过十分钟。
                info.pi_param10 = ((_content[20] >> 6) & 01).ToString();   //表示开盖报警。
                info.pi_param9 = _content[21].ToString();                  //打开门的角度
                info.pi_version = _content[26].ToString();


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


        private void vsss()
        {
            try
            {

             
                Pro_IndateBase_ZHMJ_Mod info = new Pro_IndateBase_ZHMJ_Mod();
                info.pi_bigtype = "2";
                info.pi_devicecode = "14";
                info.pi_devicetype = "1041";
                info.pi_protocoltype = "3";
                info.pi_devicetime = Convert.ToDateTime("2017-3-18");
                info.pi_cardtype = "9";
                info.pi_cardid = "000000000000000000";
                info.pi_HEADCOUNT = "1";
                info.pi_OPENTIMES = "0";
                info.pi_param1 = "175";
                info.pi_param2 = "0";
                info.pi_param3 = "1";
     
                info.pi_param6 = "0";
                info.pi_param7 = "3";
                info.pi_param8 = "11";
                info.pi_stationno = "0";
                info.pi_version = "0";
                info.pi_servicetime = Convert.ToDateTime("2017-3-18");
                info.pi_houseno = "0";
                info.pi_identitycardid = "000000000000000000";
                info.pi_policecard = "000000000000";
                info.pi_activecardid = "0";


                //info.pi_devicetime = ConverUtil.Time(_content, 0);
                //info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                //info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                //info.pi_protocoltype = _content[13].ToString();
                //info.pi_stationno = StationId.ToString();
                //info.pi_servicetime = PlatformTime;
                //info.pi_param1 = _content[14].ToString();   //变化方向
                //info.pi_param2 = _content[15].ToString();   //房间内人数
                //info.pi_param3 = _content[16].ToString();   //每天开门次数 
                //info.pi_param4 = _content[17].ToString();   //门状态  
                //info.pi_param5 = _content[18].ToString();   //自动撤布防。
                //info.pi_param6 = _content[19].ToString();   //布防报警。
                //info.pi_param7 = ((_content[20] >> 7) & 01).ToString();    //开门超过十分钟。
                //info.pi_param10 = ((_content[20] >> 6) & 01).ToString();   //表示开盖报警。
                //info.pi_param9 = _content[21].ToString();                  //打开门的角度
                //info.pi_version = _content[26].ToString();


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
        }
    }
}
