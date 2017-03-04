namespace iPhoneTrackingCleanse
{
    partial class frmMain
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
            this.cmbRoot = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.pbScan = new System.Windows.Forms.ProgressBar();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnCleanse = new System.Windows.Forms.Button();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCleanse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelScan = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRoot
            // 
            this.cmbRoot.FormattingEnabled = true;
            this.cmbRoot.Location = new System.Drawing.Point(78, 36);
            this.cmbRoot.Name = "cmbRoot";
            this.cmbRoot.Size = new System.Drawing.Size(353, 21);
            this.cmbRoot.TabIndex = 1;
            this.cmbRoot.Text = "D:\\iPhoneTrackingCleanseTestDir";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(437, 34);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(84, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "&Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(11, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(61, 21);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dlgFolder
            // 
            this.dlgFolder.Description = "Select Apple Directory";
            this.dlgFolder.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            this.dlgFolder.ShowNewFolderButton = false;
            // 
            // pbScan
            // 
            this.pbScan.Location = new System.Drawing.Point(10, 63);
            this.pbScan.Name = "pbScan";
            this.pbScan.Size = new System.Drawing.Size(511, 16);
            this.pbScan.TabIndex = 5;
            // 
            // lstFiles
            // 
            this.lstFiles.ForeColor = System.Drawing.Color.Red;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(10, 85);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFiles.Size = new System.Drawing.Size(511, 95);
            this.lstFiles.TabIndex = 3;
            // 
            // btnCleanse
            // 
            this.btnCleanse.Enabled = false;
            this.btnCleanse.Location = new System.Drawing.Point(10, 186);
            this.btnCleanse.Name = "btnCleanse";
            this.btnCleanse.Size = new System.Drawing.Size(110, 43);
            this.btnCleanse.TabIndex = 4;
            this.btnCleanse.Text = "&Cleanse";
            this.btnCleanse.UseVisualStyleBackColor = true;
            this.btnCleanse.Click += new System.EventHandler(this.btnCleanse_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(535, 24);
            this.mnuMain.TabIndex = 6;
            this.mnuMain.Text = "MainMenu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBrowse,
            this.mnuScan,
            this.mnuCleanse,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuBrowse
            // 
            this.mnuBrowse.Name = "mnuBrowse";
            this.mnuBrowse.Size = new System.Drawing.Size(112, 22);
            this.mnuBrowse.Text = "&Browse";
            this.mnuBrowse.Click += new System.EventHandler(this.mnuBrowse_Click);
            // 
            // mnuScan
            // 
            this.mnuScan.Name = "mnuScan";
            this.mnuScan.Size = new System.Drawing.Size(112, 22);
            this.mnuScan.Text = "&Scan";
            this.mnuScan.Click += new System.EventHandler(this.mnuScan_Click);
            // 
            // mnuCleanse
            // 
            this.mnuCleanse.Name = "mnuCleanse";
            this.mnuCleanse.Size = new System.Drawing.Size(112, 22);
            this.mnuCleanse.Text = "&Cleanse";
            this.mnuCleanse.Click += new System.EventHandler(this.mnuCleanse_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(112, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(103, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // btnCancelScan
            // 
            this.btnCancelScan.Enabled = false;
            this.btnCancelScan.Location = new System.Drawing.Point(437, 35);
            this.btnCancelScan.Name = "btnCancelScan";
            this.btnCancelScan.Size = new System.Drawing.Size(84, 22);
            this.btnCancelScan.TabIndex = 1;
            this.btnCancelScan.Text = "Cancel";
            this.btnCancelScan.UseVisualStyleBackColor = true;
            this.btnCancelScan.Visible = false;
            this.btnCancelScan.Click += new System.EventHandler(this.btnCancelScan_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 239);
            this.Controls.Add(this.btnCancelScan);
            this.Controls.Add(this.btnCleanse);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.pbScan);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.cmbRoot);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "ZeroTracks BETA 1.1 (TechnicalSupport.ca) by ModsRUs.com";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRoot;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.ProgressBar pbScan;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnCleanse;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowse;
        private System.Windows.Forms.ToolStripMenuItem mnuCleanse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuScan;
        private System.Windows.Forms.Button btnCancelScan;
    }
}

