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
        //This is a solution that will send a new string every time. this is heavy on the system.
        public static bool Palindrome(string str)
        {
            return (str.Length <= 1) || str[0].Equals(str[str.Length - 1]) && Palindrome(str.Substring(1, str.Length - 2));
        }
        //if you send an index you can leave the string as it is, and lower the demand on memory
        public static bool Palindrome(string str, int index)
        {
            return (index >= str.Length / 2) || str[index].Equals(str[str.Length - index - 1]) && Palindrome(str, index + 1);
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
        //loops through from the end to the start
        public static int FindMin(int[] array, int index)
        {
            return index <= 0 ? array[index] : Math.Min(array[index - 1], FindMin(array, index - 1));
        }
        //This is how to loop from the start to the end instead
        /*
        public static int FindMin(int[] array, int index)
        {
            return index == array.Length - 1 ? array[index] : Math.Min(array[index], FindMin(array, index + 1));
        }
        */

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