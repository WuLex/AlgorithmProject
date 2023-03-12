using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmSpace.Models.HuffmanAlg
{
    public static class HuffmanCompressor
    {

        private static HuffmanTree tree;
        public static byte[] Compress(string text)
        {
            var frequencies = new Dictionary<char, int>();
            foreach (var c in text)
            {
                if (!frequencies.ContainsKey(c))
                {
                    frequencies[c] = 0;
                }
                frequencies[c]++;
            }

            tree = new HuffmanTree(frequencies);
            var codes = tree.GetCodes();
            var compressed = new List<bool>();

            foreach (var c in text)
            {
                var code = codes[c];
                foreach (var bit in code)
                {
                    compressed.Add(bit == '1');
                }
            }

            var padding = (8 - compressed.Count % 8) % 8;
            compressed.AddRange(Enumerable.Repeat(false, padding));

            var result = new byte[compressed.Count / 8];
            for (int i = 0; i < compressed.Count; i += 8)
            {
                byte b = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (compressed[i + j])
                    {
                        b |= (byte)(1 << (7 - j));
                    }
                }
                result[i / 8] = b;
            }

            return result.Concat(BitConverter.GetBytes(padding)).ToArray();
        }

      

        public static string Decompress(byte[] compressedData)
        {
            // 解压缩数据
            var compressedBits = new List<bool>();
            foreach (var b in compressedData)
            {
                for (var i = 0; i < 8; i++)
                {
                    compressedBits.Add(((b >> i) & 1) == 1);
                }
            }
            // 解码压缩后的数据
            var currentNode = tree.Root;
            var result = "";
            foreach (var bit in compressedBits)
            {
                if (bit)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }

                if (currentNode.Left == null && currentNode.Right == null)
                {
                    result += currentNode.Char;
                    currentNode = tree.Root;
                }
            }

            return result;
        }
    }
}
