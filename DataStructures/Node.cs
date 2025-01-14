namespace DSA_Examples.Utility
{
    public class Node // class representing a singular node in the list
    {
        public object Value { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(object val, Node? next = null, Node? prev = null) // instantiates a node with a given value
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
}
