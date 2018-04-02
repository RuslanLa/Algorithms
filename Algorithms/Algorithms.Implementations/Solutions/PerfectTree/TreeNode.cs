namespace Algorithms.Implementations.Solutions.PerfectTree
{
    /// <summary>
    /// Solution for the kata https://www.codewars.com/kata/fun-with-trees-is-perfect
    /// class structure was inherited from the kata
    /// </summary>
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public static bool IsPerfect(TreeNode root)
        {
            if (root == null) return true;
            return root.GetLeavesLevel() != null; // TODO: implementation
        }


        private int? GetLeavesLevel()
        {
            if (this.left == null || this.right == null)
            {
                if (this.left == this.right)
                {
                    return 0;
                }

                return null;
            }

            var leftChildLevel = this.left.GetLeavesLevel();
            var rightChildLevel = this.right.GetLeavesLevel();
            if (leftChildLevel != rightChildLevel)
            {
                return null;
            }

            return leftChildLevel + 1;
        }

        public static TreeNode Leaf()
        {
            return new TreeNode();
        }

        public static TreeNode Join(TreeNode left, TreeNode right)
        {
            return new TreeNode().WithChildren(left, right);
        }

        public TreeNode WithLeft(TreeNode left)
        {
            this.left = left;
            return this;
        }

        public TreeNode WithRight(TreeNode right)
        {
            this.right = right;
            return this;
        }

        public TreeNode WithChildren(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
            return this;
        }

        public TreeNode WithLeftLeaf()
        {
            return WithLeft(Leaf());
        }

        public TreeNode WithRightLeaf()
        {
            return WithRight(Leaf());
        }

        public TreeNode WithLeaves()
        {
            return WithChildren(Leaf(), Leaf());
        }
    }
}
