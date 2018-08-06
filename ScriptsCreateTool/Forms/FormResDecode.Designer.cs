namespace GameTools
{
    partial class FormResDecode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResDecode));
            this.label1 = new System.Windows.Forms.Label();
            this.LabResShow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBDellAddr = new System.Windows.Forms.TextBox();
            this.TBResAddr = new System.Windows.Forms.TextBox();
            this.TBExcelAddr = new System.Windows.Forms.TextBox();
            this.BtnDellAddrSelect = new System.Windows.Forms.Button();
            this.BtnResAddrSelect = new System.Windows.Forms.Button();
            this.BtnExcelAddrSelect = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnInvoke = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择DELL文件地址:";
            // 
            // LabResShow
            // 
            this.LabResShow.AutoSize = true;
            this.LabResShow.Location = new System.Drawing.Point(12, 56);
            this.LabResShow.Name = "LabResShow";
            this.LabResShow.Size = new System.Drawing.Size(113, 12);
            this.LabResShow.TabIndex = 1;
            this.LabResShow.Text = "选择Res文件夹地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "选择Excel导出地址:";
            // 
            // TBDellAddr
            // 
            this.TBDellAddr.Location = new System.Drawing.Point(138, 23);
            this.TBDellAddr.Name = "TBDellAddr";
            this.TBDellAddr.Size = new System.Drawing.Size(268, 21);
            this.TBDellAddr.TabIndex = 3;
            // 
            // TBResAddr
            // 
            this.TBResAddr.Location = new System.Drawing.Point(138, 54);
            this.TBResAddr.Name = "TBResAddr";
            this.TBResAddr.Size = new System.Drawing.Size(268, 21);
            this.TBResAddr.TabIndex = 4;
            // 
            // TBExcelAddr
            // 
            this.TBExcelAddr.Location = new System.Drawing.Point(138, 84);
            this.TBExcelAddr.Name = "TBExcelAddr";
            this.TBExcelAddr.Size = new System.Drawing.Size(268, 21);
            this.TBExcelAddr.TabIndex = 5;
            // 
            // BtnDellAddrSelect
            // 
            this.BtnDellAddrSelect.Location = new System.Drawing.Point(428, 21);
            this.BtnDellAddrSelect.Name = "BtnDellAddrSelect";
            this.BtnDellAddrSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnDellAddrSelect.TabIndex = 6;
            this.BtnDellAddrSelect.Text = "选择";
            this.BtnDellAddrSelect.UseVisualStyleBackColor = true;
            this.BtnDellAddrSelect.Click += new System.EventHandler(this.BtnDellAddrSelect_Click);
            // 
            // BtnResAddrSelect
            // 
            this.BtnResAddrSelect.Location = new System.Drawing.Point(428, 52);
            this.BtnResAddrSelect.Name = "BtnResAddrSelect";
            this.BtnResAddrSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnResAddrSelect.TabIndex = 7;
            this.BtnResAddrSelect.Text = "选择";
            this.BtnResAddrSelect.UseVisualStyleBackColor = true;
            this.BtnResAddrSelect.Click += new System.EventHandler(this.BtnResAddrSelect_Click);
            // 
            // BtnExcelAddrSelect
            // 
            this.BtnExcelAddrSelect.Location = new System.Drawing.Point(428, 85);
            this.BtnExcelAddrSelect.Name = "BtnExcelAddrSelect";
            this.BtnExcelAddrSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnExcelAddrSelect.TabIndex = 8;
            this.BtnExcelAddrSelect.Text = "选择";
            this.BtnExcelAddrSelect.UseVisualStyleBackColor = true;
            this.BtnExcelAddrSelect.Click += new System.EventHandler(this.BtnExcelAddrSelect_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(14, 135);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(239, 135);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnInvoke
            // 
            this.BtnInvoke.Location = new System.Drawing.Point(428, 135);
            this.BtnInvoke.Name = "BtnInvoke";
            this.BtnInvoke.Size = new System.Drawing.Size(75, 23);
            this.BtnInvoke.TabIndex = 11;
            this.BtnInvoke.Text = "确定";
            this.BtnInvoke.UseVisualStyleBackColor = true;
            this.BtnInvoke.Click += new System.EventHandler(this.BtnInvoke_Click);
            // 
            // FormResDecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 196);
            this.Controls.Add(this.BtnInvoke);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnExcelAddrSelect);
            this.Controls.Add(this.BtnResAddrSelect);
            this.Controls.Add(this.BtnDellAddrSelect);
            this.Controls.Add(this.TBExcelAddr);
            this.Controls.Add(this.TBResAddr);
            this.Controls.Add(this.TBDellAddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabResShow);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResDecode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Res解析设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabResShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBDellAddr;
        private System.Windows.Forms.TextBox TBResAddr;
        private System.Windows.Forms.TextBox TBExcelAddr;
        private System.Windows.Forms.Button BtnDellAddrSelect;
        private System.Windows.Forms.Button BtnResAddrSelect;
        private System.Windows.Forms.Button BtnExcelAddrSelect;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnInvoke;
    }
}