namespace GameTools
{
    partial class FormCSMessageConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCSMessageConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.checkBoxbean = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxMessagePool = new System.Windows.Forms.CheckBox();
            this.checkBoxCservice = new System.Windows.Forms.CheckBox();
            this.checkBoxhandler = new System.Windows.Forms.CheckBox();
            this.checkBoxmessage = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息生成路径：";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(101, 39);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(165, 21);
            this.textBoxPath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(287, 38);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // checkBoxbean
            // 
            this.checkBoxbean.AutoSize = true;
            this.checkBoxbean.Checked = true;
            this.checkBoxbean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxbean.Location = new System.Drawing.Point(6, 21);
            this.checkBoxbean.Name = "checkBoxbean";
            this.checkBoxbean.Size = new System.Drawing.Size(72, 16);
            this.checkBoxbean.TabIndex = 3;
            this.checkBoxbean.Text = "生成Bean";
            this.checkBoxbean.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(12, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(227, 235);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "生成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPath);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMessagePool);
            this.groupBox2.Controls.Add(this.checkBoxCservice);
            this.groupBox2.Controls.Add(this.checkBoxhandler);
            this.groupBox2.Controls.Add(this.checkBoxmessage);
            this.groupBox2.Controls.Add(this.checkBoxbean);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 93);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生成选项";
            // 
            // checkBoxMessagePool
            // 
            this.checkBoxMessagePool.AutoSize = true;
            this.checkBoxMessagePool.Checked = true;
            this.checkBoxMessagePool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMessagePool.Location = new System.Drawing.Point(138, 61);
            this.checkBoxMessagePool.Name = "checkBoxMessagePool";
            this.checkBoxMessagePool.Size = new System.Drawing.Size(114, 16);
            this.checkBoxMessagePool.TabIndex = 7;
            this.checkBoxMessagePool.Text = "生成MessagePool";
            this.checkBoxMessagePool.UseVisualStyleBackColor = true;
            // 
            // checkBoxCservice
            // 
            this.checkBoxCservice.AutoSize = true;
            this.checkBoxCservice.Checked = true;
            this.checkBoxCservice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCservice.Location = new System.Drawing.Point(6, 62);
            this.checkBoxCservice.Name = "checkBoxCservice";
            this.checkBoxCservice.Size = new System.Drawing.Size(96, 16);
            this.checkBoxCservice.TabIndex = 6;
            this.checkBoxCservice.Text = "生成CService";
            this.checkBoxCservice.UseVisualStyleBackColor = true;
            // 
            // checkBoxhandler
            // 
            this.checkBoxhandler.AutoSize = true;
            this.checkBoxhandler.Checked = true;
            this.checkBoxhandler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxhandler.Location = new System.Drawing.Point(299, 21);
            this.checkBoxhandler.Name = "checkBoxhandler";
            this.checkBoxhandler.Size = new System.Drawing.Size(90, 16);
            this.checkBoxhandler.TabIndex = 5;
            this.checkBoxhandler.Text = "生成handler";
            this.checkBoxhandler.UseVisualStyleBackColor = true;
            // 
            // checkBoxmessage
            // 
            this.checkBoxmessage.AutoSize = true;
            this.checkBoxmessage.Checked = true;
            this.checkBoxmessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxmessage.Location = new System.Drawing.Point(138, 21);
            this.checkBoxmessage.Name = "checkBoxmessage";
            this.checkBoxmessage.Size = new System.Drawing.Size(90, 16);
            this.checkBoxmessage.TabIndex = 4;
            this.checkBoxmessage.Text = "生成Message";
            this.checkBoxmessage.UseVisualStyleBackColor = true;
            // 
            // FormCSMessageConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 279);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCSMessageConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成C#消息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox checkBoxbean;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxmessage;
        private System.Windows.Forms.CheckBox checkBoxCservice;
        private System.Windows.Forms.CheckBox checkBoxhandler;
        private System.Windows.Forms.CheckBox checkBoxMessagePool;
    }
}