using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.CBCTable
{
    public class CBCColumns : IList<CBCColumn>
    {
        public CBCColumn this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(CBCColumn item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(CBCColumn item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(CBCColumn[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<CBCColumn> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(CBCColumn item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, CBCColumn item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(CBCColumn item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}