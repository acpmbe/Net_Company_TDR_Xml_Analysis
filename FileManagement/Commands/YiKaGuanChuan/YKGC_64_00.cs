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
 public   class YKGC_64_00:ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_64_00(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        private readonly string Name = "舱外上传数据";


        public bool Execute()
        {
            try
            {


                Pro_ShipDevice_Sail_Mod info = new Pro_ShipDevice_Sail_Mod();
                info.Pi_DevId = StationId.ToString();  //设备编号
                info.Pi_DevTime = ConverUtil.Time(Content, 0);   //设备时间   
                info.Pi_Lng = FormatNum(Content, 6, 4);    //经度
                info.Pi_Lat = FormatNum(Content, 10, 4);   //维度
                info.Pi_Azimuth = FormatNum(Content, 14, 2);  //航向
                info.Pi_Speed = FormatNum(Content, 16, 2); //航速。
                info.Pi_StarNum = Content[18].ToString();  //卫星数量。
                info.Pi_Temperswitch = Content[19].ToString();    //防拆开关状态。
                UInt16 ResultNum;
                string Reason;
                Pro_ShipDevice_Sail_Dal.Exec(info, out ResultNum, out Reason);
                if (ResultNum != 0)
                {
                    MyLibrary.Log.Debug(Name + "出错；" + Reason + " 原始代码：" + OriginalCode);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

        private void Single(byte[] content)
        {
            try
            {


                Pro_ShipDevice_Sail_Mod info = new Pro_ShipDevice_Sail_Mod();
                info.Pi_DevId = StationId.ToString();  //设备编号
                info.Pi_DevTime = ConverUtil.Time(content, 0);   //设备时间   
                info.Pi_Lng = FormatNum(content, 6, 4);    //经度
                info.Pi_Lat = FormatNum(content, 10, 4);   //维度
                info.Pi_Azimuth = FormatNum(content, 14, 2);  //航向
                info.Pi_Speed = FormatNum(content, 16, 2); //航速。
                info.Pi_StarNum = content[18].ToString();  //卫星数量。
                info.Pi_Temperswitch = content[19].ToString();    //防拆开关状态。
                UInt16 ResultNum;
                string Reason;
                Pro_ShipDevice_Sail_Dal.Exec(info, out ResultNum, out Reason);
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



        private string FormatNum(byte[] content, int start, int length)
        {

            byte[] Data = new byte[length];
            Array.Copy(content, start, Data, 0, length);
            string dddd = "";
            string Temp = "";
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    Temp = Data[i].ToString();
                    if (Temp != "0")
                    {
                        dddd = Temp + ".";
                    }
                    else
                    {
                        return "0";
                    }
                }
                else
                {
                    dddd = dddd + Data[i].ToString("D2");
                }
            }
            return dddd;


        }
    }
}
