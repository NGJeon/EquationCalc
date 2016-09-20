using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NGEquationCalc
{
    public partial class Form_Log_Window : Form
    {
        public enum LogOption
        {
            Normal,
            System,
            Error,
            Equation,
            Result
        }
        public delegate void formClosdedDelegate();
        public event formClosdedDelegate formclosed;


        public delegate void LogMessageDelegate(string msg, LogOption option);        


        public Form_Log_Window()
        {
            InitializeComponent();
        }
       

        public void SendtoLog( string str, LogOption option)
        {
            if( this.richTextBox1.InvokeRequired )
            {
                LogMessageDelegate d = new LogMessageDelegate(SendtoLog);
                this.Invoke(d);
            }
            else
            {
                richTextBox1.SelectionCharOffset = 2;
                richTextBox1.SelectedText = string.Empty;
                richTextBox1.SelectionStart = richTextBox1.TextLength;

                switch( option )
                {
                    case LogOption.Normal:
                        richTextBox1.SelectionColor = Color.White;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                    case LogOption.System:
                        richTextBox1.SelectionColor = Color.Yellow;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                    case LogOption.Error:
                        richTextBox1.SelectionColor = Color.FromArgb(0xd9,0x2b,0x2b);
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;                        
                        break;       
                    case LogOption.Equation:
                        richTextBox1.SelectionColor = Color.PeachPuff;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                    case LogOption.Result:
                        richTextBox1.SelectionColor = Color.LightBlue;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                }

                richTextBox1.AppendText(str);                
                richTextBox1.ScrollToCaret();
            }
        }


        
        private void m_button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdialog = new SaveFileDialog();
            sfdialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            sfdialog.Filter = "txt files|*.txt";

            if ( sfdialog.ShowDialog() == DialogResult.OK )
            {
                //using (FileStream fs = new FileStream(sfdialog.FileName,FileMode.OpenOrCreate))
                {
                    //using ( StreamWriter sw = new StreamWriter(fs))
                    {
//                         sw.NewLine = "\n";
//                         sw.Write(richTextBox1.Text);
                        richTextBox1.SaveFile(sfdialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        }

        private void m_button_delete_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();            
            richTextBox1.Text = "";
            this.Refresh();
        }

        private void Log_Window_FormClosing(object sender, FormClosingEventArgs e)
        {            
            e.Cancel = true;
            this.Hide();
        }
    }
}
