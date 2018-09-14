using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManagementUtil
{
    public class DataClear
    {

        public static DataCleaner.Cleaner DataHandle;
        public static bool IsChuShiHua;

        public static bool ChuShiHua(string dataFlag, uint Keeptime)
        {
            try
            {
                DataHandle = new DataCleaner.Cleaner(dataFlag, Keeptime);
                DataHandle.Init();
                if (DataHandle.IsInit)
                {
                    IsChuShiHua = true;
                    return true;
                }
                else
                {
                    IsChuShiHua = false;
                    return false;
                }

            }
            catch
            {
                IsChuShiHua = false;
                return false;
            }

        }
        public static bool IsDataInsert(string DevInfo, string Content)
        {
            try
            {
                if (IsChuShiHua && DataHandle.IsInit)
                {

                    if (DataHandle.Exists(DevInfo, Content))   //返回true进入下一循环
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Warn("过滤错误：" + ex.Message);
                return false; 
            }

        }

    }
}
