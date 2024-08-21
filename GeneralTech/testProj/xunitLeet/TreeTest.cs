using System;
using Leet;

namespace xunitLeet;

public class TreeTest
{
    [Theory]
    [MemberData(nameof(LeftTraversalData))]
    public void LeftTraversalTest
    (
        TreeNode root,
        string dfsPost,
        string dfsPre,
        string dfsIn,
        List<List<int>> bfs

    )
    {
        TreeTricks tree = new();
        var res = tree.DfsPost(root);
        Assert.Equal(dfsPost, res);
        res = tree.DfsPre(root);
        Assert.Equal(dfsPre, res);
        res = tree.DfsIn(root);
        Assert.Equal(dfsIn, res);
        var resl = tree.LevelOrder(root);
        Assert.Equal(bfs, resl);
    }

    public static IEnumerable<object[]> LeftTraversalData()
    {
        yield return new object[]{
            new TreeNode()
                {
                    val=5,
                    left=new TreeNode()
                        {
                            val=3,
                            left=new(){val=2,left=new(){val=1}},
                            right=new(){val=4}
                        },
                    right = new TreeNode()
                    {
                        val=7,
                        left = new TreeNode()
                        {
                            val = 6
                        },
                        right = new TreeNode()
                        {
                            val =8,
                            right = new(){val=9}
                        }
                    }
                } ,"1,2,4,3,6,9,8,7,5","5,3,2,1,4,7,6,8,9","1,2,3,4,5,6,7,8,9",new List<List<int>>(){
                            new(){5},
                            new(){3,7},
                            new (){2,4,6,8},
                            new (){1,9}}};
    }

    [Theory]
    [MemberData(nameof(ZigZagData))]
    public void ZigzagTets
    (
        TreeNode input,
        List<List<int>> exp
    )
    {
        TreeTricks tree = new();
        var res = tree.ZigzagLevelOrder(input);
        Assert.Equal(exp, res);
    }

    public static IEnumerable<object[]> ZigZagData()
    {
        yield return new object[]{new TreeNode()
                {
                    val=5,
                    left=new TreeNode()
                        {
                            val=3,
                            left=new(){val=2,left=new(){val=1}},
                            right=new(){val=4}
                        },
                    right = new TreeNode()
                    {
                        val=7,
                        left = new TreeNode()
                        {
                            val = 6
                        },
                        right = new TreeNode()
                        {
                            val =8,
                            right = new(){val=9}
                        }
                    }
                },
                new List<List<int>>(){
                            new(){5},
                            new(){7,3},
                            new (){2,4,6,8},
                            new (){9,1}}
                };
    }

    [Theory]
    [MemberData(nameof(BuildTreeData))]
    public void BuildTree
    (
        int[] preOrder,
        int[] inOrder,
        TreeNode exp

    )
    {
        TreeTricks tree = new();
        var res = tree.BuildTree(preOrder, inOrder);
        Assert.Equal(exp, res);
    }

    public static IEnumerable<object[]> BuildTreeData()
    {
        yield return new object[] { new int[] { 5, 3, 7 }, new int[] { 3, 5, 7 }, new TreeNode() { val = 5, left = new() { val = 3 }, right = new() { val = 7 } } };
    }


    [Theory]
    [MemberData(nameof(FlattenTreeData))]
    public void FlattenTree
    (
        TreeNode input,
        TreeNode exp

    )
    {
        TreeTricks tree = new();
        tree.Flatten(input);
        Assert.Equal(exp, input);
    }

    public static IEnumerable<object[]> FlattenTreeData()
    {
        yield return new object[] { new TreeNode() { val = 5, left = new() { val = 3 }, right = new() { val = 7 } }, new TreeNode() { val = 5, right = new() { val = 3, right = new() { val = 7 } } } };
    }
}
