using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Commands.MenJin
{
    public class Filter_Bll
    {

        public static bool IsRepeat(string content)
        {


            return FileManagementDal.RepeatData.IsRepeatDataNN(content);

        }
    }
}
