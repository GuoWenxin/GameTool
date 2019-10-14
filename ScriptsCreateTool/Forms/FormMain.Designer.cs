using System.Xml;

namespace GameTools
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置数值文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新所有文件toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新选中文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成选中我文件表结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入选中表数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miReadLoalDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.GetTablesFromSql = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportFromSqlItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemResOpe = new System.Windows.Forms.ToolStripMenuItem();
            this.MenItemResCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDecodeResSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDecodeResFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.生成Java资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成As资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成CS资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成CS消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CS单个文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CS单个文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.单个AS文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单个AS文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.单个Java文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单个Java文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.单个文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.简转繁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.繁转简ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemJsonDecode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemJsonEncode = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAllNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSelectNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tBSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelThreadNum = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbDaLocalPosition = new System.Windows.Forms.Label();
            this.DataBaseUserNameLabel = new System.Windows.Forms.Label();
            this.DataBaseNameLabel = new System.Windows.Forms.Label();
            this.DataBaseAddressLabel = new System.Windows.Forms.Label();
            this.RemoveDataBaseBtn = new System.Windows.Forms.Button();
            this.ModifyDataBaseBtn = new System.Windows.Forms.Button();
            this.AddDataBaseBtn = new System.Windows.Forms.Button();
            this.DataBaseComBobox = new System.Windows.Forms.ComboBox();
            this.LogRichText = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbDebugtype5 = new System.Windows.Forms.RadioButton();
            this.rbDebugtype4 = new System.Windows.Forms.RadioButton();
            this.rbDebugtype3 = new System.Windows.Forms.RadioButton();
            this.rbDebugtype2 = new System.Windows.Forms.RadioButton();
            this.rbDebugtype1 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.数据ToolStripMenuItem,
            this.消息ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置数值文件夹ToolStripMenuItem,
            this.基本设置ToolStripMenuItem,
            this.toolStripSeparator1,
            this.刷新所有文件toolStripMenuItem2,
            this.刷新选中文件ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(F)";
            // 
            // 设置数值文件夹ToolStripMenuItem
            // 
            this.设置数值文件夹ToolStripMenuItem.Name = "设置数值文件夹ToolStripMenuItem";
            this.设置数值文件夹ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.设置数值文件夹ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.设置数值文件夹ToolStripMenuItem.Text = "设置数值文件夹";
            this.设置数值文件夹ToolStripMenuItem.Click += new System.EventHandler(this.设置数值文件夹ToolStripMenuItem_Click);
            // 
            // 基本设置ToolStripMenuItem
            // 
            this.基本设置ToolStripMenuItem.Name = "基本设置ToolStripMenuItem";
            this.基本设置ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.基本设置ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.基本设置ToolStripMenuItem.Text = "基本设置";
            this.基本设置ToolStripMenuItem.Click += new System.EventHandler(this.基本设置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // 刷新所有文件toolStripMenuItem2
            // 
            this.刷新所有文件toolStripMenuItem2.Name = "刷新所有文件toolStripMenuItem2";
            this.刷新所有文件toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.刷新所有文件toolStripMenuItem2.Size = new System.Drawing.Size(203, 22);
            this.刷新所有文件toolStripMenuItem2.Text = "刷新所有文件";
            this.刷新所有文件toolStripMenuItem2.Click += new System.EventHandler(this.刷新所有文件toolStripMenuItem2_Click);
            // 
            // 刷新选中文件ToolStripMenuItem
            // 
            this.刷新选中文件ToolStripMenuItem.Name = "刷新选中文件ToolStripMenuItem";
            this.刷新选中文件ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.刷新选中文件ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.刷新选中文件ToolStripMenuItem.Text = "刷新选中文件";
            this.刷新选中文件ToolStripMenuItem.Click += new System.EventHandler(this.刷新选中文件ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成选中我文件表结构ToolStripMenuItem,
            this.导入选中表数据ToolStripMenuItem,
            this.miReadLoalDatabase,
            this.GetTablesFromSql,
            this.toolStripMenuItem3,
            this.ExportFromSqlItem,
            this.toolStripSeparator3,
            this.MenuItemResOpe,
            this.toolStripSeparator4,
            this.生成Java资源ToolStripMenuItem,
            this.生成As资源ToolStripMenuItem,
            this.生成CS资源ToolStripMenuItem});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.数据ToolStripMenuItem.Text = "数据(B)";
            // 
            // 生成选中我文件表结构ToolStripMenuItem
            // 
            this.生成选中我文件表结构ToolStripMenuItem.Name = "生成选中我文件表结构ToolStripMenuItem";
            this.生成选中我文件表结构ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.生成选中我文件表结构ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.生成选中我文件表结构ToolStripMenuItem.Text = "生成选中文件表结构";
            this.生成选中我文件表结构ToolStripMenuItem.Click += new System.EventHandler(this.生成选中我文件表结构ToolStripMenuItem_Click);
            // 
            // 导入选中表数据ToolStripMenuItem
            // 
            this.导入选中表数据ToolStripMenuItem.Name = "导入选中表数据ToolStripMenuItem";
            this.导入选中表数据ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.导入选中表数据ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.导入选中表数据ToolStripMenuItem.Text = "导入选中表数据";
            this.导入选中表数据ToolStripMenuItem.Click += new System.EventHandler(this.导入选中表数据ToolStripMenuItem_Click);
            // 
            // miReadLoalDatabase
            // 
            this.miReadLoalDatabase.Name = "miReadLoalDatabase";
            this.miReadLoalDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.miReadLoalDatabase.Size = new System.Drawing.Size(228, 22);
            this.miReadLoalDatabase.Text = "读取本地数据库";
            this.miReadLoalDatabase.Click += new System.EventHandler(this.miReadLoalDatabase_Click);
            // 
            // GetTablesFromSql
            // 
            this.GetTablesFromSql.Name = "GetTablesFromSql";
            this.GetTablesFromSql.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.GetTablesFromSql.Size = new System.Drawing.Size(228, 22);
            this.GetTablesFromSql.Text = "读取数据库表";
            this.GetTablesFromSql.Click += new System.EventHandler(this.GetTablesFromSql_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItem3.Text = "更新数据库";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // ExportFromSqlItem
            // 
            this.ExportFromSqlItem.Name = "ExportFromSqlItem";
            this.ExportFromSqlItem.Size = new System.Drawing.Size(228, 22);
            this.ExportFromSqlItem.Text = "导出数据库";
            this.ExportFromSqlItem.Click += new System.EventHandler(this.ExportFromSqlItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // MenuItemResOpe
            // 
            this.MenuItemResOpe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenItemResCreate,
            this.MenuItemDecodeResSingle,
            this.MenuItemDecodeResFolder});
            this.MenuItemResOpe.Name = "MenuItemResOpe";
            this.MenuItemResOpe.Size = new System.Drawing.Size(228, 22);
            this.MenuItemResOpe.Text = "Res操作";
            // 
            // MenItemResCreate
            // 
            this.MenItemResCreate.Name = "MenItemResCreate";
            this.MenItemResCreate.Size = new System.Drawing.Size(169, 22);
            this.MenItemResCreate.Text = "生成Res资源";
            this.MenItemResCreate.Click += new System.EventHandler(this.MenItemResCreate_Click);
            // 
            // MenuItemDecodeResSingle
            // 
            this.MenuItemDecodeResSingle.Name = "MenuItemDecodeResSingle";
            this.MenuItemDecodeResSingle.Size = new System.Drawing.Size(169, 22);
            this.MenuItemDecodeResSingle.Text = "解析单个Res资源";
            this.MenuItemDecodeResSingle.Click += new System.EventHandler(this.MenuItemDecodeResSingle_Click);
            // 
            // MenuItemDecodeResFolder
            // 
            this.MenuItemDecodeResFolder.Name = "MenuItemDecodeResFolder";
            this.MenuItemDecodeResFolder.Size = new System.Drawing.Size(169, 22);
            this.MenuItemDecodeResFolder.Text = "解析Res文件夹";
            this.MenuItemDecodeResFolder.Click += new System.EventHandler(this.MenuItemDecodeResFolder_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // 生成Java资源ToolStripMenuItem
            // 
            this.生成Java资源ToolStripMenuItem.Name = "生成Java资源ToolStripMenuItem";
            this.生成Java资源ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.生成Java资源ToolStripMenuItem.Text = "生成Java资源";
            this.生成Java资源ToolStripMenuItem.Click += new System.EventHandler(this.生成Java资源ToolStripMenuItem_Click);
            // 
            // 生成As资源ToolStripMenuItem
            // 
            this.生成As资源ToolStripMenuItem.Name = "生成As资源ToolStripMenuItem";
            this.生成As资源ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.生成As资源ToolStripMenuItem.Text = "生成As资源";
            this.生成As资源ToolStripMenuItem.Click += new System.EventHandler(this.生成As资源ToolStripMenuItem_Click);
            // 
            // 生成CS资源ToolStripMenuItem
            // 
            this.生成CS资源ToolStripMenuItem.Name = "生成CS资源ToolStripMenuItem";
            this.生成CS资源ToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.生成CS资源ToolStripMenuItem.Text = "生成CS资源";
            this.生成CS资源ToolStripMenuItem.Click += new System.EventHandler(this.生成CS资源ToolStripMenuItem_Click);
            // 
            // 消息ToolStripMenuItem
            // 
            this.消息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成CS消息ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.toolStripSeparator6});
            this.消息ToolStripMenuItem.Name = "消息ToolStripMenuItem";
            this.消息ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.消息ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.消息ToolStripMenuItem.Text = "消息(M)";
            // 
            // 生成CS消息ToolStripMenuItem
            // 
            this.生成CS消息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CS单个文件ToolStripMenuItem,
            this.CS单个文件夹ToolStripMenuItem});
            this.生成CS消息ToolStripMenuItem.Name = "生成CS消息ToolStripMenuItem";
            this.生成CS消息ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.生成CS消息ToolStripMenuItem.Text = "生成CS消息";
            // 
            // CS单个文件ToolStripMenuItem
            // 
            this.CS单个文件ToolStripMenuItem.Name = "CS单个文件ToolStripMenuItem";
            this.CS单个文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.CS单个文件ToolStripMenuItem.Text = "单个文件";
            this.CS单个文件ToolStripMenuItem.Click += new System.EventHandler(this.CS单个文件ToolStripMenuItem_Click);
            // 
            // CS单个文件夹ToolStripMenuItem
            // 
            this.CS单个文件夹ToolStripMenuItem.Name = "CS单个文件夹ToolStripMenuItem";
            this.CS单个文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.CS单个文件夹ToolStripMenuItem.Text = "单个文件夹";
            this.CS单个文件夹ToolStripMenuItem.Click += new System.EventHandler(this.CS单个文件夹ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单个AS文件ToolStripMenuItem,
            this.单个AS文件夹ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem2.Text = "生成AS消息";
            // 
            // 单个AS文件ToolStripMenuItem
            // 
            this.单个AS文件ToolStripMenuItem.Name = "单个AS文件ToolStripMenuItem";
            this.单个AS文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.单个AS文件ToolStripMenuItem.Text = "单个文件";
            this.单个AS文件ToolStripMenuItem.Click += new System.EventHandler(this.单个AS文件ToolStripMenuItem_Click);
            // 
            // 单个AS文件夹ToolStripMenuItem
            // 
            this.单个AS文件夹ToolStripMenuItem.Name = "单个AS文件夹ToolStripMenuItem";
            this.单个AS文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.单个AS文件夹ToolStripMenuItem.Text = "单个文件夹";
            this.单个AS文件夹ToolStripMenuItem.Click += new System.EventHandler(this.单个AS文件夹ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单个Java文件ToolStripMenuItem,
            this.单个Java文件夹ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem1.Text = "生成Java消息";
            // 
            // 单个Java文件ToolStripMenuItem
            // 
            this.单个Java文件ToolStripMenuItem.Name = "单个Java文件ToolStripMenuItem";
            this.单个Java文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.单个Java文件ToolStripMenuItem.Text = "单个文件";
            this.单个Java文件ToolStripMenuItem.Click += new System.EventHandler(this.单个Java文件ToolStripMenuItem_Click);
            // 
            // 单个Java文件夹ToolStripMenuItem
            // 
            this.单个Java文件夹ToolStripMenuItem.Name = "单个Java文件夹ToolStripMenuItem";
            this.单个Java文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.单个Java文件夹ToolStripMenuItem.Text = "单个文件夹";
            this.单个Java文件夹ToolStripMenuItem.Click += new System.EventHandler(this.单个Java文件夹ToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(146, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单个文件ToolStripMenuItem,
            this.文件夹ToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(84, 21);
            this.toolStripMenuItem4.Text = "MD5版本号";
            // 
            // 单个文件ToolStripMenuItem
            // 
            this.单个文件ToolStripMenuItem.Name = "单个文件ToolStripMenuItem";
            this.单个文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.单个文件ToolStripMenuItem.Text = "单个文件";
            this.单个文件ToolStripMenuItem.Click += new System.EventHandler(this.单个文件ToolStripMenuItem_Click);
            // 
            // 文件夹ToolStripMenuItem
            // 
            this.文件夹ToolStripMenuItem.Name = "文件夹ToolStripMenuItem";
            this.文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文件夹ToolStripMenuItem.Text = "文件夹";
            this.文件夹ToolStripMenuItem.Click += new System.EventHandler(this.文件夹ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.简转繁ToolStripMenuItem,
            this.繁转简ToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem5.Text = "字体转换";
            // 
            // 简转繁ToolStripMenuItem
            // 
            this.简转繁ToolStripMenuItem.Name = "简转繁ToolStripMenuItem";
            this.简转繁ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.简转繁ToolStripMenuItem.Text = "简转繁";
            this.简转繁ToolStripMenuItem.Click += new System.EventHandler(this.简转繁ToolStripMenuItem_Click);
            // 
            // 繁转简ToolStripMenuItem
            // 
            this.繁转简ToolStripMenuItem.Name = "繁转简ToolStripMenuItem";
            this.繁转简ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.繁转简ToolStripMenuItem.Text = "繁转简";
            this.繁转简ToolStripMenuItem.Click += new System.EventHandler(this.繁转简ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemJsonDecode,
            this.MenuItemJsonEncode});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(76, 21);
            this.toolStripMenuItem6.Text = "JSON转换";
            // 
            // MenuItemJsonDecode
            // 
            this.MenuItemJsonDecode.Name = "MenuItemJsonDecode";
            this.MenuItemJsonDecode.Size = new System.Drawing.Size(132, 22);
            this.MenuItemJsonDecode.Text = "解析JSON";
            this.MenuItemJsonDecode.Click += new System.EventHandler(this.MenuItemJsonDecode_Click);
            // 
            // MenuItemJsonEncode
            // 
            this.MenuItemJsonEncode.Name = "MenuItemJsonEncode";
            this.MenuItemJsonEncode.Size = new System.Drawing.Size(132, 22);
            this.MenuItemJsonEncode.Text = "生成JSON";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用说明ToolStripMenuItem,
            this.清空日志ToolStripMenuItem,
            this.MenuItemAbout});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(H)";
            // 
            // 使用说明ToolStripMenuItem
            // 
            this.使用说明ToolStripMenuItem.Name = "使用说明ToolStripMenuItem";
            this.使用说明ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.使用说明ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.使用说明ToolStripMenuItem.Text = "使用说明";
            this.使用说明ToolStripMenuItem.Click += new System.EventHandler(this.使用说明ToolStripMenuItem_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // MenuItemAbout
            // 
            this.MenuItemAbout.Name = "MenuItemAbout";
            this.MenuItemAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.MenuItemAbout.Size = new System.Drawing.Size(174, 22);
            this.MenuItemAbout.Text = "关于";
            this.MenuItemAbout.Click += new System.EventHandler(this.MenuItemAbout_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 94);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(426, 308);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.labelAllNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelSelectNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tBSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 427);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "策划数值文档列表";
            // 
            // labelAllNumber
            // 
            this.labelAllNumber.AutoSize = true;
            this.labelAllNumber.Location = new System.Drawing.Point(80, 409);
            this.labelAllNumber.Name = "labelAllNumber";
            this.labelAllNumber.Size = new System.Drawing.Size(11, 12);
            this.labelAllNumber.TabIndex = 11;
            this.labelAllNumber.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "当前总个数：";
            // 
            // labelSelectNum
            // 
            this.labelSelectNum.AutoSize = true;
            this.labelSelectNum.Location = new System.Drawing.Point(386, 409);
            this.labelSelectNum.Name = "labelSelectNum";
            this.labelSelectNum.Size = new System.Drawing.Size(11, 12);
            this.labelSelectNum.TabIndex = 9;
            this.labelSelectNum.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "当前选中个数：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(336, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tBSearch
            // 
            this.tBSearch.Location = new System.Drawing.Point(95, 60);
            this.tBSearch.Name = "tBSearch";
            this.tBSearch.Size = new System.Drawing.Size(235, 21);
            this.tBSearch.TabIndex = 6;
            this.tBSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTbSearchKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "点击此处搜索:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(426, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelThreadNum);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(0, 656);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1081, 39);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // labelThreadNum
            // 
            this.labelThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelThreadNum.AutoSize = true;
            this.labelThreadNum.Location = new System.Drawing.Point(1028, 16);
            this.labelThreadNum.Name = "labelThreadNum";
            this.labelThreadNum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelThreadNum.Size = new System.Drawing.Size(11, 12);
            this.labelThreadNum.TabIndex = 2;
            this.labelThreadNum.Text = "0";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(76, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "文件路径:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lbDaLocalPosition);
            this.groupBox3.Controls.Add(this.DataBaseUserNameLabel);
            this.groupBox3.Controls.Add(this.DataBaseNameLabel);
            this.groupBox3.Controls.Add(this.DataBaseAddressLabel);
            this.groupBox3.Controls.Add(this.RemoveDataBaseBtn);
            this.groupBox3.Controls.Add(this.ModifyDataBaseBtn);
            this.groupBox3.Controls.Add(this.AddDataBaseBtn);
            this.groupBox3.Controls.Add(this.DataBaseComBobox);
            this.groupBox3.Location = new System.Drawing.Point(12, 474);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 177);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库";
            // 
            // lbDaLocalPosition
            // 
            this.lbDaLocalPosition.AutoSize = true;
            this.lbDaLocalPosition.Location = new System.Drawing.Point(16, 147);
            this.lbDaLocalPosition.Name = "lbDaLocalPosition";
            this.lbDaLocalPosition.Size = new System.Drawing.Size(65, 12);
            this.lbDaLocalPosition.TabIndex = 7;
            this.lbDaLocalPosition.Text = "本地位置：";
            // 
            // DataBaseUserNameLabel
            // 
            this.DataBaseUserNameLabel.AutoSize = true;
            this.DataBaseUserNameLabel.Location = new System.Drawing.Point(17, 120);
            this.DataBaseUserNameLabel.Name = "DataBaseUserNameLabel";
            this.DataBaseUserNameLabel.Size = new System.Drawing.Size(53, 12);
            this.DataBaseUserNameLabel.TabIndex = 6;
            this.DataBaseUserNameLabel.Text = "用户名：";
            // 
            // DataBaseNameLabel
            // 
            this.DataBaseNameLabel.AutoSize = true;
            this.DataBaseNameLabel.Location = new System.Drawing.Point(17, 95);
            this.DataBaseNameLabel.Name = "DataBaseNameLabel";
            this.DataBaseNameLabel.Size = new System.Drawing.Size(53, 12);
            this.DataBaseNameLabel.TabIndex = 5;
            this.DataBaseNameLabel.Text = "数据库：";
            // 
            // DataBaseAddressLabel
            // 
            this.DataBaseAddressLabel.AutoSize = true;
            this.DataBaseAddressLabel.Location = new System.Drawing.Point(17, 68);
            this.DataBaseAddressLabel.Name = "DataBaseAddressLabel";
            this.DataBaseAddressLabel.Size = new System.Drawing.Size(41, 12);
            this.DataBaseAddressLabel.TabIndex = 4;
            this.DataBaseAddressLabel.Text = "地址：";
            // 
            // RemoveDataBaseBtn
            // 
            this.RemoveDataBaseBtn.Location = new System.Drawing.Point(350, 34);
            this.RemoveDataBaseBtn.Name = "RemoveDataBaseBtn";
            this.RemoveDataBaseBtn.Size = new System.Drawing.Size(29, 23);
            this.RemoveDataBaseBtn.TabIndex = 3;
            this.RemoveDataBaseBtn.Text = "删";
            this.RemoveDataBaseBtn.UseVisualStyleBackColor = true;
            this.RemoveDataBaseBtn.Click += new System.EventHandler(this.RemoveDataBaseBtn_Click);
            // 
            // ModifyDataBaseBtn
            // 
            this.ModifyDataBaseBtn.Location = new System.Drawing.Point(317, 34);
            this.ModifyDataBaseBtn.Name = "ModifyDataBaseBtn";
            this.ModifyDataBaseBtn.Size = new System.Drawing.Size(26, 23);
            this.ModifyDataBaseBtn.TabIndex = 2;
            this.ModifyDataBaseBtn.Text = "改";
            this.ModifyDataBaseBtn.UseVisualStyleBackColor = true;
            this.ModifyDataBaseBtn.Click += new System.EventHandler(this.ModifyDataBaseBtn_Click);
            // 
            // AddDataBaseBtn
            // 
            this.AddDataBaseBtn.Location = new System.Drawing.Point(281, 34);
            this.AddDataBaseBtn.Name = "AddDataBaseBtn";
            this.AddDataBaseBtn.Size = new System.Drawing.Size(30, 23);
            this.AddDataBaseBtn.TabIndex = 1;
            this.AddDataBaseBtn.Text = "增";
            this.AddDataBaseBtn.UseVisualStyleBackColor = true;
            this.AddDataBaseBtn.Click += new System.EventHandler(this.AddDataBaseBtn_Click);
            // 
            // DataBaseComBobox
            // 
            this.DataBaseComBobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBaseComBobox.FormattingEnabled = true;
            this.DataBaseComBobox.Location = new System.Drawing.Point(17, 34);
            this.DataBaseComBobox.Name = "DataBaseComBobox";
            this.DataBaseComBobox.Size = new System.Drawing.Size(242, 20);
            this.DataBaseComBobox.TabIndex = 0;
            this.DataBaseComBobox.SelectedIndexChanged += new System.EventHandler(this.DataBaseComBobox_SelectedIndexChanged);
            // 
            // LogRichText
            // 
            this.LogRichText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRichText.BackColor = System.Drawing.Color.Black;
            this.LogRichText.ForeColor = System.Drawing.Color.White;
            this.LogRichText.Location = new System.Drawing.Point(457, 71);
            this.LogRichText.Name = "LogRichText";
            this.LogRichText.ReadOnly = true;
            this.LogRichText.Size = new System.Drawing.Size(612, 580);
            this.LogRichText.TabIndex = 7;
            this.LogRichText.Text = "";
            this.LogRichText.TextChanged += new System.EventHandler(this.LogRichText_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbDebugtype5);
            this.groupBox4.Controls.Add(this.rbDebugtype4);
            this.groupBox4.Controls.Add(this.rbDebugtype3);
            this.groupBox4.Controls.Add(this.rbDebugtype2);
            this.groupBox4.Controls.Add(this.rbDebugtype1);
            this.groupBox4.Location = new System.Drawing.Point(457, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(612, 37);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "控制台输出";
            // 
            // rbDebugtype5
            // 
            this.rbDebugtype5.AutoSize = true;
            this.rbDebugtype5.Location = new System.Drawing.Point(145, 15);
            this.rbDebugtype5.Name = "rbDebugtype5";
            this.rbDebugtype5.Size = new System.Drawing.Size(71, 16);
            this.rbDebugtype5.TabIndex = 4;
            this.rbDebugtype5.TabStop = true;
            this.rbDebugtype5.Text = "紫色信息";
            this.rbDebugtype5.UseVisualStyleBackColor = true;
            this.rbDebugtype5.CheckedChanged += new System.EventHandler(this.OnDebugTypeChange);
            // 
            // rbDebugtype4
            // 
            this.rbDebugtype4.AutoSize = true;
            this.rbDebugtype4.Location = new System.Drawing.Point(495, 15);
            this.rbDebugtype4.Name = "rbDebugtype4";
            this.rbDebugtype4.Size = new System.Drawing.Size(71, 16);
            this.rbDebugtype4.TabIndex = 3;
            this.rbDebugtype4.TabStop = true;
            this.rbDebugtype4.Text = "红色信息";
            this.rbDebugtype4.UseVisualStyleBackColor = true;
            this.rbDebugtype4.CheckedChanged += new System.EventHandler(this.OnDebugTypeChange);
            // 
            // rbDebugtype3
            // 
            this.rbDebugtype3.AutoSize = true;
            this.rbDebugtype3.Location = new System.Drawing.Point(390, 15);
            this.rbDebugtype3.Name = "rbDebugtype3";
            this.rbDebugtype3.Size = new System.Drawing.Size(71, 16);
            this.rbDebugtype3.TabIndex = 2;
            this.rbDebugtype3.TabStop = true;
            this.rbDebugtype3.Text = "黄色信息";
            this.rbDebugtype3.UseVisualStyleBackColor = true;
            this.rbDebugtype3.CheckedChanged += new System.EventHandler(this.OnDebugTypeChange);
            // 
            // rbDebugtype2
            // 
            this.rbDebugtype2.AutoSize = true;
            this.rbDebugtype2.Location = new System.Drawing.Point(272, 15);
            this.rbDebugtype2.Name = "rbDebugtype2";
            this.rbDebugtype2.Size = new System.Drawing.Size(71, 16);
            this.rbDebugtype2.TabIndex = 1;
            this.rbDebugtype2.TabStop = true;
            this.rbDebugtype2.Text = "白色信息";
            this.rbDebugtype2.UseVisualStyleBackColor = true;
            this.rbDebugtype2.CheckedChanged += new System.EventHandler(this.OnDebugTypeChange);
            // 
            // rbDebugtype1
            // 
            this.rbDebugtype1.AutoSize = true;
            this.rbDebugtype1.Location = new System.Drawing.Point(44, 15);
            this.rbDebugtype1.Name = "rbDebugtype1";
            this.rbDebugtype1.Size = new System.Drawing.Size(71, 16);
            this.rbDebugtype1.TabIndex = 0;
            this.rbDebugtype1.TabStop = true;
            this.rbDebugtype1.Text = "所有信息";
            this.rbDebugtype1.UseVisualStyleBackColor = true;
            this.rbDebugtype1.CheckedChanged += new System.EventHandler(this.OnDebugTypeChange);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 693);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.LogRichText);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameTools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置数值文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新所有文件toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 刷新选中文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成选中我文件表结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入选中表数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemResOpe;
        private System.Windows.Forms.ToolStripMenuItem 生成Java资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成As资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成CS消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem 生成CS资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label DataBaseUserNameLabel;
        private System.Windows.Forms.Label DataBaseNameLabel;
        private System.Windows.Forms.Label DataBaseAddressLabel;
        private System.Windows.Forms.Button RemoveDataBaseBtn;
        private System.Windows.Forms.Button ModifyDataBaseBtn;
        private System.Windows.Forms.Button AddDataBaseBtn;
        private System.Windows.Forms.ComboBox DataBaseComBobox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CS单个文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CS单个文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单个AS文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单个AS文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单个Java文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单个Java文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportFromSqlItem;
        private System.Windows.Forms.ToolStripMenuItem GetTablesFromSql;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 单个文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 简转繁ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 繁转简ToolStripMenuItem;
        private System.Windows.Forms.RichTextBox LogRichText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem MenuItemJsonDecode;
        private System.Windows.Forms.ToolStripMenuItem MenuItemJsonEncode;
        private System.Windows.Forms.ToolStripMenuItem MenItemResCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDecodeResSingle;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDecodeResFolder;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAbout;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbDebugtype2;
        private System.Windows.Forms.RadioButton rbDebugtype1;
        private System.Windows.Forms.RadioButton rbDebugtype5;
        private System.Windows.Forms.RadioButton rbDebugtype4;
        private System.Windows.Forms.RadioButton rbDebugtype3;
        private System.Windows.Forms.ToolStripMenuItem miReadLoalDatabase;
        private System.Windows.Forms.Label lbDaLocalPosition;
        private System.Windows.Forms.Label labelSelectNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAllNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelThreadNum;
    }
}

