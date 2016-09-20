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
    public partial class Form_Correspond : Form
    {        
        public string SelectedVariablePath;
        public bool isSetCorrespond = false;
        public Form_Correspond(Dictionary<string,EquationInformation> eqinfo)
        {
            InitializeComponent();
            foreach (string key in eqinfo.Keys  )
            {
                var dic_variable = eqinfo[key].m_Dictionary_Equation;
                TreeNode CategoryNode = treeView1.Nodes.Add(key);
                foreach (VariableData var_key in dic_variable.Values)
                {
                    if (var_key.IsContainEquation && !var_key.IsHiddenVariable)
                        CategoryNode.Nodes.Add(var_key.Name);
                }
            }
            treeView1.Sort();
            
            
            
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode selectedNode = treeView1.SelectedNode;
                if (selectedNode.Parent != null)
                {
                    isSetCorrespond = true;
                    m_TextBox_SelectedVariable.Text = selectedNode.Text;
                    SelectedVariablePath = selectedNode.Parent.Text + ":"+ selectedNode.Text;
                }
            }
        }

       
    }
}
