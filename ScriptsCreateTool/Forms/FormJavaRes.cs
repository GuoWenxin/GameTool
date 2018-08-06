using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GameTools
{

    public partial class FormJavaRes : Form
    {
        private List<CJavaDataConfig> dataConfigs = new List<CJavaDataConfig>();

        private CheckedListBox dataList;
        private List<ExcelData> dataExcels;
        
        private int currentConfig = 0;

        private bool comBonRefreshFlag=false;
        public FormJavaRes()
        {
            InitializeComponent();
        }

        public void InitSetting(CheckedListBox listbox, List<ExcelData> sheets)
        {
            dataList = listbox;
            dataExcels = sheets;
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\JavaDataConfig.xml");
            XmlElement root = ConfigControl.GetXmlRootAsElement(doc, "JavaDataGenerateConfig");

            XmlElement config = root.SelectSingleNode("configs") as XmlElement;
            if (config != null)
            {
                XmlNodeList configList = config.SelectNodes("JavaDataGenerateInfo");
                if (configList.Count > 0)
                {
                    for (int i = 0; i < configList.Count; i++)
                    {

                        CJavaDataConfig dataConfig = new CJavaDataConfig();
                        dataConfig.LoadConfig((XmlElement)configList[i]);
                        dataConfigs.Add(dataConfig);
                    }
                }
            }
            int index = Convert.ToInt32(ConfigControl.GetXmlElementInnerText(root, "lastIndex"));
            currentConfig = index;
            //comboBoxConfigList.Items.Clear();
            //for (int i = 0; i < dataConfigs.Count; i++)
            //{
            //    comboBoxConfigList.Items.Add(dataConfigs[i].caption);
            //}
            comBonRefreshFlag = true;
            RefreshData();
            comboBoxConfigList.SelectedIndex = index;
        }
        public void RefreshData()
        {
            if (dataConfigs != null && currentConfig < dataConfigs.Count)
            {
                textBoxSrcFolder.Text = dataConfigs[currentConfig].folder;
                textBoxJavaPackage.Text = dataConfigs[currentConfig].package;
                textBoxDataConfigFile.Text = dataConfigs[currentConfig].dbConfigFile;
                textBoxBaseDao.Text = dataConfigs[currentConfig].baseDao;
                textBoxDatamanager.Text = dataConfigs[currentConfig].manager;
                if (comBonRefreshFlag)
                {
                    comboBoxConfigList.Items.Clear();
                    for (int i = 0; i < dataConfigs.Count; i++)
                    {
                        comboBoxConfigList.Items.Add(dataConfigs[i].caption);
                    }
                    comBonRefreshFlag = false;
                    comboBoxConfigList.SelectedIndex = currentConfig;
                }
                textBoxDBAddress.Text = dataConfigs[currentConfig].dbIp;
                numericUpDownDBPort.Text = dataConfigs[currentConfig].dbport;
                textBoxDBName.Text = dataConfigs[currentConfig].dbName;
                textBoxUserName.Text = dataConfigs[currentConfig].dbUser;
                textBoxUserPsw.Text = dataConfigs[currentConfig].dbPsw;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

            CheckedListBox.CheckedItemCollection collection = dataList.CheckedItems;
            foreach (var item in collection)
            {
                string name = item.ToString();
                for (int i = 0; i < dataExcels.Count; i++)
                {
                    if (name == dataExcels[i].SheetShowName)
                    {
                        if (checkBoxBean.Checked)
                        {
                            CJavaHandleFuns.Instance.CreateJavaResBean(dataExcels[i],
                                dataConfigs[comboBoxConfigList.SelectedIndex]);
                        }
                        if (checkBoxDao.Checked)
                        {
                            CJavaHandleFuns.Instance.CreateJavaResDao(dataExcels[i],
                                dataConfigs[comboBoxConfigList.SelectedIndex]);
                        }
                        if (checkBoxContainer.Checked)
                        {
                            CJavaHandleFuns.Instance.CreateJavaResContainer(dataExcels[i],
                                dataConfigs[comboBoxConfigList.SelectedIndex]);
                        }
                        CJavaHandleFuns.Instance.CreateJavaResMapSql(dataExcels[i],
                            dataConfigs[comboBoxConfigList.SelectedIndex]);
                        CJavaHandleFuns.Instance.CreateJavaResDataConfig(dataExcels[i],
                            dataConfigs[comboBoxConfigList.SelectedIndex]);
                        CJavaHandleFuns.Instance.CreateJavaResDataManager(dataExcels[i],
                            dataConfigs[comboBoxConfigList.SelectedIndex]);
                        break;
                    }
                }
            }
            System.Diagnostics.Process.Start("Explorer.exe", dataConfigs[0].folder);
            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
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
                    textBoxSrcFolder.Text = folderName;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormResName rename = new FormResName();
            rename.Text = "添加As数据生成配置的标签";
            rename.EvenCapter += AddNewCapter;
            rename.ShowDialog();
        }

        private void AddNewCapter(string name)
        {
            SetCurrentData();
            CJavaDataConfig newConfig = new CJavaDataConfig();
            newConfig.caption = name;
            dataConfigs.Add(newConfig);
            currentConfig++;
            comBonRefreshFlag = true;
            RefreshData();
            //comboBoxConfigList.SelectedIndex = currentConfig;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FormResName rename = new FormResName();
            rename.Text = "输入要修改的标签";
            rename.InitSetting(comboBoxConfigList.SelectedItem.ToString());
            rename.EvenCapter += ModifyCapter;
            rename.ShowDialog();
        }

        private void ModifyCapter(string newName)
        {
            dataConfigs[comboBoxConfigList.SelectedIndex].caption = newName;
            comBonRefreshFlag = true;
            RefreshData();
            //comboBoxConfigList.SelectedIndex = currentConfig;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除该配置?", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dataConfigs.RemoveAt(comboBoxConfigList.SelectedIndex);
                currentConfig = 0;
                comBonRefreshFlag = true;
                RefreshData();
                //comboBoxConfigList.SelectedIndex = currentConfig;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\JavaDataConfig.xml");
            XmlElement root = ConfigControl.GetXmlRootAsElement(doc, "JavaDataGenerateConfig");

            XmlElement configelElement = root.SelectSingleNode("configs") as XmlElement;
            if (configelElement != null)
            {
                configelElement.RemoveAll();
                if (dataConfigs.Count > 0)
                {
                    foreach (var config in dataConfigs)
                    {
                        XmlElement infoElement = doc.CreateElement("JavaDataGenerateInfo");
                        config.WriteConfig(doc, infoElement);
                        configelElement.AppendChild(infoElement);
                    }
                }
            }
            XmlElement lastIndex = root.SelectSingleNode("lastIndex") as XmlElement;
            if (lastIndex != null)
            {
                lastIndex.InnerText = comboBoxConfigList.SelectedIndex.ToString();
            }
            doc.Save(@".\Config\JavaDataConfig.xml");
        }
        private void SetCurrentData()
        {
            //if (string.IsNullOrEmpty(dataConfigs[currentConfig].folder))
            {
                dataConfigs[currentConfig].folder = textBoxSrcFolder.Text;
            }
            //if (string.IsNullOrEmpty(dataConfigs[currentConfig].package))
            {
                dataConfigs[currentConfig].package = textBoxJavaPackage.Text;
            }
            dataConfigs[currentConfig].dbConfigFile = textBoxDataConfigFile.Text;
            dataConfigs[currentConfig].baseDao = textBoxBaseDao.Text;
            dataConfigs[currentConfig].package = textBoxJavaPackage.Text;
            dataConfigs[currentConfig].manager = textBoxDatamanager.Text;
            dataConfigs[currentConfig].dbIp = textBoxDBAddress.Text;
            dataConfigs[currentConfig].dbport = numericUpDownDBPort.Text;
            dataConfigs[currentConfig].dbName = textBoxDBName.Text;
            dataConfigs[currentConfig].dbUser = textBoxUserName.Text;
            dataConfigs[currentConfig].dbPsw = textBoxUserPsw.Text;
        }

        private void comboBoxConfigList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentConfig = comboBoxConfigList.SelectedIndex;
            RefreshData();
            //comboBoxConfigList.SelectedIndex =currentConfig ;
        }
    }
}
