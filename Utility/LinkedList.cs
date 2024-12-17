using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA_Examples.Utility
{
    public struct LinkedList
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

            public override string ToString()
            {
                return this.Value.ToString() ?? "Null";
            }
        }

        public LinkedList(object[] arr)
        {
            if (arr.Length == 0) return;

            Head = new Node(arr[0]);
            Length = 1;

            if (arr.Length == 1) return;

            Node last = Head;
            for (int i = 1; i < arr.Length; i++)
            {
                Node curr = new Node(arr[i]);

                last.Next = curr;
                curr.Prev = last;

                last = curr;

                Length++;
            }

            Tail = last;
        }

        public LinkedList()
        {
            Head = null; Tail = null; Length = 0;
        }

        public override string ToString()
        {
            if (Head == null || Tail == null) return "";

            string str = "";

            LinkedList.Node? curr = Head;
            while (curr != Tail && curr != null)
            {
                str += $"[{curr.Value}] -> ";
                curr = curr.Next;
            }
            str += $"[{Tail.Value}]";

            return str;
        }
    }
}
