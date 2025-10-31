using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Represents a node in a binary tree.
    /// </summary>
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Builds the teaching tree used in lecture.
        /// </summary>
        /// <returns>Root of the teaching tree</returns>
        public static TreeNode BuildTeachingTree()
        {
            TreeNode root = new TreeNode(38);
            root.Left = new TreeNode(27);
            root.Right = new TreeNode(43);
            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(9);
            return root;
        }

        /// <summary>
        /// Performs inorder traversal (Left, Root, Right).
        /// </summary>
        /// <param name="node">Current node</param>
        /// <param name="output">List to collect values</param>
        /// <remarks>O(n) time complexity</remarks>
        public static void Inorder(TreeNode node, List<int> output)
        {
            if (node == null) return;
            Inorder(node.Left, output);
            output.Add(node.Value);
            Inorder(node.Right, output);
        }

        /// <summary>
        /// Performs preorder traversal (Root, Left, Right).
        /// </summary>
        /// <param name="node">Current node</param>
        /// <param name="output">List to collect values</param>
        /// <remarks>O(n) time complexity</remarks>
        public static void Preorder(TreeNode node, List<int> output)
        {
            if (node == null) return;
            output.Add(node.Value);
            Preorder(node.Left, output);
            Preorder(node.Right, output);
        }

        /// <summary>
        /// Performs postorder traversal (Left, Right, Root).
        /// </summary>
        /// <param name="node">Current node</param>
        /// <param name="output">List to collect values</param>
        /// <remarks>O(n) time complexity</remarks>
        public static void Postorder(TreeNode node, List<int> output)
        {
            if (node == null) return;
            Postorder(node.Left, output);
            Postorder(node.Right, output);
            output.Add(node.Value);
        }

        /// <summary>
        /// Computes height of a tree (in edges).
        /// </summary>
        /// <param name="node">Root node</param>
        /// <returns>Height in edges</returns>
        /// <remarks>O(n) time complexity</remarks>
        public static int Height(TreeNode node)
        {
            if (node == null) return -1;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        /// <summary>
        /// Computes depth of a target value from root.
        /// </summary>
        /// <param name="node">Root node</param>
        /// <param name="target">Target value</param>
        /// <returns>Depth in edges or -1 if not found</returns>
        /// <remarks>O(h) time complexity</remarks>
        public static int Depth(TreeNode node, int target)
        {
            return DepthHelper(node, target, 0);
        }

        private static int DepthHelper(TreeNode node, int target, int depth)
        {
            if (node == null) return -1;
            if (node.Value == target) return depth;
            int left = DepthHelper(node.Left, target, depth + 1);
            if (left != -1) return left;
            return DepthHelper(node.Right, target, depth + 1);
        }
    }

    /// <summary>
    /// Represents a minimal Binary Search Tree.
    /// </summary>
    public class Bst
    {
        private TreeNode Root;

        /// <summary>
        /// Inserts a value into the BST (no duplicates).
        /// </summary>
        /// <param name="value">Value to insert</param>
        /// <remarks>Average O(log n), worst O(n)</remarks>
        public void Insert(int value)
        {
            Root = InsertHelper(Root, value);
        }

        private TreeNode InsertHelper(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);
            if (value < node.Value)
                node.Left = InsertHelper(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertHelper(node.Right, value);
            return node;
        }

        /// <summary>
        /// Checks if a value exists in the BST.
        /// </summary>
        /// <param name="value">Value to search</param>
        /// <returns>True if found, false otherwise</returns>
        /// <remarks>Average O(log n), worst O(n)</remarks>
        public bool Contains(int value)
        {
            return ContainsHelper(Root, value);
        }

        private bool ContainsHelper(TreeNode node, int value)
        {
            if (node == null) return false;
            if (node.Value == value) return true;
            if (value < node.Value)
                return ContainsHelper(node.Left, value);
            else
                return ContainsHelper(node.Right, value);
        }

        /// <summary>
        /// Computes height of the BST.
        /// </summary>
        /// <returns>Height in edges</returns>
        public int Height()
        {
            return TreeNode.Height(Root);
        }
    }

    /// <summary>
    /// Test harness to demonstrate correctness.
    /// </summary>
    public class TreeTest
    {
        public static void Run()
        {
            Console.WriteLine("=== Teaching Tree Traversals ===");
            TreeNode teachingTree = TreeNode.BuildTeachingTree();

            var inorder = new List<int>();
            var preorder = new List<int>();
            var postorder = new List<int>();

            TreeNode.Inorder(teachingTree, inorder);
            TreeNode.Preorder(teachingTree, preorder);
            TreeNode.Postorder(teachingTree, postorder);

            Console.WriteLine("Inorder: " + string.Join(", ", inorder));     // 3, 27, 9, 38, 43
            Console.WriteLine("Preorder: " + string.Join(", ", preorder));   // 38, 27, 3, 9, 43
            Console.WriteLine("Postorder: " + string.Join(", ", postorder)); // 3, 9, 27, 43, 38

            Console.WriteLine("\nHeight: " + TreeNode.Height(teachingTree)); // 2
            foreach (int val in new[] { 38, 27, 43, 3, 9 })
                Console.WriteLine($"Depth of {val}: {TreeNode.Depth(teachingTree, val)}");

            Console.WriteLine("\n=== BST Insert and Search ===");
            Bst bst = new Bst();
            foreach (int val in new[] { 50, 30, 70, 20, 40, 60, 80 })
                bst.Insert(val);

            foreach (int val in new[] { 20, 40, 60, 80, 90 })
                Console.WriteLine($"Contains {val}? {bst.Contains(val)}");

            Console.WriteLine("BST Height (balanced): " + bst.Height());

            Console.WriteLine("\n=== Skewed BST Height ===");
            Bst skewed = new Bst();
            foreach (int val in new[] { 10, 20, 30, 40, 50 })
                skewed.Insert(val);
            Console.WriteLine("Skewed BST Height: " + skewed.Height()); // Expected: 4
        }
    }
