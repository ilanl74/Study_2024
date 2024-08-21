using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace Leet;


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
    public override int GetHashCode()
    {
        return val.GetHashCode();
    }
    public override bool Equals(object? obj)
    {

        var other = obj as TreeNode;
        if (other == null)
            return false;
        return other.val == val && ((other.left != null) ? other.left.Equals(left) : other.left == left) && ((other.right != null) ? other.right.Equals(right) : other.right == right);
    }
}
public class TreeTricks
{
    //Leet 226 invert binary tree 
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

    // Leet 104 maximum depth of binary tree 
    public int MaxDepth(TreeNode root)
    {
        return RecDepth(root);
    }

    private int RecDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return Math.Max(RecDepth(root.left) + 1, RecDepth(root.right) + 1);
    }

    /*
    Given the root of a binary tree, return the length of the diameter of the tree.
    The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.
    The length of a path between two nodes is represented by the number of edges between them.

    Example 1:
    Input: root = [1,2,3,4,5]
    Output: 3
    Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
    Example 2:

    Input: root = [1,2]
    Output: 1
    */
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int diameter = 0;
        _ = RecPath(root, ref diameter);
        return diameter;
    }

    private int RecPath(TreeNode root, ref int diameter)
    {
        if (root == null)
            return 0;
        int leftD = RecPath(root.left, ref diameter);
        int rightD = RecPath(root.right, ref diameter);

        diameter = Math.Max(diameter, leftD + rightD);
        return Math.Max(leftD, rightD) + 1;
    }

    //Leet 108 convert sorted list to binary search tree 
    // Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.


    public TreeNode SortedArrayToBST(int[] nums)
    {
        // find the mid and insert it as the root 
        // in the left insert the mid left , do the same for the right 
        int left = 0;
        int right = nums.Length - 1;
        // int mid = (nums.Length-1)/2;

        return RecSortedArrayToBST(nums, 0, nums.Length - 1);
    }

    private TreeNode RecSortedArrayToBST(int[] nums, int l, int r)
    {
        if (l > r)
            return null;

        int mid = (l + r) / 2;
        var lBranch = RecSortedArrayToBST(nums, l, mid - 1);
        var rBranch = RecSortedArrayToBST(nums, mid + 1, r);
        return new TreeNode() { val = nums[mid], left = lBranch, right = rBranch };
    }

    // Leet 101 Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
    /*
    Input: root = [1,2,2,3,4,4,3] // parent , left ,right ...
    Output: true

    Input: root = [1,2,2,null,3,null,3]
        Output: false
    */
    public bool IsSymmetric(TreeNode root)
    {
        return IsMirror(root, root);
    }
    private bool IsMirror(TreeNode left, TreeNode right)
    {
        if (left == null && right == null)
            return true;
        if (left == null || right == null)
            return false;

        return left.val == right.val && IsMirror(left.right, right.left) && IsMirror(right.right, left.left);
    }

    // Leet 102 Left Order Traversal 
    /*
    Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
    Input: root = [3,9,20,null,null,15,7]
    Output: [[3],[9,20],[15,7]]
    Input: root = [1]
    Output: [[1]]
    Input: root = []
    Output: []
    */
    public List<List<int>> LevelOrder(TreeNode root)
    {
        List<List<int>> ans = new();
        Queue<(TreeNode node, int level)> q = new();
        q.Enqueue((root, 0));

        while (q.Any())
        {
            var curr = q.Dequeue();
            // if (curr.level == null)
            //     curr.level = new List<int>();
            if (ans.Count - 1 < curr.level)
            {
                ans.Add(new List<int>());

            }
            ans[curr.level].Add(curr.node.val);
            if (curr.node.left != null)
            {
                q.Enqueue((curr.node.left, curr.level + 1));
            }
            if (curr.node.right != null)
            {
                q.Enqueue((curr.node.right, curr.level + 1));
            }
        }
        return ans;
    }

    // private void RecLevelOrder(TreeNode root, List<int> tmp, List<IList<int>> l)
    // {
    //     if (root == null)
    //         return;
    //     //List<int> level = new(2);
    //     tmp.Add(root.val);
    //     RecLevelOrder(root.left, tmp, l);

    //     RecLevelOrder(root.right, tmp, l);
    //     l.Add(new List<int>(tmp));


    // }

    public string DfsPost(TreeNode root)
    {
        if (root == null)
            return string.Empty;
        var left = DfsPost(root.left);
        left = (!string.IsNullOrEmpty(left)) ? left + "," : string.Empty;
        var right = DfsPost(root.right);
        right = (!string.IsNullOrEmpty(right)) ? right + "," : string.Empty;
        return $"{left}{right}{root.val}";

    }

    public string DfsPre(TreeNode root)
    {
        if (root == null)
            return string.Empty;
        var left = DfsPre(root.left);
        left = (!string.IsNullOrEmpty(left)) ? "," + left : string.Empty;
        var right = DfsPre(root.right);
        right = (!string.IsNullOrEmpty(right)) ? "," + right : string.Empty;
        return $"{root.val}{left}{right}";

    }

    public string DfsIn(TreeNode root)
    {
        if (root == null)
            return string.Empty;
        var left = DfsIn(root.left);
        left = (!string.IsNullOrEmpty(left)) ? left + "," : string.Empty;
        var right = DfsIn(root.right);
        right = (!string.IsNullOrEmpty(right)) ? "," + right : string.Empty;
        return $"{left}{root.val}{right}";

    }

    public string Bfs(TreeNode root)
    {
        string ans = string.Empty;
        Queue<(TreeNode node, int level)> q = new();
        q.Enqueue((root, 0));
        while (q.Any())
        {
            var curr = q.Dequeue();
            //do action 

            ans += $"{curr.level}->{curr.node.val},";
            if (curr.node.left != null)
                q.Enqueue((curr.node.left, curr.level + 1));
            if (curr.node.right != null)
                q.Enqueue((curr.node.right, curr.level + 1));


        }
        return ans;
    }

    /*
        DFS (depth first search) botom to 
            preorder , inorder , postorder
        BFS (breadth first srearch)
            top to botom , left to right 
            //BFS_DFS.jpg
    */

    /* 
        Leet 98 valid Binary search tree
        A valid BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees.

        the solution is based on DFS inline - in BST that shoud build a sorted queue
        */
    public bool IsValidBST(TreeNode root)
    {
        Queue<int> q = new();
        RecIsValidBST(root, q);
        int last = int.MinValue;
        while (q.Any())
        {
            var curr = q.Dequeue();
            if (last > curr)
                return false;
            last = curr;
        }
        return true;
    }

    private void RecIsValidBST(TreeNode node, Queue<int> q)
    {
        if (node == null)
            return;

        RecIsValidBST(node.left, q);
        q.Enqueue(node.val);
        RecIsValidBST(node.right, q);

    }
    /*
    Leet 103 Binary Tree Zigzag Level Order Traversal
    Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).
    Input: root = [3,9,20,null,null,15,7]
    Output: [[3],[20,9],[15,7]]
    Example 2:

    Input: root = [1]
    Output: [[1]]
    Example 3:

    Input: root = []
    Output: []
    */
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        Queue<(TreeNode node, int level)> q = new();
        List<IList<int>> ans = new();
        q.Enqueue((root, 0));
        while (q.Any())
        {
            var curr = q.Dequeue();
            if (ans.Count() < curr.level + 1)
                ans.Add(new List<int>());

            if (curr.level % 2 == 0)
            {
                ans[curr.level].Add(curr.node.val);
            }
            else
            {
                ans[curr.level].Insert(0, curr.node.val);
            }
            if (curr.node.left != null)
                q.Enqueue((curr.node.left, curr.level + 1));
            if (curr.node.right != null)
                q.Enqueue((curr.node.right, curr.level + 1));
        }
        return ans;
    }

    /*
    Leet 105 Construct Binary Tree from Preorder and Inorder Traversal
    Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and inorder is the inorder traversal of the same tree, construct and return the binary tree.
    Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
    Output: [3,9,20,null,null,15,7]
    Input: preorder = [-1], inorder = [-1]
    Output: [-1]
    */
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        TreeNode root = new();
        if (preorder.Length == 0)
            return null;
        if (preorder.Length >= 1)
        {
            root.val = preorder[0];
        }
        if (preorder.Length == 1)
            return root;
        Dictionary<int, int> inOrderMap = new();
        for (var i = 0; i < inorder.Length; i++)
        {
            inOrderMap.Add(inorder[i], i);
        }

        return RecBuildTree(preorder, inorder, 0, preorder.Length - 1, inOrderMap);

    }
    int pPos = 0;
    private TreeNode RecBuildTree(int[] preorder, int[] inorder, int l, int r, Dictionary<int, int> inOrderMap)
    {

        if (l > r)
        {
            return null;
        }
        var rootVal = preorder[pPos++];

        var rootIndex = inOrderMap[rootVal];

        var root = new TreeNode() { val = rootVal };
        root.left = RecBuildTree(preorder, inorder, l, rootIndex - 1, inOrderMap);
        root.right = RecBuildTree(preorder, inorder, rootIndex + 1, r, inOrderMap);



        return root;

    }
    /*
        Leet 114 Flatten Binary Tree to Linked List
        Given the root of a binary tree, flatten the tree into a "linked list":

        The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
        The "linked list" should be in the same order as a pre-order traversal of the binary tree.
        Example 1:
        Input: root = [1,2,5,3,4,null,6]
        Output: [1,null,2,null,3,null,4,null,5,null,6]
        Example 2:

        Input: root = []
        Output: []
        Example 3:

        Input: root = [0]
        Output: [0]
     */
    public void Flatten(TreeNode root)
    {
        var ans = root;
        ans = RecFlatten(root);
        //root.left = null;


    }
    private TreeNode RecFlatten(TreeNode node)
    {
        if (node == null)
            return null;
        if (node.left == null && node.right == null)
            return node;

        var l = RecFlatten(node.left);
        var r = RecFlatten(node.right);
        if (l != null)
        {
            l.right = node.right;
            node.right = node.left;
            node.left = null;
        }
        return r == null ? l : r;



    }
    //this one is iterative solution to the 114
    public void Flatten1(TreeNode root)
    {
        if (root == null)
            return;
        var ans = root;

        while (root != null)
        {
            if (root.left == null)
            {
                root = root.right;
                continue;
            }
            var p = root.left;
            var tmp = p;
            var r = root.right;
            while (tmp.right != null)
            {
                tmp = tmp.right;
            }
            tmp.right = r;
            root.right = p;
            root.left = null;
            //root = root.right;
        }



    }
}

