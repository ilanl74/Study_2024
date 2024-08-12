using System;

namespace Leet;

//Leet 226 invert binary tree 
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
public class TreeTricks
{
    public TreeNode InvertTree(TreeNode root)
    {


        SwitchLeefs(root);
        return root;
    }

    private void SwitchLeefs(TreeNode root)
    {

        if (root is not null)
        {
            if (root.left is null && root.right is null)
                return;
        }
        else return;
        var tmp = root.left;
        root.left = root.right;
        root.right = tmp;

        SwitchLeefs(root.left);
        SwitchLeefs(root.right);

    }

    public int MaxDepth(TreeNode root)
    {
        return RecDepth(root);
    }

    private int RecDepth(TreeNode root)
    {
        if (root == null)
            return 1;

    }
}
