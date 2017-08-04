using System.Collections.Generic;

namespace Sort.Sort_Algorithms
{
    class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
    }

    class TreeSort : ISort
    {
        private int[] array;
        public void Sort(int[] array)
        {
            this.array = array;
            TreeNode root = null;
            for (int i = 0; i < this.array.Length; i++)
            {
                root = AddToTree(root, array[i]);
            }
            TreeToArray(root);
        }

        private TreeNode AddToTree(TreeNode root, int newValue)
        {
            if (root == null)
            {
                root = new TreeNode();
                root.value = newValue;
                root.left = root.right = null;
                return root;
            }
            if (root.value < newValue)
            {
                root.right = AddToTree(root.right, newValue);
            }
            else
            {
                root.left = AddToTree(root.left, newValue);
            }
            return root;
        }
        private void TreeToArray(TreeNode root)
        {
            if (root == null)
                return;

            var stack = new Stack<TreeNode>();
            var node = root;
            var index = 0;
            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    array[index++] = node.value;
                    node = node.right;
                }
                else
                {
                    stack.Push(node);
                    node = node.left;
                }
            }
        }
    }
}