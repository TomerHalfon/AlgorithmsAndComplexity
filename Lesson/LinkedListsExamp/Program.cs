//Relevent Doc: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
using System;
using LinkedListsExamp.CustomLinkedLists;
using System.Collections.Generic;

namespace LinkedListsExamp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomCircularDualLinkLinkedList<string> customLinkedList = new CustomCircularDualLinkLinkedList<string>();
            Console.WriteLine($"The last: {customLinkedList.Last}");
            customLinkedList.AddFirst("Tomer");
            customLinkedList.AddFirst("Me");
            customLinkedList.AddFirst("It's");
            customLinkedList.AddFirst("World");
            customLinkedList.AddFirst("Hello");
            foreach (var item in customLinkedList)
            {
                Console.WriteLine(item);
            }
            customLinkedList.RemoveFirst(out string savedFirstValue);
            Console.WriteLine($"Deleted {savedFirstValue}");
            foreach (var item in customLinkedList)
            {
                Console.WriteLine(item);
            }
            customLinkedList.AddLast("Last");
            foreach (var item in customLinkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"The last: {customLinkedList.Last.Data}");
        }
    }
}