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
    public partial class FormPathSelect : Form
    {
        private LinkLabel linkLabel1;
        private XmlDocument doc;
        private XmlElement folderElement;
        private string path;
        public event Action<TextBox> OnInit; 
        public event Action<TextBox> OnClickSelectBtn;
        public event Action<TextBox> OnClickOkBtn; 
        public FormPathSelect()
        {
            InitializeComponent();
            
        }

        public void Init(LinkLabel linkLabel)
        {
            linkLabel1 = linkLabel;
            doc = ConfigControl.GetXmlDocument(@".\Config\BasicConfig.xml");
            XmlElement rootElement = ConfigControl.GetXmlRootAsElement(doc, "BasicConfig");
            folderElement = ConfigControl.GetXmlElement(rootElement, "folder");
            path = folderElement.InnerText;
            textBoxPath.Text = path;
        }

        public void Init()
        {
            if (OnInit != null)
            {
                OnInit(textBoxPath);

            }
        }
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (OnClickSelectBtn!=null)
            {
                OnClickSelectBtn(textBoxPath);
                
            }
            //FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            //folderBrowserDialog1.Description = "请选择Excel数值文件的文件夹";
            //folderBrowserDialog1.ShowNewFolderButton = false;
            //folderBrowserDialog1.SelectedPath = folderElement.InnerText;
            //DialogResult result = folderBrowserDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string folderName = folderBrowserDialog1.SelectedPath;
            //    if (folderName != "")
            //    {
            //        path = folderName;
            //        textBoxPath.Text = path;
            //    }
            //}
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            if (OnClickOkBtn!=null)
            {
                OnClickOkBtn(textBoxPath);
                OnClickSelectBtn = null;
                OnClickOkBtn = null;
                OnInit = null;
            }
            //if (folderElement != null && textBoxPath.Text != null)
            //{
            //    path = textBoxPath.Text;
            //    folderElement.InnerText = path;
            //    doc.Save(@".\Config\BasicConfig.xml");
            //    Global.Folder = path;
            //    linkLabel1.Text = path;
            //}
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetInstruction(string instruction)
        {
            Instruction.Text = instruction;
        }

        public void SetPath(string path)
        {
            textBoxPath.Text = path;
        }

        public string GetPath()
        {
            return textBoxPath.Text;
        }
    }
}
