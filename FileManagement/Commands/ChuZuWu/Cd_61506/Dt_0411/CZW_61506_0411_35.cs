using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementUtil;

namespace FileManagement.Commands.ChuZuWu.Cd_61506.Dt_0411
{
    public class CZW_61506_0411_35:ICommand
    {
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_61506_0411_35(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }


        private readonly string Name = "电子防盗门牌_第三可靠级进门数据采集上传";
        public bool Execute()
        {

            try
            {

                if (FileManagementDal.RepeatData.IsRepeatData(_content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }

                Pro_IndataBase_ZNMP_Mod info = new Pro_IndataBase_ZNMP_Mod();
                info.Pi_StationNo = StationId.ToString();
                info.Pi_ServiceTime = PlatformTime;
                info.Pi_DeviceTime = ConverUtil.Time(_content, 0);
                info.Pi_RelayNo = _content[6].ToString();
                info.Pi_DeviceType = ConverUtil.ByteToStr_2(_content, 7);
                info.Pi_DeviceCode = ConverUtil.ByteToStr_4(_content, 9);
                info.Pi_ProtocolType = _content[13].ToString();

                info.Pi_Param1 = _content[14].ToString(); //进门人数
                info.Pi_Param2 = _content[15].ToString(); //第1级别进门累计
                info.Pi_Param3 = _content[16].ToString(); //第1级别出门累计
                info.Pi_Param4 = _content[17].ToString(); //第3级别进门累计
                info.Pi_Param5 = _content[18].ToString(); //第3级别出门累计
                info.Pi_Param6 = _content[19].ToString(); //第5级别进门累计
                info.Pi_Param7 = _content[20].ToString(); //第5级别出门累计

                info.Pi_Param8 = _content[29].ToString(); //进出门校准最大身高
                info.Pi_Param9 = _content[30].ToString();  //进出门实测最大身高
                info.Pi_Param10 = _content[31].ToString(); //对地校准值
                info.Pi_Rssi = _content[33].ToString(); //RSSI值。
                info.Pi_Version = _content[34].ToString(); //版本号。

                Pro_IndataBase_ZNMP_Bll c = new Pro_IndataBase_ZNMP_Bll(info);
                string Result = c.Exec();
                if (Result != "0")
                {
                    MyLibrary.Log.Debug(Name + "出错：" + Result + " 原始代码:" + OriginalCode);
                }

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }

    }
}
