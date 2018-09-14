using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.DengJiJi
{
    /// <summary>
    /// 输入实体（登记机_绑定信息上报）
    /// </summary>
    public class DJJ_2050_Mod
    {
        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public string 有源卡ID { get; set; }

        public string 姓名 { get; set; }
        public string 民族 { get; set; }
        public string 身份信息类型 { get; set; }
        public int 号码长度 { get; set; }
        public string 证件号码 { get; set; }
    }
}
