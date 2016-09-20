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
    public partial class Form_Admin : Form
    {
        string password = "1";
        public bool _checked = false;
        public delegate void LogInDelegate();
        public event LogInDelegate login_Event;
        public Form_Admin()
        {
            InitializeComponent();
            this.CancelButton = null;
        }

        private void btn_CheckAdmin_Click(object sender, EventArgs e)
        {
            if (password == txtBox_password.Text)
            {
                _checked = true;                
            }
        }

        private void Admin_Form_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (_checked)
            {
                if (login_Event != null)
                {
                    login_Event();
                }
               
            }
        }
    }
}
