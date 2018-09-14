using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal;
using FileManagementUtil;
using FileManagementModel.SocialAppTerminal;

namespace FileManagement.Commands.SocialAppTerminal
{
    public class SAT_61505 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public SAT_61505(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(Content);
        }
        public string Name
        {
            get { return "一键报警"; }
        }
        public bool Execute()
        {
            try
            {

                int Length = 9;
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
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

        private void Single(byte[] content)
        {
            try
            {

                Tb_LKCommunity_Alarm_Mod info = new Tb_LKCommunity_Alarm_Mod();
                info.ListId = Guid.NewGuid().ToString("N"); 
                info.DeviceId = StationId.ToString();
                info.DeviceTime = ConverUtil.Time(content, 0);
                info.Alarm = ConverUtil.ByteToStr_Q(content, 6, 3);     
                info.InTime = DateTime.Now;
                FileManagementDal.SocialAppTerminal.Tb_LKCommunity_Alarm_Dal.Insert(info);

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
        }



    }
}
