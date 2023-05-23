using AlgorithmSpace;
using AlgorithmSpace.Models.DFSAlg;
using AlgorithmSpace.Models.DoubleJumpList;
using AlgorithmSpace.Models.HuffmanAlg;
using AlgorithmSpace.Models.RedisJumpList;
using System.Collections;

#region 二分法查找
//int[] arr = { 1, 3, 5, 7, 9 };
//int target = 5;
//int result = BinarySearch.Search(arr, target);

//if (result == -1)
//{
//    Console.WriteLine("Element not found in array");
//}
//else
//{
//    Console.WriteLine("Element found at index " + result);
//}
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
string text = "ABABDABACDABABCABAB";
string pattern = "ABABCABAB";

int index = KMPAlgorithm.KMPSearch(text, pattern);

if (index != -1)
{
    Console.WriteLine("Pattern found at index " + index);
}
else
{
    Console.WriteLine("Pattern not found");
}
#endregion
