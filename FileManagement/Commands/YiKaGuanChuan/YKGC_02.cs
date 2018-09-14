using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.YiKaGuanChuan;
using FileManagementDal.YiKaGuanChuan;

namespace FileManagement.Commands.YiKaGuanChuan
{
    public class YKGC_02 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_02(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        private readonly string Name = "船员登记";


        public bool Execute()
        {
            try
            {
                int Length = 189;
                int Ys_Num = Content.Length % Length;
                if (Ys_Num == 0)
                {
                    int Num = Content.Length / Length;
                    byte[] Data;
                    for (int i = 0; i < Num; i++)
                    {
                        Data = new byte[Length];
                        Array.Copy(Content, i * Length, Data, 0, Length);
                        Single(Data);
                    }
                }
                else
                {
                    MyLibrary.Log.Debug(Name + "出错；内容长度错误" + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

        private void Single(byte[] content)
        {
            try
            {

                Pro_CrewregistDevice_Card_Mod info = new Pro_CrewregistDevice_Card_Mod();
                info.Pi_DevId = StationId.ToString();
                info.Pi_DevTime = ConverUtil.Time(content, 0); //设备时间    
                info.Pi_CardId = ConverUtil.ByteToStr_Q(content, 6, 8); //身份证卡号
                info.Pi_Identity = ConverUtil.ASI_To_Str(ConverUtil.ByteToStr_Q(Content, 14, 18)); //身份证号
                info.Pi_Name = Address(ConverUtil.ByteToStr_Q(Content, 32, 30)); //姓名
                info.Pi_Sex = IsSex(ConverUtil.ByteToStr_Q(Content, 62, 1)); //性别。            
                info.Pi_Nation = ConverUtil.MinZu(ConverUtil.ByteToStr_Q(Content, 63, 2)); //民族。
                info.Pi_Birthday = TimeStr(ConverUtil.ByteToStr_Q(Content, 65, 8)); //出生年月日。
                info.Pi_Address = Address(ConverUtil.ByteToStr_Q(Content, 73, 70)); //住址。
                info.Pi_SignUnit = Address(ConverUtil.ByteToStr_Q(Content, 143, 30)); //签发机关。
                info.Pi_StartTime = TimeStr(ConverUtil.ByteToStr_Q(Content, 173, 8)); //起始日期。
                info.Pi_EndTime = TimeStr(ConverUtil.ByteToStr_Q(Content, 181, 8)); //结束日期。

                UInt16 ResultNum;
                string Reason;
                Pro_CrewregistDevice_Card_Dal.Exec(info, out ResultNum, out Reason);
                if (ResultNum != 0)
                {
                    MyLibrary.Log.Debug(Name + "出错；" + Reason + " 原始代码：" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
        }




        private DateTime TimeStr(string str)
        {
            byte[] StrByte = ConverUtil.StrToBytes(str);
            string sddd = Encoding.ASCII.GetString(StrByte);
            int year = Convert.ToInt32(sddd.Substring(0, 4));
            int Month = Convert.ToInt32(sddd.Substring(4, 2));
            int day = Convert.ToInt32(sddd.Substring(6, 2));
            DateTime d = new DateTime(year, Month, day);

            return d;
        }

        private string Address(string str)
        {
            byte[] StrByte = ConverUtil.StrToBytes(str);
            string Data = Encoding.Default.GetString(StrByte);
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data.Substring(i, 1) == "\0")
                {
                    return Data.Substring(0, i);
                }
            }
            return Data;

        }

        /// <summary>
        /// 得到性别（1：男 2：女）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string IsSex(string str)
        {
            byte[] StrByte = ConverUtil.StrToBytes(str);
            string Data = Encoding.Default.GetString(StrByte);

            if (Data == "1")
            {
                return "1";
            }
            else
            {
                return "2";
            }

        }
    }
}
