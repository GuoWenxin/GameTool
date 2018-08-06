using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NVelocity;

namespace GameTools
{
    /// <summary>
    /// AS处理类
    /// </summary>
    public class CAsHandleFuns:CSingleton<CAsHandleFuns>
    {
        public void CreateAsResBean(ExcelData sheet,CAsDataConfig dataConfig, bool isSet=true)
        {
            string[,] data = Global.GetSheetFromExcel(sheet.ExcelName, sheet.SheetName);
            string name = Global.FirstCharToUpper(sheet.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = dataConfig.folder + @"\com\game\data\bean\"+name+".as";
            string templatePath = @".\Templates\AS\temp_as_res_bean.vm";
            List<string>needReplace=new List<string>();
            ArrayList replace=new ArrayList();
            needReplace.Add("PackageString");
            needReplace.Add("importList");
            needReplace.Add("BeanName");
            needReplace.Add("fieldList");
            replace.Add(dataConfig.package);
            List<string> import=new List<string>();
            if (dataConfig.beanImport.Length>0)
            {
                foreach (var bean in dataConfig.beanImport)
                {
                    import.Add(bean);
                }
            }
            replace.Add(import);
            replace.Add(name);
            List<BeanVar> fieldList=new List<BeanVar>();
            for (int i = 0; i < data.GetLength(1); i++)
            {
                if (!string.IsNullOrWhiteSpace(data[1, i]))
                {
                    BeanVar field = new BeanVar();
                    field.name = data[1, i];
                    field.className = data[2, i];
                    field.explain = data[4, i];
                    fieldList.Add(field);
                }
            }
            replace.Add(fieldList);
            if (isSet)
            {
                needReplace.Add("getFieldList");
                replace.Add(fieldList);
            }
            CNVelociryHelp.CreateFileByTemplate(filePath,templatePath,needReplace,replace);
           Debug.Log(name + ".as文件生成完毕");
        }

        public void CreateAsContainer(ExcelData sheet, CAsDataConfig dataConfig)
        {
            string name = Global.FirstCharToUpper(sheet.SheetName.Replace("'", "").Replace("$", ""));
            string filePath = dataConfig.folder + @"\com\game\data\container\" + name + "Container.as";
            string templatePath = @".\Templates\AS\temp_as_res_container.vm";
            List<string> needReplace = new List<string>();
            ArrayList replace = new ArrayList();
            needReplace.Add("PackageString");
            needReplace.Add("importList");
            needReplace.Add("Name");
            needReplace.Add("ContainerName");
            replace.Add(dataConfig.package);
            List<string> import = new List<string>();
            if (dataConfig.containerImport.Length > 0)
            {
                foreach (var container in dataConfig.containerImport)
                {
                    import.Add(container);
                }
            }
            replace.Add(import);
            replace.Add(name);
            replace.Add(name + "Container");
            CNVelociryHelp.CreateFileByTemplate(filePath, templatePath, needReplace, replace);
            Debug.Log( name + "Container.as文件生成完毕");
        }

        #region AS消息生成相关
        public  void CreateAsMessage()
        {
            if (string.IsNullOrEmpty( Global.AsMessageFilePath) || !File.Exists(Global.AsMessageFilePath))
            {
                MessageBox.Show("请选择消息文件", "消息文件为空", MessageBoxButtons.OK);
                return;
            }
            CMessages msg = Global.CsMessages;
            if (!Directory.Exists(Global.ResFolder+@"\AS"))
            {
                Directory.CreateDirectory(Global.ResFolder + @"\AS");
            }
            FileInfo info = new FileInfo(Global.AsMessageFilePath);
            string fileName = info.Name;
            int index = fileName.IndexOf("_");
            string name = fileName.Substring(0, index);
            if (msg.beans.Length>0)
            {
                if (string.IsNullOrEmpty(Global.AsBeanTemplatePath) || !File.Exists(Global.AsBeanTemplatePath))
                {
                    MessageBox.Show("请设置Bean模板文件", "Bean模板文件为空", MessageBoxButtons.OK);
                    return;
                }
                
                string path = Global.ResFolder + @"\AS\NetWork\" + name+ @"\bean";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateAsBeans(msg,path);
            }
            if (msg.messages.Length>0)
            {
                if (string.IsNullOrEmpty(Global.AsMessageTemplatePath) || !File.Exists(Global.AsMessageTemplatePath))
                {
                    MessageBox.Show("请设置Message模板文件", "Message模板文件为空", MessageBoxButtons.OK);
                    return;
                }
                string path = Global.ResFolder + @"\AS\NetWork\" + name + @"\message";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                CreateAsMessages(msg,path);
                if (string.IsNullOrEmpty(Global.AsHandleTemplatePath) || !File.Exists(Global.AsHandleTemplatePath))
                {
                    MessageBox.Show("请设置Handle模板文件", "Handle模板文件为空", MessageBoxButtons.OK);
                    return;
                }
                string path1 = Global.ResFolder + @"\AS\NetWork\" + name + @"\handler";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                CreateAsHandler(msg,path1);
            }
            
        }

        private static void CreateAsBeans(CMessages msg,string path )
        {

            foreach (var bean in msg.beans)
            {
                FileStream fs = new FileStream(path+@"\" + bean.name + ".as",
                        FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Template temp = CNVelociryHelp.GetTemplate(@".\Templates\AS\" +Global.AsBeanTemplatePath.Substring(Global.AsBeanTemplatePath.LastIndexOf(@"\")));
                VelocityContext vltCtx = new VelocityContext();
                vltCtx.Put("PackageString", msg.import);
                vltCtx.Put("Explain", bean.explain);
                vltCtx.Put("BeanName", bean.name);
                if (bean.fileds!=null && bean.fileds.Length>0)
                {
                    List<BeanVar> beanVarList = new List<BeanVar>();
                    //List<CField> beanWriteList = new List<CField>();
                    foreach (var field in bean.fileds)
                    {
                        BeanVar var = new BeanVar(field);
                        beanVarList.Add(var);
                    }
                    vltCtx.Put("fildList", beanVarList);
                }
                if (bean.lists!=null && bean.lists.Length>0)
                {
                    List<BeanVar> beanVarList = new List<BeanVar>();
                    foreach (var list in bean.lists)
                    {
                        BeanVar var = new BeanVar(list);
                        beanVarList.Add(var);
                    }
                    vltCtx.Put("vectorList", beanVarList);
                }
                
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                temp.Merge(vltCtx, vltWriter);

                Console.WriteLine(vltWriter.ToString());

                sw.Write(vltWriter.ToString());
                sw.Close();
                fs.Close();
                Debug.Log(bean.name + ".as生成成功");
            }    
        }

        private static void CreateAsMessages(CMessages msg, string path)
        {
            foreach (var message in msg.messages)
            {
                FileStream fs = new FileStream(path + @"\" + message.name + "Message.as",
                        FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                Template temp = CNVelociryHelp.GetTemplate(@".\Templates\AS\" + Global.AsMessageTemplatePath.Substring(Global.AsMessageTemplatePath.LastIndexOf(@"\")));
                VelocityContext vltCtx = new VelocityContext();
                vltCtx.Put("PackageString", msg.import);
                vltCtx.Put("Explain", message.explain);
                vltCtx.Put("MessageName", message.name+"Message");
                vltCtx.Put("MessageID", msg.ID + message.ID);
                if (message.fields!=null && message.fields.Length > 0)
                {
                    List<BeanVar> beanVarList = new List<BeanVar>();
                    //List<CField> beanWriteList = new List<CField>();
                    foreach (var field in message.fields)
                    {
                        BeanVar var = new BeanVar(field);
                        beanVarList.Add(var);
                    }
                    vltCtx.Put("fildList", beanVarList);
                }
                if (message.lists!=null && message.lists.Length > 0)
                {
                    List<BeanVar> beanVarList = new List<BeanVar>();
                    foreach (var list in message.lists)
                    {
                        BeanVar var = new BeanVar(list);
                        beanVarList.Add(var);
                    }
                    vltCtx.Put("vectorList", beanVarList);
                }

                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                temp.Merge(vltCtx, vltWriter);

                Console.WriteLine(vltWriter.ToString());

                sw.Write(vltWriter.ToString());
                sw.Close();
                fs.Close();
                Debug.Log(message.name + "Message.as生成成功");
            }
        }

        private static void CreateAsHandler(CMessages msg, string path)
        {
            foreach (var message in msg.messages)
            {
                if (message.name.Contains("Res"))
                {
                    FileStream fs = new FileStream(path + @"\" + message.name + "Handler.as",
                        FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    Template temp = CNVelociryHelp.GetTemplate(@".\Templates\AS\" + Global.AsHandleTemplatePath.Substring(Global.AsHandleTemplatePath.LastIndexOf(@"\")));
                    VelocityContext vltCtx = new VelocityContext();
                    vltCtx.Put("PackageString", msg.import);
                    vltCtx.Put("HandlerName", message.name+"Handler");
                    vltCtx.Put("MessageName", message.name + "Message");

                    System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                    temp.Merge(vltCtx, vltWriter);

                    Console.WriteLine(vltWriter.ToString());

                    sw.Write(vltWriter.ToString());
                    sw.Close();
                    fs.Close();
                    Debug.Log(message.name + "Handler.as生成成功");
                }
                
            }
        }
        #endregion
    }
}
