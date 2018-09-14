using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ZNQT;
using FileManagementUtil.Push.WeChat;
using FileManagementUtil;

namespace FileManagement.Commands.ZNQT
{
    //public class Alarm_Bll
    //{

    //    private Alarm_Mod Info;

    //    public Alarm_Bll(Alarm_Mod info)
    //    {
    //        this.Info = info;
    //    }

    //    public class Alarm_Mod
    //    {
    //        /// <summary>
    //        /// 设备编号
    //        /// </summary>
   
    //        public string GASTANKID { get; set; }
    //        public string Title { get; set; }
    //        public string Reason { get; set; }
    //        public DateTime DeviceTime { get; set; }
    //        public string Wechatid { get; set; }
    //        public string Content { get; set; }

    //    }

    //    private class Appid_Mod
    //    {

    //        public string wechatid { get; set; }
    //        public string phone { get; set; }
    //        public string appid { get; set; }


    //    }

    //    public void Handle()
    //    {

    //        List<Appid_Mod> list = MyLibrary.Json.Deserialize<List<Appid_Mod>>(this.Info.Wechatid);
    //        foreach (var v in list)
    //        {
    //            Single(v);
    //        }

    //    }

    //    private void Single(Appid_Mod info)
    //    {
    //        if (string.IsNullOrWhiteSpace(info.wechatid))
    //        {
    //            return;
    //        }

    //        Real r = new Real(Info.Title, Info.Reason, Info.DeviceTime);
    //        string Result = r.Send(info.wechatid, Info.Content);
    //        if (Result == null)
    //        {

    //            Insert_Ok(info.wechatid);

    //        }
    //        else
    //        {
    //            Insert_Err(info.wechatid, Result);

    //        }

    //    }

    //    private void Insert_Ok(string wechatid)
    //    {
    //        Pro_PushMessageRecord_Dal dal = new Pro_PushMessageRecord_Dal();
    //        dal.pi_calltype = "1";
    //        dal.pi_issuccess = "1";

    //        dal.pi_gastankid = Info.GASTANKID;
    //        dal.pi_message = Info.Content;
    //        dal.pi_messagetype = "1";
    //        dal.pi_pushtime = DateTime.Now;
    //        dal.pi_pushtype = "1";
    //        dal.pi_sourceid = Info.Reason;
    //        dal.pi_wechatid = wechatid;

    //        Pro_PushMessageRecord_Dal.OutMod OutMod = dal.Exec();

    //        if(OutMod.resultNum !=0)
    //        {
    //            MyLibrary.Log.Debug("插入微信推送表出错：" + OutMod.reason + " 微信Id：" + wechatid);

    //        }
            
    //    }

    //    private void Insert_Err(string wechatid, string errInfo)
    //    {
    //        Pro_PushMessageRecord_Dal dal = new Pro_PushMessageRecord_Dal();
    //        dal.pi_calltype = "1";
    //        dal.pi_issuccess = "0";
    //        dal.pi_failedreseaon = errInfo;

    //        dal.pi_gastankid = Info.GASTANKID;     
    //        dal.pi_message = Info.Content;
    //        dal.pi_messagetype = "1";
    //        dal.pi_pushtime = DateTime.Now;
    //        dal.pi_pushtype = "1";
    //        dal.pi_sourceid = Info.Reason;
    //        dal.pi_wechatid = wechatid;

    //        Pro_PushMessageRecord_Dal.OutMod OutMod = dal.Exec();

    //        if (OutMod.resultNum != 0)
    //        {
    //            MyLibrary.Log.Debug("插入微信推送表出错：" + OutMod.reason + " 微信Id：" + wechatid);

    //        }



       
    //    }
    //}
}
