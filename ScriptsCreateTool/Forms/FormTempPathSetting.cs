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
    public partial class FormTempPathSetting : Form
    {
        private string CsTempFilePath;
        private string typeFilePath;

        public FormTempPathSetting()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            CsTemplateText.Text = Global.CsTemplate;
            TypeTextBox.Text = Global.TypeBankFile;
        }

        private void CsTempSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择CS模板文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CsTempFilePath = file;
                CsTemplateText.Text = file;
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( CsTempFilePath))
            {
                Global.CsTemplate = CsTempFilePath;
            }
            if (!string.IsNullOrEmpty(typeFilePath))
            {
                Global.TypeBankFile = typeFilePath;
            }
            XmlDocument doc = ConfigControl.GetXmlDocument(@".\Config\BasicConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "BasicConfig");
            ConfigControl.SetXmlelementInnerText(rootElement, "csTemplate", CsTempFilePath, doc);
            ConfigControl.SetXmlelementInnerText(rootElement, "typeBankFile", typeFilePath, doc);
            doc.Save(@".\Config\BasicConfig.xml");

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TypeSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                typeFilePath = fileDialog.FileName;
                TypeTextBox.Text = typeFilePath;
            }
        }
    }
}
