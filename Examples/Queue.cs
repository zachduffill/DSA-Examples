namespace DSA_Examples.Examples
{
    internal class Queue : Example
    {
        private LinkedList queue;
        private struct LinkedList
        {
            public Node? Head { get; set; }
            public Node? Tail { get; set; }
            public int Length { get; set; }
            
            public class Node
            {
                public object Value { get; set; }
                public Node? Next { get; set; }
                public Node? Prev { get; set; }

                public Node(object val, Node? next = null, Node? prev = null)
                {
                    Value = val;
                    Next = next;
                    Prev = prev;
                }
            }

            public LinkedList(object[] arr)
            {
                if (arr.Length == 0) return;

                Head = new Node(arr[0]);

                if (arr.Length == 1) return;

                Node last = Head;
                for (int i = 1; i < arr.Length; i++)
                {
                    Node curr = new Node(arr[i]);

                    last.Next = curr;
                    curr.Prev = last;

                    last = curr;
                }

                Tail = last;
            }

            public LinkedList()
            {
                Head = null; Tail = null;
            }
        }

        public object Peek()
        {
            if (queue.Head == null) return -1;
            return queue.Head.Value;
        }

        public object Enqueue(object obj)
        {
            LinkedList.Node node = new LinkedList.Node(obj);
            if (queue.Head == null || queue.Tail == null) queue.Head = queue.Tail = node;
            else
            {
                queue.Tail.Next = node;
                node.Prev = queue.Tail;
                queue.Tail = node;
            }

            return queue.Tail.Value;
        }

        public object? Dequeue()
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

            return node.Value;
        }

        public override string ToString()
        {
            if (queue.Head == null || queue.Tail == null) return "";

            string str = "";

            LinkedList.Node? curr = queue.Head;
            while (curr != queue.Tail && curr != null)
            {
                str += $"[{curr.Value}] -> ";
                curr = curr.Next;
            }
            str += $"[{queue.Tail.Value}]";

            return str;
        }

        public Queue()
        {
            queue = new LinkedList([1,2,3,4,5,6]);

            Tests = new Test<object?>[]
            {
                new Test<object?>("Peek",() => Peek(),1),
                new Test<object?>("Dequeue",() => Dequeue(),1),
                new Test<object?>("Enqueue",() => Enqueue(0),0),
                new Test<object?>("String conversion",() => ToString(),"[2] -> [3] -> [4] -> [5] -> [6] -> [0]"),
            };
        }
    }
}
