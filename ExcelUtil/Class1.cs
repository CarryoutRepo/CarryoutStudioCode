
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;//

namespace ExcelUtil
{
    public class Class1
    {
        //public static DataTable ExcelToDataTable(string fileName) //test
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

        //public static string ReadData(int rowNumber, string columnName)
        //{
        //    try
        //    {
        //        //Retrieving Data using LINQ
        //        string data = (from colData in dataCol
        //                       where colData.colName == columnName && colData.rowNumber == rowNumber
        //                       select colData.colValue).SingleOrDefault();

        //        //var data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
        //        return data.ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        e.Message.ToString();
        //        return null;
        //    }
        //}

        //private static void mytest()
        //{
        //    string itemNo = ExcelUtil.ReadData(1, "Item");
        //}

        //public IExcelDataReader getExcelReader()
        //{
        //    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
        //    // to get started. This is how we avoid dependencies on ACE or Interop:
        //    FileStream stream = File.Open(_path, FileMode.Open, FileAccess.Read);

        //    // We return the interface, so that
        //    IExcelDataReader reader = null;
        //    try
        //    {
        //        if (_path.EndsWith(".xls"))
        //        {
        //            reader = ExcelReaderFactory.CreateBinaryReader(stream);
        //        }
        //        if (_path.EndsWith(".xlsx"))
        //        {
        //            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //        }
        //        return reader;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<string> getWorksheetNames()
        //{
        //    var reader = this.getExcelReader();
        //    var workbook = reader.AsDataSet();
        //    var sheets = from DataTable sheet in workbook.Tables select sheet.TableName;
        //    return sheets;
        //}

        //public IEnumerable<DataRow> getData(string sheet, bool firstRowIsColumnNames = false)
        //{
        //    var reader = this.getExcelReader();
        //    reader.IsFirstRowAsColumnNames = firstRowIsColumnNames;
        //    var workSheet = reader.AsDataSet().Tables[sheet];
        //    var rows = from DataRow a in workSheet.Rows select a;
        //    return rows;
        //}

    }
}