using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        static void BubbleSort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        //O(√n) Examp
        static bool IsPrime(int num)
        {
            if (num == 1)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        static void Main()
        {
            int[] array = { 4, 5, 2, 34, 7, 5, 9, 3, 5 };
            Console.WriteLine($"==========================");
            Print(array);

            Console.WriteLine($"==========================");
            Console.WriteLine($"\nO(n) Examp => Calculate average: {GetAverage(array)}\n");

            BubbleSort(array);
            Console.Write($"O(n²) Examp => BubbleSort:\t");
            Print(array);

            Console.WriteLine();
            foreach (int num in array)
            {
                Console.WriteLine($"O(√n) Examp => Check if {num} is a prime numeber, {IsPrime(num)}");
            }
        }

        static void Print(int [] array)
        {
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }
}
