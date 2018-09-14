using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.LvYe;
using FileManagementUtil;
using FileManagementDal;
using FileManagementDal.LvYe;

namespace FileManagement.Commands.LvYe.Cd_61506.Dt_0419
{
    public class LV_61506_0419_197 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public LV_61506_0419_197(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "电子防盗门牌_单人进出协议数据上传";

        public bool Execute()
        {
            try
            {

                if (RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                LV_61506_0419_197_Mod Cm = LV_61506_0419_197_Dal.GetMod(this._content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_IndataBase_ZNMP_Mod info = LV_61506_0419_197_Dal.Get_Pro_Mod(Cm);

                Other.LvYe.Pro_IndataBase_ZNMP_Bll c = new Other.LvYe.Pro_IndataBase_ZNMP_Bll(info);
                string Result = c.Exec();
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                }



            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }
    }
}
