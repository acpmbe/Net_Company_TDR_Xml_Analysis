using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagement
{
    public class AuthorizeXmlFormat : IXmlFormat
    {
        private System.Xml.XmlDocument doc;
        public AuthorizeXmlFormat(XmlDocument doc)
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
                info.CardId = uint.Parse(node.SelectSingleNode("CardID").InnerText);
                info.CardType = byte.Parse(node.SelectSingleNode("CardType").InnerText);
                info.Identity = node.SelectSingleNode("Identity").InnerText;
                info.DevID = uint.Parse(node.SelectSingleNode("DevID").InnerText);
                infos.Add(info);
            }
            return infos;
        }
    }
}
