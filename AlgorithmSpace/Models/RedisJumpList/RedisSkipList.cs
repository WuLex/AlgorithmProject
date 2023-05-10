namespace AlgorithmSpace.Models.RedisJumpList
{
    public class RedisSkipList<T> where T : IComparable<T>
    {
        private const int MaxLevel = 32;
        private readonly Random _random = new Random();
        private readonly double _p;
        private readonly RedisSkipListNode<T> _head;
        private int _level;
        private int _count;

        public RedisSkipList(double p = 0.25)
        {
            _p = p;
            _head = new RedisSkipListNode<T>(MaxLevel, default(T));
            _level = 1;
            _count = 0;
        }

        private int GetRandomLevel()
        {
            int level = 1;
            while (_random.NextDouble() < _p && level < MaxLevel)
            {
                level++;
            }

            return level;
        }

        public void Add(T value)
        {
            var update = new RedisSkipListNode<T>[MaxLevel];
            var cur = _head;

            for (int i = _level - 1; i >= 0; i--)
            {
                while (cur.Next[i] != null && cur.Next[i].Value.CompareTo(value) < 0)
                {
                    cur = cur.Next[i];
                }

                update[i] = cur;
            }

            cur = cur.Next[0];
            if (cur != null && cur.Value.CompareTo(value) == 0)
            {
                return;
            }

            int level = GetRandomLevel();
            if (level > _level)
            {
                for (int i = _level; i < level; i++)
                {
                    update[i] = _head;
                }

                _level = level;
            }

            var newNode = new RedisSkipListNode<T>(level, value);
            for (int i = 0; i < level; i++)
            {
                newNode.Next[i] = update[i].Next[i];
                update[i].Next[i] = newNode;
            }

            if (newNode.Next[0] != null)
            {
                newNode.Next[0].Backward = newNode;
            }

            newNode.Backward = update[0];
            _count++;
        }

        public bool Contains(T value)
        {
            var cur = _head;
            for (int i = _level - 1; i >= 0; i--)
            {
                while (cur.Next[i] != null && cur.Next[i].Value.CompareTo(value) < 0)
                {
                    cur = cur.Next[i];
                }
            }

            cur = cur.Next[0];
            if (cur != null && cur.Value.CompareTo(value) == 0)
            {
                return true;
            }

            return false;
        }

        public void Remove(T value)
        {
            var update = new RedisSkipListNode<T>[MaxLevel];
            var cur = _head;

            for (int i = _level - 1; i >= 0; i--)
            {
                while (cur.Next[i] != null && cur.Next[i].Value.CompareTo(value) < 0)
                {
                    cur = cur.Next[i];
                }

                update[i] = cur;
            }

            cur = cur.Next[0];
            if (cur != null && cur.Value.CompareTo(value) != 0)
            {
                return;
            }

            for (int i = 0; i < _level; i++)
            {
                if (update[i].Next[i] != cur)
                {
                    break;
                }

                update[i].Next[i] = cur.Next[i];
            }

            if (cur.Next[0] != null)
            {
                cur.Next[0].Backward = cur.Backward;
            }

            while (_level > 1 && _head.Next[_level - 1] == null)
            {
                _level--;
            }

            _count--;
        }

        public void Print()
        {
            for (int i = _level - 1; i >= 0; i--)
            {
                var cur = _head;
                while (cur.Next[i] != null)
                {
                    Console.Write(cur.Next[i].Value + " ");
                    cur = cur.Next[i];
                }

                Console.WriteLine();
            }
        }
    }
}