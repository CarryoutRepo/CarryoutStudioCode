using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//comment

namespace ClassLibrary.CBCTable
{

    public class CBCCell
    {
        public CBCColumn? CBCColumn { get; set; }
        public CBCRow? CBCRow { get; set; }
        public object? Value { get; set; }

        public CBCCell(CBCRow cBCRow, CBCColumn cBCColumn, object value)
        {
            CBCRow = cBCRow;
            CBCColumn = cBCColumn;
            Value = value;
        }
    }
}
