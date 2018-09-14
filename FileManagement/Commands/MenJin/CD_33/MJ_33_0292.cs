﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal.MenJin;

namespace FileManagement.Commands.MenJin.CD_33
{
    public class MJ_33_0292 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_33_0292(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        public const string NAME = "添加身份证";

        public bool Execute()
        {
            try
            {


                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                DateTime DeviceTime = ConverUtil.Time(_content, 0); //设备时间。  
                string IdentitycardId = ConverUtil.ByteToStr_Q(_content, 6, 8); //身份证Id

                MJInfo info = new MJInfo();
                info.Protocol = "658";
                info.DeviceId = StationId.ToString();
                info.DeviceTime = DeviceTime;
                info.IdentitycardId = IdentitycardId;

                IMjDal.Handle(NAME, OriginalCode, info);

         

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误；" + ex.Message + " 原始代码：" + OriginalCode);
            }
            return true;

        }
    }
}
