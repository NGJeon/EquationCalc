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
    public partial class Form_AddVariable : Form
    {
        Dictionary<string, VariableData> m_dictionary_Variable;
        Dictionary<string, EquationInformation> m_dictionary_EquationInfomation;
        Dictionary<string, string> m_dictionary_Case;
        bool isModifyMode = false;
        public VariableData.CheckOption Option
        {
            get
            {
                if (m_radio_no_check.Checked)
                    return VariableData.CheckOption.None;
                else if (m_radio_check_range.Checked)
                    return VariableData.CheckOption.MinMax;
                else if (m_radio_check_switch.Checked)
                    return VariableData.CheckOption.Case;
                else
                    return VariableData.CheckOption.Custom;
            }
        }
        public bool isCorrespond
        {
            get { return m_button_variable_correspond.Text == "설정해제"; }
        }
        public string VariableName
        {
            get { return m_textbox_VarName.Text; }
        }
        public string CorrespondVarPath
        {
            get { return m_textbox_variable_correspond.Text; }
        }
        public string Equation
        {
            get { return m_textbox_variable_Equation.Text; }
        }
        public bool IsEquationVariable
        {
            get { return m_radio_variable_output.Checked; }
        }
        public bool IsHiddenValue
        {
            get { return m_check_variable_hidden.Checked; }
        }

        public double CheckMinValue
        {
            get
            {
                Double retval;
                if (Double.TryParse(m_textbox_check_min.Text, out retval))
                {
                    return retval;
                }
                else
                    throw new FormatException("Double형의로의 변환에 실패 했습니다");
            }
        }

        
        public double CheckMaxValue
        {
            get
            {
                Double retval;
                if (Double.TryParse(m_textbox_check_max.Text, out retval))
                {
                    return retval;
                }
                else
                    throw new FormatException("Double형의로의 변환에 실패 했습니다");
            }
        }
        
        public Dictionary<string,string> CaseInfo
        {
            get
            {
                if (m_dictionary_Case == null)
                    m_dictionary_Case = new Dictionary<string, string>();
                return m_dictionary_Case;
            }
        }

        public string CustomOptionString
        {
            get { return m_textbox_check_user.Text; }
        }
        //새 변수
        public Form_AddVariable(Dictionary<string,EquationInformation> vardata,string selectedEquation)
        {
            InitializeComponent();   
            m_dictionary_EquationInfomation = vardata;
            m_dictionary_Variable = new Dictionary<string, VariableData>(m_dictionary_EquationInfomation[selectedEquation].m_Dictionary_Equation);
        }
        //수정
        public Form_AddVariable(VariableData selectedVar, Dictionary<string,EquationInformation> vardata,string selectedEquation)
        {
            InitializeComponent();
            isModifyMode = true;
            m_dictionary_EquationInfomation = vardata;
            m_dictionary_Variable = new Dictionary<string, VariableData>(m_dictionary_EquationInfomation[selectedEquation].m_Dictionary_Equation);

            m_textbox_VarName.Text = selectedVar.Name;
            if( selectedVar is EquationVariable )
            {
                m_radio_variable_output.Checked = true;
                m_textbox_variable_Equation.Text = selectedVar.Equation;
                m_check_variable_hidden.Checked = selectedVar.IsHiddenVariable;
                m_radio_variable_input.Enabled = false;
                m_radio_variable_output.Enabled = false;               

            }
            else
            {
                if (selectedVar.m_Dictionary_SwitchInfo == null)
                    selectedVar.m_Dictionary_SwitchInfo = new Dictionary<string, string>();
                m_dictionary_Case = new Dictionary<string, string>(selectedVar.m_Dictionary_SwitchInfo);
                m_radio_variable_input.Checked = true;
                m_radio_variable_input.Enabled = false;
                m_radio_variable_output.Enabled = false;
                if( selectedVar.IsCorrespond)
                {
                    m_button_variable_correspond.Text = "설정해제";
                    m_textbox_variable_correspond.Text = selectedVar.CorrespontVarName;
                }
                
                if (selectedVar.m_checkOption == VariableData.CheckOption.None)
                {
                    m_radio_no_check.Checked = true;
                }
                else if (selectedVar.m_checkOption == VariableData.CheckOption.MinMax)
                {
                    m_radio_check_range.Checked = true;                    
                }
                else if (selectedVar.m_checkOption == VariableData.CheckOption.Case)
                {
                    m_radio_check_switch.Checked = true;
                    
                }
                else
                {
                    m_radio_check_user.Checked = true;
                    
                }
                m_textbox_check_min.Text = selectedVar.OptionMinValue.ToString("R");
                m_textbox_check_max.Text = selectedVar.OptionMaxValue.ToString("R");
                m_textbox_check_user.Text = selectedVar.CustomOptionString;
                m_dictionary_Case = new Dictionary<string, string>(selectedVar.m_Dictionary_SwitchInfo);
            }

            
        }

        private void m_radio_variable_input_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if( radio.Checked )
            {
                m_button_variable_correspond.Enabled = true;                
                
            }
            else
            {
                m_button_variable_correspond.Enabled = false;
            }
        }

        private void m_radio_variable_output_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                m_button_variable_equation.Enabled = true;
                m_check_variable_hidden.Enabled = true;
            }
            else
            {
                m_button_variable_equation.Enabled = false;
                m_check_variable_hidden.Enabled = false;
            }
        }

        private void m_button_variable_correspond_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "설정")
            {
                Form_Correspond cform = new Form_Correspond(m_dictionary_EquationInfomation);
                if( cform.ShowDialog() == DialogResult.OK )
                {
                    if( cform.isSetCorrespond)
                    {
                        m_textbox_variable_correspond.Text = cform.SelectedVariablePath;
                        button.Text = "설정해제";
                    }
                }
                
            }
            else
            {
                m_textbox_variable_correspond.Text = "";
                button.Text = "설정";
            }
        }

        private void tab_Variable_Click(object sender, EventArgs e)
        {

        }

        private void m_radio_no_check_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
            }
            else
            {                
            }
        }

        private void m_radio_check_range_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                m_textbox_check_min.Enabled = true;
                m_textbox_check_max.Enabled = true;
            }
            else
            {
                m_textbox_check_min.Enabled = false;
                m_textbox_check_max.Enabled = false;
            }
        }

        private void m_radio_check_user_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                m_button_check_user.Enabled = true;

            }
            else
            {
                m_button_check_user.Enabled = false;
            }
        }

        private void m_button_variable_equation_Click(object sender, EventArgs e)
        {
            Form_EditEquation newform = new Form_EditEquation(m_textbox_variable_Equation.Text);
            if (newform.ShowDialog() == DialogResult.OK)
            {
                m_textbox_variable_Equation.Text = newform.text;
            }
        }

        private void m_button_check_user_Click(object sender, EventArgs e)
        {
            Form_EditEquation newform = new Form_EditEquation(m_textbox_check_user.Text);
            if (newform.ShowDialog() == DialogResult.OK)
                m_textbox_check_user.Text = newform.text;
        }

        private void m_button_OK_Click(object sender, EventArgs e)
        {

        }

        private bool CheckInputValue()
        {
            if( !Valid(VariableName))
            {
                return false;
            }
            if( !ValidMinMax())
            {
                return false;
            }
            if (!ValidCustomOption())
                return false;

            return true;
        }
        private bool ValidCustomOption()
        {
            if (Option != VariableData.CheckOption.Custom)
                return true;
            char[] c_splitter = { '\n' };
            string[] spl_strs = m_textbox_check_user.Text.Split(c_splitter,StringSplitOptions.RemoveEmptyEntries);
            string[] splitter = { ">=", "<=", "==", ">", "<", "!=" };
            foreach( string str in spl_strs )
            {
                string[] strs = str.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length != 2)
                    return false;
            }
            return true;

        }
        private bool ValidMinMax()
        {
            if (Option != VariableData.CheckOption.MinMax)
                return true;
            try
            {
                if( CheckMinValue > CheckMaxValue )
                {
                    MessageBox.Show("최저값이 최대값보다 높을 수는 없습니다");
                    return false;
                }
                return true;
            }
            catch( Exception e)
            {
                MessageBox.Show("입력값은 숫자만 가능합니다. 값을 다시 한번 확인해 주십시오");
                return false;
            }
        }
        private bool Valid(string str)
        {
            VariableData vdata;
            string temp = str.ToLower();
            if (temp.Length == 0)
            {
                MessageBox.Show("변수명을 입력해 주시길 바랍니다");
                return false;
            }
            if ((!(temp[0] >= '0' && temp[0] <= '9') || temp[0] == '_') == false)
            {
                MessageBox.Show("첫글자는 무조건 문자가 와야합니다.");
                return false;
            }
            if (str[0] == 'e')
            {
                MessageBox.Show("e는 자연수이므로 맨 앞에 쓸수 없습니다.");
                return false;
            }

//             if (m_dictionary_Variable.TryGetValue(str, out vdata))
//             {
//                 MessageBox.Show("해당 변수의 이름이 존재 합니다");
//                 return false;
//             }
            return true;
        }

        private void newAddCalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
            {
                if (!CheckInputValue())
                {
                    e.Cancel = true;
                }
            }
                      
        }

        private void m_button_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void m_radio_check_switch_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            if (radio.Checked)
                m_button_check_switch.Enabled = true;
            else
                m_button_check_switch.Enabled = false;
            
        }

        private void m_button_check_switch_Click(object sender, EventArgs e)
        {
            if (m_dictionary_Case == null)
                m_dictionary_Case = new Dictionary<string, string>();
            Form_Switch sform = new Form_Switch(m_dictionary_Case);

            if( sform.ShowDialog() == DialogResult.OK)
            {
                m_dictionary_Case = new Dictionary<string, string>(sform.GetCaseDictionary());
            }
        }
    }
}
