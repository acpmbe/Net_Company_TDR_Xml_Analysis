using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.DengJiJi;
using FileManagementDal.DengJiJi;
using FileManagement.Other.DengJiJi;

namespace FileManagement.Commands.DengJiJi
{

    /// <summary>
    /// 逻辑处理（登记机_绑定信息上报）
    /// </summary>
    public class DJJ_2050 : ICommand
    {

        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public DJJ_2050(byte[] content, ulong stationId, DateTime platformTime)
        {
            this.Content = content;
            this.StationId = stationId;
            this.PlatformTime = platformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(content);
        }


        public const string NAME = "登记机_绑定信息上报";
        public bool Execute()
        {
            try
            {
                DJJ_2050_Mod Cm = DJJ_2050_Dal.GetMod(Content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_InDatabase_LY_Mod info = DJJ_2050_Dal.Get_Pro_Mod(Cm, "2050");

                Pro_InDatabase_LY_Bll c = new Pro_InDatabase_LY_Bll(info);

                string Result = c.Exec();

                if (Result != "0")
                {
                    MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                }
            }
            catch(Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
         
            return true;
        }
    }
}
