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
    public partial class Form_EditEquation : Form
    {
        PictureBox picbox = new PictureBox();        
        public Form_EditEquation(string text)
        {
            InitializeComponent();


            richTextBox1.Text = text;
       
            
                       
        }

        public string text
        {
            get { return richTextBox1.Text; }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        
    }
}
