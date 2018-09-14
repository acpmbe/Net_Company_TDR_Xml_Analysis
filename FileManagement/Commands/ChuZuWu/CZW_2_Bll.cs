using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ChuZuWu;
using FileManagement.Other.ChuZuWu;
using FileManagementUtil;
using FileManagementDal.ChuZuWu;
using FileManagementDal;
using FileManagementDal.DB.CZW.Table;

namespace FileManagement.Commands.ChuZuWu
{

    /// <summary>
    /// 逻辑处理（访客登记 _命令字2）
    /// </summary>
    public class CZW_2_Bll : ICommand
    {
        private byte[] Content;
        private ulong StationId;
        private DateTime PlatformTime;
        private string OriginalCode;
        public CZW_2_Bll(byte[] _content, ulong _StationId, DateTime _PlatformTime)
        {
            this.Content = _content;
            this.StationId = _StationId;
            this.PlatformTime = _PlatformTime;
            this.OriginalCode = ConverUtil.ByteToStr_A(_content);
        }

        public const string NAME = "访客登记 _命令字2";
        public bool Execute()
        {


            try
            {

                if (this.Content.Length != 189)
                {
                    MyLibrary.Log.Debug(NAME + "出错：正确长度189,目前长度" + Content.Length.ToString() + " 原始代码:" + OriginalCode);
                }


                if (RepeatData.IsRepeatData(Content))
                {
                    MyLibrary.Log.RepeatDataInfo("基站编号：" + StationId.ToString() + " 原始代码：" + OriginalCode);
                    return true;
                }

                CZW_2_Mod Cm = CZW_2_Dal.GetMod(this.Content);
                Cm.设备编号 = (uint)StationId;
                Tb_EIdentitycardBung_Dal dal = CZW_2_Dal.TableMod(Cm);

                bool IsOk = dal.Select_IdCard(Cm.身份证id);
                if (IsOk)
                {
                    dal.Update();
                }
                else
                {
                    dal.Insert();
                }


            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(NAME + "出错：" + ex.Message + " 原始代码:" + OriginalCode);
            }

            return true;
        }

    }
}
