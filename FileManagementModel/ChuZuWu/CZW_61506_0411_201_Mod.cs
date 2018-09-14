using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{

    /// <summary>
    /// 输入实体（电子防盗门牌_门状态改变上传）
    /// </summary>
    public class CZW_61506_0411_201_Mod
    {

        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }

        public 门状态 门状态_信息 { get; set; }
        public byte? 进门累计统计 { get; set; }
        public byte? 出门累计统计 { get; set; }
        public byte? 版本号 { get; set; }
        public byte? RSSI值 { get; set; }


        public class 门状态
        {

     
            public byte? 开始门状态 { get; set; }
            public byte? 最后门状态 { get; set; }
            public byte? 关门标志 { get; set; }
            public byte? 开门标志 { get; set; }
            public byte? 触发前门状态 { get; set; }
          
        }


    }
}
