## Stacks and Queues Module

### MyStack<T>
- Implements a generic LIFO stack using array-backed storage with doubling resize strategy.
- Public Methods:
  - `Push(T item)` — Adds to top (Amortized O(1))
  - `Pop()` — Removes from top (O(1))
  - `Peek()` — Views top without removing (O(1))
  - `Count` — Number of items (O(1))
- Use Cases: Undo operations, backtracking, expression evaluation.

### MyQueue<T>
- Implements a generic FIFO queue using circular array with doubling resize strategy.
- Public Methods:
  - `Enqueue(T item)` — Adds to end (Amortized O(1))
  - `Dequeue()` — Removes from front (Amortized O(1))
  - `Peek()` — Views front without removing (O(1))
  - `Count` — Number of items (O(1))
- Use Cases: Task scheduling, print queues, breadth-first traversal.

### Reflection

While .NET’s built-in `Stack<T>` and `Queue<T>` offer robust and optimized implementations, building custom versions gave me deeper insight into internal mechanics like array resizing and circular indexing. MyStack<T> and MyQueue<T> use explicit doubling strategies and expose the underlying behavior, which is useful for learning and debugging. Unlike the built-in types, my versions are fully transparent and customizable, making them ideal for educational demos or performance tuning. In production, I’d likely use the built-in types for reliability, but for teaching and experimentation, custom ADTs offer unmatched clarity.
