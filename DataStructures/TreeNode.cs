
namespace DSA_Examples.DataStructures
{
    public class TreeNode
    {
        public object? Value { get; set; }
        public TreeNode? Parent { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(object? val = null, TreeNode? parent = null, TreeNode? left = null, TreeNode? right = null) // instantiates a node with a given value
        {
            Value = val;
            Parent = parent;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return this.Value.ToString() ?? "Null";
        }
    }
}
