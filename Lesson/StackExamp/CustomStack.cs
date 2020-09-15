using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListsExamp.ClassLinkedList;

namespace StackExamp
{
    /// <summary>
    /// With an inner array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArrayStack<T> : IEnumerable<T>
    {
        int _index = 0;
        T[] _innerArray;
        bool IsFull => _index == _innerArray.Length;
        bool IsEmpty => _index == 0;
        public ArrayStack(int capacity)
        {
            _innerArray = new T[capacity];
            _index = 0;
        }
        public bool Push(T value)
        {
            if (IsFull) return false;
            _innerArray[_index++] = value;
            return true;
        }

        public bool Pop(out T value)
        {
            if (IsEmpty)
            {
                value = default(T);
                return false;
            }
            value = _innerArray[--_index];
            return true;
        }
        public bool Peek(out T value)
        {
            if (IsEmpty)
            {
                value = default(T);
                return false;
            }
            value = _innerArray[_index - 1];
            return true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = _index - 1; i >= 0; i--) sb.Append($"{_innerArray[i]} ");
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _index - 1; i >= 0; i--) yield return _innerArray[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class LinkedListStack<T>
    {
        LinkedListsExamp.ClassLinkedList.LinkedList<T> _innerList = new LinkedListsExamp.ClassLinkedList.LinkedList<T>();
        public void Push(T value) => _innerList.AddFirst(value);
        public T Pop()
        {
            _innerList.RemoveFirst(out T res);
            return res;
        }
        public T Peek() => _innerList.Start.data;
    }
}
