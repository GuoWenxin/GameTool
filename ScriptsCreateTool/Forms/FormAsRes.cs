using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GameTools
{ 
    public partial class FormAsRes : Form
    {
        private List<CAsDataConfig> dataConfigs=new List<CAsDataConfig>();

        private CheckedListBox dataList;
        private List<ExcelData> dataExcels;
        
        private int currentConfig = 0;

        private bool comBoxRefreshFlag = false;

        private bool isAs=true;
        public FormAsRes()
        {
            InitializeComponent();
        }

        public void InitSetting(CheckedListBox listbox,List<ExcelData>sheets,bool asFlag=true)
        {
            isAs = asFlag;
            dataList = listbox;
            dataExcels = sheets;
            XmlElement root;
            if (isAs)
            {
                XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\AsDataConfig.xml");
                root = ConfigControl.GetXmlRootAsElement(doc, "AsDataGenerateConfig");
                XmlElement config = root.SelectSingleNode("configs") as XmlElement;
                if (config != null)
                {
                    XmlNodeList configList = config.SelectNodes("AsDataGenerateInfo");
                    if (configList.Count > 0)
                    {
                        for (int i = 0; i < configList.Count; i++)
                        {

                            CAsDataConfig dataConfig = new CAsDataConfig();
                            dataConfig.LoadConfig((XmlElement)configList[i]);
                            dataConfigs.Add(dataConfig);
                        }
                    }
                }
            }
            else
            {
                label1.Text = "Cs Src目录：";
                label2.Text = "Cs包：";
                label3.Text = "bean using  List：";
                label4.Text = "Container using  list:";
                XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\CsDataConfig.xml");
                root = ConfigControl.GetXmlRootAsElement(doc, "CsDataGenerateConfig");
                XmlElement config = root.SelectSingleNode("configs") as XmlElement;
                if (config != null)
                {
                    XmlNodeList configList = config.SelectNodes("CsDataGenerateInfo");
                    if (configList.Count > 0)
                    {
                        for (int i = 0; i < configList.Count; i++)
                        {

                            CAsDataConfig dataConfig = new CAsDataConfig();
                            dataConfig.LoadConfig((XmlElement)configList[i]);
                            dataConfigs.Add(dataConfig);
                        }
                    }
                }
                checkBoxLoad.Checked = false;
            }
            int index = Convert.ToInt32(ConfigControl.GetXmlElementInnerText(root, "lastIndex"));
            currentConfig = index;
            //comboBoxCapterList.Items.Clear();
            //for (int i = 0; i < dataConfigs.Count; i++)
            //{
            //    comboBoxCapterList.Items.Add(dataConfigs[i].caption);
            //}
            comBoxRefreshFlag = true;
            RefreshData();
            //comboBoxCapterList.SelectedIndex = index;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (isAs)
            {
                this.Close();
                if (checkBoxBean.Checked)
                {
                    CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
                    foreach (var item in collection)
                    {
                        string name = item.ToString();
                        for (int i = 0; i < dataExcels.Count; i++)
                        {
                            if (name == dataExcels[i].SheetShowName)
                            {
                                if (checkBoxIsSet.Checked)
                                {
                                    CAsHandleFuns.Instance.CreateAsResBean(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex]);
                                }
                                else
                                {
                                    CAsHandleFuns.Instance.CreateAsResBean(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex], false);
                                }
                                break;
                            }
                        }
                    }
                }
                if (checkBoxContainer.Checked)
                {
                    CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
                    foreach (var item in collection)
                    {
                        string name = item.ToString();
                        for (int i = 0; i < dataExcels.Count; i++)
                        {
                            if (name == dataExcels[i].SheetShowName)
                            {
                                CAsHandleFuns.Instance.CreateAsContainer(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex]);
                                break;
                            }
                        }
                    }
                }
                
                System.Diagnostics.Process.Start("Explorer.exe", dataConfigs[currentConfig].folder + @"\"+dataConfigs[currentConfig].package.Replace(".",@"\"));
            }
            else//生成Cs资源
            {
                this.Close();
                if (checkBoxBean.Checked)
                {
                    CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
                    foreach (var item in collection)
                    {
                        string name = item.ToString();
                        for (int i = 0; i < dataExcels.Count; i++)
                        {
                            if (name == dataExcels[i].SheetShowName)
                            {
                                if (checkBoxIsSet.Checked)
                                {
                                    CCSHandleFuns.Instance.CreateCsResBean(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex]);
                                }
                                else
                                {
                                    CCSHandleFuns.Instance.CreateCsResBean(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex], false);
                                }
                                break;
                            }
                        }
                    }
                }
                if (checkBoxContainer.Checked)
                {
                    //List<string> nameList=new List<string>();
                    CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
                    foreach (var item in collection)
                    {
                        string name = item.ToString();
                        for (int i = 0; i < dataExcels.Count; i++)
                        {
                            if (name == dataExcels[i].SheetShowName)
                            {
                                CCSHandleFuns.Instance.CreateCsContainer(dataExcels[i], dataConfigs[comboBoxCapterList.SelectedIndex]);
                                //nameList.Add(dataExcels[i].SheetName);
                                break;
                            }
                        }
                    }
                }
                if(checkBoxLoad.Checked)
                {
                    List<string> nameList=new List<string>();
                    CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
                    foreach (var item in collection)
                    {
                        string name = item.ToString();
                        for (int i = 0; i < dataExcels.Count; i++)
                        {
                            if (name == dataExcels[i].SheetShowName)
                            {
                                nameList.Add(dataExcels[i].SheetName);
                                break;
                            }
                        }
                    }
                    CreateLoadConfig(nameList, dataConfigs[currentConfig].folder);
                }
                System.Diagnostics.Process.Start("Explorer.exe", dataConfigs[currentConfig].folder);
            }
        }

        public void CreateLoadConfig(List<string> nameList,string path)
        {
            for (int i = 0; i < nameList.Count; i++)
            {
                nameList[i] = nameList[i].Replace("$", "");
            }
            if (nameList!=null && nameList.Count>0)
            {
                string Titles = "";
                foreach (var name in nameList)
                {
                    string temp = name.Replace("t_base_", "");
                    string[] tempStrings = temp.Split('_');
                    string NewName = "";
                    for (int i = 0; i < tempStrings.Length; i++)
                    {
                        tempStrings[i] = Global.FirstCharToUpper(tempStrings[i]);
                        NewName += tempStrings[i];
                    }
                    Titles += string.Format("    public static {0}Container {1}Container=null;",Global.FirstCharToUpper(name), NewName);
                }
                string Paths = "";
                foreach (var name in nameList)
                {
                    string temp = name.Replace("t_base_", "");
                    string[] tempStrings = temp.Split('_');
                    string NewName = "";
                    for (int i = 0; i < tempStrings.Length; i++)
                    {
                        tempStrings[i] = Global.FirstCharToUpper(tempStrings[i]);
                        NewName += tempStrings[i];
                    }
                    Paths +=string.Format("        DownLoadConifgRes(make_version(63578), \"res / \", \"{0}.res\", LoadConfig{1}Complete, false);",name,NewName);
                }
                string Funcs = "";
                foreach (var name in nameList)
                {
                    string temp = name.Replace("t_base_", "");
                    string[] tempStrings = temp.Split('_');
                    string NewName = "";
                    for (int i = 0; i < tempStrings.Length; i++)
                    {
                        tempStrings[i] = Global.FirstCharToUpper(tempStrings[i]);
                        NewName += tempStrings[i];
                    }
                    Funcs +="    private void LoadConfig"+ NewName+ "Complete(byte[] data, DownLoadFile file)    {        MemoryStream ms = new MemoryStream(data, 0, data.Length);        ByteArray bytearray = new ByteArray(ms);        " + NewName + "Container = new "+ Global.FirstCharToUpper(name)+ "Container(bytearray);        step++;    }";
                }
                FileStream fs=new FileStream(path+"/Funs.txt",FileMode.Create,FileAccess.Write);
                StreamWriter fw=new StreamWriter(fs);
                fw.Write(Titles);
                fw.Write(Paths);
                fw.Write(Funcs);
                fw.Close();
                fs.Close();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SetCurrentData();
            FormResName rename=new FormResName();
            rename.Text = "添加As数据生成配置的标签";
            rename.EvenCapter += AddNewCapter;
            rename.ShowDialog();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            FormResName rename = new FormResName();
            rename.Text = "输入要修改的标签";
            rename.InitSetting(comboBoxCapterList.SelectedItem.ToString());
            rename.EvenCapter += ModifyCapter;
            rename.ShowDialog();
        }

        public void AddNewCapter(string newName)
        {
            
            CAsDataConfig newConfig=new CAsDataConfig();
            newConfig.caption = newName;
            dataConfigs.Add(newConfig);
            currentConfig ++;
            comBoxRefreshFlag = true;
            RefreshData();
            
        }

        public void ModifyCapter(string name)
        {
            dataConfigs[comboBoxCapterList.SelectedIndex].caption = name;
            comBoxRefreshFlag = true;
            RefreshData();
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该配置?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                dataConfigs.RemoveAt(comboBoxCapterList.SelectedIndex);
                currentConfig = 0;
                comBoxRefreshFlag = true;
                RefreshData();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }
        public void RefreshData()
        {
            if (dataConfigs!=null && currentConfig<dataConfigs.Count)
            {
                textBoxFolder.Text = dataConfigs[currentConfig].folder;
                textBoxPackage.Text = dataConfigs[currentConfig].package;
                textBoxBeanList.Text = "";
                if (dataConfigs[currentConfig].beanImport!=null)
                {
                    foreach (var bean in dataConfigs[currentConfig].beanImport)
                    {
                        textBoxBeanList.Text += bean + "";
                    }
                }
                textBoxContainerlist.Text = "";
                if (dataConfigs[currentConfig].containerImport!=null)
                {
                    foreach (var container in dataConfigs[currentConfig].containerImport)
                    {
                        textBoxContainerlist.Text += container + "";
                    }
                }
                if (comBoxRefreshFlag)
                {
                    comboBoxCapterList.Items.Clear();
                    for (int i = 0; i < dataConfigs.Count; i++)
                    {
                        comboBoxCapterList.Items.Add(dataConfigs[i].caption);
                    }
                    comBoxRefreshFlag = false;
                    comboBoxCapterList.SelectedIndex = currentConfig;
                    
                }
                
                if (dataConfigs[currentConfig].isSet == "true")
                {
                    checkBoxIsSet.Checked = true;
                }
                else
                {
                    checkBoxIsSet.Checked = false;
                }
            }
        }

        private void SetCurrentData()
        {
            //if (string.IsNullOrEmpty(dataConfigs[currentConfig].folder))
            {
                dataConfigs[currentConfig].folder = textBoxFolder.Text;
            }
            //if (string.IsNullOrEmpty(dataConfigs[currentConfig].package))
            {
                dataConfigs[currentConfig].package = textBoxPackage.Text;
            }
            string fullBean = textBoxBeanList.Text;
            string[] beans = fullBean.TrimEnd('\n','\r').Split('\n');
            dataConfigs[currentConfig].beanImport=new string[beans.Length];
            for (int i = 0; i < beans.Length; i++)
            {
                dataConfigs[currentConfig].beanImport[i] = beans[i].TrimEnd('\r');
            }
            string fullContain = textBoxContainerlist.Text;
            string[] contain = fullContain.TrimEnd('\n', '\r').Split('\n');
            dataConfigs[currentConfig].containerImport=new string[contain.Length];
            for (int i = 0; i < contain.Length; i++)
            {
                dataConfigs[currentConfig].containerImport[i] = contain[i].TrimEnd('\r');
            }
            //if (!string.IsNullOrEmpty(dataConfigs[currentConfig].isSet))
            {
                if (checkBoxIsSet.Checked)
                {
                    dataConfigs[currentConfig].isSet = "true";
                }
                else
                {
                    dataConfigs[currentConfig].isSet = "false";
                }
            }
        }

        private void SaveConfig()
        {
            SetCurrentData();
            for (int i = 0; i < dataConfigs.Count; i++)
            {
                if (string.IsNullOrEmpty(dataConfigs[i].folder))
                {
                    if (MessageBox.Show(dataConfigs[i].caption + "配置路径为空，请设置", "空路径", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        currentConfig = i;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (isAs)
            {
                XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\AsDataConfig.xml");
                XmlElement root = ConfigControl.GetXmlRootAsElement(doc, "AsDataGenerateConfig");

                XmlElement configelElement = root.SelectSingleNode("configs") as XmlElement;
                if (configelElement != null)
                {
                    configelElement.RemoveAll();
                    if (dataConfigs.Count > 0)
                    {
                        foreach (var config in dataConfigs)
                        {
                            XmlElement infoElement = doc.CreateElement("AsDataGenerateInfo");
                            config.WriteConfig(doc, infoElement);
                            configelElement.AppendChild(infoElement);
                        }
                    }
                }
                XmlElement lastIndex = root.SelectSingleNode("lastIndex") as XmlElement;
                if (lastIndex != null)
                {
                    lastIndex.InnerText = comboBoxCapterList.SelectedIndex.ToString();
                }
                doc.Save(@".\Config\AsDataConfig.xml");
            }
            else
            {
                XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\CsDataConfig.xml");
                XmlElement root = ConfigControl.GetXmlRootAsElement(doc, "CsDataGenerateConfig");

                XmlElement configelElement = root.SelectSingleNode("configs") as XmlElement;
                if (configelElement != null)
                {
                    configelElement.RemoveAll();
                    if (dataConfigs.Count > 0)
                    {
                        foreach (var config in dataConfigs)
                        {
                            XmlElement infoElement = doc.CreateElement("CsDataGenerateInfo");
                            config.WriteConfig(doc, infoElement);
                            configelElement.AppendChild(infoElement);
                        }
                    }
                }
                XmlElement lastIndex = root.SelectSingleNode("lastIndex") as XmlElement;
                if (lastIndex != null)
                {
                    lastIndex.InnerText = comboBoxCapterList.SelectedIndex.ToString();
                }
                doc.Save(@".\Config\CsDataConfig.xml");
            }
        }
        private void BtnFolderSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    dataConfigs[currentConfig].folder = folderName;
                    textBoxFolder.Text = folderName;
                }
            }

        }

        private void comboBoxCapterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentConfig = comboBoxCapterList.SelectedIndex;
            RefreshData();
        }
    }
}
