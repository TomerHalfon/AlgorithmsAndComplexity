using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                res[i] = rng.Next(101);
            }
            return res;
        }

        static void Main()
        {
            int size = 1000000;
            int[] array = GetArrayOfRngs(size);
            Console.WriteLine($"Sorting {size:n0} numbers");
            Console.WriteLine($"PreSort => {DateTime.Now:mm:ss:fff}");
            Sorts.QuickSort(array);
            Console.WriteLine($"PostSort => {DateTime.Now:mm:ss:fff}");
        }
    }
}
