//Relevent Doc: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
using System;
using LinkedListsExamp.CustomLinkedLists;
using LinkedListsExamp.ClassLinkedList;

namespace LinkedListsExamp
{
    class Program
    {
        static string[] GetWords(int amount)
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
            customLinkedList.RemoveLast(out string savedLast);
            Console.WriteLine($"Removed {savedLast}");
            Console.WriteLine($"The last word is {customLinkedList.Last.Data}");
            Console.WriteLine($"The First Word is {customLinkedList.First.Data}");
            Console.WriteLine("Removing First");
            customLinkedList.RemoveFirst(out string savedFirst);
            Console.WriteLine($"Removed {savedFirst}");
            Console.WriteLine($"The First word is {customLinkedList.First.Data}");
        }
        static void TestClassLinkedList()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddLast("hello");
            list.AddLast("world");
            list.AddLast("it's");
            list.AddLast("me");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            //TestCustomCircularDualLinkLinkedList();
            //TestClassLinkedList();
            int number = 10;
            UpdateNumber(number, out number);
            Console.WriteLine(number);
        }
        static void UpdateNumber(int num, out int res)
        {
            res = num + 10;
        }
        static void UpdateIndex(ref int index, int step) => index += step;
        //static void UpdateNumber(int num)
        //{

        //}
        //static void UpdateNumber(int num)
        //{

        //}
    }
}