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
    public partial class FormBasicSetting : Form
    {
        private string resFolder="";
        public FormBasicSetting()
        {
            InitializeComponent();
            IntiBasicSetting();
        }

        private void IntiBasicSetting()
        {
            FilterSheetText.Text = Global.FilterSheets;
            StartLoadFoldercheckBox.Checked = Global.StartLoadFolder;
            LoadDataCheckBox.Checked = Global.LoadData;
            ResFolderText.Text = Global.ResFolder;
            IsDataBaseCheckBox.Checked = Global.IsDataBase;
            IsDisorderCheckBox.Checked = Global.IsDisorder;
            IsResEncCheckBox.Checked = Global.IsResEnc;
            SeedType type = Global.DisEncType;
            switch (type)
            { 
                case SeedType.Version:
                    SelectSeedType(VersionCheckBox);
                    break;
                case SeedType.CRC32:
                    SelectSeedType(CRC32CheckBox);
                    break;
                case SeedType.MD5:
                    SelectSeedType(MD5CheckBox);
                    break;
                case SeedType.SHA1:
                    SelectSeedType(SHA1CheckBox);
                    break;
                default:
                    break;
            }
        }

        private void SelectSeedType(CheckBox box)
        {
            if (box==VersionCheckBox)
            {
                VersionCheckBox.Checked = true;
            }
            else
            {
                VersionCheckBox.Checked = false;
            }
            if (box==MD5CheckBox)
            {
                MD5CheckBox.Checked = true;
            }
            else
            {
                MD5CheckBox.Checked = false;
            }
            if (box==SHA1CheckBox)
            {
                SHA1CheckBox.Checked = true;
            }
            else
            {
                SHA1CheckBox.Checked = false;
            }
            if (box==CRC32CheckBox)
            {
                CRC32CheckBox.Checked = true;
            }
            else
            {
                CRC32CheckBox.Checked = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Global.FilterSheets = FilterSheetText.Text;
            Global.StartLoadFolder = StartLoadFoldercheckBox.Checked;
            Global.LoadData = LoadDataCheckBox.Checked;
            Global.ResFolder = ResFolderText.Text;
            Global.IsDataBase = IsDataBaseCheckBox.Checked;
            Global.IsDisorder = IsDisorderCheckBox.Checked;
            Global.IsResEnc = IsResEncCheckBox.Checked;
            if (VersionCheckBox.Checked)
            {
                Global.DisEncType=SeedType.Version;
            }
            else if (CRC32CheckBox.Checked)
            {
                Global.DisEncType=SeedType.CRC32;
            }
            else if (MD5CheckBox.Checked)
            {
                Global.DisEncType=SeedType.MD5;
            }
            else if(SHA1CheckBox.Checked)
            {
                Global.DisEncType=SeedType.SHA1;
            }

            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\BasicConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "BasicConfig");
            XmlElement filterElement = ConfigControl.GetXmlElement(rootElement, "filterSheets");
            XmlNodeList list = filterElement.SelectNodes("string");
            foreach (XmlNode node in list )
            {
                filterElement.RemoveChild(node);
            }
            if (Global.FilterSheets!="")
            {
                string[] splites = Global.FilterSheets.Split(',');
                foreach (var sp in splites)
                {
                    if (sp!="")
                    {
                        XmlElement element = doc.CreateElement("string");
                        element.InnerText = sp;
                        filterElement.AppendChild(element);
                    }
                }
            }
            ConfigControl.SetXmlelementInnerText(rootElement, "startLoadFolder",Global.StartLoadFolder,doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "loadData", Global.LoadData, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "resFolder", Global.ResFolder, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "isDatabase", Global.IsDataBase, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "isDisorder", Global.IsDisorder, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "isResEnc", Global.IsResEnc, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "resFolder", Global.ResFolder, doc);
            switch (Global.DisEncType)
            {
                case SeedType.Version:
                    ConfigControl.SetXmlelementInnerText(rootElement, "disEncType", "Version", doc);
                    break;
                case SeedType.CRC32:
                    ConfigControl.SetXmlelementInnerText(rootElement, "disEncType", "CRC32", doc);
                    break;
                case SeedType.MD5:
                    ConfigControl.SetXmlelementInnerText(rootElement, "disEncType", "MD5", doc);
                    break;
                case SeedType.SHA1:
                    ConfigControl.SetXmlelementInnerText(rootElement, "disEncType", "SHA1", doc);
                    break;
                default:
                    break;
            }

            doc.Save(@".\Config\BasicConfig.xml");
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择资源导出的文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.SelectedPath = Global.ResFolder;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    //resFolder = folderName;
                    ResFolderText.Text = folderName;
                }
            }

        }
    }
}
