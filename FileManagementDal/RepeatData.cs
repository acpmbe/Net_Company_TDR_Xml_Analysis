using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;

namespace FileManagementDal
{
    /// <summary>
    /// 重复数据。
    /// </summary>
    public class RepeatData
    {
        /// <summary>
        /// 是否为重复数据。
        /// </summary>
        /// <param name="_content"></param>
        /// <returns></returns>
        //public static bool IsRepeatData(byte[] _content)
        //{


        //    string RelayNo = _content[6].ToString();  //中继号
        //    string DevInfo = ConverUtil.ByteToStr_Q(_content, 6, _content.Length - 6);
        //    string sn = (Convert.ToInt32(RelayNo) % 32).ToString();
        //    if (DataClear.IsDataInsert(DevInfo, sn))   //返回true进入下一循环
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        public static bool IsRepeatData(byte[] _content)
        {
            if (!Config.RedoDataConfig.IsOpen)
            {
                return false;
            }

            if(!DataClear.IsChuShiHua)
            {
                return false;
            }       
            string DevInfo = ConverUtil.ByteToStr_Q(_content, 7, _content.Length - 7);
            if (DataClear.IsDataInsert(DevInfo, DevInfo))   //返回true进入下一循环
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static bool IsRepeatDataNN(string content)
        {
            if (!Config.RedoDataConfig.IsOpen)
            {
                return false;
            }

            if (!DataClear.IsChuShiHua)
            {
                return false;
            }

            if (DataClear.IsDataInsert(content, content))   //返回true进入下一循环
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsRepeatData(string content)
        {
            if (!Config.RedoDataConfig.IsOpen)
            {
                return false;
            }

            if (!DataClear.IsChuShiHua)
            {
                return false;
            }

            if (DataClear.IsDataInsert(content, content))   //返回true进入下一循环
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public static bool IsRepeatData(byte[] _content)
        //{
        //    if (!Config.RedoDataConfig.IsOpen)
        //    {
        //        return false;
        //    }

        //    if (!DataClear.IsChuShiHua)
        //    {
        //        return false;
        //    }

        //    //  string RelayNo = _content[6].ToString();  //中继号
        //    string DevInfo = ConverUtil.ByteToStr_Q(_content, 7, _content.Length - 7);
        //    //   string sn = (Convert.ToInt32(RelayNo) % 32).ToString();
        //    if (DataClear.IsDataInsert(DevInfo, DevInfo))   //返回true进入下一循环
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        /// <summary>
        /// 是否为重复数据（A标示）。
        /// </summary>
        /// <param name="_content"></param>
        /// <returns></returns>
        //public static bool IsRepeatData_A(ulong _stationId, byte[] _content)
        //{

        //    if (DataClear.IsDataInsert(_stationId.ToString(), MyLibrary.ConverUtil.ByteToHStr(_content)))   //返回true进入下一循环
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



    }
}
