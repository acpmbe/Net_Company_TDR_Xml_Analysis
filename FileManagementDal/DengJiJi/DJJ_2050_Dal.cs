using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementModel.DengJiJi;

namespace FileManagementDal.DengJiJi
{

    /// <summary>
    /// 数据处理（登记机_绑定信息上报）
    /// </summary>
    public class DJJ_2050_Dal
    {
        public static DJJ_2050_Mod GetMod(byte[] content)
        {


            DJJ_2050_Mod info = new DJJ_2050_Mod();

            info.有源卡ID = ConverUtil.ByteToStr_4(content, 0);
            info.姓名 = GetName(content.Skip(4).Take(32).ToArray());
            info.民族 = GetMinZu(content.Skip(36).Take(10).ToArray());
            info.身份信息类型 = content[46].ToString();
            info.号码长度 = content[47];

            info.证件号码 = GetIdCard(content.Skip(48).Take(info.号码长度).ToArray());


            //if (info.号码长度 == content.Length - 48)
            //{

            //}
            //else
            //{
            //    throw er;
            //}




            return info;


        }

        static string GetIdCard(byte[] content)
        {

            string NameStr = Encoding.Default.GetString(content);
            return NameStr;
        }

        static string GetName(byte[] content)
        {

            string NameStr = Encoding.Unicode.GetString(content);
            return NameStr.Replace(" ", "").Replace("\0", "");
        }

        static string GetMinZu(byte[] content)
        {


            string NameStr = Encoding.Unicode.GetString(content);
            NameStr = NameStr.Replace("\0", "");

            switch (NameStr)
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

        public static Pro_InDatabase_LY_Mod Get_Pro_Mod(DJJ_2050_Mod info, string cmdId)
        {

            Pro_InDatabase_LY_Mod m = new Pro_InDatabase_LY_Mod();

            m.PI_DEVICETIME = info.平台时间;
            m.PI_SERVICETIME = info.平台时间;
            m.PI_DEVICECODE = info.基站编号.ToString();
            m.PI_DEVICETYPE = "";           //先传空，吴聪聪确认。
            m.PI_PROTOCOLTYPE = cmdId;
            m.PI_IDENTITYTYPE = info.身份信息类型;
            m.PI_IDENTITYCARD = info.证件号码;
            m.PI_IDENTITYNAME = info.姓名;
            m.PI_NATION = info.民族;
            m.PI_CARDID = info.有源卡ID;

        
            return m;


        }
    }
}
