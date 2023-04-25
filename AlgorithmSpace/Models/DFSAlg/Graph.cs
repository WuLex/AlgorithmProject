namespace AlgorithmSpace.Models.DFSAlg
{
    /// <summary>
    /// 广度优先遍历
    ///
    /// 在遍历过程中，先将起始节点加入到 visited 和 queue 中，
    /// 然后通过不断出队列的方式遍历队列中的节点，并将其邻居节点加入到队列中
    /// </summary>
    internal class Graph
    {
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // 添加节点和其邻居
        public void AddNode(int node, List<int> neighbours)
        {
            adjacencyList[node] = neighbours;
        }

        // 广度优先搜索遍历
        public void BFS(int start)
        {
            //用于存储已访问过的节点的哈希集合
            HashSet<int> visited = new HashSet<int>();
            //用于存储待访问节点的队列
            Queue<int> queue = new Queue<int>();

            // 标记当前节点为已访问
            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                // 从队列中取出下一个待访问节点
                int current = queue.Dequeue();
                Console.Write(current + " "); // 输出当前节点
                if (adjacencyList.ContainsKey(current)) // 检查当前节点是否有邻居节点
                {
                    // 遍历当前节点的邻居节点列表
                    foreach (var neighbour in adjacencyList[current])
                    {
                        // 检查邻居节点是否已被访问过
                        if (!visited.Contains(neighbour))
                        {
                            visited.Add(neighbour);// 将未访问过的邻居节点添加到已访问节点集合中
                            queue.Enqueue(neighbour);// 将未访问过的邻居节点加入到待访问节点队列中，以便后续访问其邻居节点
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// 深度优先遍历
    /// </summary>
    //class Graph
    //{
    //    private Dictionary<int, List<int>> adjacencyList;

    //    public Graph()
    //    {
    //        adjacencyList = new Dictionary<int, List<int>>();
    //    }

    //    // 添加节点和其邻居
    //    public void AddNode(int node, List<int> neighbours)
    //    {
    //        adjacencyList[node] = neighbours;
    //    }

    //    // 深度优先搜索遍历
    //    public void DFS(int start, HashSet<int> visited)
    //    {
    //        // 如果节点已被访问过，则直接返回
    //        if (visited.Contains(start))
    //        {
    //            return;
    //        }

    //        // 标记当前节点为已访问
    //        visited.Add(start);
    //        Console.Write(start + " "); // 输出当前节点

    //        // 递归访问邻居节点
    //        foreach (var neighbour in adjacencyList[start])
    //        {
    //            DFS(neighbour, visited);
    //        }
    //    }

    //    // 搜索图并输出
    //    public void SearchGraph(int start)
    //    {
    //        HashSet<int> visited = new HashSet<int>();
    //        DFS(start, visited);
    //        Console.WriteLine();
    //    }
    //}
}