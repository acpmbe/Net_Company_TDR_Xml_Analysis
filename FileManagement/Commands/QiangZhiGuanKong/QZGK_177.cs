using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;
using FileManagementModel.QiangZhiGuanKong;
using FileManagementDal.QiangZhiGuanKong;



namespace FileManagement.Commands.QiangZhiGuanKong
{
    public class QZGK_177 : ICommand
    {

        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;

        public QZGK_177(string _cmdId, byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "上传GPRS信息"; } }


        public bool Execute()
        {

            try
            {
                int Count = _content.Length;
                if (Count == 29)
                {
                    Single_29(_content);
                }
                else if (Count == 30)
                {
                    Single_30(_content);
                }
                else
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }
        
            return true;
        }



        public void Single_29(byte[] content)
        {
            Pro_QiangZhiGuanKong_Mod info = new Pro_QiangZhiGuanKong_Mod();
            info.pi_CmdType = "1";
            info.pi_ListId = Guid.NewGuid().ToString("N");
            info.pi_DeviceTime = ConverUtil.Time(content, 0);                          //设备时间
            info.pi_StationLng = GetPosition(content, 6);                               //经度。
            info.pi_StationLat = GetPosition(content, 10);                             //维度。
            info.pi_param1 = content[14].ToString();                                   //防拆开关状态。
            info.pi_param2 = content[15].ToString();                                   //电量。
            info.pi_param3 = content[28].ToString();                                   //标志位。
            info.pi_param5 = ConverUtil.ByteToStr_Q(content, 18, 10);                  //手机串号。
            info.pi_param6 = content[16].ToString("D2") + content[17].ToString("D2"); //省市。
            info.pi_StationNo = StationId.ToString();                                   //基站编号。
            info.pi_ServiceTime = PlatformTime;                                         //平台时间。
            info.pi_InTime = DateTime.Now;                                              //入库时间。
            string Result = QiangZhiGuanKongDal.Handle(info);
            if (Result != "0")
            {
                MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
            }
        }

        public void Single_30(byte[] content)
        {
            Pro_QiangZhiGuanKong_Mod info = new Pro_QiangZhiGuanKong_Mod();
            info.pi_CmdType = "1";
            info.pi_ListId = Guid.NewGuid().ToString("N");
            info.pi_DeviceTime = ConverUtil.Time(content, 0);                          //设备时间
            info.pi_StationLng = GetPosition(content, 6);                               //经度。
            info.pi_StationLat = GetPosition(content, 10);                             //维度。
            info.pi_param1 = content[14].ToString();                                   //防拆开关状态。
            info.pi_param2 = content[15].ToString();                                   //电量。
            info.pi_param3 = content[28].ToString();                                   //标志位。
            info.pi_param4 = content[29].ToString();                                   //是否移动。
            info.pi_param5 = ConverUtil.ByteToStr_Q(content, 18, 10);                  //手机串号。
            info.pi_param6 = content[16].ToString("D2") + content[17].ToString("D2"); //省市。
            info.pi_StationNo = StationId.ToString();                                   //基站编号。
            info.pi_ServiceTime = PlatformTime;                                         //平台时间。
            info.pi_InTime = DateTime.Now;                                              //入库时间。
            string Result = QiangZhiGuanKongDal.Handle(info);
            if (Result != "0")
            {
                MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
            }


         
        }


        private string GetPosition(byte[] content,int start)
        {

            byte[] Data;
            Data = new byte[4];
            Array.Copy(content, start, Data, 0, 4);
            string Str = Data[0].ToString() + "." + Data[1].ToString("D2") + Data[2].ToString("D2") + Data[3].ToString("D2");
            return Convert.ToDouble(Str).ToString();

        }


    }
}
