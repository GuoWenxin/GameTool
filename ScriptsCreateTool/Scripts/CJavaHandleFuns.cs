using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GameTools
{
    class CJavaHandleFuns:CSingleton<CJavaHandleFuns>
    {
        #region 生成JAVA资源相关
        public void CreateJavaResBean(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string[,] data = Global.GetSheetFromExcel(excelSheetData.ExcelName, excelSheetData.SheetName);
            string name = Global.FirstCharToUpper(excelSheetData.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = javaDataConfig.folder + @"\src\com\game\data\bean\" + name + "Bean.java";
            string templatePath = @".\Templates\Java\temp_java_res_bean.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("PackageString");
            needReplace.Add("BeanName");
            
            replace.Add(javaDataConfig.package);
            replace.Add(name);
            if (data.GetLength(1)>0)
            {
                needReplace.Add("fieldList");
                List<BeanVar>beanList=new List<BeanVar>();
                for (int i = 0; i < data.GetLength(1); i++)
                {
                    BeanVar beanVar=new BeanVar();
                    beanVar.name = data[1, i];
                    beanVar.className = data[2, i];
                    beanVar.explain = data[4, i];
                    beanList.Add(beanVar);
                }
                replace.Add(beanList);
            }
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log(name + "Bean.java文件生成完毕");
        }
        public void CreateJavaResDao(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string name = Global.FirstCharToUpper(excelSheetData.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = javaDataConfig.folder + @"\src\com\game\data\dao\" + name + "Dao.java";
            string templatePath = @".\Templates\Java\temp_java_res_dao.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("PackageString");
            needReplace.Add("Name");
            needReplace.Add("TimeNow");
            needReplace.Add("BaseDao");
            replace.Add(javaDataConfig.package);
            replace.Add(name);
            replace.Add(DateTime.Now.ToString("yy-MM-dd HH:mm:ss"));
            replace.Add(javaDataConfig.baseDao);
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log(name + "Dao.java文件生成完毕");
        }
        public void CreateJavaResContainer(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string[,] data = Global.GetSheetFromExcel(excelSheetData.ExcelName, excelSheetData.SheetName);
            string name = Global.FirstCharToUpper(excelSheetData.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = javaDataConfig.folder + @"\src\com\game\data\mapsql\" + name + "Container.java";
            string templatePath = @".\Templates\Java\temp_java_res_container.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("PackageString");
            needReplace.Add("Name");
            needReplace.Add("TimeNow");
            replace.Add(javaDataConfig.package);
            replace.Add(name);
            replace.Add(DateTime.Now.ToString("yy-MM-dd HH:mm:ss"));
            for (int i = 0; i < data.GetLength(1); i++)
            {
                if (!string.IsNullOrEmpty(data[0,i])&&data[0,i]=="1")
                {
                    needReplace.Add("ID");
                    replace.Add(Global.FirstCharToUpper(data[1,i]));
                    break;
                }
            }
            
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log(name + "Container.java文件生成完毕");
        }
        public void CreateJavaResMapSql(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string[,] data = Global.GetSheetFromExcel(excelSheetData.ExcelName, excelSheetData.SheetName);
            string name = excelSheetData.SheetName.Replace("'", "").Replace("$", "");
            string filePath = javaDataConfig.folder + @"\src\com\game\data\sqlmap\" + name + ".xml";
            string templatePath = @".\Templates\Java\temp_java_res_sqlmap.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("Name");
            replace.Add(name);
            if (data.GetLength(1)>0)
            {
                needReplace.Add("fieldList");
                List<BeanVar> beanVars=new List<BeanVar>();
                for(int i=0;i<data.GetLength(1);i++)
                {
                    BeanVar bean=new BeanVar();
                    bean.name = data[1, i];
                    bean.className = data[2, i];
                    beanVars.Add(bean);
                }
                replace.Add(beanVars);
            }

            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log(name + ".xml文件生成完毕");
        }
        public void CreateJavaResDataConfig(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string dataConfigPath = javaDataConfig.folder + @"\src\data-config.xml";
            if (File.Exists(dataConfigPath))
            {
                XmlDocument doc = ConfigControl.GetXmlDocument(dataConfigPath);
                XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "configuration");
                XmlElement mappersElement=rootElement.SelectSingleNode("mappers") as XmlElement;
                
                if (mappersElement.ChildNodes.Count>0)
                {
                    XmlNodeList list = mappersElement.ChildNodes;
                    MapperNode[] nodes = new MapperNode[list.Count/2];
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        nodes[i]=new MapperNode();
                        //nodes[i].nodeValue = list[i*2].Value;
                        XmlElement element = (XmlElement)list[i*2 + 1];
                        string fullNmae = element.GetAttribute("resource");
                        int beginIndex = fullNmae.LastIndexOf(@"/");
                        int endIndex = fullNmae.LastIndexOf(".");
                        nodes[i].name = fullNmae.Substring(beginIndex+1, endIndex - beginIndex -1).Trim();
                        string nodeValue = list[i*2].Value;
                        int startIndex = nodeValue.IndexOf(":");
                        nodes[i].time = nodeValue.Substring(startIndex + 1).Trim();

                    }
                    WriteToDataConfig(excelSheetData, dataConfigPath, javaDataConfig, nodes);
                }
                else
                {
                    WriteToDataConfig(excelSheetData, dataConfigPath, javaDataConfig, null);
                }
                Debug.Log(" data-config" + ".xml文件更新完毕");

            }
            else
            {
                WriteToDataConfig(excelSheetData,dataConfigPath,javaDataConfig,null);
                Debug.Log(" data-config" + ".xml文件生成完毕");
            }
        }

        private void WriteToDataConfig(ExcelData excelSheetData,string dataConfigPath,CJavaDataConfig javaDataConfig, MapperNode[] mapperNodes)
        {
            string name = excelSheetData.SheetName.Replace("'", "").Replace("$", "");
            string filePath = dataConfigPath;
            string templatePath = @".\Templates\Java\temp_java_res_dataconfig.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("SqlType");
            replace.Add(javaDataConfig.dbType);
            needReplace.Add("SqlIP");
            replace.Add(javaDataConfig.dbIp);
            needReplace.Add("SqlPort");
            replace.Add(javaDataConfig.dbport);
            needReplace.Add("DBName");
            replace.Add(javaDataConfig.dbName);
            needReplace.Add("UserName");
            replace.Add(javaDataConfig.dbUser);
            needReplace.Add("Psw");
            replace.Add(javaDataConfig.dbPsw);
            needReplace.Add("sheetList");
            List<MapperSheet> sheetList = new List<MapperSheet>();
            MapperSheet sheet = new MapperSheet(name, DateTime.Now.ToString("yyyy-M-d HH:mm:ss"));
            if (mapperNodes!=null)
            {
                foreach (var mn in mapperNodes)
                {
                    MapperSheet ms = new MapperSheet(mn.name, mn.time);
                    sheetList.Add(ms);
                }
                bool sampFlag = false;
                for (int i = 0; i < sheetList.Count; i++)
                {
                    if (sheet.sheetName==sheetList[i].sheetName)
                    {
                        sampFlag = true;
                        sheetList[i].nowTime = sheet.nowTime;
                        break;
                    }
                }
                if (!sampFlag)
                {
                    sheetList.Add(sheet);
                }
            }
            else
            {
                
                sheetList.Add(sheet);
            }
            
            replace.Add(sheetList);
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            
        }

        public void CreateJavaResDataManager(ExcelData excelSheetData, CJavaDataConfig javaDataConfig)
        {
            string datamMnagerPath = javaDataConfig.folder + @"\src\com\game\data\manager\DataManager.java";
            if (File.Exists(datamMnagerPath))
            {
                FileStream stream=new FileStream(datamMnagerPath,FileMode.Open,FileAccess.Read);
                StreamReader reader=new StreamReader(stream);
                string content = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                string[] contectArray = content.Split('\n');
                List<string> contentList=new List<string>();
                List<BeanVar> beaneList=new List<BeanVar>();
                foreach (var con in contectArray)
                {
                    if (con.Contains("import"))
                    {
                        string temp=con.Replace("\r","").Trim();
                        int beginIndex = temp.LastIndexOf(".");
                        int endIndex = temp.IndexOf("Container");
                        string subStr = temp.Substring(beginIndex + 1, endIndex - beginIndex - 1);
                        BeanVar bean=new BeanVar();
                        bean.UpperName = subStr;
                        bean.name = Global.FirstCharToLower(subStr);
                        beaneList.Add(bean);
                    }
                }
                if (beaneList.Count>0)
                {
                    WriteToDataManager(excelSheetData.SheetName, datamMnagerPath, javaDataConfig.package, beaneList);
                }
                else
                {
                    WriteToDataManager(excelSheetData.SheetName, datamMnagerPath, javaDataConfig.package, null);
                }
               Debug.Log( "DataManager.java文件更新完毕");

            }
            else
            {
                WriteToDataManager(excelSheetData.SheetName, datamMnagerPath, javaDataConfig.package, null);
                Debug.Log("DataManager.java文件生成完毕");
            }
        }

        private void WriteToDataManager(string sheetDataName,string dataManagerPath,string packageString,List<BeanVar>sheetNameList)
        {
            string name = sheetDataName.Replace("'", "").Replace("$", "");
            string filePath = dataManagerPath;
            string templatePath = @".\Templates\Java\temp_java_res_datamanager.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("PackageString");
            replace.Add(packageString);
            needReplace.Add("TimeNow");
            replace.Add(DateTime.Now.ToString("yyyy-M-d HH:mm:ss"));
            needReplace.Add("containerList");
            BeanVar beanVar=new BeanVar();
            beanVar.name = name;
            List<BeanVar> beanVarLiseList=new List<BeanVar>();
            if (sheetNameList!=null)
            {
                foreach (var sheetName in sheetNameList)
                {
                    beanVarLiseList.Add(sheetName);
                }
                bool sampFlag = false;
                for (int i = 0; i < sheetNameList.Count; i++)
                {
                    if (beanVar.UpperName == sheetNameList[i].UpperName)
                    {
                        sampFlag = true;
                        break;
                    }
                }
                if (!sampFlag)
                {
                    beanVarLiseList.Add(beanVar);
                }
            }
            else
            {
                beanVarLiseList.Add(beanVar);
            }
            replace.Add(beanVarLiseList);
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
        }
        class  MapperSheet
        {
            public string sheetName { get; set; }
            public string nowTime { get; set; }

            public MapperSheet(string name, string time)
            {
                sheetName = name;
                nowTime = time;
            }
        }
        class  MapperNode
        {
            public string name;
            //public string nodeValue;
            public string time;
        }
#endregion

        public void CreateJavaMessageSeries(string messageFilePath)
        {
            CMessages messages = ConfigControl.ReadMessageXml(messageFilePath);
            string messageCreatePath = Global.ResFolder + @"\Java\NetWork\" + messages.name;
            if (messages.beans!=null && messages.beans.Length>0)
            {
                CreateJavaMsBean(messages,messageCreatePath);
            }
            if (messages.messages!=null && messages.messages.Length>0)
            {
                CreateJavaMsMessage(messages, messageCreatePath);
                CreateJavaMsHandler(messages, messageCreatePath);
                UpdateMsgPool(messages, Global.ResFolder + @"\Java\NetWork\");
            }
            
        }

        private void CreateJavaMsBean(CMessages messages, string path)
        {
            foreach (var cBean in messages.beans)
            {
                string BeanName = cBean.name;
                string filePath = path + @"\bean\" + BeanName + ".java";
                string templatePath = @".\Templates\Java\temp_java_message_bean.vm";
                List<string> needReplace = new List<string>();
                ArrayList replace = new ArrayList();
                needReplace.Add("PackageString");
                replace.Add(messages.import);
                needReplace.Add("BeanSuper");
                replace.Add(messages.beanSuper);
                needReplace.Add("BeanName");
                replace.Add(BeanName);
                needReplace.Add("Explain");
                replace.Add(cBean.explain);
                if (cBean.fileds != null && cBean.fileds.Length > 0)
                {
                    needReplace.Add("fieldList");
                    List<BeanVar> beanList = new List<BeanVar>();
                    foreach (var cField in cBean.fileds)
                    {
                        BeanVar bean = new BeanVar();
                        bean.name = cField.name;
                        bean.className = cField.fieldType;
                        bean.explain = cField.explain;
                        beanList.Add(bean);
                    }
                    replace.Add(beanList);
                }
                if (cBean.lists != null && cBean.lists.Length > 0)
                {
                    needReplace.Add("beanList");
                    List<BeanVar> beanList = new List<BeanVar>();
                    foreach (var cList in cBean.lists)
                    {
                        BeanVar bean = new BeanVar();
                        bean.name = cList.name;
                        bean.className = cList.listType;
                        bean.explain = cList.explain;
                        beanList.Add(bean);
                    }
                    replace.Add(beanList);
                }
                CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
                Debug.Log(cBean.name + ".java文件生成完毕");
            }
        }

        private void CreateJavaMsMessage(CMessages messages, string path)
        {
            foreach (var cMes in messages.messages)
            {
                string msgMane = cMes.name+"Message";
                string filePath = path + @"\message\" + msgMane + ".java";
                string templatePath = @".\Templates\Java\temp_java_message_message.vm";
                List<string> needReplace = new List<string>();
                ArrayList replace = new ArrayList();
                needReplace.Add("PackageString");
                replace.Add(messages.import);
                needReplace.Add("BeanSuper");
                replace.Add(messages.beanSuper);
                needReplace.Add("MessageName");
                replace.Add(msgMane);
                needReplace.Add("Explain");
                replace.Add(cMes.explain);
                if (cMes.fields != null && cMes.fields.Length > 0)
                {
                    needReplace.Add("fieldList");
                    List<BeanVar> beanList = new List<BeanVar>();
                    foreach (var cField in cMes.fields)
                    {
                        BeanVar bean = new BeanVar();
                        bean.name = cField.name;
                        bean.className = cField.fieldType;
                        bean.explain = cField.explain;
                        beanList.Add(bean);
                    }
                    replace.Add(beanList);
                }
                if (cMes.lists != null && cMes.lists.Length > 0)
                {
                    needReplace.Add("beanList");
                    List<BeanVar> beanList = new List<BeanVar>();
                    foreach (var cList in cMes.lists)
                    {
                        BeanVar bean = new BeanVar();
                        bean.name = cList.name;
                        bean.className = cList.listType;
                        bean.explain = cList.explain;
                        beanList.Add(bean);
                    }
                    replace.Add(beanList);
                }
                CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
                Debug.Log(msgMane + ".java文件生成完毕");
            }
        }

        private void CreateJavaMsHandler(CMessages messages, string path)
        {
            foreach (var cMes in messages.messages)
            {
                string msgMane = cMes.name + "Handler";
                string filePath = path + @"\handler\" + msgMane + ".java";
                string templatePath = @".\Templates\Java\temp_java_message_handler.vm";
                List<string> needReplace = new List<string>();
                ArrayList replace = new ArrayList();
                needReplace.Add("PackageString");
                replace.Add(messages.import);
                needReplace.Add("Handler");
                replace.Add(messages.handler);
                needReplace.Add("MessageName");
                replace.Add(cMes.name);
                CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
                Debug.Log(msgMane + ".java文件生成完毕");
            }
        }

        private void UpdateMsgPool(CMessages messages, string path)
        {
            //foreach (var cMes in messages.messages)
            {
                string filePath = path + @"\MessagePool.java";
                if (File.Exists(filePath))
                {
                    FileStream stream=new FileStream(filePath,FileMode.Open,FileAccess.Read);
                    StreamReader reader=new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                    string[] cts = content.Split('\n');
                    List<string> names=new List<string>();
                    List<string> ids=new List<string>();
                    List<MessgaeField> mfList=new List<MessgaeField>();
                    foreach (var ct in cts)
                    {
                        if (ct.Contains("import") && ct.Contains("com"))
                        {
                            int beginIndex = ct.LastIndexOf(".");
                            int endIndex = ct.IndexOf("Buff");
                            names.Add(ct.Trim().Substring(beginIndex+1,endIndex-beginIndex-1));
                        }
                        if (ct.Contains("register(") && ct.Contains(");"))
                        {
                            ids.Add(ct.Trim().Substring(9,6));
                        }
                    }
                    if (names.Count>0 && ids.Count>0)
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            MessgaeField mf=new MessgaeField();
                            mf.name = names[i*2];
                            mf.id = ids[i];
                            mfList.Add(mf);
                        }
                    }
                    if (mfList.Count>0)
                    {
                        WriteToMsgPool(messages, filePath, mfList);
                        Debug.Log("MessagePool.java文件更新完毕");
                    }
                    else
                    {
                        WriteToMsgPool(messages, filePath, null);
                        Debug.Log("MessagePool.java文件更新完毕");
                    }
                }
                else
                {
                    WriteToMsgPool(messages,filePath,null);
                    Debug.Log("MessagePool.java文件更新完毕");
                }
            }
        }

        private void WriteToMsgPool(CMessages messages,string filePath,List<MessgaeField> fieldList)
        {
            string templatePath = @".\Templates\Java\temp_java_message_messagepool.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("MessageList");
            List<MessgaeField> mf = new List<MessgaeField>();
            if (fieldList!=null)
            {
                foreach (var messgaeField in fieldList)
                {
                    mf.Add(messgaeField);
                }
            }
            foreach (var cMessage in messages.messages)
            {
                MessgaeField mft = new MessgaeField();
                mft.name = cMessage.name;
                mft.id = messages.ID + cMessage.ID;
                if (fieldList!=null)
                {
                    bool flag = false;
                    foreach (var messgaeField in fieldList)
                    {
                        if (messgaeField.id == mft.id)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        mf.Add(mft);
                    }
                }
                else
                {
                    mf.Add(mft);
                }
            }
            replace.Add(mf);
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
        }
        class  MessgaeField
        {
            public string name { get; set; }
            public string id { get; set; }
        }
    }
    

}
