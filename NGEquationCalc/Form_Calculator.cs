using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonUtils;
using System.Diagnostics;
using System.IO;


namespace NGEquationCalc
{
    public partial class Form_Calculator : Form
    {
        public CommonUtils.Term m_Term = new CommonUtils.Term(); // 계산을 수행할 Term Parser

        int Variable_Label_X = 5;
        int Variable_Label_Y = 25;
        int Variable_TextBox_X = 220;
        int Variable_TextBox_Y = 25;
        

        string m_SelectedEquation; // 프로그램의 위치

        Dictionary<string, EquationInformation> m_Dictionary_EquationInfo;      // read_only
        
        

        public event  Form_Log_Window.LogMessageDelegate sendtoLog;

        public delegate void CalculatorDelegate();
        public delegate void CalculatorDelegate1(string key, EquationInformation val);

        public event CalculatorDelegate EditComplateEvent; // 계산페이지 수정 이벤트
        public event CalculatorDelegate1 CalculateEvent; // 계산이벤트

        public string m_ProgramPath;

        /// <summary>
        /// 생성자.
        /// </summary>
        /// <param name="pDictionary_EquationInfomation">메인의 Dictionary_readonly</param>
        /// <param name="selectedEquation">선택된 Equation(Strnig)</param>
        /// <param name="isAdmin">관리자 모드 여부</param>
        public Form_Calculator(Dictionary<string,EquationInformation> pDictionary_EquationInfomation, string selectedEquation, bool isAdmin )
        {
            InitializeComponent();
            
            m_ProgramPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);     
            m_Dictionary_EquationInfo = pDictionary_EquationInfomation; // Read_Only
            m_SelectedEquation = selectedEquation;                        

            this.Text = m_SelectedEquation;

            EquationInformation _EquationInfomation;
            
            // 값을 불러온뒤에 UI및 파서 초기화
            if( m_Dictionary_EquationInfo.TryGetValue(m_SelectedEquation, out _EquationInfomation))
            {
                SettingforCalc(_EquationInfomation);
                SettingForUI(_EquationInfomation);
                if( !_EquationInfomation.isAdminLocked || isAdmin )
                {
                    m_Button_Add_Equation.Enabled = true;
                }
                else
                {                    
                    m_Button_Add_Equation.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("계산기 데이터를 불러오는데 실패 했습니다.","에러", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
            
        }

        /// <summary>
        /// 파서의 변수를 초기화.
        /// 전역변수로 선언된 변수는 다시 재 초기화 해서 사용할수 있게
        /// </summary>
        private void ClearCalculateVar()
        {
            m_Term.ClearVars();

//             foreach (var key in m_Dictionary_EquationInfo.Keys)
//             {
//                 var splitedtext = key.Split(':');
//                 if (splitedtext[0].Contains("전역변수"))
//                 {
//                     foreach (var vdata in m_Dictionary_EquationInfo[key].m_Dictionary_Equation.Values)
//                     {
//                         m_Term.SetVar(vdata.Name, vdata.Value);
//                     }
//                 }
//             }
            foreach( var staticdata in MainForm.Static_Variable_Dictionary)
            {
                m_Term.SetVar(staticdata.Key, staticdata.Value);
            }
        }

        /// <summary>
        /// 라벨에서 이름을 읽어서 Textbox의 값으로 변수값을 설정.
        /// </summary>
        private void SetVar()
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    string[] str = ctrl.Name.Split('\\'); // 이름은 Name\\ControlType으로 정해져있음
                    TextBox textbox = (TextBox)panel1.Controls[str[0] + "\\TextBox"];
                    if (textbox == null)
                        continue;
                    double temp;
                    //사용자가 텍스트박스에 아무것도 입력 안했으면 0이라 가정
                    if (textbox.Text == "")
                        textbox.Text = "0";


                    // 결과값이 infinity나 NaN이면 변수로 인식하기 때문에 이것또한 계산할때 0으로 가정
                    // 나중에 Infinity나 NaN을 처리해줄 일이 있으면 파서 클래스를 변경할 필요
                    if (textbox.Text.Contains("infinity") || textbox.Text.Contains("nan"))
                    {
                        textbox.Text = "0";
                    }
                    //입력된 값을 해당 Infomation의 변수에 입력함.
                    var EquationInfo = m_Dictionary_EquationInfo[m_SelectedEquation];
                    if (EquationInfo == null)
                        return;

                    var vdata = EquationInfo.m_Dictionary_Equation[str[0]];
                    vdata.IsZeroIsNullValue = false;

                    // 계산하기전에 분기 조건문인지 확인하고 일치하면 계산속행.
                    if (vdata.m_checkOption == VariableData.CheckOption.Case)
                    {
                        if (!CheckCase(vdata, textbox.Text.ToLower()))
                        {
                            throw new ParseException(null, 0, "분기조건문이 일치하지 않습니다.");
                        }
                    }
                     // 파서에 입력된 값을 등록
                    else
                    {
                        m_Term.Parse(textbox.Text);
                        m_Term.SetVar(str[0], m_Term.Value);
                    }


                    vdata.Value = m_Term.Value;


                }
            }
        }
        /// <summary>
        /// path에 있는 변수의 값을 불러옵니다.
        /// 예외처리는 안되있으므로 잘 봐서 확인할것
        /// </summary>
        /// <param name="path">ex)Volume 1:Calculator 1-01:Test</param>
        /// <returns>해당 변수 값</returns>
        private double FindValue(string path)
        {
            var splittedstr = path.Split(':');
            var vdata = m_Dictionary_EquationInfo[splittedstr[0]+":"+splittedstr[1]].m_Dictionary_Equation[splittedstr[2]];
            return vdata.Value;
        }
        /// <summary>
        /// 해당 EquationInfomation 클래스에 있는 변수값으로 파서내에 변수를 등록
        /// </summary>
        /// <param name="equainfo">등록할 EquationInfomation Class</param>
        private void SettingforCalc(EquationInformation equainfo)
        {
            foreach (var key in equainfo.m_Dictionary_Equation.Keys)
            {
                //if (equainfo.m_Dictionary_Equation[key].IsContainEquation == false)
                {
                    try
                    {
                        m_Term.SetVar(key, equainfo.m_Dictionary_Equation[key].Value);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message + "setvar");
                        equainfo.m_Dictionary_Equation[key].Value = 0;
                    }

                }
            }
        }
       

#region 계산전 체크 함수들
        /// <summary>
        /// Min Max 체크 함수
        /// </summary>
        /// <param name="vdata"></param>
        /// <returns></returns>
        private bool CheckMinMax(VariableData vdata)
        {
            double min, max;
            min = vdata.OptionMinValue;
            max = vdata.OptionMaxValue;
            if (vdata.Value < min)
            {
                return false;
            }
            if (vdata.Value > max)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// 조건문 체크 함수 
        /// </summary>
        /// <param name="vdata"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool CheckCase(VariableData vdata, string key)
        {
            CommonUtils.Term _term = new CommonUtils.Term();
            var list = vdata.m_Dictionary_SwitchInfo;
            string val;

            if (!list.TryGetValue(key, out val))
            {
                return false;
            }
            string[] cases = val.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string _case in cases)
            {
                string[] spl = _case.Split('=');
                if (spl.Length != 2)
                    return false;

                string left = spl[0].Trim().ToLower();
                string right = spl[1].Trim();

                double temp;
                if (!double.TryParse(right, out temp))
                {
                    return false;
                }
                m_Term.Parse(right);
                m_Term.SetVar(left, m_Term.Value);
            }

            return true;

        }
        /// <summary>
        /// 사용자 조건문 체크 함수.
        /// </summary>
        /// <param name="vdata"></param>
        /// <returns></returns>
        private bool CheckCustom(VariableData vdata)
        {
            char[] c_splitter = { '\n' }; // 엔터 값으로 구분
            string[] spl_strs = vdata.CustomOptionString.Split(c_splitter, StringSplitOptions.RemoveEmptyEntries);
            string[] splitter = { ">=", "<=", "==", ">", "<", "!=" };
            foreach (string str in spl_strs)
            {
                string[] s = str.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                m_Term.Parse(s[0].Trim());
                double left = m_Term.Value;
                m_Term.Parse(s[1].Trim());
                double right = m_Term.Value;

                if (s.Length != 2)
                    return false;

                if (str.Contains(">="))
                {

                    if (!(left >= right))
                    {
                        return false;
                    }
                }
                else if (str.Contains("<="))
                {

                    if (!(left <= right))
                    {
                        return false;
                    }
                }
                else if (str.Contains("=="))
                {

                    if (!(left == right))
                    {
                        return false;
                    }
                }
                else if (str.Contains(">"))
                {

                    if (!(left > right))
                    {
                        return false;
                    }
                }
                else if (str.Contains("<"))
                {

                    if (!(left < right))
                    {
                        return false;
                    }
                }
                else if (str.Contains("!="))
                {

                    if (!(left != right))
                    {
                        return false;
                    }
                }

            }
            return true;
        }
#endregion
        #region 계산 함수
        /// <summary>
        /// 해당 수식변수를 이용해 계산하고 값 저장.
        /// </summary>
        /// <param name="edata"></param>
        private void Calculate(ref EquationVariable edata)
        {
            m_Term.Parse(edata.Equation);
            m_Term.SetVar(edata.Name, m_Term.Value);
            //SetVarAllEquainfo(edata.Name, m_Term.Value);
            double value = m_Term.Value;
            edata.Value = value;


        }
        /// <summary>
        /// Not Used
        /// </summary>
        /// <param name="cdata"></param>
        private void Calculate(ref ComparableVariable cdata)
        {
            foreach (CompareData comdata in cdata.m_list_CompareData)
            {
                if (comdata.isIfEquation)
                {
                    m_Term.Parse(comdata.s_if);
                    double var = m_Term.Value;
                    if (double.IsInfinity(var) || double.IsNaN(var))
                    {
                        var = 0;
                    }
                    comdata.d_if = var;
                }
                if (comdata.isThenEquation)
                {
                    m_Term.Parse(comdata.s_then);
                    double var = m_Term.Value;
                    if (double.IsInfinity(var) || double.IsNaN(var))
                    {
                        var = 0;
                    }
                    comdata.d_then = var;
                }
                if (comdata.istValueEquation)
                {
                    m_Term.Parse(comdata.s_value);
                    double var = m_Term.Value;
                    if (double.IsInfinity(var) || double.IsNaN(var))
                    {
                        var = 0;
                    }
                    comdata.d_value = var;
                }
            }
            double d_value = cdata.Value;

            m_Term.SetVar(cdata.Name, d_value);

        }
        /// <summary>
        /// 버튼 눌렀을때 계산하는 부분
        /// 재귀호출로 계산을 처리해줘야 하는 부분이 있으나 예) 3*c = d; a+b = c, 면 c값을 계산을 해줘야 하기때문에 재귀 호출할 필요가 있음.
        /// 그냥 함수 자체를 두번 호출하는걸로 처리
        /// 마지막 불 변수는 로그값을 한번만 띄우기 위해 처리한것임.
        /// </summary>
        /// <param name="selectedEquation"></param>
        /// <param name="test"></param>
        private void DoCalculate(string selectedEquation, bool test = true)
        {
            try
            {
                SetVar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            var EquationInfomation = m_Dictionary_EquationInfo[selectedEquation];
            if (EquationInfomation == null)
                return;
            var VariableDatas = EquationInfomation.m_Dictionary_Equation.Values;
            bool isErrorOccured = false;
            try
            {
                StringBuilder inputvalue_sb = new StringBuilder(); // 입력값 로그 출력용
                StringBuilder equation_sb = new StringBuilder(); // 식 로그 출력용
                StringBuilder result_sb = new StringBuilder(); // 결과값 로그 출력용
                inputvalue_sb.Append("입력값 : ");
                // 계산전 값 Validation.
                // 어긋나면 계산안하고 종료.
                foreach (VariableData vdata in VariableDatas)
                {
                    if (vdata is EquationVariable)
                        continue;
                    switch (vdata.m_checkOption)
                    {
                        case VariableData.CheckOption.None:
                            break;
                        case VariableData.CheckOption.MinMax:
                            if (!CheckMinMax(vdata))
                            {
                                throw new Exception(vdata.Name + "의 값은 " + vdata.OptionMinValue.ToString() + "이상 " + vdata.OptionMaxValue.ToString() + "이하여야 합니다.");
                            }
                            break;
                        case VariableData.CheckOption.Custom:
                            if (!CheckCustom(vdata))
                            {
                                throw new Exception(vdata.Name + "의 식 조건이 일치 하지 않습니다. 입력변수 조건을 다시 한번 확인해 주십시오");
                            }
                            break;
                        default:
                            break;
                    }
                    inputvalue_sb.Append(" [" + vdata.Name + "] = " + vdata.Value.ToString());

                }
                if (test == false)
                {
                    sendtoLog(inputvalue_sb.ToString() + "\n", Form_Log_Window.LogOption.Normal);
                }

                foreach (VariableData vdata in VariableDatas)
                {
                    if (vdata is EquationVariable)
                    {
                        EquationVariable edata = (EquationVariable)vdata;
                        try
                        {
                            Calculate(ref edata);
                            SetTextBoxResult(edata.Name, edata.Value);
                            if (test == false)
                            {
                                equation_sb.AppendLine("[" + edata.Name + "]" + " 공식 : " + edata.Equation);
                                result_sb.AppendLine("[" + edata.Name + "]" + " 결과 : " + m_Term.Value.ToString("R"));
                            }
                        }
                        catch (ParseException e)
                        {
                            if (test == false)
                            {
                                SetErrorForLabel(e.Message, edata, e.ParsedString);
                                isErrorOccured = true;
                            }
                        }

                    }
                }

                if (isErrorOccured)
                {
                    MessageBox.Show("수식에 문제가 있습니다. 붉은색 항목에 커서를 올리면 문제 발생 원인을 확인 할 수 있습니다");
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl.BackColor == Color.LightGoldenrodYellow)
                        {
                            ctrl.Text = "";
                        }
                    }
                }
                else
                {
                    if (test == false)
                    {
                        sendtoLog(equation_sb.ToString() + "\n", Form_Log_Window.LogOption.Equation);
                        sendtoLog(result_sb.ToString() + "\n\n\n", Form_Log_Window.LogOption.Result);
                    }

                }
            }
            catch (Exception e)
            {
                if (test == true)
                    MessageBox.Show(e.Message);
            }
        }
        #endregion

#region UI 관련 함수들
        /// <summary>
        /// 수식 에러 발생시 예외를 catch해서 ToolTip으로 표현
        /// </summary>
        /// <param name="Message">오류 메시지</param>
        /// <param name="vdata">에러 변수</param>
        /// <param name="ParsedString">오류 수식</param>
        private void SetErrorForLabel(string Message, VariableData vdata, string ParsedString)
        {
            // 숨겨진 변수는 라벨 컨트롤이 없으므로 메시지 박스로 대체
            if (vdata.IsHiddenVariable == false)
            {
                toolTip_Error.IsBalloon = true;
                toolTip_Error.ShowAlways = true;
                toolTip_Error.SetToolTip(panel1.Controls[vdata.Name + "\\Label"], Message + ", 에러수식 : " + ParsedString);
                (panel1.Controls[vdata.Name + "\\Label"]).ForeColor = Color.Red;
                StringBuilder error_sb = new StringBuilder();
                error_sb.AppendLine("[오류]");
                error_sb.AppendLine(Message);
                error_sb.AppendLine("오류변수:" + "[" + vdata.Name + "]");
                error_sb.AppendLine("오류식 : " + ParsedString);
                sendtoLog(error_sb.ToString(), Form_Log_Window.LogOption.Error);
            }
            if (vdata.IsHiddenVariable == true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("숨겨진 변수 ");
                sb.Append(vdata.Name);
                sb.Append("의 오류 입니다 \n ");
                sb.Append("에러내용 : ");
                sb.Append(Message);
                sb.Append("\n오류수식 : ");
                sb.Append(ParsedString);
                MessageBox.Show(sb.ToString());
            }
        }

        /// <summary>
        /// EquationInfomation 의 변수를 토대로 UI를 작성.
        /// </summary>
        /// <param name="equainfo"></param>
        private void SettingForUI(EquationInformation equainfo)
        {
            TabControl tabControl = new TabControl();
            TabPage tabPage = new TabPage();
            PictureBox pic_Equation = new PictureBox();


            // tab Page //
            tabPage.AutoScroll = true;
            tabPage.Controls.Add(pic_Equation);
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = "tabPage";
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(570, 171);
            tabPage.TabIndex = 0;
            tabPage.Text = "공식 이미지";
            tabPage.UseVisualStyleBackColor = true;

            // tab Control //
            tabControl.Controls.Add(tabPage);
            tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(578, 197);
            tabControl.TabIndex = 0;

            //pic_equation //
            pic_Equation.Location = new System.Drawing.Point(49, 3);
            pic_Equation.Name = "pic_Equation";
            pic_Equation.Size = new System.Drawing.Size(298, 165);
            pic_Equation.TabIndex = 0;
            pic_Equation.TabStop = false;


            panel1.Controls.Add(tabControl);

            panel1.AutoScroll = false;

            toolStripLabel1.Text = m_SelectedEquation;

            if (equainfo.m_Dictionary_Equation.Keys.Count == 0)
            {
                toolStripLabel1.Text = "빈 계산기 페이지 입니다";
                return;
            }

            int Pic_X = 0;
            int Pic_Y = 0;


            bool isimageLoaded = false;
            try
            {

                Bitmap myBitmap = new Bitmap(m_Dictionary_EquationInfo[m_SelectedEquation].m_imagePath);
                Pic_X = myBitmap.Size.Width;
                Pic_Y = myBitmap.Size.Height;
                isimageLoaded = true;
                pic_Equation.SizeMode = PictureBoxSizeMode.AutoSize;
                pic_Equation.Image = myBitmap;
                pic_Equation.Click += (a, b) => { panel1.Focus(); };
            }
            catch (Exception ex)
            {
                isimageLoaded = false;
            }


            // 사용자 이미지가 없으면 폴더 기본 이미지를 사용
            if (!isimageLoaded)
            {
                try
                {
                    string[] foldertokenizer = m_SelectedEquation.Split(':');
                    StringBuilder folderpath = new StringBuilder();

                    folderpath.Append(foldertokenizer[0]);
                    folderpath.Append("\\");
                    folderpath.Append(foldertokenizer[1]);


                    IEnumerable<string> filenames = from fullfilename in Directory.GetFiles(m_ProgramPath + "\\image\\", folderpath.ToString() + ".*")
                                                    select Path.GetFullPath(fullfilename);

                    string filename = " ";
                    foreach (var in_filename in filenames)
                    {
                        filename = in_filename;
                        break;
                    }
                    Bitmap myBitmap = new Bitmap(filename);
                    Pic_X = myBitmap.Size.Width;
                    Pic_Y = myBitmap.Size.Height;

                    pic_Equation.SizeMode = PictureBoxSizeMode.AutoSize;
                    pic_Equation.Image = myBitmap;
                    pic_Equation.Click += (a, b) => { panel1.Focus(); };
                    //m_Dictionary_EquationInfo[m_SelectedEquation].m_imagePath = filename;


                }
                catch (System.Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
            if (Pic_Y > 400)
            {
                tabControl.Height = 300;
                Pic_Y = 300;
            }
            else
            {
                tabControl.Height = Pic_Y + 60;
                Pic_Y = tabControl.Height;
            }
            if (Pic_X > 800)
            {
                tabControl.Width = 800;
                Pic_X = 800;
            }
            else
            {
                tabControl.Width = Pic_X + 50;
                Pic_X = tabControl.Width;
            }


            // 내부 변수 갯수를 토대로 Textbox와 Label 작성
            int v_count = 0;
            foreach (var key in equainfo.m_Dictionary_Equation.Keys)
            {
                var tempVariable = equainfo.m_Dictionary_Equation[key];
                double dvalue = tempVariable.Value;
                try
                {
                    // 출력변수 대입하는 변수 인지 구분.
                    if (tempVariable.IsHiddenVariable == false)
                    {
                        if (tempVariable.IsCorrespond)
                        {
                            dvalue = FindValue(tempVariable.CorrespontVarName);
                        }
                    }

                }
                catch (System.Exception ex)
                {
                    dvalue = 0;
                }
                if (tempVariable.IsContainEquation == false)
                {
                    CreateLabel(key, 0, Variable_Label_X, Pic_Y + Variable_Label_Y + (v_count * 30));
                    CreateTextBox(key, dvalue, Variable_TextBox_X, Pic_Y + Variable_TextBox_Y + (v_count * 30), Color.LightSkyBlue, tempVariable.IsZeroIsNullValue);
                    v_count++;
                }
            }

            //             foreach (var key in equainfo.m_Dictionary_Equation.Keys)
            //             {
            //                 var tempVariable = equainfo.m_Dictionary_Equation[key];
            //                 if (tempVariable is ComparableVariable)
            //                 {
            //                     double dvalue = 0;
            //                     try
            //                     {
            //                         if (tempVariable.IsHiddenVariable == false)
            //                         {
            //                             if (tempVariable.IsCorrespond)
            //                             {
            //                                 dvalue = FindValue(tempVariable.CorrespontVarName);
            //                             }
            //                         }
            //                     }
            //                     catch (System.Exception ex)
            //                     {
            //                         dvalue = 0;
            //                     }
            //                     if (tempVariable.IsHiddenVariable == false)
            //                     {
            //                         CreateLabel(key, 0, Variable_Label_X, Pic_Y + Variable_Label_Y + (v_count * 30));
            //                         CreateTextBox(key, dvalue, Variable_TextBox_X, Pic_Y + Variable_TextBox_Y + (v_count * 30), Color.MediumAquamarine);
            //                         v_count++;
            //                     }
            // 
            //                 }
            //             }

            foreach (var key in equainfo.m_Dictionary_Equation.Keys)
            {
                var tempVariable = equainfo.m_Dictionary_Equation[key];
                if (tempVariable is EquationVariable)
                {
                    double dvalue;
                    try
                    {
                        dvalue = m_Term.GetVar(tempVariable.Name);
                    }
                    catch (System.Exception ex)
                    {
                        dvalue = 0;
                    }
                    if (tempVariable.IsHiddenVariable == false)
                    {
                        CreateLabel(key, 0, Variable_Label_X, Pic_Y + Variable_Label_Y + (v_count * 30));
                        CreateTextBox(key, dvalue, Variable_TextBox_X, Pic_Y + Variable_TextBox_Y + (v_count * 30), Color.LightGoldenrodYellow, tempVariable.IsZeroIsNullValue);
                        v_count++;
                    }

                }
            }
            int ClientSize_X;
            int ClientSize_Y;


            ClientSize_X = tabControl.Width + 130;
            ClientSize_Y = Pic_Y + Variable_Label_Y + (v_count * 30);

            if (ClientSize_X > 800)
            {
                ClientSize_X = 800;

            }
            if (ClientSize_Y > 559)
            {
                ClientSize_Y = 559;

            }

            this.Refresh();
            this.ClientSize = new Size(700, ClientSize_Y + 50);
            panel1.AutoScroll = true;






        }

        // UI를 다 지움.
        private void deleteUI()
        {
            for (int i = this.panel1.Controls.Count - 1; i >= 0; i--)
            {
                panel1.Controls[i].Dispose();
            }

            panel1.Controls.Clear();
            GC.Collect();
            GC.WaitForFullGCApproach();
            toolStripLabel1.Text = "";
        }
        private void CreateLabel(string name, double value, int x, int y)
        {

            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.Location = new System.Drawing.Point(x, y);
            tempLabel.Name = name + "\\Label";
            tempLabel.Font = new Font("Calibri", 10);
            tempLabel.BorderStyle = BorderStyle.FixedSingle;
            tempLabel.AutoSize = false;
            tempLabel.Width = 200;
            tempLabel.Text = name;

            panel1.Controls.Add(tempLabel);
        }




        private void CreateTextBox(string name, double value, int x, int y, Color color, bool isCleared)
        {
            TextBox tempTextBox = new TextBox();
            tempTextBox.Location = new System.Drawing.Point(x, y);
            tempTextBox.Size = new System.Drawing.Size(170, 20);
            tempTextBox.Font = new Font("맑은 고딕", 9.5f);
            tempTextBox.Name = name + "\\TextBox";
            if (value == 0)
            {
                if (isCleared)
                    tempTextBox.Text = "";
                else
                    tempTextBox.Text = "0";
            }
            else
            {
                tempTextBox.Text = value.ToString("R").ToLower();
            }


            tempTextBox.BackColor = color;
            if (color != Color.LightSkyBlue)
                tempTextBox.ReadOnly = true;

            panel1.Controls.Add(tempTextBox);
        }

        private void SetTextBoxResult(string name, double result)
        {
            Control ctrl = panel1.Controls[name + "\\TextBox"];
            if (ctrl != null)
            {
                ctrl.Text = result.ToString("R").ToLower();
            }
        }       
#endregion


#region UI 이벤트들
        // 버튼 클릭 이벤트.
        private void m_Button_DoCalculate_Click(object sender, EventArgs e)
        {
            // 메인 계산기에 들어있는 데이터를 초기화
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    ctrl.ForeColor = Color.Black;
                }
            }
            ClearCalculateVar();
            if (m_SelectedEquation != null)
            {
                sendtoLog("☆★☆★☆★" + m_SelectedEquation + "☆★☆★☆★\n\n", Form_Log_Window.LogOption.System);
                DoCalculate(m_SelectedEquation);
                DoCalculate(m_SelectedEquation, false); // 재귀 호출로 하려 했으나 귀차니즘.
                if (CalculateEvent != null)
                {
                    CalculateEvent(m_SelectedEquation, m_Dictionary_EquationInfo[m_SelectedEquation]);
                }
            }
        }
        private void panel1_Click( object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void m_Button_Clear_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    //if (ctrl.BackColor != Color.LightGoldenrodYellow)
                    {
                        string[] splstrs = ctrl.Name.Split('\\');
                        VariableData vdata;
                        if (m_Dictionary_EquationInfo[m_SelectedEquation].m_Dictionary_Equation.TryGetValue(splstrs[0], out vdata))
                        {
                            if (!vdata.IsCorrespond)
                            {
                                ctrl.Text = "";
                                vdata.Value = 0;
                                vdata.IsZeroIsNullValue = true;
                            }
                            else
                            {
                                try
                                {
                                    ctrl.Text = FindValue(vdata.CorrespontVarName).ToString("R");
                                }
                                catch (Exception ex)
                                {
                                    ctrl.Text = "";
                                    Trace.WriteLine(ex.Message);
                                    vdata.Value = 0;
                                }

                            }
                        }
                        else
                        {
                            Trace.WriteLine("이건 오류야 CalculatingForm 753p");
                            ctrl.Text = "";
                        }

                    }

                }
            }
        }

        private void m_Button_Add_Equation_Click(object sender, EventArgs e)
        {
            if (m_SelectedEquation == null)
                return;
            var tempequation = new Dictionary<string, VariableData>(m_Dictionary_EquationInfo[m_SelectedEquation].m_Dictionary_Equation);
            Form_Edit_Calculator editform = new Form_Edit_Calculator(tempequation, m_SelectedEquation, m_Dictionary_EquationInfo);

            if (editform.ShowDialog() == DialogResult.OK)
            {
                m_Dictionary_EquationInfo[m_SelectedEquation].m_Description = editform.m_Description_Script;
                m_Dictionary_EquationInfo[m_SelectedEquation].m_imagePath = editform.m_Image_Path;
                m_Dictionary_EquationInfo[m_SelectedEquation].m_Dictionary_Equation = new Dictionary<string, VariableData>(editform.Sorted_Dictionary);
                // SetImageToFolder();
                if (EditComplateEvent != null)
                    EditComplateEvent();
            }
            deleteUI();
            SettingForUI(m_Dictionary_EquationInfo[m_SelectedEquation]);
            editform.Dispose();
        }

        // 안 쓰임.
        private void SetImageToFolder()
        {
            string[] FolderTokenizer = m_SelectedEquation.Split(':');
            string imagedirectory = m_ProgramPath + "\\image";
            string firstfolder = imagedirectory + "\\" + FolderTokenizer[0];
            string image_path = m_Dictionary_EquationInfo[m_SelectedEquation].m_imagePath;
            string extention = Path.GetExtension(image_path);
            string secondfolder = firstfolder + "\\" + FolderTokenizer[1] + extention;

            if (!Directory.Exists(firstfolder))
            {
                Directory.CreateDirectory(firstfolder);
            }

            File.Copy(image_path, secondfolder, true);





        }

        private void CalculatingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteUI();
        } 
#endregion

      

       

        
    }
}
