using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementDal;

namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_548 : ICommand
    {
        private string CmdId;
        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_548(string _cmdId, byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.CmdId = _cmdId;
            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }
        private string Name { get { return "门戒通过中继刷卡数据上传"; } }
        public bool Execute()
        {

            try
            {
                if (_content.Length != 27)
                {
                    MyLibrary.Log.Debug(Name + "长度无效：原始代码：" + OriginalCode);
                    return true;
                }

                Pro_IndateBase_ZHMJ_Mod info = new Pro_IndateBase_ZHMJ_Mod();
                info.pi_bigtype = "1";
                info.pi_cardtype = _content[14].ToString();           //卡类型
                info.pi_cardid =  info.pi_cardtype == "0" ? ConverUtil.ByteToStr_Q(_content, 15, 8) : ConverUtil.ByteToStr_4(_content, 19); 
                info.pi_HEADCOUNT = _content[23].ToString();         //房间内人数
                info.pi_OPENTIMES = _content[24].ToString();        //每天开门次数          
                info.pi_stationno = StationId.ToString();
                info.pi_servicetime = PlatformTime;


                Other.ChuZuWu.Pro_IndateBase_ZHMJ_Bll c = new Other.ChuZuWu.Pro_IndateBase_ZHMJ_Bll(info);
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
