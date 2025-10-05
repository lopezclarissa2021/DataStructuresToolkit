using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructuresToolkit
{
    /// <summary>
    /// Provides helper methods for working with arrays, strings, and lists.
    /// </summary>
    public class ArrayStringListHelpers
    {
        /// <summary>
        /// Inserts a value into an array at the specified index by shifting elements to the right.
        /// </summary>
        /// <param name="arr">The original array.</param>
        /// <param name="index">The index at which to insert the value.</param>
        /// <param name="value">The value to insert.</param>
        /// <returns>A new array with the value inserted.</returns>
        /// <remarks>Time complexity: O(n) – because all elements after the index must be shifted.</remarks>
        public static int[] InsertIntoArray(int[] arr, int index, int value)
        {
            int[] result = new int[arr.Length + 1];
            for (int i = 0; i < index; i++)
                result[i] = arr[i];

            result[index] = value;

            for (int i = index; i < arr.Length; i++)
                result[i + 1] = arr[i];

            return result;
        }

        /// <summary>
        /// Deletes an element from an array at the specified index by shifting elements to the left.
        /// </summary>
        /// <param name="arr">The original array.</param>
        /// <param name="index">The index of the element to delete.</param>
        /// <returns>A new array with the element removed.</returns>
        /// <remarks>Time complexity: O(n) – because all elements after the index must be shifted.</remarks>
        public static int[] DeleteFromArray(int[] arr, int index)
        {
            int[] result = new int[arr.Length - 1];
            for (int i = 0; i < index; i++)
                result[i] = arr[i];

            for (int i = index + 1; i < arr.Length; i++)
                result[i - 1] = arr[i];

            return result;
        }

        /// <summary>
        /// Concatenates an array of names using naive string concatenation with += in a loop.
        /// </summary>
        /// <param name="names">An array of names to concatenate.</param>
        /// <returns>A single string containing all names separated by commas.</returns>
        /// <remarks>Time complexity: O(n²) worst case – due to repeated string copying in each loop iteration.</remarks>
        public static string ConcatenateNamesNaive(string[] names)
        {
            string result = "";
            for (int i = 0; i < names.Length; i++)
            {
                result += names[i];
                if (i < names.Length - 1)
                    result += ",";
            }
            return result;
        }

        /// <summary>
        /// Concatenates an array of names using a StringBuilder for efficient string handling.
        /// </summary>
        /// <param name="names">An array of names to concatenate.</param>
        /// <returns>A single string containing all names separated by commas.</returns>
        /// <remarks>Time complexity: O(n) – StringBuilder avoids repeated copying and reallocations.</remarks>
        public static string ConcatenateNamesBuilder(string[] names)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                sb.Append(names[i]);
                if (i < names.Length - 1)
                    sb.Append(",");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Inserts a value into a List at the specified index.
        /// </summary>
        /// <param name="list">The list to insert into.</param>
        /// <param name="index">The index at which to insert the value.</param>
        /// <param name="value">The value to insert.</param>
        /// <remarks>Time complexity: O(n) – inserting in the middle requires shifting elements.</remarks>
        public static void InsertIntoList(List<int> list, int index, int value)
        {
            list.Insert(index, value);
        }
    }
}
