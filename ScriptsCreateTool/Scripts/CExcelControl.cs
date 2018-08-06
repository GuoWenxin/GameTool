using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSExcel=Microsoft.Office.Interop.Excel;
namespace GameTools
{
    class CExcelControl:CSingleton<CExcelControl>
    {
        public MSExcel.Application OpenExcel()
        {
            try
            {
                MSExcel.Application app = new MSExcel.ApplicationClass();
                return app;
            }
            catch (Exception e)
            {
                Debug.Log(string.Format("{0}", e.Message),3);
                return null;
            }
            
            
        }

        public void CloseExcel(MSExcel.Application app)
        {
            app.Quit();
        }
        public  void CreateExcelFile(MSExcel.Application app,string FileName,string sheetName,string fileExplain, List<string[]> heads, List<string[]> cells)
        {
            if (sheetName.Length > 31)
            {
                Debug.Log(string.Format("表{0}名称长度大于31",sheetName),3);
                return;
            }
            //create  
            object Nothing = System.Reflection.Missing.Value;
            //MSExcel.Application app = new MSExcel.ApplicationClass();
            app.Visible = false;
            MSExcel.Workbook workBook = app.Workbooks.Add(Nothing);
            MSExcel.Worksheet worksheet = (MSExcel.Worksheet)workBook.Sheets[1];
            worksheet.Name = sheetName;
            MSExcel.Range myRange = worksheet.get_Range(worksheet.Cells[1,1],worksheet.Cells[cells.Count+5, heads.Count]);
            //MSExcel.Range myRange = worksheet.get_Range(worksheet.Cells);
            myRange.NumberFormatLocal = "@";
            //headline  
            /*worksheet.Cells[1, 1] = "FileName";
            worksheet.Cells[1, 2] = "FindString";
            worksheet.Cells[1, 3] = "ReplaceString";*/
            worksheet.Cells[4, 1] = fileExplain;
            int keyNum = 1;
            for (int i = 0; i < heads.Count; i++)
            {
                if (heads[i][2]=="PRI")
                {
                    worksheet.Cells[1, i+1] = keyNum;
                    keyNum++;
                }
                else
                {
                    worksheet.Cells[1, i + 1] = " ";
                }
                worksheet.Cells[2, i+1] = heads[i][0];
                worksheet.Cells[3, i+1] = heads[i][1];
                worksheet.Cells[5, i+1] = heads[i][3];
            }
            int index = 0;
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    worksheet.Cells[6+i, j+1] = cells[i][j];
                }
                float x = (float)i/cells.Count;
                if ((x * 10)>index)
                {
                    Debug.Log( string.Format("写入{1}数据完成{0}%", x * 100, sheetName));
                    index++;
                }
            }
            if (File.Exists(FileName))
            {
                Debug.Log(string.Format("{0}文件已存在，已被重新生成",sheetName));
                File.Delete(FileName);
            }
            worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSExcel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            //app.Quit();
            Debug.Log(string.Format("{0}文件生成完成", sheetName));
        }
        public void WriteToExcel(string excelName, string filename, string findString, string replaceString)
        {
            //open  
            object Nothing = System.Reflection.Missing.Value;
            var app = new MSExcel.Application();
            app.Visible = false;
            MSExcel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            MSExcel.Worksheet mysheet = (MSExcel.Worksheet)mybook.Worksheets[1];
            mysheet.Activate();
            //get activate sheet max row count  
            int maxrow = mysheet.UsedRange.Rows.Count + 1;
            mysheet.Cells[maxrow, 1] = filename;
            mysheet.Cells[maxrow, 2] = findString;
            mysheet.Cells[maxrow, 3] = replaceString;
            mybook.Save();
            mybook.Close(false, Type.Missing, Type.Missing);
            mybook = null;
            //quit excel app  
            app.Quit();
        }
    }
}
