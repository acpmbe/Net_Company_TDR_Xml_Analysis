using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;

namespace FileManagement.Other.ChuZuWu
{
    public class Pro_UploadAlarm_Bll
    {


        private Pro_UploadAlarm_Mod Info;
        public Pro_UploadAlarm_Bll(Pro_UploadAlarm_Mod info)
        {
            this.Info = info;
        }
        public string Exec()
        {
            int resultnum;
            string reason;
            string wechatid;
            string alarmcontent;
            Pro_UploadAlarm_Dal.Exec(Info, out resultnum, out reason, out wechatid, out alarmcontent);
            if (resultnum == 1)
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
                return reason;
            }
        }
        //public static string Exec(Pro_UploadAlarm_Mod info)
        //{

        //    int resultnum;
        //    string reason;
        //    string wechatid;
        //    string alarmcontent;

        //    Pro_UploadAlarm_Dal.Exec(info, out resultnum, out reason, out wechatid, out alarmcontent);
        //    if (resultnum == 1)
        //    {
        //        Alert_Bll.Alert_Mod am = new Alert_Bll.Alert_Mod();
        //        am.ProtocolType = info.pi_protocoltype;
        //        am.DeviceTime = info.pi_devicetime;
        //        am.AlarmContent = alarmcontent;
        //        am.Reason = reason;
        //        am.WechatId = wechatid;
        //        Alert_Bll a = new Alert_Bll(am);
        //        return a.handle();






        //    }
        //    else
        //    {
        //        return reason;
        //    }

        //}


    }
}
