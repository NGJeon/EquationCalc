namespace NGEquationCalc
{
    partial class Form_AddStaticVar
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_button_cancel = new System.Windows.Forms.Button();
            this.m_button_ok = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "전역변수 입력란입니다\r\n전역변수는 모든 수식에서 공통적으로 사용 될 수 있는 변수들을 지정할 수 있습니다.\r\n전역변수는 상수로써 숫자로만 기입이 " +
    "가능합니다 \r\n예) radian = 0.0174532925199433";
            // 
            // m_button_cancel
            // 
            this.m_button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_button_cancel.Location = new System.Drawing.Point(374, 284);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(97, 31);
            this.m_button_cancel.TabIndex = 3;
            this.m_button_cancel.Text = "취소";
            this.m_button_cancel.UseVisualStyleBackColor = true;
            this.m_button_cancel.Click += new System.EventHandler(this.m_button_cancel_Click);
            // 
            // m_button_ok
            // 
            this.m_button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_button_ok.Location = new System.Drawing.Point(261, 284);
            this.m_button_ok.Name = "m_button_ok";
            this.m_button_ok.Size = new System.Drawing.Size(97, 31);
            this.m_button_ok.TabIndex = 2;
            this.m_button_ok.Text = "저장";
            this.m_button_ok.UseVisualStyleBackColor = true;
            this.m_button_ok.Click += new System.EventHandler(this.m_button_ok_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 71);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(459, 201);
            this.textBox1.TabIndex = 4;
            // 
            // Form_AddStaticVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 327);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.m_button_ok);
            this.Controls.Add(this.label1);
            this.Name = "Form_AddStaticVar";
            this.Text = "전역변수 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddStaticVar_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_button_cancel;
        private System.Windows.Forms.Button m_button_ok;
        private System.Windows.Forms.TextBox textBox1;
    }
}