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
    public class SAT_61443 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public SAT_61443(byte[] content, ulong stationId, DateTime platformTime)
        {

            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(Content);
        }
        public string Name
        {
            get { return "设备上传卡信息"; }
        }
        public bool Execute()
        {
            try
            {

                int Length = 27;
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

                Tb_LKCommunityRecord_Mod info = new Tb_LKCommunityRecord_Mod();
                info.DeviceId = StationId.ToString();
                info.RecordTime = DateTime.Now;
                info.DeviceTime = ConverUtil.Time(content, 0);
                info.CardType = content[6].ToString(); //身份证卡类型09信息为8位，IC卡类型05信息为4位;        
                info.CardId = CardId(info.CardType, content);
                info.Reserve = ConverUtil.ByteToStr_Q(content, 7, 3);
                info.IdCard = DataJM.SFZ_Str(content, 18);
                FileManagementDal.SocialAppTerminal.Tb_LKCommunityRecord_Dal.Insert(info);

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
        }


        private string CardId(string type, byte[] content)
        {
            if (type == "5")
            {
                return ConverUtil.ByteToStr_Q(content, 14, 4);  //CardId。
            }
            else if (type == "9")
            {
                return ConverUtil.ByteToStr_Q(content, 10, 8);  //身份证。
            }
            else
            {
                return "";
            }
        }



    }
}
