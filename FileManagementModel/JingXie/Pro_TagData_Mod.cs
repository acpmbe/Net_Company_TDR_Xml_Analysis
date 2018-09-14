using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementModel.JingXie
{
    public class Pro_TagData_Mod
    {


        /// <summary>
        /// 标签编号。
        /// </summary>
        public string TagID { get; set; }

        /// <summary>
        /// 基站编号。
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 标签时间。
        /// </summary>
        public DateTime TagTime { get; set; }

        /// <summary>
        /// 平台时间。
        /// </summary>
        public DateTime PlateTime { get; set; }

        /// <summary>
        /// 标签类型。
        /// </summary>
        public string TagType { get; set; }
    }
}
