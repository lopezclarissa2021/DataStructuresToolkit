using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class LinkedListHelpersTests
    {
        [Fact]
        public void SinglyLinkedList_AddFirst_TraversesInCorrectOrder()
        {
            var list = new SinglyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddFirst(30);

            var values = new List<int>();
            list.Traverse(v => values.Add(v));

            Assert.Equal(new List<int> { 30, 20, 10 }, values);
            Assert.True(list.Contains(20));
            Assert.False(list.Contains(99));
        }

        [Fact]
        public void DoublyLinkedList_AddFirstAndAddLast_WorkCorrectly()
        {
            var dll = new DoublyLinkedList<string>();
            dll.AddFirst("alpha");
            dll.AddLast("beta");
            dll.AddLast("gamma");

            var forward = new List<string>();
            dll.TraverseForward(s => forward.Add(s));

            Assert.Equal(new List<string> { "alpha", "beta", "gamma" }, forward);

            var backward = new List<string>();
            dll.TraverseBackward(s => backward.Add(s));

            Assert.Equal(new List<string> { "gamma", "beta", "alpha" }, backward);
        }

        [Fact]
        public void DoublyLinkedList_RemoveNode_UpdatesLinksCorrectly()
        {
            var dll = new DoublyLinkedList<string>();
            dll.AddLast("a");
            dll.AddLast("b");
            dll.AddLast("c");

            var nodeB = dll.FindFirst(s => s == "b");
            var removed = dll.Remove(nodeB);

            Assert.True(removed);

            var forward = new List<string>();
            dll.TraverseForward(s => forward.Add(s));

            Assert.Equal(new List<string> { "a", "c" }, forward);
            Assert.Equal(2, dll.Count);
        }

        [Fact]
        public void CircularLinkedList_AddFirstAndTraverse_WrapsAround()
        {
            var cll = new CircularLinkedList<int>();
            cll.AddFirst(1);
            cll.AddFirst(2);
            cll.AddFirst(3);

            var values = new List<int>();
            cll.Traverse(v => values.Add(v));

            Assert.Equal(new List<int> { 3, 2, 1 }, values);
            Assert.Equal(3, cll.Count);
        }
    }
}
