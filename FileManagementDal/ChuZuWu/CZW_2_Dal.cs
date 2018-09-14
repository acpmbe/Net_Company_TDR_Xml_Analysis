using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementUtil;
using FileManagementUtil.Data;
using FileManagementDal.DB.CZW.Table;

namespace FileManagementDal.ChuZuWu
{

    /// <summary>
    /// 数据处理（访客登记 _命令字2）
    /// </summary>
    public class CZW_2_Dal
    {



        public static CZW_2_Mod GetMod(byte[] content)
        {
            //时间(6) + 身份证id(8) + 身份证号(18) + 姓名(30) + 性别(1) + 名族(2) + 出生年月日(8) + 住址(70) + 签发机关(30) + 起始日期(8) + 结束日期(8)

            CZW_2_Mod info = new CZW_2_Mod();
            info.时间= ConverUtil.Time(content, 0);
            info.身份证id = ConverUtil.ByteToStr_Q(content, 6, 8);
            info.身份证号 = GetSFZ(content.Skip(14).Take(18).ToArray());
            info.姓名 = GetName(content.Skip(32).Take(30).ToArray());
            info.性别 = GetSex(content.Skip(62).Take(1).ToArray());
            info.名族 = GetMZ(content.Skip(63).Take(2).ToArray());
            info.出生年月日 = GetBirday(content.Skip(65).Take(8).ToArray());
            info.住址 = GetAddress(content.Skip(73).Take(70).ToArray());
            info.签发机关 = GetAddress(content.Skip(143).Take(30).ToArray());
            info.起始日期= GetBirday(content.Skip(173).Take(8).ToArray());
            info.结束日期 = GetBirday(content.Skip(181).Take(8).ToArray());



            return info;


        }


        public static Tb_EIdentitycardBung_Dal TableMod(CZW_2_Mod info)
        {

            Tb_EIdentitycardBung_Dal dal = new Tb_EIdentitycardBung_Dal();
            dal.LISTID = MyGuid.Create();
            dal.IDENTITYCARDID = info.身份证id;
            dal.IDENTITYCARD = info.身份证号;
            dal.DEVICETIME = info.时间;
            dal.INTIME = DateTime.Now;
            dal.STATUS = "2";
            dal.OWERNAME = info.姓名;
            dal.SEX = info.性别;
            dal.NATION = info.名族;
            dal.BIRTHDAY = info.出生年月日;
            dal.HJADDRESS = info.住址;
            dal.POLICE = info.签发机关;
            dal.VALIDITY = GetValidity(info.起始日期, info.结束日期);

            dal.MJDEVICEID = info.设备编号.ToString();
            return dal;
           
        }

        private static string GetValidity(DateTime startTime, DateTime endTime)
        {

            string start = startTime.ToString("yyyyMMdd");
            string end = endTime.ToString("yyyyMMdd");
            return start + "至" + end;

        }

        private static string GetAddress(byte[] strIntStrByte)
        {

         
            string NameStr = Encoding.Default.GetString(strIntStrByte);
            string NewNameStr = "";
            string LinShiStr;
            int Num = 0;
            for (int i = 0; i < NameStr.Length; i++)
            {
                LinShiStr = NameStr.Substring(i, 1);
                if (LinShiStr == "\0")
                {
                    if (Num != 0)
                    {
                        NewNameStr = NameStr.Substring(0, i);
                    }
                    break;
                }

                Num++;
            }
            return NewNameStr;


        }

        private static DateTime GetBirday(byte[] strIntStrByte)
        {
            try
            {
           
                string timeStr = Encoding.Default.GetString(strIntStrByte);
                DateTime dt = new DateTime(Convert.ToInt32(timeStr.Substring(0, 4)), Convert.ToInt32(timeStr.Substring(4, 2)), Convert.ToInt32(timeStr.Substring(6, 2)));
                return dt;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        private static string GetMZ(byte[] strIntStrByte)
        {

    
            string NameStr = Encoding.Default.GetString(strIntStrByte);
            return GetMinZu(NameStr);


        }

        private static string GetMinZu(string BianMa)
        {
            switch (BianMa)
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

        private static string GetName(byte[] strIntStrByte)
        {

     
            string NameStr = Encoding.Default.GetString(strIntStrByte);
            string NewNameStr = "";
            string LinShiStr;
            int Num = 0;
            for (int i = 0; i < NameStr.Length; i++)
            {
                LinShiStr = NameStr.Substring(i, 1);
                if (LinShiStr == "\0")
                {
                    if (Num != 0)
                    {
                        NewNameStr = NameStr.Substring(0, i);
                    }
                    break;
                }

                Num++;
            }
            return NewNameStr;


        }

        private static string GetSex(byte[] strIntStrByte)
        {


            string NameStr = Encoding.Default.GetString(strIntStrByte);
            if (NameStr == "1")
            {
                return "男";
            }
            else if (NameStr == "0")
            {
                return "女";
            }
            else
            {
                return "";
            }

        }


        private static string GetSFZ(byte[] strIntStrByte)
        {

       
            string DataStr = Encoding.ASCII.GetString(strIntStrByte);

            return DataStr; 

        }

        /// <summary>
        /// 字符串日期时间 转 日期时间DateTime。
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns></returns>
        private static DateTime GetTime(string timeStr)
        {
            try
            {
                DateTime dt = new DateTime(2000 + Convert.ToInt32(timeStr.Substring(0, 2), 16), Convert.ToInt32(timeStr.Substring(2, 2), 16), Convert.ToInt32(timeStr.Substring(4, 2), 16), Convert.ToInt32(timeStr.Substring(6, 2), 16), Convert.ToInt32(timeStr.Substring(8, 2), 16), Convert.ToInt32(timeStr.Substring(10, 2), 16));
                return dt;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

    }
}
