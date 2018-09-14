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
    public class YKGC_64 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public YKGC_64(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        private readonly string Name = "命令字64";


        public bool Execute()
        {
            try
            {
                int Length = 21;
                int Ys_Num = Content.Length % Length;
                if (Ys_Num == 0)
                {           
                    int Num = Content.Length / Length;
                    byte[] Data;
                    for (int i = 0; i < Num; i++)
                    {
                        Data = new byte[Length];
                        Array.Copy(Content, i * Length, Data, 0, Length );        
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
                string CmdId = content[0].ToString();
                byte[] Data = new byte[20];
                Array.Copy(content, 1, Data, 0, 20);
                ICommand i;
                switch(CmdId)
                {
                    case "0":
                        i = new YKGC_64_00(Data, StationId, PlatformTime);
                        break;
                    default:
                        i = new IgnoreCommand();
                        break;
                }
                i.Execute();

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
