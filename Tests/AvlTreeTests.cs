using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit;

namespace Tests
{
    public class AvlTreeTests
    {
        [Fact]
        public void AvlTree_Insert_RotatesCorrectly()
        {
            var avl = new AvlTree();

            avl.Insert(10);
            avl.Insert(20);
            avl.Insert(30);

            Assert.True(avl.Contains(10));
            Assert.True(avl.Contains(20));
            Assert.True(avl.Contains(30));
            Assert.False(avl.Contains(99));
        }
    }
}