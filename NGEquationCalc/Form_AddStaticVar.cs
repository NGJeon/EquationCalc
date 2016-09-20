using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGEquationCalc
{
    public partial class Form_AddStaticVar : Form
    {
        bool isCorrect = false;
        Dictionary<string, double> m_variable = new Dictionary<string, double>();

        public Dictionary<string, double> Variables
        {
            get { return m_variable; }
           // set { m_variable = value; }
        }
        public Form_AddStaticVar(bool Adminmode)
        {
            InitializeComponent();
            if (Adminmode)
                this.textBox1.ReadOnly = false;
            else
                this.textBox1.ReadOnly = true;

            var list = MainForm.Static_Variable_Dictionary;
            
            foreach( var pair in list)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(pair.Key);
                sb.Append(" = ");
                sb.Append(pair.Value.ToString());
                sb.Append("\r\n");

                textBox1.Text += sb.ToString();                
            }            
        }

        private bool NameValidation( string name )
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, "[\\\\/\":*?!@<>|0-9]");
        }

        private void m_button_ok_Click(object sender, EventArgs e)
        {
            Check_Variable();
        }   
        private void Check_Variable()
        {
            m_variable.Clear();
            string[] lines = textBox1.Lines;
            
            foreach( string line in lines )
            {
                if (line.Trim() == "")
                    continue;
                char[] splliter = { '=' };
                string[] splitted = line.Split(splliter,StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length != 2)
                {
                    isCorrect = false;
                    MessageBox.Show("A=1형식으로 입력해 주십시오");
                    return;
                }
                string left = splitted[0].ToLower().Trim();
                if( NameValidation(left))
                {
                    isCorrect = false;
                    MessageBox.Show("변수명은 문자로만 기입할수 있습니다");
                    return;
                }
                double right = 0;

                try
                {
                    right = double.Parse(splitted[1]);
                }
                catch(Exception ex)
                {
                    isCorrect = false;
                    MessageBox.Show("A = 1 형식으로 입력해 주십시오.\n오른쪽 항에는 숫자만 넣을 수 있습니다");
                    return;
                }
                
                try
                {
                    m_variable[left] = right;
                }
                catch( Exception ex )
                {

                    isCorrect = false;
                    MessageBox.Show("변수 명은 중복될수 없습니다. 다시한번 확인해 주십시오");
                    return;
                }
                isCorrect = true;
            }
        }

        private void Form_AddStaticVar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.None)
                return;
            if (!isCorrect)
                e.Cancel = true;
        }

        private void m_button_cancel_Click(object sender, EventArgs e)
        {
            isCorrect = true;
        }
       
    }
}
