using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public interface IXmlFormat
    {
        List<SyncInfo> GetSyncInfo();
    }
}
