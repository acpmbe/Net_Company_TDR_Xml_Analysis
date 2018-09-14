using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementDal.ChuZuWu.Cd_61506.Dt_0411;


namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_195 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_195(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "电子防盗门牌_特征协议数据上传";

        public bool Execute()
        {
            try
            {

                if (RepeatData.IsRepeatData(RepeatStr()))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                CZW_61506_0411_195_Mod Cm = CZW_61506_0411_195_Dal.GetMod(this._content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_IndataBase_ZNMP_Mod info = CZW_61506_0411_195_Dal.Get_Pro_Mod(Cm);


                Pro_IndataBase_ZNMP_Bll c = new Pro_IndataBase_ZNMP_Bll(info);
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

        private string RepeatStr()
        {
            return ConverUtil.ByteToStr_Q(this._content, 6, this._content.Length - 7);
        }


    }
}
