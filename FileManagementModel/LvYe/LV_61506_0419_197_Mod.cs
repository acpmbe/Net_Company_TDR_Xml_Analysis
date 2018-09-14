using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.LvYe
{
    public class LV_61506_0419_197_Mod
    {


        public LV_61506_0419_197_Mod()
        {
            进出结果1信息 = new 进出结果1();
            进出结果2信息 = new 进出结果2();
        }


        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }
        public byte? 最大身高 { get; set; }
        public byte? 进出超声波总用时 { get; set; }
        public byte? 出门关门用时 { get; set; }
        public byte? 进门后关门时间 { get; set; }
        public byte? 关门震动级别 { get; set; }


        public 进出结果1 进出结果1信息 { get; set; }

        public 进出结果2 进出结果2信息 { get; set; }

        public byte? 进出门标志 { get; set; }

        public byte? 进门累计统计 { get; set; }
        public byte? 出门累计统计 { get; set; }
        public byte? 门状态信息2 { get; set; }


        public byte? RSSI值 { get; set; }
        public byte? 版本号 { get; set; }



        public class 进出结果1
        {
            public byte? 算法1进门标志 { get; set; }
            public byte? 算法1出门标志 { get; set; }
            public byte? 算法1_1进门标志 { get; set; }
            public byte? 算法1_1出门标志 { get; set; }
            public byte? 算法1_2进门标志 { get; set; }
            public byte? 算法1_2出门标志 { get; set; }
            public byte? 算法1_3进门标志 { get; set; }
            public byte? 算法1_3出门标志 { get; set; }



            public string Merge()
            {
                return this.算法1进门标志.ToString() + ","
                    + this.算法1出门标志.ToString() + ","
                    + this.算法1_1进门标志.ToString() + ","
                    + this.算法1_1出门标志.ToString() + ","
                    + this.算法1_2进门标志.ToString() + ","
                    + this.算法1_2出门标志.ToString() + ","
                    + this.算法1_3进门标志.ToString() + ","
                    + this.算法1_3出门标志.ToString();


            }



        }

        public class 进出结果2
        {
            public byte? 算法2进门标志 { get; set; }
            public byte? 算法2出门标志 { get; set; }
            public byte? 算法1使能标志 { get; set; }
            public byte? 算法2使能标志 { get; set; }
            public byte? 开始门状态 { get; set; }
            public byte? 最后门状态 { get; set; }
            public byte? 开门标志 { get; set; }
            public byte? 关门标志 { get; set; }


            public string Merge()
            {
                return this.算法2进门标志.ToString() + ","
                    + this.算法2出门标志.ToString() + ","
                    + this.算法1使能标志.ToString() + ","
                    + this.算法2使能标志.ToString();



            }

        }
    }
}
