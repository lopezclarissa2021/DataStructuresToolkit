using System;
using DataStructuresToolkit.StackQueues;

namespace DemoHarness
{
    public class Demo_StacksQueues
    {
        public static void Run()
        {
            Console.WriteLine("=== STACK DEMO: Undo Sequence (LIFO) ===");
            var undoStack = new MyStack<string>();
            undoStack.Push("Typed 'Hello'");
            undoStack.Push("Bolded text");
            undoStack.Push("Inserted image");

            while (undoStack.Count > 0)
            {
                Console.WriteLine($"Undo: {undoStack.Pop()}");
            }

            Console.WriteLine("\n=== QUEUE DEMO: Print Job Order (FIFO) ===");
            var printQueue = new MyQueue<string>();
            printQueue.Enqueue("Job1: Resume");
            printQueue.Enqueue("Job2: Invoice");
            printQueue.Enqueue("Job3: Report");

            while (printQueue.Count > 0)
            {
                Console.WriteLine($"Printing: {printQueue.Dequeue()}");
            }
        }
    }
}
