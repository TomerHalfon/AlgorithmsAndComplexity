using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp.CustomLinkedLists
{
    class CustomDuelLinkLinkedListNode<T>
    {
        public T Data { get; set; }
        public CustomDuelLinkLinkedListNode<T> Next { get; set; }
        public CustomDuelLinkLinkedListNode<T> Previous { get; set; }

        public CustomDuelLinkLinkedListNode(T data)
        {
            Data = data;
        }
    }
}