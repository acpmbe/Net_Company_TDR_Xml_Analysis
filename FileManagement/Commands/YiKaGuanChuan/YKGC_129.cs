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
    public class YKGC_129 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_129(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        private readonly string Name = "经过基站信息上发";


        public bool Execute()
        {
            try
            {


                int Length = 14;
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

        
                Pro_ShipDevice_Station_Mod info = new Pro_ShipDevice_Station_Mod();
                info.Pi_DevId = StationId.ToString();  //设备编号
                info.Pi_DevTime = ConverUtil.Time(content, 0);   //设备时间   
                info.Pi_Station = ConverUtil.ByteToStr_4(content, 6);   //设备ID
          
                UInt16 ResultNum;
                string Reason;
                Pro_ShipDevice_Station_Dal.Exec(info, out ResultNum, out Reason);
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
