using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal.QiYeFangHu;
using FileManagementDal;

namespace FileManagement.Commands.QiYeFangHu
{
    public class QYFH_5 : ICommand
    {



        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public QYFH_5(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public string Name
        {
            get { return "企业防护系统_心跳0005"; }
        }
        public bool Execute()
        {

            try
            {

                if (_content.Length < 6)
                {
                    MyLibrary.Log.Debug(Name + "长度错误：" + " 原始代码:" + OriginalCode);
                    return false;
                }

            
                DateTime time = ConverUtil.Time(_content, 0); //设备时间。  
                string Result = QiYeFangHuDal.update_XinTiao(StationId.ToString(), time);
                if (Result == "0")
                {
                    MyLibrary.Log.Debug(Name + "出错：原始代码: " + OriginalCode);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }
    }
}
