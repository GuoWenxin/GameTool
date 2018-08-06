using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTools
{
    class CResHelper:CSingleton<CResHelper>
    {
        public void ResEncode(ExcelData excel)
        {
            string[,] data = Global.GetSheetFromExcel(excel.ExcelName, excel.SheetName);
            if (data==null)
            {
                return;
            }
            if (!Directory.Exists(Global.ResFolder))
            {
                Directory.CreateDirectory(Global.ResFolder);
            }
            bool successFlag = true;
            FileStream stream = new FileStream(Global.ResFolder + "/" + excel.SheetName.Replace("$", "") + ".res",
                    FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(stream);
                byte[] bytes0 = BitConverter.GetBytes(1);
                WiteByteToBinary(bw, bytes0);
                byte[] bytes00 = BitConverter.GetBytes(data.GetLength(0) - 5);
                WiteByteToBinary(bw, bytes00);
                for (int i = 5; i < data.GetLength(0); i++)
                {
                    //    int lengeth = 0;
                    //    for (int j = 0; j < data.GetLength(1); j++)
                    //    {
                    //        switch (data[2, j])
                    //        {
                    //            case "int":
                    //                lengeth += 4;
                    //                break;
                    //            case "short":
                    //                lengeth += 2;
                    //                break;
                    //            case "long":
                    //                lengeth += 8;
                    //                break;
                    //            case "float":
                    //                lengeth += 4;
                    //                break;
                    //            case "byte":
                    //                lengeth += 1;
                    //                break;
                    //            default:
                    //                lengeth += data[i, j].Length*2;
                    //                break;
                    //        }
                    //    }
                    //    bw.Write(lengeth);
                    
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[1, j] != "" && !data[0,j].Contains("备注") && !data[1, j].Contains("备注") && !data[2, j].Contains("备注") && !data[3, j].Contains("备注") && !data[4, j].Contains("备注"))
                        {
                        if (data[i, j].Length == 255)
                        {
                            Debug.Log(string.Format("{0}表第{1}行第{2}列字符长度为255", excel.SheetName,  i + 1, j+1),2);
                        }
                        try
                        {
                            switch (data[2, j])
                            {
                                case "int":
                                case "smallint":
                                case "tinyint":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(data[i, j]));
                                    WiteByteToBinary(bw, bytes);
                                    break;
                                case "short":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt16(data[i, j]));
                                    WiteByteToBinary(bw, bytes1);
                                    break;
                                case "long":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt64(data[i, j]));
                                    WiteByteToBinary(bw, bytes2);
                                    break;
                                case "float":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes3 = BitConverter.GetBytes(Convert.ToSingle(data[i, j]));
                                    WiteByteToBinary(bw, bytes3);
                                    break;
                                case "byte":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes4 = BitConverter.GetBytes(Convert.ToByte(data[i, j]));
                                    WiteByteToBinary(bw, bytes4);
                                    break;
                                case "":
                                    if (data[i, j] == "")
                                    {
                                        data[i, j] = "0";
                                    }
                                    byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(data[i, j]));
                                    WiteByteToBinary(bw, bytes5);
                                    break;
                                default:

                                    byte[] getBytes = Encoding.UTF8.GetBytes(data[i, j]);
                                    byte[] bytess = BitConverter.GetBytes(getBytes.Length);
                                    WiteByteToBinary(bw, bytess);
                                    bw.Write(getBytes);
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(excel.SheetShowName + "表资源生成失败,原因为:" + e.Message +"第"+(i+1)+"行第"+(j+1)+"列",3);
                            successFlag = false;
                        }
                    }
                }
                bw.Flush();
            }

            bw.Close();
            stream.Close();
            if (successFlag)
            {
                Debug.Log(excel.SheetShowName + "表资源生成完毕");
            }
            else
            {
                Debug.Log(excel.SheetShowName + "表资源生成失败",3);
            }
        }

        private void WiteByteToBinary(BinaryWriter write, byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                System.Array.Reverse(bytes);
            }
            for (int k = 0; k <bytes.Length; k++)
            {
                write.Write(bytes[k]);
            }
        }

        private Assembly assembly;
        public void ResDecode(string dllPath,string resPath,string excelPath,bool isFile)
        {
            if (!File.Exists(dllPath))
            {
                MessageBox.Show("DLL文件不存在!");
                return;
            }
            assembly= Assembly.LoadFile(dllPath);
            if (isFile)
            {
                CreateExcel(resPath,excelPath);
            }
            else
            {
                lostBeanNames.Clear();
                DirectoryInfo di=new DirectoryInfo(resPath);
                FileInfo[] fis = di.GetFiles("*.res");
                for (int i = 0; i < fis.Length; i++)
                {
                    CreateExcel(fis[i].FullName, excelPath);
                }
                if (lostBeanNames.Count>0)
                {
                    string path = excelPath + "/lostbean.txt";
                    FileStream fs=new FileStream(path,FileMode.Create,FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    for (int i = 0; i < lostBeanNames.Count; i++)
                    {
                        sw.Write(lostBeanNames[i]);
                        if (i<lostBeanNames.Count-1)
                        {
                            sw.Write("\r\n");
                        }
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Dispose();
                    fs.Close();
                }
            }
            Debug.Log("Res解析完成",4);
        }
        private List<string> lostBeanNames=new List<string>(); 
        private void CreateExcel(string resPath,string excelPath)
        {
            if (!File.Exists(resPath))
            {
                MessageBox.Show("res资源不存在!");
                return;
            }
            FileInfo fi = new FileInfo(resPath);
            byte[] bytes = File.ReadAllBytes(resPath);
            Type bytearray = assembly.GetType("ByteArray");
            if (bytearray==null)
            {
                MessageBox.Show("Dll中不存在ByteArray项!");
                return;
            }
            Type[] pt0 = new Type[1];
            pt0[0] = bytes.GetType();
            ConstructorInfo baci = bytearray.GetConstructor(pt0);
            object[] obj0 = new object[1];
            obj0[0] = bytes;
            object array = baci.Invoke(obj0);
            string name = fi.Name;
            name = name.Substring(0, name.IndexOf('.'));
            string cName = Global.FirstCharToUpper(name) + "Container";
            Type type = assembly.GetType(cName);
            if (type == null)
            {
                if (!lostBeanNames.Contains(name))
                {
                    lostBeanNames.Add(name);
                }
                Debug.Log(string.Format("Dll中不存在{0}项!", cName),3);
                return;
            }
            Object[] params_obj = new Object[1];
            params_obj[0] = array;
            Type[] pt = new Type[1];
            pt[0] = array.GetType();
            ConstructorInfo ci = type.GetConstructor(pt);
            object ob = ci.Invoke(params_obj);
            PropertyInfo mi = type.GetProperty("list");
            object list = mi.GetValue(ob, null);

            string beanName = "com.game.data.bean." + Global.FirstCharToUpper(name);
            Type bean = assembly.GetType(beanName);
            if (bean==null)
            {
                if (!lostBeanNames.Contains(name))
                {
                    lostBeanNames.Add(name);
                }
                Debug.Log(string.Format("Dll中不存在{0}项!", beanName), 3);
                return;
            }
            PropertyInfo[] beanMi = bean.GetProperties();

            List<string[]> cells = new List<string[]>();
            List<string[]> heads = new List<string[]>();
            string[] he = new string[beanMi.Length];
            for (int i = 0; i < beanMi.Length; i++)
            {
                string[] temp = new string[4];
                temp[0] = beanMi[i].Name;
                heads.Add(temp);
            }
            foreach (var li in (IEnumerable)list)
            {
                string[] temp = new string[beanMi.Length];
                for (int i = 0; i < beanMi.Length; i++)
                {
                    object o = beanMi[i].GetValue(li, null);
                    temp[i] = o.ToString();
                }
                cells.Add(temp);
            }

            Microsoft.Office.Interop.Excel.Application app = CExcelControl.Instance.OpenExcel();
            if (app == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的电脑未安装Excel", "创建失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string outName = excelPath + "/" + name + ".xlsx";
            CExcelControl.Instance.CreateExcelFile(app, outName, name, "", heads, cells);
        }
    }
}
