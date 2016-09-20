using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CommonUtils
{
    // Parse 오류가 났을때 뿌려줄 Exception 클래스
	class ParseException : Exception
	{
		public string ParsedString {get; set;} // 스트링
		public int IndexOfError {get; set;} // 에러의 index
		public ParseException(string parsedString, int indexOfError, string message) : base(message)
        {
            ParsedString = parsedString;
            IndexOfError = indexOfError;
        }
	}
    // 수식을 하기위한 Element를 정의 이 클래스는 abstract로 이클래스 단독으로 사용할 수 없음.
	public abstract class EquationElement
	{
		public EquationElement Parent {get; set;} // Element의 부모값.
		protected StringBuilder m_sb = new StringBuilder(); // 현재 Element가 담고 있는 스트링.
		public virtual int Length { get { return m_sb.Length; }}
		protected virtual void Add(char ch)
		{
			m_sb.Append(ch);
		}
        /// <summary>
        /// 이 Element가 어떤 클래스인지 구분시켜주는 함수
        /// </summary>
        /// <param name="equation"></param>
        /// <param name="index"></param>
        /// <returns></returns>
		public abstract bool IsValid(string equation, int index);
		public override string ToString()
		{
			return m_sb.ToString();
		}

		protected EquationElement Root // 이 Element의 Root를 찾아서 뱉어냄.
		{
			get
			{
				if (Parent == null)
					return this;
				EquationElement parent = Parent;
				while (parent != null && parent.Parent != null)
					parent = parent.Parent;
				return parent;
			}
		}

		Dictionary<string, double> m_variables; // 이 클래스가 포함하고 있는 변수들
		Dictionary<string, bool> m_usedVars; // 사용한 변수들. 안쓰임

        public Dictionary<string, double> Variables
        {
            get { return m_variables; }
        }
        public void ClearVars() // 내부의 변수를 모두 초기화
		{
			EquationElement root = Root;
			if (root.m_variables != null)
				root.m_variables.Clear();
		}
        /// <summary>
        /// 해당 변수명을 찾아서 지움
        /// </summary>
        /// <param name="varname">변수명</param>
        /// <returns>변수지우는데 성공을 하면 True 실패시 false</returns>
        public bool removeVar(string varname) // 
        {
            EquationElement root = Root;
            if (root != null)
            {
                if (root.m_variables == null)
                {
                    root.m_variables = new Dictionary<string, double>();
                    return false;
                }
                if (root.m_variables.ContainsKey(varname))
                {
                    root.m_variables.Remove(varname);
                    return true;
                }
            }

            return false;
            
        }
        /// <summary>
        /// 해당 변수가 존재하는가
        /// </summary>
        /// <param name="varname"></param>
        /// <returns></returns>
        public bool VarExist(string varname)
        {
            EquationElement root = Root;
            return (root.m_variables != null && root.m_variables.ContainsKey(varname.ToLower()));
		}
        /// <summary>
        /// 변수를 설정함
        /// </summary>
        /// <param name="varname"></param>
        /// <param name="value"></param>
		public void SetVar(string varname, string value)
		{
			Term term = new Term();
			term.Parse(value);
			SetVar(varname, term.Value);
		}
        /// <summary>
        /// 변수를 설정함
        /// </summary>
        /// <param name="varname"></param>
        /// <param name="value"></param>
		public void SetVar(string varname, double value) 
		{
            EquationElement root = Root;
            if (root.m_variables == null)
                root.m_variables = new Dictionary<string, double>();
            root.m_variables[varname.ToLower()] = value;
        }
        /// <summary>
        /// 변수를 얻어옴
        /// </summary>
        /// <param name="varname"></param>
        /// <returns></returns>
		public double GetVar(string varname)
        {
            EquationElement root = Root;
            double result = 0;
            if (root.m_variables == null || root.m_variables.TryGetValue(varname.ToLower(), out result) == false)
                throw new ParseException(this.ToString(), 0, string.Format("변수 {0}가 정의되지 않았습니다.", varname));
            if (m_usedVars == null)
                m_usedVars = new Dictionary<string, bool>();
            if (m_usedVars.ContainsKey(varname) == false)
                m_usedVars[varname] = true;
            return result;
        }
        /// <summary>
        /// 모든 변수를 얻어옴
        /// </summary>
        /// <returns></returns>
        public string[] GetVars()
        {
            EquationElement root = Root;
            if (m_variables == null)
                return new string[0];
            List<string> I = new List<string>(m_variables.Keys);
            I.Sort();
            return I.ToArray();
        }
		public string[] GetUsedVars()
		{
            if (m_usedVars == null)
                return new string[0];
            List<string> l = new List<string>(m_usedVars.Keys);
            l.Sort();
            return l.ToArray();
		}
	}

    // 비교연산자
    public class CompareOperator : EquationElement
    {
        static public bool IsValidOperator( string ch )
        {
            string[] operators = new string[] {  ">", "<", ">=", "<=", "==", "!=" };
            if (operators.Contains(ch))
                return true;
            return false;
        }
        public string Value { get; private set;}
        public CompareOperator(string src)
        {
            if( IsValid(src,0))
            {
                Value = src;
                foreach( char c in src)
                {
                    Add(c);
                }
            }
        }
        public override bool IsValid(string equation, int index)
        {
            return IsValidOperator(equation);
        }
    }
    /// <summary>
    /// 연산자
    /// </summary>
    public class Operator : EquationElement
    {
        static public bool IsValidOperator(char ch)
        {
            char[] operators = new char[] { '+', '-', '/', '*', '^', '%' };
            if (operators.Contains(ch))
                return true;
            return false;
		}
        public char Value { get; private set; }
        public override bool IsValid(string equation, int index)
        {
            return IsValidOperator(equation[index]);
        }
		public Operator(string src, int start)
		{
			if (IsValid(src, start))
			{
				Value = src[start];
				Add(Value);
			}
		}
        public Operator(char ch)
        {
            if (IsValidOperator(ch))
            {
                Value = ch;
                Add(Value);
            }
        }
		public bool CanStartTerm
		{
			get { return Value == '-'; }
		}
		public bool IsSign
		{
			get { return Value == '-'; }
		}
        /// <summary>
        /// Operator 좌우의 값을 받아서 계산해서 리턴함
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>계산된 값</returns>
		public double Perform(double left, double right)
		{
			if (Value == '-')
				return left - right;
			if (Value == '+')
				return left + right;
			if (Value == '*')
                return left * right;
            if (Value == '/')
                return left / right;
            if (Value == '^')
                return Math.Pow(left, right);
            if (Value == '%')
            {
                return left % right;
            }
			throw new ParseException("", 0, string.Format("지원되지 않은 연산자 입니다. '{0}'", Value));
		}
    }
    /// <summary>
    /// Operator에 의해 연산될 EquationValue들.
    /// </summary>
    public abstract class EquationValue : EquationElement
    {

        protected bool m_signed = false; // -변수인가.
        public virtual double Value { get; protected set; }
        public virtual bool Signed
        {
            get { return m_signed; }
            set
            {
                m_signed = value;
                if (m_signed && Value > 0)
                {
                    Value = 0 - Value;
                    return;
                }
                if (!m_signed && Value < 0)
                {
                    Value = Math.Abs(Value);
                }

            }
        }
        /// <summary>
        /// 이 Value가 -표시를 앞에 붙여되 되는지 안되는지
        /// </summary>
        public virtual bool CanBeSigned { get { return true; } }
        public override string ToString()
        {
            if (Signed)
                return "s" + base.ToString();
            return base.ToString();
        }
    }
    /// <summary>
    /// 괄호 : Value의 최상위 값이므로 Parse는 여기서 실행할것.
    /// </summary>
    public class Term : EquationValue
	{
		public override double Value
		{
			get
            {
                double value = 0;
                if (Stack.Count == 0)
                    return value;

                EquationValue left = Stack[0] as EquationValue;
                value = left.Value;

                // () 내부의 Element들을 구분해서 리턴
				for (int index = 1; index < Stack.Count; index++)
				{
					Operator op = null;
                    EquationValue right = null;
                    if (index < Stack.Count)
                        op = Stack[index] as Operator;
                    if (index + 1 < Stack.Count)
						right = Stack[index+1] as EquationValue;
					if (op != null && right != null)
						value = op.Perform(value, right.Value);
					index += 1;
				}
				if (this.Signed)
					return -value;
				return value;
			}
		}
        // Term들의 스택을 만들어 보관. 재귀호출용
		public List<EquationElement> Stack { get; set; }
		static public bool IsValidDigit(char ch)
		{
            if (ch == '(' || ch == '[')
                return true;           
			return false;
		}
        
		public override bool IsValid(string equation, int index)
		{
			return IsValidDigit(equation[index]);
		}
		public Term(string src, int start) : this()
		{
		}
		public Term()
		{
			Stack = new List<EquationElement>();
		}
		public override string ToString()
		{
            StringBuilder sb = new StringBuilder();
            if (Signed)
                sb.Append("s");

            sb.Append("(");



            foreach (EquationElement item in Stack)
                sb.Append(item.ToString());

            sb.Append(")");
            
            
            return sb.ToString();
        }
        // 파싱.
		public void Parse(string equation)
		{
			Parse(equation, this);
		}
        /// <summary>
        /// 최상위에서부터 차근차근 풀어감
        /// 연산전 제곱과 나눔 곱셈을 구분해서 연산 순위를 정참.
        /// </summary>
        /// <param name="equation"></param>
        /// <param name="root"></param>
        public void Parse(string equation, EquationElement root)
        {
            Stack.Clear();
            Parse(equation, 0, root);
            CombineTerms(new char[] { '^' }); 
            CombineTopDown();
            CombineTerms(new char[] { '*', '/' });
        }
        /// <summary>
        /// Minus 기호를 뺴오기
        /// </summary>
        /// <returns></returns>
        EquationElement PopSignOperator()
        {
            if (Stack.Count > 1)
			{
				int index = Stack.Count-1;
				Operator op1 = Stack[index] as Operator;
				Operator op2 = Stack[index-1] as Operator;
				if (op2 != null && op1 != null && op1.IsSign)
				{
					Stack.RemoveAt(index);
					return op1;
				}
			}
			if (Stack.Count == 1)
			{
				int index = Stack.Count-1;
				Operator op1 = Stack[index] as Operator;
				if (op1 != null && op1.IsSign)
				{
					Stack.RemoveAt(index);
					return op1;
				}
			}
			return null;
		}
		EquationElement LastElement
		{
			get
			{
				if (Stack.Count == 0)
					return null;
				return Stack[Stack.Count-1];
			}
		}
		int OperatorCount
		{
			get
			{
				int cnt = 0;
				for (int index = Stack.Count-1; index >= 0; index--)
				{
					if (Stack[index] is Operator)
					{
						cnt++;
						continue;
					}
					break;
				}
				return cnt;
			}
		}
		EquationElement Add(EquationElement item)
		{
            item.Parent = this;
            if (item is EquationValue)
			{
				// 변수와 변수 사이에 *를 삽입
                 if (LastElement is EquationValue)
                     Stack.Add(new Operator('*'));
                
                if (PopSignOperator() != null)
                    ((EquationValue)item).Signed = true;
                Stack.Add(item);
				return item;
			}
			if (item is Operator)
			{
				// 괄호앞에 - 이외엔 쓸수 없음.
				if (((Operator)item).CanStartTerm == false && Stack.Count == 0)
					throw new ParseException(string.Empty, 0, "- 기호 이외엔 괄호앞에 사용 할 수 없습니다.");
				// -(-) 일 경우도 생각
				Operator op = LastElement as Operator;
				if (op != null && ((Operator)item).IsSign == false)
					throw new ParseException(Root.ToString(), 0, "연속된 연산자는 유효하지 않습니다.");
				if (OperatorCount >= 2)
					throw new ParseException(Root.ToString(), 0, "연속된 연산자는 유효하지 않습니다.");
				Stack.Add(item);
				return item;
			}
            if (item is CompareOperator)
            {
                Stack.Add(item);
                return item;
            }
			return null;
		}
        /// <summary>
        /// 파싱함수
        /// </summary>
        /// <param name="equation"></param>
        /// <param name="index"></param>
        /// <param name="root"></param>
        /// <returns></returns>
		int Parse(string equation, int index, EquationElement root)
		{
			while (index < equation.Length)
			{
				char ch = equation[index];
				if (char.IsWhiteSpace(ch)) // 공백무시
				{
					index++;
					continue;
				}
				if (Operator.IsValidOperator(ch)) // 각 클래스에 정의된 Valid옵션을 토대로 Parse
				{
					EquationElement n = Add(new Operator(equation, index)); // Add에서 해당 Element의 길이를 구해서 스택에 저장.
					index += n.Length; //인덱스를 n의 길이만큼 늘려서 계속 검색
					continue;
				}
				if (Number.IsValidDigit(equation, index)) 
				{
					EquationElement n = Add(new Number(equation, index));
					index += n.Length;
					continue;
				}
				if (Constant.IsValidDigit(equation, index))
				{
					EquationElement n = Add(new Constant(equation, index));
					index += n.Length;
					continue;
				}
				if (Function.IsValidDigit(equation, index))
				{
					EquationElement n = Add(new Function(equation, index, root));
					index += n.Length;
					continue;
				}
                if (CompareOperator.IsValidOperator(equation))
                {
                    EquationElement n = Add(new CompareOperator(equation));
                    index += n.Length;
                    continue;
                }
				if (Variable.IsValidDigit(equation, index, root))
				{
					EquationElement n = Add(new Variable(equation, index, root));                    
					index += n.Length;
					continue;
				}
				index++;

				if (Term.IsValidDigit(ch)) // 괄호가 또나오면 그 괄호를 풀어야됨.
				{
					int endindex = FindMatchingEnd(ch, equation, index-1);
					if (endindex > index)
                    {
                        int len = endindex - index;
                        string s = equation.Substring(index, len);
                        Term g = Add(new Term(s, 0)) as Term;
                        len = g.Parse(s, 0, root) + 1;
                        index += len;
                        continue;
					}
					throw new ParseException(equation, index-1, "매칭되는 괄호를 찾을 수 없습니다.");
				}
                else
                {
                    if (ch == ']' || ch == ')')
                        throw new ParseException(equation, index - 1, " 매칭되는 괄호를 찾을 수 없습니다");
                }
                

			}
			return index;
		}
		void CombineTopDown()
		{
			// ^연산자의 경우 가장 먼저 처리.
            // 2^3^4 일 경우엔 2^(3^4) right -> left(top->down) 형태로 처리
			char operatorCh = '^';
			foreach (EquationElement element in Stack)
			{
				if (element is Term)
					((Term)element).CombineTopDown();
			}
			int index = Stack.Count-1;
			while (index > 0)
			{
				Operator op = Stack[index] as Operator;
				index--;
				if (op == null || op.Value != operatorCh)
					continue;

				EquationElement left = Stack[index];
				EquationElement right = Stack[index+2];

				Term newterm = new Term();
				newterm.Parent = this;
                newterm.Add(left);
                newterm.Add(op);
                newterm.Add(right);

				// move signed to outer term
				if ( ((EquationValue)left).Signed )
				{
					((EquationValue)left).Signed = false;
					newterm.Signed = true;
				}

				Stack.RemoveRange(index, newterm.Stack.Count);
				Stack.Insert(index, newterm);
			}
		}
		void CombineTerms(char[] operators)
		{
			foreach (EquationElement element in Stack)
			{
				if (element is Term)
					((Term)element).CombineTerms(operators);
			}
			if (NeedSubTerms(operators) == false)
				return;

            int startIndex = 0;
            int startpoint = 0;
            while (startIndex < Stack.Count)
			{
				startIndex = FindOperator(startIndex, operators);
				if (startIndex < 0)
                    return;

                Term newterm = new Term();
                newterm.Parent = this;
                startIndex--;
                startpoint = startIndex;

                while (startIndex < Stack.Count)
                {
                    EquationElement item = Stack[startIndex];
                    if (item is EquationValue)
                    {
                        newterm.Add(item);
                        startIndex++;
					}
					if (item is Operator)
					{
						Operator op = item as Operator;
						if (op == null || operators.Contains(op.Value) == false)
						{
							Stack.RemoveRange(startpoint, newterm.Stack.Count);
							Stack.Insert(startpoint, newterm);
							break;
						}
						newterm.Add(item);
						startIndex++;
					}

					if (startIndex >= Stack.Count)
					{
                        Stack.RemoveRange(startpoint, newterm.Stack.Count);
                        Stack.Insert(startpoint, newterm);
                        return;
                    }
				}
			}
		}
		bool NeedSubTerms(char[] operators)
		{			
			for (int index = 0; index < Stack.Count; index++)
			{
				Operator op = Stack[index] as Operator;
				if (op != null && operators.Contains(op.Value) == false)
					return true;
			}
			return false;
		}
		int FindOperator(int startIndex, char[] operators)
		{
			for (int index = startIndex; index < Stack.Count; index++)
			{
				Operator op = Stack[index] as Operator;
				if (op != null && operators.Contains(op.Value))
					return index;
			}
			return -1;
		}

		public static int FindMatchingEnd(char beginChar, string equation, int beginCharindex)
		{
			int index = beginCharindex;
			int matchCount = 0;
			char endChar = ')';
			if (beginChar == '[')
				endChar = ']';
			while (index < equation.Length-1)
			{
				index++;
				char ch = equation[index];
				if (ch == beginChar)
				{
					matchCount++;
					continue;
				}
				if (ch == endChar)
				{
					if (matchCount == 0)
						return index;
					matchCount--;
					continue;
				}
			}
			return -1;
		}
		public static string ExtractName(string equation, int index)
		{
			return ExtractName(equation, index, true);
		}
		public static string ExtractName(string equation, int index, bool allowDigits)
		{
			StringBuilder sb = new StringBuilder();
			while (index < equation.Length)
			{
				char ch = equation[index];
                if (char.IsLetter(ch))
                    sb.Append(ch);
                else if (ch == '˚')
                    sb.Append(ch);
                else if (ch == '_')
                    sb.Append(ch);
                else if (allowDigits && (char.IsDigit(ch)) && (sb.Length > 0))  // 변수의 이름 첫글자는 숫자가 와선 안됨.    
                    sb.Append(ch);

                else
                    break;
				index++;
			}
			return sb.ToString();
		}
	}
	class Number : EquationValue
	{
		static string GetNumber(string equation, int index)
		{
			StringBuilder sb = new StringBuilder();
			char[] chars = new char[] {',', '.','E','e', '-','+', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
			bool isScientific = false;
			while (index < equation.Length)
			{
				char ch = equation[index++];
				if (ch >= '0' && ch <= '9')
				{
					sb.Append(ch);
					continue;
				}
				if (chars.Contains(ch))
				{
					// e랑 E는 단독으로 쓰일때 자연수가 될수 있고
					if (ch == 'e' || ch == 'E')
					{
						if (isScientific)
							break;
						isScientific = true;
						if (index >= equation.Length)
							break;
						char nextchar = equation[index];
						if (chars.Contains(nextchar) == false)
							break;
					}
					// 마지막 뒤에 붙으면 자릿수 축약용 
					char lastchar = char.ToLower(sb[sb.Length-1]);
                    if (ch == '-' && lastchar != 'e')
                        break;
                    if (ch == '+' && lastchar != 'e')
                        break;
                    sb.Append(ch);
                    continue;
                }
				break;
			}
			return sb.ToString();
		}
		static public bool IsValidDigit(string equation, int index)
		{
			char ch = equation[index];
			if (ch < '0' || ch > '9')
				return false;
			return GetNumber(equation, index).Length > 0;
		}
		public override bool IsValid(string equation, int index)
		{
			return IsValidDigit(equation, index);
		}
		public Number(string src, int start)
		{
			string number = GetNumber(src, start);
			if (number.Length > 0)
				m_sb.Append(number);
			double result;

			string val = m_sb.ToString();
			string invarSeperator = System.Globalization.CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
			val = val.Replace(",", invarSeperator);
			if (double.TryParse(val, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result) == false)
				throw new ParseException(src, start, "double 형으로 변환할 수 없습니다.");
			Value = result;
		}
	}
    /// <summary>
    /// 변수
    /// </summary>
	class Variable : EquationValue
	{
		public override bool Signed 
		{
			get { return m_signed;}
			set { m_signed = value; }
		}
		public override double Value
		{
			get
			{
				double value = Root.GetVar(m_sb.ToString());
				if (this.Signed)
					return -value;
				return value;
			}
		}
		static string GetVarName(string equation, int index, EquationElement root)
		{
			string varname = Term.ExtractName(equation, index).ToLower();
			if (root != null && root.VarExist(varname))
				return varname;
            char ch = equation[index]; 
            if (ch >= 'a' && ch <= 'z')
                //return new string(new char[] { ch });
                return varname;
            if (ch >= 'A' && ch <= 'Z')
                // return new string(new char[] { ch });
                return varname;
            if (ch == '_')
                // return new string(new char[] { ch });
                return varname;
            return string.Empty;
		}
		static public bool IsValidDigit(string equation, int index, EquationElement root)
		{
			return GetVarName(equation, index, root).Length > 0;
		}
		public override bool IsValid(string equation, int index)
		{
			throw new NotImplementedException();
		}
		public bool IsValid(string equation, int index, EquationElement root)
		{
			return GetVarName(equation, index, root).Length > 0;
		}
		public Variable(string src, int start, EquationElement root)
		{
			
			string varname = GetVarName(src, start, root);
			if (varname.Length > 0)
				m_sb.Append(varname);
		}
	}
	class Constant : EquationValue
	{
		static bool IsPI(string equation, int index)
		{
			if (equation.Length > index + 1)
            {
                string spi = Term.ExtractName(equation, index, false).ToLower();
                if (spi == "pi")
                    return true;
			}
			return false;
		}
        static bool IsE(string equation, int index)
        {
            char ch = equation[index];
            if (ch == 'e' )
                return true;
            return false;
		}
		static public bool IsValidDigit(string equation, int index)
		{
			if (IsE(equation, index))
				return true;
			if (IsPI(equation, index))
				return true;
			return false;
		}
		public override bool IsValid(string equation, int index)
		{
			return IsValidDigit(equation, index);
		}
		public Constant(string src, int start)
		{
			if (IsE(src, start))
			{
				m_sb.Append("e");
				Value = Math.E;
			}
			if (IsPI(src, start))
			{
				m_sb.Append("pi");
				Value = Math.PI;
			}
		}
	}

    
    // 함수지원 클래스.
	class Function : EquationValue
	{
        delegate double FunctionCallback(double value);
        delegate double FunctionCallback2(double value, double value1);
        delegate double FunctionCallbackIF(double v, double v2, string symbol, double t, double f);
      //  delegate double FunctionCallbackIF2(params object[] param);
       
        public static string[] FunctionsList { get; private set; }
        static Dictionary<string, FunctionCallback> Functions;
        static Dictionary<string, FunctionCallback2> Functions2;
        static Dictionary<string, FunctionCallbackIF> FunctionsIF;
     //   static Dictionary<string, FunctionCallbackIF2> FunctionsIF2;

        
        
        static double Ln(double value)
        {
			return Math.Log(value, Math.E);
		}

        static double IF( double left, double right, string symbol, double t, double f)
        {
            if( symbol == "(==)")
            {
                if( left == right )
                    return t;
                return f;
            }
            else if( symbol == "(>=)" )
            {
                if( left >= right )
                    return t;
                return f;
            }
            else if( symbol == "(!=)")
            {
                if( left != right )
                    return t;
                return f;
            }
            else if( symbol == "(>)")
            {
                if( left>right)
                    return t;
                return f;
            }
            else if (symbol == "(<)")
            {
                if (left < right)
                    return t;
                return f;
            }
            else if (symbol == "(<=)")
            {
                if (left <= right)
                    return t;
                return f;
            }
            throw new ParseException(symbol, 0, "IF 함수에 사용할수 있는 기호는 >=, >, !=, == 입니다.");
            
        }        

        static double Round(double value1, double value2)
        {
            return Math.Round(value1, (int)value2);
        }
        static double Round(double value1)
        {
            return Math.Round(value1, 0);
        }
		static Function()
		{
			Functions2 = new Dictionary<string, FunctionCallback2>();
			Functions = new Dictionary<string, FunctionCallback>();
            FunctionsIF = new Dictionary<string, FunctionCallbackIF>();
       //     FunctionsIF2 = new Dictionary<string, FunctionCallbackIF2>();
			Functions["abs"] = new FunctionCallback(Math.Abs);
			Functions["sin"] = new FunctionCallback(Math.Sin);
			Functions["cos"] = new FunctionCallback(Math.Cos);
			Functions["tan"] = new FunctionCallback(Math.Tan);
			Functions["sqrt"] = new FunctionCallback(Math.Sqrt);
			Functions["log"] = new FunctionCallback(Math.Log10);
			Functions2["log"] = new FunctionCallback2(Math.Log);
            Functions["ln"] = new FunctionCallback(Ln);
            Functions["acos"] = new FunctionCallback(Math.Acos);
            Functions["asin"] = new FunctionCallback(Math.Asin);
            Functions["atan"] = new FunctionCallback(Math.Atan);
			//Functions2["atan2"] = new FunctionCallback2(Math.Atan2);
			Functions["ceiling"] = new FunctionCallback(Math.Ceiling);
			Functions["floor"] = new FunctionCallback(Math.Floor);
            Functions["cosh"] = new FunctionCallback(Math.Cosh);
            Functions["sinh"] = new FunctionCallback(Math.Sinh);
            Functions["tanh"] = new FunctionCallback(Math.Tanh);
            Functions2["max"] = new FunctionCallback2(Math.Max);
            Functions2["min"] = new FunctionCallback2(Math.Min);
            Functions2["round"] = new FunctionCallback2(Round);
            Functions["round"] = new FunctionCallback(Round);
            Functions["exp"] = new FunctionCallback(Math.Exp);
            FunctionsIF["if"] = new FunctionCallbackIF(IF);
           // FunctionsIF2["if"] = new FunctionCallbackIF2(IF);

// 			FunctionsList = new string[]
// 			{
// 				"abs(a)",
// 				"sin(a)",
// 				"asin(a)",
// 				"sinh(a)",
// 				"cos(a)",
// 				"acos(a)",
// 				"cosh(a)",
// 				"tan(a)",
// 				"atan(a)",
// 				//"atan2(y, x)",
// 				"tanh(a)",
// 				"sqrt(a)",
// 				"log(a, base)",
// 				"log(a)",
// 				"ln(a)",
// 				"ceiling(a)",
// 				"floor(a)",
// 				"max(a, b)",
// 				"min(a, b)",
//                 "round(a, b)"
// 			};
		}
		public override bool Signed 
		{
			get { return m_signed;} 
			set { m_signed = value; }
		}

        /// <summary>
        /// 함수의 ,로 나눠진 인자를 검색해서 해당되는 대리자를 호출해서 그 값을 리턴.
        /// </summary>
		public override double Value
		{
			get 
			{

				if (m_terms.Count == 1)
				{
					double value = Functions[m_func](m_terms[0].Value);
					if (Signed)
						return -value;
					return value;
				}
				if (m_terms.Count == 2)
				{
                    double value = Functions2[m_func](m_terms[0].Value, m_terms[1].Value);
                    if (Signed)
                        return -value;
                    return value;
                }                
                if( m_terms.Count ==5 )
                {
                    double value = FunctionsIF[m_func](m_terms[0].Value, m_terms[1].Value, m_terms[2].ToString(), m_terms[3].Value, m_terms[4].Value);
                    if (Signed)
                        return -value;
                    return value;
                }
                throw new ParseException(string.Empty, 0, string.Format("{0} 개의 인자를 포함하는 함수는 없습니다.", m_terms.Count));
            }
		}
        static public bool IsValidDigit(string equation, int index)
        {
			string spi = Term.ExtractName(equation, index).ToLower();
			if (spi.Length < 2)
				return false;
			if (Functions.ContainsKey(spi))
				return true;
			if (Functions2.ContainsKey(spi))
				return true;
             if (FunctionsIF.ContainsKey(spi))
                 return true;            
			return false;
		}
		public override bool IsValid(string equation, int index)
		{
			return IsValidDigit(equation, index);
		}
		
		string m_func = string.Empty;
		int m_startIndex;
		int m_endindex;
		List<Term> m_terms;
		public override int Length
		{
			get
			{
				return m_endindex- m_startIndex + 1;
			}
		}
		public Function(string src, int start, EquationElement root)
		{
			m_startIndex = start;
			m_func = Term.ExtractName(src, start).ToLower();
			start+= m_func.Length;
			// space는 무시, 다음문자는 무조건 괄호가 와야함.
			while (src[start] == ' ')
				start++;
			if (src[start] != '(')
                throw new ParseException(src, m_startIndex, "함수는 무조건 () 로 실행해야 합니다.'");
            int termstart = start;
            int end = Term.FindMatchingEnd('(', src, termstart);
            if (end < termstart)
                throw new ParseException(src, m_startIndex, "함수 매칭 실패");

			m_endindex = end;
			string allterms = src.Substring(termstart+1, end-termstart-1);
			//string[] terms = allterms.Split(',');
			string[] terms = GetTerms(allterms);
			m_terms = new List<Term>();
			foreach (string term in terms)
			{
				Term newterm = new Term();
				newterm.Parse(term, root);
				newterm.Parent = this;
				m_terms.Add(newterm);
			}
		}

		private string[] GetTerms(string allterms) 
		{ 
			int splitIndex = allterms.IndexOf(',');
			if (splitIndex < 0)
				return new string[] {allterms};
			
			char[] startChars = new char[] { '(','[', ',' };
			int start = 0;
			int len;
			List<string> result = new List<string>();
			while (start < allterms.Length)
			{
				int ss = allterms.IndexOfAny(startChars, start);
				if (ss < 0)
				{
					string s = allterms.Substring(start).Trim();
					if (s.Length > 0)
						result.Add(s);
					break;
				}
				if (allterms[ss] == ',')
				{
					// copy from start
					len = ss - start;
					string s = allterms.Substring(start, len).Trim();
					if (s.Length > 0)
						result.Add(s);
					start = ss+1;
					continue;
				}
				int termend = Term.FindMatchingEnd(allterms[ss], allterms, ss);
				len = termend - start+1;
				string su = allterms.Substring(start, len).Trim();
				if (su.Length > 0)
					result.Add(su);
				start = termend+1;
				ss = allterms.IndexOfAny(startChars, start);
				if (ss > 0)
					start = ss+1;
			}
			return result.ToArray();
		}


		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(m_func);
			sb.Append('(');
			for (int index = 0; index < m_terms.Count; index++)
            {
                sb.Append(m_terms[index].ToString());
                if (index < m_terms.Count - 1)
                    sb.Append(',');
			}
			sb.Append(')');
			return sb.ToString();
		}
	}
}
