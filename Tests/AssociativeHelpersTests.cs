using DataStructuresToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class AssociativeHelpersTests
    {
        /// <summary>
        /// Verifies DemoDictionary outputs expected presence flags and values.
        /// </summary>
        [Fact]
        public void DemoDictionary_Should_Show_Correct_ContainsKey_And_Lookups()
        {
            // Act
            string result = AssociativeHelpers.DemoDictionary();

            // Assert
            Assert.Contains("Dictionary Demo:", result);
            Assert.Contains("Has Alice? True", result);
            Assert.Contains("Has David? False", result);
            Assert.Contains("Alice's number: 555-0101", result);
            Assert.Contains("David's number: (not found)", result);
        }

        /// <summary>
        /// Verifies DemoHashSet prevents duplicates and reports membership correctly.
        /// </summary>
        [Fact]
        public void DemoHashSet_Should_Prevent_Duplicates_And_Report_Membership()
        {
            // Act
            string result = AssociativeHelpers.DemoHashSet();

            // Assert
            Assert.Contains("HashSet Demo:", result);
            Assert.Contains("Add 'apple' first time: True", result);
            Assert.Contains("Add 'apple' second time: False", result);
            Assert.Contains("Contains 'apple'? True", result);
            Assert.Contains("Contains 'banana'? False", result);

            // Items list should include only a single 'apple'
            // We check that 'apple' appears exactly once in the Items line.
            string[] lines = result.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string itemsLine = Array.Find(lines, l => l.StartsWith("- Items: ", StringComparison.Ordinal));
            Assert.NotNull(itemsLine);

            int countApple = CountOccurrences(itemsLine, "apple");
            Assert.Equal(1, countApple);
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
