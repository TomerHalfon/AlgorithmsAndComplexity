using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp.CustomLinkedLists
{
    /// <summary>
    /// This Is a custom circular dual Link linked list
    /// </summary>
    /// <typeparam name="T">The type of the node's data</typeparam>
    class CustomCircularDualLinkLinkedList<T>: IEnumerable<T>
    {
        CustomDuelLinkLinkedListNode<T> First { get; set; }
        private int _count;

        public int Count => _count;
        public CustomDuelLinkLinkedListNode<T> Last => First?.Previous;
        public CustomCircularDualLinkLinkedList(T start) => AddFirst(start);
        public CustomCircularDualLinkLinkedList() { }
        public void AddFirst(T data)
        {
            CustomDuelLinkLinkedListNode<T> newFirst = new CustomDuelLinkLinkedListNode<T>(data);
            if (First is null)
            {
                newFirst.Next = newFirst;
                newFirst.Previous = newFirst;
            }
            else
            {
                newFirst.Next = First;
                newFirst.Previous = First.Previous;
                First.Previous.Next = newFirst;
                First.Previous = newFirst;
            }
            First = newFirst;
            _count++;
        }
        public void AddLast(T data)
        {
            CustomDuelLinkLinkedListNode<T> newLast = new CustomDuelLinkLinkedListNode<T>(data)
            {
                Next = First,
                Previous = First.Previous 
            };
            First.Previous.Next = newLast;
            First.Previous = newLast;
            _count++;
        }
        public bool RemoveFirst(out T savedFirstValue)
        {
            savedFirstValue = default(T);
            if (First is null) return false;

            savedFirstValue = First.Data;
            if (First.Next == First) First = null;
            else
            {
                First.Next.Previous = First.Previous;
                First.Previous.Next = First.Next;
                if (First == First) First = First.Next;
            }
            _count--;
            return true;
        }
        public bool RemoveLast(out T savedLastValue)
        {
            savedLastValue = Last.Data;
            if (First is null) return false;

            savedLastValue = Last.Data;
            First.Previous = Last.Previous;
            return true;
        }
        #region IEnumrable
        public IEnumerator<T> GetEnumerator() => new CustomLinkedListEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region Enumerator
        class CustomLinkedListEnumerator : IEnumerator<T>
        {
            CustomCircularDualLinkLinkedList<T> _list;
            CustomDuelLinkLinkedListNode<T> _node;
            int _index;
            public T Current { get; private set; }
            public CustomLinkedListEnumerator(CustomCircularDualLinkLinkedList<T> list)
            {
                _list = list;
                _node = list.First;
                Current = default(T);
                _index = 0;
            }
            object IEnumerator.Current => _index == 0 || _index == _list.Count ? default(T) : Current;

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
                if (_node == _list.First)
                    _node = default(CustomDuelLinkLinkedListNode<T>);
                return true;
            }

            public void Reset()
            {
                Current = default(T);
                _node = _list.First;
                _index = 0;
            }
        } 
        #endregion
        #endregion
    }
}