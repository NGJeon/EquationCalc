namespace NGEquationCalc
{
    partial class Form_AddCalculator
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
            this.m_Button_Add_EuqationInfomation = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.m_button_Category = new System.Windows.Forms.Button();
            this.m_Button_OK = new System.Windows.Forms.Button();
            this.m_Button_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_button_NameChange = new System.Windows.Forms.Button();
            this.m_Button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_Button_Add_EuqationInfomation
            // 
            this.m_Button_Add_EuqationInfomation.Location = new System.Drawing.Point(372, 128);
            this.m_Button_Add_EuqationInfomation.Name = "m_Button_Add_EuqationInfomation";
            this.m_Button_Add_EuqationInfomation.Size = new System.Drawing.Size(114, 36);
            this.m_Button_Add_EuqationInfomation.TabIndex = 2;
            this.m_Button_Add_EuqationInfomation.Text = "항목 추가";
            this.m_Button_Add_EuqationInfomation.UseVisualStyleBackColor = true;
            this.m_Button_Add_EuqationInfomation.Click += new System.EventHandler(this.m_Button_Add_EuqationInfomation_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.FullRowSelect = true;
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(12, 86);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = ":";
            this.treeView1.Size = new System.Drawing.Size(354, 248);
            this.treeView1.TabIndex = 2;
            this.treeView1.TabStop = false;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // m_button_Category
            // 
            this.m_button_Category.Location = new System.Drawing.Point(372, 86);
            this.m_button_Category.Name = "m_button_Category";
            this.m_button_Category.Size = new System.Drawing.Size(114, 36);
            this.m_button_Category.TabIndex = 1;
            this.m_button_Category.Text = "카테고리 추가";
            this.m_button_Category.UseVisualStyleBackColor = true;
            this.m_button_Category.Click += new System.EventHandler(this.m_button_Category_Click);
            // 
            // m_Button_OK
            // 
            this.m_Button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_Button_OK.Location = new System.Drawing.Point(372, 295);
            this.m_Button_OK.Name = "m_Button_OK";
            this.m_Button_OK.Size = new System.Drawing.Size(53, 36);
            this.m_Button_OK.TabIndex = 6;
            this.m_Button_OK.Text = "확인";
            this.m_Button_OK.UseVisualStyleBackColor = true;
            this.m_Button_OK.Click += new System.EventHandler(this.m_Button_OK_Click);
            // 
            // m_Button_Delete
            // 
            this.m_Button_Delete.Location = new System.Drawing.Point(372, 212);
            this.m_Button_Delete.Name = "m_Button_Delete";
            this.m_Button_Delete.Size = new System.Drawing.Size(114, 36);
            this.m_Button_Delete.TabIndex = 4;
            this.m_Button_Delete.Text = "삭제";
            this.m_Button_Delete.UseVisualStyleBackColor = true;
            this.m_Button_Delete.Click += new System.EventHandler(this.m_Button_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "계산페이지를 추가/삭제 할 수 있습니다. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "관리자 모드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "해당 계산페이지의 체크박스를 클릭해 잠금모드로 설정 할 수 있습니다\r\n잠금모드로 설정된 페이지는 일반 사용자가 수정/삭제 할 수 없습니다";
            // 
            // m_button_NameChange
            // 
            this.m_button_NameChange.Location = new System.Drawing.Point(372, 170);
            this.m_button_NameChange.Name = "m_button_NameChange";
            this.m_button_NameChange.Size = new System.Drawing.Size(114, 36);
            this.m_button_NameChange.TabIndex = 3;
            this.m_button_NameChange.Text = "이름 변경";
            this.m_button_NameChange.UseVisualStyleBackColor = true;
            this.m_button_NameChange.Click += new System.EventHandler(this.m_button_NameChange_Click);
            // 
            // m_Button_Cancel
            // 
            this.m_Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_Button_Cancel.Location = new System.Drawing.Point(431, 295);
            this.m_Button_Cancel.Name = "m_Button_Cancel";
            this.m_Button_Cancel.Size = new System.Drawing.Size(55, 36);
            this.m_Button_Cancel.TabIndex = 5;
            this.m_Button_Cancel.Text = "취소";
            this.m_Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_AddCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 346);
            this.Controls.Add(this.m_Button_Cancel);
            this.Controls.Add(this.m_button_NameChange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_Button_Delete);
            this.Controls.Add(this.m_Button_OK);
            this.Controls.Add(this.m_button_Category);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.m_Button_Add_EuqationInfomation);
            this.Name = "Form_AddCalculator";
            this.Text = "추가/삭제";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_Button_Add_EuqationInfomation;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button m_button_Category;
        private System.Windows.Forms.Button m_Button_OK;
        private System.Windows.Forms.Button m_Button_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_button_NameChange;
        private System.Windows.Forms.Button m_Button_Cancel;
    }
}