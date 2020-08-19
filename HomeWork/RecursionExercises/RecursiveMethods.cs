using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionExercises
{
    class RecursiveMethods
    {
        //Q1
        //Check for Polindrom
        public static bool Palindrome(string str)
        {
            if (str.Length <= 1) return true;
            return str[0].Equals(str[str.Length - 1]) && Palindrome(str.Substring(1, str.Length - 2));
        }
        //Q2
        //Check for Prime Number
        public static bool IsPrime(int num, int divider = 2)
        {
            if (num % divider == 0) return false;

            if (divider * divider > num) return true;

            return IsPrime(num, ++divider);
        }
        //Q3
        //return Sum of digits
        public static int GetSumOfDigits(int num)
        {
            return num <= 0 ? 0 : num % 10 + GetSumOfDigits(num / 10);
        }
        //Q4
        //Find Min In Array
        public static int FindMin(int[] array, int pos)
        {
            return pos == 1 ? array[0] : Math.Min(array[pos - 1], FindMin(array, pos - 1));
        }
        //Q5
        //Find Appearances
        public static int CountAppearances(int[] array, int num, int startingIndex = 0)
        {
            if (startingIndex >= array.Length)
            {
                return 0;
            }
            return array[startingIndex].Equals(num) ? 1 + CountAppearances(array, num, ++startingIndex) :
                CountAppearances(array, num, ++startingIndex);
        }
    }
}
