//Relevent Doc: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
using System;
using LinkedListsExamp.CustomLinkedList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsExamp
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
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
        }
    }
}