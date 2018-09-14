using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public class SyncInfo
    {
        public string EQType { get; set; }
        public string EQID { get; set; }
        public string CommandID { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }

        public uint CardId { get; set; }

        public byte CardType { get; set; }

        public string Identity { get; set; }

        public uint DevID { get; set; }
        public string UploadType { get; set; }
    }
}
