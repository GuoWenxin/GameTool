namespace GameTools
{
    partial class FormBasicSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBasicSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoadDataCheckBox = new System.Windows.Forms.CheckBox();
            this.StartLoadFoldercheckBox = new System.Windows.Forms.CheckBox();
            this.FilterSheetText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IsDisorderCheckBox = new System.Windows.Forms.CheckBox();
            this.IsDataBaseCheckBox = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SelectFolder = new System.Windows.Forms.Button();
            this.ResFolderText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SHA1CheckBox = new System.Windows.Forms.CheckBox();
            this.MD5CheckBox = new System.Windows.Forms.CheckBox();
            this.CRC32CheckBox = new System.Windows.Forms.CheckBox();
            this.VersionCheckBox = new System.Windows.Forms.CheckBox();
            this.IsResEncCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LoadDataCheckBox);
            this.groupBox1.Controls.Add(this.StartLoadFoldercheckBox);
            this.groupBox1.Controls.Add(this.FilterSheetText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读取excel数据";
            // 
            // LoadDataCheckBox
            // 
            this.LoadDataCheckBox.AutoSize = true;
            this.LoadDataCheckBox.Location = new System.Drawing.Point(282, 54);
            this.LoadDataCheckBox.Name = "LoadDataCheckBox";
            this.LoadDataCheckBox.Size = new System.Drawing.Size(132, 16);
            this.LoadDataCheckBox.TabIndex = 3;
            this.LoadDataCheckBox.Text = "解析数据(后端可选)";
            this.LoadDataCheckBox.UseVisualStyleBackColor = true;
            this.LoadDataCheckBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // StartLoadFoldercheckBox
            // 
            this.StartLoadFoldercheckBox.AutoSize = true;
            this.StartLoadFoldercheckBox.Location = new System.Drawing.Point(9, 54);
            this.StartLoadFoldercheckBox.Name = "StartLoadFoldercheckBox";
            this.StartLoadFoldercheckBox.Size = new System.Drawing.Size(144, 16);
            this.StartLoadFoldercheckBox.TabIndex = 2;
            this.StartLoadFoldercheckBox.Text = "程序开启自动解析文件";
            this.StartLoadFoldercheckBox.UseVisualStyleBackColor = true;
            // 
            // FilterSheetText
            // 
            this.FilterSheetText.Location = new System.Drawing.Point(84, 19);
            this.FilterSheetText.Name = "FilterSheetText";
            this.FilterSheetText.Size = new System.Drawing.Size(330, 21);
            this.FilterSheetText.TabIndex = 1;
            this.FilterSheetText.Text = "changelog,说明,sheet,备份";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "过滤工作簿:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.IsDisorderCheckBox);
            this.groupBox2.Controls.Add(this.IsDataBaseCheckBox);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.SelectFolder);
            this.groupBox2.Controls.Add(this.ResFolderText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(35, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 219);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "前端资源生成";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "下划线过滤：";
            // 
            // IsDisorderCheckBox
            // 
            this.IsDisorderCheckBox.AutoSize = true;
            this.IsDisorderCheckBox.ForeColor = System.Drawing.Color.Red;
            this.IsDisorderCheckBox.Location = new System.Drawing.Point(84, 192);
            this.IsDisorderCheckBox.Name = "IsDisorderCheckBox";
            this.IsDisorderCheckBox.Size = new System.Drawing.Size(120, 16);
            this.IsDisorderCheckBox.TabIndex = 5;
            this.IsDisorderCheckBox.Text = "是否加密资源文件";
            this.IsDisorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // IsDataBaseCheckBox
            // 
            this.IsDataBaseCheckBox.AutoSize = true;
            this.IsDataBaseCheckBox.ForeColor = System.Drawing.Color.Red;
            this.IsDataBaseCheckBox.Location = new System.Drawing.Point(84, 170);
            this.IsDataBaseCheckBox.Name = "IsDataBaseCheckBox";
            this.IsDataBaseCheckBox.Size = new System.Drawing.Size(204, 16);
            this.IsDataBaseCheckBox.TabIndex = 4;
            this.IsDataBaseCheckBox.Text = "是否从数据库中读取数据生成文件";
            this.IsDataBaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(84, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(330, 101);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // SelectFolder
            // 
            this.SelectFolder.Location = new System.Drawing.Point(355, 21);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.SelectFolder.TabIndex = 2;
            this.SelectFolder.Text = "选择";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // ResFolderText
            // 
            this.ResFolderText.Location = new System.Drawing.Point(84, 24);
            this.ResFolderText.Name = "ResFolderText";
            this.ResFolderText.Size = new System.Drawing.Size(244, 21);
            this.ResFolderText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "保存路径:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.SHA1CheckBox);
            this.groupBox3.Controls.Add(this.MD5CheckBox);
            this.groupBox3.Controls.Add(this.CRC32CheckBox);
            this.groupBox3.Controls.Add(this.VersionCheckBox);
            this.groupBox3.Controls.Add(this.IsResEncCheckBox);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(35, 353);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "乱序排列表中字段";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(54, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "*优先判断是否强制乱序的表";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(52, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "注意：使用版本，将以表生成的版本号为种子进行CRC32乱序排列";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(52, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "乱序模式，请先生成前端RES文件，再生成前端AS文件";
            // 
            // SHA1CheckBox
            // 
            this.SHA1CheckBox.AutoSize = true;
            this.SHA1CheckBox.Location = new System.Drawing.Point(287, 56);
            this.SHA1CheckBox.Name = "SHA1CheckBox";
            this.SHA1CheckBox.Size = new System.Drawing.Size(48, 16);
            this.SHA1CheckBox.TabIndex = 6;
            this.SHA1CheckBox.Text = "SHA1";
            this.SHA1CheckBox.UseVisualStyleBackColor = true;
            // 
            // MD5CheckBox
            // 
            this.MD5CheckBox.AutoSize = true;
            this.MD5CheckBox.Location = new System.Drawing.Point(214, 56);
            this.MD5CheckBox.Name = "MD5CheckBox";
            this.MD5CheckBox.Size = new System.Drawing.Size(42, 16);
            this.MD5CheckBox.TabIndex = 5;
            this.MD5CheckBox.Text = "MD5";
            this.MD5CheckBox.UseVisualStyleBackColor = true;
            // 
            // CRC32CheckBox
            // 
            this.CRC32CheckBox.AutoSize = true;
            this.CRC32CheckBox.Location = new System.Drawing.Point(124, 56);
            this.CRC32CheckBox.Name = "CRC32CheckBox";
            this.CRC32CheckBox.Size = new System.Drawing.Size(54, 16);
            this.CRC32CheckBox.TabIndex = 4;
            this.CRC32CheckBox.Text = "CRC32";
            this.CRC32CheckBox.UseVisualStyleBackColor = true;
            // 
            // VersionCheckBox
            // 
            this.VersionCheckBox.AutoSize = true;
            this.VersionCheckBox.Location = new System.Drawing.Point(52, 57);
            this.VersionCheckBox.Name = "VersionCheckBox";
            this.VersionCheckBox.Size = new System.Drawing.Size(48, 16);
            this.VersionCheckBox.TabIndex = 3;
            this.VersionCheckBox.Text = "版本";
            this.VersionCheckBox.UseVisualStyleBackColor = true;
            // 
            // IsResEncCheckBox
            // 
            this.IsResEncCheckBox.AutoSize = true;
            this.IsResEncCheckBox.Location = new System.Drawing.Point(342, 21);
            this.IsResEncCheckBox.Name = "IsResEncCheckBox";
            this.IsResEncCheckBox.Size = new System.Drawing.Size(48, 16);
            this.IsResEncCheckBox.TabIndex = 2;
            this.IsResEncCheckBox.Text = "启用";
            this.IsResEncCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(52, 18);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(283, 21);
            this.textBox3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "种子:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(299, 511);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(400, 511);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // FormBasicSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 549);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBasicSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "基本设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox LoadDataCheckBox;
        private System.Windows.Forms.CheckBox StartLoadFoldercheckBox;
        private System.Windows.Forms.TextBox FilterSheetText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox IsDisorderCheckBox;
        private System.Windows.Forms.CheckBox IsDataBaseCheckBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button SelectFolder;
        private System.Windows.Forms.TextBox ResFolderText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SHA1CheckBox;
        private System.Windows.Forms.CheckBox MD5CheckBox;
        private System.Windows.Forms.CheckBox CRC32CheckBox;
        private System.Windows.Forms.CheckBox VersionCheckBox;
        private System.Windows.Forms.CheckBox IsResEncCheckBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label7;
    }
}