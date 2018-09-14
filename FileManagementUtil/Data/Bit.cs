using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil.Data
{
    public class Bit
    {

        /// <summary>
        /// 一个字节里位区间的值（顺序:右往左）
        /// </summary>
        /// <param name="content"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static byte GetBitR(byte content, int start, int end)
        {

            string BinaryStr = Convert.ToString(content, 2).PadLeft(8, '0');
            BinaryStr = ReverseStr(BinaryStr);
            int Lenght;
            if (start == 0)
            {
                Lenght = end + 1;
            }
            else
            {
                Lenght = (end - start) + 1;
            }
            string SelectStr = BinaryStr.Substring(start, Lenght);
            SelectStr = ReverseStr(SelectStr);
            return Convert.ToByte(SelectStr, 2);

        }




        /// <summary>
        /// 取位的值
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="start">开始</param>
        /// <returns></returns>
        public static byte GetBin(byte content, int start)
        {

            string BinaryStr = Convert.ToString(content, 2).PadLeft(8, '0');
            BinaryStr = ReverseStr(BinaryStr);
            string SelectStr = BinaryStr.Substring(start, 1);
            return Convert.ToByte(SelectStr, 2);

        }


        /// <summary>
        /// 字符串反转
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string ReverseStr(string text)
        {
            string reverse = string.Empty;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse += text[i];
            }

            return reverse;
        }
    }
}
