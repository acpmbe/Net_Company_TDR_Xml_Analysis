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
    public class CZW_33 : ICommand
    {

        private byte[] _content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;

        private Tb_AutoDeployLog_Mod Info;
        public CZW_33(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {

            this._content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        private string Name { get { return "电子门牌上传"; } }
        public bool Execute()
        {

            try
            {

                byte[] bDianBiao1 = new byte[4];
                Array.Copy(_content, 0, bDianBiao1, 0, 4);
                string dianbiao1 = (Convert.ToUInt32(ConverUtil.ByteToStr_A(bDianBiao1), 16)).ToString();

                string dianbiaoState1 = _content[4].ToString();

                byte[] bDianBiao2 = new byte[4];
                Array.Copy(_content, 5, bDianBiao2, 0, 4);
                string dianbiao2 = (Convert.ToInt32(ConverUtil.ByteToStr_A(bDianBiao2), 16)).ToString();

                string dianbiaoState2 = _content[9].ToString();
                string sblx = "257";

                string room = Tb_DeviceInfo_Dal.Select(sblx, dianbiao1, dianbiaoState1);
                string bfState = dianbiaoState1 == "1" ? "1" : "2";


                Info = Tb_AutoDeployLog_Info(room, bfState);
                Tb_AutoDeployLog_Dal.Insert(Info);
                if (!string.IsNullOrEmpty(room))
                {

                    Tb_RoomInfo_Dal.Update(room, bfState);
                }
                room = Tb_DeviceInfo_Dal.Select(sblx, dianbiao2, dianbiaoState2);
                string bfState2 = dianbiaoState2 == "1" ? "1" : "2";

                Info = Tb_AutoDeployLog_Info(room, bfState2);
                Tb_AutoDeployLog_Dal.Insert(Info);

                if (!string.IsNullOrEmpty(room))
                {
                    Tb_RoomInfo_Dal.Update(room, bfState2);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(Name + "错误: " + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }


        private Tb_AutoDeployLog_Mod Tb_AutoDeployLog_Info(string otherId, string deployState)
        {

            Tb_AutoDeployLog_Mod info = new Tb_AutoDeployLog_Mod();
            info.NewListId = Guid.NewGuid().ToString("N");
            info.OldListId = "1";
            info.OtherType = "2";
            info.OtherId = otherId;
            info.DeployType = "2";
            info.DeployState = deployState;
            info.Status = "1";
            info.OperaTime = DateTime.Now;
            info.OperateType = "1";
            return info;
        }
    }
}
