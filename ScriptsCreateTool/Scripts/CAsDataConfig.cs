using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameTools
{
    public class CAsDataConfig
    {
        public string caption;
        public string folder;
        public string package;
        public string[] beanImport;
        public string[] containerImport;
        public string isSet;

        public void LoadConfig(XmlElement info)
        {
            caption = ConfigControl.GetXmlElementInnerText(info, "caption");
            folder = ConfigControl.GetXmlElementInnerText(info, "folder");
            package = ConfigControl.GetXmlElementInnerText(info, "package_basic");
            XmlElement beanImportElement=info.SelectSingleNode("beanImport") as XmlElement;
            XmlNodeList beanList = beanImportElement.SelectNodes("string");
            if (beanList.Count>0)
            {
                beanImport = new string[beanList.Count];
                for (int i = 0; i < beanList.Count; i++)
                {
                    beanImport[i] = ((XmlElement) beanList[i]).InnerText;
                }
            }
            XmlElement containerImpoerElement=info.SelectSingleNode("containerImport") as XmlElement;
            XmlNodeList containerList = containerImpoerElement.SelectNodes("string");
            if (containerList.Count>0)
            {
                containerImport=new string[containerList.Count];
                for (int i = 0; i < containerList.Count; i++)
                {
                    containerImport[i] = ((XmlElement) containerList[i]).InnerText;
                }
            }
            isSet = ConfigControl.GetXmlElementInnerText(info, "isSet");
        }

        public void WriteConfig(XmlDocument doc, XmlElement parent)
        {
            XmlElement capterElement = doc.CreateElement("caption");
            if (!string.IsNullOrEmpty(caption))
            {
                capterElement.InnerText = caption;
            }
            parent.AppendChild(capterElement);
            XmlElement folderElement = doc.CreateElement("folder");
            if (!string.IsNullOrEmpty(folder))
            {
                folderElement.InnerText = folder;
            }
            parent.AppendChild(folderElement);
            XmlElement packageElement = doc.CreateElement("package_basic");
            if (!string.IsNullOrEmpty(package))
            {
                packageElement.InnerText = package;
            }
            parent.AppendChild(packageElement);
            XmlElement beanImportElement = doc.CreateElement("beanImport");
            if (beanImport!=null)
            {
                foreach (var beam in beanImport)
                {
                    XmlElement beanElement = doc.CreateElement("string");
                    if (!string.IsNullOrEmpty(beam))
                    {
                        beanElement.InnerText = beam;
                    }
                    beanImportElement.AppendChild(beanElement);
                }
            }
            parent.AppendChild(beanImportElement);
            XmlElement containerElement = doc.CreateElement("containerImport");
            if (containerImport!=null)
            {
                foreach (var contain in containerImport)
                {
                    XmlElement containElement = doc.CreateElement("string");
                    if (!string.IsNullOrEmpty(contain))
                    {
                        containElement.InnerText = contain;
                    }
                    containerElement.AppendChild(containElement);
                }
            }
            parent.AppendChild(containerElement);
            XmlElement isSetElement = doc.CreateElement("isSet");
            if (!string.IsNullOrEmpty(isSet))
            {
                isSetElement.InnerText = isSet;
            }
            parent.AppendChild(isSetElement);
        }
    }
}
