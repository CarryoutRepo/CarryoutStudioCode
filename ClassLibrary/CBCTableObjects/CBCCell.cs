using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCTableObjects
{ 
    public class CBCCell
    {
        public CBCColumn CBCColumn { get; set; }
        public CBCRow CBCRow { get; set; }
        public dynamic? Value { get; set; }

        public CBCCell(CBCRow cbcRow, CBCColumn cbcColumn, dynamic? value)
        {
            CBCRow = cbcRow;
            CBCColumn = cbcColumn;
            Value = value;
        }
    }
}
