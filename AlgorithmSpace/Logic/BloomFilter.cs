using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Logic
{
    public class BloomFilter
    {
        private BitArray bitArray;
        private int size;
        private int[] seeds;

        public BloomFilter(int size, int[] seeds)
        {
            this.size = size;
            bitArray = new BitArray(size);
            this.seeds = seeds;
        }

        public void Add(string value)
        {
            foreach (int seed in seeds)
            {
                int hash = GetHash(value, seed);
                bitArray[hash] = true;
            }
        }

        public bool Contains(string value)
        {
            foreach (int seed in seeds)
            {
                int hash = GetHash(value, seed);
                if (!bitArray[hash])
                {
                    return false;
                }
            }
            return true;
        }

        private int GetHash(string value, int seed)
        {
            int hash = seed;
            foreach (char c in value)
            {
                hash = hash * 31 + c;
            }
            return Math.Abs(hash) % size;
        }
    }
}
