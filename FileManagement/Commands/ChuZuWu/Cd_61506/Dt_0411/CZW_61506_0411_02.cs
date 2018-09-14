using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_02 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_02(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "电子防盗门牌_超声波检测";
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
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                info.pi_protocoltype = _content[13].ToString();
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                info.pi_param1 = _content[14].ToString();   //门状态
                info.pi_param2 = _content[15].ToString();   //每天开门次数       
                info.pi_param3 = ConverUtil.ZF_Value(_content[16]);   //房间内人数 
                info.pi_param4 = _content[17].ToString();   //进出门时间 
                info.pi_version = _content[27].ToString();   //版本号。
                info.pi_param9 = ConverUtil.ZF_Value(_content[28]); //当前温度。
                info.pi_param10 = ConverUtil.ByteToStr_2(_content, 29); //总红外触发次数                       
                info.pi_policecard = _content[31].ToString(); //从上次心跳到现在的触发次数

                info.pi_param8 = _content[32].ToString();   //空旷时距离。
                info.pi_param6 = _content[33].ToString();   //超声波最大值。
                info.pi_param7 = _content[34].ToString();    //进出门方向。           
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
        /// 连续采集的超声波距离。
        /// </summary>
        /// <param name="array">内容。</param>
        /// <param name="start">开始索引。</param>
        /// <returns></returns>
        private string Distance(byte[] array, int start,int length)
        {

          //调用=  info.pi_param5 = Distance(_content, 18, 14);   //连续采集的超声波距离。
            byte[] Data = new byte[length];
            Array.Copy(array, start, Data, 0, length);
            string Temp;
            string Content = "";
            for (int i = 0; i < length; i++)
            {
                Temp = Data[i].ToString();
                if (i == 0)
                {
                    Content = Temp;
                }
                else
                {
                    Content = Content + "," + Temp;
                }
            }
            return Content;
        }
    }
}
