using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class RecursionHelpersTests
    {
        // Factorial Tests
        [Fact]
        public void Factorial_Zero_ReturnsOne()
        {
            Assert.Equal(1, RecursionHelpers.Factorial(0));
        }

        [Fact]
        public void Factorial_Five_Returns120()
        {
            Assert.Equal(120, RecursionHelpers.Factorial(5));
        }

        [Fact]
        public void Factorial_Negative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => RecursionHelpers.Factorial(-1));
        }

        // Palindrome Tests
        [Theory]
        [InlineData("racecar", true)]
        [InlineData("hello", false)]
        [InlineData("", true)]
        [InlineData("a", true)]
        public void IsPalindrome_Cases(string input, bool expected)
        {
            Assert.Equal(expected, RecursionHelpers.IsPalindrome(input));
        }

        [Fact]
        public void IsPalindrome_Null_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => RecursionHelpers.IsPalindrome(null));
        }

        // Directory Traversal Tests
        [Fact]
        public void GetAllFiles_ReturnsAllFiles()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            File.WriteAllText(Path.Combine(tempDir, "file1.txt"), "test");
            Directory.CreateDirectory(Path.Combine(tempDir, "sub"));
            File.WriteAllText(Path.Combine(tempDir, "sub", "file2.txt"), "test");

            var files = RecursionHelpers.GetAllFiles(tempDir);
            Assert.Contains(files, f => f.EndsWith("file1.txt"));
            Assert.Contains(files, f => f.EndsWith("file2.txt"));

            Directory.Delete(tempDir, true);
        }

        [Fact]
        public void GetAllFiles_InvalidPath_ThrowsException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => RecursionHelpers.GetAllFiles("nonexistent_path"));
        }
    }
}

