using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Reflection:

Linked lists trade random access for flexible, constant-time structural edits at the ends and near known positions. Arrays (and List<T>) excel at indexed access and cache-friendly iteration; however, inserting or deleting near the front requires shifting elements, which is O(n). In contrast, singly linked lists deliver O(1) insertion at the head and O(1) deletion when you have the predecessor, but they suffer from O(n) search and no backward traversal. Doubly linked lists add a Prev link, enabling reverse traversal and O(1) deletion with a direct node reference, with the cost of extra memory and more careful pointer maintenance. Circular linked lists shine when wrap-around iteration is a first-class need (e.g., round-robin schedulers, buffering, playlists). They avoid null checks at boundaries and make the “next after tail” well-defined, but complexity remains O(n) for arbitrary searches. This exercise deepened my understanding of references in C#: nodes are objects on the heap, and links are references that must be updated consistently. Bugs often stem from missing one side of an update (e.g., setting Next but not Prev), or losing Head/Tail when removing boundary nodes. I saw how O(1) operations depend on maintaining stable entry points (Head/Tail) and direct references to nodes; otherwise work degrades to O(n). I also appreciated how .NET’s LinkedList<T> exposes node objects (LinkedListNode<T>) and methods that mirror manual operations, while taking care of edge cases internally. Choosing among arrays, singly, doubly, and circular lists depends on whether you prioritize random access and memory locality, or stable, constant-time structural edits and bidirectional navigation.
*/


namespace DataStructuresToolkit
{
    /// <summary>
    /// Node for a singly linked list.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <remarks>
    /// Stores data and a reference to the next node.
    /// </remarks>
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public override string ToString() => Data?.ToString() ?? "null";
    }

    /// <summary>
    /// Node for a doubly linked list.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <remarks>
    /// Stores data and both next and previous references.
    /// </remarks>
    public class DoublyNode<T>
    {
        public T Data { get; set; }
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Prev { get; set; }

        public DoublyNode(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }

        public override string ToString() => Data?.ToString() ?? "null";
    }

    /// <summary>
    /// Minimal singly linked list with head pointer.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <remarks>
    /// Complexity:
    /// - AddFirst: O(1)
    /// - Traverse: O(n)
    /// - Contains: O(n)
    /// Space per node: one reference (Next).
    /// </remarks>
    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Inserts an element at the head in O(1).
        /// </summary>
        /// <param name="data">Element to insert.</param>
        /// <returns>The new head node.</returns>
        public Node<T> AddFirst(T data)
        {
            var node = new Node<T>(data)
            {
                Next = Head
            };
            Head = node;
            Count++;
            return node;
        }

        /// <summary>
        /// Traverses from head to end, invoking an action on each element.
        /// </summary>
        /// <param name="visit">Action applied to each element.</param>
        public void Traverse(Action<T> visit)
        {
            var current = Head;
            while (current != null)
            {
                visit(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns true if any element equals the target.
        /// </summary>
        /// <param name="target">Value to search for.</param>
        /// <returns>True if found; otherwise false.</returns>
        /// <remarks>O(n) linear search.</remarks>
        public bool Contains(T target)
        {
            var comparer = EqualityComparer<T>.Default;
            var current = Head;
            while (current != null)
            {
                if (comparer.Equals(current.Data, target)) return true;
                current = current.Next;
            }
            return false;
        }
    }

    /// <summary>
    /// Doubly linked list tracking head and tail for O(1) inserts at either end and O(1) deletion with a direct node reference.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <remarks>
    /// Complexity:
    /// - AddFirst: O(1)
    /// - AddLast: O(1)
    /// - Remove(node): O(1) with direct node reference
    /// - TraverseForward / TraverseBackward: O(n)
    /// Space per node: two references (Next, Prev).
    /// </remarks>
    public class DoublyLinkedList<T>
    {
        public DoublyNode<T> Head { get; private set; }
        public DoublyNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Inserts at the head in O(1).
        /// </summary>
        /// <param name="data">Element to insert.</param>
        /// <returns>The inserted node.</returns>
        public DoublyNode<T> AddFirst(T data)
        {
            var node = new DoublyNode<T>(data);

            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }

            Count++;
            return node;
        }

        /// <summary>
        /// Inserts at the tail in O(1).
        /// </summary>
        /// <param name="data">Element to insert.</param>
        /// <returns>The inserted node.</returns>
        public DoublyNode<T> AddLast(T data)
        {
            var node = new DoublyNode<T>(data);

            if (Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                node.Prev = Tail;
                Tail.Next = node;
                Tail = node;
            }

            Count++;
            return node;
        }

        /// <summary>
        /// Removes the specified node in O(1) by splicing neighbors.
        /// </summary>
        /// <param name="node">Node to remove.</param>
        /// <returns>True if removal succeeded; false if node was null.</returns>
        public bool Remove(DoublyNode<T> node)
        {
            if (node == null) return false;

            if (node == Head) Head = node.Next;
            if (node == Tail) Tail = node.Prev;

            if (node.Prev != null) node.Prev.Next = node.Next;
            if (node.Next != null) node.Next.Prev = node.Prev;

            node.Prev = null;
            node.Next = null;

            if (Count > 0) Count--;
            return true;
        }

        /// <summary>
        /// Traverses from head to tail, invoking an action on each element.
        /// </summary>
        /// <param name="visit">Action applied to each element.</param>
        public void TraverseForward(Action<T> visit)
        {
            var current = Head;
            while (current != null)
            {
                visit(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Traverses from tail to head, invoking an action on each element.
        /// </summary>
        /// <param name="visit">Action applied to each element.</param>
        public void TraverseBackward(Action<T> visit)
        {
            var current = Tail;
            while (current != null)
            {
                visit(current.Data);
                current = current.Prev;
            }
        }

        /// <summary>
        /// Utility to find the first node matching a predicate. O(n).
        /// </summary>
        public DoublyNode<T> FindFirst(Func<T, bool> predicate)
        {
            var cur = Head;
            while (cur != null)
            {
                if (predicate(cur.Data)) return cur;
                cur = cur.Next;
            }
            return null;
        }
    }

    /// <summary>
    /// Optional circular singly linked list.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <remarks>
    /// Head.Next eventually wraps to Head; traversal uses a do-while style and stops when back at Head.
    /// </remarks>
    public class CircularLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Add at head and maintain circular Next.
        /// </summary>
        public Node<T> AddFirst(T data)
        {
            var node = new Node<T>(data);
            if (Head == null)
            {
                Head = node;
                node.Next = node; // self-loop
            }
            else
            {
                // Insert before current head
                var tail = Head;
                while (tail.Next != Head) tail = tail.Next; // find tail (O(n))
                node.Next = Head;
                tail.Next = node;
                Head = node;
            }
            Count++;
            return node;
        }

        /// <summary>
        /// Traverses once around the circle starting at Head. O(n).
        /// </summary>
        public void Traverse(Action<T> visit)
        {
            if (Head == null) return;
            var current = Head;
            do
            {
                visit(current.Data);
                current = current.Next;
            } while (current != Head);
        }
    }
}