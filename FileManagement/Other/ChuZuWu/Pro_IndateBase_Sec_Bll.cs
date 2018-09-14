using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Pro_IndateBase_Sec_Bll
    {

        private Pro_IndateBase_Sec_Mod Info;
        public Pro_IndateBase_Sec_Bll(Pro_IndateBase_Sec_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {
            int resultnum;
            string reason;
            int status;
            string wechatid;
            string alarmcontent;
            Pro_IndateBase_Sec_Dal.Exec(Info, out resultnum, out reason, out status, out wechatid, out alarmcontent);
            if (resultnum == 0)
            {
                if (status == 1)
                {
                    Alert_Bll.Alert_Mod am = new Alert_Bll.Alert_Mod();
                    am.ProtocolType = Info.pi_protocoltype;
                    am.DeviceTime = Info.pi_devicetime;
                    am.AlarmContent = alarmcontent;
                    am.Reason = reason;
                    am.WechatId = wechatid;
                    Alert_Bll a = new Alert_Bll(am);
                    return a.handle();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return reason;
            }
        }
      


      
    }
}
