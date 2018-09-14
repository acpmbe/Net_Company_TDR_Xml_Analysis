using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.YiKaGuanChuan;
using FileManagementDal.YiKaGuanChuan;

namespace FileManagement.Commands.YiKaGuanChuan
{


    public  class YKGC_02_01: ICommand
    {

        private string Content;
        private ulong StationId;
        private DateTime PlatformTime;
   
        public YKGC_02_01(string content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
       
        }

        private readonly string Name = "船员登记(插入照片)";


        public bool Execute()
        {
            Pro_CrewregistDevice_Photo_Mod info = new Pro_CrewregistDevice_Photo_Mod();
            try
            {
                string[] array = Content.Split('|');            
                info.Pi_DevId = StationId.ToString();
                info.Pi_DevTime = PlatformTime;
                info.Pi_Index = array[0];
                info.Pi_Photo = Convert.FromBase64String(array[1]);

                UInt16 ResultNum;
                string Reason;
                Pro_CrewregistDevice_Photo_Dal.Exec(info, out ResultNum, out Reason);
                if (ResultNum != 0)
                {
                    MyLibrary.Log.Debug(Name + "出错；" + Reason + " 设备编号：" + info.Pi_DevId + " 照片时间：" + info.Pi_DevTime + " 照片编号：" + info.Pi_Index);

                }
            }
            catch(Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误；" + ex.Message + " 设备编号：" + info.Pi_DevId + " 照片时间：" + info.Pi_DevTime + " 照片编号：" + info.Pi_Index);
            }

            return true;
        }
    }


  

}
