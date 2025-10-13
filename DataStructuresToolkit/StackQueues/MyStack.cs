using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StackQueues
{
    /// <summary>
    /// A generic stack (LIFO) implemented with array-backed storage and doubling strategy.
    /// </summary>
    /// <typeparam name="T">Type of elements stored.</typeparam>
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;

        public MyStack(int capacity = 4)
        {
            _items = new T[capacity];
            _count = 0;
        }

        /// <summary>
        /// Gets the number of elements in the stack. O(1)
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Adds an item to the top of the stack. Amortized O(1)
        /// </summary>
        public void Push(T item)
        {
            if (_count == _items.Length)
                Resize(_items.Length * 2);
            _items[_count++] = item;
        }

        /// <summary>
        /// Returns the item at the top and removes it. O(1)
        /// </summary>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty.");
            return _items[--_count];
        }

        /// <summary>
        /// Returns the item at the top without removing it. O(1)
        /// </summary>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty.");
            return _items[_count - 1];
        }

        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }
    }
}
