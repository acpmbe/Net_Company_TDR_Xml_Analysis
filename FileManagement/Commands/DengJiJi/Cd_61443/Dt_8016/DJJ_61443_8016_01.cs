using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.DengJiJi;
using FileManagementModel.DengJiJi.Cd_61443.Dt_8016;
using FileManagementDal.DengJiJi.Cd_61443.Dt_8016;
using FileManagement.Other.DengJiJi;
using FileManagementDal;

namespace FileManagement.Commands.DengJiJi.Cd_61443.Dt_8016
{


    /// <summary>
    /// 逻辑处理（登记机_心跳）
    /// </summary>
    public class DJJ_61443_8016_01 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public DJJ_61443_8016_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "登记机_心跳";

        public bool Execute()
        {
            try
            {

                if (RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }

                DJJ_61443_8016_01_Mod Cm = DJJ_61443_8016_01_Dal.GetMod(this._content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_InDatabase_LY_Mod info = DJJ_61443_8016_01_Dal.Get_Pro_Mod(Cm);

                Pro_InDatabase_LY_Bll c = new Pro_InDatabase_LY_Bll(info);

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
