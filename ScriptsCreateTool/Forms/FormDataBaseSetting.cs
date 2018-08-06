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
    public enum DBOpeType
    {
        ADD,
        Modify
    }
    public partial class FormDataBaseSetting : Form
    {
        private  DBOpeType dbOpeType=DBOpeType.ADD;
        private XmlDocument dbDoc;
        private string path;
        private XmlElement parentElement;
        private List<CDataBaseInfo> dbList ;
        private ComboBox combox;
        private XmlElement dataBaseElement;
        private CDataBaseInfo database;
        public FormDataBaseSetting()
        {
            InitializeComponent();
            comboBoxSQLType.SelectedIndex = 0;
        }
        public void InitAddDataBase(XmlDocument doc,string path, XmlElement parent,ref List<CDataBaseInfo>databaseList,ComboBox box )
        {
            dbOpeType = DBOpeType.ADD;
            dbDoc = doc;
            parentElement = parent;
            dbList = databaseList;
            this.path = path;
            combox = box;
        }
        public void InitModifyDataBase(XmlDocument doc, string path, XmlElement dbElement,CDataBaseInfo dainfo, ComboBox box)
        {
            dbOpeType=DBOpeType.Modify;
            dbDoc = doc;
            this.path = path;
            dataBaseElement = dbElement;
            database = dainfo;
            combox = box;
            textBoxAddress.Text = database.address;
            textBoxDataBaseName.Text = database.databaseName;
            textBoxPassword.Text = database.password;
            textBoxPort.Text = database.port;
            textBoxTitle.Text = database.title;
            textBoxUserName.Text = database.userName;
            textBoxVerTableName.Text = database.versionTableName;
            textBoxVerTableField.Text = database.versionTableField;
            textBoxVerValue.Text = database.versionValueField;
            textBoxVerDesc.Text = database.versionDescField;
            tbLocalPosition.Text = database.localPositionPath;
            for (int i = 0; i < combox.Items.Count; i++)
            {
                if (combox.Items[i].ToString()==database.dbType)
                {
                    combox.SelectedIndex = i;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool resault = true;
            if (dbOpeType==DBOpeType.ADD)
            {
                resault= AddDataBaseToConfig(dbDoc,parentElement);
            }
            else
            {
                resault= ModifyDataBaseInConfig(dbDoc,path, dataBaseElement);
                FormMain.Instance.RefreshDatabaseComBox();
            }
            if (resault)
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AddDataBaseToConfig(XmlDocument doc, XmlElement parent)
        {
            if (!Directory.Exists(tbLocalPosition.Text))
            {
                MessageBox.Show(string.Format("{0}路径文件夹不存在", tbLocalPosition.Text), "无效文件夹", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            CDataBaseInfo dbInfo=new CDataBaseInfo();
            dbInfo.title = textBoxTitle.Text;
            dbInfo.address = textBoxAddress.Text;
            dbInfo.databaseName = textBoxDataBaseName.Text;
            dbInfo.dbType = comboBoxSQLType.SelectedItem.ToString();
            dbInfo.password = textBoxPassword.Text;
            dbInfo.port = textBoxPort.Text;
            dbInfo.userName = textBoxUserName.Text;
            dbInfo.versionTableName = textBoxVerTableName.Text;
            dbInfo.versionTableField = textBoxVerTableField.Text;
            dbInfo.versionValueField = textBoxVerValue.Text;
            dbInfo.versionDescField = textBoxVerDesc.Text;
            dbInfo.localPositionPath = tbLocalPosition.Text;
            dbInfo.AddToConfig(doc,path,parent);
            dbList.Add(dbInfo);
            combox.Items.Add(dbInfo.title);
            combox.SelectedIndex = combox.Items.Count - 1;
            return true;
        }

        private bool ModifyDataBaseInConfig(XmlDocument doc,string path, XmlElement node)
        {
            if (!Directory.Exists(tbLocalPosition.Text))
            {
                MessageBox.Show(string.Format("{0}路径文件夹不存在", tbLocalPosition.Text), "无效文件夹", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            database.title = textBoxTitle.Text;
            database.address = textBoxAddress.Text;
            database.databaseName = textBoxDataBaseName.Text;
            database.dbType = comboBoxSQLType.SelectedItem.ToString();
            database.password = textBoxPassword.Text;
            database.port = textBoxPort.Text;
            database.userName = textBoxUserName.Text;
            database.versionTableName = textBoxVerTableName.Text;
            database.versionTableField = textBoxVerTableField.Text;
            database.versionValueField = textBoxVerValue.Text;
            database.versionDescField = textBoxVerDesc.Text;
            database.localPositionPath = tbLocalPosition.Text;
            database.ModifyNodeInConfig(doc,path,node);
            return true;

        }

        private void btnSelectLocalPos_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择关联的本地文件夹";
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    tbLocalPosition.Text = folderName;
                }
            }
        }
    }
}
