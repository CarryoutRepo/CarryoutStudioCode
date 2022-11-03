using ClassLibrary.CBCTableObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCDataObjects
{
    public static class Transformations
    {
        public static Items TransformCBCellsToItems(CBCTable cbcTable)
        {
            Items items = new();
            foreach (CBCRow cbcRow in cbcTable.CBCRows)
            {
                Item item = new(sku: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "SKU")),
                                description: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "Description")),
                                shortDescription: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "ShortDescription")),
                                size: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "Size")),
                                cbcCode: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "CBCCode")),
                                note: cbcTable.GetStringValue(cbcRow, GetCBCColumnByName(cbcTable: cbcTable, name: "Note")));
                items.AddNew(item);
            }
            return items;
        }
        private static CBCColumn GetCBCColumnByName(CBCTable cbcTable, string name)
        {
            return (CBCColumn)cbcTable.CBCColumns.First(c => c.Name == name);
        }
    }
}
