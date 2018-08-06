namespace GameTools
{
    partial class FormAsRes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsRes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnFolderSelect = new System.Windows.Forms.Button();
            this.textBoxContainerlist = new System.Windows.Forms.TextBox();
            this.textBoxBeanList = new System.Windows.Forms.TextBox();
            this.textBoxPackage = new System.Windows.Forms.TextBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsSet = new System.Windows.Forms.CheckBox();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.comboBoxCapterList = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxLoad = new System.Windows.Forms.CheckBox();
            this.checkBoxContainer = new System.Windows.Forms.CheckBox();
            this.checkBoxBean = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnFolderSelect);
            this.groupBox1.Controls.Add(this.textBoxContainerlist);
            this.groupBox1.Controls.Add(this.textBoxBeanList);
            this.groupBox1.Controls.Add(this.textBoxPackage);
            this.groupBox1.Controls.Add(this.textBoxFolder);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "默认配置 配置基本信息";
            // 
            // BtnFolderSelect
            // 
            this.BtnFolderSelect.Location = new System.Drawing.Point(388, 26);
            this.BtnFolderSelect.Name = "BtnFolderSelect";
            this.BtnFolderSelect.Size = new System.Drawing.Size(38, 23);
            this.BtnFolderSelect.TabIndex = 8;
            this.BtnFolderSelect.Text = "+";
            this.BtnFolderSelect.UseVisualStyleBackColor = true;
            this.BtnFolderSelect.Click += new System.EventHandler(this.BtnFolderSelect_Click);
            // 
            // textBoxContainerlist
            // 
            this.textBoxContainerlist.Location = new System.Drawing.Point(155, 153);
            this.textBoxContainerlist.Multiline = true;
            this.textBoxContainerlist.Name = "textBoxContainerlist";
            this.textBoxContainerlist.Size = new System.Drawing.Size(271, 61);
            this.textBoxContainerlist.TabIndex = 7;
            // 
            // textBoxBeanList
            // 
            this.textBoxBeanList.Location = new System.Drawing.Point(155, 85);
            this.textBoxBeanList.Multiline = true;
            this.textBoxBeanList.Name = "textBoxBeanList";
            this.textBoxBeanList.Size = new System.Drawing.Size(271, 62);
            this.textBoxBeanList.TabIndex = 6;
            // 
            // textBoxPackage
            // 
            this.textBoxPackage.Location = new System.Drawing.Point(155, 52);
            this.textBoxPackage.Name = "textBoxPackage";
            this.textBoxPackage.Size = new System.Drawing.Size(271, 21);
            this.textBoxPackage.TabIndex = 5;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(155, 28);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(227, 21);
            this.textBoxFolder.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Container Import list：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "bean Import List：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "As包：";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "As Src目录：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxIsSet);
            this.groupBox2.Controls.Add(this.BtnDel);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.comboBoxCapterList);
            this.groupBox2.Controls.Add(this.BtnAdd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置信息";
            // 
            // checkBoxIsSet
            // 
            this.checkBoxIsSet.AutoSize = true;
            this.checkBoxIsSet.Location = new System.Drawing.Point(155, 56);
            this.checkBoxIsSet.Name = "checkBoxIsSet";
            this.checkBoxIsSet.Size = new System.Drawing.Size(114, 16);
            this.checkBoxIsSet.TabIndex = 5;
            this.checkBoxIsSet.Text = "Bean是否生成Set";
            this.checkBoxIsSet.UseVisualStyleBackColor = true;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(394, 26);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(32, 23);
            this.BtnDel.TabIndex = 4;
            this.BtnDel.Text = "删";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.Location = new System.Drawing.Point(350, 26);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(32, 23);
            this.BtnModify.TabIndex = 3;
            this.BtnModify.Text = "改";
            this.BtnModify.UseVisualStyleBackColor = true;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // comboBoxCapterList
            // 
            this.comboBoxCapterList.FormattingEnabled = true;
            this.comboBoxCapterList.Location = new System.Drawing.Point(155, 29);
            this.comboBoxCapterList.Name = "comboBoxCapterList";
            this.comboBoxCapterList.Size = new System.Drawing.Size(147, 20);
            this.comboBoxCapterList.TabIndex = 2;
            this.comboBoxCapterList.SelectedIndexChanged += new System.EventHandler(this.comboBoxCapterList_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(308, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(32, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "配置列表：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxLoad);
            this.groupBox3.Controls.Add(this.checkBoxContainer);
            this.groupBox3.Controls.Add(this.checkBoxBean);
            this.groupBox3.Location = new System.Drawing.Point(13, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成选项";
            // 
            // checkBoxLoad
            // 
            this.checkBoxLoad.AutoSize = true;
            this.checkBoxLoad.Checked = true;
            this.checkBoxLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLoad.Location = new System.Drawing.Point(304, 20);
            this.checkBoxLoad.Name = "checkBoxLoad";
            this.checkBoxLoad.Size = new System.Drawing.Size(72, 16);
            this.checkBoxLoad.TabIndex = 2;
            this.checkBoxLoad.Text = "加载代码";
            this.checkBoxLoad.UseVisualStyleBackColor = true;
            // 
            // checkBoxContainer
            // 
            this.checkBoxContainer.AutoSize = true;
            this.checkBoxContainer.Checked = true;
            this.checkBoxContainer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxContainer.Location = new System.Drawing.Point(180, 20);
            this.checkBoxContainer.Name = "checkBoxContainer";
            this.checkBoxContainer.Size = new System.Drawing.Size(78, 16);
            this.checkBoxContainer.TabIndex = 1;
            this.checkBoxContainer.Text = "Container";
            this.checkBoxContainer.UseVisualStyleBackColor = true;
            // 
            // checkBoxBean
            // 
            this.checkBoxBean.AutoSize = true;
            this.checkBoxBean.Checked = true;
            this.checkBoxBean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBean.Location = new System.Drawing.Point(74, 21);
            this.checkBoxBean.Name = "checkBoxBean";
            this.checkBoxBean.Size = new System.Drawing.Size(48, 16);
            this.checkBoxBean.TabIndex = 0;
            this.checkBoxBean.Text = "Bean";
            this.checkBoxBean.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(168, 411);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "保存设置";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(290, 410);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(75, 23);
            this.BtnCreate.TabIndex = 4;
            this.BtnCreate.Text = "生成";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(376, 409);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FormAsRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 444);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAsRes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "根据默认配置 配置生成相关文件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Button BtnFolderSelect;
        protected System.Windows.Forms.TextBox textBoxContainerlist;
        protected System.Windows.Forms.TextBox textBoxBeanList;
        protected System.Windows.Forms.TextBox textBoxPackage;
        protected System.Windows.Forms.TextBox textBoxFolder;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Button BtnAdd;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Button BtnModify;
        protected System.Windows.Forms.ComboBox comboBoxCapterList;
        protected System.Windows.Forms.Button BtnDel;
        protected System.Windows.Forms.CheckBox checkBoxIsSet;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.CheckBox checkBoxContainer;
        protected System.Windows.Forms.CheckBox checkBoxBean;
        protected System.Windows.Forms.Button BtnSave;
        protected System.Windows.Forms.Button BtnCreate;
        protected System.Windows.Forms.Button BtnCancel;
        protected System.Windows.Forms.CheckBox checkBoxLoad;
    }
}