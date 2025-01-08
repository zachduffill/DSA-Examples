using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class Queue : Example
    {
        private LinkedList queue;

        public object Peek() // Returns the item at the front of the queue
        {
            if (queue.Head == null) return -1;
            return queue.Head.Value;
        }

        public object Enqueue(object obj) // Adds a given object to the end of the queue as a node, returns it's value
        {
            LinkedList.Node node = new LinkedList.Node(obj);
            if (queue.Head == null || queue.Tail == null) queue.Head = queue.Tail = node;
            else
            {
                queue.Tail.Next = node;
                node.Prev = queue.Tail;
                queue.Tail = node;
            }

            queue.Length++;
            return queue.Tail.Value;
        }

        public object? Dequeue() // Removes the node at the front of the queue, returns it's value
        {
            if (queue.Head == null || queue.Tail == null) return null;

            LinkedList.Node node = queue.Head;

            if (node.Next == null)
            {
                queue.Head = queue.Tail = null;
            }
            else
            {
                node.Next.Prev = null;
                queue.Head = node.Next;
            }

            queue.Length--;
            return node.Value;
        }

        public Queue()
        {
            queue = new LinkedList([1,2,3,4,5,6]);

            Tests = new Test<object?>[]
            {
                new Test<object?>("Peek",() => Peek(),1),
                new Test<object?>("Dequeue",() => Dequeue(),1),
                new Test<object?>("Enqueue",() => Enqueue(0),0),
                new Test<object?>("String conversion",() => queue.ToString(),"[2] -> [3] -> [4] -> [5] -> [6] -> [0]"),
            };
        }
    }
}
