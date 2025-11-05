using System;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class AvlTreeTests
    {
        public static void Run()
        {
            Console.WriteLine("=== AVL Tree Test ===");

            var avl = new AvlTree();

            Console.WriteLine("Inserting 10, 20, 30 (should trigger RR rotation):");
            avl.Insert(10);
            avl.Insert(20);
            avl.Insert(30);
            avl.PrintTree();

            Assert.True(avl.Contains(10));
            Assert.True(avl.Contains(20));
            Assert.True(avl.Contains(30));
            Assert.False(avl.Contains(99));
        }
    }
}

