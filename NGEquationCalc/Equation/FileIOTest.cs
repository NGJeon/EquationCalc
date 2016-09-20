using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NGEquationCalc.Equation
{
    class FileIOTest
    {
        public void UnitTest()
        {

        }
    }

    class FileIO
    {
        public Dictionary<string, EquationInformation> test = new Dictionary<string, EquationInformation>();
        public void SaveFile(Dictionary<string,EquationInformation> savefile)
        {
            try
            {
                FileStream stream = new FileStream("test.dat", FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, savefile);
                formatter.Serialize(stream, "여러가지 데이터 테스트");
                stream.Close();
            }
            catch(Exception e )
            {
               // Console.Write(e.Message);
            }            

        }

        public void LoadFile()
        {
            FileStream stream = new FileStream("test.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            var test2 = formatter.Deserialize(stream) as Dictionary<string, EquationInformation>;
            var test3 = formatter.Deserialize(stream) as string;
            foreach( var a in test2.Values )
            {
                foreach( var b in a.m_Dictionary_Equation.Values )
                {
                    if( b is EquationVariable )
                    {
                        //MainForm.m_LogWindow.WriteLog("Name : " + b.Name + " Equation: " + ((EquationVariable)b).Equation);
                    }
                }
            }

          //  MainForm.m_LogWindow.WriteLog(test3);
        }

        public FileIO()
        {
           
        }
    }
}
