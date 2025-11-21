using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class PriorityQueueTest  
    {
        [Fact]
        public void PriorityQueue_EnqueueAndDequeue_WorkCorrectly()
        {
            Console.WriteLine("\n=== Priority Queue Test ===");

            var pq = new PriorityQueue();

            pq.Enqueue(5);
            pq.Enqueue(2);
            pq.Enqueue(8);

            Assert.Equal(2, pq.Dequeue());
            Assert.Equal(5, pq.Dequeue());
            Assert.Equal(8, pq.Dequeue());
        }
    }
}

