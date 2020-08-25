using System;
using System.Collections;
using System.IO;

namespace RecursionExamp
{
    class Program
    {
        #region Helping Methods
        //Request a number
        static int GetNum(string msg)
        {
            int num;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid input!\nTry again...");
            }
            return num;
        }
        //print a group
        static void Print(IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        //generate random numbers
        static int[] GetTestNumbers(int amount, int maxV)
        {
            int[] res = new int[amount];
            Random random = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = random.Next(maxV + 1);
            }
            return res;
        }
        #endregion

        #region The Methods!
        //calculates the factorial of the parameter
        static long Factorial(long num) => num <= 1 ? 1 : num * Factorial(num - 1);
        //Shows how recursion acts with calculating the sum
        static int UnderstandingRecursion(int num)
        {
            Console.WriteLine($"Entered Method with num = {num}");

            if (num <= 1)
            {
                Console.WriteLine("Reached recursion break point num = 1");
                return 1;
            }

            Console.WriteLine($"sending to method with {num} - 1 = {num - 1}");
            int temp = UnderstandingRecursion(num - 1);

            Console.WriteLine($"Came Back from method with result = {temp}, sending back {num} + {temp} = {num + temp}");
            return num + temp;
        }
        //calculate the sum of an array
        static int SumArray(int[] arr)
        {
            int SumArray(int[] array, int index) => index >= array.Length ? 0 : array[index] + SumArray(array, index + 1);
            return SumArray(arr, 0);
        }
        //Fibonacci sequence example
        static int Fibonacci(int num) => num <= 2 ? 1 : Fibonacci(num - 1) + Fibonacci(num - 2);
        //Show DirTree in a recursive pattern
        public static void PrintDir(DirectoryInfo dir)
        {
            void PrintDir(DirectoryInfo rootDir, int spaces = 0)
            {
                foreach (DirectoryInfo childDir in rootDir.GetDirectories())
                {
                    Console.WriteLine($"{new string(' ', spaces)}-{childDir.Name}");
                    PrintDir(childDir, spaces + 2);
                }
            }
            PrintDir(dir);
        }
        #endregion

        #region The Test Methods(create data and run the methods)
        static void TestFactorial()
        {
            Console.WriteLine("Factorial");
            int num;
            Console.WriteLine($"Testing Factorial Algorithm => num = { num = GetNum("Enter Number ")} |Resault => {Factorial(num)} ");
        }

        static void TestUnderstandingRecursion()
        {
            Console.WriteLine("Understanding Recursion (will sum all of the numbers leading up to the input)");
            int num;
            Console.WriteLine($"\nRecursivly sum up to {num = GetNum("Enter Numeber ")} resault = {UnderstandingRecursion(num)}");
        }

        static void TestSumArray()
        {
            var array = GetTestNumbers(10, 25);
            Console.WriteLine("Testing SumArray => ");
            Print(array);
            Console.WriteLine($"Resualt => {SumArray(array)}");
        }

        static void TestFibonacci()
        {
            Console.WriteLine("Fibonacci");
            int num;
            Console.WriteLine($"Testing Fibonacci Algorithm => in position { num = GetNum("Enter Number ")} |Resault => {Fibonacci(num)} ");
        }

        static void TestPrintDir()
        {
            Console.WriteLine("DirTree");
            string dirPath = @"D:\Test";
            Console.WriteLine($"Printing all of the folders in {dirPath}");
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            PrintDir(directory);
        }
        #endregion

        static void Main()
        {
            TestFactorial();
            Console.WriteLine();

            TestUnderstandingRecursion();
            Console.WriteLine();

            TestSumArray();
            Console.WriteLine();

            TestFibonacci();
            Console.WriteLine();

            TestPrintDir();
            Console.WriteLine();
        }

    }
}