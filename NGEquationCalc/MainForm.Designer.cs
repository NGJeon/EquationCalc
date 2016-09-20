namespace NGEquationCalc
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.m_treeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_textBox_Search = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_toolButton_Admin = new System.Windows.Forms.ToolStripButton();
            this.m_toolButton_Load = new System.Windows.Forms.ToolStripButton();
            this.m_toolButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolButton_AddCalculator = new System.Windows.Forms.ToolStripButton();
            this.m_toolbtn_AddStatic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_toolButton_Log = new System.Windows.Forms.ToolStripButton();
            this.m_toolButton_Result = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.m_label_version = new System.Windows.Forms.Label();
            this.m_Button_Search = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_button_ReloadTree = new System.Windows.Forms.Button();
            this.m_label_admin = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(193, 152);
            // 
            // m_treeView
            // 
            this.m_treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.m_treeView.ImageIndex = 0;
            this.m_treeView.ImageList = this.imageList1;
            this.m_treeView.Location = new System.Drawing.Point(12, 116);
            this.m_treeView.Name = "m_treeView";
            this.m_treeView.PathSeparator = ":";
            this.m_treeView.SelectedImageIndex = 0;
            this.m_treeView.ShowNodeToolTips = true;
            this.m_treeView.Size = new System.Drawing.Size(372, 461);
            this.m_treeView.TabIndex = 4;
            this.m_treeView.TabStop = false;
            this.m_treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.m_treeView_DrawNode);
            this.m_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeView_NodeMouseClick);
            this.m_treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_treeView_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.jpg");
            this.imageList1.Images.SetKeyName(1, "2.jpg");
            // 
            // m_textBox_Search
            // 
            this.m_textBox_Search.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textBox_Search.Location = new System.Drawing.Point(12, 82);
            this.m_textBox_Search.Name = "m_textBox_Search";
            this.m_textBox_Search.Size = new System.Drawing.Size(289, 22);
            this.m_textBox_Search.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolButton_Admin,
            this.m_toolButton_Load,
            this.m_toolButton_Save,
            this.toolStripSeparator1,
            this.m_toolButton_AddCalculator,
            this.m_toolbtn_AddStatic,
            this.toolStripSeparator2,
            this.m_toolButton_Log,
            this.m_toolButton_Result,
            this.toolStripSeparator3,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(397, 47);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_toolButton_Admin
            // 
            this.m_toolButton_Admin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_Admin.Image = global::NGEquationCalc.Properties.Resources.toolbtn_admin;
            this.m_toolButton_Admin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_Admin.Name = "m_toolButton_Admin";
            this.m_toolButton_Admin.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_Admin.ToolTipText = "관리자 로그인";
            this.m_toolButton_Admin.Click += new System.EventHandler(this.m_button_Admin_Click);
            // 
            // m_toolButton_Load
            // 
            this.m_toolButton_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_Load.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaLoad;
            this.m_toolButton_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_Load.Name = "m_toolButton_Load";
            this.m_toolButton_Load.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_Load.Text = "toolStripButton2";
            this.m_toolButton_Load.ToolTipText = "불러오기";
            this.m_toolButton_Load.Click += new System.EventHandler(this.m_button_load_Click);
            // 
            // m_toolButton_Save
            // 
            this.m_toolButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_Save.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaSave;
            this.m_toolButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_Save.Name = "m_toolButton_Save";
            this.m_toolButton_Save.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_Save.Text = "toolStripButton3";
            this.m_toolButton_Save.ToolTipText = "저장";
            this.m_toolButton_Save.Click += new System.EventHandler(this.m_button_save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // m_toolButton_AddCalculator
            // 
            this.m_toolButton_AddCalculator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_AddCalculator.Image = global::NGEquationCalc.Properties.Resources.toolbtn_formulaModify;
            this.m_toolButton_AddCalculator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_AddCalculator.Name = "m_toolButton_AddCalculator";
            this.m_toolButton_AddCalculator.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_AddCalculator.Text = "toolStripButton6";
            this.m_toolButton_AddCalculator.ToolTipText = "계산기 수정";
            this.m_toolButton_AddCalculator.Click += new System.EventHandler(this.m_toolButton_AddCalculator_Click);
            // 
            // m_toolbtn_AddStatic
            // 
            this.m_toolbtn_AddStatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolbtn_AddStatic.Image = ((System.Drawing.Image)(resources.GetObject("m_toolbtn_AddStatic.Image")));
            this.m_toolbtn_AddStatic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolbtn_AddStatic.Name = "m_toolbtn_AddStatic";
            this.m_toolbtn_AddStatic.Size = new System.Drawing.Size(44, 44);
            this.m_toolbtn_AddStatic.Text = "전역변수 편집";
            this.m_toolbtn_AddStatic.Click += new System.EventHandler(this.m_toolbtn_AddStatic_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // m_toolButton_Log
            // 
            this.m_toolButton_Log.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_Log.Image = global::NGEquationCalc.Properties.Resources.toolbtn_log;
            this.m_toolButton_Log.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_Log.Name = "m_toolButton_Log";
            this.m_toolButton_Log.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_Log.Text = "toolStripButton4";
            this.m_toolButton_Log.ToolTipText = "로그창 열기";
            this.m_toolButton_Log.Click += new System.EventHandler(this.m_Button_Log_Click);
            // 
            // m_toolButton_Result
            // 
            this.m_toolButton_Result.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_toolButton_Result.Image = global::NGEquationCalc.Properties.Resources.toolbtn_resultValues;
            this.m_toolButton_Result.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_toolButton_Result.Name = "m_toolButton_Result";
            this.m_toolButton_Result.Size = new System.Drawing.Size(44, 44);
            this.m_toolButton_Result.Text = "toolStripButton5";
            this.m_toolButton_Result.ToolTipText = "결과값 확인";
            this.m_toolButton_Result.Click += new System.EventHandler(this.m_toolButton_Result_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::NGEquationCalc.Properties.Resources.toolbtn_help;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::NGEquationCalc.Properties.Resources.toolbtn_calc;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "계산기";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // m_label_version
            // 
            this.m_label_version.AutoSize = true;
            this.m_label_version.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_label_version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_label_version.Location = new System.Drawing.Point(12, 57);
            this.m_label_version.Name = "m_label_version";
            this.m_label_version.Size = new System.Drawing.Size(65, 11);
            this.m_label_version.TabIndex = 12;
            this.m_label_version.Text = "Version :";
            // 
            // m_Button_Search
            // 
            this.m_Button_Search.Location = new System.Drawing.Point(306, 82);
            this.m_Button_Search.Name = "m_Button_Search";
            this.m_Button_Search.Size = new System.Drawing.Size(53, 22);
            this.m_Button_Search.TabIndex = 5;
            this.m_Button_Search.Text = "검색";
            this.m_Button_Search.UseVisualStyleBackColor = true;
            this.m_Button_Search.Click += new System.EventHandler(this.button4_Click);
            // 
            // m_button_ReloadTree
            // 
            this.m_button_ReloadTree.Image = global::NGEquationCalc.Properties.Resources.btn_ReloadTree;
            this.m_button_ReloadTree.Location = new System.Drawing.Point(361, 80);
            this.m_button_ReloadTree.Name = "m_button_ReloadTree";
            this.m_button_ReloadTree.Size = new System.Drawing.Size(25, 24);
            this.m_button_ReloadTree.TabIndex = 13;
            this.m_button_ReloadTree.UseVisualStyleBackColor = true;
            this.m_button_ReloadTree.Click += new System.EventHandler(this.m_button_ReloadTree_Click);
            // 
            // m_label_admin
            // 
            this.m_label_admin.AutoSize = true;
            this.m_label_admin.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold);
            this.m_label_admin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_label_admin.Location = new System.Drawing.Point(319, 57);
            this.m_label_admin.Name = "m_label_admin";
            this.m_label_admin.Size = new System.Drawing.Size(65, 11);
            this.m_label_admin.TabIndex = 14;
            this.m_label_admin.Text = "관리자모드";
            this.m_label_admin.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(397, 589);
            this.Controls.Add(this.m_label_admin);
            this.Controls.Add(this.m_button_ReloadTree);
            this.Controls.Add(this.m_label_version);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.m_Button_Search);
            this.Controls.Add(this.m_textBox_Search);
            this.Controls.Add(this.m_treeView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PBN (ROKAF)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.TreeView m_treeView;
        private System.Windows.Forms.Button m_Button_Search;
        private System.Windows.Forms.TextBox m_textBox_Search;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_toolButton_Admin;
        private System.Windows.Forms.ToolStripButton m_toolButton_Load;
        private System.Windows.Forms.ToolStripButton m_toolButton_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_toolButton_Log;
        private System.Windows.Forms.ToolStripButton m_toolButton_Result;
        private System.Windows.Forms.ToolStripButton m_toolButton_AddCalculator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Label m_label_version;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button m_button_ReloadTree;
        private System.Windows.Forms.ToolStripButton m_toolbtn_AddStatic;
        private System.Windows.Forms.Label m_label_admin;
    }
}

