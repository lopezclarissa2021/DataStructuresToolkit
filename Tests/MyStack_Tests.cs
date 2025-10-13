using Xunit;
using System;
using DataStructuresToolkit.StackQueues;

public class MyStackTests
{
    [Fact]
    public void Push_IncreasesCount()
    {
        var stack = new MyStack<int>();
        stack.Push(10);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Peek_ReturnsLastPushed()
    {
        var stack = new MyStack<string>();
        stack.Push("A");
        stack.Push("B");
        Assert.Equal("B", stack.Peek());
    }

    [Fact]
    public void Pop_ReturnsAndRemovesLast()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_OnEmpty_Throws()
    {
        var stack = new MyStack<int>();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Push_TriggersResize()
    {
        var stack = new MyStack<int>(2);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3); // Should resize
        Assert.Equal(3, stack.Count);
    }
}
