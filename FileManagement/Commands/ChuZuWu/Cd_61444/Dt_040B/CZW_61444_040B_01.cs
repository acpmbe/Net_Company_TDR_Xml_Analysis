﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu.Cd_61444.Dt_040B
{
    public class CZW_61444_040B_01 : ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61444_040B_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "可燃气体心跳"; } }

        public bool Execute()
        {


            try
            {


                Pro_IndateBase_Sec_Mod info = new Pro_IndateBase_Sec_Mod();
                info.pi_bigtype = "4";
                info.pi_devicetime = ConverUtil.Time(_content, 0);
                info.pi_devicetype = ConverUtil.ByteToStr_2(_content, 7);
                info.pi_devicecode = ConverUtil.ByteToStr_4(_content, 9);
                info.pi_protocoltype = _content[13].ToString();
                char[] ModelStateChar = DataJM.ModelState(_content[14].ToString());
                info.pi_param1 = ModelStateChar[0].ToString();  //模块状态
                info.pi_param2 = ModelStateChar[1].ToString();  //模块状态
                info.pi_param3 = DataJM.电池电压(_content, 15);  //电池电压。
                info.pi_version = _content[18].ToString();
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;
                Other.ChuZuWu.Pro_IndateBase_Sec_Bll c = new Other.ChuZuWu.Pro_IndateBase_Sec_Bll(info);
                string Result = c.Exec();
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }
    }
}
