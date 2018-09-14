using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0426
{

    /// <summary>
    /// 过滤规则
    /// </summary>
    public class Filter_0426_Bll
    {


        public static bool IsRepeat(byte[] content)
        {


            int Int_10 = content[6] & 0x1f;
            string Str_16 = Int_10.ToString("x2").ToUpper();
            string Str_Content = ConverUtil.ByteToStr_Q(content, 7, 26);
            string Data = Str_16 + Str_Content;
            return FileManagementDal.RepeatData.IsRepeatDataNN(Data);

        }
        //public static bool IsRepeat(byte[] content)
        //{



        //    string Str = ConverUtil.ByteToStr_Q(content, 7, 26);
        //    return FileManagementDal.RepeatData.IsRepeatDataNN(Str);

        //}
    }
}
