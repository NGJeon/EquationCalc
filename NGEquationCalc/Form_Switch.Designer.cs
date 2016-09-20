namespace NGEquationCalc
{
    partial class Form_Switch
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
            this.m_Button_OK = new System.Windows.Forms.Button();
            this.m_Button_Cancel = new System.Windows.Forms.Button();
            this.m_button_Add_Case = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_Button_OK
            // 
            this.m_Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_Button_OK.Location = new System.Drawing.Point(158, 220);
            this.m_Button_OK.Name = "m_Button_OK";
            this.m_Button_OK.Size = new System.Drawing.Size(53, 30);
            this.m_Button_OK.TabIndex = 1;
            this.m_Button_OK.Text = "확인";
            this.m_Button_OK.UseVisualStyleBackColor = true;
            this.m_Button_OK.Click += new System.EventHandler(this.m_Button_OK_Click);
            // 
            // m_Button_Cancel
            // 
            this.m_Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_Button_Cancel.Location = new System.Drawing.Point(219, 220);
            this.m_Button_Cancel.Name = "m_Button_Cancel";
            this.m_Button_Cancel.Size = new System.Drawing.Size(53, 30);
            this.m_Button_Cancel.TabIndex = 2;
            this.m_Button_Cancel.Text = "취소";
            this.m_Button_Cancel.UseVisualStyleBackColor = true;
            this.m_Button_Cancel.Click += new System.EventHandler(this.m_Button_Cancel_Click);
            // 
            // m_button_Add_Case
            // 
            this.m_button_Add_Case.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_button_Add_Case.Location = new System.Drawing.Point(12, 220);
            this.m_button_Add_Case.Name = "m_button_Add_Case";
            this.m_button_Add_Case.Size = new System.Drawing.Size(75, 30);
            this.m_button_Add_Case.TabIndex = 3;
            this.m_button_Add_Case.Text = "분기추가";
            this.m_button_Add_Case.UseVisualStyleBackColor = true;
            this.m_button_Add_Case.Click += new System.EventHandler(this.m_button_Add_Case_Click);
            // 
            // Form_Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.m_button_Add_Case);
            this.Controls.Add(this.m_Button_Cancel);
            this.Controls.Add(this.m_Button_OK);
            this.Name = "Form_Switch";
            this.Text = "분기식 추가/수정";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_Button_OK;
        private System.Windows.Forms.Button m_Button_Cancel;
        private System.Windows.Forms.Button m_button_Add_Case;
    }
}