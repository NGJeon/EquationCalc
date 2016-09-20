namespace NGEquationCalc
{
    partial class Form_Edit_Calculator
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
            this.m_textbox_equation = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_button_listbox2_Down = new System.Windows.Forms.Button();
            this.m_button_Listbox2_Up = new System.Windows.Forms.Button();
            this.m_button_listbox1_Down = new System.Windows.Forms.Button();
            this.m_button_Listbox1_Up = new System.Windows.Forms.Button();
            this.m_button_setImage = new System.Windows.Forms.Button();
            this.m_textbox_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_picturebox_preview = new System.Windows.Forms.PictureBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.m_Button_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picturebox_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "수식";
            // 
            // m_textbox_equation
            // 
            this.m_textbox_equation.BackColor = System.Drawing.Color.White;
            this.m_textbox_equation.ForeColor = System.Drawing.Color.Black;
            this.m_textbox_equation.Location = new System.Drawing.Point(14, 66);
            this.m_textbox_equation.Name = "m_textbox_equation";
            this.m_textbox_equation.ReadOnly = true;
            this.m_textbox_equation.Size = new System.Drawing.Size(629, 21);
            this.m_textbox_equation.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(367, 112);
            this.listBox1.TabIndex = 3;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteKeyDown);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.White;
            this.listBox2.ForeColor = System.Drawing.Color.Black;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(7, 133);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(366, 160);
            this.listBox2.TabIndex = 4;
            this.listBox2.Click += new System.EventHandler(this.listBox2_Click);
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            this.listBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteKeyDown);
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.ForeColor = System.Drawing.Color.Black;
            this.button_OK.Location = new System.Drawing.Point(408, 416);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(112, 29);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "확인";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_picturebox_preview);
            this.groupBox1.Controls.Add(this.m_button_listbox2_Down);
            this.groupBox1.Controls.Add(this.m_button_Listbox2_Up);
            this.groupBox1.Controls.Add(this.m_button_listbox1_Down);
            this.groupBox1.Controls.Add(this.m_button_Listbox1_Up);
            this.groupBox1.Controls.Add(this.m_button_setImage);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 308);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "변수목록";
            // 
            // m_button_listbox2_Down
            // 
            this.m_button_listbox2_Down.ForeColor = System.Drawing.Color.Black;
            this.m_button_listbox2_Down.Location = new System.Drawing.Point(379, 209);
            this.m_button_listbox2_Down.Name = "m_button_listbox2_Down";
            this.m_button_listbox2_Down.Size = new System.Drawing.Size(27, 31);
            this.m_button_listbox2_Down.TabIndex = 14;
            this.m_button_listbox2_Down.Text = "▼";
            this.m_button_listbox2_Down.UseVisualStyleBackColor = true;
            this.m_button_listbox2_Down.Click += new System.EventHandler(this.m_button_listbox2_Down_Click);
            // 
            // m_button_Listbox2_Up
            // 
            this.m_button_Listbox2_Up.ForeColor = System.Drawing.Color.Black;
            this.m_button_Listbox2_Up.Location = new System.Drawing.Point(379, 172);
            this.m_button_Listbox2_Up.Name = "m_button_Listbox2_Up";
            this.m_button_Listbox2_Up.Size = new System.Drawing.Size(27, 31);
            this.m_button_Listbox2_Up.TabIndex = 13;
            this.m_button_Listbox2_Up.Text = "▲";
            this.m_button_Listbox2_Up.UseVisualStyleBackColor = true;
            this.m_button_Listbox2_Up.Click += new System.EventHandler(this.m_button_Listbox2_Up_Click);
            // 
            // m_button_listbox1_Down
            // 
            this.m_button_listbox1_Down.ForeColor = System.Drawing.Color.Black;
            this.m_button_listbox1_Down.Location = new System.Drawing.Point(379, 77);
            this.m_button_listbox1_Down.Name = "m_button_listbox1_Down";
            this.m_button_listbox1_Down.Size = new System.Drawing.Size(27, 31);
            this.m_button_listbox1_Down.TabIndex = 12;
            this.m_button_listbox1_Down.Text = "▼";
            this.m_button_listbox1_Down.UseVisualStyleBackColor = true;
            this.m_button_listbox1_Down.Click += new System.EventHandler(this.m_button_listbox1_Down_Click);
            // 
            // m_button_Listbox1_Up
            // 
            this.m_button_Listbox1_Up.ForeColor = System.Drawing.Color.Black;
            this.m_button_Listbox1_Up.Location = new System.Drawing.Point(379, 40);
            this.m_button_Listbox1_Up.Name = "m_button_Listbox1_Up";
            this.m_button_Listbox1_Up.Size = new System.Drawing.Size(27, 31);
            this.m_button_Listbox1_Up.TabIndex = 11;
            this.m_button_Listbox1_Up.Text = "▲";
            this.m_button_Listbox1_Up.UseVisualStyleBackColor = true;
            this.m_button_Listbox1_Up.Click += new System.EventHandler(this.m_button_Listbox1_Up_Click);
            // 
            // m_button_setImage
            // 
            this.m_button_setImage.ForeColor = System.Drawing.Color.Black;
            this.m_button_setImage.Location = new System.Drawing.Point(548, 15);
            this.m_button_setImage.Name = "m_button_setImage";
            this.m_button_setImage.Size = new System.Drawing.Size(88, 24);
            this.m_button_setImage.TabIndex = 10;
            this.m_button_setImage.Text = "이미지 변경";
            this.m_button_setImage.UseVisualStyleBackColor = true;
            this.m_button_setImage.Click += new System.EventHandler(this.m_button_setImage_Click);
            // 
            // m_textbox_description
            // 
            this.m_textbox_description.BackColor = System.Drawing.Color.White;
            this.m_textbox_description.ForeColor = System.Drawing.Color.Black;
            this.m_textbox_description.Location = new System.Drawing.Point(13, 27);
            this.m_textbox_description.Name = "m_textbox_description";
            this.m_textbox_description.Size = new System.Drawing.Size(630, 21);
            this.m_textbox_description.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "설명";
            // 
            // m_picturebox_preview
            // 
            this.m_picturebox_preview.Location = new System.Drawing.Point(426, 45);
            this.m_picturebox_preview.Name = "m_picturebox_preview";
            this.m_picturebox_preview.Size = new System.Drawing.Size(210, 158);
            this.m_picturebox_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picturebox_preview.TabIndex = 15;
            this.m_picturebox_preview.TabStop = false;
            this.m_picturebox_preview.MouseEnter += new System.EventHandler(this.m_picturebox_preview_MouseEnter_1);
            this.m_picturebox_preview.MouseLeave += new System.EventHandler(this.m_picturebox_preview_MouseLeave);
            this.m_picturebox_preview.MouseHover += new System.EventHandler(this.m_picturebox_preview_MouseHover);
            // 
            // button_delete
            // 
            this.button_delete.ForeColor = System.Drawing.Color.Black;
            this.button_delete.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaRemove;
            this.button_delete.Location = new System.Drawing.Point(60, 416);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(48, 40);
            this.button_delete.TabIndex = 8;
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_Add
            // 
            this.button_Add.ForeColor = System.Drawing.Color.Black;
            this.button_Add.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaAdd;
            this.button_Add.Location = new System.Drawing.Point(6, 416);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(48, 40);
            this.button_Add.TabIndex = 1;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_Button_Cancel
            // 
            this.m_Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_Button_Cancel.ForeColor = System.Drawing.Color.Black;
            this.m_Button_Cancel.Location = new System.Drawing.Point(537, 416);
            this.m_Button_Cancel.Name = "m_Button_Cancel";
            this.m_Button_Cancel.Size = new System.Drawing.Size(112, 29);
            this.m_Button_Cancel.TabIndex = 12;
            this.m_Button_Cancel.Text = "취소";
            this.m_Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Form_Edit_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(661, 459);
            this.Controls.Add(this.m_Button_Cancel);
            this.Controls.Add(this.m_textbox_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_textbox_equation);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_Edit_Calculator";
            this.Text = "공식 추가/수정";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picturebox_preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.TextBox m_textbox_equation;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox m_textbox_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_button_setImage;
        private System.Windows.Forms.Button m_button_listbox1_Down;
        private System.Windows.Forms.Button m_button_Listbox1_Up;
        private System.Windows.Forms.Button m_button_listbox2_Down;
        private System.Windows.Forms.Button m_button_Listbox2_Up;
        private System.Windows.Forms.PictureBox m_picturebox_preview;
        private System.Windows.Forms.Button m_Button_Cancel;
    }
}