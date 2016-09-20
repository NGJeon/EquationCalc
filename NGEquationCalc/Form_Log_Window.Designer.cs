namespace NGEquationCalc
{
    partial class Form_Log_Window
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
            this.m_button_save = new System.Windows.Forms.Button();
            this.m_button_delete = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // m_button_save
            // 
            this.m_button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_button_save.Location = new System.Drawing.Point(334, 21);
            this.m_button_save.Name = "m_button_save";
            this.m_button_save.Size = new System.Drawing.Size(118, 28);
            this.m_button_save.TabIndex = 1;
            this.m_button_save.Text = "저장";
            this.m_button_save.UseVisualStyleBackColor = true;
            this.m_button_save.Click += new System.EventHandler(this.m_button_save_Click);
            // 
            // m_button_delete
            // 
            this.m_button_delete.Location = new System.Drawing.Point(12, 21);
            this.m_button_delete.Name = "m_button_delete";
            this.m_button_delete.Size = new System.Drawing.Size(118, 31);
            this.m_button_delete.TabIndex = 2;
            this.m_button_delete.Text = "지우기";
            this.m_button_delete.UseVisualStyleBackColor = true;
            this.m_button_delete.Click += new System.EventHandler(this.m_button_delete_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.richTextBox1.Location = new System.Drawing.Point(-2, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(468, 487);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form_Log_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(464, 544);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.m_button_delete);
            this.Controls.Add(this.m_button_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Log_Window";
            this.Text = "공식 로그창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Log_Window_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_button_save;
        private System.Windows.Forms.Button m_button_delete;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}