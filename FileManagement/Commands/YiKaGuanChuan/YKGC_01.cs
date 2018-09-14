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
    public class YKGC_01 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_01(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);

           // MyLibrary.ConverUtil.StrToBytes(info.Content.Trim().Replace(" ", ""));
        }


        private readonly string Name = "渔船心跳";


        public bool Execute()
        {
            try
            {


                int Length = 12;
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


                Pro_CrewregistDevice_Beat_Mod info = new Pro_CrewregistDevice_Beat_Mod();
       
                info.Pi_DevId = StationId.ToString();  //设备编号
                info.Pi_DevTime = ConverUtil.Time(content, 0); //设备时间     
                info.Pi_StateTFT = content[6].ToString(); //tft屏状态
                info.Pi_State433 = content[7].ToString(); //433状态
                info.Pi_StateReader = content[8].ToString(); //读卡器状态
                info.Pi_StateCard = content[9].ToString(); //身份证读卡器状态
                info.Pi_StatePrint = content[10].ToString(); //打印机状态
                info.Pi_StateSd = content[11].ToString(); //SD卡状态

                UInt16 ResultNum;
                string Reason;
                Pro_CrewregistDevice_Beat_Dal.Exec(info, out ResultNum, out Reason);
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
