using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Logic
{
    public class KMPAlgorithm
    {
        // 计算模式字符串的前缀表
        public static int[] CalculatePrefixTable(string pattern)
        {
            int[] prefixTable = new int[pattern.Length];
            int i = 0, j = 1;

            while (j < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    prefixTable[j] = i + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (i != 0)
                    {
                        // 回退到上一个匹配的前缀的结束位置
                        i = prefixTable[i - 1];
                    }
                    else
                    {
                        prefixTable[j] = 0;
                        j++;
                    }
                }
            }

            return prefixTable;
        }

        // 使用KMP算法在文本字符串中搜索模式字符串
        public static int KMPSearch(string text, string pattern)
        {
            int[] prefixTable = CalculatePrefixTable(pattern);
            int i = 0, j = 0;

            while (i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        // 回退到上一个匹配的前缀的结束位置
                        j = prefixTable[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if (j == pattern.Length)
            {
                return i - j; // 返回匹配的起始索引
            }

            return -1; // 没有找到匹配的模式
        }
    }
}
