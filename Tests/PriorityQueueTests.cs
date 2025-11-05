using System;
using DataStructuresToolkit;

namespace Tests
{
    public class PriorityQueueTest
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Priority Queue Test ===");

            var pq = new PriorityQueue();

            Console.WriteLine("Enqueuing 5, 2, 8:");
            pq.Enqueue(5);
            pq.Enqueue(2);
            pq.Enqueue(8);
            pq.PrintHeap();

            Console.WriteLine("Dequeued: " + pq.Dequeue()); // Should be 2
            pq.PrintHeap();
        }
    }
}

