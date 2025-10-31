using DataStructuresToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TreeToolkitTests
    {
        [Fact]
        public void TeachingTree_Traversals_AreCorrect()
        {
            var root = TreeNode.BuildTeachingTree();

            var inorder = new List<int>();
            TreeNode.Inorder(root, inorder);
            Assert.Equal(new List<int> { 3, 27, 9, 38, 43 }, inorder);

            var preorder = new List<int>();
            TreeNode.Preorder(root, preorder);
            Assert.Equal(new List<int> { 38, 27, 3, 9, 43 }, preorder);

            var postorder = new List<int>();
            TreeNode.Postorder(root, postorder);
            Assert.Equal(new List<int> { 3, 9, 27, 43, 38 }, postorder);
        }

        [Fact]
        public void TeachingTree_HeightAndDepth_AreCorrect()
        {
            var root = TreeNode.BuildTeachingTree();
            Assert.Equal(2, TreeNode.Height(root));
            Assert.Equal(0, TreeNode.Depth(root, 38));
            Assert.Equal(1, TreeNode.Depth(root, 27));
            Assert.Equal(2, TreeNode.Depth(root, 3));
            Assert.Equal(2, TreeNode.Depth(root, 9));
            Assert.Equal(1, TreeNode.Depth(root, 43));
        }

        [Fact]
        public void Bst_InsertAndContains_WorkCorrectly()
        {
            var bst = new Bst();
            int[] values = { 50, 30, 70, 20, 40, 60, 80 };
            foreach (int val in values)
                bst.Insert(val);

            foreach (int val in values)
                Assert.True(bst.Contains(val));

            Assert.False(bst.Contains(90));
        }

        [Fact]
        public void Bst_Height_IsCorrect_ForBalancedAndSkewed()
        {
            var balanced = new Bst();
            foreach (int val in new[] { 50, 30, 70, 20, 40, 60, 80 })
                balanced.Insert(val);
            Assert.Equal(2, balanced.Height());

            var skewed = new Bst();
            foreach (int val in new[] { 10, 20, 30, 40, 50 })
                skewed.Insert(val);
            Assert.Equal(4, skewed.Height());
        }
    }
}
