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
}
