using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -------------------------------------------------------------
// Reflection (200–300 words)
// Built-in associative containers handle hashing, collisions, and resizing internally.
// Dictionary<TKey,TValue> provides fast key-based lookups and updates, while HashSet<T>
// maintains uniqueness with a clear API for set operations. This reduces cognitive load:
// fewer implementation choices, fewer error-prone details, and stronger guarantees.
//
// I learned that collisions don’t disappear with built-ins—they’re just handled well.
// The API stays stable even as the structure resizes or rebalances. This makes everyday
// development simpler and safer compared to custom structures, unless there’s a niche need.
// -------------------------------------------------------------

namespace DataStructuresToolkit
{
    public class AssociativeHelpers
    {
        /// <summary>
        /// Demonstrates Dictionary usage by storing simple phone numbers and performing lookups.
        /// </summary>
        /// <returns>A formatted string describing lookup results.</returns>
        public static string DemoDictionary()
        {
            var phoneBook = new Dictionary<string, string>
            {
                ["Alice"] = "555-0101",
                ["Bob"] = "555-0202",
                ["Carol"] = "555-0303"
            };

            bool hasAlice = phoneBook.ContainsKey("Alice");
            bool hasDavid = phoneBook.ContainsKey("David");

            string aliceNumber = hasAlice ? phoneBook["Alice"] : "(not found)";
            string davidNumber = hasDavid ? phoneBook["David"] : "(not found)";

            return
                "Dictionary Demo:\n" +
                $"- Has Alice? {hasAlice}\n" +
                $"- Has David? {hasDavid}\n" +
                $"- Alice's number: {aliceNumber}\n" +
                $"- David's number: {davidNumber}\n";
        }

        /// <summary>
        /// Demonstrates HashSet usage by preventing duplicates and checking membership.
        /// </summary>
        /// <returns>A formatted string describing set contents and checks.</returns>
        public static string DemoHashSet()
        {
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            bool addedApple1 = set.Add("apple"); // true
            bool addedApple2 = set.Add("apple"); // false, duplicate due to case-insensitive comparer
            bool containsApple = set.Contains("apple");
            bool containsBanana = set.Contains("banana");

            return
                "HashSet Demo:\n" +
                $"- Add 'apple' first time: {addedApple1}\n" +
                $"- Add 'apple' second time: {addedApple2}\n" +
                $"- Contains 'apple'? {containsApple}\n" +
                $"- Contains 'banana'? {containsBanana}\n" +
                $"- Items: {string.Join(", ", set.OrderBy(s => s))}\n";
        }
    }
}
