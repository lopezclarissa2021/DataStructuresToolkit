using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.StackQueues
{
    /// <summary>
    /// A generic queue (FIFO) implemented with circular array and doubling strategy.
    /// </summary>
    /// <typeparam name="T">Type of elements stored.</typeparam>
    public class MyQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public MyQueue(int capacity = 4)
        {
            _items = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        /// <summary>
        /// Gets the number of elements in the queue. O(1)
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Adds an item to the end of the queue. Amortized O(1)
        /// </summary>
        public void Enqueue(T item)
        {
            if (_count == _items.Length)
                Resize(_items.Length * 2);

            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        /// <summary>
        /// Removes and returns the item at the front. Amortized O(1)
        /// </summary>
        public T Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty.");

            T item = _items[_head];
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        /// <summary>
        /// Returns the item at the front without removing it. O(1)
        /// </summary>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return _items[_head];
        }

        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < _count; i++)
                newArray[i] = _items[(_head + i) % _items.Length];

            _items = newArray;
            _head = 0;
            _tail = _count;
        }
    }
}
