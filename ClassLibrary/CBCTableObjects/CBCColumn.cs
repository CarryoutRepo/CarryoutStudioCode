using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCTableObjects
{
    public class CBCColumn
    {
        public string Name { get; set; } = "";
        public int Number { get; set; }
        public CBCDataTypes CBCDataType { get; set; }
        public CBCColumn(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}
