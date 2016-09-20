using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGEquationCalc
{
    [Serializable]
    // 계산할 공식들의 데이터를 보관하는 클래스
    public class EquationInformation
    {
        public Dictionary<string, VariableData> m_Dictionary_Equation = new Dictionary<string, VariableData>();


        // 수식 페이지의 이미지 주소
        public string m_imagePath
        {
            get;set;
        }
        // 수식 설명
        public string m_Description
        {
            get;set;
        }

        // 관리자에 의해 잠겼는지 확인하는 변수
        public bool isAdminLocked
        {
            get;set;
        }

        // 이미지 변경을 했는가.
        public bool isUserimage
        {
            get;set;
        }
        
        public EquationInformation()
        {
            m_Description = "수식 설명이 없습니다";
            m_imagePath = "";
            isAdminLocked = false;
        }    
       

    }
    // Serializable은 변수 직렬화를 의미. 파일로 저장할때 직렬화해서 저장
    [Serializable]
    // 변수 데이터
    public class VariableData
    {
        // 계산전 데이터 검증을 위한 옵션들
        public enum CheckOption
        {
            None,
            MinMax, // 최소값 최대값
            Custom, // 사용자 정의
            Case // 분기 조건문
        }

        //분기 조건문을 위한 Dictionary
        public Dictionary<string, string> m_Dictionary_SwitchInfo = new Dictionary<string, string>();
        // 현재 변수의 데이터 검증 옵션
        public CheckOption m_checkOption = CheckOption.None;
        public string CustomOptionString; // 사용자 정의 옵션의 스트링
        public double OptionMinValue; //  검증 최소값
        public double OptionMaxValue; // 검증 최대값

        bool isContainEquation; // 이 변수가 수식을 포함하고 있는지.
        bool isHiddenVariable; // 숨겨진 변수인가
        bool isZeroIsNullValue = false; // 0값이 사용자가 정의한 0인지 null로 인한 0인지 구별하기 위해
       
        protected string m_Name; // 변수 명
        protected double m_Value; // 변수 값

        
        public virtual string GetType()
        {
            return "입력";
        }
                

        public virtual double Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
        public string CorrespontVarName // Iscorrespond가 yes라면 그 주소가 어디인지
        {
            get;set;
        }

        public string Name
        {
            get { return m_Name;  }
            set { m_Name = value; }
        }

        public bool IsCorrespond // 이 변수가 다른 수식의 결과값을 가르키는지
        {
            get;set;
        }
        
  
        public virtual string Equation 
        {
            get { return ""; }
            set { }
        }

        public bool IsZeroIsNullValue
        {
            get { return isZeroIsNullValue; }
            set { isZeroIsNullValue = value; }
        }
        public bool IsContainEquation 
        {
            get { return isContainEquation; }
            set { isContainEquation = value;  }
        }

        public bool IsHiddenVariable
        {
            get { return isHiddenVariable;  }
            set { isHiddenVariable = value; }
        }

        public VariableData()
        {
        }        
        public VariableData(string name )
        {
            m_Name = name;
            IsContainEquation = false;
            m_Value = 0.0;
        }
        public VariableData(string name, bool isequation, double value )
        {
            if (isequation == true)
                throw new Exception("일반 변수는 이걸 True로 지정해선 안됩니다");
            m_Name = name;
            isContainEquation = isequation;
            m_Value = value;            
        }
    }
    [Serializable]
    class EquationVariable : VariableData
    {
        string m_Equation; //수식내용
        
        
        public EquationVariable(string name) : base(name)
        {
            m_Equation = "";
            IsContainEquation = true;
        }
        public EquationVariable(string name, string equation)
        {
            m_Name = name;
            m_Equation = equation;
            IsContainEquation = true;
        }
        public EquationVariable(string name, bool isequation, double value,string equation) : base(name, isequation,value)
        {
            m_Equation = equation;
        }

        public override string GetType()
        {
            return "출력";
        }

        public override string Equation
        {
            get { return m_Equation; }
            set { m_Equation = value; }
        }        
    }
    // 비교 변수 인데 안 쓰임 그냥 놔둠.
    [Serializable]
    public class ComparableVariable : VariableData
    {
        public List<CompareData> m_list_CompareData = new List<CompareData>();

        public bool bResult;               

        public override string GetType()
        {
            return "조건변수";
        }
        
        public override double Value
        {
            get
            {
                bool bResult = Compare();
                if (!bResult)
                {
                    throw new CommonUtils.ParseException(GetCompareEquation(), 1, "변수의 조건이 일치하지 않습니다. 변수 값을 확인해 주시길 바랍니다.\n");
                }
                    

                return m_Value;
            }         
            set
            {
                m_Value = value;
            }
        }

        public override string Equation
        {
            get
            {
                return base.Equation;
            }
        }       

        
        
       

        public ComparableVariable():base()
        {

        }        
        public ComparableVariable(string name, bool isequation, double value) : base(name, isequation,value)
        {
            
        }

       public string GetCompareEquation()
       {
           StringBuilder sb = new StringBuilder();

           foreach(CompareData comdata in m_list_CompareData )
           {
               sb.Append(comdata.s_if);
               sb.Append(" ");
               sb.Append(comdata.symbol);
               sb.Append(" ");
               sb.Append(comdata.s_then);
               sb.Append(" -> ");
               sb.Append(comdata.s_value);

               sb.Append("\n");
           }

           return sb.ToString();
       }

       
       
        

        private bool Compare()
        {
            bool bReturn = false;
            foreach( CompareData comdata in m_list_CompareData)
            {
                if( comdata.symbol == ">=")
                {
                    if (comdata.d_if >= comdata.d_then)
                    {
                        bReturn = true;
                        Value = comdata.d_value;
                    }
                }
                else if (comdata.symbol == "==")
                {
                    if (comdata.d_if == comdata.d_then)
                    {
                        bReturn = true;
                        Value = comdata.d_value;
                    }
                }
                else if (comdata.symbol == ">")
                {
                    if (comdata.d_if > comdata.d_then)
                    {
                        bReturn = true;
                        Value = comdata.d_value;
                    }
                }
                else if (comdata.symbol == "!=")
                {
                    if (comdata.d_if != comdata.d_then)
                    {
                        bReturn = true;
                        Value = comdata.d_value;
                    }
                }
            }

            return bReturn;
        }

        public void InitCompareList( List<CompareData> l_data )
        {
            m_list_CompareData = new List<CompareData>(l_data);
        }
       

    }
}

// 안 쓰임. 그냥 놔둠.
[Serializable]
public class CompareData
{
    public string s_if;
    public string s_then;
    public string s_value;
    public double d_if;
    public double d_then;
    public double d_value;

    public string symbol;
    public bool isIfEquation;
    public bool isThenEquation;
    public bool istValueEquation;    
}
