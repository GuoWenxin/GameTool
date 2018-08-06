using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;


namespace GameTools
{
    public class LanageTransfer
    {
        public static bool SimpleToTW(string inputFolderPath,string outPutFolderPath)
        {
            if (!Directory.Exists(inputFolderPath))
            {
                MessageBox.Show("简体文件夹不存在!", "文件夹错误");
                return false;
            }
            DirectoryInfo dirInfo=new DirectoryInfo(inputFolderPath);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (var file in files)
            {
                if (file.DirectoryName != null)
                {
                    StreamReader sr = new StreamReader(file.FullName);
                    string text = sr.ReadToEnd();
                    sr.Close();
                    string resultText = ChineseConverter.Convert(text, ChineseConversionDirection.SimplifiedToTraditional);
                    string outPath = outPutFolderPath + "/" + file.Name;
                    if (!Directory.Exists(outPutFolderPath))
                    {
                        Directory.CreateDirectory(outPutFolderPath);
                    }
                    FileStream fs=new FileStream(outPath,FileMode.Create,FileAccess.Write);
                    StreamWriter sw=new StreamWriter(fs);
                    sw.Write(resultText);
                    sw.Close();
                    Debug.Log(file.FullName + "转化成功");
                }
            }
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (var dir in dirs)
            {
                SimpleToTW(dir.FullName, outPutFolderPath + "/" + dir.Name);
            }
            return true;
        }
        public static bool TWToSimple(string inputFolderPath, string outPutFolderPath)
        {
            if (!Directory.Exists(inputFolderPath))
            {
                MessageBox.Show("繁体文件夹不存在!", "文件夹错误");
                return false;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (var file in files)
            {
                if (file.DirectoryName != null)
                {
                    StreamReader sr = new StreamReader(file.FullName);
                    string text = sr.ReadToEnd();
                    sr.Close();
                    string resultText = ChineseConverter.Convert(text, ChineseConversionDirection.TraditionalToSimplified);
                    string outPath = outPutFolderPath + "/" + file.Name;
                    if (!Directory.Exists(outPutFolderPath))
                    {
                        Directory.CreateDirectory(outPutFolderPath);
                    }
                    FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(resultText);
                    sw.Close();
                    Debug.Log(file.FullName + "转化成功");
                }
            }
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            foreach (var dir in dirs)
            {
                TWToSimple(dir.FullName, outPutFolderPath + "/" + dir.Name);
            }
            return true;
        }
    }
}
