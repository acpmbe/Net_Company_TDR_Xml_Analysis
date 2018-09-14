using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementDal
{
    public class DeviceIdTranslateFactory
    {
        public static IDeviceIdTranslate Create(string type){
            switch (type)
            {
                case "0101":
                   // return new MenJinDeviceIdTranslate();
                case "1201":
                   // return new AnFangDeviceIdTranslate();
                default:
                    return null;
            }
        }
    }
}
