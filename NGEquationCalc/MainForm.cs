using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonUtils;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace NGEquationCalc
{
    public partial class MainForm : Form
    {
        Dictionary<string, EquationInformation> m_Dictionary_EquationInfo = new Dictionary<string, EquationInformation>();
        Dictionary<string, EquationInformation> m_Dictionary_Searched_EquationInfo = new Dictionary<string, EquationInformation>();
        Dictionary<string, EquationInformation> m_Dictionary_UsedEquationInfo = new Dictionary<string, EquationInformation>();

       public static Dictionary<string, double> Static_Variable_Dictionary = new Dictionary<string, double>();
      
       // public Form_VariableSearch m_SearchForm = new Form_VariableSearch();
        public static Form_Log_Window m_LogWindow = new Form_Log_Window();
        public static string m_ProgramPath;
        bool isAdminLogin = false;
        bool isSearchMode = false;
        string find_text = "";


        public delegate void SearchDelegate(string key);
        public event SearchDelegate SearchEvent;
        
        public MainForm()
        {
            InitializeComponent();


         
            m_LogWindow.Location = new Point(this.ClientSize.Width + this.Location.X, this.Location.Y);
            SearchEvent += new SearchDelegate(MainForm_SearchEvent);
           // m_SearchForm.listViewclickEvent += new Form_VariableSearch.listViewClickDelegate(m_SearchForm_listViewclickEvent);
            m_ProgramPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName); 
        }


        void m_SearchForm_listViewclickEvent(string path)
        {
            OpenCalculator(path);
        }


        /// <summary>
        /// 검색 버튼 클릭 이벤트.
        /// </summary>
        /// <param name="key"></param>
        void MainForm_SearchEvent(string key)
        {
            if (m_Dictionary_EquationInfo == null)
                return;
            m_treeView.Nodes.Clear();
            m_Dictionary_Searched_EquationInfo.Clear();
            foreach (string eq_key in m_Dictionary_EquationInfo.Keys)
            {
                EquationInformation eqinfo = m_Dictionary_EquationInfo[eq_key];
                string key_tolower = key.ToLower();                
                if (eqinfo.m_Description.ToLower().Contains(key_tolower))
                {
                    m_Dictionary_Searched_EquationInfo.Add(eq_key, eqinfo);
                   
                }
            }
            find_text = key.ToLower();
            isSearchMode = true;
            InitialTreeView(m_Dictionary_Searched_EquationInfo);
            this.Refresh();
          
        } 
        /// <summary>
        /// 폼 종료 전 종료 할것인지 묻는 이벤트.
        /// e.cancel = true로 종료를 막을 수 있음.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dresult = MessageBox.Show("종료하기전에 저장 하시겠습니까?", "종료", MessageBoxButtons.YesNoCancel);

            if (dresult == DialogResult.Yes)
            {
               bool ret =  Save();
               if (!ret)
                   e.Cancel = true;
            }
            else if (dresult == DialogResult.No)
            {
                //MessageBox.Show("저장안함");
            }
            else
            {
                e.Cancel = true;
            }      
        }

        /// <summary>
        /// Serialable 데이터를 토대로 저장
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            SaveFileDialog sfDialog = new SaveFileDialog();
            sfDialog.Filter = "Save Files (*.dat)|*.dat";
            sfDialog.DefaultExt = "dat";
            sfDialog.InitialDirectory = m_ProgramPath + "\\save";

            if( sfDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFile(sfDialog.FileName);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 직렬화 데이터를 토대로 로드
        /// </summary>
        private void LoadFile()
        {
           
            OpenFileDialog ofDialog = new OpenFileDialog();

            ofDialog.Filter = "Save Files (*.dat)|*.dat";
            ofDialog.DefaultExt = "dat";
            ofDialog.InitialDirectory = m_ProgramPath + "\\save";

            if( ofDialog.ShowDialog() == DialogResult.OK)
            {
                LoadForClear();
                
                if(!LoadFile(ofDialog.FileName))
                {
                    MessageBox.Show("불러오는데 실패 했습니다");
                }
                else
                {
                    try
                    {
                        string version = ofDialog.SafeFileName;
                        int start = version.IndexOf('(');
                        int end = version.IndexOf(')');

                        m_label_version.Text = "Version : " + version.Substring(start + 1, end - start - 1);
                        
                    }
                    catch(Exception ex)
                    {
                        m_label_version.Text = "Version : Not Versioned";
                    }


                }
//                 DebugForm de = new DebugForm(m_Dictionary_EquationInfo);
//                 de.Show();
                
            }
        }

        /// <summary>
        /// 새 파일 로드전 노드와 사전클래스를 비워줌.
        /// </summary>
        private void LoadForClear()
        {
            m_treeView.Nodes.Clear();
            if( m_Dictionary_EquationInfo != null )
            {
                m_Dictionary_EquationInfo.Clear();
                m_Dictionary_EquationInfo = null;
            }
            if( m_Dictionary_UsedEquationInfo != null )
            {
                m_Dictionary_UsedEquationInfo.Clear();
            }
            
            
            
        }

        

        private void button4_Click(object sender, EventArgs e)
        {            
            SearchEvent(m_textBox_Search.Text);
        }        


        private bool SaveFile(string path)
        {
            try
            {
                // UI 용
//                 Object[] savetreeNode = new Object[m_treeView.Nodes.Count];
//                 for (int i = 0; i < savetreeNode.Length; i++)
//                 {
//                     savetreeNode[i] = m_treeView.Nodes[i].Clone();
//                 }
                // Parser 용                
                
                FileStream fstream = new FileStream(path, FileMode.OpenOrCreate);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(fstream, m_Dictionary_EquationInfo);
                bFormatter.Serialize(fstream, Static_Variable_Dictionary);
//                bFormatter.Serialize(fstream, savetreeNode);                

                fstream.Close();
                fstream.Dispose();
                MessageBox.Show("성공적으로 저장되었습니다.");
                return true;
            }
            catch( Exception e )
            {
                MessageBox.Show("해당 이유로 저장을 실패 했습니다 : " + e.Message);               
                
                return false;
            }            
        }

        private bool LoadFile(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
               
                var LoadedDictionary = formatter.Deserialize(stream) as Dictionary<string, EquationInformation>;
                var LoadedStaticDictionary = formatter.Deserialize(stream) as Dictionary<string, double>;
//                 Static_Variable_Dictionary.Add("fpnm", 6076.115485564304);
//                 Static_Variable_Dictionary.Add("radian", 0.017453292519943295);
//                 Static_Variable_Dictionary.Add("_r", 20890537);

//                var LoadedTreeNode = formatter.Deserialize(stream) as Object[];                          
                
                m_Dictionary_EquationInfo = new Dictionary<string, EquationInformation>(LoadedDictionary);
                Static_Variable_Dictionary = new Dictionary<string, double>(LoadedStaticDictionary);

                foreach (var vdatas in m_Dictionary_EquationInfo)
                {
                   // vdatas.Value.m_imagePath = ""
                    foreach (var vdata in vdatas.Value.m_Dictionary_Equation.Values)
                    {
                        vdata.Value = 0;
                        vdata.IsZeroIsNullValue = true;
                    }
                }
                
                //                 foreach( TreeNode node in LoadedTreeNode )
//                 {                       
//                     m_treeView.Nodes.Add(node);                     
//                 }
                isSearchMode = false;
                InitialTreeView(m_Dictionary_EquationInfo);
              
                
                stream.Close();
                return true;
            }
            catch(Exception e)
            {                
                stream.Close();
                
                return false;
            }       
        }

        /// <summary>
        /// 해당 EquationInfomation 클래스를 토대로 TreeView를 생성
        /// </summary>
        /// <param name="p_EquationInfo"></param>
        private void InitialTreeView(Dictionary<string,EquationInformation> p_EquationInfo)
        {
            m_treeView.Nodes.Clear(); // 트리뷰 초기화

            foreach (var dic in p_EquationInfo)
            {
                // dic.key값은 부모:자식 형태로 이루어져있음.

                String[] varpath = dic.Key.Split(':');
                // 부모키가 존재 하지 않으면 부모 노드를 만듬.
                if (!m_treeView.Nodes.ContainsKey(varpath[0]))
                {
                    TreeNode nodeParent = new TreeNode();
                    nodeParent.Name = varpath[0];                    
                    nodeParent.Text = varpath[0];                    
                    nodeParent.ImageIndex = 0;
                    nodeParent.SelectedImageIndex = 0;
                    m_treeView.Nodes.Add(nodeParent);
                }
                //key값을 짤라서 자식 노드에 넣어줌.
                TreeNode nodeChild = new TreeNode();
                nodeChild.Name = varpath[1];
                nodeChild.Text = varpath[1] + " : " + dic.Value.m_Description;
                nodeChild.ImageIndex = 1;
                nodeChild.SelectedImageIndex = 1;
                m_treeView.Nodes[varpath[0]].Nodes.Add(nodeChild);
            }

            m_treeView.Sort();
        }
       

        private void OpenCalculator(string VarFullPath)
        {
            Form_Calculator calForm = new Form_Calculator(m_Dictionary_EquationInfo, VarFullPath, isAdminLogin);

            /*calForm.sendtoLog += new Log_Window.LogMessageDelegate(calform_sendtoLog);*/

            while (calForm.InvokeRequired)
            {
            }
            calForm.Show();
            calForm.sendtoLog += (msg, option) => { sendtoLog(msg, option); };
            calForm.Location = new Point(this.Size.Width + this.Location.X + 1, this.Location.Y - 2);

            calForm.EditComplateEvent += () => { isSearchMode = false; InitialTreeView(m_Dictionary_EquationInfo); };
            calForm.CalculateEvent += (k, v) => { m_Dictionary_UsedEquationInfo[k] = v; };
        }
        private void m_treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level == 1)
                {
                     Control ctrl = (Control)sender;
                     string NodeText = e.Node.Text;
                     string NodeParent = e.Node.Parent.Text;
                     string Varname = e.Node.Text.Split(':')[0].Trim();
                     string VarFullPath = NodeParent + ":" + Varname;
                     OpenCalculator(VarFullPath);
                }

           
            }
        }

        private void m_button_save_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void m_button_load_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
        private void m_Button_Log_Click(object sender, EventArgs e)
        {
            if (!m_LogWindow.Visible)
            {
                m_LogWindow.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y);
                m_LogWindow.Show();
            }
        }
        private void sendtoLog(string msg, Form_Log_Window.LogOption option)
        {
            m_LogWindow.SendtoLog(msg, option);
        }

        private void m_button_Admin_Click(object sender, EventArgs e)
        {
            Form_Admin m_admin = new Form_Admin();
            m_admin.login_Event += ()
                =>
                {
                    isAdminLogin = true;
                    m_toolButton_Admin.Enabled = false;
                    m_toolbtn_AddStatic.Enabled = true;
                    m_label_admin.Visible = true;
                    sendtoLog("\n[System] : 관리자 로그인에 성공하였습니다\n", Form_Log_Window.LogOption.System);
                };
            m_admin.ShowDialog();            
        }     
        
        private void m_toolButton_AddCalculator_Click(object sender, EventArgs e)
        {
            if (m_Dictionary_EquationInfo == null)
                m_Dictionary_EquationInfo = new Dictionary<string, EquationInformation>();
                       
            Form_AddCalculator addform = new Form_AddCalculator(m_Dictionary_EquationInfo,isAdminLogin);

            if (addform.ShowDialog() == DialogResult.OK)
            {                
                m_Dictionary_EquationInfo = new Dictionary<string, EquationInformation>(addform.m_Dic_equationInfomation);
                isSearchMode = false;
                InitialTreeView(m_Dictionary_EquationInfo);
                
            }
            addform.Dispose();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void m_toolButton_Result_Click(object sender, EventArgs e)
        {
            Form_OutputValues output = new Form_OutputValues(m_Dictionary_UsedEquationInfo);
            output.ShowDialog();
        }

        private void m_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
//             if (e.Node.Level == 0)
//                 m_treeView.SelectedImageIndex = 0;
//             else
//                 m_treeView.SelectedImageIndex = 1;
        }

        private void m_button_ReloadTree_Click(object sender, EventArgs e)
        {
            find_text = "";
            isSearchMode = false;
            InitialTreeView(m_Dictionary_EquationInfo);
        }

        

        private void m_toolbtn_AddStatic_Click(object sender, EventArgs e)
        {
            Form_AddStaticVar form_static = new Form_AddStaticVar(isAdminLogin);
            if( form_static.ShowDialog() == DialogResult.OK)
            {
                Static_Variable_Dictionary = new Dictionary<string, double>(form_static.Variables);
            }
        }

        private void m_treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
           
//             if (e.Node.Level != 1)
//             {
//                 e.DrawDefault = true;
//                 return;
//             }
//             if (find_text != "" && isSearchMode)
//             {
//                 int len = find_text.Length;
//                 string lower_str = e.Node.Text.ToLower();
//                 string node_text = e.Node.Text;
//                 int index = lower_str.IndexOf(find_text);
// 
//                 string find_fowardstring = node_text.Substring(0, index);
//                 string find_string = node_text.Substring(index, len);
//                 string find_backward = node_text.Substring(index + len);
// 
//                 Font normalFont = e.Node.TreeView.Font;
//                 float textwidth = e.Graphics.MeasureString(find_fowardstring, normalFont).Width;
// 
//                 e.Graphics.DrawString(find_fowardstring, normalFont, SystemBrushes.WindowText, e.Bounds);
//                 float textwidth_2;
//                 using (Font boldFont = new Font(normalFont, FontStyle.Bold))
//                 {
//                     e.Graphics.DrawString(find_string, boldFont, SystemBrushes.WindowText, e.Bounds.Left + textwidth - 10, e.Bounds.Top);
//                     textwidth_2 = textwidth + e.Graphics.MeasureString(find_string, boldFont).Width;
//                 }
//                 e.Graphics.DrawString(find_backward, normalFont, SystemBrushes.WindowText, e.Bounds.Left+textwidth_2-13,e.Bounds.Top);
//                 
//                 
//                 
//             }
//             else
//             {
//                 e.DrawDefault = true;
//             }
            e.DrawDefault = true;
        }    

        


    }
}
