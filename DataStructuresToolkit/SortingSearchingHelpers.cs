using System;
using System.Diagnostics;

/// <summary>
/// Reflection:
/// BubbleSort and LinearSearch were the easiest to implement because their logic is simple and direct.
/// They use basic loops and comparisons, which made them easy to test and debug.
/// MergeSort and BinarySearch were harder because they required recursion and careful index handling.
/// I had to pay close attention to splitting arrays and managing boundaries.
/// In terms of performance, MergeSort was much faster than BubbleSort on larger arrays.
/// The difference became clear at 1,000 elements and even more at 10,000.
/// BinarySearch also outperformed LinearSearch, but only after the array was sorted.
/// For small arrays, the difference was small, but for large arrays, BinarySearch was much faster.
/// In my Capstone Toolkit, I’ll use MergeSort for sorting and BinarySearch for searching when performance matters.
/// I’ll keep BubbleSort and LinearSearch for teaching and testing because they’re easy to understand and useful for small datasets.
/// This lab helped me see how algorithm choice affects speed and efficiency in real projects.
/// </summary>
namespace DataStructuresToolkit
{
    public static class SortingSearchingHelpers
    {
        /// <summary>
        /// Sorts an array using Bubble Sort.
        /// </summary>
        /// <param name="arr">Array to sort</param>
        /// <remarks>
        /// Time: Best O(n), Average/Worst O(n^2)
        /// Space: O(1)
        /// </remarks>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array using Merge Sort.
        /// </summary>
        /// <param name="arr">Array to sort</param>
        /// <remarks>
        /// Time: Best/Average/Worst O(n log n)
        /// Space: O(n)
        /// </remarks>
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;
            MergeSortRecursive(arr, 0, arr.Length - 1);
        }

        private static void MergeSortRecursive(int[] arr, int left, int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            MergeSortRecursive(arr, left, mid);
            MergeSortRecursive(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= mid) temp[k++] = arr[i++];
            while (j <= right) temp[k++] = arr[j++];

            for (int m = 0; m < temp.Length; m++)
                arr[left + m] = temp[m];
        }

        /// <summary>
        /// Searches for a target value using Linear Search.
        /// </summary>
        /// <param name="arr">Array to search</param>
        /// <param name="target">Value to find</param>
        /// <returns>Index of target or -1</returns>
        /// <remarks>
        /// Time: Best O(1), Average/Worst O(n)
        /// Space: O(1)
        /// </remarks>
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Searches for a target value using Binary Search.
        /// </summary>
        /// <param name="arr">Sorted array to search</param>
        /// <param name="target">Value to find</param>
        /// <returns>Index of target or -1</returns>
        /// <remarks>
        /// Time: Best/Average/Worst O(log n)
        /// Space: O(1)
        /// </remarks>
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        /// <summary>
        /// Test harness to measure performance and correctness.
        /// </summary>
        public static void Main()
        {
            int[] sizes = { 100, 1000, 10000 };
            Random rand = new Random();

            Console.WriteLine("Size\tBubbleSort\tMergeSort\tLinearSearch\tBinarySearch");

            foreach (int size in sizes)
            {
                int[] original = new int[size];
                for (int i = 0; i < size; i++)
                    original[i] = rand.Next(1, 100000);

                int target = original[size / 2];

                int[] bubbleArray = (int[])original.Clone();
                int[] mergeArray = (int[])original.Clone();

                Stopwatch sw = new Stopwatch();

                sw.Start();
                BubbleSort(bubbleArray);
                sw.Stop();
                long bubbleTime = sw.ElapsedMilliseconds;

                sw.Reset();
                sw.Start();
                MergeSort(mergeArray);
                sw.Stop();
                long mergeTime = sw.ElapsedMilliseconds;

                sw.Reset();
                sw.Start();
                LinearSearch(original, target);
                sw.Stop();
                long linearTime = sw.ElapsedMilliseconds;

                Array.Sort(original); // Required for BinarySearch
                sw.Reset();
                sw.Start();
                BinarySearch(original, target);
                sw.Stop();
                long binaryTime = sw.ElapsedMilliseconds;

                Console.WriteLine($"{size}\t{bubbleTime} ms\t\t{mergeTime} ms\t\t{linearTime} ms\t\t{binaryTime} ms");
            }
        }
    }
}

