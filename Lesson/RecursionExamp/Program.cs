using System;

namespace RecursionExamp
{
    class Program
    {
        //calculates the factorial of the parameter
        static long Factorial(long num)
        {
            return num <= 1 ? 1 : num * Factorial(num - 1);
        }
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
        static void Main()
        {
            int num = 3;
            Console.WriteLine($"Recursively sum {num}\n");
            Console.WriteLine($"\nresault = {UnderstandingRecursion(num)}");
            //Console.WriteLine($"The Factorial of {num} is {Factorial(num)}");
        }
    }
}