using System;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class SimpleHashTableTests
    {
        /// <summary>
        /// Verifies that keys 12, 22, 37 collide into the same bucket in a size-5 table
        /// and that Contains returns true for each inserted key.
        /// </summary>
        [Fact]
        public void Insert_And_Contains_Should_Handle_Collisions()
        {
            // Arrange
            var table = new SimpleHashTable(5);
            int[] keys = { 12, 22, 37 };

            // Act
            foreach (var k in keys) table.Insert(k);

            // Assert
            Assert.True(table.Contains(12));
            Assert.True(table.Contains(22));
            Assert.True(table.Contains(37));
            Assert.False(table.Contains(99)); // sanity check

            // PrintTable content check (bucket 2 should have all keys)
            string output = table.PrintTable();
            Assert.Contains("Bucket 2:", output);
            Assert.Contains("12", output);
            Assert.Contains("22", output);
            Assert.Contains("37", output);
        }

        /// <summary>
        /// Verifies that duplicates are not inserted multiple times.
        /// </summary>
        [Fact]
        public void Insert_Should_Ignore_Duplicates()
        {
            // Arrange
            var table = new SimpleHashTable(5);

            // Act
            table.Insert(12);
            table.Insert(12); // duplicate
            table.Insert(22);

            // Assert
            string output = table.PrintTable();
            // Bucket 2 should list 12 only once
            int count12 = CountOccurrences(output, "12");
            Assert.Equal(1, count12);
            Assert.True(table.Contains(12));
            Assert.True(table.Contains(22));
        }

        /// <summary>
        /// Verifies modulo normalization handles negative keys without throwing or misindexing.
        /// </summary>
        [Fact]
        public void Contains_Should_Work_With_Negative_Keys()
        {
            // Arrange
            var table = new SimpleHashTable(5);

            // Act
            table.Insert(-1); // -1 % 5 should normalize
            table.Insert(-6); // -6 % 5 should normalize to same bucket as -1

            // Assert
            Assert.True(table.Contains(-1));
            Assert.True(table.Contains(-6));

            string output = table.PrintTable();
            Assert.Contains("Bucket", output); // basic sanity
        }

        /// <summary>
        /// Verifies constructor rejects non-positive sizes.
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Constructor_Should_Throw_For_Invalid_Size(int size)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SimpleHashTable(size));
        }

        // Helper: Count occurrences of a substring within a string
        private static int CountOccurrences(string text, string fragment)
        {
            int count = 0;
            int idx = 0;
            while ((idx = text.IndexOf(fragment, idx, StringComparison.Ordinal)) != -1)
            {
                count++;
                idx += fragment.Length;
            }
            return count;
        }
    }
}
