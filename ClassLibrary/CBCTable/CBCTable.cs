using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCTable
{
    public class CBCTable : CBCTableBase
    {
        public CBCColumns CBCColumns { get; set; } = new ();
        public CBCRows CBCRows { get; set; } = new ();
        public CBCCells CBCCells { get; set; } = new ();

        public object? GetValue(CBCRow cBCRow, CBCColumn cBCColumn)
        {
            object? returnValue = null;
            return returnValue;
        }

    }
}
