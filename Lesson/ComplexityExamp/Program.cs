using System;
using System.Collections.Generic;

namespace ComplexityExamp
{
    class Program
    {
        //O(n) Examp
        static double GetAverage(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return (double)sum / array.Length;
        }
        //O(n²) Examp
        static void BubbleSort<T>(IList<T> collection) where T : IComparable<T>
        {
            for (int i = collection.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (collection[j].CompareTo(collection[j + 1]) > 0)
                    {
                        T temp = collection[j];
                        collection[j] = collection[j + 1];
                        collection[j + 1] = temp;
                    }
                }
            }
        }
        //O(√n) Examp
        static bool IsPrime(int num)
        {
            for (int i = 2; i <= (int)Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        //O(log(n)) Examp
        static bool BinarySerch<T>(IList<T> collection, T serchKey, out int index) where T : IComparable<T>
        {
            int low = 0;
            int high = collection.Count - 1;
            int middle;
            while (low <= high)
            {
                middle = (low + high) / 2;
                if (collection[middle].Equals(serchKey))
                {
                    index = middle;
                    return true;
                }
                if (collection[middle].CompareTo(serchKey) > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            index = -1;
            return false;
        }

        static void Main()
        {
            int[] array = { 4, 5, 2, 34, 7, 99, 9, 3, 46 };

            Console.WriteLine($"==========================");
            Print(array);
            Console.WriteLine($"==========================");

            Console.WriteLine($"\nO(n) Examp => Calculate average: {GetAverage(array):0.00}\n");

            BubbleSort(array);
            Console.Write($"O(n²) Examp => BubbleSort:  ");
            Print(array);
            Console.WriteLine();

            foreach (int num in array)
            {
                Console.WriteLine($"O(√n) Examp => Check if {num} is a prime numeber, {IsPrime(num)}");
            }

            int serchKey = 5;
            if (BinarySerch(array, serchKey, out int resIndex))
            {
                Console.WriteLine($"\nO(log(n)) Examp => Binery Serch. Serch key: {serchKey} -> index: {resIndex}");
            }
            else
            {
                Console.WriteLine($"The serch key {serchKey} is not in the array");
            }
        }

        static void Print<T>(IList<T> collection)
        {
            foreach (T item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}