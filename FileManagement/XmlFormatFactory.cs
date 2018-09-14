using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagement
{
    public class XmlFormatFactory
    {
        public static IXmlFormat Create(string fileName, XmlDocument doc)
        {
            IXmlFormat xmlFactory;
            if (fileName.StartsWith("0401_"))
            {
                
                xmlFactory = new AuthorizeXmlFormat(doc);
            }
            else
            {
                xmlFactory = new CommandXmlFormat(doc);
            }
            return xmlFactory;
        }
    }
} 
