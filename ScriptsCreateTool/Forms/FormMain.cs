using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Commons.Collections;
using MySql.Data.MySqlClient;
using GameTools.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;
using Timer = System.Timers.Timer;

namespace GameTools
{
    public partial class FormMain : Form
    {
        public List<string> excelFiles;
        public List<ExcelData> excelDatas = new List<ExcelData>();
        private XmlDocument dataDocdoc;
        private XmlElement dbinfoElement;
        private XmlNodeList databasList;
        private List<CDataBaseInfo> dataBases;
        public static RichTextBox LogText;
        public static FormMain Instance;
        public static Timer timer=new Timer();
        public FormMain()
        {
            PlayerPref.Init();
            InitializeComponent();
            InitBasicSetting();
            InitDataBaseInfo();
            if (LogText == null)
            {
                LogText = LogRichText;
                CheckForIllegalCrossThreadCalls = false;
            }
            Instance = this;
            rbDebugtype1.Checked = true;
            timer.Enabled = true;
            timer.Interval = 100;
            timer.Start();
            timer.Elapsed+=Debug.Tick;
            timer.Elapsed+=TickThreadNum;
        }

        private void TickThreadNum(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                labelThreadNum.Text = System.Diagnostics.Process.GetCurrentProcess().Threads.Count.ToString();
            }
            catch (Exception)
            {
            }
        }
        private XmlDocument basicConfigDic;
        private XmlElement basicConfElement;
        private string excelFolder;
        private void 设置数值文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basicConfigDic = ConfigControl.GetXmlDocument(@".\Config\BasicConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(basicConfigDic, "BasicConfig");
            basicConfElement = ConfigControl.GetXmlElement(rootElement, "folder");
            excelFolder = basicConfElement.InnerText;
            linkLabel1.Text = excelFolder;
            FormPathSelect dialog=new FormPathSelect();
            dialog.Text = "请选择数值文件夹";
            dialog.Init(linkLabel1);
            dialog.OnClickSelectBtn += OnClickSelectBtnForExcel;
            dialog.OnClickOkBtn += OnClickOKBtnForExcel;
            dialog.ShowDialog();
        }

        private void OnClickSelectBtnForExcel(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择Excel数值文件的文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.SelectedPath = basicConfElement.InnerText;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text=folderName;
                }
            }
        }

        private void OnClickOKBtnForExcel(TextBox textBoxPath)
        {
            if (basicConfElement != null && textBoxPath.Text != null)
            {
                excelFolder = textBoxPath.Text;
                basicConfElement.InnerText = excelFolder;
                basicConfigDic.Save(@".\Config\BasicConfig.xml");
                Global.Folder = excelFolder;
                linkLabel1.Text = excelFolder;
            }
        }
        private void 刷新所有文件toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            ClearCheckedListBox();
            LoadExcelFiles(1);
            if (excelFiles != null)
            {

                foreach (var file in excelFiles)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        int index = file.LastIndexOf(@"\");
                        string fi = file.Substring(index + 1);
                        this.comboBox1.Items.Add(fi);
                        Thread.Sleep(20);
                    }
                }
                this.comboBox1.SelectedIndex = 0;
            }
        }

        private Thread threas;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox list = (ComboBox) sender;
            int index = list.SelectedIndex;
            threas?.Abort();
            threas = new Thread(new ParameterizedThreadStart(AddSheetToListBox));
            threas.Start(index);
        }

        private void AddSheetToListBox(object obj)
        {
           //FormLoading formLoading=new FormLoading();
           // formLoading.Start();
            int index = (int)obj;
            ClearCheckedListBox();
            if (index == 0 && excelFiles != null)
            {
                int i = 0;
                this.checkedListBox1.Items.Add("<选择全部>");
                foreach (var file in excelFiles)
                {
                    if (file != null)
                    {
                        if ((file.Contains(".xls") || file.Contains(".xlsx")) && !file.Contains("~$"))
                        {
                            LoadSheetFromExcel(file, ref i);
                            Thread.Sleep(20);
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                this.checkedListBox1.Items.Add("<选择全部>");
                LoadSheetFromExcel(excelFiles[index], ref i);
                Thread.Sleep(20);
            }
            Debug.Log("加载完成",4);
            //formLoading.Stop();
        }
        private void LoadSheetFromExcel(string excelName,ref int i)
        {
            string[] sheetnames = Global.GetExcelSheetName(excelName);
            if (sheetnames != null)
            {
                for (int j = 0; j < sheetnames.Length; j++)
                {
                    string filter = Global.FilterSheets;
                    if (!sheetnames[j].Contains("$"))
                    {
                        continue;
                    }
                    if (filter != "")
                    {
                        bool flag = false;
                        string[] splite = filter.Split(',');
                        foreach (var sp in splite)
                        {
                            if (sheetnames[j].Contains(sp))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            continue;
                        }
                    }
                    string showName = sheetnames[j].Replace(",", "").Replace("$", "") + "(" +
                                      excelName.Substring(excelName.LastIndexOf(@"\") + 1) +
                                      ")";
                    excelDatas.Add(new ExcelData(excelName, sheetnames[j],showName));
                    string[,] data = Global.GetSheetFromExcel(excelDatas[i].ExcelName, excelDatas[i].SheetName);
                    if (data == null)
                    {
                        continue;
                    }
                    bool wrongflag = false;
                    bool keyFlag = false;
                    if (data!=null)
                    {
                        bool checkFlag = false;
                        for (int k = 0; k < data.GetLength(1); k++)
                        {
                            try
                            {
                                if (data[0, k] != " " && data[0, k] != "")
                                {
                                    int keyNum = int.Parse(data[0, k]);
                                    if (keyNum==1)
                                    {
                                        if (!checkFlag)
                                        {
                                            keyFlag = true;
                                            checkFlag = true;
                                        }
                                        else
                                        {
                                            Debug.Log(excelDatas[i].SheetShowName + "主键重复，已被跳过",2);
                                        }
                                    }
                                }
                                
                            }
                            catch (Exception)
                            {
                                Debug.Log(excelDatas[i].SheetShowName + "主键格式有误，已被跳过",2);
                                wrongflag = true;
                                break;
                            }
                            
                        }
                        if (!keyFlag)
                        {
                            Debug.Log(excelDatas[i].SheetShowName + "不含主键，已被跳过", 2);
                        }
                        if (!wrongflag )//&& keyFlag)
                        {
                            this.checkedListBox1.Items.Add(excelDatas[i].SheetShowName);
                            Debug.Log("加载 " + excelDatas[i].SheetShowName + "成功");
                            i++;
                        }
                    }
                }
            }
        }
        private void LoadSheetFromExcelFilterName(string excelName,string filtername, ref int i)
        {
            string[] sheetnames = Global.GetExcelSheetName(excelName);
            if (sheetnames != null)
            {
                for (int j = 0; j < sheetnames.Length; j++)
                {
                    string filter = Global.FilterSheets;
                    if (!sheetnames[j].Contains("$"))
                    {
                        continue;
                    }
                    if (filter != "")
                    {
                        bool flag = false;
                        string[] splite = filter.Split(',');
                        foreach (var sp in splite)
                        {
                            if (sheetnames[j].Contains(sp))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            continue;
                        }
                    }
                    string showName = sheetnames[j].Replace(",", "").Replace("$", "") + "(" +
                                      excelName.Substring(excelName.LastIndexOf(@"\") + 1) +
                                      ")";
                    excelDatas.Add(new ExcelData(excelName,sheetnames[j],showName));
                    string[,] data = Global.GetSheetFromExcel(excelDatas[i].ExcelName, excelDatas[i].SheetName);
                    if (data==null)
                    {
                        continue;
                    }
                    if (!excelDatas[i].SheetName.Replace(",", "").Replace("$", "").Contains(filtername) && !excelDatas[i].ExcelName.Substring(excelDatas[i].ExcelName.LastIndexOf(@"\") + 1).Contains(filtername))
                    {
                        continue;
                    }
                    bool wrongflag = false;
                    bool keyFlag = false;
                    if (data != null)
                    {
                        bool checkFlag = false;
                        for (int k = 0; k < data.GetLength(1); k++)
                        {
                            try
                            {
                                if (data[0, k] != " " && data[0, k] != "")
                                {
                                    int keyNum = int.Parse(data[0, k]);
                                    if (keyNum == 1)
                                    {
                                        if (!checkFlag)
                                        {
                                            keyFlag = true;
                                            checkFlag = true;
                                        }
                                        else
                                        {
                                            Debug.Log(excelDatas[i].SheetShowName + "主键重复，已被跳过", 2);
                                        }
                                    }
                                }

                            }
                            catch (Exception)
                            {
                                Debug.Log(excelDatas[i].SheetShowName + "主键格式有误，已被跳过", 2);
                                wrongflag = true;
                                break;
                            }

                        }
                        if (!keyFlag)
                        {
                            Debug.Log(excelDatas[i].SheetShowName + "不含主键，已被跳过", 2);
                        }
                        if (!wrongflag)//&& keyFlag)
                        {
                            this.checkedListBox1.Items.Add(excelDatas[i].SheetShowName);
                            Debug.Log("加载 " + excelDatas[i].SheetShowName + "成功");
                            i++;
                        }
                    }
                }
            }
        }
        private void 刷新选中文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.comboBox1.SelectedIndex;
            ClearCheckedListBox();
            if (index >= 0 && excelFiles != null)
            {
                comboBox1_SelectedIndexChanged(comboBox1, e);
            }
            else if (index < 0)
            {
                MessageBox.Show("请加载Excel文件!", "文件不存在", MessageBoxButtons.OK);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 基本设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBasicSetting dialog = new FormBasicSetting();
            dialog.ShowDialog();
        }

        private void InitBasicSetting()
        {
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\BasicConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "BasicConfig");
            XmlElement folderElement = ConfigControl.GetXmlElement(rootElement, "folder");
            if (folderElement != null)
            {
                Global.Folder = folderElement.InnerText.Trim();
            }
            XmlElement filtSheetsElement = ConfigControl.GetXmlElement(rootElement, "filterSheets");
            if (filtSheetsElement != null)
            {
                XmlNodeList list = filtSheetsElement.SelectNodes("string");
                Global.FilterSheets = "";
                for (int i = 0; i < list.Count - 1; i++)
                {
                    XmlElement element = (XmlElement) list[i];
                    if (!string.IsNullOrEmpty(element.InnerText))
                    {
                        Global.FilterSheets += element.InnerText.Trim();
                        Global.FilterSheets += ',';
                    }

                }
                XmlElement ele = (XmlElement) list[list.Count - 1];
                if (ele != null && !string.IsNullOrEmpty(ele.InnerText))
                {
                    Global.FilterSheets += ele.InnerText.Trim();
                }
            }
            Global.StartLoadFolder = Global.GetXmlInnerTextTrueOrFalse(rootElement, "startLoadFolder");
            Global.LoadData = Global.GetXmlInnerTextTrueOrFalse(rootElement, "loadData");
            XmlElement resFolderElement = ConfigControl.GetXmlElement(rootElement, "resFolder");
            if (resFolderElement != null)
            {
                Global.ResFolder = resFolderElement.InnerText.Trim();
            }
            Global.IsDisorder = Global.GetXmlInnerTextTrueOrFalse(rootElement, "isDisorder");
            Global.IsDataBase = Global.GetXmlInnerTextTrueOrFalse(rootElement, "isDatabase");
            Global.IsResEnc = Global.GetXmlInnerTextTrueOrFalse(rootElement, "isResEnc");
            XmlElement disEncTypeElement = ConfigControl.GetXmlElement(rootElement, "disEncType");
            if (disEncTypeElement != null)
            {
                switch (disEncTypeElement.InnerText.Trim())
                {
                    case "Version":
                        Global.DisEncType = SeedType.Version;
                        break;
                    case "CRC32":
                        Global.DisEncType = SeedType.CRC32;
                        break;
                    case "MD5":
                        Global.DisEncType = SeedType.MD5;
                        break;
                    case "SHA1":
                        Global.DisEncType = SeedType.SHA1;
                        break;
                    default:
                        break;
                }
            }
            XmlElement csTempElement = ConfigControl.GetXmlElement(rootElement, "csTemplate");
            if (csTempElement != null)
            {
                Global.CsTemplate = csTempElement.InnerText.Trim();
            }
            XmlElement typeChangeFileElement = ConfigControl.GetXmlElement(rootElement, "typeBankFile");
            if (typeChangeFileElement != null)
            {
                Global.TypeBankFile = typeChangeFileElement.InnerText.Trim();
            }

            Global.InitMessageSetting();
            this.linkLabel1.Text = Global.Folder;
        }
        
        private void 生成CS资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CCSHandleFuns.CreateCsTable(checkedListBox1, excelDatas, LogTextBox);
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                FormAsRes asres = new FormAsRes();
                asres.InitSetting(checkedListBox1, excelDatas, false);
                asres.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择数据表！", "数据表为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(linkLabel1.Text))
            {
                return;
            }
            System.Diagnostics.Process.Start("Explorer.exe", linkLabel1.Text);

        }
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count > 1)
            {
                if (checkedListBox1.SelectedIndex == 0)
                {
                    if (checkedListBox1.CheckedItems.IndexOf(checkedListBox1.Items[0])==0)
                    {
                        for (int i = 1; i < this.checkedListBox1.Items.Count; i++)
                        {
                            this.checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                    else
                    {
                        for (int i = 1; i < this.checkedListBox1.Items.Count; i++)
                        {
                            this.checkedListBox1.SetItemChecked(i, false);
                        }
                    }
                }
            }
            labelSelectNum.Text = checkedListBox1.CheckedItems.Count.ToString();
        }

        private void ClearCheckedListBox()
        {
            checkedListBox1.Items.Clear();
            labelSelectNum.Text ="0";
        }
        private void LogRichText_TextChanged(object sender, EventArgs e)
        {
            this.LogRichText.SelectionStart = this.LogRichText.Text.Length;
            this.LogRichText.ScrollToCaret();
        }

        private void InitDataBaseInfo()
        {
            dataDocdoc = ConfigControl.GetXmlDocument(@".\Config\DbConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(dataDocdoc, "DatabaseConfig");
            dbinfoElement = ConfigControl.GetXmlElement(rootElement, "DbInfos");
            databasList = dbinfoElement.SelectNodes("DatabaseInfo");
            dataBases=new List<CDataBaseInfo>();
            if (databasList.Count>0)
            {
                for (int i = 0; i < databasList.Count; i++)
                {
                    CDataBaseInfo db = new CDataBaseInfo((XmlElement) databasList[i]);
                    dataBases.Add(db);
                    DataBaseComBobox.Items.Add(dataBases[i].title);
                }
                //DataBaseComBobox.SelectedIndex = 0;
            }

            string strselectIndex= PlayerPref.GetData("DataBaseSelectIndex");
            int index = -1;
            if (!string.IsNullOrEmpty(strselectIndex))
            {
                index= int.Parse(strselectIndex);
            }
            DataBaseComBobox.SelectedIndex = index;
        }

        private void DataBaseComBobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDatabaseComBox();
        }

        public void RefreshDatabaseComBox()
        {

            int index = DataBaseComBobox.SelectedIndex;
            if (index >= 0)
            {
                DataBaseAddressLabel.Text = "地址:" + dataBases[index].address + ":" + dataBases[index].port;
                DataBaseNameLabel.Text = "数据库:" + dataBases[index].databaseName;
                DataBaseUserNameLabel.Text = "用户名:" + dataBases[index].userName;
                lbDaLocalPosition.Text = "本地位置:" + dataBases[index].localPositionPath;
            }
            else
            {
                DataBaseAddressLabel.Text = "地址:";
                DataBaseNameLabel.Text = "数据库:";
                DataBaseUserNameLabel.Text = "用户名:";
                lbDaLocalPosition.Text = "本地位置:";
            }
            PlayerPref.SetData("DataBaseSelectIndex",index.ToString());
        }
        private void AddDataBaseBtn_Click(object sender, EventArgs e)
        {
            if (dataDocdoc!=null)
            {
                FormDataBaseSetting db = new FormDataBaseSetting();
                db.InitAddDataBase(dataDocdoc, @".\Config\DbConfig.xml", dbinfoElement,ref dataBases, DataBaseComBobox);
                db.ShowDialog();
            }
        }

        private void ModifyDataBaseBtn_Click(object sender, EventArgs e)
        {
            int index = DataBaseComBobox.SelectedIndex;
            if (index>=0)
            {
                FormDataBaseSetting db = new FormDataBaseSetting();
                db.InitModifyDataBase(dataDocdoc, @".\Config\DbConfig.xml", (XmlElement)databasList[index], dataBases[index], DataBaseComBobox);
                db.ShowDialog();
            }
            
        }

        private void RemoveDataBaseBtn_Click(object sender, EventArgs e)
        {
            int index = DataBaseComBobox.SelectedIndex;
            if (index>=0)
            {
                DialogResult dr= MessageBox.Show("确定要删除【" + dataBases[index].title + "】连接吗？", "删除", MessageBoxButtons.YesNo);
                if (dr==DialogResult.Yes)
                {
                    dataBases.RemoveAt(index);
                    databasList = dbinfoElement.SelectNodes("DatabaseInfo");
                    dbinfoElement.RemoveChild(databasList[index]);
                    dataDocdoc.Save(@".\Config\DbConfig.xml");
                    DataBaseComBobox.Items.RemoveAt(index);
                    if (index > 0)
                    {
                        DataBaseComBobox.SelectedIndex = 0;
                    }
                    else
                    {
                        DataBaseComBobox.SelectedIndex = -1;
                    }
                }
            }
            RefreshDatabaseComBox();
        }

        private void 生成选中我文件表结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection collection = checkedListBox1.CheckedItems;
            if (collection.Count == 0)
            {
                MessageBox.Show("请选择需要生成的表", "空表", MessageBoxButtons.OK);
                return;
            }
            if (DataBaseComBobox.SelectedIndex<0)
            {
                MessageBox.Show("请选择需要需要操作的数据库", "没有数据库", MessageBoxButtons.OK);
                return;
            }
            int index = DataBaseComBobox.SelectedIndex;
            if (dataBases[index].dbType == "MySql")
            {
                CDataBaseHandle.CreateTableToSql(dataBases[index], checkedListBox1, excelDatas);
            }
            
        }

        private void 导入选中表数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection collection = checkedListBox1.CheckedItems;
            if (collection.Count == 0)
            {
                MessageBox.Show("请选择需要生成的表", "空表", MessageBoxButtons.OK);
                return;
            }
            if (DataBaseComBobox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择需要需要操作的数据库", "没有数据库", MessageBoxButtons.OK);
                return;
            }
            int index = DataBaseComBobox.SelectedIndex;
            if (dataBases[index].dbType == "MySql")
            {
                CDataBaseHandle.ImportDataToTable(dataBases[index], checkedListBox1, excelDatas);
            }
        }
        private void GetTablesFromSql_Click(object sender, EventArgs e)
        {
            if (DataBaseComBobox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择需要需要操作的数据库", "没有数据库", MessageBoxButtons.OK);
                return;
            }
            int index = DataBaseComBobox.SelectedIndex;
            if (dataBases[index].dbType == "MySql")
            {
                List<string> nameList=CDataBaseHandle.GetAllTableFromSql(dataBases[index]);
                if (nameList.Count>0)
                {
                    ClearCheckedListBox();
                    checkedListBox1.Items.Add("<选择全部>");
                    foreach (var name in nameList)
                    {
                        checkedListBox1.Items.Add(name);
                    }
                }
            }
        }
        private void ExportFromSqlItem_Click(object sender, EventArgs e)
        {
            if (DataBaseComBobox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择需要需要操作的数据库", "没有数据库", MessageBoxButtons.OK);
                return;
            }
            FormPathSelect dialog = new FormPathSelect();
            dialog.Text = "请选择目标文件夹";
            dialog.OnClickSelectBtn += OnClickSelectBtnForImportExcel;
            dialog.OnClickOkBtn += OnClickOKBtnForImportExcel;
            string path= PlayerPref.GetData("ExportExcelPath");
            dialog.SetPath(path);
            dialog.ShowDialog();
            
        }
        private void OnClickSelectBtnForImportExcel(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择Excel数值文件的文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }
        private void OnClickOKBtnForImportExcel(TextBox textBoxPath)
        {
            string outExcelPath = "";
            if (textBoxPath.Text != null)
            {
                outExcelPath = textBoxPath.Text;
                PlayerPref.SetData("ExportExcelPath", outExcelPath);
                int index = DataBaseComBobox.SelectedIndex;
                CheckedListBox.CheckedItemCollection collection = checkedListBox1.CheckedItems;
                MSExcel.Application app= CExcelControl.Instance.OpenExcel();
                if (app==null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的电脑未安装Excel", "创建失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var item in collection)
                {
                    string path = string.Format("{0}/{1}.xlsx", outExcelPath, item.ToString());
                    if (item.ToString()== "<选择全部>")
                    {
                        continue;
                    }
                    if (app!=null)
                    {
                        CDataBaseHandle.ExportTableFromSql(app, dataBases[index], item.ToString(), path);
                    }
                    
                }
                if (app != null)
                {
                    CExcelControl.Instance.CloseExcel(app);
                }
                System.Diagnostics.Process.Start("Explorer.exe", outExcelPath);
            }
        }
        private void 生成As资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                FormAsRes asres=new FormAsRes();
                asres.InitSetting(checkedListBox1,excelDatas);
                asres.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择数据表！", "数据表为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 生成Java资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                FormJavaRes javaRes = new FormJavaRes();
                javaRes.InitSetting(checkedListBox1, excelDatas);
                javaRes.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择数据表！", "数据表为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        private void CS单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择CS消息配置文件";
            fileDialog.Filter = "所有 文件(*.xml)|*.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Contains(".xml"))
                {
                    FormCSMessageConfig config=new FormCSMessageConfig();
                    config.Init(new []{fileDialog.FileName});
                    config.ShowDialog();
                }
                
            }
        }

        private XmlDocument csMessFolderPath = null;
        private XmlElement csMessageFolderElement = null;
        private void CS单个文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPathSelect dialog=new FormPathSelect();
            dialog.OnInit += OnInitCsPath;
            dialog.OnClickSelectBtn += OnClickSelectBtnForXmlFolder;
            dialog.OnClickOkBtn += OnClickCreateBtnForCsMessage;
            dialog.Init();
            dialog.ShowDialog();
        }

        private void OnInitCsPath(TextBox pathText)
        {
            csMessFolderPath=ConfigControl.GetXmlDocument(@".\Config\MessageConfig.xml");
            XmlElement rootXmlElement = ConfigControl.GetXmlRootAsElement(csMessFolderPath, "MessageConfig");
            XmlElement csElement = ConfigControl.GetXmlElement(rootXmlElement, "CS");
            csMessageFolderElement = ConfigControl.GetXmlElement(csElement, "messageFolder");
            pathText.Text = csMessageFolderElement.InnerText;
        }
        private void OnClickSelectBtnForXmlFolder(TextBox textBox)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择xml文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    
                    textBox.Text = folderName;
                }
            }
        }

        private void OnClickCreateBtnForCsMessage(TextBox textBox)
        {
            csMessageFolderElement.InnerText = textBox.Text;
            csMessFolderPath.Save(@".\Config\MessageConfig.xml");
            string[] filePaths = Directory.GetFiles(textBox.Text);
            FormCSMessageConfig config = new FormCSMessageConfig();
            config.Init(filePaths);
            config.ShowDialog();
        }
        private void 单个AS文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择As消息配置文件";
            fileDialog.Filter = "所有 文件(*.xml)|*.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Global.AsMessageFilePath = fileDialog.FileName;
                Global.CsMessages = ConfigControl.ReadMessageXml(Global.AsMessageFilePath);
                Debug.Log("配置表读取成功");
                CAsHandleFuns.Instance.GetInstance().CreateAsMessage();
                System.Diagnostics.Process.Start("Explorer.exe", Global.ResFolder + @"\AS\NetWork\");
            }
        }

        private void 单个AS文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择xml文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    string[] filePaths = Directory.GetFiles(folderName);
                    foreach (var file in filePaths)
                    {
                        Global.AsMessageFilePath = file;
                        Global.CsMessages = ConfigControl.ReadMessageXml(Global.AsMessageFilePath);
                        Debug.Log( "配置表读取成功");
                        CAsHandleFuns.Instance.GetInstance().CreateAsMessage();
                    }
                    System.Diagnostics.Process.Start("Explorer.exe", Global.ResFolder + @"\AS\NetWork\");
                }
            }
        }
        private void 单个Java文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择Java消息配置文件";
            fileDialog.Filter = "所有 文件(*.xml)|*.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //Global.AsMessageFilePath = fileDialog.FileName;
                //Global.CsMessages = ConfigControl.ReadMessageXml(Global.AsMessageFilePath);
                //CAsHandleFuns.Instance.GetInstance().CreateAsMessage(LogTextBox);
                CJavaHandleFuns.Instance.CreateJavaMessageSeries(fileDialog.FileName);
                System.Diagnostics.Process.Start("Explorer.exe", Global.ResFolder + @"\Java\NetWork");
            }
        }

        private void 单个Java文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择xml文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    string[] filePaths = Directory.GetFiles(folderName);
                    foreach (var file in filePaths)
                    {
                        CJavaHandleFuns.Instance.CreateJavaMessageSeries(file);
                    }
                    System.Diagnostics.Process.Start("Explorer.exe", Global.ResFolder + @"\Java\NetWork");
                }
            }
        }

        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream stream=new FileStream(@".\Config\Instruction.txt",FileMode.Open,FileAccess.Read);
            StreamReader reader=new StreamReader(stream);
            string contends = reader.ReadToEnd();
            MessageBox.Show(contends, "使用说明", MessageBoxButtons.OK,MessageBoxIcon.Information);
            reader.Close();
            stream.Close();
        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Clearmessages();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (DataBaseComBobox.SelectedIndex < 0)
            {
                MessageBox.Show("请选择需要需要操作的数据库", "没有数据库", MessageBoxButtons.OK);
                return;
            }
            int dbIndex = DataBaseComBobox.SelectedIndex;
            if (dbIndex < 0)
            {
                MessageBox.Show("数据库信息为空，请先设置数据库信息", "错误", MessageBoxButtons.OK);
                return;
            }
            string path = dataBases[dbIndex].localPositionPath;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("本地数据库文件夹不存在，请重新设置路径!", "错误", MessageBoxButtons.OK);
                return;
            }
            CheckedListBox.CheckedItemCollection collection = checkedListBox1.CheckedItems;
            if (collection.Count == 0)
            {
                MessageBox.Show("请先选择文件表数据", "空数据", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result= MessageBox.Show(string.Format("确定要回滚{0}文件夹的数据吗？", path), "更新数据库", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                int index = DataBaseComBobox.SelectedIndex;
                //MySqlConnection con = CDataBaseHandle.LinkDataBase(dataBases[index].address,dataBases[index].userName, dataBases[index].password, dataBases[index].databaseName);
                List<ExcelData> datas=new List<ExcelData>();
                foreach (var item in collection)
                {
                    if (item.ToString() == "<选择全部>")
                    {
                        continue;
                    }
                    if (dataBases[index].dbType == "MySql")
                    {

                        for (int i = 0; i < excelDatas.Count; i++)
                        {
                            if (item.ToString() == excelDatas[i].SheetShowName)
                            {
                                datas.Add(excelDatas[i]);
                                //CDataBaseHandle.UpdateDataBase(con, excelDatas[i].SheetName.Replace("$",""), excelDatas[i],LogTextBox);
                                //CDataBaseHandle.UpdateDataBase(dataBases[index],excelDatas[i].SheetName.Replace("$", ""), excelDatas[i],con);
                                break;
                            }
                        }
                    }
                }
                //con.Open();
                if (datas.Count>0)
                {
                    for (int i = 0; i < datas.Count; i++)
                    {
                        CDataBaseHandle.UpdateDataBase(dataBases[index], datas[i].SheetName.Replace("$", ""), datas[i]);
                    }
                }
                Thread.Sleep(1000);
                Debug.Log("更新数据库完成",4);
                //con.Close();
            }
        }
        #region MD5生成版本文件
        
        private void 单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersionSetting versionset = new FormVersionSetting (false);
            versionset.ShowDialog();
        }
        private void 文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersionSetting versionset = new FormVersionSetting(true);
            versionset.ShowDialog();
        }
        #endregion

        private void 简转繁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = PlayerPref.GetData("LanageTransferSimpleToTWSimple");
            FormPathSelect dialog = new FormPathSelect();
            dialog.Text = "请选择简体文件夹";
            dialog.SetPath(path);
            dialog.OnClickSelectBtn += OnClickSelectBtnForSimple;
            dialog.OnClickOkBtn += OnClickOKBtnForSimple;
            dialog.ShowDialog();
        }
        private void OnClickSelectBtnForSimple(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择简体文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            string path = PlayerPref.GetData("LanageTransferSimpleToTWSimple");
            folderBrowserDialog1.SelectedPath = path;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }
        private void OnClickOKBtnForSimple(TextBox textBoxPath)
        {
            if (textBoxPath.Text != null)
            {
                PlayerPref.SetData("LanageTransferSimpleToTWSimple", textBoxPath.Text);
                string path = PlayerPref.GetData("LanageTransferSimpleToTWTW");
                FormPathSelect dialog = new FormPathSelect();
                dialog.Text = "请选择繁体文件夹";
                dialog.SetPath(path);
                dialog.OnClickSelectBtn += OnClickSelectBtnForTW;
                dialog.OnClickOkBtn += OnClickOKBtnForTW;
                dialog.ShowDialog();
            }
        }
        private void OnClickSelectBtnForTW(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择繁体文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            string path = PlayerPref.GetData("LanageTransferSimpleToTWTW");
            folderBrowserDialog1.SelectedPath = path;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }
        private void OnClickOKBtnForTW(TextBox textBoxPath)
        {
            if (textBoxPath.Text != null)
            {
                PlayerPref.SetData("LanageTransferSimpleToTWTW", textBoxPath.Text);
                CheckForIllegalCrossThreadCalls = false;
                try
                {
                    new Thread(() => LanageSimpeToTW()).Start();
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message ,3);
                }
            }
        }

        private void LanageSimpeToTW()
        {
            string inputPath = PlayerPref.GetData("LanageTransferSimpleToTWSimple");
            string outputPath= PlayerPref.GetData("LanageTransferSimpleToTWTW");
            if (LanageTransfer.SimpleToTW(inputPath, outputPath))
            {
                Debug.Log("简转繁成功");
            }
            else
            {
                Debug.Log("简转繁失败",3);
            }
        }

        private void 繁转简ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = PlayerPref.GetData("LanageTransferTWToSimpleTW");
            FormPathSelect dialog = new FormPathSelect();
            dialog.Text = "请选择繁体文件夹";
            dialog.SetPath(path);
            dialog.OnClickSelectBtn += OnClickSelectBtnForTWSimple;
            dialog.OnClickOkBtn += OnClickOKBtnForTWSimple;
            dialog.ShowDialog();
        }
        private void OnClickSelectBtnForTWSimple(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择繁体文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            string path = PlayerPref.GetData("LanageTransferTWToSimpleTW");
            folderBrowserDialog1.SelectedPath = path;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }
        private void OnClickOKBtnForTWSimple(TextBox textBoxPath)
        {
            if (textBoxPath.Text != null)
            {
                PlayerPref.SetData("LanageTransferTWToSimpleTW", textBoxPath.Text);
                string path = PlayerPref.GetData("LanageTransferTWToSimpleSimple");
                FormPathSelect dialog = new FormPathSelect();
                dialog.Text = "请选择简体文件夹";
                dialog.SetPath(path);
                dialog.OnClickSelectBtn += OnClickSelectBtnForTWSimpleTw;
                dialog.OnClickOkBtn += OnClickOKBtnForTWSimpleTw;
                dialog.ShowDialog();
            }
        }
        private void OnClickSelectBtnForTWSimpleTw(TextBox textBoxPath)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择简体文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            string path = PlayerPref.GetData("LanageTransferTWToSimpleSimple");
            folderBrowserDialog1.SelectedPath = path;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }
        private void OnClickOKBtnForTWSimpleTw(TextBox textBoxPath)
        {
            if (textBoxPath.Text != null)
            {
                PlayerPref.SetData("LanageTransferTWToSimpleSimple", textBoxPath.Text);
                CheckForIllegalCrossThreadCalls = false;
                try
                {
                    new Thread(() => LanageTWToSimple()).Start();
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message,3);
                }
            }
        }

        private void LanageTWToSimple()
        {
            string inputPath = PlayerPref.GetData("LanageTransferTWToSimpleTW");
            string outputPath = PlayerPref.GetData("LanageTransferTWToSimpleSimple");
            if (LanageTransfer.TWToSimple(inputPath, outputPath))
            {
                Debug.Log("繁转简成功");
            }
            else
            {
                Debug.Log("繁转简失败",3);
            }
        }
        
        private void LoadExcelFiles(int type)
        {
            string folderPath = "";
            if (type == 1)
            {
                if (!Directory.Exists(Global.Folder))
                {
                    MessageBox.Show("数值文件夹不存在，请重新设置路径!", "错误", MessageBoxButtons.OK);
                    return;
                }
                linkLabel1.Text = Global.Folder;
                folderPath = Global.Folder;
            }
            else if (type == 2)
            {
                int index = DataBaseComBobox.SelectedIndex;
                if (index<0)
                {
                    MessageBox.Show("数据库信息为空，请先设置数据库信息", "错误", MessageBoxButtons.OK);
                    return;
                }
                string path = dataBases[index].localPositionPath;
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("本地数据库文件夹不存在，请重新设置路径!", "错误", MessageBoxButtons.OK);
                    return;
                }
                linkLabel1.Text = path;
                folderPath = path;
            }
            int sum = 0;
            if (!string.IsNullOrEmpty(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath);
                excelFiles = new List<string>();
                foreach (var file in fileNames)
                {
                    if ((file.Contains(".xls") || file.Contains(".xlsx")) && !file.Contains("~$"))
                    {
                        excelFiles.Add( file);
                        sum++;
                    }
                }
                labelAllNumber.Text = sum.ToString();
            }
            else
            {
                MessageBox.Show("请先设置数值文件夹路径", "路径为空", MessageBoxButtons.OK);
            }
        }

        private void OnTbSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchExcelOrSheet();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchExcelOrSheet();
        }

        private void SearchExcelOrSheet()
        {
            if (excelFiles.IsNullOrCountZero())
            {
                LoadExcelFiles(1);
            }
            TextBox tb = tBSearch;
            string filterName = tb.Text;
            ClearCheckedListBox();
            if (!filterName.IsNullOrEmpty())
            {
                if (!excelFiles.IsNullOrCountZero())
                {
                    int i = 0;
                    this.checkedListBox1.Items.Add("<选择全部>");
                    foreach (var file in excelFiles)
                    {
                        if (file != null)
                        {
                            if ((file.Contains(".xls") || file.Contains(".xlsx")) && !file.Contains("~$"))
                            {
                                LoadSheetFromExcelFilterName(file, filterName, ref i);
                                Thread.Sleep(20);
                            }
                        }
                    }
                    Debug.Log("搜索完成", 4);
                }
            }
        }

        private void MenuItemJsonDecode_Click(object sender, EventArgs e)
        {
            JsonHelper.Instance.SelectJsonFile();
        }

        private void MenItemResCreate_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection collection = checkedListBox1.CheckedItems;
            if (collection.Count == 0)
            {
                MessageBox.Show("请先选择文件表数据", "空数据", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var item in collection)
            {
                string name = item.ToString();
                for (int i = 0; i < excelDatas.Count; i++)
                {
                    if (name == excelDatas[i].SheetShowName)
                    {
                        CResHelper.Instance.GetInstance().ResEncode(excelDatas[i]);
                        break;
                    }
                }
            }
            System.Diagnostics.Process.Start("Explorer.exe", Global.ResFolder);
        }

        private void MenuItemDecodeResSingle_Click(object sender, EventArgs e)
        {
            FormResDecode dialog=new FormResDecode();
            dialog.InitDialog(true);
            dialog.ShowDialog();
        }

        private void MenuItemDecodeResFolder_Click(object sender, EventArgs e)
        {
            FormResDecode dialog = new FormResDecode();
            dialog.InitDialog(false);
            dialog.ShowDialog();
        }

        private void MenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本信息:2.3.1","关于",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        public static int DebugType;
        private void OnDebugTypeChange(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton) sender;
            if (!rb.Checked)
            {
                return;
            }
            switch (rb.Name)
            {
                case "rbDebugtype1":
                    DebugType = 1;
                    break;
                case "rbDebugtype2":
                    DebugType = 2;
                    break;
                case "rbDebugtype3":
                    DebugType = 3;
                    break;
                case "rbDebugtype4":
                    DebugType = 4;
                    break;
                case "rbDebugtype5":
                    DebugType = 5;
                    break;
            }
            Debug.ChangeLog(DebugType);
        }

        private void miReadLoalDatabase_Click(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            ClearCheckedListBox();
            LoadExcelFiles(2);
            if (excelFiles != null)
            {

                foreach (var file in excelFiles)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        int index = file.LastIndexOf(@"\");
                        string fi = file.Substring(index + 1);
                        this.comboBox1.Items.Add(fi);
                        Thread.Sleep(20);
                    }
                }
                this.comboBox1.SelectedIndex = 0;
            }
        }
    }
    public struct ExcelData
    {
        public string ExcelName;
        public string SheetName;
        public string SheetShowName;

        public ExcelData(string en, string sn ,string ssn)
        {
            ExcelName = en;
            SheetName = sn;
            SheetShowName = ssn;
        }
    }
}
