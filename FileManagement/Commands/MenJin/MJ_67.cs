using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.MenJin;
using FileManagementModel;
using FileManagementDal;
using FileManagementUtil;
using FileManagementDal.MenJin;

namespace FileManagement.Commands.MenJin
{
    public class MJ_67 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public MJ_67(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }



        public const string NAME = "串号上传";

        public bool Execute()
        {
            try
            {

                if (FileManagement.Commands.MenJin.Filter_Bll.IsRepeat(this.OriginalCode))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }



                string sim_sn = BitConverter.ToString(_content).Replace("-", "");
                MJInfo info = new MJInfo();
                info.Protocol = "67";
                info.DeviceId = StationId.ToString();
                info.SimNum = sim_sn;

                IMjDal.Handle(NAME, OriginalCode, info);





            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码：" + OriginalCode);

            }
            return true;
        }
    }
}
