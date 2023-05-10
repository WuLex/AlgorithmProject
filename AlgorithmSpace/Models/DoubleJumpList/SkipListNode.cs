using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DoubleJumpList
{
    public class SkipListNode<T>
    {
        public T Value { get; set; }
        public SkipListNode<T> Next { get; set; }
        public SkipListNode<T> Down { get; set; }

        public SkipListNode(T value, SkipListNode<T> next = null, SkipListNode<T> down = null)
        {
            Value = value;
            Next = next;
            Down = down;
        }
    }

    
}
