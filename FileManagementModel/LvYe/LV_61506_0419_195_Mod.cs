using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.LvYe
{
    public class LV_61506_0419_195_Mod
    {

        public LV_61506_0419_195_Mod()
        {
            腿部信息 = new 腿部实体();
            手臂信息 = new 手臂实体();
            肩膀信息 = new 肩膀实体();
            面部信息 = new 面部实体();
            头部信息 = new 头部实体();
        }

        public uint? 基站编号 { get; set; }
        public DateTime 平台时间 { get; set; }
        public DateTime 设备时间 { get; set; }
        public string 中继号 { get; set; }
        public int? 设备类型 { get; set; }
        public UInt32? 设备编号 { get; set; }
        public int? 命令字 { get; set; }
        public byte? 最大身高 { get; set; }
        public byte? RSSI值 { get; set; }
        public byte? 版本号 { get; set; }
        public 腿部实体 腿部信息 { get; set; }
        public 手臂实体 手臂信息 { get; set; }
        public 肩膀实体 肩膀信息 { get; set; }
        public 面部实体 面部信息 { get; set; }
        public 头部实体 头部信息 { get; set; }

        public class 腿部实体
        {
            public byte? 拐点时间 { get; set; }
            public byte? 小波动次数 { get; set; }
            public byte? 对地波动次数 { get; set; }


            /// <summary>
            /// 合并字段（以逗号隔开）
            /// </summary>
            /// <returns></returns>
            public string Merge()
            {
                return this.拐点时间.ToString()
                    + ","
                    + this.小波动次数.ToString()
                    + ","
                    + this.对地波动次数.ToString();

            }
        }

        public class 手臂实体
        {
            public byte? 拐点时间 { get; set; }
            public byte? 对地波动次数 { get; set; }
            public byte? 小波动最大波动幅度 { get; set; }
            public byte? 小波动次数 { get; set; }

            public byte? 曲线变化级别 { get; set; }


            /// <summary>
            /// 合并字段（以逗号隔开）
            /// </summary>
            /// <returns></returns>
            public string Merge()
            {
                return this.拐点时间.ToString()
                    + ","
                    + this.对地波动次数.ToString()
                    + ","
                    + this.小波动最大波动幅度.ToString()
                    + ","
                    + this.小波动次数.ToString()
                    + ","
                    + this.曲线变化级别.ToString();
            }


        }

        public class 肩膀实体
        {
            public byte? 拐点时间 { get; set; }
            public byte? 对地波动次数 { get; set; }
            public byte? 小波动次数 { get; set; }
            public byte? 肩膀高度 { get; set; }
            public byte? 小波动最大波动幅度 { get; set; }
            public byte? 运行速度 { get; set; }

            /// <summary>
            /// 合并字段（以逗号隔开）
            /// </summary>
            /// <returns></returns>
            public string Merge()
            {
                return this.拐点时间.ToString()
                    + ","
                    + this.对地波动次数.ToString()
                    + ","
                    + this.小波动次数.ToString()
                    + ","
                    + this.肩膀高度.ToString()
                    + ","
                    + this.小波动最大波动幅度.ToString()
                    + ","
                    + this.运行速度.ToString();
            }



        }

        public class 面部实体
        {
            public byte? 拐点时间 { get; set; }
            public byte? 对地波动次数 { get; set; }
            public byte? 小波动次数 { get; set; }
            public byte? 小波动最大值 { get; set; }

            /// <summary>
            /// 合并字段（以逗号隔开）
            /// </summary>
            /// <returns></returns>
            public string Merge()
            {
                return this.拐点时间.ToString()
                    + ","
                    + this.对地波动次数.ToString()
                    + ","
                    + this.小波动次数.ToString()
                    + ","
                    + this.小波动最大值.ToString();

            }

        }

        public class 头部实体
        {
            public byte? 对地波动次数 { get; set; }
            public byte? 小波动次数 { get; set; }
            public byte? 门下驻停时间 { get; set; }
            public byte? 开门到关门时间 { get; set; }
            public byte? 进门肩膀高度 { get; set; }
            public byte? 关门震动级别 { get; set; }
            public byte? 手上是否有物品 { get; set; }
            public byte? 低头次数 { get; set; }
            public byte? 是否复杂波形 { get; set; }


            public byte? 是否有多人进入 { get; set; }
            public byte? 开关标志 { get; set; }
            public byte? 关门标志 { get; set; }
            public byte? 进出门标志 { get; set; }



            /// <summary>
            /// 合并字段（以逗号隔开）
            /// </summary>
            /// <returns></returns>
            public string Merge()
            {
                return this.对地波动次数.ToString()
                    + ","
                    + this.小波动次数.ToString()
                    + ","
                    + this.门下驻停时间.ToString()
                    + ","
                    + this.开门到关门时间.ToString()
                       + ","
                    + this.进门肩膀高度.ToString()
                    + ","
                    + this.关门震动级别.ToString()
                    + ","
                    + this.手上是否有物品.ToString()
                       + ","
                    + this.低头次数.ToString()
                    + ","
                    + this.是否复杂波形.ToString();


            }


        }
    }
}
