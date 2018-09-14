using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;

namespace FileManagementDal
{
    public class DataJM
    {
       
    
        public static string 电池电压(byte[] _content, int Start)
        {
            byte[] Data = new byte[2];
            Array.Copy(_content, Start, Data, 0, 2);
            return (((float)Convert.ToInt32(MyLibrary.ConverUtil.ByteToHStr(Data), 16)) / 100).ToString();

        }

        public static string 温度(byte[] _content, int Start)
        {

            return (((SignSymbol)_content[Start] & SignSymbol.WenDu) == SignSymbol.WenDu ? Convert.ToInt16("-" + ((int)((SignSymbol)_content[Start] ^ SignSymbol.WenDu)).ToString()) : _content[Start]).ToString();

        }

        public static int 温度(byte src)
        {

            return ((SignSymbol)src & SignSymbol.WenDu) == SignSymbol.WenDu ? Convert.ToInt16("-" + ((int)((SignSymbol)src ^ SignSymbol.WenDu)).ToString()) : src;
        }
        private enum SignSymbol
        {
            WenDu = 0x80,
            GongLv = 0x8000,
            ModelSate = 0x80,
            GongLvYinSu = 0x65
        }

        public static string 功率因素(byte[] _content, int Start)
        {

            int s = Convert.ToInt32(_content[Start].ToString());
            if (s > 0 && s <= 100)
            {
                float gonglvF = s / 100F;
                return gonglvF.ToString();
            }
            else
            {
                return "0";
            }
        }
  
        public static string 震动时间(byte[] _content, int Start)
        {

            return ((Convert.ToInt32(_content[Start])) * 0.5).ToString();

        }


        public static char[] ModelState(string src)
        {

            int int10 = Convert.ToInt32(src);
            if (int10 < 2)
            {
                if (int10 == 1)
                {
                    char[] ychar = { '1', '0' };
                    return ychar;
                }
                else
                {
                    char[] ychar = { '0', '0' };
                    return ychar;
                }
            }
            else
            {
                string zhuan2 = Convert.ToString(int10, 2);
                int count = zhuan2.Length;
                char[] model = zhuan2.ToCharArray();
                char[] model1 = { model[count - 1], model[count - 2] };
                return model1;

            }

        }

        public static string gonglvyinsu(string src)
        {

            int s = Convert.ToInt32(src);
            if (s > 0 && s <= 100)
            {
                float gonglvF = s / 100F;
                return gonglvF.ToString();
            }
            else
            {
                return "0";

            }

        }

        public static string[] GetBitStr(byte DeviceByte)
        {

            string DeviceStateStr = Convert.ToString(Convert.ToInt32(DeviceByte.ToString()), 2);//j就是转换后的二进制了！！
            string BitStr = "";
            if (DeviceStateStr.Length != 8)
            {
                int End = 8 - DeviceStateStr.Length;
                for (int i = 0; i < End; i++)
                {
                    BitStr = BitStr + "0";
                }
                BitStr = BitStr + DeviceStateStr;
            }
            string[] BitStrArray = new string[8];
            int AddValue = 0;
            for (int i = 7; i >= 0; i--)
            {
                BitStrArray[AddValue] = BitStr.Substring(i, 1);
                AddValue++;
            }

            return BitStrArray;
        }


        /// <summary>
        /// 得到角度值。
        /// </summary>
        /// <param name="AngleValueHexadecimal"></param>
        /// <returns></returns>
        public static string GetAngleValue(string AngleValueHexadecimal)
        {
            string AngleValue = "";
            double DecimalDouble = 0;
            string BinaryStr = Convert.ToString(Convert.ToUInt16(AngleValueHexadecimal, 16), 2); //转二进制
            if (BinaryStr.Length == 16)
            {
                DecimalDouble = Convert.ToDouble(Convert.ToUInt16(BinaryStr.Substring(1, 15), 2));
                AngleValue = (DecimalDouble / 10).ToString();
            }
            else
            {
                DecimalDouble = Convert.ToDouble(Convert.ToUInt16(BinaryStr, 2));
                AngleValue = "-" + (DecimalDouble / 10).ToString();
            }
            return AngleValue;
        }


        /// <summary>
        /// 以数组的形式得到卡类型和房东编号（索引0：卡类型 索引1：房东编号）。
        /// </summary>
        /// <param name="Content">内容 （一个字节转10）。</param>
        /// <returns></returns>
        public static string[] GetCardTypeAndHouseNo(string Content)
        {
            string[] Array = new string[2];
            string Binary = Convert.ToString(Convert.ToInt32(Content), 2);
            if (Binary.Length < 8)
            {
                Array[0] = "0";
                Array[1] = Convert.ToInt32(Binary, 2).ToString();
            }
            else
            {
                Array[0] = "1";
                Array[1] = Convert.ToInt32(Binary.Substring(1, 7), 2).ToString();
            }
            return Array;

        }


        public static string SFZ_Str(byte[] value, int start)
        {
     
            if(ConverUtil.ByteToStr_A(value) != "FFFFFFFFFFFFFFFFFF")
            {
                return SFZUtil.ByteToStr(value, start);
            }
            else
            {
                return "";
            }
        }
    }
}
