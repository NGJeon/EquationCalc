using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace NGEquationCalc
{
    /// <summary>
    /// 계산 페이지 추가 삭제 폼
    /// </summary>
    public partial class Form_AddCalculator : Form
    {       
        bool isAdminMode;
        bool InitializeComplete = false; // 트리뷰가 다 만들어졌는지 안만들어졌는지
        bool AfterCheckEntrance = false; // AfterCheck의 무한호출을 막기위해 만듬.
        
        public Dictionary<string, EquationInformation> m_Dic_equationInfomation; // Mainform에서 넘어온 dictionary -> by deep copy
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="equationInfomation">Treeview를 관리하기 위한 Dictionary - Deep Copy</param>
        /// <param name="isAdminLogined"> 관리자 로그인 상태 </param>
        public Form_AddCalculator(Dictionary<string,EquationInformation> equationInfomation, bool isAdminLogined )
        {
            
            InitializeComponent();
            isAdminMode = isAdminLogined;
            if( !isAdminLogined )
            {
                label2.Visible = false;
                label3.Visible = false;
                treeView1.CheckBoxes = false;
            }
            else
            {
                treeView1.CheckBoxes = true;
            }            

            m_Dic_equationInfomation = new Dictionary<string, EquationInformation>(equationInfomation); // 넘어온 사전을 복사

            // TreeView 생성.
            foreach (var dic in m_Dic_equationInfomation)
            {
                String[] varpath = dic.Key.Split(':'); // path를 나눠서 0은 부모값에 1은 차일드로

                if (!treeView1.Nodes.ContainsKey(varpath[0]))
                {
                    TreeNode nodeParent = new TreeNode();
                    nodeParent.Name = varpath[0].ToLower();
                    nodeParent.Text = varpath[0];
                    treeView1.Nodes.Add(nodeParent);
                }
                TreeNode nodeChild = new TreeNode();
                nodeChild.Name = varpath[1].ToLower();
                nodeChild.Text = varpath[1];

                nodeChild.Checked = dic.Value.isAdminLocked;               

                treeView1.Nodes[varpath[0]].Nodes.Add(nodeChild);                
                
            }

            foreach(TreeNode node in treeView1.Nodes)
            {
                bool isAllcheck = true;
                foreach( TreeNode in_node in node.Nodes )
                {
                    if (!in_node.Checked)
                        isAllcheck = false;
                }
                if (isAllcheck)
                    node.Checked = true;
            }
            
            
            InitializeComplete = true;
        }
        /// <summary>
        /// treeView_doubleclick 이벤트를 죽임. .net 자체버그때문에 죽임.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if( m.Msg == 0x203)
            {
                m.Result = IntPtr.Zero;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        /// <summary>
        /// 이름에 특수문자가 들어있는지 검사
        /// </summary>
        /// <param name="name">검사할 이름</param>
        /// <returns>유효한지 아닌지</returns>
        public bool FileNameValidate(string name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, "[\\\\/\":*?!@<>|]");
        }
        /// <summary>
        /// 카테고리 추가버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_button_Category_Click(object sender, EventArgs e)
        {
            treeView1.LabelEdit = true;
            treeView1.SelectedNode = treeView1.Nodes.Add("");
            treeView1.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// 항목추가버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_Button_Add_EuqationInfomation_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            // 카테고리를 클릭해야만 추가 가능
            if (treeView1.SelectedNode.Level == 0)
            {
                //if(treeView1.LabelEdit ==false )
                {
                    treeView1.LabelEdit = true;
                    var node = treeView1.SelectedNode.Nodes.Add("");
                    treeView1.SelectedNode.Expand();

                    treeView1.SelectedNode = node;
                    node.BeginEdit();                   
                }
                
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            
            //항목의 이름을 편집했을때
            if( e.Node.Level == 1 )
            {
                // Label을 변경했다.
                if (e.Label != null)
                {
                    // 변경한 문자열이 공백이라면
                    if (e.Label == "")
                    {
                        MessageBox.Show("이름을 입력해 주십시오");                        
                        e.Node.BeginEdit();
                        return;
                    }
                    else
                    {
                        // 특수문자검사
                        if (FileNameValidate(e.Label))
                        {
                            MessageBox.Show("이름에 사용할수 없는 문자가 있습니다.");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                            return;
                        }
                        if (e.Node.Parent.Nodes[e.Label.ToLower()] != null)
                        {
                            MessageBox.Show("해당 이름의 수식이 이미 존재합니다");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                            return;
                        }
                        // 만약 수정한 것이라면
                        if (m_Dic_equationInfomation.ContainsKey(e.Node.Parent.Text + ":" +e.Node.Text))
                        {
                            // 바꾼 이름으로 수식정보를 재편성
                            string before = e.Node.Parent.Text + ":" + e.Node.Text;
                            string after = e.Node.Parent.Text + ":" + e.Label;
                            ReNameEquationInformation(before, after);
                        }                       
                        // 새로 입력했다면.
                        else
                        {
                            try
                            {
                                // 새수식 입력.
                                string str = e.Node.Parent.Text + ":" + e.Label;
                                m_Dic_equationInfomation.Add(str, new EquationInformation());
                            }
                            catch (System.Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine(ex.Message);
                                e.Node.EndEdit(true);
                                treeView1.Nodes.Remove(e.Node);
                            }
                            
                        }

                    }
                }
                // 새로 만들고 아무것도 하지 않았으므로 노드 그냥 삭제.
                else
                {
                    if (e.Node.Text == "")
                    {
                        e.Node.EndEdit(true);
                        treeView1.Nodes.Remove(e.Node);
                    }
                }
            }
            // 카테고리 변경
            else
            {
                // 라벨에 무언가를 입력했다.
                if(e.Label != null )
                {
                    //아무것도 입력하지 않으면 재입력.
                    if (e.Label == "")
                    {
                        MessageBox.Show("이름을 입력해 주십시오");
                        e.Node.BeginEdit();
                        return;
                    }
                    else
                    {
                        if (FileNameValidate(e.Label))
                        {
                            MessageBox.Show("이름에 사용할수 없는 문자가 있습니다.");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                            return;
                        }
                        if (treeView1.Nodes[e.Label.ToLower()] != null)
                        {
                            MessageBox.Show("해당 이름의 카테고리가 이미 존재합니다");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                            return;
                        }


                        //이름 유효성 검사 완료뒤 해당 카테고리에 묶인 계산기데이터를 전부 변경해서 재입력.
                        foreach(TreeNode node in e.Node.Nodes )
                        {
                            string before = e.Node.Text + ":" + node.Text;
                            string after = e.Label + ":" + node.Text;
                            if(m_Dic_equationInfomation.ContainsKey(before))
                            {
                                ReNameEquationInformation(before, after);
                            }
                            
                        }
                    }
                }
                    //카테고리 츄ㅜ가를 누르고 아무것도 하지 않았으면 그냥 트리노드 삭제.
                else
                {
                    if (e.Node.Text == "")
                    {
                        e.Node.EndEdit(true);
                        treeView1.Nodes.Remove(e.Node);                        
                        return;
                    }                    
                   
                }

            }              
        }
        /// <summary>
        /// Dictionary의 Key값을 변경
        /// </summary>
        /// <param name="before">전 Key</param>
        /// <param name="after">새 Key</param>
        private void ReNameEquationInformation( string before, string after )
        {
            EquationInformation equation = new EquationInformation();
            m_Dic_equationInfomation.TryGetValue(before, out equation);
            m_Dic_equationInfomation.Remove(before);
            string[] b1 = before.Split(':');
            string[] a1 = after.Split(':');
            m_Dic_equationInfomation.Add(after, equation);            
            Trace.WriteLine("Complete! " + before + " -> " + after);
            foreach( VariableData vdata in equation.m_Dictionary_Equation.Values )
            {
                if( vdata.IsCorrespond )
                {
                    Trace.WriteLine("바뀌기 전 :" + vdata.CorrespontVarName);
                    vdata.CorrespontVarName = vdata.CorrespontVarName.Replace(b1[0], a1[0]);
                    Trace.WriteLine("바뀐뒤 :" + vdata.CorrespontVarName);
                }
            }
            
        }
        
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        /// <summary>
        /// delete키
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Delete )
            {
                TreeView _sender = (TreeView)sender;
                if( _sender.SelectedNode != null )
                {
                    removeNode(_sender.SelectedNode);
                }
            }
        }

        /// <summary>
        /// 해당 노드를 검사한뒤 삭제
        /// </summary>
        /// <param name="node"></param>
        private void removeNode(TreeNode node )
        {
            if (node.Checked)
            {
                if (isAdminMode)
                    MessageBox.Show("체크박스의 체크를 해제 한뒤에 지워 주시길 바랍니다.");
                else
                    MessageBox.Show("일반 사용자는 이 페이지의 수정/삭제가 불가능합니다.");
                return;
            }


            if (node.Level == 1)
            {
                string str = node.FullPath;
                m_Dic_equationInfomation.Remove(str);
            }
            // 카테고리를 지웠다면 하위 항목의 수식정보를 모두 제거.
            else
            {
                foreach (TreeNode Node in node.Nodes)
                {
                    if (Node.Checked)
                    {
                        MessageBox.Show("일반 사용자는 이 페이지의 수정/삭제가 불가능합니다..");
                        return;
                    }
                }
                foreach (TreeNode Node in node.Nodes)
                {
                    string str = Node.FullPath;
                    m_Dic_equationInfomation.Remove(str.ToString());
                }
            }



            treeView1.Nodes.Remove(node);
        }

        /// <summary>
        /// 삭제 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_Button_Delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
                removeNode(treeView1.SelectedNode);
        }

        /// <summary>
        /// 관리자의 잠금 처리를 위한 AfterCheck이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!InitializeComplete) 
                return;
            if (AfterCheckEntrance) // 무한 호출 방지용
                return;
            if (e.Node.Level == 0 )
            {
                foreach (TreeNode node in e.Node.Nodes)
                    node.Checked = e.Node.Checked;                
            }
            else
            {                
                EquationInformation e_info;
                if( !e.Node.Checked)
                {
                    AfterCheckEntrance = true;
                    e.Node.Parent.Checked = false;
                    AfterCheckEntrance = false;
                }
                string path = e.Node.FullPath;
                if ( m_Dic_equationInfomation.TryGetValue(path,out e_info ) )
                {
                    e_info.isAdminLocked = e.Node.Checked; // 체크를 했으면 그 Dictionary 의 변수의 잠금모드도 편집을 해줌.
                   // Trace.WriteLine(e.Node.Text + " 자식체크 및 admin속성 등록 " + e_info.isAdminLocked.ToString() );
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if( !isAdminMode )
            {
                if (e.Node.Checked)
                    treeView1.LabelEdit = false;
                else
                    treeView1.LabelEdit = true;
            }
           
        }

        private void m_button_NameChange_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            try
            {
                treeView1.SelectedNode.BeginEdit();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("일반 사용자는 이 페이지의 수정/삭제가 불가능합니다.");
            }
            
        }

        private void m_Button_OK_Click(object sender, EventArgs e)
        {

        }
    }
}
