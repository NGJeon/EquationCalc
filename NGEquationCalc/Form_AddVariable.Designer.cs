namespace NGEquationCalc
{
    partial class Form_AddVariable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_button_OK = new System.Windows.Forms.Button();
            this.m_button_Cancel = new System.Windows.Forms.Button();
            this.m_tab_check = new System.Windows.Forms.TabPage();
            this.m_button_check_switch = new System.Windows.Forms.Button();
            this.m_radio_check_switch = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_button_check_user = new System.Windows.Forms.Button();
            this.m_textbox_check_user = new System.Windows.Forms.TextBox();
            this.m_textbox_check_max = new System.Windows.Forms.TextBox();
            this.m_textbox_check_min = new System.Windows.Forms.TextBox();
            this.m_radio_check_user = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_radio_check_range = new System.Windows.Forms.RadioButton();
            this.m_radio_no_check = new System.Windows.Forms.RadioButton();
            this.tab_Variable = new System.Windows.Forms.TabPage();
            this.m_check_variable_hidden = new System.Windows.Forms.CheckBox();
            this.m_button_variable_correspond = new System.Windows.Forms.Button();
            this.m_textbox_variable_correspond = new System.Windows.Forms.TextBox();
            this.m_textbox_VarName = new System.Windows.Forms.TextBox();
            this.m_textbox_variable_Equation = new System.Windows.Forms.TextBox();
            this.m_radio_variable_output = new System.Windows.Forms.RadioButton();
            this.m_radio_variable_input = new System.Windows.Forms.RadioButton();
            this.m_button_variable_equation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tab_Variable_Input_Config = new System.Windows.Forms.TabControl();
            this.m_tab_check.SuspendLayout();
            this.tab_Variable.SuspendLayout();
            this.tab_Variable_Input_Config.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_button_OK
            // 
            this.m_button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_button_OK.Location = new System.Drawing.Point(293, 483);
            this.m_button_OK.Name = "m_button_OK";
            this.m_button_OK.Size = new System.Drawing.Size(99, 30);
            this.m_button_OK.TabIndex = 1;
            this.m_button_OK.Text = "확인";
            this.m_button_OK.UseVisualStyleBackColor = true;
            this.m_button_OK.Click += new System.EventHandler(this.m_button_OK_Click);
            // 
            // m_button_Cancel
            // 
            this.m_button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_button_Cancel.Location = new System.Drawing.Point(398, 483);
            this.m_button_Cancel.Name = "m_button_Cancel";
            this.m_button_Cancel.Size = new System.Drawing.Size(99, 30);
            this.m_button_Cancel.TabIndex = 2;
            this.m_button_Cancel.Text = "취소";
            this.m_button_Cancel.UseVisualStyleBackColor = true;
            this.m_button_Cancel.Click += new System.EventHandler(this.m_button_Cancel_Click);
            // 
            // m_tab_check
            // 
            this.m_tab_check.Controls.Add(this.m_button_check_switch);
            this.m_tab_check.Controls.Add(this.m_radio_check_switch);
            this.m_tab_check.Controls.Add(this.textBox1);
            this.m_tab_check.Controls.Add(this.m_button_check_user);
            this.m_tab_check.Controls.Add(this.m_textbox_check_user);
            this.m_tab_check.Controls.Add(this.m_textbox_check_max);
            this.m_tab_check.Controls.Add(this.m_textbox_check_min);
            this.m_tab_check.Controls.Add(this.m_radio_check_user);
            this.m_tab_check.Controls.Add(this.label2);
            this.m_tab_check.Controls.Add(this.label1);
            this.m_tab_check.Controls.Add(this.m_radio_check_range);
            this.m_tab_check.Controls.Add(this.m_radio_no_check);
            this.m_tab_check.Location = new System.Drawing.Point(4, 22);
            this.m_tab_check.Name = "m_tab_check";
            this.m_tab_check.Padding = new System.Windows.Forms.Padding(3);
            this.m_tab_check.Size = new System.Drawing.Size(490, 450);
            this.m_tab_check.TabIndex = 3;
            this.m_tab_check.Text = "입력 옵션";
            this.m_tab_check.UseVisualStyleBackColor = true;
            // 
            // m_button_check_switch
            // 
            this.m_button_check_switch.Enabled = false;
            this.m_button_check_switch.Location = new System.Drawing.Point(297, 309);
            this.m_button_check_switch.Name = "m_button_check_switch";
            this.m_button_check_switch.Size = new System.Drawing.Size(95, 32);
            this.m_button_check_switch.TabIndex = 11;
            this.m_button_check_switch.Text = "편집";
            this.m_button_check_switch.UseVisualStyleBackColor = true;
            this.m_button_check_switch.Click += new System.EventHandler(this.m_button_check_switch_Click);
            // 
            // m_radio_check_switch
            // 
            this.m_radio_check_switch.AutoSize = true;
            this.m_radio_check_switch.Location = new System.Drawing.Point(6, 287);
            this.m_radio_check_switch.Name = "m_radio_check_switch";
            this.m_radio_check_switch.Size = new System.Drawing.Size(115, 16);
            this.m_radio_check_switch.TabIndex = 10;
            this.m_radio_check_switch.Text = "분기 조건문 사용";
            this.m_radio_check_switch.UseVisualStyleBackColor = true;
            this.m_radio_check_switch.CheckedChanged += new System.EventHandler(this.m_radio_check_switch_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 309);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(285, 89);
            this.textBox1.TabIndex = 9;
            // 
            // m_button_check_user
            // 
            this.m_button_check_user.Enabled = false;
            this.m_button_check_user.Location = new System.Drawing.Point(290, 141);
            this.m_button_check_user.Name = "m_button_check_user";
            this.m_button_check_user.Size = new System.Drawing.Size(95, 32);
            this.m_button_check_user.TabIndex = 8;
            this.m_button_check_user.Text = "편집";
            this.m_button_check_user.UseVisualStyleBackColor = true;
            this.m_button_check_user.Click += new System.EventHandler(this.m_button_check_user_Click);
            // 
            // m_textbox_check_user
            // 
            this.m_textbox_check_user.Location = new System.Drawing.Point(6, 141);
            this.m_textbox_check_user.Multiline = true;
            this.m_textbox_check_user.Name = "m_textbox_check_user";
            this.m_textbox_check_user.ReadOnly = true;
            this.m_textbox_check_user.Size = new System.Drawing.Size(276, 97);
            this.m_textbox_check_user.TabIndex = 7;
            // 
            // m_textbox_check_max
            // 
            this.m_textbox_check_max.Enabled = false;
            this.m_textbox_check_max.Location = new System.Drawing.Point(147, 79);
            this.m_textbox_check_max.Name = "m_textbox_check_max";
            this.m_textbox_check_max.Size = new System.Drawing.Size(100, 21);
            this.m_textbox_check_max.TabIndex = 4;
            // 
            // m_textbox_check_min
            // 
            this.m_textbox_check_min.Enabled = false;
            this.m_textbox_check_min.Location = new System.Drawing.Point(6, 79);
            this.m_textbox_check_min.Name = "m_textbox_check_min";
            this.m_textbox_check_min.Size = new System.Drawing.Size(100, 21);
            this.m_textbox_check_min.TabIndex = 2;
            // 
            // m_radio_check_user
            // 
            this.m_radio_check_user.AutoSize = true;
            this.m_radio_check_user.Location = new System.Drawing.Point(6, 119);
            this.m_radio_check_user.Name = "m_radio_check_user";
            this.m_radio_check_user.Size = new System.Drawing.Size(165, 16);
            this.m_radio_check_user.TabIndex = 6;
            this.m_radio_check_user.Text = "사용자 정의(엔터로 구분) ";
            this.m_radio_check_user.UseVisualStyleBackColor = true;
            this.m_radio_check_user.CheckedChanged += new System.EventHandler(this.m_radio_check_user_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "까지";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "부터";
            // 
            // m_radio_check_range
            // 
            this.m_radio_check_range.AutoSize = true;
            this.m_radio_check_range.Location = new System.Drawing.Point(6, 46);
            this.m_radio_check_range.Name = "m_radio_check_range";
            this.m_radio_check_range.Size = new System.Drawing.Size(91, 16);
            this.m_radio_check_range.TabIndex = 1;
            this.m_radio_check_range.Text = "입력 값 범위";
            this.m_radio_check_range.UseVisualStyleBackColor = true;
            this.m_radio_check_range.CheckedChanged += new System.EventHandler(this.m_radio_check_range_CheckedChanged);
            // 
            // m_radio_no_check
            // 
            this.m_radio_no_check.AutoSize = true;
            this.m_radio_no_check.Checked = true;
            this.m_radio_no_check.Location = new System.Drawing.Point(6, 15);
            this.m_radio_no_check.Name = "m_radio_no_check";
            this.m_radio_no_check.Size = new System.Drawing.Size(119, 16);
            this.m_radio_no_check.TabIndex = 0;
            this.m_radio_no_check.TabStop = true;
            this.m_radio_no_check.Text = "입력 값 확인 안함";
            this.m_radio_no_check.UseVisualStyleBackColor = true;
            this.m_radio_no_check.CheckedChanged += new System.EventHandler(this.m_radio_no_check_CheckedChanged);
            // 
            // tab_Variable
            // 
            this.tab_Variable.Controls.Add(this.m_check_variable_hidden);
            this.tab_Variable.Controls.Add(this.m_button_variable_correspond);
            this.tab_Variable.Controls.Add(this.m_textbox_variable_correspond);
            this.tab_Variable.Controls.Add(this.m_textbox_VarName);
            this.tab_Variable.Controls.Add(this.m_textbox_variable_Equation);
            this.tab_Variable.Controls.Add(this.m_radio_variable_output);
            this.tab_Variable.Controls.Add(this.m_radio_variable_input);
            this.tab_Variable.Controls.Add(this.m_button_variable_equation);
            this.tab_Variable.Controls.Add(this.label6);
            this.tab_Variable.Controls.Add(this.label5);
            this.tab_Variable.Controls.Add(this.label4);
            this.tab_Variable.Controls.Add(this.label3);
            this.tab_Variable.Location = new System.Drawing.Point(4, 22);
            this.tab_Variable.Name = "tab_Variable";
            this.tab_Variable.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Variable.Size = new System.Drawing.Size(490, 450);
            this.tab_Variable.TabIndex = 2;
            this.tab_Variable.Text = "변수 설정";
            this.tab_Variable.UseVisualStyleBackColor = true;
            this.tab_Variable.Click += new System.EventHandler(this.tab_Variable_Click);
            // 
            // m_check_variable_hidden
            // 
            this.m_check_variable_hidden.AutoSize = true;
            this.m_check_variable_hidden.Enabled = false;
            this.m_check_variable_hidden.Location = new System.Drawing.Point(248, 103);
            this.m_check_variable_hidden.Name = "m_check_variable_hidden";
            this.m_check_variable_hidden.Size = new System.Drawing.Size(48, 16);
            this.m_check_variable_hidden.TabIndex = 11;
            this.m_check_variable_hidden.Text = "숨김";
            this.m_check_variable_hidden.UseVisualStyleBackColor = true;
            // 
            // m_button_variable_correspond
            // 
            this.m_button_variable_correspond.Location = new System.Drawing.Point(309, 176);
            this.m_button_variable_correspond.Name = "m_button_variable_correspond";
            this.m_button_variable_correspond.Size = new System.Drawing.Size(98, 21);
            this.m_button_variable_correspond.TabIndex = 10;
            this.m_button_variable_correspond.Text = "설정";
            this.m_button_variable_correspond.UseVisualStyleBackColor = true;
            this.m_button_variable_correspond.Click += new System.EventHandler(this.m_button_variable_correspond_Click);
            // 
            // m_textbox_variable_correspond
            // 
            this.m_textbox_variable_correspond.Location = new System.Drawing.Point(8, 176);
            this.m_textbox_variable_correspond.Name = "m_textbox_variable_correspond";
            this.m_textbox_variable_correspond.ReadOnly = true;
            this.m_textbox_variable_correspond.Size = new System.Drawing.Size(295, 21);
            this.m_textbox_variable_correspond.TabIndex = 9;
            // 
            // m_textbox_VarName
            // 
            this.m_textbox_VarName.Location = new System.Drawing.Point(8, 39);
            this.m_textbox_VarName.Name = "m_textbox_VarName";
            this.m_textbox_VarName.Size = new System.Drawing.Size(227, 21);
            this.m_textbox_VarName.TabIndex = 6;
            // 
            // m_textbox_variable_Equation
            // 
            this.m_textbox_variable_Equation.Location = new System.Drawing.Point(8, 246);
            this.m_textbox_variable_Equation.Multiline = true;
            this.m_textbox_variable_Equation.Name = "m_textbox_variable_Equation";
            this.m_textbox_variable_Equation.ReadOnly = true;
            this.m_textbox_variable_Equation.Size = new System.Drawing.Size(355, 103);
            this.m_textbox_variable_Equation.TabIndex = 4;
            // 
            // m_radio_variable_output
            // 
            this.m_radio_variable_output.AutoSize = true;
            this.m_radio_variable_output.Location = new System.Drawing.Point(167, 102);
            this.m_radio_variable_output.Name = "m_radio_variable_output";
            this.m_radio_variable_output.Size = new System.Drawing.Size(75, 16);
            this.m_radio_variable_output.TabIndex = 8;
            this.m_radio_variable_output.Text = "출력 변수";
            this.m_radio_variable_output.UseVisualStyleBackColor = true;
            this.m_radio_variable_output.CheckedChanged += new System.EventHandler(this.m_radio_variable_output_CheckedChanged);
            // 
            // m_radio_variable_input
            // 
            this.m_radio_variable_input.AutoSize = true;
            this.m_radio_variable_input.Checked = true;
            this.m_radio_variable_input.Location = new System.Drawing.Point(8, 102);
            this.m_radio_variable_input.Name = "m_radio_variable_input";
            this.m_radio_variable_input.Size = new System.Drawing.Size(75, 16);
            this.m_radio_variable_input.TabIndex = 7;
            this.m_radio_variable_input.TabStop = true;
            this.m_radio_variable_input.Text = "입력 변수";
            this.m_radio_variable_input.UseVisualStyleBackColor = true;
            this.m_radio_variable_input.CheckedChanged += new System.EventHandler(this.m_radio_variable_input_CheckedChanged);
            // 
            // m_button_variable_equation
            // 
            this.m_button_variable_equation.Enabled = false;
            this.m_button_variable_equation.Location = new System.Drawing.Point(369, 246);
            this.m_button_variable_equation.Name = "m_button_variable_equation";
            this.m_button_variable_equation.Size = new System.Drawing.Size(98, 28);
            this.m_button_variable_equation.TabIndex = 5;
            this.m_button_variable_equation.Text = "편집";
            this.m_button_variable_equation.UseVisualStyleBackColor = true;
            this.m_button_variable_equation.Click += new System.EventHandler(this.m_button_variable_equation_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "출력 변수 대입";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "출력 공식";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "변수 종류";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "변수명";
            // 
            // tab_Variable_Input_Config
            // 
            this.tab_Variable_Input_Config.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_Variable_Input_Config.Controls.Add(this.tab_Variable);
            this.tab_Variable_Input_Config.Controls.Add(this.m_tab_check);
            this.tab_Variable_Input_Config.Location = new System.Drawing.Point(3, 1);
            this.tab_Variable_Input_Config.Name = "tab_Variable_Input_Config";
            this.tab_Variable_Input_Config.SelectedIndex = 0;
            this.tab_Variable_Input_Config.Size = new System.Drawing.Size(498, 476);
            this.tab_Variable_Input_Config.TabIndex = 0;
            // 
            // Form_AddVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 525);
            this.Controls.Add(this.m_button_Cancel);
            this.Controls.Add(this.m_button_OK);
            this.Controls.Add(this.tab_Variable_Input_Config);
            this.Name = "Form_AddVariable";
            this.Text = "변수 추가";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.newAddCalculatorForm_FormClosing);
            this.m_tab_check.ResumeLayout(false);
            this.m_tab_check.PerformLayout();
            this.tab_Variable.ResumeLayout(false);
            this.tab_Variable.PerformLayout();
            this.tab_Variable_Input_Config.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_button_OK;
        private System.Windows.Forms.Button m_button_Cancel;
        private System.Windows.Forms.TabPage m_tab_check;
        private System.Windows.Forms.Button m_button_check_user;
        private System.Windows.Forms.TextBox m_textbox_check_user;
        private System.Windows.Forms.TextBox m_textbox_check_max;
        private System.Windows.Forms.TextBox m_textbox_check_min;
        private System.Windows.Forms.RadioButton m_radio_check_user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_radio_check_range;
        private System.Windows.Forms.RadioButton m_radio_no_check;
        private System.Windows.Forms.TabPage tab_Variable;
        private System.Windows.Forms.Button m_button_variable_correspond;
        private System.Windows.Forms.TextBox m_textbox_variable_correspond;
        private System.Windows.Forms.TextBox m_textbox_VarName;
        private System.Windows.Forms.TextBox m_textbox_variable_Equation;
        private System.Windows.Forms.RadioButton m_radio_variable_output;
        private System.Windows.Forms.RadioButton m_radio_variable_input;
        private System.Windows.Forms.Button m_button_variable_equation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tab_Variable_Input_Config;
        private System.Windows.Forms.CheckBox m_check_variable_hidden;
        private System.Windows.Forms.Button m_button_check_switch;
        private System.Windows.Forms.RadioButton m_radio_check_switch;
        private System.Windows.Forms.TextBox textBox1;
    }
}