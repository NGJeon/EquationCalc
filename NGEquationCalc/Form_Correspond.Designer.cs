namespace NGEquationCalc
{
    partial class Form_Correspond
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.m_TextBox_SelectedVariable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 93);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = ":";
            this.treeView1.Size = new System.Drawing.Size(264, 228);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(187, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_TextBox_SelectedVariable
            // 
            this.m_TextBox_SelectedVariable.Location = new System.Drawing.Point(12, 66);
            this.m_TextBox_SelectedVariable.Name = "m_TextBox_SelectedVariable";
            this.m_TextBox_SelectedVariable.ReadOnly = true;
            this.m_TextBox_SelectedVariable.Size = new System.Drawing.Size(264, 21);
            this.m_TextBox_SelectedVariable.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "다른 계산식의 결과값을 해당 변수에 적용하려면";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "아래 창에서 사용하고자 하는 변수를 찾아";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "더블클릭 한 뒤에 확인버튼을 누르십시오";
            // 
            // Form_Correspond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 369);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_TextBox_SelectedVariable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form_Correspond";
            this.Text = "다른식에서 적용";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox m_TextBox_SelectedVariable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}