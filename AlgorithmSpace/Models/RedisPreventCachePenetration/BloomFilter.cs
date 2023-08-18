using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RedisPreventCachePenetration
{
    // 布隆过滤器
    public class BloomFilter
    {
        private BitArray bitArray;
        private int hashFunctionsCount;

        public BloomFilter(int capacity, double falsePositiveRate)
        {
            // 计算所需的位数组长度
            int bitArrayLength = (int)Math.Ceiling(-capacity * Math.Log(falsePositiveRate) / Math.Pow(Math.Log(2), 2));
            bitArray = new BitArray(bitArrayLength);

            // 计算所需的哈希函数数量
            hashFunctionsCount = (int)Math.Ceiling(bitArrayLength * Math.Log(2) / capacity);
        }

        // 添加元素到布隆过滤器
        public void Add(string element)
        {
            for (int i = 0; i < hashFunctionsCount; i++)
            {
                int hash = Hash(element, i);
                bitArray[hash] = true;
            }
        }

        // 判断元素是否可能存在于布隆过滤器
        public bool MightContain(string element)
        {
            for (int i = 0; i < hashFunctionsCount; i++)
            {
                int hash = Hash(element, i);
                if (!bitArray[hash])
                {
                    return false;
                }
            }
            return true;
        }

        // 哈希函数
        private int Hash(string element, int index)
        {
            // 这里可以使用多种哈希算法进行计算，例如MD5、SHA1等
            int hash = (element + index.ToString()).GetHashCode();
            return Math.Abs(hash) % bitArray.Length;
        }
    }

}
