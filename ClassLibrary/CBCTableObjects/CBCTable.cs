using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCTableObjects
{
    public class CBCTable
    {
        public CBCColumns CBCColumns { get; set; } = new();
        public CBCRows CBCRows { get; set; } = new();
        public CBCCells CBCCells { get; set; } = new();
        public dynamic? GetValue(CBCRow cbcRow, CBCColumn cbcColumn)
        {
            return (from cell in CBCCells
                    where cell.CBCRow.Number == cbcRow.Number
                         where cell.CBCColumn.Number == cbcColumn.Number
                         select cell.Value).SingleOrDefault();
        }
        public string? GetStringValue(CBCRow cbcRow, CBCColumn cbcColumn)
        {
            //return (string?)GetValue(cbcRow, cbcColumn);
            string? returnValue =  null;
            dynamic? getValue = GetValue(cbcRow, cbcColumn);
            if (getValue != null)
            {
                returnValue = Convert.ToString(getValue);
            }
            return returnValue;
        }
        public int? GetIntValue(CBCRow cbcRow, CBCColumn cbcColumn)
        {
            return (int?)GetValue(cbcRow, cbcColumn);

            //dynamic? testReturnValue = GetValue(cbcRow, cbcColumn);
            //int? returnValue = null;
            //if (testReturnValue != null)
            //{
            //    returnValue = (int)testReturnValue;
            //}
            //return returnValue;
        }
        public DateTime? GetDateValue(CBCRow cbcRow, CBCColumn cbcColumn)
        {
            dynamic? returnValue = GetValue(cbcRow, cbcColumn);

            if (returnValue != null)
            {
                //DateTime((string?)returnValue, out DateTime getDateTimeValue))
                //if 
                //throw new Exception("Return Value for GetValueInt is not a DateTime.");
                return null;
            }
            return returnValue;
        }

    }
}
