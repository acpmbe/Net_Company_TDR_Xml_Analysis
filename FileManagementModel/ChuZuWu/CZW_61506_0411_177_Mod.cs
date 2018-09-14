using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.ChuZuWu
{
    /// <summary>
    /// 输入实体（单人进出协议数据上传）
    /// </summary>
    public class CZW_61506_0411_177_Mod
    {

        public CZW_61506_0411_177_Mod()
        {
            防拆报警和当前门状态_信息 = new 防拆报警和当前门状态();
            设备状态_信息 = new 设备状态();
            烟感和激光使能_信息 = new 烟感和激光使能();
        }


        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }

        public byte? 环境状态 { get; set; }
        public byte? 环境值 { get; set; }
        public byte? 对地校准值 { get; set; }
        public byte? 工作状态 { get; set; }
        public Int16? 当前环境温度 { get; set; }
        public 防拆报警和当前门状态 防拆报警和当前门状态_信息 { get; set; }
        public byte? 电池电压 { get; set; }
        public byte? 热视电触发次数 { get; set; }
        public UInt16? 超声波总工作时间 { get; set; }
        public UInt16? 热释电总触发次数 { get; set; }
        public UInt16? 总震动次数 { get; set; }
        public Int16? 门左右倾斜角度 { get; set; }
        public 设备状态 设备状态_信息 { get; set; }
        public Int16? 门上下倾斜角度 { get; set; }
        public byte? 激光关门值 { get; set; }
        public 烟感和激光使能 烟感和激光使能_信息 { get; set; }
        public byte? RSSI值 { get; set; }
        public byte? 版本号 { get; set; }

        public class 防拆报警和当前门状态
        {
            public byte? 防拆报警 { get; set; }
            public byte? 当前门状态 { get; set; }

            public string Merge()
            {
                return this.防拆报警.ToString() + ","
                     + this.当前门状态.ToString();

            }



        }

        public class 设备状态
        {

            public byte? 超声波 { get; set; }
            public byte? 热释电 { get; set; }

            public string Merge()
            {

                return this.超声波.ToString() + ","
                    + this.热释电.ToString();

            }

        }


        public class 烟感和激光使能
        {

            public byte? 烟感级别 { get; set; }
            public byte? 激光使能 { get; set; }

            public string Merge()
            {

                return this.烟感级别.ToString() + ","
                     + this.激光使能.ToString();

            }

        }


    }
}
