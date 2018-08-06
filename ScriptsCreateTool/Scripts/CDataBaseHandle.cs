using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MSExcel = Microsoft.Office.Interop.Excel;
namespace GameTools
{
    class CDataBaseHandle
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="address"></param>
        /// <param name="userName"></param>
        /// <param name="psw"></param>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static MySqlConnection LinkDataBase(string address, string userName, string psw, string dataBaseName, TextBox text=null)
        {
            //string constr = "server=localhost;User Id=root;password=219229;Database=reg";
            string constr = "Data Source=" + address + ";User Id=" + userName + ";Charset=utf8;password=" + psw +
                            ";Database=" + dataBaseName;
            MySqlConnection mycon = new MySqlConnection(constr);
            if (text!=null)
            {
                text.Text += "数据库连接成功!";
            }
            return mycon;
        }

        /// <summary>
        /// 在数据库中创建表
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="checkedListBox1"></param>
        /// <param name="excelDatas"></param>
        public static void CreateTableToSql(CDataBaseInfo dbInfo, CheckedListBox checkedListBox1, List<ExcelData> excelDatas)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);

            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    con.Open();
                    foreach (var item in checkedListBox1.SelectedItems)
                    {
                        string[,] data;
                        string sheetName = "";
                        string excelName = "";
                        for (int i = 0; i < excelDatas.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(excelDatas[i].ExcelName))
                            {
                                if ((string) item == excelDatas[i].SheetShowName)
                                {

                                    excelName = excelDatas[i].ExcelName;
                                    sheetName = excelDatas[i].SheetName;
                                    break;
                                }
                            }
                        }
                        //将sheet表名首字母转换为大写
                        data = Global.GetSheetFromExcel(excelName, sheetName);
                        char[] t = sheetName.Replace("'", "").Replace("$", "").ToCharArray();
                        if ((t[0] > 'a' || t[0] == 'a') && (t[0] < 'z' || t[0] == 'z'))
                        {
                            t[0] = (char) (t[0] - 32);
                        }
                        sheetName = new string(t);
                        cmd = con.CreateCommand();
                        StringBuilder str = new StringBuilder();
                        for (int i = 0; i < data.GetLength(1) - 1; i++)
                        {
                            str.Append(data[1, i]);
                            str.Append(" ");
                            str.Append(data[2, i]);
                            str.Append(",");
                        }
                        str.Append(data[1, data.GetLength(1) - 1]);
                        str.Append(" ");
                        str.Append(data[2, data.GetLength(1) - 1]);
                        str.Append(",");
                        for (int i = 0; i < data.GetLength(1); i++)
                        {
                            if (data[0, i] == "1")
                            {
                                str.Append("PRIMARY KEY (" + data[1, i] + ")");
                                break;
                            }
                        }
                        cmd.CommandText = "create table " + sheetName + " (" + str + ") ENGINE=InnoDB";
                        //  DEFAULT CHARSET=utf8";
                        cmd.ExecuteNonQuery();
                        Debug.Log("创建" + sheetName + "表成功",3);
                    }

                }
                catch (Exception e)
                {
                   Debug.Log("生成文件表结构失败   " + e.Message,3);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 向表中写入数据库
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="checkedListBox1"></param>
        /// <param name="excelDatas"></param>
        public static void ImportDataToTable(CDataBaseInfo dbInfo, CheckedListBox checkedListBox1,
            List<ExcelData> excelDatas)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);

            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    con.Open();
                    foreach (var item in checkedListBox1.SelectedItems)
                    {
                        string[,] data;
                        string sheetName = "";
                        string excelName = "";
                        for (int i = 0; i < excelDatas.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(excelDatas[i].ExcelName))
                            {
                                if ((string) item == excelDatas[i].SheetShowName)
                                {

                                    excelName = excelDatas[i].ExcelName;
                                    sheetName = excelDatas[i].SheetName;
                                    break;
                                }
                            }
                        }
                        //将sheet表名首字母转换为大写
                        data = Global.GetSheetFromExcel(excelName, sheetName);
                        char[] t = sheetName.Replace("'", "").Replace("$", "").ToCharArray();
                        if ((t[0] > 'a' || t[0] == 'a') && (t[0] < 'z' || t[0] == 'z'))
                        {
                            t[0] = (char) (t[0] - 32);
                        }
                        sheetName = new string(t);
                        cmd = con.CreateCommand();
                        for (int i = 5; i < data.GetLength(0); i++)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("(");
                            for (int j = 0; j < data.GetLength(1) - 1; j++)
                            {
                                sb.Append("'");
                                sb.Append(data[i, j]);
                                sb.Append("',");
                            }
                            sb.Append("'");
                            sb.Append(data[i, data.GetLength(1) - 1]);
                            sb.Append("')");
                            cmd.CommandText = "INSERT INTO " + sheetName + " VALUES" + sb;
                            cmd.ExecuteNonQuery();
                        }
                        Debug.Log("向" + sheetName + "表写入数据完成");
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("导入文件表数据失败   " + e.Message,3);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 从数据库中获取所有的表
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="text"></param>
        public static List<string> GetAllTableFromSql(CDataBaseInfo dbInfo)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            List<string> list_tblName = new List<string>();
            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "show tables;";
                    MySqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string t = reader.GetString(0);
                            list_tblName.Add(t);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.Log("读取数据库失败   " + e.Message,3);
                }
                finally
                {
                    con.Close();
                }
            }
            return list_tblName;
        }

        public static void ExportTableFromSql(MSExcel.Application app, CDataBaseInfo dbInfo, string tableName,string filePath)
        {
            string TableConment = GetTableComment(dbInfo, tableName);
            List<string[]> ColInfo = GetColInfo(dbInfo, tableName);
            List<string[]> AllColCount = GetAllCol(dbInfo, tableName);

            CExcelControl.Instance.CreateExcelFile(app,filePath, tableName,TableConment,ColInfo,AllColCount);
        }
        /// <summary>
        /// 获取表的注释
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="tableName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetTableComment(CDataBaseInfo dbInfo, string tableName)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            string tableComment = "";
            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    Debug.Log(string.Format("读取数据库{0}属性...", tableName));
                    con.Open();
                    cmd = con.CreateCommand();
                    MySqlDataReader reader = null;
                    cmd.CommandText =
                        "select table_name,table_comment from information_schema.tables  where table_schema = '" +
                        dbInfo.databaseName + "' and table_name ='" + tableName + "';";
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                tableComment = reader.GetString(1);
                            }
                            catch (Exception)
                            {

                                tableComment="";
                            }
                            
                            
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.Log("读取数据库失败   " + e.Message ,3);
                }
                finally
                {
                    con.Close();
                }
            }
            return tableComment;
        }
        /// <summary>
        /// 获取表的字段
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="tableName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<string[]> GetColInfo(CDataBaseInfo dbInfo, string tableName)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            List<string[]> list_tblName = new List<string[]>();
            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    Debug.Log(string.Format("读取数据库{0}信息...",tableName));
                    con.Open();
                    cmd = con.CreateCommand();
                    MySqlDataReader reader = null;
                    cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + tableName +
                                      "' AND TABLE_SCHEMA = '" + dbInfo.databaseName + "';";
                    //cmd.ExecuteNonQuery();

                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] t = new string[4];
                            {
                                try
                                {
                                    t[0] = reader.GetString("COLUMN_NAME");//字段名
                                }
                                catch(Exception)
                                {
                                    t[0] = "";
                                }
                                try
                                {
                                    t[1] = reader.GetString("DATA_TYPE");//类型
                                }
                                catch (Exception)
                                {
                                    t[1] = "";
                                }
                                try
                                {
                                    t[2] = reader.GetString("COLUMN_KEY");//是否主键 若是主键则为PRI 不是则为空
                                }
                                catch (Exception)
                                {
                                    t[2] = "";
                                }
                                try
                                {
                                    t[3] = reader.GetString("COLUMN_COMMENT");//中文含义
                                }
                                catch (Exception)
                                {
                                    t[3] = "";
                                }
                            }
                            list_tblName.Add(t);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.Log("读取数据库失败   " + e.Message,3);
                }
                finally
                {
                    con.Close();
                }
            }
            return list_tblName;
        }
        /// <summary>
        /// 获取标的内容
        /// </summary>
        /// <param name="dbInfo"></param>
        /// <param name="tableName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<string[]> GetAllCol(CDataBaseInfo dbInfo, string tableName)
        {
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            List<string[]> list_tblName = new List<string[]>();
            if (con != null)
            {
                MySqlCommand cmd;
                try
                {
                    Debug.Log(string.Format("正在读取数据库{0}内容...",tableName));
                    con.Open();
                    cmd = con.CreateCommand();
                    MySqlDataReader reader = null;
                    cmd.CommandText = "SELECT * FROM  " + tableName+";";
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string[] t = new string[reader.FieldCount];
                            for (int i = 0; i < t.Length; i++)
                            {
                                try
                                {
                                    t[i] = reader.GetString(i);
                                }
                                catch (Exception)
                                {

                                    t[i] = "";
                                }
                            }
                            list_tblName.Add(t);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                   Debug.Log("读取数据库失败   " + e.Message ,3);
                }
                finally
                {
                    con.Close();
                }
            }
            return list_tblName;
        }
        public static void UpdateDataBase(CDataBaseInfo dbInfo,string tableName, ExcelData excel)
        {
            string[,] exceldata = Global.GetSheetFromExcel(excel.ExcelName, excel.SheetName);
            if (exceldata == null)
            {
                return;
            }
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            if (con != null)
            {
                MySqlCommand cmd;
                currentOver = false;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = '" + tableName +
                                      "' AND TABLE_SCHEMA = '" + dbInfo.databaseName + "';";
                    //cmd.ExecuteNonQuery();

                    MySqlDataReader reader = null;
                    reader = cmd.ExecuteReader();
                    List<string> colNames=new List<string>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string name = reader.GetString("COLUMN_NAME"); //字段名
                                colNames.Add(name);
                            }
                            catch (Exception e)
                            {
                                Debug.Log(string.Format("{0}:{1}", tableName,e.Message));
                            }
                        }
                    }
                    reader.Close();
                    if (colNames.Count<=0)
                    {
                        Debug.Log(string.Format("{0}表的列数为0", tableName));
                        return;
                    }
                    cmd.CommandText = string.Format("delete from {0};", tableName);
                    cmd.ExecuteNonQuery();
                    Debug.Log(string.Format("{0}表已清空", tableName));
                    Debug.Log(string.Format("{0}表写入数据中...", tableName));
                    con.Close();
                    //UpdateDatabaseSub(con, cmd, tableName, exceldata, text);
                    Mutex mutex=new Mutex();
                   /* int threadNum = Process.GetCurrentProcess().Threads.Count;
                    while (threadNum>80)
                    {
                        Thread.Sleep(100);
                        threadNum = Process.GetCurrentProcess().Threads.Count;
                    }*/
                    /*if (exceldata.GetLength(0) > 50)
                    {
                        int left = (exceldata.GetLength(0)+45) / 10;
                        int right = left * 2;
                        int line = exceldata.GetLength(1);
                        string[,] excel1 = new string[left, line];
                        string[,] excel2 = new string[left, line];
                        string[,] excel3 = new string[left, line];
                        string[,] excel4 = new string[left, line];
                        string[,] excel5 = new string[left, line];
                        string[,] excel6 = new string[left, line];
                        string[,] excel7 = new string[left, line];
                        string[,] excel8 = new string[left, line];
                        string[,] excel9 = new string[left, line];
                        string[,] excel10 = new string[exceldata.GetLength(0)- left * 9+45, line];
                        Array.Copy(exceldata, 0, excel1, 0, 5* line);
                        Array.Copy(exceldata, 0, excel2, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel3, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel4, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel5, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel6, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel7, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel8, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel9, 0, 5 * line);
                        Array.Copy(exceldata, 0, excel10, 0, 5 * line);
                        Array.Copy(exceldata, 5* line, excel1, 5 * line, (left-5) * line);
                        Array.Copy(exceldata, left * line, excel2, 5 * line, (left-5) * line);
                        Array.Copy(exceldata, (left * 2 - 5) * line, excel3, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 3 - 10) * line, excel4, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 4 - 15) * line, excel5, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 5 - 20) * line, excel6, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 6 - 25) * line, excel7, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 7 - 30) * line, excel8, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 8 - 35) * line, excel9, 5 * line, (left - 5) * line);
                        Array.Copy(exceldata, (left * 9 - 40) * line, excel10, 5 * line, (exceldata.GetLength(0)+40 - left * 9) * line);
                        UpdataDataBaseClass udbc1 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel1,index=0,dbInfo=dbInfo,partNum=left,connection = con,colNames = colNames,mutex = mutex};
                        UpdataDataBaseClass udbc2 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel2, index=1, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc3 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel3, index=2, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc4 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel4, index = 3, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc5 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel5, index = 4, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc6 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel6, index = 5, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc7 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel7, index = 6, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc8 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel8, index = 7, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc9 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel9, index = 8, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        UpdataDataBaseClass udbc10 = new UpdataDataBaseClass { tableNam = tableName, exceldata = excel10, index = 9, dbInfo = dbInfo, partNum = left, connection = con, colNames = colNames, mutex = mutex };
                        Thread t1 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t2 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t3 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t4 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t5 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t6 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t7 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t8 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t9 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        Thread t10 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        overFlag = new bool[10];
                        t1.Start(udbc1);
                        t2.Start(udbc2);
                        t3.Start(udbc3);
                        t4.Start(udbc4);
                        t5.Start(udbc5);
                        t6.Start(udbc6);
                        t7.Start(udbc7);
                        t8.Start(udbc8);
                        t9.Start(udbc9);
                        t10.Start(udbc10);
                    }
                    else*/
                    {
                        UpdataDataBaseClass udbc = new UpdataDataBaseClass { tableNam = tableName, exceldata = exceldata, index = -1, dbInfo = dbInfo, connection = con, colNames = colNames, mutex = mutex,partNum = 5};
                        /*Thread t1 = new Thread(new ParameterizedThreadStart(UpdateDatabaseSub));
                        t1.Start(udbc);*/
                        UpdateDatabaseSub(udbc);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("更新数据库失败   " + e.Message,3 );
                    currentOver = true;
                    con.Close();
                }
                /*while (true)
                {
                    Thread.Sleep(10);
                    if (currentOver)
                    {
                        break;
                    }
                }*/
            }
        }
        private static bool[] overFlag;
        private static bool currentOver;
        private static void UpdateDatabaseSub(object obj)
        {
            UpdataDataBaseClass udbc = (UpdataDataBaseClass)obj;
            string tableName = udbc.tableNam;
            string[,] exceldata = udbc.exceldata;
            CDataBaseInfo dbInfo = udbc.dbInfo;
            int index = udbc.index;
            int part = udbc.partNum;
            MySqlConnection con = LinkDataBase(dbInfo.address, dbInfo.userName, dbInfo.password, dbInfo.databaseName);
            //MySqlConnection con = udbc.connection;
            MySqlCommand cmd;
            // TextBox text = udbc.text;
            try
            {

                con.Open();
                cmd = con.CreateCommand();
                for (int i = 5; i < exceldata.GetLength(0); i++)
                {
                    cmd.CommandText = string.Format("insert into {0} values (", tableName);
                    for (int j = 0; j < exceldata.GetLength(1); j++)
                    {
                        /*if (exceldata[0, j].Contains("备注") || exceldata[1, j].Contains("备注") || exceldata[2, j].Contains("备注") || exceldata[3, j].Contains("备注") || exceldata[4, j].Contains("备注"))
                        {
                            continue;
                        }*/
                        if (!udbc.colNames.Contains(exceldata[1,j]))
                        {
                            continue;
                        }
                        if (exceldata[i, j].Length == 255)
                        {
                            Debug.Log(string.Format("{0}表第{1}行第{2}列字符长度为255", tableName, (part - 5) * index + i + 1, j+1),2);
                        }
                        //if (j< exceldata.GetLength(1)-1)
                        {
                            if (exceldata[2, j].Contains("varchar") || exceldata[2,j].Contains("datetime"))
                            {
                                exceldata[i, j] = exceldata[i, j].Replace("，",",").Replace("：",":").Replace("|","|").Replace("“","\"").Replace("”","\"")
                                    .Replace("‘’","'").Replace("’","'").Replace("｛","{").Replace("｝","}").Replace("'", "\\'");
                                cmd.CommandText += "'" + exceldata[i, j] + "',";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(exceldata[i, j]))
                                {
                                    exceldata[i, j] = "NULL";
                                }
                                cmd.CommandText += exceldata[i, j] + ",";
                            }
                        }
                        //else
                        //{
                        //    if (exceldata[2, j].Contains("varchar"))
                        //    {
                        //        cmd.CommandText += "'" + exceldata[i, j] + "'";
                        //    }
                        //    else
                        //    {
                        //        if (string.IsNullOrEmpty(exceldata[i, j]))
                        //        {
                        //            exceldata[i, j] = "NULL";
                        //        }
                        //        cmd.CommandText += exceldata[i, j];
                        //    }

                        //}
                    }
                    cmd.CommandText += ");";
                    while (true)
                    {
                        string str = cmd.CommandText.Substring(cmd.CommandText.Length - 3, 1);
                        if (str == ",")
                        {
                            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 3, 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ee)
                    {
                        Debug.Log(string.Format("{0}表第{1}行  {2}  {3}", tableName,(part-5)*index+i+1, cmd.CommandText, ee.Message));
                    }
                }
                if (index != -1)
                {
                    lock (overFlag)
                    {
                        udbc.mutex.WaitOne();
                        overFlag[index] = true;
                        bool isOver = true;
                        for (int i = 0; i < overFlag.Length; i++)
                        {
                            if (overFlag[i] == false)
                            {
                                isOver = false;
                                break;
                            }
                        }
                        udbc.mutex.ReleaseMutex();
                        if (isOver)
                        {
                            currentOver = true;
                            Debug.Log(string.Format("{0}表更新成功!", tableName));
                        }
                    }
                }
                else
                {
                    currentOver = true;
                    Debug.Log(string.Format("{0}表更新成功!", tableName));
                }
            }
            catch (Exception e)
            {
                currentOver = true;
                Debug.Log("更新数据库失败   " + e.Message + "");
            }
            finally
            {
                con.Close();
            }
        }
    }

   public class UpdataDataBaseClass
    {
        public string tableNam;
        public string[,] exceldata;
        public int index;
        public CDataBaseInfo dbInfo;
        public int partNum;
       public MySqlConnection connection;
       public List<string> colNames;
       public Mutex mutex;
    }
}
