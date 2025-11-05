using System;
using System.Collections.Generic;

/*
Reflection:
While working on the AVL tree, I learned how to spot when the tree becomes unbalanced. After inserting numbers like 10, 20, and 30 in order, the tree leaned too far to the right. I used balance factors (difference in height between left and right subtrees) to check each node. When the balance factor was less than -1 or greater than 1, I knew a rotation was needed to fix it. Rotations in AVL trees help keep the tree balanced so that searching and inserting stay fast. I practiced left and right rotations, and also learned how to handle tricky cases like LR and RL. Heapify works differently—it doesn’t balance a tree, but instead organizes an array into a min-heap where the smallest value is always at the top. Heapify is great for quick access to the smallest item, like in a priority queue. If I were building a real project, I’d choose an AVL tree when I need fast searching, like looking up users or items by ID. I’d choose a priority queue when I need to process tasks by urgency or time, like scheduling jobs or handling events. Both are useful, but they solve different problems. This lab helped me understand how structure affects performance and why choosing the right tool matters.
*/



namespace DataStructuresToolkit
{
    /// <summary>
    /// Min-heap based priority queue with Enqueue and Dequeue operations.
    /// </summary>
    public class PriorityQueue
    {
        private List<int> heap = new List<int>();

        /// <summary>
        /// Adds a value to the priority queue.
        /// </summary>
        /// <param name="val">The value to enqueue.</param>
        /// <remarks>Time complexity: O(log n)</remarks>
        public void Enqueue(int val)
        {
            heap.Add(val);
            BubbleUp(heap.Count - 1);
        }

        /// <summary>
        /// Removes and returns the smallest value.
        /// </summary>
        /// <returns>The minimum value.</returns>
        /// <remarks>Time complexity: O(log n)</remarks>
        public int Dequeue()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Empty queue");
            int min = heap[0];
            heap[0] = heap[heap.Count - 1];

            heap.RemoveAt(heap.Count - 1);
            BubbleDown(0);
            return min;
        }

        /// <summary>
        /// Prints the current heap as a comma-separated list.
        /// </summary>
        public void PrintHeap()
        {
            Console.WriteLine(string.Join(", ", heap));
        }

        // ---------------- Internal Helpers ----------------

        private void BubbleUp(int i)
        {
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (heap[i] >= heap[parent]) break;
                (heap[i], heap[parent]) = (heap[parent], heap[i]);
                i = parent;
            }
        }

        private void BubbleDown(int i)
        {
            int n = heap.Count;
            while (true)
            {
                int left = 2 * i + 1, right = 2 * i + 2, smallest = i;
                if (left < n && heap[left] < heap[smallest]) smallest = left;
                if (right < n && heap[right] < heap[smallest]) smallest = right;
                if (smallest == i) break;
                (heap[i], heap[smallest]) = (heap[smallest], heap[i]);
                i = smallest;
            }
        }
    }
}
