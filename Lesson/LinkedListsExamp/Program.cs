//Relevent Doc: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
using System;
using LinkedListsExamp.CustomLinkedLists;
using System.Collections.Generic;

namespace LinkedListsExamp
{
    class Program
    {
       static string [] GetWords(int amount)
        {
            string[] res = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.Write($"Add Word {i + 1}: ");
                res[i] = Console.ReadLine();
            }
            return res;
        }
       static void TestCustomCircularDualLinkLinkedList()
        {
            CustomCircularDualLinkLinkedList<string> customLinkedList = new CustomCircularDualLinkLinkedList<string>();
            Console.WriteLine("Created a new Circular Dual Link LinkedList");
            Console.WriteLine("Adding Words by AddFirst(word)");
            foreach (string word in GetWords(3))
            {
                customLinkedList.AddFirst(word);
            }
            Console.WriteLine("The Words:");
            foreach (var item in customLinkedList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\nAdding Words by AddLast(word)");
            foreach (string word in GetWords(3))
            {
                customLinkedList.AddLast(word);
            }
            Console.WriteLine("The Words:");
            foreach (var item in customLinkedList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"The last word is {customLinkedList.Last.Data}");
            Console.WriteLine("Removing last");
            customLinkedList.RemoveLast(out string savedlast);
            Console.WriteLine($"Removed {savedlast}");
            Console.WriteLine($"The last word is {customLinkedList.Last.Data}");
        }
        static void Main(string[] args)
        {
            TestCustomCircularDualLinkLinkedList();
        }
    }
}