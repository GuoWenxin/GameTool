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
    public partial class FormCSMessageConfig : Form
    {
        private string[] filepaths;
        private string savepath;
        private XmlDocument doc;
        private XmlElement outPathElement;
        private string outPath;
        public FormCSMessageConfig()
        {
            InitializeComponent();
        }

        public void Init(string[] xmlPath)
        {
            filepaths = xmlPath;
            doc =ConfigControl.GetXmlDocument(@".\Config\MessageConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "MessageConfig");
            XmlElement csElement = ConfigControl.GetXmlElement(rootElement, "CS");
            outPathElement = ConfigControl.GetXmlElement(csElement, "OutPath");
            outPath = outPathElement.InnerText;
            textBoxPath.Text = outPath;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (btnSave.Enabled)
            {
                SaveConfig();
            }
            Close();
            foreach (string file in filepaths)
            {
                if (file.Substring(file.Length-4)==".xml")
                {
                    Global.CsMessageFilePath = file;
                    Global.CsMessages = ConfigControl.ReadMessageXml(Global.CsMessageFilePath);
                    Debug.Log("配置表读取成功");
                    CCSHandleFuns.CreateCSMessage(checkBoxbean.Checked,checkBoxmessage.Checked,checkBoxhandler.Checked,checkBoxCservice.Checked,checkBoxMessagePool.Checked,outPath);
                }

            }
            System.Diagnostics.Process.Start("Explorer.exe", outPath);
        }

        private void btnSelect_Click(object sender, EventArgs e)
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
                    outPath = folderName;
                    textBoxPath.Text = outPath;
                }
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            outPath = textBoxPath.Text;
            outPathElement.InnerText = outPath;
            doc.Save(@".\Config\MessageConfig.xml");
            btnSave.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
