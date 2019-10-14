
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using GameTools.Forms;

namespace GameTools
{
    public class CVersionMd5 : CSingleton<CVersionMd5>
    {
        public string CreateMd5(string contents,bool isLower)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contents);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            if (isLower)
            {
                return sb.ToString().ToLower();
            }
            else
            {
                return sb.ToString().ToUpper();
            }
        }

        public bool CreateVersionByMd5(string resousPath,string outPath,string versionNum,string strPostFix,string sizeUnit,bool isLower=true, bool isFile=true)
        {
            IngorePostFixs.Clear();
            if (!string.IsNullOrEmpty(strPostFix))
            {
                string []strs = strPostFix.Split(';');
                IngorePostFixs = strs.ToList();
            }
            if (isFile)
            {
                try
                {
                    //FormLoading.Instance.Start();
                    string contents = File.ReadAllText(resousPath);
                    string md5 = CreateMd5(contents,isLower);
                    CVersion versionlist = new CVersion();
                    versionlist.version = versionNum;
                    resousPath = resousPath.Replace("\\", "/");
                    string name = resousPath.Substring(resousPath.LastIndexOf("/", StringComparison.Ordinal) + 1);
                    if (!IngorePostFixs.Contains(Global.GetFilePostFix(name)))
                    {

                        Version version = new Version();
                        version.name = name;
                        FileInfo fi = new FileInfo(resousPath);
                        long size = fi.Length.BinaryUnitConvert(sizeUnit);
                        if (size<=0)
                        {
                            size = 1;
                        }
                        version.size = size.ToString();
                        version.element = md5;
                        versionlist.element.Add(version);
                    }
                    //FormLoading.Instance.SetProgerss(80);;

                    string outFilePath = outPath + "/version.xml";
                    FileStream fs = new FileStream(outFilePath, FileMode.Create);
                    XmlSerializer xmlser = new XmlSerializer(typeof(CVersion));
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "    ";
                    settings.NewLineChars = "\r\n";
                    settings.Encoding = Encoding.UTF8;
                    using (XmlWriter xmlWriter = XmlWriter.Create(fs, settings))
                    {
                        // 强制指定命名空间，覆盖默认的命名空间  
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add(string.Empty, string.Empty);
                        xmlser.Serialize(xmlWriter, versionlist, namespaces);
                        xmlWriter.Close();
                    };
                    //xmlser.Serialize(fs, versionlist);
                    fs.Close();
                    Debug.Log("版本文件生成完毕");
                    System.Diagnostics.Process.Start("Explorer.exe", outPath);
                }
                catch (Exception e)
                {
                    Debug.Log(string.Format("版本文件生成失败！ 原因如下:{0}", e.Message));
                }
                finally
                {
                    //FormLoading.Instance.Stop();
                }
            }
            else
            {
                try
                {
                    //FormLoading.Instance.Start();
                    //DirectoryInfo dirInfo = new DirectoryInfo(resousPath);
                    //FileInfo[] fileInfos = dirInfo.GetFiles();
                    LoadFiles(resousPath);
                    if (FileInfos.Count == 0)
                    {
                        Debug.Log("源文件夹中没有文件",3);
                    }
                    else
                    {
                        CVersion versionlist = new CVersion();
                        versionlist.version = versionNum;
                        int sum = 0;
                        foreach (var fileInfo in FileInfos)
                        {
                            string contents = File.ReadAllText(fileInfo.FullName);
                            string md5 = CreateMd5(contents,isLower);
                            //string name = fileInfo.Name;
                            string name = fileInfo.FullName.Replace("\\","/");
                            string root = resousPath.Replace("\\", "/");
                            name = name.Replace(root+"/", "");
                            Version version = new Version();
                            version.name = name;
                            long size = fileInfo.Length.BinaryUnitConvert(sizeUnit);
                            if (size<=0)
                            {
                                size = 1;
                            }
                            version.size =size.ToString();
                            version.element = md5;
                            versionlist.element.Add(version);
                            sum++;
                            //FormLoading.Instance.SetProgerss((float) sum/FileInfos.Count*100);
                        }

                        string outFilePath = outPath + "/version.xml";
                        FileStream fs = new FileStream(outFilePath, FileMode.Create);
                        XmlSerializer xmlser = new XmlSerializer(typeof(CVersion));
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        settings.IndentChars = "    ";
                        settings.NewLineChars = "\r\n";
                        settings.Encoding = Encoding.UTF8;
                        using (XmlWriter xmlWriter = XmlWriter.Create(fs, settings))
                        {
                            // 强制指定命名空间，覆盖默认的命名空间  
                            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                            namespaces.Add(string.Empty, string.Empty);
                            xmlser.Serialize(xmlWriter, versionlist, namespaces);
                            xmlWriter.Close();
                        };

                        //xmlser.Serialize(fs, versionlist);
                        fs.Close();
                        Debug.Log("版本文件生成完毕。");
                        System.Diagnostics.Process.Start("Explorer.exe", outPath);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(string.Format("版本文件生成失败！ 原因如下:{0}", e.Message),3);
                }
                finally
                {
                    //FormLoading.Instance.Stop();
                }
            }
            return true;
        }
        private List<FileInfo> FileInfos=new List<FileInfo>();
        private List<string> IngorePostFixs=new List<string>(); 

        private void LoadFiles(string root, bool isStart=true)
        {
            if (isStart)
            {
                FileInfos.Clear();
            }
            DirectoryInfo dirInfo = new DirectoryInfo(root);
            FileInfo []files = dirInfo.GetFiles();
            if (files.Length>0)
            {
                foreach (var fileInfo in files)
                {
                    if (IngorePostFixs.Contains(Global.GetFilePostFix(fileInfo.Name)))
                    {
                        continue;
                    }
                    FileInfos.Add(fileInfo);
                }
            }
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            if (dirs.Length>0)
            {
                foreach (var directoryInfo in dirs)
                {
                    LoadFiles(directoryInfo.FullName,false);
                }
            }
        }
    }
}
