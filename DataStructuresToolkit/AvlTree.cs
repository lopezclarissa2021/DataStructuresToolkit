using System;

namespace DataStructuresToolkit
{
    /// <summary>
    /// Represents a single node in an AVL tree.
    /// </summary>
    public class AvlNode
    {
        public int Key;
        public AvlNode Left;
        public AvlNode Right;
        public int Height;

        public AvlNode(int key)
        {
            Key = key;
            Height = 1;
        }
    }

    /// <summary>
    /// AVL Tree with Insert, Contains, and balancing.
    /// </summary>
    public class AvlTree
    {
        private AvlNode root;

        /// <summary>
        /// Inserts a key into the AVL tree.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <remarks>Time complexity: O(log n)</remarks>
        public void Insert(int key)
        {
            root = Insert(root, key);
        }

        /// <summary>
        /// Checks if a key exists in the tree.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>True if found, false otherwise.</returns>
        /// <remarks>Time complexity: O(log n)</remarks>
        public bool Contains(int key)
        {
            return Contains(root, key);
        }

        /// <summary>
        /// Prints the tree structure with balance factors.
        /// </summary>
        public void PrintTree()
        {
            PrintTree(root, "", true);
        }

        // ---------------- Internal Helpers ----------------

        private AvlNode Insert(AvlNode node, int key)
        {
            if (node == null) return new AvlNode(key);

            if (key < node.Key)
                node.Left = Insert(node.Left, key);
            else if (key > node.Key)
                node.Right = Insert(node.Right, key);
            else
                return node; // Duplicate keys not allowed

            UpdateHeight(node);
            return Rebalance(node);
        }

        private bool Contains(AvlNode node, int key)
        {
            if (node == null) return false;
            if (key == node.Key) return true;
            return key < node.Key ? Contains(node.Left, key) : Contains(node.Right, key);
        }

        private void UpdateHeight(AvlNode node)
        {
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }

        private int GetHeight(AvlNode node) => node?.Height ?? 0;

        private int GetBalance(AvlNode node) => GetHeight(node.Left) - GetHeight(node.Right);

        private AvlNode Rebalance(AvlNode node)
        {
            int balance = GetBalance(node);

            // Left heavy
            if (balance > 1)
            {
                if (GetBalance(node.Left) < 0)
                    node.Left = RotateLeft(node.Left); // LR case
                return RotateRight(node); // LL case
            }

            // Right heavy
            if (balance < -1)
            {
                if (GetBalance(node.Right) > 0)
                    node.Right = RotateRight(node.Right); // RL case
                return RotateLeft(node); // RR case
            }

            return node;
        }

        private AvlNode RotateLeft(AvlNode x)
        {
            AvlNode y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            UpdateHeight(x);
            UpdateHeight(y);
            return y;
        }

        private AvlNode RotateRight(AvlNode y)
        {
            AvlNode x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            UpdateHeight(y);
            UpdateHeight(x);
            return x;
        }

        private void PrintTree(AvlNode node, string indent, bool isLeft)
        {
            if (node != null)
            {
                Console.WriteLine($"{indent}{(isLeft ? "├──" : "└──")} {node.Key} (BF={GetBalance(node)})");
                PrintTree(node.Left, indent + (isLeft ? "│   " : "    "), true);
                PrintTree(node.Right, indent + (isLeft ? "│   " : "    "), false);
            }
        }
    }
}


