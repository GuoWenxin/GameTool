using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameTools
{
    class ConfigControl
    {
        public static XmlDocument GetXmlDocument(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc;
        }
        public static XmlElement GetXmlRootAsElement(XmlDocument doc,string nodeName)
        {
            XmlNode node = doc.SelectSingleNode(nodeName);
            if (node==null)
            {
                return null;
            }
            XmlElement element = (XmlElement) node;
            return element;
        }

        public static XmlElement GetXmlElement(XmlElement parent, string childNode)
        {
            XmlElement element = parent.SelectSingleNode(childNode) as XmlElement;
            return element;
        }
        /// <summary>
        /// 根据父节点获取子节点的Inner值
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childNode"></param>
        /// <returns></returns>
        public static string GetXmlElementInnerText(XmlElement parent,string childNode)
        {
            XmlElement element = parent.SelectSingleNode(childNode) as XmlElement;
            if (element!=null)
            {
                return element.InnerText.Trim();
            }
            return "";
        }
        public static void SetXmlelementInnerText(XmlElement parent, string childNode, bool value, XmlDocument doc)
        {
            XmlElement element = parent.SelectSingleNode(childNode) as XmlElement;
            string tempStr = value ? "true" : "false";
            if (element != null)
            {
                element.InnerText = tempStr;
            }
            else
            {
                if (doc != null)
                {
                    XmlElement ele = CreateNewElement(doc, childNode, tempStr);
                    parent.AppendChild(ele);
                }
            }
        }
        public static void SetXmlelementInnerText(XmlElement parent, string childNode, string value,XmlDocument doc )
        {
            XmlElement element = parent.SelectSingleNode(childNode) as XmlElement;
            if (element!=null)
            {
                element.InnerText = value;
            }
            else
            {
                if (doc != null)
                {
                    XmlElement ele = CreateNewElement(doc, childNode, value);
                    parent.AppendChild(ele);
                }
            }
        }

        public static XmlElement CreateNewElement(XmlDocument doc,string eleName ,string innerText)
        {
            XmlElement element = doc.CreateElement(eleName);
            if (!string.IsNullOrEmpty(innerText))
            {
                element.InnerText = innerText;
            }
            return element;
        }
        public static XmlElement CreateNewElement(XmlDocument doc, string eleName)
        {
            XmlElement element = doc.CreateElement(eleName);
            return element;
        }
        public static CMessages ReadMessageXml(string path)
        {
            CMessages messages=new CMessages();
            XmlDocument doc = GetXmlDocument(path);
            XmlElement root = GetXmlRootAsElement(doc, "messages");
            if (root!=null)
            {
                messages.ID = root.GetAttribute("id");
                FileInfo fi=new FileInfo(path);
                string fileFullName = fi.Name;
                if (fileFullName.Contains("_"))
                {
                    messages.name = fileFullName.Substring(0, fileFullName.LastIndexOf("_"));
                }
                else
                {
                    messages.name = fileFullName.Substring(0, fileFullName.IndexOf(".xml"));
                }
                messages.explain = root.GetAttribute("explain").Replace("\n","").Replace("\r","").Replace("\t","");
                messages.import = root.GetAttribute("package");
                messages.beanSuper = root.GetAttribute("beansuper");
                messages.handler = root.GetAttribute("handler");
                XmlNodeList beanList = root.SelectNodes("bean");
                if (beanList.Count>0)
                {
                    messages.beans=new CBean[beanList.Count];
                    for (int i = 0; i < beanList.Count; i++)
                    {
                        XmlElement element = (XmlElement) beanList[i];
                        messages.beans[i]=new CBean();
                        messages.beans[i].name = element.GetAttribute("name");
                        messages.beans[i].explain = element.GetAttribute("explain").Replace("\n","").Replace("\r", "").Replace("\t", "");
                        XmlNodeList classItemList = element.ChildNodes;
                        if (classItemList!=null && classItemList.Count > 0)
                        {
                            messages.beans[i].items = new List<CMessgaeItem>();
                            foreach (XmlNode item in classItemList)
                            {
                                if (item.LocalName == "field" || item.LocalName == "list")
                                {
                                    messages.beans[i].items.Add( new CMessgaeItem((XmlElement)item));
                                }

                            }
                        }
                        XmlNodeList fieldList = element.SelectNodes("field");
                        if (fieldList.Count>0)
                        {
                            messages.beans[i].fileds=new CField[fieldList.Count];
                            for (int j = 0; j < fieldList.Count; j++)
                            {
                                XmlElement fieldElement = (XmlElement) fieldList[j];
                                messages.beans[i].fileds[j]=new CField();
                                messages.beans[i].fileds[j].name = fieldElement.GetAttribute("name");
                                messages.beans[i].fileds[j].explain = fieldElement.GetAttribute("explain").Replace("\n","").Replace("\r", "").Replace("\t", "");
                                messages.beans[i].fileds[j].fieldType = fieldElement.GetAttribute("class");
                            }
                        }
                        XmlNodeList listList = element.SelectNodes("list");
                        if (listList.Count>0)
                        {
                            messages.beans[i].lists = new CList[listList.Count];
                            for (int j = 0; j < listList.Count; j++)
                            {
                                XmlElement fieldElement = (XmlElement)listList[j];
                                messages.beans[i].lists[j] = new CList();
                                messages.beans[i].lists[j].name = fieldElement.GetAttribute("name");
                                messages.beans[i].lists[j].explain = fieldElement.GetAttribute("explain").Replace("\n","").Replace("\r", "").Replace("\t", "");
                                messages.beans[i].lists[j].listType = fieldElement.GetAttribute("class");
                            }
                        }
                    }
                }
                XmlNodeList messageList = root.SelectNodes("message");
                if (messageList.Count>0)
                {
                    messages.messages=new CMessage[messageList.Count];
                    for (int i = 0; i < messageList.Count; i++)
                    {
                        XmlElement messageElement = (XmlElement) messageList[i];
                        messages.messages[i]=new CMessage();
                        messages.messages[i].name = messageElement.GetAttribute("name");
                        messages.messages[i].ID = messageElement.GetAttribute("id");
                        messages.messages[i].explain = messageElement.GetAttribute("explain").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                        messages.messages[i].msType = messageElement.GetAttribute("type");
                        XmlNodeList classItemList = messageElement.ChildNodes;
                        if (classItemList.Count>0)
                        {
                            messages.messages[i].items=new List<CMessgaeItem>();
                            int j = 0;
                            foreach (XmlNode item in classItemList)
                            {
                                if (item.LocalName=="field" || item.LocalName=="list")
                                {
                                    messages.messages[i].items.Add(new CMessgaeItem((XmlElement)item));
                                    j++;
                                }
                                
                            }
                        }
                        XmlNodeList fieleList = messageElement.SelectNodes("field");
                        if (fieleList.Count > 0)
                        {
                            messages.messages[i].fields = new CField[fieleList.Count];
                            for (int j = 0; j < fieleList.Count; j++)
                            {
                                XmlElement fieldElement = (XmlElement)fieleList[j];
                                messages.messages[i].fields[j] = new CField();
                                messages.messages[i].fields[j].fieldType = fieldElement.GetAttribute("class");
                                messages.messages[i].fields[j].name = fieldElement.GetAttribute("name");
                                messages.messages[i].fields[j].explain = fieldElement.GetAttribute("explain").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                            }
                        }
                        XmlNodeList listList = messageElement.SelectNodes("list");
                        if (listList.Count > 0)
                        {
                            messages.messages[i].lists = new CList[listList.Count];
                            for (int j = 0; j < listList.Count; j++)
                            {
                                XmlElement fieldElement = (XmlElement)listList[j];
                                messages.messages[i].lists[j] = new CList();
                                messages.messages[i].lists[j].name = fieldElement.GetAttribute("name");
                                messages.messages[i].lists[j].explain = fieldElement.GetAttribute("explain").Replace("\n", "").Replace("\r", "").Replace("\t", "");
                                messages.messages[i].lists[j].listType = fieldElement.GetAttribute("class");
                            }
                        }

                    }
                }
            }
            return messages;
        }
    }
}
