using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karmarunner.Helper;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace KarmaRunner
{
    public partial class frmKarmarunner : Form
    {
        public List<string> SpecFiles { get; set; }
        public string jsonTemplate { get; set; }
        public string basedir { get; set; }
        public string jsFiles { get; set; }
        public string inputjson { get; set; }
        public string karmabat { get; set; }
        string dquotes = "\"";
        Process oProcess;
        StringBuilder sbresult = new StringBuilder();
        StringBuilder sberror = new StringBuilder();

        public frmKarmarunner()
        {
            InitializeComponent();
            basedir = AppDomain.CurrentDomain.BaseDirectory;
            jsonTemplate = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jsonTemplate"]);
            jsFiles = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["jsfiles"]);
            inputjson = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["inputjson"]);
            karmabat = string.Format("{0}{1}", basedir, ConfigurationManager.AppSettings["karmabat"]);
            SpecFiles = new List<string>();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSourceDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtSourceDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = txtSourceDir.Text;
            openFileDialog1.FileName = "*.js";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //lstFiles.DataSource = null;
            //lstFiles.Items.Clear();
            SpecFiles.AddRange(openFileDialog1.FileNames);
            //lstFiles.DataSource = SpecFiles;
            chkListFullPath_CheckedChanged(chkListFullPath, new EventArgs());
        }

        private void ExecuteNodeProcess()
        {
            txtResult.Text = "";
            txtErrResult.Text = "";
            ExecuteExternalProcess(karmabat);
        }

        private void ExecuteExternalProcess(string filename)
        {
            sberror.Length = 0;
            sbresult.Length = 0;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = filename;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            using (oProcess = Process.Start(psi))
            {
                oProcess.ErrorDataReceived += oProcess_ErrorDataReceived;
                oProcess.BeginErrorReadLine();
                oProcess.OutputDataReceived += oProcess_OutputDataReceived;
                oProcess.BeginOutputReadLine();
                //oProcess.WaitForExit();
            }

        }

        void oProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            sberror.AppendLine(e.Data);
            SetText(sberror.ToString(), txtErrResult);
        }
        void oProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            sbresult.AppendLine(e.Data);
            SetText(sbresult.ToString(),txtResult);
        }
        delegate void SetTextCallback(string text,RichTextBox tb);
        private void SetText(string text, RichTextBox tb)
        {

            if (tb.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text,tb });
            }
            else
            {
                tb.Text = "";
                tb.Text = text;
                tb.Select(txtResult.TextLength, 0);
                tb.Focus();

            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                Int32 lcount = 1;
                string jsonContent = KarmaRunnerHelper.OpenFileSharedMode(jsonTemplate);
                string jcontemp;
                foreach (string sp in SpecFiles)
                {
                    jcontemp = string.Format("{2}{0}{2}{1}", sp.Replace(@"\", @"\\"), (lcount == SpecFiles.Count) ? "" : ",", dquotes);
                    sb.AppendLine(jcontemp);
                    lcount++;
                }
                jsonContent = string.Format(jsonContent, "{", "}", sb.ToString());
                if (File.Exists(inputjson))
                {
                    KarmaRunnerHelper.WriteFileSharedMode(inputjson, jsonContent);
                }
                else
                {
                    File.WriteAllText(inputjson, jsonContent);
                }

                ExecuteNodeProcess();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            SpecFiles.Clear();
            chkListFullPath_CheckedChanged(chkListFullPath, new EventArgs());

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
       
    }
}
