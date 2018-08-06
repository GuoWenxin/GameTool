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

namespace GameTools
{
    public partial class FormResDecode : Form
    {
        private bool IsSingleFile;

        private bool isDialogChange
        {
            set
            {
                if (value)
                {
                    BtnSave.Enabled = true;
                }
                else
                {
                    BtnSave.Enabled = false;
                }
            }
        }

        private string _strDellAddr;

        private string strDelladdr
        {
            set
            {
                if (value!=_strDellAddr)
                {
                    isDialogChange = true;
                    _strDellAddr = value;
                    TBDellAddr.Text = value;
                }
            }
            get { return _strDellAddr; }
        }

        private string _strResAddr;

        private string strResAddr
        {
            set
            {
                if (value!=_strResAddr)
                {
                    isDialogChange = true;
                    _strResAddr = value;
                    TBResAddr.Text = value;
                }
            }
            get { return _strResAddr; }
        }

        private string _strExcelAddr;

        private string strExcelAddr
        {
            set
            {
                if (value!=_strExcelAddr)
                {
                    isDialogChange = true;
                    _strExcelAddr = value;
                    TBExcelAddr.Text = value;
                }
            }
            get { return _strExcelAddr; }
        }

        private const string RES_DECODE_DELL_ADDR = "RES_DECODE_DELL_ADDR";
        private const string RES_DECODE_RES_SINGLE_ADDR = "RES_DECODE_RES_SINGLE_ADDR";
        private const string RES_DECODE_EXCEL_ADDR = "RES_DECODE_EXCEL_ADDR";
        private const string RES_DECODE_RES_FOLDER_ADDR = "RES_DECODE_RES_FOLDER_ADDR";
        public FormResDecode()
        {
            InitializeComponent();
        }

        public void InitDialog(bool isFile)
        {
            IsSingleFile = isFile;
            if (IsSingleFile)
            {
                LabResShow.Text = "选择Res资源文件地址:";
                strResAddr = PlayerPref.GetData(RES_DECODE_RES_SINGLE_ADDR);
            }
            else
            {
                LabResShow.Text = "选择Res资源文件夹地址:";
                strResAddr = PlayerPref.GetData(RES_DECODE_RES_FOLDER_ADDR);
            }
            isDialogChange = false;
            strDelladdr = PlayerPref.GetData(RES_DECODE_DELL_ADDR);
            strExcelAddr = PlayerPref.GetData(RES_DECODE_EXCEL_ADDR);
        }

        private void BtnDellAddrSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择DLL文件";

            if (!string.IsNullOrEmpty(strDelladdr))
            {
                fileDialog.FileName = strDelladdr;
            }

            fileDialog.Filter = "DLL文件(*.dll)|*.dll";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                strDelladdr = fileDialog.FileName;
            }
        }

        private void BtnResAddrSelect_Click(object sender, EventArgs e)
        {
            if (!IsSingleFile)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                folderBrowserDialog1.Description = "请选择Res文件夹路径";
                folderBrowserDialog1.ShowNewFolderButton = false;
                if (!string.IsNullOrEmpty(strResAddr))
                {
                    folderBrowserDialog1.SelectedPath = strResAddr;
                }
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    strResAddr = folderBrowserDialog1.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Title = "请选择Res文件";

                if (!string.IsNullOrEmpty(strResAddr))
                {
                    fileDialog.FileName = strResAddr;
                }

                fileDialog.Filter = "Res文件(*.res)|*.res";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    strResAddr = fileDialog.FileName;
                }
            }
        }

        private void BtnExcelAddrSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择Excel文件夹路径";
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (!string.IsNullOrEmpty(strExcelAddr))
            {
                folderBrowserDialog1.SelectedPath = strExcelAddr;
            }
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                strExcelAddr = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            PlayerPref.SetData(RES_DECODE_DELL_ADDR, strDelladdr);
            PlayerPref.SetData(RES_DECODE_EXCEL_ADDR, strExcelAddr);
            if (IsSingleFile)
            {
                PlayerPref.SetData(RES_DECODE_RES_SINGLE_ADDR, strResAddr);
            }
            else
            {
                PlayerPref.SetData(RES_DECODE_RES_FOLDER_ADDR, strResAddr);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnInvoke_Click(object sender, EventArgs e)
        {
            if (BtnSave.Enabled)
            {
                Save();
                BtnSave.Enabled = false;
            }
            if (string.IsNullOrEmpty(strExcelAddr))
            {
                MessageBox.Show("请输入生成Excel的路径!");
                return;
            }
            if (string.IsNullOrEmpty(strResAddr))
            {
                if (IsSingleFile)
                {
                    MessageBox.Show("请选择res文件!");
                    return;
                }
                else
                {
                    MessageBox.Show("请输入res文件夹的路径!");
                    return;
                }
            }
            if (string.IsNullOrEmpty(strDelladdr))
            {
                MessageBox.Show("请选择dll文件!");
                return;
            }
            Close();
            Thread.Sleep(200);
            Thread thread = new Thread(CreateFile);
            thread.Start();
        }

        private void CreateFile()
        {
            CResHelper.Instance.ResDecode(strDelladdr, strResAddr, strExcelAddr, IsSingleFile);
        }
    }
}
