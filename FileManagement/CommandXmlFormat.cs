using FileManagementUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagement
{
    public class CommandXmlFormat : IXmlFormat
    {
        private System.Xml.XmlDocument doc;
        public CommandXmlFormat(XmlDocument doc)
        {
            // TODO: Complete member initialization
            this.doc = doc;
          
        }
        public List<SyncInfo> GetSyncInfo()
        {
            SyncInfo info;
            List<SyncInfo> infos = new List<SyncInfo>();
            XmlNode datas = doc.SelectSingleNode("Datas");
            foreach (XmlNode node in datas.ChildNodes)
            {
                info = new SyncInfo();
                if (node.SelectSingleNode("CommandID")!=null)
                {
                    info.CommandID = node.SelectSingleNode("CommandID").InnerText;
                }
                else
                {
                    MyLibrary.Log.Error("CommandID node is null.Node info : " + node.ToString());
                    continue;
                }
                if (node.SelectSingleNode("Content") != null)
                {
                    info.Content = node.SelectSingleNode("Content").InnerText;

                }
                else
                {
                    MyLibrary.Log.Error("Content node is null.Node info : " + node.ToString());
                    continue;
                }
                info.EQID = node.SelectSingleNode("EQID").InnerText;
                info.EQType = node.SelectSingleNode("EQType").InnerText;
                info.Time = node.SelectSingleNode("Time").InnerText;                            
                infos.Add(info);
            }
            return infos;
        }
    }
}
