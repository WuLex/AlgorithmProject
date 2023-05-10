using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.DoubleJumpList
{
    public class SkipList<T> where T : IComparable<T>
    {
        private readonly Random _random = new Random();
        private readonly double _p;
        private SkipListNode<T> _head;
        private int _count;

        public SkipList(double p = 0.5)
        {
            _p = p;
            _head = new SkipListNode<T>(default(T));
            _count = 0;
        }

        public void Add(T value)
        {
            var newNode = new SkipListNode<T>(value);
            var cur = _head;
            var stack = new Stack<SkipListNode<T>>();
            while (cur != null)
            {
                if (cur.Next == null || cur.Next.Value.CompareTo(value) > 0)
                {
                    stack.Push(cur);
                    cur = cur.Down;
                }
                else
                {
                    cur = cur.Next;
                }
            }

            SkipListNode<T> downNode = null;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var newNodeCopy = new SkipListNode<T>(value, node.Next, downNode);
                node.Next = newNodeCopy;
                downNode = newNodeCopy;

                if (_random.NextDouble() < _p)
                {
                    break;
                }
            }

            if (downNode != null)
            {
                _head = new SkipListNode<T>(default(T), null, _head);
                _head.Next = new SkipListNode<T>(default(T), downNode, _head.Next);
            }

            _count++;
        }

        public bool Contains(T value)
        {
            var cur = _head;
            while (cur != null)
            {
                if (cur.Next == null || cur.Next.Value.CompareTo(value) > 0)
                {
                    cur = cur.Down;
                }
                else if (cur.Next.Value.CompareTo(value) == 0)
                {
                    return true;
                }
                else
                {
                    cur = cur.Next;
                }
            }

            return false;
        }

        public void Remove(T value)
        {
            var cur = _head;
            var stack = new Stack<SkipListNode<T>>();
            while (cur != null)
            {
                if (cur.Next == null || cur.Next.Value.CompareTo(value) > 0)
                {
                    stack.Push(cur);
                    cur = cur.Down;
                }
                else if (cur.Next.Value.CompareTo(value) == 0)
                {
                    cur.Next = cur.Next.Next;
                    while (cur.Down != null)
                    {
                        cur = cur.Down;
                        var prev = stack.Pop();
                        prev.Next = cur.Next;
                    }

                    _count--;
                    return;
                }
                else
                {
                    cur = cur.Next;
                }
            }
        }

        public int Count => _count;
    }
}
