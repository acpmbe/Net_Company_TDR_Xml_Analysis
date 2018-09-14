using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal.QiYeKaoQing;
using FileManagementModel;
using FileManagementUtil;
using FileManagementModel.QiYeKaoQing;

namespace FileManagementDal.QiYeKaoQing
{
    public class QYKQ_04_Dal
    {

        private string Name;
        private EnterpriseInfo Content;
        private DateTime Time;
        private string QYCode;
        public QYKQ_04_Dal(string name, EnterpriseInfo content, DateTime time)
        {
            this.Name = name;
            this.Content = content;        
            this.Time = time;
            this.QYCode = this.Content.QIYECODE;
        }
        public string Handle()
        {
            try
            {

                List<StaffInfo> newUserList = GetNewUserList(Content.users);
                List<StaffInfo> oldUserList = QYKQDal.GetUsers(QYCode);
                List<StaffInfo> AddList = new List<StaffInfo>();
                List<StaffInfo> DelList = new List<StaffInfo>();
                CompareCardId(newUserList, oldUserList, out AddList, out DelList);
                if (AddList.Count != 0)
                {
                    MyLibrary.Log.Warn("增卡开始；企业代码：" + QYCode);       
                    foreach(var v in AddList)
                    {
                        Add(QYCode,v.Name, v.ID.ToUpper());
                    }
                    MyLibrary.Log.Warn("增卡结束；企业代码：" + QYCode);
                }
                if (DelList.Count != 0)
                {
                    MyLibrary.Log.Warn("销卡开始；企业代码：" + QYCode);
                    foreach (var v in DelList)
                    {
                        Del(QYCode, v.Name, v.ID.ToUpper());
                    }
                    MyLibrary.Log.Warn("销卡结束；企业代码：" + QYCode);
                }
                QYKQDal.UpdateLastTime(QYCode);
                return "0";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        private List<StaffInfo> GetNewUserList(List<string> NewUserList)
        {
            StaffInfo TempUser;
            string[] NewArray;
            List<StaffInfo> NewUser = new List<StaffInfo>();
            if (NewUserList != null)
            {     
                foreach(var v in NewUserList)
                {
                    TempUser = new StaffInfo();
                    NewArray = v.Split(',');
                    TempUser.Name = NewArray[0];
                    TempUser.ID = NewArray[1];
                    NewUser.Add(TempUser);
                }

            }
            return NewUser;
        }

        //private void CompareCardId(List<StaffInfo> NewUserList, List<StaffInfo> OldUserList, out List<StaffInfo> OutAddList, out List<StaffInfo> OutDelList)
        //{

        //    List<StaffInfo> AddList = new List<StaffInfo>();
        //    List<StaffInfo> DelList = new List<StaffInfo>();
        //    StaffInfo info;
        //    bool IsFind;
        //    string CompareData = "";
        //    if (NewUserList.Count != 0)
        //    {
        //        for (int i = 0; i < NewUserList.Count; i++)
        //        {
        //            IsFind = false;
        //            CompareData = NewUserList[i].ID;
        //            for (int k = 0; k < OldUserList.Count; k++)
        //            {
        //                if (CompareData == OldUserList[k].ID && NewUserList[i].Name == OldUserList[k].Name)
        //                {
        //                    IsFind = true;
        //                    break;
        //                }
        //            }
        //            if (!IsFind)
        //            {
        //                info = new StaffInfo();
        //                info.ID = NewUserList[i].ID;
        //                info.Name = NewUserList[i].Name;
        //                AddList.Add(info);
        //            }

        //        }
        //        for (int i = 0; i < OldUserList.Count; i++)
        //        {
        //            IsFind = false;
        //            CompareData = OldUserList[i].ID;
        //            for (int k = 0; k < NewUserList.Count; k++)
        //            {
        //                if (CompareData == NewUserList[k].ID)
        //                {
        //                    IsFind = true;
        //                    break;
        //                }
        //            }
        //            if (!IsFind)
        //            {
        //                info = new StaffInfo();
        //                info.ID = OldUserList[i].ID;
        //                info.Name = OldUserList[i].Name;
        //                DelList.Add(info);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        DelList = OldUserList;
        //    }
        //    OutAddList = AddList;
        //    OutDelList = DelList;

        //}


        private void CompareCardId(List<StaffInfo> NewUserList, List<StaffInfo> OldUserList, out List<StaffInfo> OutAddList, out List<StaffInfo> OutDelList)
        {

            List<StaffInfo> AddList = new List<StaffInfo>();
            List<StaffInfo> DelList = new List<StaffInfo>();
            StaffInfo info;
            bool IsFind;

            if (NewUserList.Count != 0)
            {        
                foreach (var a in NewUserList)
                {
                    IsFind = false;         
                    foreach (var b in OldUserList)
                    {
                        if (a.ID == b.ID && a.Name == b.Name)
                        {
                            IsFind = true;
                            break;
                        }
                    }
                    if (!IsFind)
                    {
                        info = new StaffInfo();
                        info.ID = a.ID;
                        info.Name = a.Name;
                        AddList.Add(info);
                    }
                }                       
                foreach (var c in OldUserList)
                {
                    IsFind = false;
                    foreach (var d in NewUserList)
                    {
                        if (c.ID == d.ID)
                        {
                            IsFind = true;
                            break;
                        }
                    }
                    if (!IsFind)
                    {
                        info = new StaffInfo();
                        info.ID = c.ID;
                        info.Name = c.Name;
                        DelList.Add(info);
                    }
                }
            }
            else
            {
                DelList = OldUserList;
            }
            OutAddList = AddList;
            OutDelList = DelList;

        }


        private void Add(string QYCode ,string StaffName,string IdentityCardNo)
        {
         
            QykqInfo info = new QykqInfo();
            info.pi_CmdId = "04_1";
            info.pi_EnterpriseID = QYCode;
            info.pi_StaffName = StaffName;
            info.pi_IdentityCardNo = IdentityCardNo;
            info.pi_RegistrationTime = Time;
            info.pi_Dataintegrity = string.IsNullOrWhiteSpace(info.pi_IdentityCardNo) ? "1" : "0";
            info.pi_UploadType = "1";

            UInt16 ResultNum;
            string Reason;
            QYKQDal.Insert_Pro(info, out ResultNum, out Reason);
            if(ResultNum ==1)
            {
                MyLibrary.Log.Debug(Name + "_发卡出错；" + Reason + " 企业号码：" + QYCode+" 员工姓名："+StaffName+" 身份证号："+IdentityCardNo);
            }

        }

        private void Del(string QYCode, string StaffName, string IdentityCardNo)
        {

        
            QykqInfo info = new QykqInfo();
            info.pi_CmdId = "04_2";
            info.pi_EnterpriseID = QYCode;
            info.pi_IdentityCardNo = IdentityCardNo;

            UInt16 ResultNum;
            string Reason;
            QYKQDal.Insert_Pro(info, out ResultNum, out Reason);
            if (ResultNum == 1)
            {
                MyLibrary.Log.Debug(Name + "_销卡出错；" + Reason + " 企业号码：" + QYCode + " 员工姓名：" + StaffName + " 身份证号：" + IdentityCardNo);
            }


        }
    }
}
