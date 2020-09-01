using System;
using System.Collections.Generic;

namespace SortsExamp
{
    public class Sorts
    {
        /// <summary>
        /// Swaps the two values in the collection
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="c">The collection</param>
        /// <param name="i1">The first index</param>
        /// <param name="i2">The second index</param>
        static void Swap<T>(T[] c, int i1, int i2)
        {
            T temp = c[i1];
            c[i1] = c[i2];
            c[i2] = temp;
        }

        /* Bubble sort is of O(n²) complexity.
         * ====================================
         * both the comparisons and the swaps are of O(n²)
         */
        public static void BubbleSort<T>(T[] collection) where T : IComparable<T>
        {
            for (int i = collection.Length - 1; i > 0; i--)
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
        public static void MaxSort<T>(T[] collection) where T : IComparable<T>
        {
            int maxIndex;
            for (int i = collection.Length - 1; i > 0; i--)
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
         * in the best and avarage cases it's of O(n log n) complexity
         * but in the worst case it's of O(n²)
         */
        public static void QuickSort<T>(T[] collection) where T : IComparable<T>
        {
            void QuickSort(T[] coll, int leftIndex, int rightIndex)
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
            int ReArrange(T[] coll, int leftIndex, int rightIndex)
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
            QuickSort(collection, 0, collection.Length - 1);
        }

        /* QuickSort with improverd Rearrange*/
        public static void ImprovedRearrangeQuickSort<T>(T[] collection) where T : IComparable<T>
        {
            void QuickSort(T[] coll, int leftIndex, int rightIndex)
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
            int ReArrange(T[] coll, int leftIndex, int rightIndex)
            {
                //The Improvment here is selecting a "Random" pivot.
                Random rng = new Random();
                int tempI = rng.Next(leftIndex, rightIndex + 1);
                Swap(coll, leftIndex, tempI);

                T pivotValue = coll[leftIndex];

                while (leftIndex < rightIndex)
                {
                    while (coll[rightIndex].CompareTo(pivotValue) >= 0 && leftIndex != rightIndex) rightIndex--;

                    if (leftIndex != rightIndex)
                        Swap(coll, leftIndex, rightIndex);

                    while (coll[leftIndex].CompareTo(pivotValue) <= 0 && leftIndex != rightIndex) leftIndex++;

                    if (leftIndex != rightIndex)
                        Swap(coll, leftIndex, rightIndex);
                }
                return leftIndex;
            }
            QuickSort(collection, 0, collection.Length - 1);
        }
        /* MergeSort is of O(n log n) complexity
         * ================================
         * is allways of n log n complexity
         * the downside of it is the memory allocation
         */
        public static void MergeSort<T>(T[] collection) where T : IComparable<T>
        {
            void MergeSort(T[] coll, int leftIndex, int rightIndex)
            {
                if (leftIndex >= rightIndex) return;
                //find and set the middle of the range
                int midIndex = (leftIndex + rightIndex) / 2;
                //sort left side
                MergeSort(coll, leftIndex, midIndex);
                //sort right side
                MergeSort(coll, midIndex + 1, rightIndex);
                //merge the two
                Merge(coll, leftIndex, midIndex, midIndex + 1, rightIndex);
            }
            void Merge(T[] coll, int startLeftIndex, int endLeftIndex, int startRightIndex, int endRightIndex)
            {
                //create a temp array for holding the merged data
                T[] temp = new T[endRightIndex - startLeftIndex + 1];

                //loop the two chunks, compare the values, and position in temp array
                int i = startLeftIndex;
                int j = startRightIndex;
                int writeIndex = 0;
                while ((i <= endLeftIndex) && (j <= endRightIndex))
                {
                    if (coll[i].CompareTo(coll[j]) <= 0) temp[writeIndex] = coll[i++];
                    else temp[writeIndex] = coll[j++];
                    writeIndex++;
                }
                //add tail to tmp
                while (i <= endLeftIndex) temp[writeIndex++] = coll[i++];
                while (j <= endRightIndex) temp[writeIndex++] = coll[j++];
                //write the tmp to the collection
                for (int k = startLeftIndex, tmpIndex = 0; k <= endRightIndex; k++, tmpIndex++)
                {
                    coll[k] = temp[tmpIndex];
                }
            }
            MergeSort(collection, 0, collection.Length - 1);
        }
    }
}