using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public interface ILinkedListADT<T>
    {
        void Prepend(T item);
        void Append(T item);
        void RemoveAt(int index);
        void RemoveFirst();
        void RemoveLast();
        void InsertAt(int index, T item);
        void Replace(int index, T item);
        T GetAt(int index);
        int IndexAt(T item);
        bool Contains(T item);
        void Clear();
        int Count();
        void Reverse();
    }


}
