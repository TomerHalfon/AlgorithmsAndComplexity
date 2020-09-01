using System;
using System.Collections.Generic;

namespace SortsExamp
{
    class Program
    {
        static void Print<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static int[] GetArrayOfRngs(int amount)
        {
            Random rng = new Random();
            int[] res = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                res[i] = rng.Next(amount*2);
            }
            return res;
        }
        static int GetNumFromUser(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!\nTry again...");
            }
            return num;
        }

        static void TestTheSpeedOfQuickSort()
        {
            int size = GetNumFromUser("How many numbers to sort => ");
            int[] array = GetArrayOfRngs(size);
            Console.WriteLine($"Sorting {size:n0} numbers");
            Console.WriteLine($"Starting the first sort...");

            DateTime startTime = DateTime.Now;
            Sorts.QuickSort(array);
            TimeSpan firstSort = DateTime.Now - startTime;
            Console.WriteLine($"Finished the first sort => {firstSort.TotalMilliseconds}(in milliseconds)");

            Console.WriteLine("Starting the second sort");
            startTime = DateTime.Now;
            Sorts.ImprovedRearrangeQuickSort(array);
            //Sorts.QuickSort(array);
            TimeSpan secondSort = DateTime.Now - startTime;
            Console.WriteLine($"Finished the second sort => {secondSort.TotalMilliseconds}(in milliseconds)");
        }
        static void Main()
        {
            // TestTheSpeedOfQuickSort();
            int size = GetNumFromUser("How many numbers to sort => ");
            int[] array = GetArrayOfRngs(size);
            Console.WriteLine($"Sorting {size:n0} numbers");
            Print(array);
            Console.WriteLine();
            Sorts.MergeSort(array);
            Print(array);
        }
    }
}