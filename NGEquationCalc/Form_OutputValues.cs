using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace NGEquationCalc
{
    public partial class Form_OutputValues : Form
    {
        Dictionary<string, EquationInformation> m_Dictionary_UsedEquationInfo;
        DataTable _dataTable;
        string programpath;
        public Form_OutputValues(Dictionary<string,EquationInformation> pDictionary_UsedEquationInfo)
        {
            InitializeComponent();
            m_Dictionary_UsedEquationInfo = pDictionary_UsedEquationInfo;
            InitialViewer();
            programpath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            
            
        }

        private void InitialViewer()
        {
            DataRow rows;
            _dataTable = new DataTable("InOutValues");
            DataColumn c1 = new DataColumn("분류");
            DataColumn c2 = new DataColumn("명칭");
            DataColumn c3 = new DataColumn("변수명");
            DataColumn c4 = new DataColumn("저장값");
            DataColumn c5 = new DataColumn("타입");            
            
            _dataTable.Columns.Add(c1);
            _dataTable.Columns.Add(c2);
            _dataTable.Columns.Add(c3);
            _dataTable.Columns.Add(c4);
            _dataTable.Columns.Add(c5);
            
            foreach( var Pair in m_Dictionary_UsedEquationInfo )
            {
                var _key = Pair.Key;
                var _val = Pair.Value;
                
                string[] category_and_data = _key.Split(':');
                int index = 0;
                foreach (var dictionary in _val.m_Dictionary_Equation)
                {
                    
                    if( dictionary.Value.IsHiddenVariable == false)
                    {
                        rows = _dataTable.NewRow();
//                         if( index == 0 )
//                         {
//                             rows["분류"] = category_and_data[0];
//                             rows["명칭"] = category_and_data[1];
//                         }
//                         else
//                         {
//                             rows["분류"] = "";
//                             rows["명칭"] = "";
//                         }
                        rows["분류"] = category_and_data[0];
                        rows["명칭"] = category_and_data[1];
                        rows["변수명"] = dictionary.Key;
                        rows["저장값"] = dictionary.Value.Value;
                        rows["타입"] = dictionary.Value.GetType();
                        _dataTable.Rows.Add(rows);
                    }
                    index++;
                }
            }
            dataGridView_Values.DataSource = _dataTable;
            
            
        }

        private void btn_SaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var wb = new XLWorkbook();
                DateTime saveTime = new DateTime();
                saveTime = DateTime.Now;
                string strSheet = saveTime.ToString("yyyyMMdd-HHmmss");
                string strFileName = "PBN결과값(" + strSheet + ")";

                //Console.WriteLine(strFileName);


                //저장위치... 선택
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "파일 저장";
                dlg.FileName = strFileName;
                dlg.DefaultExt = "xlsx";
                string firstURL = Application.StartupPath + "\\Data";
                dlg.InitialDirectory = firstURL;
                dlg.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //시트이름
                    var ws = wb.Worksheets.Add((DataTable)dataGridView_Values.DataSource);
                    //wb.SaveAs("C:\\" + strFileName + ".xlsx");
                    wb.SaveAs(dlg.FileName);
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("파일저장 실패 : " + error.ToString());
            }



            
            

        }
        
    }
}
