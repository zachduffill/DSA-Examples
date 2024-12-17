using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class Stack : Example
    {
        private LinkedList stack;
        public int Length => stack.Length;

        public object Push(object obj)
        {
            LinkedList.Node node = new LinkedList.Node(obj);
            stack.Length++;

            if (stack.Head == null)
            {
                stack.Head = stack.Tail = node;
                return stack.Head.Value;
            }

            stack.Head.Prev = node;
            node.Next = stack.Head;
            stack.Head = node;

            return stack.Head.Value;
        }

        public object Pop()
        {
            if (stack.Head == null) return -1;
            
            LinkedList.Node node = stack.Head;

            if (node.Next == null)
            {
                stack.Head = stack.Tail = null;
                return node.Value;
            }

            node.Next.Prev = null;
            stack.Head = node.Next;
            node.Next = null;

            stack.Length--;
            return node.Value;
        }

        public Stack()
        {
            stack = new LinkedList();

            Tests = new Test<object?>[]
            {
                new Test<object?>("Push to Empty",() => Push(1),1),
                new Test<object?>("Push",() => Push(4),4),
                new Test<object?>("Length",() => Length,2),
                new Test<object?>("String conversion",() => stack.ToString(),"[4] -> [1]"),
                new Test<object?>("Pop",() => Pop(),4),
                new Test<object?>("Pop Last",() => Pop(),1),
                new Test<object?>("Attempt Pop on Empty",() => Pop(),-1), 
            };
        }
    }
}
