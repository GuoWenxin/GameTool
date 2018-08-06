using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameTools
{
    class Global
    {
        /// <summary>数值文件夹</summary>
        public  static string Folder { get; set; }
        /// <summary>过滤工作簿 </summary>
        public  static string FilterSheets { get; set; }
        /// <summary>程序是否开启自动解析文件</summary>
        public  static  bool StartLoadFolder { get; set; }
        /// <summary>解析数据 </summary>
        public  static  bool LoadData { get; set; }
        /// <summary>输出资源路径</summary>
        public  static  string ResFolder { get; set; }
        /// <summary>是否从数据库加载资源</summary>
        public  static  bool IsDataBase { get; set; }
        /// <summary>是否从数据库读取资源生成文件 </summary>
        public  static  bool IsDisorder { get; set; }
        /// <summary>是否启用种子 </summary>
        public  static  bool IsResEnc { get; set; }
        /// <summary>种子模式</summary>
        public static SeedType DisEncType { get; set; }
        /// <summary>CS文件模板位置 </summary>
        public  static string CsTemplate { get; set; }
        /// <summary>变量类型转换文件 </summary>
        public  static  string TypeBankFile { get; set; }
        /// <summary>格式转换类型
        ///  第1列为数据库类型
        /// 第2列为C#类型
        /// 第3列为Java类型
        /// 第4列为As类型 
        /// </summary>
        public  static string[,] TypeChange { get; set; }
#region 消息相关
        /// <summary>CS消息配置表 </summary>
        public static  string CsMessageFilePath { get; set; }
        /// <summary>c#bean模板 </summary>
        public static  string CsBeanTemplatePath { get; set; }
        /// <summary>C#消息模板 </summary>
        public  static string CsMessageTemplatePath { get; set; }
        /// <summary>C#MessageType模板 </summary>
        public static  string CsMessageTypeTemplatePath { get; set; }
        /// <summary>C#方法映射文件 </summary>
        public  static  string CsFunMapFilePath { get; set; }
        /// <summary>消息类 </summary>
        public static CMessages CsMessages { get; set; }
        /// <summary>CS消息配置表 </summary>
        public static string AsMessageFilePath { get; set; }
        /// <summary>ASbean模板 </summary>
        public static string AsBeanTemplatePath { get; set; }
        /// <summary>AS消息模板 </summary>
        public static string AsMessageTemplatePath { get; set; }
        /// <summary>ASHandle模板 </summary>
        public static string AsHandleTemplatePath { get; set; }
        /// <summary>AS方法映射文件 </summary>
        public static string AsFunMapFilePath { get; set; }
        
#endregion
        /// <summary>
        /// 获取Excel表中的sheet名
        /// 末尾不带$符号表示不是一个正确的sheet表
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string [] GetExcelSheetName(string path)
        {
            
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                string strConn = "";
                if (path.Contains(".xlsx"))
                {
                    strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                }
                else
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";
                }
                objConn = new OleDbConnection(strConn);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null)
                {
                    return null;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                return excelSheets;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        /// <summary>
        /// 读取Excel表内容
        /// </summary>
        /// <param name="excelName">Excel表名</param>
        /// <param name="sheetName">sheet表名（末尾要带$）</param>
        /// <returns>sheet表中的数据(二维字符串数组)</returns>
        public static string[,] GetSheetFromExcel(string excelName, string sheetName)
        {
            CheckExcelRegedit();
            try
            {
                string strConn = "";
                if (excelName.Contains(".xlsx"))
                {
                    strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + excelName +
                              ";Extended Properties='Excel 12.0; HDR=No; IMEX=1'";
                }
                else
                {
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelName + ";" +
                              "Extended Properties='Excel 8.0;HDR=No;IMEX=1'";
                }
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataTable dt = null;
                strExcel = "select * from [" + sheetName + "]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                dt = new DataTable();
                myCommand.Fill(dt);
                int Row = dt.Rows.Count; //行
                int Columns = dt.Columns.Count; //列
                string[,] str = new string[Row, Columns];
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        str[i, j] = dt.Rows[i][j].ToString();
                    }
                }
                return str;
            }
            catch (Exception e)
            {
                Debug.Log("excel表:" +excelName+"   "+sheetName+"读取失败:"+e.Message,3);
                return null;
            }
        }

        public static bool GetXmlInnerTextTrueOrFalse(XmlElement element,string nodeName)
        {
            bool boolValue = false;
            XmlElement ele = ConfigControl.GetXmlElement(element, nodeName);
            if (ele!=null)
            {
                if (ele.InnerText.Trim()=="true")
                {
                    boolValue = true;
                }
            }
            return boolValue;
        }

        public static void InitTypeBankFile()
        {
            if (string.IsNullOrEmpty(TypeBankFile))
            {
                MessageBox.Show("请设置格式转换文件", "转换文件不存在", MessageBoxButtons.OK);
                return;
            }
            else
            {
                TypeChange = GetSheetFromExcel(TypeBankFile, "TypeChange$");
            }
        }

        public static void InitMessageSetting()
        {
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\MessageConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "MessageConfig");
            ///C#配置读取
            XmlElement csElement = ConfigControl.GetXmlElement(rootElement, "CS");
            XmlElement csMessageFileElement = ConfigControl.GetXmlElement(csElement, "CsMessageFile");
            if (csMessageFileElement!=null)
            {
                CsMessageFilePath = csMessageFileElement.InnerText.Trim();
            }
            XmlElement csBeanTemplateElement = ConfigControl.GetXmlElement(csElement, "CsBeanTemplate");
            if (csBeanTemplateElement!=null)
            {
                CsBeanTemplatePath = csBeanTemplateElement.InnerText.Trim();
            }
            XmlElement csMessageTemplateElement = ConfigControl.GetXmlElement(csElement, "CsMessageTemplate");
            if (csMessageTemplateElement!=null)
            {
                CsMessageTemplatePath = csMessageTemplateElement.InnerText.Trim();
            }
            CsMessageTypeTemplatePath = ConfigControl.GetXmlElementInnerText(csElement, "CsMessageTypeTemplate");

            XmlElement csFunMapElement = ConfigControl.GetXmlElement(csElement, "CsFunMap");
            if (csFunMapElement!=null)
            {
                CsFunMapFilePath = csFunMapElement.InnerText.Trim();
            }
            ///AS配置读取
            XmlElement asElement = ConfigControl.GetXmlElement(rootElement, "AS");
            AsMessageFilePath = ConfigControl.GetXmlElementInnerText(asElement, "AsMessageFile");
            AsBeanTemplatePath = ConfigControl.GetXmlElementInnerText(asElement, "AsBeanTemplate");
            AsMessageTemplatePath = ConfigControl.GetXmlElementInnerText(asElement, "AsMessageTemplate");
            AsHandleTemplatePath = ConfigControl.GetXmlElementInnerText(asElement, "AsHandleTemplate");
            AsFunMapFilePath = ConfigControl.GetXmlElementInnerText(asElement, "AsFunMap");
        }

        public static void SaveMessageSetting()
        {
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\MessageConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "MessageConfig");
            XmlElement csElement = ConfigControl.GetXmlElement(rootElement, "CS");
            ConfigControl.SetXmlelementInnerText(csElement, "CsMessageFile", CsMessageFilePath, doc);
            ConfigControl.SetXmlelementInnerText(csElement, "CsBeanTemplate", CsBeanTemplatePath, doc);
            ConfigControl.SetXmlelementInnerText(csElement, "CsMessageTemplate", CsMessageTemplatePath, doc);
            ConfigControl.SetXmlelementInnerText(csElement, "CsMessageTypeTemplate",CsMessageTypeTemplatePath, doc);
            ConfigControl.SetXmlelementInnerText(csElement, "CsFunMap", CsFunMapFilePath, doc);
            doc.Save(@".\Config\MessageConfig.xml");
        }

        public static string FirstCharToUpper(string lowerString)
        {
            if (!string.IsNullOrEmpty(lowerString))
            {
                char[] t = lowerString.ToCharArray();
                if ((t[0] > 'a' || t[0] == 'a') && (t[0] < 'z' || t[0] == 'z'))
                {
                    t[0] = (char) (t[0] - 32);
                }
                return new string(t);
            }
            else
                return "";
        }
        public static string FirstCharToLower(string UpperString)
        {
            if (!string.IsNullOrEmpty(UpperString))
            {
                char[] t = UpperString.ToCharArray();
                if ((t[0] > 'A' || t[0] == 'A') && (t[0] < 'Z' || t[0] == 'Z'))
                {
                    t[0] = (char) (t[0] + 32);
                }
                return new string(t);
            }
            else
                return "";
        }

        public static bool IsCustomType(string customType)
        {
            switch (customType)
            {
                case "int":
                    return false;
                case "short":
                    return false;
                case "float":
                    return false;
                case "long":
                    return false;
                case "byte":
                    return false;
                case "String":
                    return false;
                case "string":
                    return false;
            }
            return true;
        }

        public static string GetFilePostFix(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }
            int index = fileName.LastIndexOf(".");
            if (index==-1)
            {
                return null;
            }
            if (fileName.Length==index+1)//".在最后"
            {
                return null;
            }
            return fileName.Substring(index + 1);
        }

        public static void CheckExcelRegedit()
        {
            //修改注册表
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Office\\12.0\\Access Connectivity Engine\\Engines\\Excel", true);
            if (rk != null)
            {
                string val = rk.GetValue("TypeGuessRows").ToString();
                if (val == "8")
                {
                    rk.SetValue("TypeGuessRows", "0");
                }
                rk.Close();
            }
        }
    }
    public enum SeedType
    {
        Version=1,
        CRC32=2,
        MD5=4,
        SHA1=8
    }
}
