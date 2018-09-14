using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementDal.ChuZuWu.Cd_61506.Dt_0426;


namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0426
{

    /// <summary>
    /// 逻辑处理（NFC_添卡）
    /// </summary>
    public class CZW_61506_0426_02: ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0426_02(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "NFC_添卡";

        public bool Execute()
        {
            try
            {

                if (Filter_0426_Bll.IsRepeat(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }

                CZW_61506_0426_02_Mod Cm = CZW_61506_0426_02_Dal.GetMod(this._content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_InDatabase_NFC_Mod info = CZW_61506_0426_02_Dal.Get_Pro_Mod(Cm);

                Pro_InDatabase_NFC_Bll c = new Pro_InDatabase_NFC_Bll(info);

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
