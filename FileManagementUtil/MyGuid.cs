using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementUtil
{
    public class MyGuid
    {

        public static string Create()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
