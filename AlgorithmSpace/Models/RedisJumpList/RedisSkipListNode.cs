using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RedisJumpList
{
    public class RedisSkipListNode<T>
    {
        public T Value { get; set; }
        public RedisSkipListNode<T>[] Next { get; set; }
        public RedisSkipListNode<T> Backward { get; set; }

        public RedisSkipListNode(int level, T value, RedisSkipListNode<T> backward = null)
        {
            Value = value;
            Next = new RedisSkipListNode<T>[level];
            Backward = backward;
        }
    }
}
