/********************************
 *    Class Code From Katya     *
 ********************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp.ClassLinkedList
{
    #region Katya's code
   public class LinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T data;
            public Node next;

            public Node(T data)
            {
                this.data = data;
                next = null;
            }
        }
        public Node Start { get; private set; }
        Node end;

        public void AddFirst(T val) //O(1)
        {
            Node n = new Node(val);
            n.next = Start;
            Start = n;
            if (end == null) end = n;
        }

        public bool RemoveFirst(out T saveFirstValue) //O(1)
        {
            saveFirstValue = default(T);
            if (Start == null) return false;

            saveFirstValue = Start.data;
            Start = Start.next;
            if (Start == null) end = null; //for removing single (last) item

            return true;
        }

        public void AddLast(T val) //O(1) !!!!!
        {
            if (Start == null)
            {
                AddFirst(val);
                return;
            }
            Node n = new Node(val);
            end.next = n;
            end = n;
        }

        //public bool RemoveLast(out string saveFirstValue)//O(n)
        //{

        //}

        public void AddLast_badVersion(T val) //O(n)
        {
            if (Start == null)
            {
                AddFirst(val);
                return;
            }

            Node tmp = Start;

            while (tmp.next != null) //stop at the last node
            {
                tmp = tmp.next;
            }
            Node n = new Node(val);
            tmp.next = n;
        }

        public override string ToString() //O(n)
        {
            StringBuilder sb = new StringBuilder();
            Node tmp = Start;

            while (tmp != null)
            {
                sb.AppendLine(tmp.data.ToString());
                tmp = tmp.next;
            }

            return sb.ToString();
        }
        #endregion
        public IEnumerator<T> GetEnumerator()
        {
            //return new LinkedListEnumerator1(Start);
            //return new LinkedListEnumerator2(Start);

            //Using The yield keyword
            for (Node currentNode = Start; currentNode != null; currentNode = currentNode.next) yield return currentNode.data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Enumerator option 1 (add a private set to Current)
        class LinkedListEnumerator1 : IEnumerator<T>
        {
            readonly Node _start;
            Node _indexNode;
            public LinkedListEnumerator1(Node start)
            {
                this._start = start;
                Reset();
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_indexNode != null)
                {
                    Current = _indexNode.data;
                    _indexNode = _indexNode.next;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _indexNode = _start;
                Current = default(T);
            }
        }
        #endregion
        #region Enumerator option 2 shown in class (add a bool value for first iteration)
        class LinkedListEnumerator2 : IEnumerator<T>
        {
            Node _start, _currentNode;
            bool isFirstTime;
            public LinkedListEnumerator2(Node start)
            {
                _start = start;
                Reset();
            }

            public T Current => _currentNode.data;

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_currentNode == null) return false;
                if (isFirstTime)
                {
                    isFirstTime = false;
                    return true;
                }
                _currentNode = _currentNode.next;
                if (_currentNode == null) return false;
                return true;
            }

            public void Reset()
            {
                _currentNode = _start;
                isFirstTime = true;
            }
        }
        #endregion
    }
}
