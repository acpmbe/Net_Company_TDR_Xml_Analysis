using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementDal.ChuZuWu;
using FileManagementUtil;
using FileManagementModel.ChuZuWu;

namespace FileManagement.Commands.ChuZuWu
{
    public class CZW_23 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_23(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "有源卡"; } }

        public bool Execute()
        {
            try
            {
                byte[] bKaHao = new byte[4];
                Array.Copy(_content, 0, bKaHao, 0, 4);
                string YouYuanKa = (Convert.ToUInt32(ConverUtil.ByteToStr_A(bKaHao), 16)).ToString();

                byte[] bEsiteNum = new byte[4];
                Array.Copy(_content, 4, bEsiteNum, 0, 4);
                string EJKaHao = (Convert.ToUInt32(ConverUtil.ByteToStr_A(bEsiteNum), 16)).ToString();

                byte[] IdentitycardByte = new byte[9];
                Array.Copy(_content, 8, IdentitycardByte, 0, 9);
                string Identitycard = ConverUtil.ByteToStr_A(IdentitycardByte).Replace('A', 'X').TrimStart('0');

                Pro_IndateBase_Mod info = new Pro_IndateBase_Mod();
                info.pi_bigtype = "3";
                info.pi_devicetime = PlatformTime;
                info.pi_devicetype = "270";
                info.pi_devicecode = YouYuanKa;
                info.pi_protocoltype = EJKaHao;
                info.pi_param1 = EJKaHao;
                info.pi_param2 = Identitycard;
                info.pi_stationno = StationId.ToString();

                int resultNo;
                string reason;
                int status;
                string wechatid;


                Pro_IndateBase_Dal.Exec(info, out resultNo, out reason, out status, out wechatid);
                if (resultNo == 1)
                {
                    MyLibrary.Log.Debug(Name + "出错"+ " Reason：" + reason+ " 原始代码:" + OriginalCode);
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
