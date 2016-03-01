using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KarmaRunner.Helper;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Management;

namespace KarmaRunner
{
    public partial class frmKarmarunner : Form
    {
       public enum ConfigType
        {
            KARMA,
            REQUIREJS,
            APPLICATION
        }
        #region Properties
        public List<string> SpecFiles { get; set; }
        public string jsonTemplate { get; set; }
        public string basedir { get; set; }
        public string jsFiles { get; set; }
        public string inputjson { get; set; }
        public string createSpecJson { get; set; }
        public string jsuitejson { get; set; }
        public string buildTemplate { get; set; }
        public string buildInput { get; set; }
        public string buildOutput { get; set; }
        public string karmaBase { get; set; }
        public string karmaconfig { get; set; }
        public string karmaRequireconfig { get; set; }
        public string karmabat { get; set; }
        public string testExtn { get; set; }
        public string basePath { get; set; }
        public string sourcePath { get; set; }
        public string testPath { get; set; }
        public string libPath { get; set; }
        public string xmlReportFile { get; set; }
        public string htmlReportFile { get; set; }
        public string cobReportPath { get; set; }
        public string lcovReportPath { get; set; }
        public string browserFile { get; set; }
        public string serverBat { get; set; }
        public string serverFile { get; set; }
        public string jasmineBase { get; set; }
        public string jasmineRequireconfig { get; set; }
        public string jasminespecconfig { get; set; }
        public string specrunner { get; set; }
        public string baseUrl { get; set; }
        public ConfigType ConfigFile { get; set; }
        public string searchWord { get; set; }
        public Int32 searchIndex { get; set; }
        public StringBuilder sbResult { get; set; }
        public StringBuilder sbError { get; set; }

        public DataTable dt { get; set; }


        #endregion Properties

        #region Fields
        string dquotes = "\"";
        Process oProcess;

        Timer ProcessTimer;
        #endregion Fields

        #region public methods

        public frmKarmarunner()
        {
            InitializeComponent();
            ReadAppSettings();

            SpecFiles = new List<string>();
            dt = new DataTable();
            sbError = new StringBuilder();
            sbResult = new StringBuilder();

            cmbRunner.SelectedIndex = 0;
            txtProjDir.Text = @"D:\Arun\HTML5UI\HTML5UI\ProviderHome";
            //txtProjDir.Text = basePath;
            txtSourceDir.Text = sourcePath;
            txtTestdir.Text = testPath;
            txtLibDir.Text = libPath;
            moveToLast();

        }

        #endregion public Methods

        #region Private Methods

        private void ReadAppSettings()
        {
            basedir = AppDomain.CurrentDomain.BaseDirectory;
            jsonTemplate = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jsonTemplate"]);
            jsFiles = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jsfiles"]);
            inputjson = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["inputjson"]);
            createSpecJson = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["createSpecJson"]);
            jsuitejson = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jsuitejson"]);
            buildTemplate = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["buildTemplate"]);
            buildInput = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["buildInput"]);
            buildOutput = string.Format("{0}{1}", @"\", ConfigurationManager.AppSettings["buildOutput"]);
            karmaBase = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["karmaBase"]);
            karmaconfig = string.Format(@"{0}\{1}", buildInput, ConfigurationManager.AppSettings["karmaconfig"]);
            karmaRequireconfig = string.Format(@"{0}\{1}", buildInput, ConfigurationManager.AppSettings["karmaRequireconfig"]);
            karmabat = string.Format(@"{0}{1}", basedir, ConfigurationManager.AppSettings["karmabat"]);
            testExtn = ConfigurationManager.AppSettings["testExtn"];
            basePath = ConfigurationManager.AppSettings["basePath"];
            sourcePath = ConfigurationManager.AppSettings["sourcePath"];
            testPath = ConfigurationManager.AppSettings["testPath"];
            libPath = ConfigurationManager.AppSettings["libPath"];
            xmlReportFile = ConfigurationManager.AppSettings["xmlReportFile"];
            htmlReportFile = ConfigurationManager.AppSettings["htmlReportFile"];
            cobReportPath = ConfigurationManager.AppSettings["cobReportPath"];
            lcovReportPath = ConfigurationManager.AppSettings["lcovReportPath"];
            browserFile = ConfigurationManager.AppSettings["browserFile"];
            serverBat = string.Format(@"{0}\{1}", jasmineBase, ConfigurationManager.AppSettings["serverBat"]);
            serverFile = string.Format(@"{0}\{1}", jasmineBase, ConfigurationManager.AppSettings["serverFile"]);
            jasmineBase = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jasmineBase"]);
            jasmineRequireconfig = string.Format(@"{0}\{1}", buildInput, ConfigurationManager.AppSettings["jasmineRequireconfig"]);
            jasminespecconfig = string.Format(@"{0}\{1}", buildInput, ConfigurationManager.AppSettings["jasminespecconfig"]);
            specrunner = string.Format(@"{0}\{1}", buildInput, ConfigurationManager.AppSettings["specrunner"]);
            baseUrl = string.Format(@"{0}\{1}", basePath, ConfigurationManager.AppSettings["baseUrl"]);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateControls())
                {
                    openFileDialog1.InitialDirectory = txtTestdir.Text;
                    openFileDialog1.FileName = testExtn;
                    openFileDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a valid project path");
                    txtProjDir.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            AddSpecFiles(openFileDialog1.FileNames);
        }

        private void AddSpecFiles(string[] fileNames)
        {
            bool isAvl = false;
            string[] extArr = testExtn.Replace("*", "").Split(new char[] { ';' });
            foreach (string fname in fileNames)
            {

                if (SpecFiles.Where(f => f.Equals(fname)).Count() <= 0 && extArr.Where(fn => fname.EndsWith(fn)).Count() > 0)
                {
                    SpecFiles.Add(fname);
                }
                else
                {
                    isAvl = true;
                    SpecFiles.Add(fname);
                }

            }
            if (isAvl)
            {
                MessageBox.Show(string.Format("{0}{3}{1}{3}{2}",
                                                            "Some of the files are not added ",
                                                            "1. It is already available in the list",
                                                            "2. Or the selected file is not a spec file",
                                                            Environment.NewLine));
            }

            //SpecFiles.AddRange(openFileDialog1.FileNames);
            chkListFullPath_CheckedChanged(chkListFullPath, new EventArgs());
        }

        private void ExecuteNodeProcess()
        {
            btnExecute.Enabled = false;
            btnClearResult_Click(btnClearResult, new EventArgs { });
            //btnClearError_Click(btnClearError, new EventArgs { });
            Stoptimer();
            ProcessTimer = new Timer();
            ProcessTimer.Interval = 100;
            ProcessTimer.Tick += t_Tick;
            ProcessTimer.Enabled = true;
            ProcessTimer.Start();
            ExecuteExternalProcess(createSpecJson);
            
        }

        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                if (txtResult.Text.Contains("sucessfully"))
                {
                    Stoptimer();
                    LogError("process exited normally");
                    
                    //txtErrResult.Text = "process exited normally";
                    ProcessCompleted();
                    btnExecute.Enabled = true;
                }
                else if (txtResult.Text.Contains("failed"))
                {
                    Stoptimer();
                    btnExecute.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Stoptimer();
                btnExecute.Enabled = true;
                MessageBox.Show(ex.Message);

            }


        }

        private void Stoptimer()
        {
            if (ProcessTimer != null)
            {
                ProcessTimer.Enabled = false;
                ProcessTimer.Stop();
                ProcessTimer = null;

            }

        }

        private void ExecuteExternalProcess(string filename, string args = "")
        {
            try
            {
                //sbError.Length = 0;
                //sbResult.Length = 0;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = false;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.FileName = filename;
                psi.CreateNoWindow = true;
                psi.Arguments = args;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                using (oProcess = Process.Start(psi))
                {
                    oProcess.EnableRaisingEvents = true;
                    oProcess.ErrorDataReceived += oProcess_ErrorDataReceived;
                    oProcess.BeginErrorReadLine();
                    oProcess.OutputDataReceived += oProcess_OutputDataReceived;
                    oProcess.BeginOutputReadLine();

                    //oProcess.WaitForExit();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void oProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            LogError(e.Data);
            
        }

        void oProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            LogInfo(e.Data);
            
        }

        delegate void SetTextCallback(string text, RichTextBox tb);

        private void SetText(string text, RichTextBox tb)
        {

            if (tb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, tb });
            }
            else
            {
                tb.Text = "";
                tb.Text = text;
                tb.Select(txtResult.TextLength, 0);
                tb.Focus();

            }
        }

        private void btnCreateTree_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validateControls())
                {
                    MessageBox.Show("Check all mandatory fields are entered.");
                    return;
                }
                StringBuilder sb = new StringBuilder();
                Int32 lcount = 1;
                //open the template file for creating the input json file
                string jsonContent = KarmaRunnerHelper.OpenFileSharedMode(jsonTemplate);
                string jcontemp;
                treeView1.Nodes.Clear();
                if (lstFiles.Items.Count == 0)
                {
                    MessageBox.Show("No Spec files are selected.");
                    return;
                }
                foreach (string sp in SpecFiles)
                {
                    jcontemp = string.Format("{2}{0}{2}{1}", sp.Replace(@"\", @"\\"), (lcount == SpecFiles.Count) ? "" : ",", dquotes);
                    sb.AppendLine(jcontemp);
                    lcount++;
                }
                jsonContent = string.Format(jsonContent, "{", "}", sb.ToString());

                File.WriteAllText(inputjson, jsonContent);

                //Execute the batch file which will use the input json for processing  and create json file to build tree.
                ExecuteNodeProcess();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateKarmaconfig()
        {
            
            string filePattern = @"{0}pattern: '{2}',included: false{1},";
            string fileContent, sfile, outfile, outDir, reqInfile, reqOutfile, fileExclusion,bldout;
            StringBuilder sb = new StringBuilder();
            fileContent = File.ReadAllText(karmaconfig);
            LogInfo("started updating karma configuration file");
            //LogInfo("Updating " + karmaconfig +" file ...");
            foreach (string spec in SpecFiles)
            {
                sfile = spec.Replace(txtProjDir.Text + @"\", "").Replace(@"\", "/");
                sfile = string.Format(filePattern, "{", "}", sfile);
                sb.AppendLine(sfile);
            }

            outfile = string.Format("{0}{1}", txtProjDir.Text, karmaconfig.Replace(buildInput, buildOutput));
            outDir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }
            fileContent = fileContent.Replace("{specsPlaceholder}", sb.ToString());
            
            //strAppend=createPrefix(txtProjDir.Text, baseUrl);
            bldout = buildOutput.Substring(1).Replace(@"\", @"/");
            fileContent = fileContent.Replace(@"{vendorPlaceholder}", libPath.Replace(basePath + @"\", @"").Replace(@"\", @"/"));
            fileContent = fileContent.Replace(@"{basePathPlaceholder}", createPrefix(txtProjDir.Text,Path.GetDirectoryName(outfile)));
            fileContent = fileContent.Replace(@"{karmaRequireConfigPlaceholder}", string.Format(@"{0}\{1}", bldout, Path.GetFileName(karmaRequireconfig)).Replace(@"\", @"/"));
            fileExclusion = string.Format("'{1}',{0}'{2}'", Environment.NewLine, string.Format(@"{0}\{1}", bldout, Path.GetFileName(karmaconfig)), string.Format(@"{0}\{1}", bldout, Path.GetFileName(jasmineRequireconfig)));
            fileExclusion = fileExclusion.Replace(@"\", "/");
            fileContent = fileContent.Replace(@"{excludePlaceholder}", fileExclusion);
            
            //update report path
            fileContent = fileContent.Replace(@"{junitReporterPlaceholder}", xmlReportFile.Replace(@"\", @"/"));
            fileContent = fileContent.Replace(@"{htmlReporterPlaceholder}", htmlReportFile.Replace(@"\", @"/"));
            fileContent = fileContent.Replace(@"{coberturaPlaceholder}", cobReportPath.Replace(@"\", @"/"));
            fileContent = fileContent.Replace(@"{lcovPlaceholder}", lcovReportPath.Replace(@"\", @"/"));

            File.WriteAllText(outfile, fileContent);

            //LogInfo("sucessfully updated " + karmaconfig + " file.");

            //LogInfo("Updating " + karmaRequireconfig + " file ...");
            //update karma requireconfig placeholders
            reqInfile = string.Format(@"{0}\{1}", buildInput, "karmaRequireConfig.js");
            reqOutfile = string.Format(@"{0}\{1}", outDir, "karmaRequireConfig.js");
            fileContent = File.ReadAllText(reqInfile);

            fileContent = fileContent.Replace(@"{vendorPlaceholder}", createPrefix(txtProjDir.Text, baseUrl) + libPath.Replace(basePath + @"\", @"").Replace(@"\", @"/"));
            fileContent = fileContent.Replace(@"{baseUrlPlaceholder}", baseUrl.Replace(basePath + @"\", @"/base/").Replace(@"\", @"/"));

            File.WriteAllText(reqOutfile, fileContent);
            //LogInfo("sucessfully updated " + karmaRequireconfig + " file.");

            LogInfo("Sucessfully updated karma configuration file");
            
        }

        private string createPrefix(string p1, string p2)
        {
            string strAppend = string.Empty; //intialize this
            Int32 projDepth = KarmaRunnerHelper.DirDepth(p1, p2);
            strAppend = strAppend.Replicate(@"../", projDepth);
            return strAppend;
        }

        private void ProcessCompleted()
        {
            string jsuite;
            Int32 rootNode;
            try
            {
                jsuite = File.ReadAllText(jsuitejson);
                List<JsuiteSchema> jschema = JsonConvert.DeserializeObject<List<JsuiteSchema>>(jsuite);

                //dt.Rows.Clear();
                LogInfo("Started building Tree view");
                
                dt = new DataTable();
                foreach (JsuiteSchema js in jschema)
                {

                    DataColumn dc = new DataColumn("specfile");
                    js.suite.PrimaryKey = new DataColumn[] { js.suite.Columns["Id"] };
                    dc.DefaultValue = js.file;
                    js.suite.Columns.Add(dc);
                    dt.Merge(js.suite);
                    if (js.suite.Rows.Count > 0)
                    {
                        rootNode = Convert.ToInt32(js.suite.Rows[0]["ParentId"].ToString());
                        KarmaRunnerHelper.CreateTreeView(treeView1, js.suite, rootNode);
                        treeView1.CollapseAll();
                    }
                }
                LogInfo("Sucessfully created Tree view");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSpecFiles()
        {
            string[] fileContent;
            string filterExp = "specfile='{0}' and Active=false";
            Int32 rindex;
            DataRow[] drows;
            SpecDetails sdetails = new SpecDetails();
            LogInfo("Started updating Spec files");
            
            foreach (string spec in SpecFiles)
            {
                fileContent = File.ReadAllLines(spec);
                //Enable all specs by modifying all the describe and it statement 
                for (int r = 0; r < fileContent.Length; r++)
                {
                    fileContent[r] = Regex.Replace(fileContent[r], @"\bxdescribe\b", "describe");
                    fileContent[r] = Regex.Replace(fileContent[r], @"\bxit\b", "it");
                }

                drows = dt.Select(string.Format(filterExp, spec));
                foreach (DataRow drow in drows)
                {
                    sdetails.Node = drow["Node"].ToString();
                    sdetails.Type = drow["Type"].ToString();

                    rindex = Array.FindIndex(fileContent, fi => fi.Contains(sdetails.Node));
                    if (rindex >= 0)
                    {
                        if (sdetails.Type.ToLower() == "suite")
                        {
                            string innerfilter = "ParentId={0} and Active=true";
                            DataRow[] drs = dt.Select(string.Format(innerfilter, drow["Id"]));
                            if (drs.Count() <=0 )
                            {
                                fileContent[rindex] = Regex.Replace(fileContent[rindex], @"\bdescribe\b", "xdescribe");
                            }
                            
                        }
                        else if (sdetails.Type.ToLower() == "spec")
                        {
                            fileContent[rindex] = Regex.Replace(fileContent[rindex], @"\bit\b", "xit");
                        }
                    }
                }
                //File.WriteAllText(spec, fileContent);
                File.WriteAllLines(spec, fileContent);


            }
            LogInfo("Sucessfully updated Spec files");
            
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            SpecFiles.Clear();
            chkListFullPath_CheckedChanged(chkListFullPath, new EventArgs());
            dt = null;
            treeView1.Nodes.Clear();

        }

        private void chkListFullPath_CheckedChanged(object sender, EventArgs e)
        {
            lstFiles.DataSource = null;
            lstFiles.Items.Clear();
            if (chkListFullPath.Checked)
            {
                lstFiles.DataSource = SpecFiles;
            }
            else
            {

                foreach (string spec in SpecFiles)
                {
                    lstFiles.Items.Add(Path.GetFileName(spec));
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Int32 rowid;
            DataRow dtrow;
            rowid = Convert.ToInt32(e.Node.Tag);
            dtrow = dt.Rows.Find(rowid);
            dtrow["Active"] = e.Node.Checked;
            foreach (TreeNode childnode in e.Node.Nodes)
            {
                childnode.Checked = e.Node.Checked;
                rowid = Convert.ToInt32(childnode.Tag);
                dtrow = dt.Rows.Find(rowid);
                //dt.Rows[rowid - 1]["Active"] = e.Node.Checked;
                dtrow["Active"] = e.Node.Checked;
            }
        }

        private void lstFiles_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete && lstFiles.SelectedItem != null)
                {
                    DeleteSelectedSpecs();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteSelectedSpecs()
        {
            string selectedItem;
            if (MessageBox.Show("Do you want to remove this item ?", "Remove Item", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = lstFiles.SelectedItems.Count - 1; i >= 0; i--)
                {
                    selectedItem = lstFiles.SelectedItems[i].ToString();
                    SpecFiles.Remove(SpecFiles.Find(f => f.Contains(selectedItem)));
                    lstFiles.Items.Remove(lstFiles.SelectedItems[i]);
                }
                if (treeView1.Nodes.Count >0)
                {
                    btnCreateTree_Click(btnCreateTree, new EventArgs { });    
                }
                
            }
        }

        private void moveToLast()
        {
            Boolean pathExists = true;
            TextBox[] tboxes = new TextBox[] { txtProjDir, txtSourceDir, txtTestdir, txtLibDir };
            foreach (TextBox tbox in tboxes)
            {
                tbox.Select(tbox.Text.Length + 1, 0);
                if (!Directory.Exists(tbox.Text))
                {
                    pathExists = false;
                    break;
                }
            }
            if (!pathExists)
            {
                MessageBox.Show("Some of the Path is incorrect. The Source, Spec & Lib path should be relative to the Base path");
            }

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count > 0  && validateControls())
                {
                    pnlUnitTest.Visible = false;
                    //sbError.Length = 0;
                    //sbResult.Length = 0;
                    
                    if (cmbRunner.Text=="Karma")
                    {
                        ExecuteKarma();
                    }
                    else if(cmbRunner.Text=="Jasmine")
                    {
                        ExecuteJasmine();
                    }
                    
                    pnlUnitTest.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please create the tree view before this action.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ExecuteJasmine()
        {
            Updatejasmineconfig();
            UpdateSpecFiles();
            string args =Path.GetFileName(serverFile);
            string serfile = string.Format(@"{0}\{1}",basePath,args);
            string serbat = string.Format(@"{0}\{1}",basePath,Path.GetFileName(serverBat));
            Process[] ps;
            LogInfo("starting Jamines Execution");
            if (!File.Exists(serfile))
            {
                File.Copy(serverFile, serfile);
            }
            if (!File.Exists(serbat))
            {
               
                File.Copy(serverBat, serbat);
            }
            else
            {
                File.WriteAllText(serbat, File.ReadAllText(serverBat));
                
            }

            ps= Process.GetProcessesByName("node.exe");
            foreach (Process p in ps)
            {
                p.Kill();
            }
            //ExecuteExternalProcess(serbat, args);
            KarmaRunnerHelper.ExecuteProcess(serbat, args);

            while (true)
            {
                if (KarmaRunnerHelper.IsProcessRunning("Node.exe", args))
                {
                    LogInfo("Server is launched ...");
                    break;
                }
	
            }
            string spr = buildOutput.Substring(1)+@"\"+ Path.GetFileName(specrunner);
            ExecuteExternalProcess(browserFile, string.Format("{0}", "http://localhost:8050/" +spr).Replace(@"\", "/"));
        }

        private void Updatejasmineconfig()
        {
            string searchstr = "{specfiles}";
            string filePattern = @"specs.push('{0}');";
            string strAppend = string.Empty;
            string fileContent, sfile, outfile, outDir;
            StringBuilder sb = new StringBuilder();
            Int32 projDepth;

            fileContent = File.ReadAllText(jasminespecconfig);
            LogInfo("started updating jasmine configuration file");
            projDepth = KarmaRunnerHelper.DirDepth(txtProjDir.Text , txtProjDir.Text + buildOutput);
            strAppend=strAppend.Replicate(@"../", projDepth);

            foreach (string spec in SpecFiles)
            {

                sfile = spec.Replace(txtProjDir.Text + @"\", "").Replace(@"\", "/");
                sfile = strAppend + sfile;
                sfile = string.Format(filePattern, sfile);
                sb.AppendLine(sfile);
            }

            outfile = string.Format("{0}{1}", txtProjDir.Text, jasminespecconfig.Replace(buildInput, buildOutput));
            outDir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }
            fileContent = fileContent.Replace(searchstr, sb.ToString());

            LogInfo("updating jasmine spec configuration : " + outfile);
            

            File.WriteAllText(outfile, fileContent);

            //update specrunner.html for vendor placeholder
            outfile = string.Format("{0}{1}", txtProjDir.Text, specrunner.Replace(buildInput, buildOutput));
            strAppend = string.Empty; //intialize this
            projDepth = KarmaRunnerHelper.DirDepth(txtProjDir.Text, txtTestdir.Text);
            strAppend = strAppend.Replicate(@"../", projDepth);
            projDepth = KarmaRunnerHelper.DirDepth(txtProjDir.Text,Path.GetDirectoryName(outfile));
            strAppend = strAppend.Replicate(@"../", projDepth);
            fileContent = File.ReadAllText(specrunner);
            fileContent = fileContent.Replace("{vendor}", strAppend + libPath.Replace(basePath + @"\", @"").Replace(@"\", @"/"));

            LogInfo("updating jasmine spec runner file : " + outfile);
            

            File.WriteAllText(outfile, fileContent);
            
            //updatejasmineRequireConfig.js  for vendor placeholder
            outfile = string.Format("{0}{1}", txtProjDir.Text, jasmineRequireconfig.Replace(buildInput, buildOutput));
            fileContent = File.ReadAllText(jasmineRequireconfig);
            fileContent = fileContent.Replace("{vendor}", strAppend + libPath.Replace(basePath + @"\", @"").Replace(@"\", @"/"));
            strAppend = string.Empty; //intialize this
            projDepth = KarmaRunnerHelper.DirDepth(txtProjDir.Text, baseUrl);
            strAppend = strAppend.Replicate(@"../", projDepth);
            fileContent = fileContent.Replace("{baseUrl}", strAppend + baseUrl.Replace(basePath+@"\", @"").Replace(@"\", @"/"));
            LogInfo("updating jasmine require config  file : " + outfile);
            File.WriteAllText(outfile, fileContent);

            LogInfo("Sucessfully updated all jasmine files.");

           
        }

        private void LogError(string p)
        {
            sbError.AppendLine(p);
            SetText(sbError.ToString(), txtErrResult);
        }

        private void LogInfo(string p)
        {
            sbResult.AppendLine(p);
            SetText(sbResult.ToString(), txtResult);
            
        }

        private void ExecuteKarma()
        {
            try
            {
                UpdateKarmaconfig();
                UpdateSpecFiles();
                string outfile = string.Format("{0}{1}", txtProjDir.Text, karmaconfig.Replace(buildInput, buildOutput));
                string outdir = Path.GetDirectoryName(outfile);
                string args = string.Format("{0} {1}", outdir, outfile);
                LogInfo("starting Karma Execution");
                
                ExecuteExternalProcess(karmabat, args);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            sbError.Length = 0;
            txtErrResult.Text = "";
        }

        private void btnClearResult_Click(object sender, EventArgs e)
        {
            sbResult.Length = 0;
            txtResult.Text = "";
        }

        private void btnProjDir_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                txtProjDir.Text = folderBrowserDialog1.SelectedPath;
                setAllPath();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void setAllPath()
        {
            try
            {
                if (folderBrowserDialog1.SelectedPath != string.Empty)
                {
                    if (txtProjDir.Text != folderBrowserDialog1.SelectedPath)
                    {
                        txtProjDir.Text = Directory.GetParent(folderBrowserDialog1.SelectedPath).Name;

                    }

                    txtSourceDir.Text = string.Format(@"{0}\{1}", txtProjDir.Text, "src");
                    txtTestdir.Text = string.Format(@"{0}\{1}", txtProjDir.Text, "test");
                    txtLibDir.Text = string.Format(@"{0}\{1}", txtProjDir.Text, "vendor");
                    moveToLast();
                    KarmaRunnerHelper.WriteAppsettingToConfig("basePath", txtProjDir.Text);
                    KarmaRunnerHelper.WriteAppsettingToConfig("sourcePath", txtSourceDir.Text);
                    KarmaRunnerHelper.WriteAppsettingToConfig("testPath", txtTestdir.Text);
                    KarmaRunnerHelper.WriteAppsettingToConfig("libPath", txtLibDir.Text);
                    ReadAppSettings();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtProjDir_TextChanged(object sender, EventArgs e)
        {
            //btnProjDir_Click(btnProjDir, new EventArgs { });
            //setAllPath();
        }

        private void btnSourceDir_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                setAllPath();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestDir_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                setAllPath();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnLibdir_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                setAllPath();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUTResults_Click(object sender, EventArgs e)
        {
            try
            {
                
                string htmlfullPath = string.Format(@"{0}\{1}", txtProjDir.Text, htmlReportFile);
                LogInfo(string.Format("{0} {1}", "Opening the report file ", htmlfullPath));
                
                if (File.Exists(htmlfullPath))
                {
                    ExecuteExternalProcess(browserFile, string.Format("{0}{1}{0}", dquotes, htmlfullPath));
                }
                else
                {
                    MessageBox.Show("Report is not available at this time");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
            try
            {
                string lcovFullPath = string.Format(@"{0}\{1}", txtProjDir.Text, lcovReportPath);
                LogInfo(string.Format(@"{0} {1}\{2}", "Opening the report file ", lcovFullPath,"index.html"));
                
                if (!Directory.Exists(lcovFullPath))
                {
                    MessageBox.Show("Report is not available at this time");
                    return;
                }
                string indexFile = Directory.GetFiles(lcovFullPath, "index.html", SearchOption.AllDirectories).First();

                if (File.Exists(indexFile))
                {

                    ExecuteExternalProcess(browserFile, string.Format("{0}{1}{0}", dquotes, indexFile));
                }
                else
                {
                    MessageBox.Show("Report is not available at this time");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtProjDir_Leave(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtProjDir.Text;
            setAllPath();
        }

        private void chkLoadFolder_CheckedChanged(object sender, EventArgs e)
        {
            btnLoadFolder.Visible = chkLoadFolder.Checked;
            btnLoad.Visible = !chkLoadFolder.Checked;

        }

        private void btnLoadFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                //if (txtProjDir.Text != string.Empty && Directory.Exists(txtProjDir.Text))
                if (validateControls())
                {

                    fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                    fbd.SelectedPath = txtTestdir.Text + @"\";
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        fbd.SelectedPath = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a valid project path");
                    txtProjDir.Focus();
                    return;
                }
                List<string> filenames = new List<string>();
                if (fbd.SelectedPath != string.Empty)
                {
                    string[] extArr = testExtn.Split(new char[] { ';' });
                    foreach (string arr in extArr)
                    {
                        filenames.AddRange(Directory.GetFiles(fbd.SelectedPath, arr, SearchOption.AllDirectories));
                    }
                    AddSpecFiles(filenames.ToArray());

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lstFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = lstFiles.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
            }
            contextMenuStrip1.Show(Cursor.Position);
            contextMenuStrip1.Visible = true;

            
        }

        private void deleteSpecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFiles.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("No item Selected. Please select a spec file to be removed.");
                    return;
                }
                DeleteSelectedSpecs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    lstFiles.SetSelected(i, true);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < lstFiles.Items.Count; i++)
                {
                    lstFiles.SetSelected(i, false);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void addSpecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkLoadFolder.Checked)
                {
                    btnLoadFolder_Click(btnLoad, new EventArgs());
                }
                else
                {
                    btnLoad_Click(btnLoad, new EventArgs());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void karmaConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigFile = ConfigType.KARMA;
                LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void requireJsConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigFile = ConfigType.REQUIREJS;
                LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void applicationConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigFile = ConfigType.APPLICATION;
                LoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadConfig()
        {

            string fileName = CheckConfigSelection();
            if (fileName != string.Empty)
            {
                pnlConfig.Visible = true;
                pnlConfig.BringToFront();
                pnlConfig.Dock = DockStyle.Fill;
                rtbConfig.Text = File.ReadAllText(fileName);
            }
        }

        private string CheckConfigSelection()
        {
            string fileName;
            switch (ConfigFile)
            {
                case ConfigType.KARMA:
                    fileName = karmaconfig;
                    break;
                case ConfigType.REQUIREJS:
                    fileName = karmaRequireconfig;
                    break;
                case ConfigType.APPLICATION:
                    fileName = string.Format("{0}{1}", AppDomain.CurrentDomain.FriendlyName, ".config");
                    break;
                default:
                    fileName = string.Empty;
                    break;
            }
            return fileName;
        }

        private void btnCloseConfig_Click(object sender, EventArgs e)
        {
            pnlConfig.Visible = false;
            pnlConfig.SendToBack();
            pnlConfig.Dock = DockStyle.None;

        }

        private void btnCancelConfig_Click(object sender, EventArgs e)
        {
            DialogResult dres = MessageBox.Show("Are you sure, All your changes will be lost");
            if (dres == DialogResult.Yes)
            {
                LoadConfig();
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = CheckConfigSelection();
                DialogResult dres = MessageBox.Show(string.Format("{1}{0}{2}{0}{3}", Environment.NewLine, "Are you sure you want to save changes to the config file.",
                                                                                     "Caution this will overwrite the config.",
                                                                                     "May fail to work if not configured properly!!!"), "Karma Config", MessageBoxButtons.YesNo);

                if (dres == DialogResult.Yes && filename != string.Empty)
                {
                    File.WriteAllText(filename, rtbConfig.Text);
                    MessageBox.Show("File Sucessfully saved");
                    ReadAppSettings();// Read the app settings.
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //KarmaRunnerHelper.FindAllInRTB(rtbConfig, txtFind.Text, Color.Red);
            try
            {
                if (txtFind.Text == string.Empty)
                {
                    return;
                }
                string word = txtFind.Text;
                Int32 index;
                if (searchWord != word)
                {
                    searchWord = word;
                    searchIndex = 0;
                }
                index = rtbConfig.Text.IndexOf(word, searchIndex);
                if (index != -1)
                {
                    rtbConfig.SelectAll();
                    rtbConfig.SelectionColor = Color.Black;
                    rtbConfig.Select(index, word.Length);
                    rtbConfig.SelectionColor = Color.Blue;
                    rtbConfig.ScrollToCaret();
                    searchIndex = index + word.Length;

                }
                else
                {
                    MessageBox.Show("Search string not found");
                    searchIndex = 0;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private bool validateControls()
        {

            return validate(new TextBox[] { txtProjDir, txtSourceDir, txtTestdir, txtLibDir });
            
        }

        private bool validate(TextBox[] tbox)
        {
            errorProvider1.Clear();
            foreach (TextBox tb in tbox)
            {
                if (tb.Text == string.Empty || !Directory.Exists(tb.Text))
                {
                    errorProvider1.SetError(tb, "Cannot be Empty and should be a valid directory");
                    return false;

                }
            }
           
            return true;
        }

        #endregion Private Methods

        

        

    }
}
