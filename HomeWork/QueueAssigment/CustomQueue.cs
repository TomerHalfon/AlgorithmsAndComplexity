using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueAssigment
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        T[] _innerArray;
        int _first, _last;

        bool IsEmpty => _first == -1;
        bool IsFull => _first == _last && !IsEmpty;
        public int Capacity => _innerArray.Length;

        //How we treverse the inner array (circular)
        void MoveIndex(ref int index) => index = (index + 1) % _innerArray.Length;

        public ArrayQueue(int capacity)
        {
            _innerArray = new T[capacity];
            _first = _last = -1;
        }
        
        public bool DeQueue(out T removedValue)
        {
            removedValue = default(T);
            if (IsEmpty) return false;

            removedValue = _innerArray[_first];
            MoveIndex(ref _first);

            if (_first == _last) _first = _last = -1;
            return true;
        }
        public bool EnQueue(T value)
        {
            if (IsFull) return false;
            if (IsEmpty) _first = _last = 0;

            _innerArray[_last] = value;
            MoveIndex(ref _last);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = _first;
            //because of the yield keyword this 'if' statement will only be checked the first time
            if (i == _last && i != -1)
            {
                yield return _innerArray[i];
                MoveIndex(ref i);
            }
            for (; i != _last; MoveIndex(ref i)) yield return _innerArray[i];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
