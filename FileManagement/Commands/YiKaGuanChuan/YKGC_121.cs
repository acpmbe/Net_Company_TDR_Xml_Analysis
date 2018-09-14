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
    public class YKGC_121 : ICommand
    {
        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_121(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        private readonly string Name = "人员刷卡信息上传";


        public bool Execute()
        {

            try
            {

                int Length = 56;
                int Ys_Num = Content.Length % Length;
                if (Ys_Num == 0)
                {
                    int Num = Content.Length / Length;
                    byte[] Data;
                    for (int i = 0; i < Num; i++)
                    {
                        Data = new byte[Length];
                        Array.Copy(Content, i * Length, Data, 0, Length);
                        Single_56(Data);
                    }
                }
                else
                {
                    //  MyLibrary.Log.Debug(Name + "出错；内容长度错误" + " 原始代码:" + OriginalCode);

                    Length = 14;
                    Ys_Num = Content.Length % Length;
                    if (Ys_Num == 0)
                    {
                        int Num = Content.Length / Length;
                        byte[] Data;
                        for (int i = 0; i < Num; i++)
                        {
                            Data = new byte[Length];
                            Array.Copy(Content, i * Length, Data, 0, Length);
                            Single_14(Data);
                        }
                    }
                    else
                    {
                        MyLibrary.Log.Debug(Name + "出错；内容长度错误" + " 原始代码:" + OriginalCode);
                    }
                }


            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;

        }


        /// <summary>
        /// 56字节处理程序。
        /// </summary>
        /// <param name="content"></param>
        private void Single_56(byte[] content)
        {

            Pro_ShipDevice_Card_New_Mod info = new Pro_ShipDevice_Card_New_Mod();
            info.Pi_DevId = StationId.ToString();
            info.Pi_DevTime = ConverUtil.Time(content, 0);   //设备时间   
            info.Pi_Name = Encoding.Default.GetString(ConverUtil.Byte_Q(content, 6, 30)).Replace("\0", ""); //姓名
            info.Pi_SFZH = Encoding.ASCII.GetString(ConverUtil.Byte_Q(content, 36, 18)); //身份证好。

            UInt16 ResultNum;
            string Reason;
            Pro_ShipDevice_Card_New_Dal.Exec(info, out ResultNum, out Reason);
            if (ResultNum != 0)
            {
                MyLibrary.Log.Debug(Name + "出错；" + Reason + " 原始代码：" + OriginalCode);
            }

        }



        private string vvssss(byte[] content)
        {
            string Str = "";
            string StrTemp = "";
            byte[] Data;
            int Num = content.Length;
            if (Num >= 2)
            {
                if (Num % 2 == 0)
                {
                    for (int i = 0; i < Num / 2; i++)
                    {
                        Data = new byte[2];
                        Array.Copy(content, i * 2, Data, 0, 2);
                        StrTemp = ConverUtil.ByteToStr_A(Data);
                        if (StrTemp == "0000")
                        {
                            return Str;
                        }
                        else
                        {
                            Str += Encoding.Default.GetString(Data);
                        }

                    }
                    return Str;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 14字节处理程序。
        /// </summary>
        /// <param name="content"></param>
        private void Single_14(byte[] content)
        {
            try
            {

                Pro_ShipDevice_Card_Mod info = new Pro_ShipDevice_Card_Mod();
                info.Pi_DevId = StationId.ToString();  //设备编号
                info.Pi_DevTime = ConverUtil.Time(content, 0);   //设备时间   
                info.Pi_CardNo = ConverUtil.ByteToStr_Q(content, 6, 8);   //身份证Id。
                UInt16 ResultNum;
                string Reason;
                Pro_ShipDevice_Card_Dal.Exec(info, out ResultNum, out Reason);
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

    }
}
