using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp.CustomLinkedList
{
    class CustomLinkedList<T>: IEnumerable<T>
    {
        CustomLinkedListNode<T> First { get; set; }
        CustomLinkedListNode<T> Last { get; set; }
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public CustomLinkedList(T start)
        {
            First = new CustomLinkedListNode<T>(start);
            Last = null;
            _count = 1;
        }
        public CustomLinkedList()
        {
            First = null;
            Last = null;
            _count = 0;
        }
        public void AddFirst(T data)
        {
            CustomLinkedListNode<T> newFirst = new CustomLinkedListNode<T>(data) { Next = First };
            First = newFirst;
            _count++;
        }
        public bool RemoveFirst(out T savedFirstValue)
        {
            savedFirstValue = default;
            if (First == null) return false;
            savedFirstValue = First.Data;
            First = First.Next;
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomLinkedListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class CustomLinkedListEnumerator : IEnumerator<T>
        {
            CustomLinkedList<T> _list;
            CustomLinkedListNode<T> _node;
            int _index;
            public T Current { get; private set; }
            public CustomLinkedListEnumerator(CustomLinkedList<T> list)
            {
                _list = list;
                _node = list.First;
                Current = default;
                _index = 0;
            }
            object IEnumerator.Current => _index == 0 || _index == _list.Count ? default : Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_node == null)
                {
                    _index = _list.Count;
                    return false;
                }

                _index++;
                Current = _node.Data;
                _node = _node.Next;
                return true;
            }

            public void Reset()
            {
                Current = default;
                _node = _list.First;
                _index = 0;
            }
        }
    }
}
