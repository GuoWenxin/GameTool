using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTools.Forms
{
    public partial class FormVersionSetting : Form
    {
        private bool IsFolder = true;

        private string VersionFolderInput = "VersionFolder_Input";
        private string VersionFolderOutput = "VersionFolder_Output";
        private string VersionSingleOutput = "VersionSingle_Output";
        private string VersionSingleInput = "VersionSingle_Input";
        private string VersionBigVersionNum = "VersionBigVersionNum";
        private string VersionType = "VersionType";
        private string VersionFileSizeUnit = "VersionFileSizeUnit";
        private string VersionIgnorePostFix = "VersionIgnorePostFix";
        private string InputPath;
        private string OutPutPath;
        private string BigVersionNum;
        private string VerType;
        private string SizeUnit;
        private string IgnoorePostFix;
        public FormVersionSetting(bool isfolder)
        {
            InitializeComponent();
            IsFolder = isfolder;
            Init();
        }

        private void Init()
        {
            if (IsFolder)
            {
                labelInput.Text = "资源文件夹路径:";
                InputPath = PlayerPref.GetData(VersionFolderInput);
                OutPutPath= PlayerPref.GetData(VersionFolderOutput); 
            }
            else
            {
                labelInput.Text = "资源文件路径:";
                InputPath = PlayerPref.GetData(VersionSingleInput);
                OutPutPath = PlayerPref.GetData(VersionSingleOutput);
            }
            BigVersionNum= PlayerPref.GetData(VersionBigVersionNum);
            VerType= PlayerPref.GetData(VersionType);
            IgnoorePostFix = PlayerPref.GetData(VersionIgnorePostFix);
            textBoxInput.Text = InputPath;
            textBoxOutPut.Text = OutPutPath;
            textBoxBigVersionNum.Text = BigVersionNum;
            textBoxIgnoreFileName.Text = IgnoorePostFix;
            switch (VerType)
            {
                case "Num":
                    radioButtonNum.Checked = true;
                    break;
                default:
                    radioButtonMd5.Checked = true;
                    break;
            }
            SizeUnit= PlayerPref.GetData(VersionFileSizeUnit,"B");
            for(int i=0;i<cbUnit.Items.Count;i++)
            {
                if (cbUnit.Items[i].ToString()== SizeUnit)
                {
                    cbUnit.SelectedIndex = i;
                    break;
                }
            }
            buttonSave.Enabled = false;
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            InputPath = textBoxInput.Text;
        }

        private void textBoxOutPut_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            OutPutPath = textBoxOutPut.Text;
        }

        private void textBoxBigVersionNum_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            BigVersionNum = textBoxBigVersionNum.Text;
        }

        private void textBoxIgnoreFileName_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            IgnoorePostFix =textBoxIgnoreFileName.Text;
        }
        private void radioButtonNum_CheckedChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            RadioButton rb = (RadioButton) sender;
            if (rb==radioButtonNum)
            {
                VerType = "Num";
            }
        }

        private void radioButtonMd5_CheckedChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = true;
            buttonSave.Enabled = true;
            RadioButton rb = (RadioButton)sender;
            if (rb == radioButtonMd5)
            {
                VerType = "MD5";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            if (buttonSave.Enabled)
            {
                if (IsFolder)
                {
                    PlayerPref.SetData(VersionFolderInput,InputPath);
                    PlayerPref.SetData(VersionFolderOutput,OutPutPath);
                }
                else
                {
                    PlayerPref.SetData(VersionSingleInput, InputPath);
                    PlayerPref.SetData(VersionSingleOutput, OutPutPath);
                }
                PlayerPref.SetData(VersionBigVersionNum,BigVersionNum);
                PlayerPref.SetData(VersionIgnorePostFix,IgnoorePostFix);
                PlayerPref.SetData(VersionType,VerType);
                PlayerPref.SetData(VersionFileSizeUnit, SizeUnit);
                buttonSave.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInSelect_Click(object sender, EventArgs e)
        {
            if (IsFolder)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "请选择文件夹路径";
                folderBrowserDialog1.ShowNewFolderButton = false;
                folderBrowserDialog1.SelectedPath = InputPath;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;
                    if (folderName != "")
                    {
                        textBoxInput.Text = folderName;
                    }
                }
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择文件";
                fileDialog.FileName = PlayerPref.GetData("Md5VersionSingle_Input");
                fileDialog.Filter = "所有 文件(*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxInput.Text = fileDialog.FileName;
                }
            }
        }

        private void buttonOutSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择生成的文件路径";
            folderBrowserDialog1.SelectedPath = PlayerPref.GetData("Md5VersionSingle_Output");
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    textBoxOutPut.Text = folderName;
                }
            }
        }

        private void buttonSure_Click(object sender, EventArgs e)
        {
            SaveConfig();
            Close();
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread.Sleep(200);
            Thread thread= new Thread(CreateFile);
            thread.Start();
        }

        private void CreateFile()
        {
            CVersionMd5.Instance.CreateVersionByMd5(InputPath, OutPutPath, BigVersionNum,IgnoorePostFix,SizeUnit, !IsFolder);
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox) sender;
            SizeUnit = cb.Text;
            buttonSave.Enabled = true;
        }

    }
}
