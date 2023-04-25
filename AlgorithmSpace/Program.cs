using AlgorithmSpace;
using AlgorithmSpace.Models.DFSAlg;
using AlgorithmSpace.Models.HuffmanAlg;

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
// 构建网状图
Graph graph = new Graph();
graph.AddNode(1, new List<int> { 2, 3, 4 });
graph.AddNode(2, new List<int> { 1, 5 });
graph.AddNode(3, new List<int> { 1, 5 });
graph.AddNode(4, new List<int> { 1, 6 });
graph.AddNode(5, new List<int> { 2, 3, 7 });
graph.AddNode(6, new List<int> { 4, 7 });
graph.AddNode(7, new List<int> { 5, 6 });

// 输出网状图
// 输出网状图
Console.WriteLine("BFS traversal:");
graph.BFS(1); // 从节点1开始广度优先搜索并输出
#endregion


