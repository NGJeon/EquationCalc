namespace NGEquationCalc
{
    partial class Form_Admin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_CheckAdmin = new System.Windows.Forms.Button();
            this.m_button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(102, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "암호 : 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "<관리자 암호를 입력해주세요>";
            // 
            // txtBox_password
            // 
            this.txtBox_password.Location = new System.Drawing.Point(104, 49);
            this.txtBox_password.Name = "txtBox_password";
            this.txtBox_password.PasswordChar = '*';
            this.txtBox_password.Size = new System.Drawing.Size(100, 21);
            this.txtBox_password.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::NGEquationCalc.Properties.Resources.toolbtn_admin;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(31, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btn_CheckAdmin
            // 
            this.btn_CheckAdmin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_CheckAdmin.Location = new System.Drawing.Point(104, 79);
            this.btn_CheckAdmin.Name = "btn_CheckAdmin";
            this.btn_CheckAdmin.Size = new System.Drawing.Size(45, 23);
            this.btn_CheckAdmin.TabIndex = 9;
            this.btn_CheckAdmin.Text = "확인";
            this.btn_CheckAdmin.UseVisualStyleBackColor = true;
            this.btn_CheckAdmin.Click += new System.EventHandler(this.btn_CheckAdmin_Click);
            // 
            // m_button_cancel
            // 
            this.m_button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_button_cancel.Location = new System.Drawing.Point(159, 79);
            this.m_button_cancel.Name = "m_button_cancel";
            this.m_button_cancel.Size = new System.Drawing.Size(45, 23);
            this.m_button_cancel.TabIndex = 14;
            this.m_button_cancel.Text = "취소";
            this.m_button_cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(245, 133);
            this.Controls.Add(this.m_button_cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CheckAdmin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBox_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Admin";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBox_password;
        private System.Windows.Forms.Button btn_CheckAdmin;
        private System.Windows.Forms.Button m_button_cancel;
    }
}