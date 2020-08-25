using System;
using System.Collections.Generic;

namespace SortsExamp
{
    public class Sorts
    {
        /* Bubble sort is of O(n²) complexity.
         * ====================================
         * both the comparisons and the swaps are of O(n²)
         */
        public static void BubbleSort<T>(IList<T> collection) where T : IComparable<T>
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

        /* Max Sort is of O(n²) complexity.
         * ================================
         * but, there is a diffrent in the swaps.
         * the comparisons complexity is O(n²).
         * yet the swaps complexity is of O(n)
         */
        public static void MaxSort<T>(IList<T> collection) where T : IComparable<T>
        {
            int maxIndex;
            for (int i = collection.Count - 1; i > 0; i--)
            {
                maxIndex = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (collection[j].CompareTo(collection[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }
                if (maxIndex != i)
                {
                    T temp = collection[i];
                    collection[i] = collection[maxIndex];
                    collection[maxIndex] = temp;
                }
            }
        }
    }
}