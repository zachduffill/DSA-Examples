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

        public Queue()
        {
            queue = new LinkedList([1,2,3,4,5,6]);

            Tests = new Test<object?>[]
            {
                new Test<object?>(() => ToString(),0)
            };
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
    }
}
