using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using ClassLibrary;
using ClassLibrary.CBCTable;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace CBCDashboardWPF.Excel
{
    public class CBCExcel
    {
        public static string OpenWorkbook(string caption)
        {
            Application? application = null;
            Workbook? workbook = null;
            string fileName = string.Empty;

            try
            {
                
                var dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.Title = caption;
                dialog.FileName = "";
                dialog.DefaultExt = ".xls*";
                dialog.Filter = "All Excel Files|*.xls*";
                bool? result = dialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    application = new Application();
                    application.Visible = false;

                    fileName = dialog.FileName;
                    application.Workbooks.Open(fileName);
                    workbook = application.Workbooks[1];
                    Worksheet worksheet = workbook.Worksheets[1];
                    GetTable(worksheet);

                    //TODO: put dialog box here
                    string newFilename = fileName.Replace(".xlsx", "") + " (Converted)" + ".xls";
                    workbook.SaveAs2(Filename: newFilename, FileFormat: XlFileFormat.xlWorkbookDefault);

                    MessageBox.Show("Success!", "Carryout By Chrislyn", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            finally
            { 
                if (workbook != null)                  
                {
                    workbook.Close(false);
                }
                if (application != null)
                {
                    application.Quit();
                }
            }

            return fileName;
        }

        public static void GetTable(Worksheet worksheet)
        {
            if (worksheet.ListObjects.Count > 1)
            {
                throw new Exception("There are too many tables in the first worksheet.");
            }
            CBCTable cBCTable = new CBCTable();

            foreach (ListObject listObject in worksheet.ListObjects)
            {
                MessageBox.Show(messageBoxText: listObject.Name);
                foreach (ListColumn listColumn in listObject.ListColumns)
                {
                    CBCColumn cBCColumn = new(number: listColumn.Index, name: listColumn.Name);
                    cBCTable.CBCColumns.Add(cBCColumn);
                }
                foreach (ListRow listRow in listObject.ListRows)
                {
                    CBCRow cBCRow = new(listRow.Index);
                    cBCTable.CBCRows.Add(cBCRow);
                }
        
                for (int row = 1; row <= listObject.ListRows.Count; row++)
                {
                    CBCRow cBCRow = cBCTable.CBCRows[row];
                    for (int col = 0; col < listObject.ListColumns.Count; col++)
                    {
                        CBCColumn cBCColumn = cBCTable.CBCColumns[col];
                        CBCCell cBCCell = new(cBCRow, cBCColumn, worksheet.Cells[row, col].Value);
                        cBCTable.CBCCells.Add(cBCCell);
                    }
                }
            }
        }

        //public static DataTable ExcelToDataTable(string fileName)
        //{
        //    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    excelReader.IsFirstRowAsColumnNames = true;
        //    DataSet result = excelReader.AsDataSet();
        //    DataTableCollection table = result.Tables;
        //    DataTable? resultTable = table["Sheet1"];

        //    return resultTable;
        //}
        //public static List<Datacollection> dataCol = new List<Datacollection>();

        //public static void PopulateInCollection(string fileName)
        //{
        //    DataTable table = ExcelToDataTable(fileName);
        //    //Iterate through all the rows and columns of the Table
        //    for (int row = 1; row <= table.Rows.Count; row++)
        //    {
        //        for (int col = 0; col < table.Columns.Count; col++)
        //        {
        //            Datacollection dtTable = new Datacollection()
        //            {
        //                rowNumber = row,
        //                colName = table.Columns[col].ColumnName,
        //                colValue = table.Rows[row - 1][col].ToString()
        //            };
        //            //Add all the details for each row
        //            dataCol.Add(dtTable);
        //        }
        //    }
        //}

        //public static string? ReadData(int rowNumber, string columnName)
        //{
        //    try
        //    {
        //        //Retrieving Data using LINQ
        //        string? data = (from colData in dataCol
        //                       where colData.colName == columnName && colData.rowNumber == rowNumber
        //                       select colData.colValue).SingleOrDefault();

        //        //var data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;

        //        return data;
        //    }
        //    catch (Exception e)
        //    {
        //        e.Message.ToString();
        //        return null;
        //    }
        //}
    }
}