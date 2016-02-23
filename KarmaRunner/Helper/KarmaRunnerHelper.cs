using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;


namespace KarmaRunner.Helper
{
    public static class KarmaRunnerHelper
    {
        public static int ExecuteProcess(string filename, string arguments)
        {
            return ExecuteProcess(filename, arguments, false);
        }

        public static int ExecuteProcessWithHandle(string filename, string arguments, EventHandler pe)
        {
            try
            {


                System.Diagnostics.Process oProcess = new System.Diagnostics.Process(); ;
                bool waitforexit = true;

                string outputContent = string.Empty;
                oProcess = new System.Diagnostics.Process();
                oProcess.StartInfo.UseShellExecute = false;
                oProcess.StartInfo.FileName = filename;
                oProcess.StartInfo.Arguments = arguments;
                oProcess.StartInfo.CreateNoWindow = true;
                oProcess.Exited += oProcess_Exited;
                oProcess.Start();
                if (waitforexit)
                {
                    oProcess.WaitForExit();
                }

                //return oProcess.ExitCode;
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void oProcess_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("process Exited");
        }
        public static int ExecuteProcess(string filename, string arguments, bool waitforexit)
        {
            try
            {

                Process oProcess = new System.Diagnostics.Process(); ;
                string outputContent = string.Empty;
                oProcess = new System.Diagnostics.Process();
                oProcess.StartInfo.UseShellExecute = false;
                oProcess.StartInfo.FileName = filename;
                oProcess.StartInfo.Arguments = arguments;
                oProcess.StartInfo.CreateNoWindow = true;
                oProcess.Start();
                if (waitforexit)
                {
                    oProcess.WaitForExit();
                }

                //return oProcess.ExitCode;
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string OpenFileSharedMode(string filename)
        {
            string content = string.Empty;
            if (File.Exists(filename))
            {
                using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var textReader = new StreamReader(fileStream))
                    {
                        content = textReader.ReadToEnd();
                    }
                }
            }
            return content;
        }
        public static void WriteFileSharedMode(string filename, string content)
        {

            if (File.Exists(filename))
            {
                using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (var textWriter = new StreamWriter(fileStream))
                    {
                        textWriter.Write(content);
                    }
                }
            }

        }

        public static void ExecuteProcessWithOutput(string filename, string outFilename)
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = filename; // Specify exe name.
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            //
            // Start the process.
            //
            using (Process process = Process.Start(start))
            {

                // Read in all the text from the process with the StreamReader.

                using (StreamReader reader = process.StandardOutput)
                {


                    string content = reader.ReadToEnd();

                    Console.Write(content);
                    WriteFileSharedMode(outFilename, content);



                }
            }



        }

        public static void WriteAppsettingToConfig(string key, string value)
        {
            try
            {
                Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                conf.AppSettings.Settings[key].Value = value;
                conf.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static void CreateTreeView(TreeView treeView1, DataTable dt, Int32 rootNode)
        {

            TreeViewSchema tvwSchema = new TreeViewSchema();
            tvwSchema.DataSource = dt;
            tvwSchema.KeyMember = "Id";
            tvwSchema.DisplayMember = "Node";
            tvwSchema.ValueMember = "Id";
            tvwSchema.ParentMember = "ParentId";
            tvwSchema.Checked = "Active";
            PopulateTree(treeView1, tvwSchema, rootNode);
            treeView1.ExpandAll();
            treeView1.CheckBoxes = true;
            //treeView1.Nodes[0].Checked = true;
            //CheckAllNodes(treeView1.Nodes);

        }
        private static DataTable CreateSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Node");
            dt.Columns.Add("ParentId", typeof(Int32));
            dt.Columns.Add("Type");
            dt.Columns.Add("Active", typeof(Boolean));
            dt.Columns["Active"].DefaultValue = true;
            return dt;

        }

        public static void PopulateTree(TreeView objTreeView, TreeViewSchema tvwSchema, Int32 rootNode)
        {

            //objTreeView.Nodes.Clear();    
            if (tvwSchema.DataSource != null)
            {
                foreach (DataRow dataRow in tvwSchema.DataSource.Rows)
                {

                    if (Convert.ToInt32(dataRow[tvwSchema.ParentMember]) == rootNode)
                    {

                        TreeNode treeRoot = new TreeNode();
                        treeRoot.Text = dataRow[tvwSchema.DisplayMember].ToString();
                        treeRoot.Tag = dataRow[tvwSchema.ValueMember].ToString();
                        treeRoot.Checked =Convert.ToBoolean(dataRow[tvwSchema.Checked] );
                        treeRoot.ExpandAll();
                        objTreeView.Nodes.Add(treeRoot);
                        Int32 keyMember = Convert.ToInt32(dataRow[tvwSchema.KeyMember].ToString());
                        foreach (TreeNode childNode in GetChildNode(keyMember, tvwSchema))
                        {
                            treeRoot.Nodes.Add(childNode);
                        }
                    }
                }
            }
        }

        private static List<TreeNode> GetChildNode(Int32 parentid, TreeViewSchema tvwSchema)
        {
            List<TreeNode> childtreenodes = new List<TreeNode>();
            DataView dataView1 = new DataView(tvwSchema.DataSource);
            String strFilter = "" + tvwSchema.ParentMember + "=" + parentid.ToString() + "";
            dataView1.RowFilter = strFilter;

            if (dataView1.Count > 0)
            {
                foreach (DataRow dataRow in dataView1.ToTable().Rows)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dataRow[tvwSchema.DisplayMember].ToString();
                    childNode.Tag = dataRow[tvwSchema.ValueMember].ToString();
                    childNode.Checked = Convert.ToBoolean(dataRow[tvwSchema.Checked]);
                    childNode.ExpandAll();
                    Int32 keyMember = Convert.ToInt32(dataRow[tvwSchema.KeyMember].ToString());
                    foreach (TreeNode cnode in GetChildNode(keyMember, tvwSchema))
                    {
                        childNode.Nodes.Add(cnode);
                    }
                    childtreenodes.Add(childNode);

                }
            }
            return childtreenodes;

        }

        private static void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }
        private static void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }
        private static void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        public static void FindAllInRTB(this RichTextBox myRtb, string word, Color color)
        {
            if (word == "")
            {
                myRtb.SelectedText = "";
                return;
            }

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }
        
    }

}

