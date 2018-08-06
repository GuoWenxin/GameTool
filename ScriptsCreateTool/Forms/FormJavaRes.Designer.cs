namespace GameTools
{
    partial class FormJavaRes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJavaRes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSelectFolder = new System.Windows.Forms.Button();
            this.textBoxBaseDao = new System.Windows.Forms.TextBox();
            this.textBoxDatamanager = new System.Windows.Forms.TextBox();
            this.textBoxJavaPackage = new System.Windows.Forms.TextBox();
            this.textBoxDataConfigFile = new System.Windows.Forms.TextBox();
            this.textBoxSrcFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownDBPort = new System.Windows.Forms.NumericUpDown();
            this.textBoxUserPsw = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.textBoxDBAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDel = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.comboBoxConfigList = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxContainer = new System.Windows.Forms.CheckBox();
            this.checkBoxDao = new System.Windows.Forms.CheckBox();
            this.checkBoxBean = new System.Windows.Forms.CheckBox();
            this.checkBoxSameFileTip = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBPort)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSelectFolder);
            this.groupBox1.Controls.Add(this.textBoxBaseDao);
            this.groupBox1.Controls.Add(this.textBoxDatamanager);
            this.groupBox1.Controls.Add(this.textBoxJavaPackage);
            this.groupBox1.Controls.Add(this.textBoxDataConfigFile);
            this.groupBox1.Controls.Add(this.textBoxSrcFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "默认配置 配置基本信息";
            // 
            // BtnSelectFolder
            // 
            this.BtnSelectFolder.Location = new System.Drawing.Point(324, 22);
            this.BtnSelectFolder.Name = "BtnSelectFolder";
            this.BtnSelectFolder.Size = new System.Drawing.Size(35, 23);
            this.BtnSelectFolder.TabIndex = 10;
            this.BtnSelectFolder.Text = "+";
            this.BtnSelectFolder.UseVisualStyleBackColor = true;
            this.BtnSelectFolder.Click += new System.EventHandler(this.BtnSelectFolder_Click);
            // 
            // textBoxBaseDao
            // 
            this.textBoxBaseDao.Location = new System.Drawing.Point(288, 48);
            this.textBoxBaseDao.Name = "textBoxBaseDao";
            this.textBoxBaseDao.Size = new System.Drawing.Size(71, 21);
            this.textBoxBaseDao.TabIndex = 9;
            // 
            // textBoxDatamanager
            // 
            this.textBoxDatamanager.Location = new System.Drawing.Point(111, 108);
            this.textBoxDatamanager.Name = "textBoxDatamanager";
            this.textBoxDatamanager.Size = new System.Drawing.Size(248, 21);
            this.textBoxDatamanager.TabIndex = 8;
            // 
            // textBoxJavaPackage
            // 
            this.textBoxJavaPackage.Location = new System.Drawing.Point(111, 76);
            this.textBoxJavaPackage.Name = "textBoxJavaPackage";
            this.textBoxJavaPackage.Size = new System.Drawing.Size(248, 21);
            this.textBoxJavaPackage.TabIndex = 7;
            // 
            // textBoxDataConfigFile
            // 
            this.textBoxDataConfigFile.Location = new System.Drawing.Point(111, 49);
            this.textBoxDataConfigFile.Name = "textBoxDataConfigFile";
            this.textBoxDataConfigFile.Size = new System.Drawing.Size(118, 21);
            this.textBoxDataConfigFile.TabIndex = 6;
            // 
            // textBoxSrcFolder
            // 
            this.textBoxSrcFolder.Location = new System.Drawing.Point(111, 24);
            this.textBoxSrcFolder.Name = "textBoxSrcFolder";
            this.textBoxSrcFolder.ReadOnly = true;
            this.textBoxSrcFolder.Size = new System.Drawing.Size(206, 21);
            this.textBoxSrcFolder.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "BaseDao：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "DataManager：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Java包：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库配置文件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Java Src目录：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownDBPort);
            this.groupBox2.Controls.Add(this.textBoxUserPsw);
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.textBoxDBName);
            this.groupBox2.Controls.Add(this.textBoxDBAddress);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库基本设置";
            // 
            // numericUpDownDBPort
            // 
            this.numericUpDownDBPort.Location = new System.Drawing.Point(272, 16);
            this.numericUpDownDBPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownDBPort.Name = "numericUpDownDBPort";
            this.numericUpDownDBPort.Size = new System.Drawing.Size(61, 21);
            this.numericUpDownDBPort.TabIndex = 9;
            // 
            // textBoxUserPsw
            // 
            this.textBoxUserPsw.Location = new System.Drawing.Point(111, 89);
            this.textBoxUserPsw.Name = "textBoxUserPsw";
            this.textBoxUserPsw.Size = new System.Drawing.Size(139, 21);
            this.textBoxUserPsw.TabIndex = 8;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(111, 65);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(139, 21);
            this.textBoxUserName.TabIndex = 7;
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(111, 42);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(139, 21);
            this.textBoxDBName.TabIndex = 6;
            // 
            // textBoxDBAddress
            // 
            this.textBoxDBAddress.Location = new System.Drawing.Point(111, 17);
            this.textBoxDBAddress.Name = "textBoxDBAddress";
            this.textBoxDBAddress.Size = new System.Drawing.Size(139, 21);
            this.textBoxDBAddress.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(254, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "用户名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "数据库名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "地址：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDel);
            this.groupBox3.Controls.Add(this.btnModify);
            this.groupBox3.Controls.Add(this.BtnAdd);
            this.groupBox3.Controls.Add(this.comboBoxConfigList);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(13, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配置信息";
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(335, 26);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(37, 23);
            this.BtnDel.TabIndex = 4;
            this.BtnDel.Text = "删";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(296, 26);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(37, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(257, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(37, 23);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // comboBoxConfigList
            // 
            this.comboBoxConfigList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfigList.FormattingEnabled = true;
            this.comboBoxConfigList.Location = new System.Drawing.Point(111, 27);
            this.comboBoxConfigList.Name = "comboBoxConfigList";
            this.comboBoxConfigList.Size = new System.Drawing.Size(139, 20);
            this.comboBoxConfigList.TabIndex = 1;
            this.comboBoxConfigList.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfigList_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "配置列表：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxContainer);
            this.groupBox4.Controls.Add(this.checkBoxDao);
            this.groupBox4.Controls.Add(this.checkBoxBean);
            this.groupBox4.Location = new System.Drawing.Point(13, 368);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(378, 65);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "生成选项";
            // 
            // checkBoxContainer
            // 
            this.checkBoxContainer.AutoSize = true;
            this.checkBoxContainer.Location = new System.Drawing.Point(256, 31);
            this.checkBoxContainer.Name = "checkBoxContainer";
            this.checkBoxContainer.Size = new System.Drawing.Size(78, 16);
            this.checkBoxContainer.TabIndex = 2;
            this.checkBoxContainer.Text = "Container";
            this.checkBoxContainer.UseVisualStyleBackColor = true;
            // 
            // checkBoxDao
            // 
            this.checkBoxDao.AutoSize = true;
            this.checkBoxDao.Location = new System.Drawing.Point(148, 32);
            this.checkBoxDao.Name = "checkBoxDao";
            this.checkBoxDao.Size = new System.Drawing.Size(42, 16);
            this.checkBoxDao.TabIndex = 1;
            this.checkBoxDao.Text = "DAO";
            this.checkBoxDao.UseVisualStyleBackColor = true;
            // 
            // checkBoxBean
            // 
            this.checkBoxBean.AutoSize = true;
            this.checkBoxBean.Location = new System.Drawing.Point(41, 33);
            this.checkBoxBean.Name = "checkBoxBean";
            this.checkBoxBean.Size = new System.Drawing.Size(48, 16);
            this.checkBoxBean.TabIndex = 0;
            this.checkBoxBean.Text = "Bean";
            this.checkBoxBean.UseVisualStyleBackColor = true;
            // 
            // checkBoxSameFileTip
            // 
            this.checkBoxSameFileTip.AutoSize = true;
            this.checkBoxSameFileTip.Location = new System.Drawing.Point(37, 458);
            this.checkBoxSameFileTip.Name = "checkBoxSameFileTip";
            this.checkBoxSameFileTip.Size = new System.Drawing.Size(96, 16);
            this.checkBoxSameFileTip.TabIndex = 4;
            this.checkBoxSameFileTip.Text = "相同文件提示";
            this.checkBoxSameFileTip.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(151, 454);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存信息";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(267, 452);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(56, 23);
            this.BtnCreate.TabIndex = 6;
            this.BtnCreate.Text = "生成";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormJavaRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 494);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.checkBoxSameFileTip);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJavaRes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "根据默认配置 配置生成相关文件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDBPort)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSelectFolder;
        private System.Windows.Forms.TextBox textBoxBaseDao;
        private System.Windows.Forms.TextBox textBoxDatamanager;
        private System.Windows.Forms.TextBox textBoxJavaPackage;
        private System.Windows.Forms.TextBox textBoxDataConfigFile;
        private System.Windows.Forms.TextBox textBoxSrcFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownDBPort;
        private System.Windows.Forms.TextBox textBoxUserPsw;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Windows.Forms.TextBox textBoxDBAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ComboBox comboBoxConfigList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxContainer;
        private System.Windows.Forms.CheckBox checkBoxDao;
        private System.Windows.Forms.CheckBox checkBoxBean;
        private System.Windows.Forms.CheckBox checkBoxSameFileTip;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}