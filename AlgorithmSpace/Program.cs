using AlgorithmSpace;
using AlgorithmSpace.Models.HuffmanAlg;

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
var originalText = "This is a test string to be compressed using Huffman encoding";
var compressedBytes = HuffmanCompressor.Compress(originalText);
var compressedText = Convert.ToBase64String(compressedBytes);
var decompressedText = HuffmanCompressor.Decompress(Convert.FromBase64String(compressedText));
Console.WriteLine(originalText);
Console.WriteLine(compressedText);
Console.WriteLine(decompressedText);
#endregion