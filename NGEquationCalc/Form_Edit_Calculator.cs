using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// ListBox1은 입력변수고 2는 출력변수임.
namespace NGEquationCalc
{
    public partial class Form_Edit_Calculator : Form
    {
        public Dictionary<string, VariableData> m_Dictionary_VariableData;
        public string m_Description_Script;
        public string m_Image_Path;
        private Dictionary<string, EquationInformation> m_Dictionary_EquationInformation;
        private string m_selectedEquation;
        private bool isSelectedEquation = false;
        PictureBox picbox_Popup;
        
        public Form_Edit_Calculator(Dictionary<string, VariableData> datas)
        {
            m_Dictionary_VariableData = datas;
            InitializeComponent();
            Initialize();
                   
        }
        /// <summary>
        /// 초기화 함수.
        /// 밖에서 초기화 할때 해당 KeyPair가 Shallow Copy면 곤란할수 있으니 유의.
        /// </summary>
        /// <param name="datas"></param>
       public Form_Edit_Calculator(Dictionary<string, VariableData> datas,string selectedEquation, Dictionary<string,EquationInformation> eqinfo)
       {
           m_Dictionary_VariableData = datas;
           m_Dictionary_EquationInformation = eqinfo;
           m_selectedEquation = selectedEquation;
           InitializeComponent();
           Initialize();
           m_textbox_description.Text = m_Dictionary_EquationInformation[m_selectedEquation].m_Description;
           m_Image_Path = m_Dictionary_EquationInformation[m_selectedEquation].m_imagePath;

           imageload();         
           
       }
        private void imageload()
        {
            bool isimageload = true;
            try
            {
                Bitmap bitmap = new Bitmap(m_Image_Path);
                if (bitmap != null)
                {
                    m_picturebox_preview.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                isimageload = false;
            }
            if( !isimageload )
            {
                try
                {
                    string[] foldertokenizer = m_selectedEquation.Split(':');
                    StringBuilder folderpath = new StringBuilder();

                    folderpath.Append(foldertokenizer[0]);
                    folderpath.Append("\\");
                    folderpath.Append(foldertokenizer[1]);


                    IEnumerable<string> filenames = from fullfilename in Directory.GetFiles(MainForm.m_ProgramPath + "\\image\\", folderpath.ToString() + ".*")
                                                    select System.IO.Path.GetFullPath(fullfilename);

                    string filename = " ";
                    foreach (var in_filename in filenames)
                    {
                        filename = in_filename;
                        break;
                    }
                    Bitmap myBitmap = new Bitmap(filename);
                    if (myBitmap != null)
                        m_picturebox_preview.Image = myBitmap;

                }
                catch( Exception ex )
                {
                    
                }
            
            }
        }

        private void Initialize()
        {
            foreach( var temp in m_Dictionary_VariableData.Keys )
            {
                var tempVariable = m_Dictionary_VariableData[temp];
                if (tempVariable is EquationVariable)
                {
                    listBox2.Items.Add(tempVariable.Name);
                }                
                else
                {
                    listBox1.Items.Add(tempVariable.Name);
                }
            }
        }

        /// <summary>
        /// 변수 추가 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form_AddVariable addvarform = new Form_AddVariable(m_Dictionary_EquationInformation,m_selectedEquation);

            // 다이얼로그에서 설정된 값을 토대로 변수 생성.
            if( addvarform.ShowDialog( ) == DialogResult.OK)
            {
                // 폼에서 출력 변수를 선택 했다.
                if(addvarform.IsEquationVariable)
                {
                    // 출력변수 만들고 등록.
                    EquationVariable vdata = MakeNewEquationVar(addvarform.VariableName, addvarform.Equation);
                    vdata.Equation = addvarform.Equation;
                    vdata.IsHiddenVariable = addvarform.IsHiddenValue;                   
                    listBox2.Items.Add(vdata.Name);
                    m_Dictionary_VariableData.Add(vdata.Name, vdata);
                    
                }
                    // 입력 변수를 선택했다.
                else
                {
                    VariableData vdata = MakeNewVar(addvarform.VariableName);
                    vdata.IsCorrespond = addvarform.isCorrespond;
                    // 출력변수 대입인지 체크.
                    if( vdata.IsCorrespond )
                    {
                        vdata.CorrespontVarName = addvarform.CorrespondVarPath;
                    }
                    // Option 체크 설정.
                    vdata.m_checkOption = addvarform.Option;

                    if (addvarform.Option == VariableData.CheckOption.None)
                    {

                    }
                    else if (addvarform.Option == VariableData.CheckOption.MinMax)
                    {
                        vdata.OptionMinValue = addvarform.CheckMinValue;
                        vdata.OptionMaxValue = addvarform.CheckMaxValue;
                    }
                    else
                    {
                        vdata.CustomOptionString = addvarform.CustomOptionString;
                    }

                    listBox1.Items.Add(vdata.Name);
                    m_Dictionary_VariableData.Add(vdata.Name, vdata);
                }
            }
            
        }
        private VariableData MakeNewVar(string name)
        {
            VariableData vdata = new VariableData(name);
            return vdata;
        }
        private EquationVariable MakeNewEquationVar(string name, string equation)
        {
            EquationVariable edata = new EquationVariable(name,equation);
            return edata;
        }
        

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                isSelectedEquation = true;
                listBox1.SelectedItem = null;               
                string str = listBox2.SelectedItem.ToString();
                var tempEquation = (m_Dictionary_VariableData[str] as EquationVariable).Equation;
                m_textbox_equation.Text = tempEquation;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            isSelectedEquation = false;
            listBox2.SelectedItem = null;
            
            m_textbox_equation.Text = "";
        }
        
        /// <summary>
        /// Dictionary는 기본적으로 Sort가 안되므로.
        /// Listbox의 순서대로 새로운 Dictionary를 재입력해서 Sort한 상태로 뱉어주장
        /// </summary>
        public Dictionary<string,VariableData> Sorted_Dictionary
        {
            get
            {
                Dictionary<string, VariableData> Sorted_Dictionary = new Dictionary<string, VariableData>();
                
                foreach( var item in listBox1.Items )
                {
                    Sorted_Dictionary.Add(item.ToString(), m_Dictionary_VariableData[item.ToString()]);
                }
                foreach( var item in listBox2.Items)
                {
                    Sorted_Dictionary.Add(item.ToString(), m_Dictionary_VariableData[item.ToString()]);
                }

                return Sorted_Dictionary;
            }
        }

        private void button_Add_Condition_Click(object sender, EventArgs e)
        {
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            m_Description_Script = m_textbox_description.Text;            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if( listBox1.SelectedItem != null )
            {                
                m_Dictionary_VariableData.Remove(listBox1.SelectedItem.ToString());                
                listBox1.Items.Remove(listBox1.SelectedItem);
                
            }
            if (listBox2.SelectedItem != null)
            {
                m_Dictionary_VariableData.Remove(listBox2.SelectedItem.ToString());                
                listBox2.Items.Remove(listBox2.SelectedItem);
                
            }            
        }


        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Delete )
            {
                button_delete_Click(this, null);
            }
        }

        /// <summary>
        /// listbox더블클릭시엔 해당 변수에 맞게 addvariable 창을 띄워줌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if( listBox2.SelectedItem != null )
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                var selectedVariable = m_Dictionary_VariableData[selectedItem];
                Form_AddVariable addvarform = new Form_AddVariable(selectedVariable, m_Dictionary_EquationInformation, m_selectedEquation);

                if(addvarform.ShowDialog() == DialogResult.OK)
                {
                   
                    EquationVariable newVariable = new EquationVariable(addvarform.VariableName);
                    newVariable.Equation = addvarform.Equation;
                    newVariable.IsHiddenVariable = addvarform.IsHiddenValue;


                    try
                    {
                        m_Dictionary_VariableData.Remove(selectedItem);
                        m_Dictionary_VariableData.Add(newVariable.Name, newVariable);

                        int index = listBox2.SelectedIndex;


                       listBox2.Items.Remove(listBox2.SelectedItem);
                       listBox2.Items.Insert(index, newVariable.Name);
                       
                   }
                   catch (System.Exception ex)
                   {
                       newVariable.Name = listBox2.SelectedItem.ToString();
                       m_Dictionary_VariableData.Add(listBox2.SelectedItem.ToString(), newVariable);
                       
                       MessageBox.Show(ex.Message);
                   }      
                   

                }
            
            }

        
        }
       
    


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {        
            if(listBox1.SelectedItem != null )
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                var selectedVariable = m_Dictionary_VariableData[selectedItem];
                Form_AddVariable addvarform = new Form_AddVariable(selectedVariable, m_Dictionary_EquationInformation, m_selectedEquation);

                if(addvarform.ShowDialog() == DialogResult.OK)
                {
                    VariableData newVariable = new VariableData(addvarform.VariableName);
                    newVariable.IsCorrespond = addvarform.isCorrespond;
                    if (newVariable.IsCorrespond)
                        newVariable.CorrespontVarName = addvarform.CorrespondVarPath;

                    newVariable.m_checkOption = addvarform.Option;                    
                    newVariable.OptionMinValue = addvarform.CheckMinValue;
                    newVariable.OptionMaxValue = addvarform.CheckMaxValue;
                    newVariable.m_Dictionary_SwitchInfo = addvarform.CaseInfo;
                    newVariable.CustomOptionString = addvarform.CustomOptionString;



                    try
                    {
                        int index = listBox1.SelectedIndex;
                        m_Dictionary_VariableData.Remove(selectedItem);
                        m_Dictionary_VariableData.Add(newVariable.Name, newVariable);

                        listBox1.Items.Remove(listBox1.SelectedItem);
                        listBox1.Items.Insert(index, newVariable.Name);
                    }
                    catch (System.Exception ex)
                    {
                        newVariable.Name = listBox1.SelectedItem.ToString();
                        m_Dictionary_VariableData.Add(listBox1.SelectedItem.ToString(), newVariable);

                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void m_button_setImage_Click(object sender, EventArgs e)
        {
            if (m_button_setImage.Text == "이미지 변경")
            {
                setimage();
            }
            else
            {
                unsetimage();
            }

        }

        private void setimage()
        {
            OpenFileDialog ofFileDialog = new OpenFileDialog();

            ofFileDialog.Filter = "PNG File(*.png)|*.png|JPG File(*.jpg)|*.jpg|GIF File(*.gif)|*.gif";
            ofFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            if (ofFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_Image_Path = ofFileDialog.FileName;
                try
                {
                    Bitmap bitmap = new Bitmap(ofFileDialog.FileName);
                    m_picturebox_preview.Image = bitmap;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("326 form_edit_calculator");
                }
                m_button_setImage.Text = "원래대로";
            }
        }
        private void unsetimage()
        {
            m_picturebox_preview.Image = null;
            m_button_setImage.Text = "이미지 변경";
            m_Image_Path = m_Dictionary_EquationInformation[m_selectedEquation].m_imagePath;
            imageload();
        }

        private void m_button_Listbox1_Up_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;

            if( item != null )
            {
                int selected_index = listBox1.SelectedIndex;
                string selecteditem = item.ToString();

                if (selected_index != 0)
                    selected_index--;

               
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.Items.Insert(selected_index, selecteditem);                
                listBox1.SelectedIndex = selected_index;               
            }
            
        }       

        private void m_button_listbox1_Down_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if( item != null )
            {
                int selected_index = listBox1.SelectedIndex;
                string selected_item = item.ToString();

                if( selected_index != listBox1.Items.Count-1)
                {
                    selected_index++;
                }

                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox1.Items.Insert(selected_index, selected_item);
                listBox1.SelectedIndex = selected_index;     
            }
        }

        private void m_button_Listbox2_Up_Click(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;

            if (item != null)
            {
                int selected_index = listBox2.SelectedIndex;
                string selecteditem = item.ToString();

                if (selected_index != 0)
                    selected_index--;


                listBox2.Items.Remove(listBox2.SelectedItem);
                listBox2.Items.Insert(selected_index, selecteditem);
                listBox2.SelectedIndex = selected_index;
            }
        }

        private void m_button_listbox2_Down_Click(object sender, EventArgs e)
        {
            var item = listBox2.SelectedItem;
            if (item != null)
            {
                int selected_index = listBox2.SelectedIndex;
                string selected_item = item.ToString();

                if (selected_index != listBox2.Items.Count - 1)
                {
                    selected_index++;
                }

                listBox2.Items.Remove(listBox2.SelectedItem);
                listBox2.Items.Insert(selected_index, selected_item);
                listBox2.SelectedIndex = selected_index;
            }
        }

        private void m_picturebox_preview_MouseHover(object sender, EventArgs e)
        {
         
                       
         
           
        }

        private void m_picturebox_preview_MouseLeave(object sender, EventArgs e)
        {
//             if (picbox_Popup != null)
//             {
//                 this.Controls.RemoveByKey("popup");
//                 picbox_Popup.Dispose();
//                 picbox_Popup = null;
//             }
                                   
        }

        private void m_picturebox_preview_MouseEnter(object sender, EventArgs e)
        {        
              
            
            
        }

        private void m_picturebox_preview_MouseEnter_1(object sender, EventArgs e)
        {          
                  
            
        }
        
    }
}
