using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NVelocity;

namespace GameTools
{
    public class CCSHandleFuns:CSingleton<CCSHandleFuns>
    {
        #region CS表格资源
        /// <summary>
        /// 生成CS表格资源
        /// </summary>
        /// <param name="checkedListBox1"></param>
        /// <param name="excelDatas"></param>
        /// <param name="label1"></param>
        public void CreateCsResBean(ExcelData sheet, CAsDataConfig dataConfig, bool isSet = true)
        {
            string[,] data = Global.GetSheetFromExcel(sheet.ExcelName, sheet.SheetName);
            string name = Global.FirstCharToUpper(sheet.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = dataConfig.folder + @"\" + name + ".cs";
            string templatePath = @".\Templates\CS\temp_cs_res_bean.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("DateTime");
            replace.Add(DateTime.Now.ToString("yyyy-M-d HH:mm:ss"));
            needReplace.Add("PackageString");
            replace.Add(dataConfig.package);
            needReplace.Add("BeanName");
            replace.Add(name);
            List<string> import = new List<string>();
            if (dataConfig.beanImport != null && dataConfig.beanImport.Length > 0)
            {
                needReplace.Add("importList");
                foreach (var bean in dataConfig.beanImport)
                {
                    import.Add(bean);
                }
                replace.Add(import);
            }
            needReplace.Add("fieldList");
            List<BeanVar> fieldList = new List<BeanVar>();
            for (int i = 0; i < data.GetLength(1); i++)
            {
                if (!string.IsNullOrWhiteSpace(data[1, i]) && !data[0, i].Contains("备注") && !data[1, i].Contains("备注") && !data[2, i].Contains("备注") && !data[3, i].Contains("备注") && !data[4, i].Contains("备注"))
                {
                    BeanVar field = new BeanVar();
                    field.name = data[1, i];
                    field.className = data[2, i];
                    field.explain = data[4, i].Replace("\n", "").Replace("\r", "");
                    fieldList.Add(field);
                }
            }
            replace.Add(fieldList);
            if (isSet)
            {
                needReplace.Add("getFieldList");
                replace.Add(fieldList);
            }
            if (File.Exists(templatePath))
            {
                CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
                Debug.Log(name + ".cs文件生成完毕");
            }
            else
            {
                Debug.Log("模板文件不存在请检查."+templatePath);
            }
        }

        public void CreateCsContainer(ExcelData sheet, CAsDataConfig dataConfig)
        {
            string name = Global.FirstCharToUpper(sheet.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = dataConfig.folder +@"\"+ name + "Container.cs";
            string templatePath = @".\Templates\CS\temp_cs_res_container.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("DateTime");
            replace.Add(DateTime.Now.ToString("yyyy-M-d HH:mm:ss"));
            if (dataConfig.package!=null)
            {
                needReplace.Add("PackageString");
                replace.Add(dataConfig.package);
                needReplace.Add("BeanPackage");
                replace.Add(dataConfig.package);
            }
            needReplace.Add("Name");
            replace.Add(name);
            needReplace.Add("ContainerName");
            replace.Add(name + "Container");
            List<string> import = new List<string>();
            if (dataConfig.containerImport!=null && dataConfig.containerImport.Length > 0)
            {
                needReplace.Add("importList");
                foreach (var bean in dataConfig.containerImport)
                {
                    import.Add(bean);
                }
                replace.Add(import);
            }
            string[,] sheetdata = Global.GetSheetFromExcel(sheet.ExcelName, sheet.SheetName);
            if (sheetdata!=null && sheetdata.GetLength(1)>0)
            {
                string Id = "";
                Dictionary<int ,string> KeyDict=new Dictionary<int, string>();
                for (int i = 0; i < sheetdata.GetLength(1); i++)
                {
                    if (sheetdata[0,i]!="" && sheetdata[0,i]!=" ")
                    {
                        int index = int.Parse(sheetdata[0, i]);
                        KeyDict.Add(index, sheetdata[1, i]);
                    }
                    
                }
                if (KeyDict.Count>0)
                {
                    Id += string.Format("bean.{0}.ToString()", KeyDict[1]);;
                    for (int i = 0; i < KeyDict.Count-1; i++)
                    {
                        Id += string.Format("+\"_\"+bean.{0}.ToString()", KeyDict[2+i]);
                    }
                }
                
                needReplace.Add("ID");
                if (Id=="")
                {
                    replace.Add("IAMNULL");
                }
                else
                {
                    replace.Add(Id);
                }
            }
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log(name + "Container.cs文件生成完毕");
        }
        #endregion
        #region CS消息处理
        /// <summary>
        /// 生成CS消息相关文件
        /// </summary>
        public static void CreateCSMessage(bool isBean,bool ismessage,bool isHandler,bool isCservice,bool isMessagePool,string outpath)
        {
            if (Global.CsMessages == null)
            {
                MessageBox.Show("请先选择消息配置表", "配置表为空", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(Global.CsBeanTemplatePath) || string.IsNullOrEmpty(Global.CsMessageTemplatePath) ||
                string.IsNullOrEmpty(Global.CsFunMapFilePath) ||string.IsNullOrEmpty(Global.CsMessageTypeTemplatePath))
            {
                MessageBox.Show("请先设置CS消息配置", "CS消息配置不正确", MessageBoxButtons.OK);
                return;
            }
            CMessages msg = Global.CsMessages;
            string conflictSheetPath = @".\Templates\CS\ClassNameConflict.xlsx";
            string[,] conflictStrings = Global.GetSheetFromExcel(conflictSheetPath, "Conflict$");
            if (conflictStrings.GetLength(0)>1)
            {
                if (msg.beans!=null&&msg.beans.Length > 0)//bean
                {
                    for (int k=0;k< msg.beans.Length;k++)
                    {
                        //if (msg.beans[k].fileds!=null &&msg.beans[k].fileds.Length > 0)
                        //{
                        //    for (int j = 0; j < msg.beans[k].fileds.Length; j++)
                        //    {
                        //        for (int i = 0; i < conflictStrings.GetLength(0); i++)
                        //        {
                        //            if (msg.beans[k].fileds[j].fieldType.Contains(conflictStrings[i,0]))
                        //            {
                        //                msg.beans[k].fileds[j].fieldType=msg.beans[k].fileds[j].fieldType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                        //            }
                        //        }
                        //    }
                        //}
                        //if (msg.beans[k].lists!=null &&msg.beans[k].lists.Length > 0)
                        //{
                        //    for (int j = 0; j < msg.beans[k].lists.Length; j++)
                        //    {
                        //        for (int i = 0; i < conflictStrings.GetLength(0); i++)
                        //        {
                        //            if (msg.beans[k].lists[j].listType.Contains(conflictStrings[i, 0]))
                        //            {
                        //                msg.beans[k].lists[j].listType=msg.beans[k].lists[j].listType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                        //            }
                        //        }
                        //    }
                        //}
                        if (msg.beans[k].items!=null &&msg.beans[k].items.Count > 0)
                        {
                            for (int i = 0; i < conflictStrings.GetLength(0); i++)
                            {
                                if (msg.beans[k].name == conflictStrings[i, 0])
                                {
                                    msg.beans[k].name = conflictStrings[i, 1];
                                }
                            }
                            for (int j = 0; j < msg.beans[k].items.Count; j++)
                            {
                                for (int i = 0; i < conflictStrings.GetLength(0); i++)
                                {
                                    if (msg.beans[k].items[j].realClassType==conflictStrings[i, 0])
                                    {
                                        msg.beans[k].items[j].classType=msg.beans[k].items[j].classType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                                        msg.beans[k].items[j].realClassType = conflictStrings[i, 1];
                                    }
                                }
                            }
                        }
                    }
                }
                if (msg.messages!=null&&msg.messages.Length > 0)//message
                {
                    for(int k=0;k< msg.messages.Length;k++)
                    {
                    //    if (msg.messages[k].fields!=null &&msg.messages[k].fields.Length > 0)
                    //    {
                    //        for (int j = 0; j < msg.messages[k].fields.Length; j++)
                    //        {
                    //            for (int i = 0; i < conflictStrings.GetLength(0); i++)
                    //            {
                    //                if (msg.messages[k].fields[j].fieldType.Contains(conflictStrings[i, 0]))
                    //                {
                    //                    msg.messages[k].fields[j].fieldType=msg.messages[k].fields[j].fieldType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                    //                }
                    //            }
                    //        }
                    //    }
                    //    if (msg.messages[k].lists!=null&&msg.messages[k].lists.Length > 0)
                    //    {
                    //        for (int j = 0; j < msg.messages[k].lists.Length; j++)
                    //        {
                    //            for (int i = 0; i < conflictStrings.GetLength(0); i++)
                    //            {
                    //                if (msg.messages[k].lists[j].listType.Contains(conflictStrings[i, 0]))
                    //                {
                    //                    msg.messages[k].lists[j].listType=msg.messages[k].lists[j].listType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                    //                }
                    //            }
                    //        }
                    //    }
                        if (msg.messages[k].items!=null &&msg.messages[k].items.Count > 0)
                        {
                            for (int j = 0; j < msg.messages[k].items.Count; j++)
                            {
                                for (int i = 0; i < conflictStrings.GetLength(0); i++)
                                {
                                    if (msg.messages[k].items[j].realClassType==conflictStrings[i, 0])
                                    {
                                        msg.messages[k].items[j].classType=msg.messages[k].items[j].classType.Replace(conflictStrings[i, 0], conflictStrings[i, 1]);
                                        msg.messages[k].items[j].realClassType = conflictStrings[i, 1];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            
            FileInfo info = new FileInfo(Global.CsMessageFilePath);
            string fileName = info.Name;
            string name = msg.name;
            if (isBean&&msg.beans!=null && msg.beans.Length > 0)
            {
                //if (string.IsNullOrEmpty(Global.CsBeanTemplatePath) || !File.Exists(Global.CsBeanTemplatePath))
                //{
                //    MessageBox.Show("请设置Bean模板文件", "Bean模板文件为空", MessageBoxButtons.OK);
                //    return;
                //}

                string path = outpath+@"\" + name + @"\bean";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateBeans(msg, path);
            }
            if (ismessage&&msg.messages.Length > 0)
            {
                //if (string.IsNullOrEmpty(Global.CsMessageTemplatePath) || !File.Exists(Global.CsMessageTemplatePath))
                //{
                //    MessageBox.Show("请设置Message模板文件", "Message模板文件为空", MessageBoxButtons.OK);
                //    return;
                //}
                string path = outpath + @"\" + name + @"\message";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateMessage(msg, path);
            }
            if (isHandler && msg.messages.Length>0)
            {
                string path = outpath + @"\" + name + @"\handler";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateHandler(msg, path);
            }
            if (isCservice && msg.messages.Length > 0)
            {
                string path = outpath + @"\" + name;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateServices(msg, path);
            }
            if (isMessagePool && msg.messages.Length > 0)
            {
                CreateMessageTypeEnum(outpath, msg);
            }
        }
        /// <summary>
        /// 生成CS下的Bean文件
        /// </summary>
        /// <param name="csMessages"></param>
        /// <param name="funMap"></param>
        /// <param name="label1"></param>
        private static void CreateBeans(CMessages msg, string path)
        {
            //Thread myThread=new Thread(new ThreadStart(CreateBeanThread(msg,path,LogText)));
            foreach (var bean in msg.beans)
            {
                if (bean.name!="")
                {
                    Template temp = CNVelociryHelp.GetTemplate(@".\Templates\CS\" + Global.CsBeanTemplatePath.Substring(Global.CsBeanTemplatePath.LastIndexOf(@"\")));
                    VelocityContext vltCtx = new VelocityContext();
                    vltCtx.Put("ImportString", msg.import);
                    vltCtx.Put("BeanExplain", bean.explain);
                    vltCtx.Put("BeanName", bean.name);
                    //if (bean.fileds != null && bean.fileds.Length > 0)
                    //{
                    //    List<BeanVar> beanVarList = new List<BeanVar>();
                    //    //List<CField> beanWriteList = new List<CField>();
                    //    foreach (var field in bean.fileds)
                    //    {
                    //        BeanVar var = new BeanVar(field);
                    //        beanVarList.Add(var);
                    //    }
                    //    vltCtx.Put("fieldList", beanVarList);
                    //}
                    //if (bean.lists != null && bean.lists.Length > 0)
                    //{
                    //    List<BeanVar> beanVarList = new List<BeanVar>();
                    //    foreach (var list in bean.lists)
                    //    {
                    //        BeanVar var = new BeanVar(list);
                    //        beanVarList.Add(var);
                    //    }
                    //    vltCtx.Put("listList", beanVarList);
                    //}
                    List<string> usList = new List<string>();
                    if (bean.lists != null && bean.lists.Length > 0)
                    {
                        usList.Add("using System.Collections.Generic;");
                    }
                    vltCtx.Put("usList", usList);
                    if (bean.items != null && bean.items.Count > 0)
                    {
                        List<CMessageFieldAndList> list = new List<CMessageFieldAndList>();
                        foreach (var item in bean.items)
                        {
                            if (item != null)
                            {
                                CMessageFieldAndList fl = new CMessageFieldAndList(item);
                                list.Add(fl);
                            }

                        }
                        vltCtx.Put("flList", list);
                    }
                    System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                    temp.Merge(vltCtx, vltWriter);

                    FileStream fs = new FileStream(path + @"\" + bean.name + ".cs",
                       FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(vltWriter.ToString());
                    sw.Close();
                    fs.Close();
                    Debug.Log(bean.name + ".cs生成成功");
                }
                else
                {
                    Debug.Log("Bean名称为空，不能生成文件",3);
                }
            }
        }
        /// <summary>
        /// 生成CS下的Message.cs文件
        /// </summary>
        /// <param name="csMessages"></param>
        /// <param name="funMap"></param>
        private static void CreateMessage(CMessages msg, string path)
        {
            foreach (var message in msg.messages)
            {
                if (message.name != "")
                {
                    FileStream fs = new FileStream(path + @"\" + message.name + "Message.cs",
                        FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    string tempPath = @".\Templates\CS\" +
                                      Global.CsMessageTemplatePath.Substring(
                                          Global.CsMessageTemplatePath.LastIndexOf(@"\") + 1);
                    Template temp = CNVelociryHelp.GetTemplate(tempPath);
                    VelocityContext vltCtx = new VelocityContext();
                    string importString = "";
                    vltCtx.Put("MessageExplain", message.explain);
                    vltCtx.Put("MessageName", message.name + "Message");
                    vltCtx.Put("MessageID", msg.ID + message.ID);
                    if (message.lists!=null && message.lists.Length>0)
                    {
                        vltCtx.Put("Length", "int length=0;");
                    }
                    else
                    {
                        vltCtx.Put("Length", "");
                    }
                    List<string> usList=new List<string>();
                    if (message.lists!=null && message.lists.Length>0)
                    {
                        usList.Add("using System.Collections.Generic;");
                    }
                    
                    if (message.items != null && message.items.Count > 0)
                    {
                        List<CMessageFieldAndList> list = new List<CMessageFieldAndList>();
                        foreach (var item in message.items)
                        {
                            if (item != null)
                            {
                                CMessageFieldAndList fl = new CMessageFieldAndList(item);
                                
                                if (Global.IsCustomType(fl.className) && fl.isPrefix=="0" && importString=="")
                                {
                                    importString = msg.import;
                                }
                                list.Add(fl);
                                if (item.classType=="Position")
                                {
                                    usList.Add("using com.game.structs;");
                                }
                            }

                        }
                        vltCtx.Put("flList", list);
                    }
                    vltCtx.Put("usList", usList);
                    vltCtx.Put("ImportString", importString);
                    System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                    temp.Merge(vltCtx, vltWriter);

                    sw.Write(vltWriter.ToString());
                    sw.Close();
                    fs.Close();
                    Debug.Log(message.name + "Message.cs生成成功");
                }
                else
                {
                    Debug.Log("Message文件名称为空",3);
                }
            }
        }
        private static void CreateHandler(CMessages msg, string path)
        {
            foreach (var message in msg.messages)
            {
                if (message.name != "") 
                {
                    if (!message.name.Contains("Req") && message.msType.Substring(0, 1) != "C" &&
                        message.msType.Substring(1) != "S" && !message.msType.Contains("W"))
                    {
                        if (File.Exists(path + @"\" + message.name + "Handler.cs"))
                        {
                            Debug.Log(message.name + "Handler.cs已经存在!不会生成",2);
                        }
                        else
                        {
                            FileStream fs = new FileStream(path + @"\" + message.name + "Handler.cs",FileMode.Create, FileAccess.Write);
                            StreamWriter sw = new StreamWriter(fs);
                            string tempPath = @".\Templates\CS\temp_cs_handler.vm";
                            Template temp = CNVelociryHelp.GetTemplate(tempPath);
                            VelocityContext vltCtx = new VelocityContext();
                            vltCtx.Put("HandlerName", message.name + "Handler");
                            vltCtx.Put("ResMessageName", message.name + "Message");
                            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                            temp.Merge(vltCtx, vltWriter);
                            sw.Write(vltWriter.ToString());
                            sw.Close();
                            fs.Close();
                            Debug.Log(message.name + "Handler.cs生成成功");
                        }
                        
                    }
                }
                else
                {
                    Debug.Log("Message文件名称为空",3);
                }
            }
        }
        private static void CreateServices(CMessages msg, string path)
        {
            string name = Global.FirstCharToUpper(msg.name);
            FileStream fs = new FileStream(path + @"\" + "CService" + name + ".cs",
                            FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string tempPath = @".\Templates\CS\temp_cs_cservice.vm";
            Template temp = CNVelociryHelp.GetTemplate(tempPath);
            VelocityContext vltCtx = new VelocityContext();
            vltCtx.Put("CServiceName", "CService" + name);
            StringBuilder sb=new StringBuilder();

            string listusing = "";
            string importBean = "";
            foreach (var message in msg.messages)
            {
                if (message.name != "")
                {
                    if (message.name.Contains("Req") || message.msType.Substring(0, 1) == "C"||
                        message.msType.Substring(1) == "S" || message.msType.Contains("W"))//生成Send函数
                    {
                        sb.Append("        /// <summary>\n        /// " + message.explain + "\n        /// </summary>\n");
                        if (message.items != null && message.items.Count > 0)
                        {
                            for (int i = 0; i < message.items.Count; i++)
                            {
                                if (message.items[i]!=null)
                                {
                                    sb.Append("        /// <param name=\"" + message.items[i].name + "\">" + message.items[i].explain + "</param>\n");
                                }
                                
                            }
                        }
                        sb.Append("        public static void Send" + message.name.Replace("Req", "") + "(");
                        if (message.items!=null &&message.items.Count > 0)
                        {
                            for (int i = 0; i < message.items.Count - 1; i++)
                            {
                                if (message.items[i]!=null)
                                {
                                    if (!message.items[i].isList)
                                    {
                                        if (message.items[i].classType=="String")
                                        {
                                            sb.Append( "string " + message.items[i].name + ",");
                                        }
                                        else
                                        {
                                            sb.Append(message.items[i].classType + " " + message.items[i].name + ",");
                                        }
                                    }
                                    else
                                    {
                                        if (message.items[i].classType == "String")
                                        {
                                            sb.Append("List<string>" + " " +
                                                      message.items[i].name +
                                                      ",");
                                        }
                                        else
                                        {
                                            sb.Append("List<" + message.items[i].classType + ">" + " " +
                                                      message.items[i].name +
                                                      ",");
                                        }
                                        if (listusing == "")
                                        {
                                            listusing = "using System.Collections.Generic;";
                                        }
                                    }
                                    if (Global.IsCustomType(message.items[i].classType) && !message.items[i].isHavePrefix && importBean=="")
                                    {
                                        importBean = "using "+msg.import+".bean;";
                                    }
                                }
                                
                            }
                            if (message.items[message.items.Count - 1] != null)
                            {
                                if (!message.items[message.items.Count - 1].isList)
                                {
                                    if (message.items[message.items.Count - 1].classType == "String")
                                    {
                                        sb.Append("string " +
                                                  message.items[message.items.Count - 1].name);
                                    }
                                    else
                                    {
                                        sb.Append(message.items[message.items.Count - 1].classType + " " +
                                                  message.items[message.items.Count - 1].name);
                                    }
                                }
                                else
                                {
                                    if (message.items[message.items.Count - 1].classType == "String")
                                    {
                                        sb.Append("List<string>" + " " +
                                                  message.items[message.items.Count - 1].name);
                                    }
                                    else
                                    {
                                        sb.Append("List<" + message.items[message.items.Count - 1].classType + ">" + " " +
                                                  message.items[message.items.Count - 1].name);
                                    }
                                    if (listusing == "")
                                    {
                                        listusing = "using System.Collections.Generic;";
                                    }
                                }
                                if (Global.IsCustomType(message.items[message.items.Count - 1].classType) && importBean == "")
                                {
                                    importBean = "using " + msg.import + ".bean;";
                                }
                            }
                        }
                        sb.Append(")\n        {\n            ");
                        sb.Append(message.name + "Message message = new " + message.name + "Message();\n            ");
                        if (message.items != null && message.items.Count > 0)
                        {
                            for (int i = 0; i < message.items.Count ; i++)
                            {
                                  sb.Append("message." + message.items[i].name + "="+ message.items[i].name+ ";\n            ");
                            }
                        }
                        sb.Append("ClientNetwork.Instance.SendMessage (message);\n        }\n");
                    }
                }
            }
            vltCtx.Put("FunList", sb);
            List<string> usList = new List<string>();
            if (listusing!="")
            {
                usList.Add(listusing);
            }
            if (importBean!="")
            {
                usList.Add(importBean);
            }
            vltCtx.Put("usList", usList);
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            temp.Merge(vltCtx, vltWriter);

            sw.Write(vltWriter.ToString());
            sw.Close();
            fs.Close();
            Debug.Log(name + "Handler.cs生成成功");
        }
        /*private static void CreateMessageTypeEnum(string outPath,CMessages csMessages, TextBox label1)
        {
            if (csMessages.messages.Length>0)
            {
                FileStream fs = new FileStream(outPath + "/MessagePool.cs",
                        FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                List<string> lines=new List<string>();
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
                //string contents = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                FileStream fs1 = new FileStream(outPath + "/MessagePool.cs",
                        FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                //string[] lines = contents.Split('\n');
                List<string> newMessage=new List<string>();
                List<string> listeners =new List<string>();
                List<string> cases =new List<string>();
                foreach (var mess in csMessages.messages)
                {
                    if (mess.name.Contains("Res") || mess.msType.Substring(0, 1) == "C" &&
                        mess.msType.Substring(1) == "S")
                    {
                        bool flag = false;//该消息是否已经存在
                        string mId = csMessages.ID + mess.ID;
                        if (!string.IsNullOrWhiteSpace(mess.name))
                        {
                            string mName = "";
                            if (mess.name.Contains("Res") || mess.name.Contains("Req"))
                            {
                                mName = mess.name.Substring(3).Replace("Message", "");
                            }
                            else
                            {
                                mName = mess.name.Replace("Message", "");
                            }

                            for (int i = 0; i < lines.Count; i++)
                            {
                                if (lines[i].Contains(mName) && lines[i].Contains(mId))//该消息已存在
                                {
                                    if (lines[i - 1].Contains("</summary>"))
                                    {
                                        if (lines[i-2].Contains("<summary>"))
                                        {
                                            lines[i - 2] = "        ///" + mess.explain;
                                        }
                                        else
                                        {
                                            lines[i - 1] = "        ///<summary>" + mess.explain + "</summary>";
                                        }
                                    }
                                    lines[i] = "        " + mName + " = " + mId + ",";
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            label1.Text += "消息号为" + csMessages.ID + mess.ID + "名称为空";
                        }
                        //该消息不存在
                        if (!flag)
                        {
                            if (!string.IsNullOrWhiteSpace(mess.name))
                            {
                                string mName = "";
                                if (mess.name.Contains("Res") || mess.name.Contains("Req"))
                                {
                                    mName = mess.name.Substring(3).Replace("Message", "");
                                }
                                else
                                {
                                    mName = mess.name.Replace("Message", "");
                                }
                                newMessage.Add("        ///<summary>" + mess.explain + "</summary>        " + mName + " = " + mId + ",");
                                listeners.Add("            ClientNetwork.Instance.AddListener(GameMessageType." + mName+", \"Res"+ mName+"Handler\");");
                                cases.Add("                case \"Res" + mName + "Handler\":                    return new Res" + mName + "Handler();");
                            }
                            else
                            {
                                newMessage.Add("        ///<summary>" + mess.explain + "</summary>	    " + mId + ",");
                            }
                        }
                    }
                    
                }
                List<string> allMessage =new List<string>();
                for(int i=0;i<lines.Count;i++)
                {
                    lines[i].Replace("\r", "");
                    if (i>0 && lines[i].Contains("="))
                    {
                        string str = "";
                        if (lines[i-1].Contains("<summary>") && lines[i-1].Contains("</summary>"))
                        {
                            str+=lines[i - 1];
                        }
                        str+=lines[i];
                        allMessage.Add(str);
                    }
                }
                if (newMessage.Count>0)
                {
                    foreach (var mess in newMessage)
                    {
                        allMessage.Add(mess);
                    }
                }
                List<string> allListener = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains("ClientNetwork.Instance.AddListener"))
                    {
                        allListener.Add(lines[i]);
                    }
                }
                if (listeners.Count>0)
                {
                    foreach (var listen in listeners)
                    {
                        allListener.Add(listen);
                    }
                }
                
                List<string> allCases = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains("case") || lines[i].Contains("return new"))
                    {
                        allCases.Add(lines[i]);
                    }
                }
                if (cases.Count>0)
                {
                    foreach (var cas in cases)
                    {
                        allCases.Add(cas);
                    }
                }
                CCmessageTypeTemplate.Instance.Init(fs1,sw);
                CCmessageTypeTemplate.Instance.Write(allMessage,allListener,allCases);
                CCmessageTypeTemplate.Instance.Close();
                label1.Text += "MessagePool.cs" + "生成成功" + "";
            }
            GC.Collect();
        }*/
        private static void CreateMessageTypeEnum(string outPath, CMessages csMessages)
        {
            if (csMessages.messages.Length > 0)
            {
                FileStream fs = new FileStream(outPath + "/MessagePool.cs",
                        FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string contents = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                string[] licont = contents.Split('\r','\n');
                List<string>lines=new List<string>();
                List<string> newMessage = new List<string>();
                for (int i = 0; i < licont.Length; i++)
                {
                    lines.Add(licont[i]);
                }
                for (int i = 0;i<lines.Count;i++)
                {
                    if (lines[i]=="")
                    {
                        lines.RemoveAt(i);
                        i--;
                    }
                }
                List<string> listeners = new List<string>();
                List<string> cases = new List<string>();
                foreach (var mess in csMessages.messages)
                {
                    if (!mess.name.Contains("Req") && mess.msType.Substring(0, 1) != "C" &&
                        mess.msType.Substring(1) != "S" && !mess.msType.Contains("W"))
                    {
                        bool flag = false;//该消息是否已经存在
                        string mId = csMessages.ID + mess.ID;
                        if (!string.IsNullOrWhiteSpace(mess.name))
                        {
                            string mName = "";
                            if (mess.name.Contains("Res") || mess.name.Contains("Req"))
                            {
                                mName = mess.name.Substring(3).Replace("Message", "");
                            }
                            else
                            {
                                mName = mess.name.Replace("Message", "");
                            }

                            for (int i = 0; i < lines.Count; i++)
                            {
                                if (lines[i].Contains(mName) && lines[i].Contains(mId))//该消息已存在
                                {
                                    if (lines[i - 1].Contains("</summary>"))
                                    {
                                        if (lines[i - 2].Contains("<summary>"))
                                        {
                                            lines[i - 2] = "        ///" + mess.explain;
                                        }
                                        else
                                        {
                                            lines[i - 1] = "        ///<summary>" + mess.explain + "</summary>";
                                        }
                                    }
                                    lines[i] = "        " + mName + " = " + mId + ",";
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("消息号为" + csMessages.ID + mess.ID + "名称为空",3);
                        }
                        //该消息不存在
                        if (!flag)
                        {
                            string mName = "";
                            if (!string.IsNullOrWhiteSpace(mess.name))
                            {
                                if (mess.name.Contains("Res") || mess.name.Contains("Req"))
                                {
                                    mName = mess.name.Substring(3).Replace("Message", "");
                                }
                                else
                                {
                                    mName = mess.name.Replace("Message", "");
                                }
                                newMessage.Add("        ///<summary>" + mess.explain + "</summary>");
                                newMessage.Add("        " + mName + " = " + mId + ",");
                            }
                            else
                            {
                                newMessage.Add("        ///<summary>" + mess.explain + "</summary>");
                                newMessage.Add("        "+mId + ",");
                            }
                            listeners.Add("            ClientNetwork.Instance.AddListener(GameMessageType." + mName + ", \"" + mess.name + "Handler\");");
                            cases.Add("                case \"" + mess.name + "Handler\":");
                            cases.Add("                    return new " + mess.name + "Handler();");;
                        }
                    }

                }
                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i].Replace('\r', ' ');
                }
                List<string> allMessage = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    lines[i].Replace("\r", "");
                    if (lines[i].Contains("="))
                    {
                        //string str = "";
                        if (lines[i - 1].Contains("<summary>") && lines[i - 1].Contains("</summary>"))
                        {
                            //str += lines[i - 1];
                            allMessage.Add(lines[i-1]);
                        }
                        //str += lines[i];
                        allMessage.Add(lines[i]);
                    }
                }
                if (newMessage.Count > 0)
                {
                    foreach (var mess in newMessage)
                    {
                        allMessage.Add(mess);
                    }
                }
                List<string> allListener = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains("ClientNetwork.Instance.AddListener"))
                    {
                        allListener.Add(lines[i]);
                    }
                }
                if (listeners.Count > 0)
                {
                    foreach (var listen in listeners)
                    {
                        allListener.Add(listen);
                    }
                }

                List<string> allCases = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains("case") || lines[i].Contains("return new"))
                    {
                        allCases.Add(lines[i]);
                    }
                }
                if (cases.Count > 0)
                {
                    foreach (var cas in cases)
                    {
                        allCases.Add(cas);
                    }
                }
                Template temp = CNVelociryHelp.GetTemplate(@".\Templates\CS\" +
                                                               Global.CsMessageTypeTemplatePath.Substring(
                                                                   Global.CsMessageTypeTemplatePath.LastIndexOf(@"\")));
                VelocityContext vltCtx = new VelocityContext();
                vltCtx.Put("MessageType", allMessage);
                vltCtx.Put("Listeners", allListener);
                vltCtx.Put("CaseHanders", allCases);
                StringWriter vltWriter = new StringWriter();
                try
                {
                    temp.Merge(vltCtx, vltWriter);
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message ,3);
                }
                FileStream fs1 = new FileStream(outPath + "/MessagePool.cs",
                       FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                string str1 = vltWriter.ToString();
                sw.Write(vltWriter.ToString());
                sw.Close();
                fs1.Close();
                Debug.Log("MessagePool.cs" + "生成成功");
            }
        }
        #endregion
    }
}
