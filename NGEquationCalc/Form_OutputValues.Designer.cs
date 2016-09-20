namespace NGEquationCalc
{
    partial class Form_OutputValues
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
            this.dataGridView_Values = new System.Windows.Forms.DataGridView();
            this.btn_SaveExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Values)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Values
            // 
            this.dataGridView_Values.AllowUserToAddRows = false;
            this.dataGridView_Values.AllowUserToDeleteRows = false;
            this.dataGridView_Values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Values.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Values.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Values.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Values.Name = "dataGridView_Values";
            this.dataGridView_Values.RowTemplate.Height = 23;
            this.dataGridView_Values.Size = new System.Drawing.Size(619, 413);
            this.dataGridView_Values.TabIndex = 1;
            // 
            // btn_SaveExcel
            // 
            this.btn_SaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveExcel.Location = new System.Drawing.Point(529, 419);
            this.btn_SaveExcel.Name = "btn_SaveExcel";
            this.btn_SaveExcel.Size = new System.Drawing.Size(84, 36);
            this.btn_SaveExcel.TabIndex = 2;
            this.btn_SaveExcel.Text = "저장(엑셀)";
            this.btn_SaveExcel.UseVisualStyleBackColor = true;
            this.btn_SaveExcel.Click += new System.EventHandler(this.btn_SaveExcel_Click);
            // 
            // Form_OutputValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 467);
            this.Controls.Add(this.btn_SaveExcel);
            this.Controls.Add(this.dataGridView_Values);
            this.Name = "Form_OutputValues";
            this.Text = "결과 값 확인";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Values)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Values;
        private System.Windows.Forms.Button btn_SaveExcel;
    }
}