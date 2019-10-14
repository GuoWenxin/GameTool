namespace GameTools.Forms
{
    partial class FormVersionSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVersionSetting));
            this.labelInput = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutPut = new System.Windows.Forms.TextBox();
            this.buttonInSelect = new System.Windows.Forms.Button();
            this.buttonOutSelect = new System.Windows.Forms.Button();
            this.radioButtonMd5 = new System.Windows.Forms.RadioButton();
            this.radioButtonNum = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBigVersionNum = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSure = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labSizeUnitTitle = new System.Windows.Forms.Label();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIgnoreFileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonLower = new System.Windows.Forms.RadioButton();
            this.radioButtonUpper = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(13, 28);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(101, 12);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "资源文件夹路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "输出文件夹路径：";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(130, 25);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(282, 21);
            this.textBoxInput.TabIndex = 2;
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // textBoxOutPut
            // 
            this.textBoxOutPut.Location = new System.Drawing.Point(130, 58);
            this.textBoxOutPut.Name = "textBoxOutPut";
            this.textBoxOutPut.Size = new System.Drawing.Size(282, 21);
            this.textBoxOutPut.TabIndex = 3;
            this.textBoxOutPut.TextChanged += new System.EventHandler(this.textBoxOutPut_TextChanged);
            // 
            // buttonInSelect
            // 
            this.buttonInSelect.Location = new System.Drawing.Point(429, 23);
            this.buttonInSelect.Name = "buttonInSelect";
            this.buttonInSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonInSelect.TabIndex = 4;
            this.buttonInSelect.Text = "选择";
            this.buttonInSelect.UseVisualStyleBackColor = true;
            this.buttonInSelect.Click += new System.EventHandler(this.buttonInSelect_Click);
            // 
            // buttonOutSelect
            // 
            this.buttonOutSelect.Location = new System.Drawing.Point(429, 59);
            this.buttonOutSelect.Name = "buttonOutSelect";
            this.buttonOutSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonOutSelect.TabIndex = 5;
            this.buttonOutSelect.Text = "选择";
            this.buttonOutSelect.UseVisualStyleBackColor = true;
            this.buttonOutSelect.Click += new System.EventHandler(this.buttonOutSelect_Click);
            // 
            // radioButtonMd5
            // 
            this.radioButtonMd5.AutoSize = true;
            this.radioButtonMd5.Checked = true;
            this.radioButtonMd5.Location = new System.Drawing.Point(105, 43);
            this.radioButtonMd5.Name = "radioButtonMd5";
            this.radioButtonMd5.Size = new System.Drawing.Size(41, 16);
            this.radioButtonMd5.TabIndex = 6;
            this.radioButtonMd5.TabStop = true;
            this.radioButtonMd5.Text = "MD5";
            this.radioButtonMd5.UseVisualStyleBackColor = true;
            this.radioButtonMd5.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonNum
            // 
            this.radioButtonNum.AutoSize = true;
            this.radioButtonNum.Location = new System.Drawing.Point(340, 43);
            this.radioButtonNum.Name = "radioButtonNum";
            this.radioButtonNum.Size = new System.Drawing.Size(107, 16);
            this.radioButtonNum.TabIndex = 7;
            this.radioButtonNum.TabStop = true;
            this.radioButtonNum.Text = "数值(暂不可用)";
            this.radioButtonNum.UseVisualStyleBackColor = true;
            this.radioButtonNum.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMd5);
            this.groupBox1.Controls.Add(this.radioButtonNum);
            this.groupBox1.Location = new System.Drawing.Point(15, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 87);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "输入大版本号：";
            // 
            // textBoxBigVersionNum
            // 
            this.textBoxBigVersionNum.Location = new System.Drawing.Point(130, 91);
            this.textBoxBigVersionNum.Name = "textBoxBigVersionNum";
            this.textBoxBigVersionNum.Size = new System.Drawing.Size(282, 21);
            this.textBoxBigVersionNum.TabIndex = 10;
            this.textBoxBigVersionNum.TextChanged += new System.EventHandler(this.textBoxBigVersionNum_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(15, 436);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSure
            // 
            this.buttonSure.Location = new System.Drawing.Point(185, 436);
            this.buttonSure.Name = "buttonSure";
            this.buttonSure.Size = new System.Drawing.Size(75, 23);
            this.buttonSure.TabIndex = 12;
            this.buttonSure.Text = "确定";
            this.buttonSure.UseVisualStyleBackColor = true;
            this.buttonSure.Click += new System.EventHandler(this.buttonSure_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(403, 436);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labSizeUnitTitle
            // 
            this.labSizeUnitTitle.AutoSize = true;
            this.labSizeUnitTitle.Location = new System.Drawing.Point(13, 392);
            this.labSizeUnitTitle.Name = "labSizeUnitTitle";
            this.labSizeUnitTitle.Size = new System.Drawing.Size(83, 12);
            this.labSizeUnitTitle.TabIndex = 14;
            this.labSizeUnitTitle.Text = "文件大小单位:";
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB",
            "GB",
            "TB"});
            this.cbUnit.Location = new System.Drawing.Point(102, 389);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(121, 20);
            this.cbUnit.TabIndex = 15;
            this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.cbUnit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "输入忽略文件后缀：";
            // 
            // textBoxIgnoreFileName
            // 
            this.textBoxIgnoreFileName.Location = new System.Drawing.Point(130, 120);
            this.textBoxIgnoreFileName.Name = "textBoxIgnoreFileName";
            this.textBoxIgnoreFileName.Size = new System.Drawing.Size(282, 21);
            this.textBoxIgnoreFileName.TabIndex = 17;
            this.textBoxIgnoreFileName.TextChanged += new System.EventHandler(this.textBoxIgnoreFileName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonLower);
            this.groupBox2.Controls.Add(this.radioButtonUpper);
            this.groupBox2.Location = new System.Drawing.Point(15, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 87);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标类型";
            // 
            // radioButtonLower
            // 
            this.radioButtonLower.AutoSize = true;
            this.radioButtonLower.Checked = true;
            this.radioButtonLower.Location = new System.Drawing.Point(105, 43);
            this.radioButtonLower.Name = "radioButtonLower";
            this.radioButtonLower.Size = new System.Drawing.Size(47, 16);
            this.radioButtonLower.TabIndex = 6;
            this.radioButtonLower.TabStop = true;
            this.radioButtonLower.Text = "小写";
            this.radioButtonLower.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpper
            // 
            this.radioButtonUpper.AutoSize = true;
            this.radioButtonUpper.Location = new System.Drawing.Point(340, 43);
            this.radioButtonUpper.Name = "radioButtonUpper";
            this.radioButtonUpper.Size = new System.Drawing.Size(47, 16);
            this.radioButtonUpper.TabIndex = 7;
            this.radioButtonUpper.TabStop = true;
            this.radioButtonUpper.Text = "大写";
            this.radioButtonUpper.UseVisualStyleBackColor = true;
            // 
            // FormVersionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxIgnoreFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.labSizeUnitTitle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSure);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxBigVersionNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOutSelect);
            this.Controls.Add(this.buttonInSelect);
            this.Controls.Add(this.textBoxOutPut);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVersionSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "版本生成设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutPut;
        private System.Windows.Forms.Button buttonInSelect;
        private System.Windows.Forms.Button buttonOutSelect;
        private System.Windows.Forms.RadioButton radioButtonMd5;
        private System.Windows.Forms.RadioButton radioButtonNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBigVersionNum;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSure;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labSizeUnitTitle;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIgnoreFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonLower;
        private System.Windows.Forms.RadioButton radioButtonUpper;
    }
}