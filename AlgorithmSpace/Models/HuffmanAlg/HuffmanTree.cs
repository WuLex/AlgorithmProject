using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.HuffmanAlg
{
    public class HuffmanTree
    {
        public HuffmanNode Root { get; private set; }

        public HuffmanTree(Dictionary<char, int> frequencies)
        {
            var priorityQueue = new SortedSet<HuffmanNode>(Comparer<HuffmanNode>.Create((a, b) => a.Frequency - b.Frequency));
            foreach (var entry in frequencies)
            {
                priorityQueue.Add(new HuffmanNode { Char = entry.Key, Frequency = entry.Value });
            }

            while (priorityQueue.Count > 1)
            {
                var left = priorityQueue.Min;
                priorityQueue.Remove(left);
                var right = priorityQueue.Min;
                priorityQueue.Remove(right);

                var parent = new HuffmanNode { Frequency = left.Frequency + right.Frequency, Left = left, Right = right };
                priorityQueue.Add(parent);
            }

            Root = priorityQueue.Single();
        }

        public Dictionary<char, string> GetCodes()
        {
            var codes = new Dictionary<char, string>();
            Traverse(Root, "", codes);
            return codes;
        }

        private static void Traverse(HuffmanNode node, string code, Dictionary<char, string> codes)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left == null && node.Right == null)
            {
                codes[node.Char] = code;
            }

            Traverse(node.Left, code + "0", codes);
            Traverse(node.Right, code + "1", codes);
        }
    }
}
