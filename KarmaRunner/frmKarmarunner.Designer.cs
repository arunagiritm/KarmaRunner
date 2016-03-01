namespace KarmaRunner
{
    partial class frmKarmarunner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKarmarunner));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.karmaConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requireJsConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSourceDir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtErrResult = new System.Windows.Forms.RichTextBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.chkListFullPath = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestdir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTestDir = new System.Windows.Forms.Button();
            this.txtLibDir = new System.Windows.Forms.TextBox();
            this.pnlUnitTest = new System.Windows.Forms.Panel();
            this.btnUTResults = new System.Windows.Forms.Button();
            this.btnCoverage = new System.Windows.Forms.Button();
            this.btnLibdir = new System.Windows.Forms.Button();
            this.txtProjDir = new System.Windows.Forms.TextBox();
            this.btnProjDir = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoadFolder = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.btnClearError = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateTree = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkLoadFolder = new System.Windows.Forms.CheckBox();
            this.addSpecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSpecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnCloseConfig = new System.Windows.Forms.Button();
            this.btnCancelConfig = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.rtbConfig = new System.Windows.Forms.RichTextBox();
            this.cmbRunner = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.pnlUnitTest.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1177, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.karmaConfigToolStripMenuItem,
            this.requireJsConfigToolStripMenuItem,
            this.applicationConfigToolStripMenuItem});
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.cToolStripMenuItem.Text = "Configuration";
            // 
            // karmaConfigToolStripMenuItem
            // 
            this.karmaConfigToolStripMenuItem.Name = "karmaConfigToolStripMenuItem";
            this.karmaConfigToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.karmaConfigToolStripMenuItem.Text = "Karma Config";
            this.karmaConfigToolStripMenuItem.Click += new System.EventHandler(this.karmaConfigToolStripMenuItem_Click);
            // 
            // requireJsConfigToolStripMenuItem
            // 
            this.requireJsConfigToolStripMenuItem.Name = "requireJsConfigToolStripMenuItem";
            this.requireJsConfigToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.requireJsConfigToolStripMenuItem.Text = "RequireJs Config";
            this.requireJsConfigToolStripMenuItem.Click += new System.EventHandler(this.requireJsConfigToolStripMenuItem_Click);
            // 
            // applicationConfigToolStripMenuItem
            // 
            this.applicationConfigToolStripMenuItem.Name = "applicationConfigToolStripMenuItem";
            this.applicationConfigToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.applicationConfigToolStripMenuItem.Text = "Application Config";
            this.applicationConfigToolStripMenuItem.Click += new System.EventHandler(this.applicationConfigToolStripMenuItem_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(596, 69);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(565, 325);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "";
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Enabled = false;
            this.txtSourceDir.Location = new System.Drawing.Point(418, 32);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(123, 20);
            this.txtSourceDir.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Source Base Path";
            // 
            // btnSourceDir
            // 
            this.btnSourceDir.Location = new System.Drawing.Point(559, 32);
            this.btnSourceDir.Name = "btnSourceDir";
            this.btnSourceDir.Size = new System.Drawing.Size(25, 20);
            this.btnSourceDir.TabIndex = 9;
            this.btnSourceDir.Text = "...";
            this.btnSourceDir.UseVisualStyleBackColor = true;
            this.btnSourceDir.Click += new System.EventHandler(this.btnSourceDir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = " ";
            this.openFileDialog1.Filter = "JS files|*.js;*.json";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtErrResult
            // 
            this.txtErrResult.ForeColor = System.Drawing.Color.Red;
            this.txtErrResult.Location = new System.Drawing.Point(596, 406);
            this.txtErrResult.Name = "txtErrResult";
            this.txtErrResult.Size = new System.Drawing.Size(565, 104);
            this.txtErrResult.TabIndex = 10;
            this.txtErrResult.Text = "";
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(10, 69);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(180, 381);
            this.lstFiles.TabIndex = 11;
            this.lstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFiles_KeyDown);
            this.lstFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDown);
            // 
            // chkListFullPath
            // 
            this.chkListFullPath.AutoSize = true;
            this.chkListFullPath.Location = new System.Drawing.Point(13, 460);
            this.chkListFullPath.Name = "chkListFullPath";
            this.chkListFullPath.Size = new System.Drawing.Size(97, 17);
            this.chkListFullPath.TabIndex = 13;
            this.chkListFullPath.Text = "Show Full Path";
            this.chkListFullPath.UseVisualStyleBackColor = true;
            this.chkListFullPath.CheckedChanged += new System.EventHandler(this.chkListFullPath_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Spec Files List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(601, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Execution Result";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Execution Errors";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(196, 69);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(371, 441);
            this.treeView1.TabIndex = 18;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Specs List";
            // 
            // txtTestdir
            // 
            this.txtTestdir.Enabled = false;
            this.txtTestdir.Location = new System.Drawing.Point(700, 32);
            this.txtTestdir.Name = "txtTestdir";
            this.txtTestdir.Size = new System.Drawing.Size(123, 20);
            this.txtTestdir.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Test Base Path";
            // 
            // btnTestDir
            // 
            this.btnTestDir.Location = new System.Drawing.Point(841, 32);
            this.btnTestDir.Name = "btnTestDir";
            this.btnTestDir.Size = new System.Drawing.Size(25, 20);
            this.btnTestDir.TabIndex = 21;
            this.btnTestDir.Text = "...";
            this.btnTestDir.UseVisualStyleBackColor = true;
            this.btnTestDir.Click += new System.EventHandler(this.btnTestDir_Click);
            // 
            // txtLibDir
            // 
            this.txtLibDir.Enabled = false;
            this.txtLibDir.Location = new System.Drawing.Point(966, 32);
            this.txtLibDir.Name = "txtLibDir";
            this.txtLibDir.Size = new System.Drawing.Size(123, 20);
            this.txtLibDir.TabIndex = 22;
            // 
            // pnlUnitTest
            // 
            this.pnlUnitTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUnitTest.Controls.Add(this.btnUTResults);
            this.pnlUnitTest.Controls.Add(this.btnCoverage);
            this.pnlUnitTest.Location = new System.Drawing.Point(460, 516);
            this.pnlUnitTest.Name = "pnlUnitTest";
            this.pnlUnitTest.Size = new System.Drawing.Size(257, 33);
            this.pnlUnitTest.TabIndex = 32;
            // 
            // btnUTResults
            // 
            this.btnUTResults.Location = new System.Drawing.Point(13, 5);
            this.btnUTResults.Name = "btnUTResults";
            this.btnUTResults.Size = new System.Drawing.Size(106, 23);
            this.btnUTResults.TabIndex = 3;
            this.btnUTResults.Text = "Unit Test Report";
            this.btnUTResults.UseVisualStyleBackColor = true;
            this.btnUTResults.Click += new System.EventHandler(this.btnUTResults_Click);
            // 
            // btnCoverage
            // 
            this.btnCoverage.Location = new System.Drawing.Point(136, 5);
            this.btnCoverage.Name = "btnCoverage";
            this.btnCoverage.Size = new System.Drawing.Size(99, 23);
            this.btnCoverage.TabIndex = 28;
            this.btnCoverage.Text = "Coverage Report";
            this.btnCoverage.UseVisualStyleBackColor = true;
            this.btnCoverage.Click += new System.EventHandler(this.btnCoverage_Click);
            // 
            // btnLibdir
            // 
            this.btnLibdir.Location = new System.Drawing.Point(1107, 32);
            this.btnLibdir.Name = "btnLibdir";
            this.btnLibdir.Size = new System.Drawing.Size(25, 20);
            this.btnLibdir.TabIndex = 24;
            this.btnLibdir.Text = "...";
            this.btnLibdir.UseVisualStyleBackColor = true;
            this.btnLibdir.Click += new System.EventHandler(this.btnLibdir_Click);
            // 
            // txtProjDir
            // 
            this.txtProjDir.Location = new System.Drawing.Point(123, 32);
            this.txtProjDir.Name = "txtProjDir";
            this.txtProjDir.Size = new System.Drawing.Size(123, 20);
            this.txtProjDir.TabIndex = 25;
            this.txtProjDir.TextChanged += new System.EventHandler(this.txtProjDir_TextChanged);
            this.txtProjDir.Leave += new System.EventHandler(this.txtProjDir_Leave);
            // 
            // btnProjDir
            // 
            this.btnProjDir.Location = new System.Drawing.Point(264, 32);
            this.btnProjDir.Name = "btnProjDir";
            this.btnProjDir.Size = new System.Drawing.Size(25, 20);
            this.btnProjDir.TabIndex = 27;
            this.btnProjDir.Text = "...";
            this.btnProjDir.UseVisualStyleBackColor = true;
            this.btnProjDir.Click += new System.EventHandler(this.btnProjDir_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnClearList);
            this.panel4.Controls.Add(this.btnLoad);
            this.panel4.Controls.Add(this.btnLoadFolder);
            this.panel4.Location = new System.Drawing.Point(15, 517);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 33);
            this.panel4.TabIndex = 31;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(6, 3);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(65, 23);
            this.btnClearList.TabIndex = 12;
            this.btnClearList.Text = "C&lear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(76, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "&Load Test File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoadFolder
            // 
            this.btnLoadFolder.Location = new System.Drawing.Point(77, 3);
            this.btnLoadFolder.Name = "btnLoadFolder";
            this.btnLoadFolder.Size = new System.Drawing.Size(95, 23);
            this.btnLoadFolder.TabIndex = 13;
            this.btnLoadFolder.Text = "&Load Test Folder";
            this.btnLoadFolder.UseVisualStyleBackColor = true;
            this.btnLoadFolder.Click += new System.EventHandler(this.btnLoadFolder_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnClearResult);
            this.panel3.Controls.Add(this.btnClearError);
            this.panel3.Location = new System.Drawing.Point(778, 516);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(366, 33);
            this.panel3.TabIndex = 31;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(254, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 23);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Ex&it";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(13, 5);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(106, 23);
            this.btnClearResult.TabIndex = 3;
            this.btnClearResult.Text = "Clear Result";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // btnClearError
            // 
            this.btnClearError.Location = new System.Drawing.Point(136, 5);
            this.btnClearError.Name = "btnClearError";
            this.btnClearError.Size = new System.Drawing.Size(99, 23);
            this.btnClearError.TabIndex = 28;
            this.btnClearError.Text = "Clear Error";
            this.btnClearError.UseVisualStyleBackColor = true;
            this.btnClearError.Click += new System.EventHandler(this.btnClearError_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(136, 5);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(99, 23);
            this.btnExecute.TabIndex = 28;
            this.btnExecute.Text = "E&xecute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCreateTree);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Location = new System.Drawing.Point(196, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 33);
            this.panel1.TabIndex = 29;
            // 
            // btnCreateTree
            // 
            this.btnCreateTree.Location = new System.Drawing.Point(13, 5);
            this.btnCreateTree.Name = "btnCreateTree";
            this.btnCreateTree.Size = new System.Drawing.Size(106, 23);
            this.btnCreateTree.TabIndex = 3;
            this.btnCreateTree.Text = "Create Spec Tree";
            this.btnCreateTree.UseVisualStyleBackColor = true;
            this.btnCreateTree.Click += new System.EventHandler(this.btnCreateTree_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(884, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Ext Lib Path";
            // 
            // chkLoadFolder
            // 
            this.chkLoadFolder.AutoSize = true;
            this.chkLoadFolder.Location = new System.Drawing.Point(107, 460);
            this.chkLoadFolder.Name = "chkLoadFolder";
            this.chkLoadFolder.Size = new System.Drawing.Size(82, 17);
            this.chkLoadFolder.TabIndex = 33;
            this.chkLoadFolder.Text = "Load Folder";
            this.chkLoadFolder.UseVisualStyleBackColor = true;
            this.chkLoadFolder.CheckedChanged += new System.EventHandler(this.chkLoadFolder_CheckedChanged);
            // 
            // addSpecToolStripMenuItem
            // 
            this.addSpecToolStripMenuItem.Name = "addSpecToolStripMenuItem";
            this.addSpecToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.addSpecToolStripMenuItem.Text = "Add Spec";
            this.addSpecToolStripMenuItem.Click += new System.EventHandler(this.addSpecToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSpecToolStripMenuItem,
            this.deleteSpecToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 92);
            // 
            // deleteSpecToolStripMenuItem
            // 
            this.deleteSpecToolStripMenuItem.Name = "deleteSpecToolStripMenuItem";
            this.deleteSpecToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteSpecToolStripMenuItem.Text = "Delete spec";
            this.deleteSpecToolStripMenuItem.Click += new System.EventHandler(this.deleteSpecToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Project Base Path";
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.btnFind);
            this.pnlConfig.Controls.Add(this.txtFind);
            this.pnlConfig.Controls.Add(this.btnCloseConfig);
            this.pnlConfig.Controls.Add(this.btnCancelConfig);
            this.pnlConfig.Controls.Add(this.btnSaveConfig);
            this.pnlConfig.Controls.Add(this.rtbConfig);
            this.pnlConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(1177, 549);
            this.pnlConfig.TabIndex = 34;
            this.pnlConfig.Visible = false;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(333, 445);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(116, 445);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(200, 20);
            this.txtFind.TabIndex = 4;
            // 
            // btnCloseConfig
            // 
            this.btnCloseConfig.Location = new System.Drawing.Point(1003, 445);
            this.btnCloseConfig.Name = "btnCloseConfig";
            this.btnCloseConfig.Size = new System.Drawing.Size(75, 23);
            this.btnCloseConfig.TabIndex = 3;
            this.btnCloseConfig.Text = "C&lose";
            this.btnCloseConfig.UseVisualStyleBackColor = true;
            this.btnCloseConfig.Click += new System.EventHandler(this.btnCloseConfig_Click);
            // 
            // btnCancelConfig
            // 
            this.btnCancelConfig.Location = new System.Drawing.Point(915, 445);
            this.btnCancelConfig.Name = "btnCancelConfig";
            this.btnCancelConfig.Size = new System.Drawing.Size(75, 23);
            this.btnCancelConfig.TabIndex = 2;
            this.btnCancelConfig.Text = "&Cancel";
            this.btnCancelConfig.UseVisualStyleBackColor = true;
            this.btnCancelConfig.Click += new System.EventHandler(this.btnCancelConfig_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(832, 445);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 1;
            this.btnSaveConfig.Text = "&Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // rtbConfig
            // 
            this.rtbConfig.Location = new System.Drawing.Point(12, 27);
            this.rtbConfig.Name = "rtbConfig";
            this.rtbConfig.Size = new System.Drawing.Size(1153, 395);
            this.rtbConfig.TabIndex = 0;
            this.rtbConfig.Text = "";
            // 
            // cmbRunner
            // 
            this.cmbRunner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRunner.FormattingEnabled = true;
            this.cmbRunner.Items.AddRange(new object[] {
            "Karma",
            "Jasmine"});
            this.cmbRunner.Location = new System.Drawing.Point(85, 483);
            this.cmbRunner.Name = "cmbRunner";
            this.cmbRunner.Size = new System.Drawing.Size(102, 21);
            this.cmbRunner.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 487);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Select Runner";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmKarmarunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 551);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.chkLoadFolder);
            this.Controls.Add(this.pnlUnitTest);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnProjDir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProjDir);
            this.Controls.Add(this.btnLibdir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLibDir);
            this.Controls.Add(this.btnTestDir);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTestdir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkListFullPath);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.txtErrResult);
            this.Controls.Add(this.btnSourceDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceDir);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmbRunner);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmKarmarunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karma Runner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlUnitTest.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem karmaConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requireJsConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationConfigToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSourceDir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox txtErrResult;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.CheckBox chkListFullPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTestdir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTestDir;
        private System.Windows.Forms.TextBox txtLibDir;
        private System.Windows.Forms.Panel pnlUnitTest;
        private System.Windows.Forms.Button btnUTResults;
        private System.Windows.Forms.Button btnCoverage;
        private System.Windows.Forms.Button btnLibdir;
        private System.Windows.Forms.TextBox txtProjDir;
        private System.Windows.Forms.Button btnProjDir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadFolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Button btnClearError;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateTree;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkLoadFolder;
        private System.Windows.Forms.ToolStripMenuItem addSpecToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSpecToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Button btnCloseConfig;
        private System.Windows.Forms.Button btnCancelConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.RichTextBox rtbConfig;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ComboBox cmbRunner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

