using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal.MenJinShouQuan;

namespace FileManagement.Commands.MenJinShouQuanCommand
{
    public class MenJinKaShanChuCommand : ICommand
    {


        private byte[] Content;
        private string Devid;
        private string OriginalCode;

        public MenJinKaShanChuCommand(string _devid, byte[] _content)
        {
            this.Content = _content;
            this.Devid = _devid;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);

        }
        private string Name { get { return "门禁删除"; } }

        public bool Execute()
        {
            try
            {


                byte[] sqkNumberByte = null;             
                string sqkNumberInt;
                int length = 4;
                int count = Content.Length / length;
                for (int i = 0; i < count; i++)
                {
                    sqkNumberByte = new byte[4];
                    Array.Copy(Content, i * length, sqkNumberByte, 0, 4);
                    Array.Reverse(sqkNumberByte);
                    sqkNumberInt = (Convert.ToUInt32(ConverUtil.ByteToStr_A(sqkNumberByte), 16)).ToString();
                    int resultNo;
                    string ResultInfo;
                    MenJinShouQuanDal.Insert(Devid, sqkNumberInt, 2, out resultNo, out ResultInfo);
                    if (resultNo == 1)
                    {
                        MyLibrary.Log.Debug(string.Format(Name + "出错, ID：{0} 卡号：{1} Result：{2} 原始代码: {3}", Devid, sqkNumberInt, ResultInfo, OriginalCode));

                    }

                }

            }
            catch (Exception ex)
            {

                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码：" + OriginalCode);
            }

            return true;

        }
    }
}
