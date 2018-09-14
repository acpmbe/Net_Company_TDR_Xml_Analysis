using FileManagement.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public class FileFactory
    {
      
        public static ICommandFactory Create(string fileName, System.Xml.XmlDocument doc)
        {
            ICommandFactory cmdFactory;
            IXmlFormat xmlFormat = new CommandXmlFormat(doc);

            if (fileName.StartsWith("0101_"))
            {
                cmdFactory = new WxmjCommandFactory(xmlFormat);
            }
            else if (fileName.StartsWith("0301_"))
            {
                cmdFactory = new QykqCommandFactory(xmlFormat);
            }
            else if (fileName.StartsWith("0401_"))
            {
                cmdFactory = new WxmjAuthorizeCommandFactory(xmlFormat);
            }                                                
            else if (fileName.StartsWith("1201_"))
            {
                cmdFactory = new ChuZuWuAnFangFactory(xmlFormat);
            }
            else if (fileName.StartsWith("1301_"))
            {
                cmdFactory = new MenJinShouQuanFactory(xmlFormat);
            }
            else if (fileName.StartsWith("1401_"))
            {
                cmdFactory = new DuanXinFaSongFactory(xmlFormat);
            }
            else if (fileName.StartsWith("1601_"))
            {
                cmdFactory = new MenJinErQiFactory(xmlFormat);
            }
            else if (fileName.StartsWith("1602_"))
            {
                cmdFactory = new HouseAndUserCardFactory(xmlFormat);
            }        
            else if (fileName.StartsWith("2101_"))
            {
                cmdFactory = new QiYeFangHuFactory(xmlFormat);
            }
            else if (fileName.StartsWith("2401_"))
            {
                cmdFactory = new AgreementFormatFactory(xmlFormat);
            }
            else if (fileName.StartsWith("2701_"))
            {
                cmdFactory = new QiangZhiGuanKongFactory(xmlFormat);
            }
            else if (fileName.StartsWith("3101_"))
            {
                cmdFactory = new SocialAppTerminalFactory(xmlFormat);
            }
            else if (fileName.StartsWith("3201_"))
            {
                cmdFactory = new YiKaGuanChuanFactory(xmlFormat);
            }
            else if (fileName.StartsWith("3301_"))
            {
                cmdFactory = new JingXieFactory(xmlFormat);
            }
            else if (fileName.StartsWith("3501_"))
            {
                cmdFactory = new LvYeFactory(xmlFormat);
            }
            else if (fileName.StartsWith("3521_"))
            {
                cmdFactory = new DengJiJiFactory(xmlFormat);
            }
            //else if (fileName.StartsWith("3601_"))
            //{
            //    cmdFactory = new ZNQTFactory(xmlFormat);
            //}      
            else
            {
                return null;
            }
            return cmdFactory;

        }



    }
}
