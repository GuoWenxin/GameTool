namespace GameTools
{
    partial class FormTempPathSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTempPathSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CsTempSelectButton = new System.Windows.Forms.Button();
            this.CsTemplateText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TypeSelectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CsTempSelectButton);
            this.groupBox1.Controls.Add(this.CsTemplateText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CS模板路径";
            // 
            // CsTempSelectButton
            // 
            this.CsTempSelectButton.Location = new System.Drawing.Point(298, 32);
            this.CsTempSelectButton.Name = "CsTempSelectButton";
            this.CsTempSelectButton.Size = new System.Drawing.Size(75, 23);
            this.CsTempSelectButton.TabIndex = 2;
            this.CsTempSelectButton.Text = "选择";
            this.CsTempSelectButton.UseVisualStyleBackColor = true;
            this.CsTempSelectButton.Click += new System.EventHandler(this.CsTempSelectButton_Click);
            // 
            // CsTemplateText
            // 
            this.CsTemplateText.Location = new System.Drawing.Point(123, 34);
            this.CsTemplateText.Name = "CsTemplateText";
            this.CsTemplateText.Size = new System.Drawing.Size(169, 21);
            this.CsTemplateText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择表格模板文件：";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.Location = new System.Drawing.Point(163, 282);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(292, 281);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TypeSelectButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TypeTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 76);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变量类型转换文件";
            // 
            // TypeSelectButton
            // 
            this.TypeSelectButton.Location = new System.Drawing.Point(298, 49);
            this.TypeSelectButton.Name = "TypeSelectButton";
            this.TypeSelectButton.Size = new System.Drawing.Size(75, 23);
            this.TypeSelectButton.TabIndex = 2;
            this.TypeSelectButton.Text = "选择";
            this.TypeSelectButton.UseVisualStyleBackColor = true;
            this.TypeSelectButton.Click += new System.EventHandler(this.TypeSelectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "设置变量类型转换文件：";
            // 
            // TypeTextBox
            // 
            this.TypeTextBox.Location = new System.Drawing.Point(123, 49);
            this.TypeTextBox.Name = "TypeTextBox";
            this.TypeTextBox.Size = new System.Drawing.Size(169, 21);
            this.TypeTextBox.TabIndex = 0;
            // 
            // FormTempPathSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 337);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTempPathSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTempPathSetting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CsTemplateText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CsTempSelectButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TypeSelectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TypeTextBox;
    }
}