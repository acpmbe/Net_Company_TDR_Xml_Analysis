using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.HouseAndUserCard;
using FileManagementUtil;
using FileManagementDal.HouseAndUserCard;

namespace FileManagement.Commands.HouseAndUserCard
{
    public class HU_3_1:ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public HU_3_1(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public string Name
        {
            get { return "上传房东用户卡"; }
        }
        public bool Execute()
        {

            try
            {
                int Num = this._content.Length % 31;
                if (Num == 0)
                {
                    Pro_IndateBase_MjSec_Mod info = IndateBase();
                    string Result = HouseAndUser_Dal.Exec(info);
                    if (Result != "0")
                    {
                   
                        MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + this.OriginalCode);
                    }

                }
                else
                {

                    MyLibrary.Log.Debug(Name + "长度出错；" + " 原始代码：" + this.OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

        private Pro_IndateBase_MjSec_Mod IndateBase()
        {
            Pro_IndateBase_MjSec_Mod info = new Pro_IndateBase_MjSec_Mod();
            info.pi_bigtype = "104";
            info.pi_devicecode = this.StationId.ToString();
            info.pi_devicetime = DateTime.Now;
            info.pi_param1 = this._content.Length.ToString();
            info.pi_param2 = this.OriginalCode;
            return info;
        }

    }
}
