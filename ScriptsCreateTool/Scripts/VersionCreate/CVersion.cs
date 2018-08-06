using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace GameTools
{
    [XmlRoot("Root")]
    public class CVersion
    {
        [XmlElement("version")]
        public string version;
        [XmlArray("res"),XmlArrayItem("res")]
        public List<Version> element=new List<Version>();
    }
    [XmlRoot("res")]
    public class Version
    {
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("size")]
        public string size;
        [XmlText()]
        public string element;
    }
}
