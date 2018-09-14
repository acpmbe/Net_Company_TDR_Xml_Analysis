using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementUtil;
using FileManagementDal;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementDal.ChuZuWu.Cd_61506.Dt_0411;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    /// <summary>
    /// 逻辑处理（多人进出协议数据上传）
    /// </summary>
    public class CZW_61506_0411_199:ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_199(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "电子防盗门牌_多人进出协议数据上传";

        public bool Execute()
        {
            try
            {

                if (RepeatData.IsRepeatData(RepeatStr()))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }


                CZW_61506_0411_199_Mod Cm = CZW_61506_0411_199_Dal.GetMod(this._content);
                Cm.基站编号 = (uint)StationId;
                Cm.平台时间 = this.PlatformTime;

                Pro_IndataBase_ZNMP_Mod info = CZW_61506_0411_199_Dal.Get_Pro_Mod(Cm);

                List<Pro_IndataBase_ZNMP_Mod> list = GetList(info);


                 Pro_IndataBase_ZNMP_Bll c;
                string Result = "";
                foreach (var v in list)
                {
                    c = new Pro_IndataBase_ZNMP_Bll(v);
                    Result = c.Exec();
                    if (Result != "0")
                    {
                        MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
                    }
                }


            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }


        private string RepeatStr()
        {
            return ConverUtil.ByteToStr_Q(this._content, 6, this._content.Length - 7);
        }


        private List<Pro_IndataBase_ZNMP_Mod> GetList(Pro_IndataBase_ZNMP_Mod info)
        {
            List<Pro_IndataBase_ZNMP_Mod> list = new List<Pro_IndataBase_ZNMP_Mod>();
            int Count = Convert.ToInt32(info.Pi_Param1);
            if(Count==0)
            {
                return list;
            }
            string[] InAOut_A = info.Pi_Param2.Split(','); //进出数组
            string[] Height_A = info.Pi_Param3.Split(',');//身高数组 
            InAOut_Mod InInfo = new InAOut_Mod();
            InAOut_Mod OutInfo = new InAOut_Mod();

            for (int i = 0; i < Count; i++)
            {
                if (InAOut_A[i] == "1")
                {
                    InInfo.Count++;
                    if (string.IsNullOrWhiteSpace(InInfo.InAOut))
                    {
                        InInfo.InAOut = InAOut_A[i];
                    }
                    else
                    {
                        InInfo.InAOut += "," + InAOut_A[i];
                    }

                    if (string.IsNullOrWhiteSpace(InInfo.Height))
                    {
                        InInfo.Height = Height_A[i];
                    }
                    else
                    {
                        InInfo.Height += "," + Height_A[i];
                    }

                }
                else if (InAOut_A[i] == "0")
                {
                    OutInfo.Count++;
                    if (string.IsNullOrWhiteSpace(OutInfo.InAOut))
                    {
                        OutInfo.InAOut = InAOut_A[i];
                    }
                    else
                    {
                        OutInfo.InAOut += "," + InAOut_A[i];
                    }

                    if (string.IsNullOrWhiteSpace(OutInfo.Height))
                    {
                        OutInfo.Height = Height_A[i];
                    }
                    else
                    {
                        OutInfo.Height += "," + Height_A[i];
                    }
                }

            }

          
            Pro_IndataBase_ZNMP_Mod PInfo;

            if (InInfo.Count != 0)
            {
                PInfo = info.Clone();
                PInfo.Pi_Param1 = InInfo.Count.ToString();
                PInfo.Pi_Param2 = InInfo.InAOut;
                PInfo.Pi_Param3 = InInfo.Height;
                list.Add(PInfo);
            }


            if (OutInfo.Count != 0)
            {
                PInfo = info.Clone();
                PInfo.Pi_Param1 = OutInfo.Count.ToString();
                PInfo.Pi_Param2 = OutInfo.InAOut;
                PInfo.Pi_Param3 = OutInfo.Height;
                list.Add(PInfo);
            }


            return list;

        }

        /// <summary>
        /// 进出模型
        /// </summary>
        public class InAOut_Mod
        {
            /// <summary>
            /// 人数
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// 进出标识
            /// </summary>
            public string InAOut { get; set; }

            /// <summary>
            /// 身高
            /// </summary>
            public string Height { get; set; }
        }

    

        //public bool Execute()
        //{
        //    try
        //    {

        //        if (RepeatData.IsRepeatData(_content))
        //        {
        //            MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
        //            return true;
        //        }


        //        CZW_61506_0411_199_Mod Cm = CZW_61506_0411_199_Dal.GetMod(this._content);
        //        Cm.基站编号 = (uint)StationId;
        //        Cm.平台时间 = this.PlatformTime;

        //        Pro_IndataBase_ZNMP_Mod info = CZW_61506_0411_199_Dal.Get_Pro_Mod(Cm);


        //        Pro_IndataBase_ZNMP_Bll c = new Pro_IndataBase_ZNMP_Bll(info);
        //        string Result = c.Exec();
        //        if (Result != "0")
        //        {
        //            MyLibrary.Log.Debug(NAME + "出错：" + Result + " 原始代码:" + OriginalCode);
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MyLibrary.Log.Error(NAME + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
        //    }

        //    return true;
        //}
    }
}
