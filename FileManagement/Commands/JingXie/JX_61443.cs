using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.JingXie;
using FileManagementUtil;

namespace FileManagement.Commands.JingXie
{
    public class JX_61443 : ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public JX_61443(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "警械管控_有源标签数据";
        public bool Execute()
        {

            try
            {

                Pro_TagData_Mod info = new Pro_TagData_Mod();
                info.StationID = StationId.ToString();
                info.PlateTime = PlatformTime;
                info.TagTime = ConverUtil.Time(_content, 0);
                info.TagType = ConverUtil.ByteToStr_2(_content, 7);
                info.TagID = ConverUtil.ByteToStr_4(_content, 9);

                int ResultNum;
                FileManagementDal.JingXie.Pro_TagData_Dal.Exec(info, out ResultNum);
                if (ResultNum != 1)
                {
                    MyLibrary.Log.Debug(Name + "出错；原始代码：" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误；" + ex.Message + " 原始代码:" + OriginalCode);
            }
            return true;
        }

    }
}
