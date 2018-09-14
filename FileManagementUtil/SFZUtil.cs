using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil
{

    /// <summary>
    /// 身份证类。
    /// </summary>
    public class SFZUtil
    {

        /// <summary>
        /// 验证（返回0正确，否则出错信息）。
        /// </summary>
        /// <param name="sfz">身份证号。</param>
        /// <returns></returns>
        public static string Validate(string sfz)
        {
            if (!string.IsNullOrEmpty(sfz))
            {
                if (sfz.Length == 18)
                {
                    return "0";
                }
                else
                {
                    return "身份证位数出错。";
                }
            }
            else
            {
                return "身份证为空或null值。";
            }

        }

        /// <summary>
        /// 通过身份证得到性别。
        /// </summary>
        /// <param name="sfz">身份证号。</param>
        /// <returns></returns>
        public static string Sex(string sfz)
        {
            string sex = sfz.Substring(14, 3);
            if (int.Parse(sex) % 2 == 0)
            {
                return "女";
            }
            else
            {
                return "男";
            }
        }


        /// <summary>
        /// 通过身份证得到出生日期。
        /// </summary>
        /// <param name="sfz">身份证号。</param>
        /// <returns></returns>
        public static string Date(string sfz)
        {

            return sfz.Substring(6, 4) + "-" + sfz.Substring(10, 2) + "-" + sfz.Substring(12, 2);

        }



        /// <summary>
        /// Byte数组转身份证号。
        /// </summary>
        /// <param name="value">值。</param>
        /// <param name="start">开始索引。</param>
        /// <returns></returns>
        public static string ByteToStr(byte[] value, int start)
        {

            byte[] Data = new byte[9];
            Array.Copy(value, start, Data, 0, 9);
            string Identitycard = ConverUtil.ByteToStr_A(Data);
            if (Identitycard.Substring(17, 1) == "A")
            {
                Identitycard = Identitycard.Substring(0, 17) + "X";
            }
            return Identitycard;
        }
    }
}
