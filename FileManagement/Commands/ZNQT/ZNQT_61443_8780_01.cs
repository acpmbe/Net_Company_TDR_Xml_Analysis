using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FileManagement.Commands.ZNQT
{
    //public class ZNQT_61443_8780_01 : ICommand
    //{

    //    private byte[] _content;
    //    private ulong StationId;
    //    private DateTime PlatformTime;
    //    private string OriginalCode;
    //    public ZNQT_61443_8780_01(byte[] _content, ulong _StationId, DateTime _PlatformTime)
    //    {

    //        this._content = _content;
    //        this.StationId = _StationId;
    //        this.PlatformTime = _PlatformTime;
    //        this.OriginalCode = ConverUtil.ByteToStr_A(_content);
    //    }


    //    public const string NAME = "设备心跳";
    //    public bool Execute()
    //    {

    //        try
    //        {


    //            ZNQT_61443_8780_01_Dal dal = new ZNQT_61443_8780_01_Dal();
    //            ZNQT_61443_8780_01_Mod info = dal.GetMod(this._content);
    //            info.基站编号 = (uint)StationId;
    //            info.平台时间 = PlatformTime;

    //            Pro_InDateBase_Dal pro = dal.Get_Pro_Mod(info);
        
    //            Pro_InDateBase_Dal.OutMod OutMod = pro.Exec();

    //            if (OutMod.resultNum != 0)
    //            {
    //                MyLibrary.Log.Debug(NAME + "调用过程出错：" + OutMod.reason + " 原始代码:" + OriginalCode);
    //            }




    //        }
    //        catch (Exception ex)
    //        {
    //            MyLibrary.Log.Error(NAME + "错误：" + ex.Message + " 原始代码:" + OriginalCode);
    //        }

    //        return true;
    //    }
    //}
}
