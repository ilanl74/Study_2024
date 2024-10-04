using System;

namespace Leet;

public class Graph
{
    /*
    210. Course Schedule II

    Example 1:
    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: [0,1]
    Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

    Example 2:
    Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
    Output: [0,2,1,3]
    Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
    So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

    Example 3:
    Input: numCourses = 1, prerequisites = []
    Output: [0]


    the point here is to represent the graph and what is the root of the graph and teh deferent levels of it 
    for that we have 
    a dictionary that holds source as key destinations list as value 
    an array to represent the level of dependencies  (int[] indegree = new int[numCourses];)
    to fill it we use the location so destination (the first from the left of the 2 argument array) 3 will [0,0,0,1] and so on 
    next we will take all the 0 level and add them to a queue 
    dequeue from the q we will add the the ans and 
    and the map that 
    */

    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        int[] level = new int[numCourses];
        int[] ans = new int[numCourses];
        Dictionary<int, List<int>> sourceToDest = new Dictionary<int, List<int>>(numCourses);
        for (var i = 0; i < prerequisites.Length; i++) // level is determined by the dest , mapping from source to dest is done as well 
        {
            var list = sourceToDest.GetValueOrDefault(prerequisites[i][1], new List<int>(numCourses));// dest is 0 position , source is 1 position 
            if (!sourceToDest.ContainsKey(prerequisites[i][1]))
                sourceToDest.Add(prerequisites[i][1], list);
            list.Add(prerequisites[i][0]);
            level[prerequisites[i][0]]++;
        }
        Queue<int> path = new(numCourses);
        for (var i = 0; i < level.Length; i++)
        {
            if (level[i] == 0)
            {
                path.Enqueue(i);
            }
        }
        int index = 0;
        while (path.Any())
        {
            ans[index] = path.Dequeue();
            if (sourceToDest.ContainsKey(ans[index]))
            {
                foreach (var i in sourceToDest[ans[index]])
                {
                    level[i]--;
                    if (level[i] == 0)
                    {
                        path.Enqueue(i);
                    }
                }
            }

            index++;
        }
        if (index == numCourses)
            return ans;
        return Array.Empty<int>();

    }

    //Leet 133. Clone Graph
    /*
    Given a reference of a node in a connected undirected graph.
    Return a deep copy (clone) of the graph.

    Example 1:
    Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
    Output: [[2,4],[1,3],[2,4],[1,3]]
    Explanation: There are 4 nodes in the graph.
    1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
    3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
    4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

    Example 2:
    Input: adjList = [[]]
    Output: [[]]
    Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.

    Example 3:

    Input: adjList = []
    Output: []
    Explanation: This an empty graph, it does not have any nodes.
    */
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        Dictionary<int, Node> map = new();
        return RecCloneGraph(node, map);
    }

    private Node RecCloneGraph(Node node, Dictionary<int, Node> map)
    {
        Node newNode = null;
        if (map.ContainsKey(node.val))
            return map[node.val];
        else
        {
            newNode = new(node.val);
            map.Add(node.val, newNode);
        }
        foreach (var n in node.neighbors)
        {
            newNode.neighbors.Add(RecCloneGraph(n, map));
        }

        return newNode;
    }
}
