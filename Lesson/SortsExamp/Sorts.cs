using System;
using System.Collections.Generic;

namespace SortsExamp
{
    public class Sorts
    {
        static void Swap<T>(IList<T> c, int i1, int i2)
        {
            T temp = c[i1];
            c[i1] = c[i2];
            c[i2] = temp;
        }

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

        /* QuickSort complexity is divided to the average case and the worst case.
         * ================================
         * in the best and avarage case it's of O(n log n)
         * but the worst case it's of O(n²)
         */
        public static void QuickSort<T>(IList<T> collection) where T : IComparable<T>
        {
            void QuickSort(IList<T> coll, int leftIndex, int rightIndex)
            {
                //Check if there are cells left in the collection
                if (leftIndex >= rightIndex) return;

                //ReArrange the array and recive a new pivotInex
                int pivotIndex = ReArrange(coll, leftIndex, rightIndex);

                //sort the left side
                QuickSort(coll, leftIndex, pivotIndex - 1);
                //sort the right side
                QuickSort(coll, pivotIndex + 1, rightIndex);
            }
            int ReArrange(IList<T> coll, int leftIndex, int rightIndex)
            {
                T pivotValue = coll[leftIndex];
                while (leftIndex < rightIndex)
                {
                    while (coll[rightIndex].CompareTo(pivotValue) >= 0 && leftIndex != rightIndex) rightIndex--;

                    if (leftIndex != rightIndex)
                        Swap(coll, rightIndex, leftIndex);

                    while (coll[leftIndex].CompareTo(pivotValue) <= 0 && leftIndex != rightIndex) leftIndex++;

                    if (leftIndex != rightIndex)
                        Swap(coll, rightIndex, leftIndex);
                }
                return rightIndex;
            }
            QuickSort(collection, 0, collection.Count - 1);
        }

        /* InPlaceQuickSort is of O(___) complexity.
         * ================================
         */
        public static void InPlaceQuickSort<T>(IList<T> collection) where T : IComparable<T>
        {

        }
    }
}