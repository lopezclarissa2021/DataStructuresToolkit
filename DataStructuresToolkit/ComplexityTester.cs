using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructuresToolkit
{
    /// <summary>
    /// Provides methods to demonstrate different algorithmic complexities.
    /// </summary>
    public class ComplexityTester
    {
        /// <summary>
        /// Returns the first element of the array.
        /// </summary>
        /// <param name="arr">Input array</param>
        /// <returns>The first element</returns>
        /// <remarks>
        /// O(1) – Constant time. The operation does not depend on the size of the input.
        /// </remarks>
        public int RunConstantScenario(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Array cannot be null or empty.");
            return arr[0];
        }

        /// <summary>
        /// Computes the sum of all elements in the array.
        /// </summary>
        /// <param name="arr">Input array</param>
        /// <returns>The sum of elements</returns>
        /// <remarks>
        /// O(n) – Linear time. Each element is visited exactly once.
        /// </remarks>
        public int RunLinearScenario(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            int sum = 0;
            foreach (var num in arr)
            {
                sum += num;
            }
            return sum;
        }

        /// <summary>
        /// Computes the sum of all pairwise products in the array.
        /// </summary>
        /// <param name="arr">Input array</param>
        /// <returns>The sum of pairwise products</returns>
        /// <remarks>
        /// O(n²) – Quadratic time. Nested loops iterate over all pairs of elements.
        /// </remarks>
        public int RunQuadraticScenario(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            int total = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    total += arr[i] * arr[j];
                }
            }
            return total;
        }
    }
}
