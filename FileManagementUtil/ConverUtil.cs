using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil
{
    public class ConverUtil
    {


        /// <summary>
        /// 得到指定长度的Byte数组。
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="start">开始索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static byte[] GetByteData(byte[] content, int start, int length)
        {
            return content.Skip(start).Take(length).ToArray();
        }
        /// <summary>
        /// Byte数组转时间。
        /// </summary>
        /// <param name="value">值。</param>
        /// <param name="start">开始字节。</param>
        /// <returns></returns>
        public static DateTime Time(byte[] value, int start)
        {
            byte[] timeByte = new byte[6];
            Array.Copy(value, start, timeByte, 0, 6);
            return MyLibrary.ConverUtil.Time(timeByte);
        }

        public static UInt16 ByteToUint16(byte[] content)
        {
            if (content.Length > 2)
            {
                return 0;
            }
            else
            {

                return Convert.ToUInt16(ByteToHStr(content), 16);
            }
        }

        public static uint ByteToUint(byte[] content)
        {
            if (content.Length > 4)
            {
                return 0;
            }
            else
            {

                return Convert.ToUInt32(ByteToHStr(content), 16);
            }
        }

        /// <summary>
        /// byte转Int16
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Int16 ByteToInt16(byte content)
        {

            string Str_2 = Convert.ToString(content, 2).PadLeft(8, '0');
            string IsZF = Str_2.Substring(0, 1);
            Int16 Value = Convert.ToInt16(Str_2.Substring(1, 7), 2);
            if (IsZF == "0")
            {
                return Value;
            }
            else
            {
                return Convert.ToInt16("-" + Value);
            }

        }

        private static string ByteToHStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null && bytes.Length > 0)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }



        /// <summary>
        /// 二个字节转字符串。
        /// </summary>
        /// <param name="value">值。</param>
        /// <param name="start">开始索引。</param>
        /// <returns></returns>
        public static string ByteToStr_2(byte[] value, int start)
        {

            return MyLibrary.ConverUtil.Byte2_ToDStr(value, start);
        }

        public static int ByteToInt_2(byte[] value, int start)
        {

            return Convert.ToInt32(  MyLibrary.ConverUtil.Byte2_ToDStr(value, start));
        }


        /// <summary>
        /// 得到位值
        /// </summary>
        /// <param name="str">数据</param>
        /// <param name="Num">右边开始第几位</param>
        /// <returns></returns>
        public static string GetBin(byte str, int Num)
        {
            int StrInt = Convert.ToInt32(str);
            string Data = Convert.ToString(StrInt, 2).PadLeft(8, '0');
            return Data.Substring(Data.Length - Num, 1);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static string ByteToStr_4(byte[] value, int start)
        {
            return MyLibrary.ConverUtil.Byte4_ToDStr(value, start);
        }


        public static uint ByteToInt_4(byte[] value, int start)
        {
            return Convert.ToUInt32(MyLibrary.ConverUtil.Byte4_ToDStr(value, start));
        }

        /// <summary>
        /// Byte数组（区间）转字符串。
        /// </summary>
        /// <param name="value">原始内容。</param>
        /// <param name="start">开始字节。</param>
        /// <param name="length">长度。</param>
        /// <returns></returns>
        public static string ByteToStr_Q(byte[] value, int start, int length)
        {

            return MyLibrary.ConverUtil.ByteToStr(value, start, length);

        }

        /// <summary>
        /// 取Byte数组（区间）。
        /// </summary>
        /// <param name="value">原始内容。</param>
        /// <param name="start">开始索引。</param>
        /// <param name="length">长度。</param>
        /// <returns></returns>
        public static byte[] Byte_Q(byte[] value, int start, int length)
        {
            byte[] Data = new byte[length];
            Array.Copy(value, start, Data, 0, length);
            return Data;
        }


        /// <summary>
        /// Byte数组（全部）转字符串。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public static string ByteToStr_A(byte[] value)
        {
            return MyLibrary.ConverUtil.ByteToHStr(value);
        }

        public static string StrToBase64(string Content)
        {
            System.Text.Encoding encode = System.Text.Encoding.ASCII;
            byte[] bytedata = encode.GetBytes(Content);
            return Convert.ToBase64String(bytedata, 0, bytedata.Length);
        }

        public static string GetGongLv(int content)
        {

            string Str_2 = (Convert.ToString(content, 2)).PadLeft(16, '0');
            string ZF = Str_2.Substring(0, 1);
            string Str_10 = Str_2.Substring(1, Str_2.Length - 1);
            int Int_10 = Convert.ToInt32(Str_10, 2);
            string temp = "";
            if (ZF == "0")
            {
                temp = Int_10.ToString();
            }
            else
            {
                temp = "-" + Int_10.ToString();
            }
            return temp;
        }


        /// <summary>
        /// 字符串数组转换为以特殊符号标记的字符串。
        /// </summary>
        /// <param name="_array"></param>
        /// <returns></returns>
        public static string GetArrayToStr(string[] _array)
        {
            string Data = "";
            for (int i = 0; i < _array.Length; i++)
            {
                if (i == 0)
                {
                    Data = _array[i];
                }
                else
                {
                    Data = Data + "," + _array[i];
                }
            }
            return Data;
        }


        /// <summary>
        /// 字符串转Byte数组。
        /// </summary>
        /// <param name="str">字符串。</param>
        /// <returns></returns>
        public static byte[] StrToBytes(string str)
        {
            return MyLibrary.ConverUtil.StrToBytes(str);
        }



        /// <summary>
        /// ASCII码转字符串。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ASI_To_Str(string str)
        {

            byte[] StrByte = ConverUtil.StrToBytes(str);
            string Data = Encoding.ASCII.GetString(StrByte);
            for (int i = 0; i < Data.Length; i++)
            {
                if (Data.Substring(i, 1) == "\0")
                {
                    return Data.Substring(0, i);
                }
            }
            return Data;
        }


   


        /// <summary>
        /// 最高位b7表示正负，1为负，0为正 ,B6-b0数值表示值。
        /// </summary>
        /// <param name="value">byte值。</param>
        /// <returns></returns>
        public static string ZF_Value(byte value)
        {

            string Temp;
            string Content;
            Content = Convert.ToString(value, 2);
            if (Content.Length == 8)
            {
                Temp = Content.Substring(1, 7);
                if (Temp == "0000000")
                {
                    return "";
                }
                else
                {
                    return "-" + Convert.ToInt32(Temp, 2).ToString();
                }

            }
            else
            {
                return Convert.ToInt32(Content, 2).ToString();
            }

        }
        public static string MinZu(string type)
        {
            string Type = ASI_To_Str(type);
            switch (Type)
            {
                case "01":
                    return "汉族";
                case "02":
                    return "蒙古族";
                case "03":
                    return "回族";
                case "04":
                    return "藏族";
                case "05":
                    return "维吾尔族";
                case "06":
                    return "苗族";
                case "07":
                    return "彝族";
                case "08":
                    return "壮族";
                case "09":
                    return "布依族";
                case "10":
                    return "朝鲜族";
                case "11":
                    return "满族";
                case "12":
                    return "侗族";
                case "13":
                    return "瑶族";
                case "14":
                    return "白族";
                case "15":
                    return "土家族";
                case "16":
                    return "哈尼族";
                case "17":
                    return "哈萨克族";
                case "18":
                    return "傣族";
                case "19":
                    return "黎族";
                case "20":
                    return "傈傈族";
                case "21":
                    return "佤族";
                case "22":
                    return "畲族";
                case "23":
                    return "高山族";
                case "24":
                    return "拉祜族";
                case "25":
                    return "水族";
                case "26":
                    return "东乡族";
                case "27":
                    return "纳西族";
                case "28":
                    return "景颇族";
                case "29":
                    return "柯尔克孜族";
                case "30":
                    return "土族";
                case "31":
                    return "达斡尔族";
                case "32":
                    return "仫佬族";
                case "33":
                    return "姜族";
                case "34":
                    return "布朗族";
                case "35":
                    return "撒拉族";
                case "36":
                    return "毛难族";
                case "37":
                    return "仡佬族";
                case "38":
                    return "锡伯族";
                case "39":
                    return "阿昌族";
                case "40":
                    return "普米族";
                case "41":
                    return "塔吉克族";
                case "42":
                    return "怒族";
                case "43":
                    return "乌孜别克族";
                case "44":
                    return "俄罗斯族";
                case "45":
                    return "鄂温克族";
                case "46":
                    return "崩龙族";
                case "47":
                    return "保安族";
                case "48":
                    return "裕固族";
                case "49":
                    return "京族";
                case "50":
                    return "塔塔尔族";
                case "51":
                    return "独龙族";
                case "52":
                    return "鄂伦春族";
                case "53":
                    return "赫哲族";
                case "54":
                    return "门巴族";
                case "55":
                    return "珞巴族";
                case "56":
                    return "基诺族";
                case "97":
                    return "其他";
                case "98":
                    return "外国血统";
                default:
                    return "";


            }
        }



    }
}
