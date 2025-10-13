using DataStructuresToolkit.StackQueues;
using System;
using Xunit;

public class MyQueueTests
{
    [Fact]
    public void Enqueue_IncreasesCount()
    {
        var queue = new MyQueue<int>();
        queue.Enqueue(5);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Peek_ReturnsFirstEnqueued()
    {
        var queue = new MyQueue<string>();
        queue.Enqueue("X");
        queue.Enqueue("Y");
        Assert.Equal("X", queue.Peek());
    }

    [Fact]
    public void Dequeue_ReturnsAndRemovesFirst()
    {
        var queue = new MyQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Dequeue_OnEmpty_Throws()
    {
        var queue = new MyQueue<int>();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Wraparound_WorksCorrectly()
    {
        var queue = new MyQueue<int>(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue();
        queue.Dequeue();
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5); // Wraparound
        Assert.Equal(3, queue.Dequeue());
    }
}
