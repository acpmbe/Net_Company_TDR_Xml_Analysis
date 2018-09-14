using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagementModel.ZNQT;
using FileManagementUtil;
using FileManagementUtil.Data;
using FileManagementDal.DB.ZNQT.Process;

namespace FileManagementDal.ZNQT
{
  //public  class ZNQT_61443_8780_02_Dal
  //  {

  //      public ZNQT_61443_8780_02_Mod GetMod(byte[] content)
  //      {

  //          ZNQT_61443_8780_02_Mod info = new ZNQT_61443_8780_02_Mod();
  //          info.设备时间 = ConverUtil.Time(content, 0);
  //          info.SN号 = Bit.GetBitR(content[6], 0, 4);
  //          info.中继编号 = Bit.GetBitR(content[6], 5, 7);
  //          info.设备类型 = (UInt16)ConverUtil.ByteToInt_2(content, 7);
  //          info.设备编号 = ConverUtil.ByteToInt_4(content, 9);
  //          info.命令字 = content[13];
  //          info.内容 = ConverUtil.ByteToStr_Q(content, 14, 5);
  //          info.内容长度 = (byte)(info.内容.Length / 2);
  //          info.版本号 = Bit.GetBitR(content[18], 5, 7);

  //          return info;


  //      }

  //      public Pro_InDateBase_Dal Get_Pro_Mod(ZNQT_61443_8780_02_Mod info)
  //      {
  //          Pro_InDateBase_Dal m = new Pro_InDateBase_Dal();
  //          m.pi_stationno = info.基站编号.ToString();
  //          m.pi_version = info.版本号.ToString();
  //          m.pi_sn = info.SN号.ToString();
  //          m.pi_relayno = info.中继编号.ToString();
  //          m.pi_servicetime = info.平台时间;
  //          m.pi_devicetime = info.设备时间;
  //          m.pi_devicetype = info.设备类型.ToString();
  //          m.pi_devicecode = info.设备编号.ToString();
  //          m.pi_cmdid = info.命令字.ToString();
  //          m.pi_content = info.内容;
  //          m.pi_length = info.内容长度.ToString();
  //          return m;


  //      }
  //  }
}
