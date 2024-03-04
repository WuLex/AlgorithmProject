using AlgorithmSpace;
using AlgorithmSpace.Models.ConsistentHashAlg;
using AlgorithmSpace.Models.DFSAlg;
using AlgorithmSpace.Models.DoubleJumpList;
using AlgorithmSpace.Models.HuffmanAlg;
using AlgorithmSpace.Models.RedisJumpList;
using AlgorithmSpace.Models.RedisPreventCachePenetration;
using AlgorithmSpace.Models.EightQueensAlg;
using System.Collections;
using AlgorithmSpace.Models.ELOAlg;
using AlgorithmSpace.Models.RTreeAlg;
using AlgorithmSpace.Logic;

#region 二分法查找
int[] arr = { 1, 3, 5, 7, 9 };
int target = 5;
int result = BinarySearch.Search(arr, target);

if (result == -1)
{
    Console.WriteLine("Element not found in array");
}
else
{
    Console.WriteLine("Element found at index " + result);
}
#endregion

#region 哈夫曼树使用示例
// 使用示例
//var originalText = "This is a test string to be compressed using Huffman encoding";
//var compressedBytes = HuffmanCompressor.Compress(originalText);
//var compressedText = Convert.ToBase64String(compressedBytes);
//var decompressedText = HuffmanCompressor.Decompress(Convert.FromBase64String(compressedText));
//Console.WriteLine(originalText);
//Console.WriteLine(compressedText);
//Console.WriteLine(decompressedText);
#endregion

#region 搜索图
//// 构建网状图
//Graph graph = new Graph();
//graph.AddNode(1, new List<int> { 2, 3, 4 });
//graph.AddNode(2, new List<int> { 1, 5 });
//graph.AddNode(3, new List<int> { 1, 5 });
//graph.AddNode(4, new List<int> { 1, 6 });
//graph.AddNode(5, new List<int> { 2, 3, 7 });
//graph.AddNode(6, new List<int> { 4, 7 });
//graph.AddNode(7, new List<int> { 5, 6 });

//// 输出网状图
//// 输出网状图
//Console.WriteLine("BFS traversal:");
//graph.BFS(1); // 从节点1开始广度优先搜索并输出
#endregion

#region Bloom Filter是一种快速检索数据集合的算法，它能够判断某个元素是否在集合中，具有高效、节省内存等优点，但有一定的误判率。
/*int size = 1000000;
int[] seeds = { 3, 5, 7, 11, 13, 17 };
BloomFilter bloomFilter = new BloomFilter(size, seeds);

bloomFilter.Add("hello");
bloomFilter.Add("world");

Console.WriteLine(bloomFilter.Contains("hello")); // true
Console.WriteLine(bloomFilter.Contains("world")); // true
Console.WriteLine(bloomFilter.Contains("foo")); // false
                                                //在这个示例中，BloomFilter类包含了一个BitArray，用于存储元素是否存在的信息，以及一个哈希种子数组seeds，
                                                //用于生成哈希值。在构造函数中，我们指定了Bloom filter的大小和哈希种子。Add方法用于将元素添加到Bloom filter中，
                                                //而Contains方法用于检查元素是否存在。GetHash方法用于生成哈希值。
                                                //我们可以通过调整Bloom filter的大小和哈希种子数量来平衡误判率和空间使用。在实际应用中，
                                                //我们可以根据数据集的大小和预期的误判率来选择适当的参数。
*/
#endregion

#region 双层跳跃链表
/*
var list = new SkipList<int>();
list.Add(1);
list.Add(3);
list.Add(2);

Console.WriteLine($"List contains 1: {list.Contains(1)}"); // true
Console.WriteLine($"List contains 2: {list.Contains(2)}"); // true
Console.WriteLine($"List contains 3: {list.Contains(3)}"); // true
Console.WriteLine($"List contains 4: {list.Contains(4)}"); // false
Console.WriteLine($"List count: {list.Count}"); // 3

list.Remove(2);

Console.WriteLine($"List contains 1: {list.Contains(1)}"); // true
Console.WriteLine($"List contains 2: {list.Contains(2)}"); // false
Console.WriteLine($"List contains 3: {list.Contains(3)}"); // true
Console.WriteLine($"List contains 4: {list.Contains(4)}"); // false
Console.WriteLine($"List count: {list.Count}"); // 2

//首先创建了一个双层跳跃链表对象list。然后使用Add方法向链表中添加三个整数元素。
//    接下来分别使用Contains方法判断链表中是否包含1、2、3和4这四个整数。
//    最后使用Remove方法从链表中删除2这个整数。在每个操作后，都打印出链表中元素的状态，以及链表的计数器值。
*/
#endregion

#region 模拟实现Redis跳跃链表结构
/*
var skipList = new RedisSkipList<int>();
skipList.Add(3);
skipList.Add(1);
skipList.Add(4);
skipList.Add(2);
skipList.Add(5);
skipList.Print(); // 输出：1 2 3 4 5
skipList.Remove(4);
skipList.Print(); // 输出：1 2 3 5
Console.WriteLine(skipList.Contains(3)); // 输出：True
Console.WriteLine(skipList.Contains(4)); // 输出：False
                                         //以上示例中，我们定义了`RedisSkipListNode`类表示跳跃链表的节点，包含`Value`、`Next`和`Backward`属性，
                                         //其中`Value`表示节点的值，`Next`表示该节点在每一层的下一个节点，`Backward`表示该节点在第 0 层的前一个节点。
                                         //我们还定义了`RedisSkipList`类表示跳跃链表，包含`MaxLevel`、`_random`、`_p`、`_head`、`_level`和`_count`字段和方法。

//`MaxLevel`表示跳跃链表的最大层数，`_random`表示一个随机数生成器，`_p`表示每一层生成新节点的概率，`_head`表示头节点，
//    `_level`表示跳跃链表的层数，`_count`表示跳跃链表的节点数。`GetRandomLevel`方法用于生成新节点的随机层数，
//    `Add`方法用于向跳跃链表中添加一个节点，`Contains`方法用于判断跳跃链表中是否包含某个值，
//    `Remove`方法用于从跳跃链表中移除一个节点，`Print`方法用于打印跳跃链表的所有节点。

//在主函数中，我们创建了一个`RedisSkipList`对象，并向其中添加了一些节点，然后打印跳跃链表的所有节点。
//    接着，我们从跳跃链表中移除一个节点，并再次打印跳跃链表的所有节点。
//    最后，我们判断跳跃链表中是否包含某些值，并将结果打

*/
#endregion

#region KMP算法 
//CalculatePrefixTable方法用于计算模式字符串的前缀表（prefix table），
//KMPSearch方法使用KMP算法在给定的文本字符串中搜索模式字符串。
//string text = "ABABDABACDABABCABAB";
//string pattern = "ABABCABAB";

//int index = KMPAlgorithm.KMPSearch(text, pattern);

//if (index != -1)
//{
//    Console.WriteLine("Pattern found at index " + index);
//}
//else
//{
//    Console.WriteLine("Pattern not found");
//}
#endregion

#region R-Tree算法
//double searchLatitude = 37.7749;
//double searchLongitude = -122.4194;
//double searchRadius = 2.0;

//RTreeHelper.RunRTreeSearch(searchLatitude, searchLongitude, searchRadius);
//RTreeHelper.RunRTreeTestData();
#endregion

#region 防止Redis缓存穿透:布隆过滤器
//CacheHelper cachehelepr = new CacheHelper();
//// 添加缓存数据
//cachehelepr.Add("key1", "value1");
//cachehelepr.Add("key2", "");

//// 获取缓存数据
//string value1 = cachehelepr.Get("key1"); // 存在于缓存中
//Console.WriteLine("Value1: " + value1); // 输出：Value1: value1

//string value3 = cachehelepr.Get("key3"); // 不存在于缓存中
//Console.WriteLine("Value3: " + value3); // 输出：Value3: 

//string value2 = cachehelepr.Get("key2"); // 存在于缓存中，但为缓存空值
//Console.WriteLine("Value2: " + value2); // 输出：Value2:
#endregion

#region 防止Redis缓存穿透:保存空值
//CacheHelperTwo cache = new CacheHelperTwo();

//// 模拟将数据库查询的结果加入缓存
//string dbResult = null; // 假设数据库中不存在该数据
//if (dbResult != null)
//{
//    cache.Add("key1", dbResult);
//}
//else
//{
//    // 将空值添加到缓存，并设置适当的失效时间
//    cache.Add("key1", string.Empty);
//}

//// 获取缓存数据
//string value1 = cache.Get("key1");
//Console.WriteLine("Value1: " + value1); // 输出：Value1:

//string value2 = cache.Get("key2"); // 不存在于缓存中
//Console.WriteLine("Value2: " + value2); // 输出：Value2: 
#endregion

#region 一致性哈希算法
////node => node 这是一个函数，用于将节点转换为其键。在这个示例中，
////它实际上不对节点进行任何转换，直接将节点自身作为键。
////这意味着节点的名称本身就是它们在哈希环上的标识符。
//// 创建一致性哈希对象
//var consistentHash = new ConsistentHash<string>(100, node => node);

//// 添加节点
//consistentHash.Add("Node1");
//consistentHash.Add("Node2");
//consistentHash.Add("Node3");
//for (int i = 0; i < 10; i++)
//{
//    string key = $"key{i}";
//    // 查找键对应的节点
//    string node = consistentHash.GetNode(key);
//    Console.WriteLine($"Key'{key}'映射到节点'{node}'。");
//}
//#region 反向查找逻辑，查找节点对应的键
//string nodeToFind = "Node2";
//var keys = consistentHash.GetKeysForNode(nodeToFind);
//Console.WriteLine($"'{nodeToFind}'节点上有映射的Keys集合 :");
//foreach (var key in keys)
//{
//   Console.WriteLine(key);
//}

//#endregion

//// 删除节点Node2
//consistentHash.Remove("Node2");
//#region 删除节点Node2后,再次映射
//for (int i = 0; i < 10; i++)
//{
//    string key = $"secondkey{i}";
//    // 查找键对应的节点
//    string node = consistentHash.GetNode(key);
//    Console.WriteLine($"Secondkey'{key}'映射到节点'{node}'。");
//}

//string secondnodeToFind = "Node3";
//var secondkeys = consistentHash.GetKeysForNode(secondnodeToFind);
//Console.WriteLine($"'{secondnodeToFind}'节点上有映射的Secondkeys集合 :");
//foreach (var key in secondkeys)
//{
//    Console.WriteLine(key);
//}
//#endregion

#endregion

#region 八皇后算法
//在 SolveQueens(0) 中的0表示开始放置皇后的行号。
//这里的0意味着从第一行（索引为0的行）开始尝试放置皇后。
//递归函数 SolveQueens 通过不断增加 row 的值来逐行放置皇后。
//你可以使用不同的行号作为参数调用 SolveQueens，
//例如 SolveQueens(1) 或 SolveQueens(2)，
//以从棋盘的不同行开始寻找解决方案。但通常情况下，
//我们从第一行开始（row = 0）来寻找八皇后问题的解决方案，
//因为这是问题的标准起点。
//EightQueens.SolveQueens(0);
//Console.WriteLine("共有解决方案数量: " + EightQueens.solutionCount);

#endregion

#region 王者荣耀（或其他竞技游戏）的匹配算法通常基于ELO算法
//Matchmaking matchmaking = new Matchmaking();

//Player player1 = new Player(1, 1000);
//Player player2 = new Player(2, 1000);
//Player player3 = new Player(3, 1000);

//matchmaking.AddPlayer(player1);
//matchmaking.AddPlayer(player2);
//matchmaking.AddPlayer(player3);

//// 玩家1与玩家2匹配，玩家1赢得比赛
//matchmaking.MatchPlayers(player1, player2, true);

//// 输出更新后的ELO等级
//Console.WriteLine($"Player 1 ELO: {player1.Elo}");
//Console.WriteLine($"Player 2 ELO: {player2.Elo}");

//// 玩家1与玩家3匹配，玩家3赢得比赛
//matchmaking.MatchPlayers(player1, player3, false);

//// 输出更新后的ELO等级
//Console.WriteLine($"Player 1 ELO: {player1.Elo}");
//Console.WriteLine($"Player 3 ELO: {player3.Elo}");


//Player playerONE = new Player(1, 1200);
//Player playerTWO = new Player(2, 1000);

//// 玩家1赢得比赛
//EloCalculator.UpdateRatings(playerONE, playerTWO, true);

//Console.WriteLine($"玩家1新的ELO分数：{playerONE.Elo}");
//Console.WriteLine($"玩家2新的ELO分数：{playerTWO.Elo}");
#endregion