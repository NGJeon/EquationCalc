namespace NGEquationCalc
{
    partial class Form_Calculator
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_Button_Clear = new System.Windows.Forms.Button();
            this.m_Button_Add_Equation = new System.Windows.Forms.Button();
            this.m_Button_DoCalculate = new System.Windows.Forms.Button();
            this.toolTip_Error = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 477);
            this.panel1.TabIndex = 11;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // m_Button_Clear
            // 
            this.m_Button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Button_Clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_Button_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.m_Button_Clear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_Button_Clear.Image = global::NGEquationCalc.Properties.Resources.toolbtn_initial;
            this.m_Button_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_Button_Clear.Location = new System.Drawing.Point(589, 446);
            this.m_Button_Clear.Name = "m_Button_Clear";
            this.m_Button_Clear.Size = new System.Drawing.Size(95, 45);
            this.m_Button_Clear.TabIndex = 9;
            this.m_Button_Clear.TabStop = false;
            this.m_Button_Clear.Text = "        초기화";
            this.m_Button_Clear.UseVisualStyleBackColor = false;
            this.m_Button_Clear.Click += new System.EventHandler(this.m_Button_Clear_Click);
            // 
            // m_Button_Add_Equation
            // 
            this.m_Button_Add_Equation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Button_Add_Equation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_Button_Add_Equation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.m_Button_Add_Equation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.m_Button_Add_Equation.Image = global::NGEquationCalc.Properties.Resources.toolbtn_config;
            this.m_Button_Add_Equation.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_Button_Add_Equation.Location = new System.Drawing.Point(590, 345);
            this.m_Button_Add_Equation.Name = "m_Button_Add_Equation";
            this.m_Button_Add_Equation.Size = new System.Drawing.Size(95, 46);
            this.m_Button_Add_Equation.TabIndex = 8;
            this.m_Button_Add_Equation.TabStop = false;
            this.m_Button_Add_Equation.Text = "   공식    편집";
            this.m_Button_Add_Equation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_Button_Add_Equation.UseVisualStyleBackColor = false;
            this.m_Button_Add_Equation.Click += new System.EventHandler(this.m_Button_Add_Equation_Click);
            // 
            // m_Button_DoCalculate
            // 
            this.m_Button_DoCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Button_DoCalculate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_Button_DoCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.m_Button_DoCalculate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_Button_DoCalculate.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaExec;
            this.m_Button_DoCalculate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_Button_DoCalculate.Location = new System.Drawing.Point(590, 397);
            this.m_Button_DoCalculate.Name = "m_Button_DoCalculate";
            this.m_Button_DoCalculate.Size = new System.Drawing.Size(95, 43);
            this.m_Button_DoCalculate.TabIndex = 10;
            this.m_Button_DoCalculate.Text = "       실행";
            this.m_Button_DoCalculate.UseVisualStyleBackColor = false;
            this.m_Button_DoCalculate.Click += new System.EventHandler(this.m_Button_DoCalculate_Click);
            // 
            // toolTip_Error
            // 
            this.toolTip_Error.IsBalloon = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(694, 28);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(134, 25);
            this.toolStripLabel1.Text = "toolStripLabel1";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(694, 503);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_Button_Clear);
            this.Controls.Add(this.m_Button_Add_Equation);
            this.Controls.Add(this.m_Button_DoCalculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_Calculator";
            this.Text = "계산 창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalculatingForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_Button_Clear;
        private System.Windows.Forms.Button m_Button_Add_Equation;
        private System.Windows.Forms.Button m_Button_DoCalculate;
        private System.Windows.Forms.ToolTip toolTip_Error;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}