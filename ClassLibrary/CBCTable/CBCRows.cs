using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.CBCTable
{
    public class CBCRows : IList<CBCRow>
    {
        private readonly IList<CBCRow> _cBCRows = new List<CBCRow>();

        public CBCRow this[int index] { get => _cBCRows[index]; set => _cBCRows[index] = value; }

        public int Count => _cBCRows.Count();

        public bool IsReadOnly => _cBCRows.IsReadOnly;

        public void Add(CBCRow item)
        {
            _cBCRows.Add(item: item);
        }        
        public void Clear()
        {
            _cBCRows.Clear();
        }
        public bool Contains(CBCRow item)
        {
            return _cBCRows.Contains(item: item);
        }

        public void CopyTo(CBCRow[] array, int arrayIndex)
        {
            _cBCRows.CopyTo(array: array, arrayIndex: arrayIndex);
        }

        public IEnumerator<CBCRow> GetEnumerator()
        {
            return _cBCRows.GetEnumerator();
        }

        public int IndexOf(CBCRow item)
        {
            return _cBCRows.IndexOf(item: item);
        }

        public void Insert(int index, CBCRow item)
        {
            _cBCRows.Insert(index: index, item: item);
        }

        public bool Remove(CBCRow item)
        {
            return _cBCRows.Remove(item: item);
        }

        public void RemoveAt(int index)
        {
            _cBCRows.RemoveAt(index: index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cBCRows.GetEnumerator();
        }
    }
}
