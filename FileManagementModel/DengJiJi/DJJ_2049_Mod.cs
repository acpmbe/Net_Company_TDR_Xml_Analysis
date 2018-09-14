using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.DengJiJi
{


    /// <summary>
    /// 输入实体（登记机_有源卡ID信息上报）
    /// </summary>
    public class DJJ_2049_Mod
    {
        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public string 有源卡ID { get; set; }


    }
}
