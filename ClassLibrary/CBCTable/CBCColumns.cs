using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary.CBCOverride;

namespace ClassLibrary.CBCTable
{
    public class CBCColumns : IList<CBCColumn>
    {
        private readonly IList<CBCColumn> _cBCColumns = new List<CBCColumn>();

        public CBCColumn this[int index] { get => _cBCColumns[index]; set => _cBCColumns[index] = value; }

        public int Count => _cBCColumns.Count();

        public bool IsReadOnly => _cBCColumns.IsReadOnly;

        public void Add(CBCColumn item)
        {
            _cBCColumns.Add(item: item);
        }

        public void Clear()
        {
            _cBCColumns.Clear();
        }

        public bool Contains(CBCColumn item)
        {
            return _cBCColumns.Contains(item: item);
        }

        public void CopyTo(CBCColumn[] array, int arrayIndex)
        {
            _cBCColumns.CopyTo(array: array, arrayIndex: arrayIndex);
        }

        public IEnumerator<CBCColumn> GetEnumerator()
        {
            return _cBCColumns.GetEnumerator();
        }

        public int IndexOf(CBCColumn item)
        {
            return _cBCColumns.IndexOf(item: item);
        }

        public void Insert(int index, CBCColumn item)
        {
            _cBCColumns.Insert(index: index, item: item);
        }

        public bool Remove(CBCColumn item)
        {
            return _cBCColumns.Remove(item: item);
        }

        public void RemoveAt(int index)
        {
            _cBCColumns.RemoveAt(index: index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cBCColumns.GetEnumerator();
        }
    }
}