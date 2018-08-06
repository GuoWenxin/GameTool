using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GameTools
{
    public class CDataBaseInfo
    {
        public string dbType;
        public string address;
        public string title;
        public string databaseName;
        public string userName;
        public string password;
        public string port;
        public string versionTableName;
        public string versionTableField;
        public string versionValueField;
        public string versionDescField;
        public string localPositionPath;

        public CDataBaseInfo()
        {
            
        }
        public CDataBaseInfo(XmlElement dbElement)
        {
            dbType = ConfigControl.GetXmlElementInnerText(dbElement, "DbType");
            address = ConfigControl.GetXmlElementInnerText(dbElement, "IPAddress");
            title = ConfigControl.GetXmlElementInnerText(dbElement, "Title");
            databaseName = ConfigControl.GetXmlElementInnerText(dbElement, "Database");
            userName = ConfigControl.GetXmlElementInnerText(dbElement, "Username");
            password = ConfigControl.GetXmlElementInnerText(dbElement, "Password");
            port = ConfigControl.GetXmlElementInnerText(dbElement, "Port");
            XmlElement versionElement = ConfigControl.GetXmlElement(dbElement, "VersionInfo");
            versionTableName = ConfigControl.GetXmlElementInnerText(versionElement, "TableName");
            versionTableField = ConfigControl.GetXmlElementInnerText(versionElement, "TableField");
            versionValueField = ConfigControl.GetXmlElementInnerText(versionElement, "IntValueField");
            versionDescField = ConfigControl.GetXmlElementInnerText(versionElement, "DescField");
            localPositionPath = ConfigControl.GetXmlElementInnerText(dbElement, "LocalPositionPath");
        }

        public void AddToConfig(XmlDocument doc,string path, XmlElement parent)
        {
            XmlElement dbInfoElement = doc.CreateElement("DatabaseInfo");
            XmlElement dbtypElement = doc.CreateElement("DbType");
            dbtypElement.InnerText = dbType;
            XmlElement dbTitleElement = doc.CreateElement("Title");
            dbTitleElement.InnerText = title;
            XmlElement dbUsernameElement = doc.CreateElement("Username");
            dbUsernameElement.InnerText = userName;
            XmlElement dbPasswordElement = doc.CreateElement("Password");
            dbPasswordElement.InnerText = password;
            XmlElement dbIPAddressElement = doc.CreateElement("IPAddress");
            dbIPAddressElement.InnerText = address;
            XmlElement dbPortElement = doc.CreateElement("Port");
            dbPortElement.InnerText = port;
            XmlElement dbDatabaseElement = doc.CreateElement("Database");
            dbDatabaseElement.InnerText = databaseName;
            XmlElement dbVersionInfoElement = doc.CreateElement("VersionInfo");
            XmlElement dbTableNameElement = doc.CreateElement("TableName");
            dbTableNameElement.InnerText = versionTableName;
            XmlElement dbTableFieldElement = doc.CreateElement("TableField");
            dbTableFieldElement.InnerText = versionTableField;
            XmlElement dbIntValueFieldElement = doc.CreateElement("IntValueField");
            dbIntValueFieldElement.InnerText = versionValueField;
            XmlElement dbDescFieldElement = doc.CreateElement("DescField");
            dbDescFieldElement.InnerText = versionDescField;
            XmlElement dbLocalPositionPathElement = doc.CreateElement("LocalPositionPath");
            dbLocalPositionPathElement.InnerText = localPositionPath;
            dbInfoElement.AppendChild(dbtypElement);
            dbInfoElement.AppendChild(dbTitleElement);
            dbInfoElement.AppendChild(dbUsernameElement);
            dbInfoElement.AppendChild(dbPasswordElement);
            dbInfoElement.AppendChild(dbIPAddressElement);
            dbInfoElement.AppendChild(dbPortElement);
            dbInfoElement.AppendChild(dbDatabaseElement);
            dbInfoElement.AppendChild(dbVersionInfoElement);
            dbInfoElement.AppendChild(dbLocalPositionPathElement);
            dbVersionInfoElement.AppendChild(dbTableNameElement);
            dbVersionInfoElement.AppendChild(dbTableFieldElement);
            dbVersionInfoElement.AppendChild(dbIntValueFieldElement);
            dbVersionInfoElement.AppendChild(dbDescFieldElement);
            parent.AppendChild(dbInfoElement);
            doc.Save(path);
        }

        public  void ModifyNodeInConfig(XmlDocument doc,string path, XmlElement node)
        {
            ConfigControl.SetXmlelementInnerText(node, "DbType", dbType, doc);
            ConfigControl.SetXmlelementInnerText(node, "Title", title, doc);
            ConfigControl.SetXmlelementInnerText(node, "Username", userName, doc);
            ConfigControl.SetXmlelementInnerText(node, "Password", password, doc);
            ConfigControl.SetXmlelementInnerText(node, "IPAddress", address, doc);
            ConfigControl.SetXmlelementInnerText(node, "Port", port, doc);
            ConfigControl.SetXmlelementInnerText(node, "Database", databaseName, doc);
            ConfigControl.SetXmlelementInnerText(node, "TableName", versionTableName, doc);
            ConfigControl.SetXmlelementInnerText(node, "TableField", versionTableField, doc);
            ConfigControl.SetXmlelementInnerText(node, "IntValueField", title, doc);
            ConfigControl.SetXmlelementInnerText(node, "DescField", versionDescField, doc);
            ConfigControl.SetXmlelementInnerText(node, "Title", title, doc);
            ConfigControl.SetXmlelementInnerText(node, "LocalPositionPath",localPositionPath,doc);
            doc.Save(path);
        }
    }
}
