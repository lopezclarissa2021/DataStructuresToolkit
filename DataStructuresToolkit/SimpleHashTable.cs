using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// -------------------------------------------------------------
// Reflection:
// What I learned: Collisions are inevitable when mapping many keys into fewer buckets.
// Chaining handles collisions by keeping per-bucket lists, which preserves all entries
// without overwriting. The distribution quality of the hash function and the table size
// strongly affect average performance: in practice, good hashing keeps bucket lists short,
// making operations effectively O(1). In contrast, adversarial or clustered inputs can
// degrade to O(n) when many items land in the same bucket.
//
// Built-in containers like Dictionary<TKey,TValue> and HashSet<T> hide these details:
// they implement robust hashing, resizing, and load-factor management. This reduces
// implementation risk and yields predictable performance in typical workloads, while
// also providing rich APIs and safety checks.
//
// I’d prefer a custom hash table when I need to teach, instrument, or control low-level
// behavior: e.g., fixed-capacity memory, custom hashing for domain-specific keys,
// or predictable iteration with no rehashing. For real projects, Dictionary and HashSet
// are usually superior due to mature optimization, thorough testing, and maintainability.
// -------------------------------------------------------------

namespace DataStructuresToolkit
{
    public class SimpleHashTable
    {
        private readonly List<int>[] _buckets;
        private readonly int _size;

        /// <summary>
        /// Initializes a simple hash table with the specified number of buckets.
        /// </summary>
        /// <param name="size">The number of buckets used for hashing.</param>
        public SimpleHashTable(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be positive.");

            _size = size;
            _buckets = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                _buckets[i] = new List<int>();
            }
        }

        /// <summary>
        /// Inserts a key into the hash table using chaining to resolve collisions.
        /// Does not overwrite; duplicates are ignored to maintain set-like behavior.
        /// </summary>
        /// <param name="key">The integer key to insert.</param>
        /// <remarks>
        /// Average-case time: \(\mathcal{O}(1)\). Worst-case time: \(\mathcal{O}(n)\).
        /// </remarks>
        public void Insert(int key)
        {
            int index = GetIndex(key);
            var bucket = _buckets[index];
            if (!bucket.Contains(key))
            {
                bucket.Add(key);
            }
        }

        /// <summary>
        /// Checks whether a key exists in the table.
        /// </summary>
        /// <param name="key">The integer key to search for.</param>
        /// <returns>True if the key is present; otherwise, false.</returns>
        /// <remarks>
        /// Average-case time: \(\mathcal{O}(1)\). Worst-case time: \(\mathcal{O}(n)\).
        /// </remarks>
        public bool Contains(int key)
        {
            int index = GetIndex(key);
            return _buckets[index].Contains(key);
        }

        /// <summary>
        /// Prints all buckets and their contents to a single formatted string.
        /// </summary>
        /// <returns>A string representation of the hash table buckets.</returns>
        public string PrintTable()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                sb.Append($"Bucket {i}: ");
                if (_buckets[i].Count == 0)
                {
                    sb.AppendLine("(empty)");
                }
                else
                {
                    sb.AppendLine(string.Join(", ", _buckets[i]));
                }
            }
            return sb.ToString();
        }

        private int GetIndex(int key)
        {
            // Ensure non-negative index even if key is negative.
            int mod = key % _size;
            return mod < 0 ? mod + _size : mod;
        }
    }
}
