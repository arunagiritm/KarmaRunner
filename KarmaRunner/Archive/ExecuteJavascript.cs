using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KarmaRunner
{
    [ComVisibleAttribute(true)]
    public partial class ExecuteJavascript : Form
    {
        public ExecuteJavascript()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new ScriptManager(this);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] o = new object[1];
            o[0] = txtMessage.Text;
            object result = this.webBrowser1.Document.InvokeScript("ShowMessage", o);

        }

        private void ExecuteJavascript_Load(object sender, EventArgs e)
        {
            string filename = string.Format(@"{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Specrunner.html");
            this.webBrowser1.Navigate(filename);
            
        }
        
    }
    [ComVisible(true)]
    public class ScriptManager
    {
        ExecuteJavascript _form;
        public ScriptManager(ExecuteJavascript form)
        {
            _form = form;
        }
        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
