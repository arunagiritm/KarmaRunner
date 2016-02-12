using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Windows.Forms;
using System.Configuration;


namespace Karmarunner.Helper
{
    public static class KarmaRunnerHelper
    {
       

       

        public static int ExecuteProcess(string filename, string arguments)
        {
            return ExecuteProcess(filename, arguments, false);
        }
      
         public static int  ExecuteProcessWithHandle(string filename, string arguments,EventHandler pe)
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
                oProcess.Exited +=oProcess_Exited;
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
            string content=string.Empty;
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
        public static void WriteFileSharedMode(string filename,string content)
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

        public static void ExecuteProcessWithOutput(string filename,string outFilename)
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
       
    }
}
