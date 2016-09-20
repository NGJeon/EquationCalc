using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGEquationCalc
{
    public partial class Form_Switch : Form
    {
        private int List_Index = 0;
        private Dictionary<string, string> m_Dictionary_Case;

        public Form_Switch()
        {
            InitializeComponent();
        }

        public Form_Switch( Dictionary<string,string> in_data )
        {
            InitializeComponent();

            foreach( var data in in_data )
            {
                this.Controls.Add(MakeNewGroup(data.Key, data.Value));
            }
            
        }

        private void m_button_Add_Case_Click(object sender, EventArgs e)
        {
           GroupBox group = MakeNewGroup();
           this.Controls.Add(group);
        }

        public Dictionary<string,string> GetCaseDictionary()
        {
            m_Dictionary_Case = new Dictionary<string, string>();
            foreach( Control ctrl in this.Controls )
            {
                if (!(ctrl is GroupBox))
                    continue;
                GroupBox pgroup = (GroupBox)ctrl;
                string name = pgroup.Controls["NAME"].Text.ToLower();
                string text = pgroup.Controls["TEXT"].Text;

                m_Dictionary_Case[name] = text;
                
            }
            return m_Dictionary_Case;
        }

        private GroupBox MakeNewGroup(string name = "", string casetext = "")
        {
            Label name_label = new Label();
            name_label.Location = new Point(10, 20);
            name_label.Size = new Size(29, 12);
            name_label.Text = "이름";
            
            TextBox name_textbox = new TextBox();
            name_textbox.Location = new Point(57, 17);
            name_textbox.Name = "NAME";
            name_textbox.Size = new Size(142, 21);
            name_textbox.Text = name;

            Button name_button = new Button();
            name_button.Location = new Point(205, 17);
            name_button.Size = new Size(32, 21);
            name_button.Text = "X";
            name_button.Click += new EventHandler(name_button_Click);

            Label case_label = new Label();
            case_label.Location = new Point(10, 48);
            case_label.Size = new Size(41, 12);
            case_label.Text = "분기식";

            TextBox case_textbox = new TextBox();
            case_textbox.Location = new Point(57, 44);
            case_textbox.Size = new Size(180, 63);
            case_textbox.Name = "TEXT";
            case_textbox.Text = casetext;
            case_textbox.Multiline = true;

            GroupBox groupbox1 = new GroupBox();
            groupbox1.Name = "Group" + List_Index.ToString();
            groupbox1.Size = new Size(250, 125);
            groupbox1.Location = new Point(12, 12 + 125 * List_Index);
            groupbox1.Text = "그룹";
            groupbox1.Controls.Add(name_label);
            groupbox1.Controls.Add(name_textbox);
            groupbox1.Controls.Add(name_button);
            groupbox1.Controls.Add(case_label);
            groupbox1.Controls.Add(case_textbox);
            List_Index++;

            int newheight = (100 + (125 * List_Index));

            this.ClientSize = new Size(ClientSize.Width, newheight + 100);

            return groupbox1;
            
        }

        void name_button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Parent.Dispose();
            List_Index--;
            RefreshUI();
        }

        void RefreshUI()
        {
            int group_index = 0;
            foreach( Control group in this.Controls )
            {
                if( group is GroupBox )
                {
                    group.Location = new Point(12, 12 + 125 * group_index++);
                }
            }

            int newheight = (100 + (125 * group_index));
            this.ClientSize = new Size(ClientSize.Width, newheight + 100);
        }

        private void m_Button_OK_Click(object sender, EventArgs e)
        {

        }

        private void m_Button_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
