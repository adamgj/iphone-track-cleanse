using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;


namespace iPhoneTrackingCleanse
{
    public partial class frmMain : Form
    {
        private const string strVer = "BETA 1.1";
        private string backupDir = Application.StartupPath + @"\Backup";
        private string defaultDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Apple Computer\MobileSync\Backup";
        private bool doBackup = false;
        private const string strFSearch = "*.*";
        private const string strHeader = "SQLite";
        private const string strToFind = "CellLocation";
        readonly object stateLock = new object();
        private string strRoot;
        private string curFName = "";
        private List<string> lstFNames = new List<string>();
        private List<string> lstTrackFiles = new List<string>();
        private const string credit = "by Adam Jones";
        private Thread workThread;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            BeginScan();
        }

        private void BeginScan()
        {
            if (Directory.Exists(cmbRoot.Text) == false)
            {
                MessageBox.Show("Error: Directory does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DisableUI();
            btnCancelScan.Enabled = true;
            btnCancelScan.Visible = btnCancelScan.Enabled;
            pbScan.Value = 0;
            lstFiles.Items.Clear();
            lstFNames.Clear();
            lstFiles.ForeColor = Color.Red;
            lstTrackFiles.Clear();
            lock (stateLock)
            {
                strRoot = cmbRoot.Text;
                curFName = "";
            }
            ThreadStart scanThreadStart = new ThreadStart(ScanJob);
            lock (stateLock)
            {
                workThread = new Thread(scanThreadStart);
            }
            workThread.IsBackground = true;
            workThread.Start();
        }

        private void DisableUI()
        {
            btnScan.Enabled = false;
            btnBrowse.Enabled = false;
            btnCleanse.Enabled = false;
            mnuScan.Enabled = false;
            mnuBrowse.Enabled = false;
            mnuCleanse.Enabled = false;
            mnuExit.Enabled = false;
            cmbRoot.Enabled = false;
        }

        private void EnableUI()
        {
            btnScan.Enabled = true;
            btnBrowse.Enabled = true;
            mnuScan.Enabled = true;
            mnuBrowse.Enabled = true;
            mnuExit.Enabled = true;
            cmbRoot.Enabled = true;
            if (lstFiles.Items.Count > 0)
            {
                mnuCleanse.Enabled = true;
                btnCleanse.Enabled = true;
            }
        }

        private void CompleteScan()
        {
            pbScan.Value = pbScan.Maximum;
            MessageBox.Show("Scan Complete!","Complete",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnCancelScan.Enabled = false;
            btnCancelScan.Visible = btnCancelScan.Enabled;
            EnableUI();

        }

        private void ScanJob()
        {
            MethodInvoker setupPB = new MethodInvoker(SetupPB);
            string strLocalRoot;
            lock (stateLock)
            {
                strLocalRoot = strRoot;
            }
            DirectoryInfo dirIRoot = new DirectoryInfo(strLocalRoot);
            RecursiveDirScan(dirIRoot);
            Invoke(setupPB);
            ScanFiles();
            Invoke(new MethodInvoker(CompleteScan));
        }

        private void SetupPB()
        {
            pbScan.Maximum = lstFNames.Count+1;
            pbScan.Step = 1;
            pbScan.PerformStep();
        }

        private void RecursiveDirScan(DirectoryInfo dirInfo)
        {
            if (dirInfo.Exists == false)
                return;

            DirectoryInfo[] curDirISubs = dirInfo.GetDirectories();
            foreach (FileInfo fInfo in dirInfo.GetFiles(strFSearch))
            {
                lstFNames.Add(fInfo.FullName);
            }
            foreach (DirectoryInfo curDirI in curDirISubs)
            {
                RecursiveDirScan(curDirI);
            }
        }

        private void ScanFiles()
        {
            MethodInvoker updateProgress = new MethodInvoker(UpdateProgress);
            MethodInvoker addFile = new MethodInvoker(AddFile);
            List<string> fNames;
            lock (stateLock)
            {
                fNames = lstFNames;
            }
            foreach (string curLocalFName in fNames)
            {
                if (containsValidData(curLocalFName) == true)
                {
                    lock (stateLock)
                    {
                        curFName = curLocalFName;
                    }
                    Invoke(addFile);
                }
                Invoke(updateProgress);
            }
        }

        private bool containsValidData(string curLocalFName)
        {
            if (File.Exists(curLocalFName) == false)
                return false;

            FileInfo curFInfo = new FileInfo(curLocalFName);
            Stream fStream = null;
            try
            {
                fStream = curFInfo.OpenRead();
            }
            catch
            {
                MessageBox.Show("Error: Could not read file: " + curLocalFName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            BinaryReader bReader = new BinaryReader(fStream);

            string localStrHeader;
            lock (stateLock)
            {
                localStrHeader = strHeader;
            }
            char[] headerTest;
            try
            {
                headerTest = bReader.ReadChars(localStrHeader.Length);
            }
            catch
            {
                return false;
            }
            if (String.Compare(new string(headerTest), localStrHeader) != 0)
                return false;

            int strLen;
            lock (stateLock)
            {
                strLen = strToFind.Length;
            }
            long pos = 0;
            byte[] previous = bReader.ReadBytes(strLen);

            for (long i = bReader.BaseStream.Position; i < fStream.Length; i++)
            {
                byte current = bReader.ReadByte();
                previous[pos++ % strLen] = current;

                bool isValidStr = true;
                for (int j = 0; j < strLen; j++)
                {
                    if (previous[(pos + j) % strLen] != strToFind[j])
                    {
                        isValidStr = false;
                    }
                }
                if (isValidStr == true)
                    return true;
            }

            return false;
        }

        private void AddFile()
        {
            string curLocalFName;
            lock (stateLock)
            {
                curLocalFName = curFName;
            }
            lstFiles.Items.Add(Path.GetFileName(curLocalFName));
            lstTrackFiles.Add(curLocalFName);
        }

        private void UpdateProgress()
        {
            pbScan.PerformStep();
        }

        private void BrowseFolders()
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
                cmbRoot.Text = dlgFolder.SelectedPath;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolders();
        }

        private void btnCleanse_Click(object sender, EventArgs e)
        {
            BeginCleanse();
        }

        private void BeginCleanse()
        {
            DisableUI();
            pbScan.Value = 0;
            ThreadStart cleanseThreadStart = new ThreadStart(CleanseJob);
            Thread cleanseThread = new Thread(cleanseThreadStart);
            cleanseThread.IsBackground = true;
            cleanseThread.Start();
        }

        private void CleanseJob()
        {
            MethodInvoker setupPB = new MethodInvoker(SetupPB);
            MethodInvoker updateProgress = new MethodInvoker(UpdateProgress);
            Invoke(setupPB);

            foreach (string strLocalCurFile in lstTrackFiles)
            {
                try
                {
                    if (File.Exists(strLocalCurFile))
                    {
                        if (doBackup == true)
                        {
                            if (Directory.Exists(backupDir) == false)
                                Directory.CreateDirectory(backupDir);
                            File.Move(strLocalCurFile, backupDir + Path.GetFileName(strLocalCurFile));
                        }
                        else
                            File.Delete(strLocalCurFile);
                        File.Create(strLocalCurFile);
                        /*Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("iPhoneTrackingCleanse.dummyConsolidated");
                        FileStream fileStream = new FileStream(strLocalCurFile, FileMode.CreateNew);
                        int iB =-1;
                        do
                        {
                            iB = stream.ReadByte();
                            fileStream.WriteByte((byte)iB);
                        } while (iB != -1);
                        fileStream.Close();*/

                        Invoke(updateProgress);
                    }
                    else
                        MessageBox.Show("Error: Could not find file " + strLocalCurFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Error: Could not access file " + strLocalCurFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Invoke(new MethodInvoker(CompleteCleanse));
        }

        private void CompleteCleanse()
        {
            pbScan.Value = pbScan.Maximum;
            lstFiles.ForeColor = Color.Green;
            MessageBox.Show("Cleanse Complete!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EnableUI();
            btnCleanse.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setAppleBackupDir();
        }

        private void setAppleBackupDir()
        {
            cmbRoot.Text = defaultDir;
            cmbRoot.Items.Add(defaultDir);
            if (Directory.Exists(defaultDir) == false)
                MessageBox.Show("Error: Could not detect Apple Backup directory","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void mnuBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolders();
        }

        private void mnuCleanse_Click(object sender, EventArgs e)
        {
            BeginCleanse();
        }

        private void mnuScan_Click(object sender, EventArgs e)
        {
            BeginScan();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName+" "+strVer+"\n\tby ModsRUs.com\n\n\tTechnicalSupport.ca","About",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void StopWorkThread()
        {
            workThread.Abort();
        }

        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            //workThread.Suspend();
            if (MessageBox.Show("Are you sure you would like to cancel a scan in progress?", "Cancel scan?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                //workThread.Resume();
                return;
            }
            StopWorkThread();
            btnCancelScan.Enabled = false;
            btnCancelScan.Visible = btnCancelScan.Enabled;
            EnableUI();
        }
    }
}
