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
    public partial class DebugForm : Form
    {
        Dictionary<string, EquationInformation> m_dic_eqinfo;
        
        public DebugForm(Dictionary<string,EquationInformation> eqinfo )
        {
           
            InitializeComponent();
            treeView1.ShowNodeToolTips = true;
            foreach( var datas in eqinfo)
            {
                var node = treeView1.Nodes.Add(datas.Key);
                foreach( var vdatas in datas.Value.m_Dictionary_Equation )
                {
                    if (vdatas.Value.IsCorrespond)
                    {
                        node.Nodes.Add(vdatas.Key).ToolTipText = vdatas.Value.CorrespontVarName;                  
                        vdatas.Value.IsCorrespond = false;
                        vdatas.Value.CorrespontVarName = "";
                        
                    }
                }
            }
            m_dic_eqinfo = eqinfo;
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                if (treeView1.SelectedNode != null)
                {
                    if (treeView1.SelectedNode.Parent != null)
                    {
                        m_dic_eqinfo[treeView1.SelectedNode.Parent.Text].m_Dictionary_Equation.Remove(treeView1.SelectedNode.Text);
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                    }
                }
            }
           
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if( e.Node.Parent != null )
            {
                string path = e.Node.FullPath;

                Clipboard.SetText(((ComparableVariable)m_dic_eqinfo[treeView1.SelectedNode.Parent.Text].m_Dictionary_Equation[e.Node.Text]).GetCompareEquation());
            }
        }
    }
}
