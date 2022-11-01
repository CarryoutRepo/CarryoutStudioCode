using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.CBCTable
{
    public class CBCCells : IList<CBCCell>
    {
        private readonly IList<CBCCell> _cBCCells = new List<CBCCell>();

        public CBCCell this[int index] { get => _cBCCells[index]; set => _cBCCells[index] = value; }

        public int Count => _cBCCells.Count();

        public bool IsReadOnly => _cBCCells.IsReadOnly;

        public void Add(CBCCell item)
        {
            _cBCCells.Add(item: item);
        }

        public void Clear()
        {
            _cBCCells.Clear();
        }

        public bool Contains(CBCCell item)
        {
            return _cBCCells.Contains(item: item);
        }

        public void CopyTo(CBCCell[] array, int arrayIndex)
        {
            _cBCCells.CopyTo(array: array, arrayIndex: arrayIndex);
        }

        public IEnumerator<CBCCell> GetEnumerator()
        {
            return _cBCCells.GetEnumerator();
        }

        public int IndexOf(CBCCell item)
        {
            return _cBCCells.IndexOf(item: item);
        }

        public void Insert(int index, CBCCell item)
        {
            _cBCCells.Insert(index: index, item: item);
        }

        public bool Remove(CBCCell item)
        {
            return _cBCCells.Remove(item: item);
        }

        public void RemoveAt(int index)
        {
            _cBCCells.RemoveAt(index: index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cBCCells.GetEnumerator();
        }
    }
}
