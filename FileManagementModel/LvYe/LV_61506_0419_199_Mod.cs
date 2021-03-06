﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.LvYe
{
    public class LV_61506_0419_199_Mod
    {

        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }

        public byte? 进出几人次 { get; set; }
        public 进出方向标识 进出方向标识_信息 { get; set; }
        public 每个人身高 每个人身高_信息 { get; set; }
        public 进出结果1 进出结果1_信息 { get; set; }
        public 进出结果2 进出结果2_信息 { get; set; }


        public byte? 进门累计统计 { get; set; }
        public byte? 出门累计统计 { get; set; }
        public byte? 门状态信息2 { get; set; }


        public byte? RSSI值 { get; set; }
        public byte? 版本号 { get; set; }

        public class 进出方向标识
        {
            public byte? 第1个人的进出方向 { get; set; }
            public byte? 第2个人的进出方向 { get; set; }
            public byte? 第3个人的进出方向 { get; set; }
            public byte? 第4个人的进出方向 { get; set; }
            public byte? 第5个人的进出方向 { get; set; }
            public byte? 第6个人的进出方向 { get; set; }
            public byte? 第7个人的进出方向 { get; set; }
            public byte? 第8个人的进出方向 { get; set; }

            public string Merge()
            {
                return this.第1个人的进出方向.ToString() + ","
                     + this.第2个人的进出方向.ToString() + ","
                     + this.第3个人的进出方向.ToString() + ","
                     + this.第4个人的进出方向.ToString() + ","
                     + this.第5个人的进出方向.ToString() + ","
                     + this.第6个人的进出方向.ToString() + ","
                     + this.第7个人的进出方向.ToString() + ","
                     + this.第8个人的进出方向.ToString();



            }

        }

        public class 每个人身高
        {

            public byte? 第1个人身高 { get; set; }
            public byte? 第2个人身高 { get; set; }
            public byte? 第3个人身高 { get; set; }
            public byte? 第4个人身高 { get; set; }
            public byte? 第5个人身高 { get; set; }
            public byte? 第6个人身高 { get; set; }
            public byte? 第7个人身高 { get; set; }
            public byte? 第8个人身高 { get; set; }

            public string Merge()
            {
                return this.第1个人身高.ToString() + ","
                     + this.第2个人身高.ToString() + ","
                     + this.第3个人身高.ToString() + ","
                     + this.第4个人身高.ToString() + ","
                     + this.第5个人身高.ToString() + ","
                     + this.第6个人身高.ToString() + ","
                     + this.第7个人身高.ToString() + ","
                     + this.第8个人身高.ToString();




            }

        }

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
