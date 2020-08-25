using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionExercises
{
    class Program
    {
        static void Main()
        {
            //string w = "abcdcba";
            //string res = RecursiveMethods.Palindrome(w, 0) ? "a Palindrome" : "not a Palindrome";
            //Console.WriteLine($"{w} is {res}");

            //int num = 153;
            //Console.WriteLine($"num = {num}, is prime {RecursiveMethods.IsPrime(num, 2)}");
            //Console.WriteLine($"sum of digits for {num} is {RecursiveMethods.GetSumOfDigits(num)}");

            int[] array = { 1, 5, 8, 5, 5, 3, 2 };
            Console.WriteLine($"The min is {RecursiveMethods.FindMin(array, array.Length)}");

            //int numToSerch = 5;
            //Console.WriteLine($"{numToSerch} appers {RecursiveMethods.CountAppearances(array, numToSerch)}");
        }
    }
}