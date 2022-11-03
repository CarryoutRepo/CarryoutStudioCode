using System;
using System.CodeDom;
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
using ClassLibrary.CBCTableObjects;
using ClassLibrary.CBCDataObjects;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace CBCDashboardWPF.CBCExcel
{
    public static class Util
    {
        private const string ItemsWorksheetName = "Items";
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
                if (result == true)
                {
                    application = new Application();
                    application.Visible = false;
                    fileName = dialog.FileName;
                    application.Workbooks.Open(Filename: fileName, ReadOnly: true);
                    workbook = application.Workbooks[1];
                    Worksheet worksheet = workbook.Worksheets[ItemsWorksheetName];
                    CBCTable? cbcTable = GetItemsTable(worksheet);
                    if (cbcTable != null)
                    {
                        Items items = Transformations.TransformCBCellsToItems(cbcTable);
                    }
                    if (cbcTable == null)
                    {
                        throw new Exception("Unable to Get Items Table from Worksheet.");
                    }
                    string newFilename = fileName.Replace(".xlsx", "") + " (Converted)" + ".xls";
                    workbook.SaveAs2(Filename: newFilename, FileFormat: XlFileFormat.xlWorkbookDefault);
                    if (cbcTable != null)
                    {
                        MessageBox.Show("Success!", "Carryout By Chrislyn", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Reading Worksheet", "Carryout By Chrislyn", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
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
        public static CBCTable? GetItemsTable(Worksheet worksheet)
        {
            CBCTable? returnCBCTable = null;
            try
            {
                ListObject listObject = worksheet.ListObjects[1];

                CBCTable cbcTable = new();
                foreach (ListColumn listColumn in listObject.ListColumns)
                {
                    CBCColumn cbcColumn = new(number: listColumn.Index, name: listColumn.Name);
                    cbcTable.CBCColumns.Add(cbcColumn);
                }
                for (int rowIndex = 2; rowIndex <= listObject.ListRows.Count + 1; rowIndex++)
                {
                    CBCRow cbcRow = new(rowIndex - 1);
                    cbcTable.CBCRows.Add(cbcRow);
                    foreach (CBCColumn cbcColumn in cbcTable.CBCColumns)
                    {
                        var value = worksheet.Cells[rowIndex, cbcColumn.Number].Value2;
                        CBCCell cbcCell = new(cbcRow: cbcRow,
                                                cbcColumn: cbcColumn,
                                                value: value);
                        cbcTable.CBCCells.Add(cbcCell);
                    }
                }
                returnCBCTable = cbcTable;
            }
            catch (Exception)
            {
                throw;
            }
            return returnCBCTable;
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
