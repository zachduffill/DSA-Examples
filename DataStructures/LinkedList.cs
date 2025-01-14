﻿namespace DSA_Examples.Utility
{
    public class LinkedList
    {
        public Node? Head { get; set; }
        public Node? Tail { get; set; }
        public int Length { get; set; }

        public LinkedList(object[] initialValues) // Fill the list with values defined in the object[] argument
        {
            if (initialValues.Length == 0) return;

            Head = new Node(initialValues[0]);
            Length = 1;

            if (initialValues.Length == 1) return;

            Node last = Head;
            for (int i = 1; i < initialValues.Length; i++)
            {
                Node current = new Node(initialValues[i]);

                last.Next = current;
                current.Prev = last;

                last = current;

                Length++;
            }

            Tail = last;
        }

        public LinkedList()// Instantiate an empty list
        {
            Head = null; Tail = null; Length = 0;
        }


        // Returns a string representation of the list in the format "[value1] -> [value2] -> etc.."
        public override string ToString()
        {
            if (Head == null || Tail == null) return "";

            string str = "";

            LinkedList.Node? current = Head;
            while (current != Tail && current != null)
            {
                str += $"[{current.Value}] -> ";
                current = current.Next;
            }
            str += $"[{Tail.Value}]";

            return str;
        }
    }
}
