
namespace DSA_Examples.Utility
{
    public class Tree
    {
        TreeNode Root;

        public Tree() // Instantiates the tree with an empty Root node
        {
            Root = new TreeNode();
        }

        public Tree(object[] objs) // Takes an array representation of a binary tree (objs), and creates and fills a tree with it 
        {
            Root = new TreeNode(objs[0]);
            Root = recurse(Root, 0);

            TreeNode recurse(TreeNode node, int idx) //      UNTESTED UNTESTED UNTESTED !!!!!!!!!!!!!!!!!
            {
                int? leftChildIndex = getChildIndex(false, idx);
                int? rightChildIndex = getChildIndex(true, idx);
                if (node.Left == null && leftChildIndex != null) // If a left child can be added, add it and recurse into it
                {
                    TreeNode newNode = new TreeNode(objs[(int)leftChildIndex]);
                    node.Left = recurse(newNode,(int)leftChildIndex);
                }
                if (node.Right == null && rightChildIndex != null) // If a right child can be added, add it and recurse into it
                {
                    TreeNode newNode = new TreeNode(objs[(int)rightChildIndex]);
                    node.Right = recurse(newNode, (int)rightChildIndex);
                }
                return node;
            }

            int? getChildIndex(bool dir, int currIdx)
            {
                int idx = (2 * currIdx) + (dir ? 2 : 1);
                if (idx < objs.Length)
                {
                    if (objs[idx] != null) return idx;
                }

                return null;
            }
        }
    }
}
