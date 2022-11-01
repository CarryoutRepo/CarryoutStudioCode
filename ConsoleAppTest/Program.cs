using System;
using System.Data.Common;
using ClassLibrary;
using ClassLibrary.CBCTable;
using ClassLibrary.CBCData;
using System.Configuration;
using ClassLibrary.CBCDataObjects;

//using ClassLibrary.CBCOverride;

// See https://aka.ms/new-console-template for more information


//string thisEnv = Properties.Settings.Default.RuntimEnv;

//string thisEnv = System.Configuration.Assemblies.AssemblyVersionCompaif(thisEnv == “Release”);
//System.Drawing

//#if DEBUG
    const string fileName = @"/Users/JohnMewesAccount/Library/CloudStorage/OneDrive-Personal/JM Documents/StudioCode/ConsoleAppTest/TestData.csv";
//#endif

//ConsoleAppTest.ClassTestSomething.DoSomething();
//CBCDataSet.MakeDataTables();
//return;

CBCDataSet cBCDataSet = new();

//foreach (var line in System.IO.File.ReadLines(fileName))
//{ 
//    var values = line.Split(',');
//    for (int index = 0; index <= values.GetUpperBound(dimension: 0); index++)
//    {
//        int col = index + 1;

//        if (cBCRow == null)
//        {
//            cBCTable.CBCColumns.Add(new(number: col, name: values[index]));
//        }
//        else
//        {
//            cBCTable.CBCCells.Add(new(cBCRow: cBCRow, cBCColumn: cBCTable.CBCColumns[index], value: (object)values[index]));
//        }
//    };
//    row++;
//    cBCRow = new(number: row);
//        cBCTable.CBCRows.Add(cBCRow);
//}
Console.WriteLine("Program Finished.");

