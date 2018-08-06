using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameTools
{
    public class CJavaDataConfig
    {
        public string caption;
        public string folder;
        public string dbConfigFile;
        public string baseDao;
        public string package;
        public string manager;
        public string dbName;
        public string dbIp;
        public string dbport;
        public string dbUser;
        public string dbPsw;
        public string dbType = "MySql";
        public string verInfoTableName = "q_version";
        public string verInfoTablefield = "q_tablename";
        public string verInfoIntValueField = "q_int_value";
        public string verDescField = "q_desc";
        public string overLap = "true";

        public void LoadConfig(XmlElement Info)
        {
            caption = ConfigControl.GetXmlElementInnerText(Info, "caption");
            folder = ConfigControl.GetXmlElementInnerText(Info, "folder");
            dbConfigFile = ConfigControl.GetXmlElementInnerText(Info, "db_configFile");
            baseDao = ConfigControl.GetXmlElementInnerText(Info, "baseDao");
            package = ConfigControl.GetXmlElementInnerText(Info, "package_basic");
            manager = ConfigControl.GetXmlElementInnerText(Info, "manager");
            XmlElement dbConfig=Info.SelectSingleNode("db_config") as XmlElement;
            dbUser = ConfigControl.GetXmlElementInnerText(dbConfig, "Username");
            dbPsw = ConfigControl.GetXmlElementInnerText(dbConfig, "Password");
            dbIp = ConfigControl.GetXmlElementInnerText(dbConfig, "IPAddress");
            dbport = ConfigControl.GetXmlElementInnerText(dbConfig, "Port");
            dbName = ConfigControl.GetXmlElementInnerText(dbConfig, "Database");
        }

        public void WriteConfig(XmlDocument doc, XmlElement parenteElement)
        {
            XmlElement captionElement = ConfigControl.CreateNewElement(doc, "caption", caption);
            parenteElement.AppendChild(captionElement);
            XmlElement folderElement = ConfigControl.CreateNewElement(doc, "folder", folder);
            parenteElement.AppendChild(folderElement);
            XmlElement dbConfigFileElement = ConfigControl.CreateNewElement(doc, "db_configFile", dbConfigFile);
            parenteElement.AppendChild(dbConfigFileElement);
            XmlElement baseDaoElement = ConfigControl.CreateNewElement(doc, "baseDao", baseDao);
            parenteElement.AppendChild(baseDaoElement);
            XmlElement packageElement = ConfigControl.CreateNewElement(doc, "package_basic", package);
            parenteElement.AppendChild(packageElement);
            XmlElement managerElement = ConfigControl.CreateNewElement(doc, "manager", manager);
            parenteElement.AppendChild(managerElement);
            XmlElement dbConfigElement = ConfigControl.CreateNewElement(doc, "db_config");
            XmlElement dbTypeElement = ConfigControl.CreateNewElement(doc, "DbType", dbType);
            dbConfigElement.AppendChild(dbTypeElement);
            XmlElement userNameElement = ConfigControl.CreateNewElement(doc, "Username", dbUser);
            dbConfigElement.AppendChild(userNameElement);
            XmlElement pswElement = ConfigControl.CreateNewElement(doc, "Password", dbPsw);
            dbConfigElement.AppendChild(pswElement);
            XmlElement ipElement = ConfigControl.CreateNewElement(doc, "IPAddress", dbIp);
            dbConfigElement.AppendChild(ipElement);
            XmlElement portElement = ConfigControl.CreateNewElement(doc, "Port", dbport);
            dbConfigElement.AppendChild(portElement);
            XmlElement dbNameElement = ConfigControl.CreateNewElement(doc, "Database", dbName);
            dbConfigElement.AppendChild(dbNameElement);
            XmlElement verInfoElement = ConfigControl.CreateNewElement(doc, "VersionInfo");
            XmlElement tableNameElement = ConfigControl.CreateNewElement(doc, "TableName", verInfoTableName);
            verInfoElement.AppendChild(tableNameElement);
            XmlElement tableFieldElement = ConfigControl.CreateNewElement(doc, "TableField", verInfoTablefield);
            verInfoElement.AppendChild(tableFieldElement);
            XmlElement intValfieldElement = ConfigControl.CreateNewElement(doc, "IntValueField", verInfoIntValueField);
            verInfoElement.AppendChild(intValfieldElement);
            XmlElement descFieldElement = ConfigControl.CreateNewElement(doc, "DescField", verDescField);
            verInfoElement.AppendChild(descFieldElement);
            dbConfigElement.AppendChild(verInfoElement);
            parenteElement.AppendChild(dbConfigElement);
            XmlElement overLapElement = ConfigControl.CreateNewElement(doc, "overlap", overLap);
            parenteElement.AppendChild(overLapElement);
            
        }
    }
}
