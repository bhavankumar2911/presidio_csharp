﻿namespace LeetcodeProblemsApp
{
    internal class BinaryTreeMinDepth
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.left == null && root.right == null)
            {
                return 1;
            }
            else
            {
                int min = Int32.MaxValue;
                if (root.left != null)
                {
                    min = Math.Min(min, MinDepth(root.left));
                }
                if (root.right != null)
                {
                    min = Math.Min(min, MinDepth(root.right));
                }
                return min + 1;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
