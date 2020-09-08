using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp.CustomLinkedLists
{
    class CustomLinkedListNode<T>
    {
        public T Data { get; set; }
        public CustomLinkedListNode<T> Next { get; set; }
        public CustomLinkedListNode<T> Previous { get; set; }

        public CustomLinkedListNode(T data)
        {
            Data = data;
        }
    }
}