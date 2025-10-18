using System;
using System.IO;
using System.Collections.Generic;

namespace DataStructuresToolkit
{
    public static class RecursionHelpers
    {
        /// <summary>
        /// Computes the factorial of a non-negative integer n recursively.
        /// Base case: Factorial(0) = 1
        /// Recursive case: Factorial(n) = n * Factorial(n - 1)
        /// </summary>
        /// <param name="n">A non-negative integer</param>
        /// <returns>The factorial of n</returns>
        /// <exception cref="ArgumentException">Thrown if n is negative</exception>
        /// <remarks>Time: O(n), Space: O(n)</remarks>
        public static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be non-negative.");
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Recursively traverses a directory and returns all file paths.
        /// Base case: If directory has no subdirectories, return its files.
        /// Recursive case: Traverse each subdirectory and collect files.
        /// </summary>
        /// <param name="path">Root directory path</param>
        /// <returns>List of all file paths under the directory</returns>
        /// <remarks>Time: O(n), Space: O(n) where n is total files + folders</remarks>
        public static List<string> GetAllFiles(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"Directory not found: {path}");

            List<string> files = new List<string>();
            Traverse(path, files);
            return files;
        }

        private static void Traverse(string path, List<string> files)
        {
            foreach (var file in Directory.GetFiles(path))
                files.Add(file);

            foreach (var dir in Directory.GetDirectories(path))
                Traverse(dir, files);
        }

        /// <summary>
        /// Recursively checks if a string is a palindrome.
        /// Base case: Empty or single-character strings are palindromes.
        /// Recursive case: Compare first and last characters, then recurse on substring.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>True if s is a palindrome, false otherwise</returns>
        /// <remarks>Time: O(n), Space: O(n) due to substring and call stack</remarks>
        public static bool IsPalindrome(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            return CheckPalindrome(s, 0, s.Length - 1);
        }

        private static bool CheckPalindrome(string s, int left, int right)
        {
            if (left >= right)
                return true;
            if (s[left] != s[right])
                return false;
            return CheckPalindrome(s, left + 1, right - 1);
        }
    }
}
