using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.ConsistentHashAlg
{
    /// <summary>
    /// 我们创建了一个ConsistentHash<T>类，其中T是节点类型的泛型参数。
    ///ring是一个SortedDictionary，用于维护一致性哈希环，其中键是节点的哈希值，值是节点本身。
    ///构造函数接受副本数和一个委托keySelector，该委托用于将节点映射到其键。
    ///Add方法用于将节点添加到哈希环上，我们为每个节点创建多个虚拟节点，以增加一致性。
    ///Remove方法从哈希环中删除节点。
    ///GetNode方法根据给定的键查找对应的节点。
    ///ComputeHash方法使用SHA256哈希函数计算字符串的哈希值。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConsistentHash<T>
    {
        // 用于存储哈希环上的节点
        private readonly SortedDictionary<int, T> ring = new SortedDictionary<int, T>();

        //修改一致性哈希类以支持反向查找。这需要维护一个额外的字典，将节点映射回其键。
        private readonly SortedDictionary<T, List<string>> KeysForNode = new SortedDictionary<T, List<string>>();


        // 副本数控制每个节点在哈希环上的虚拟节点数量
        private readonly int replicaCount;

        // 用于将节点映射到其键的委托
        private readonly Func<T, string> keySelector;

        public ConsistentHash(int replicaCount, Func<T, string> keySelector)
        {
            this.replicaCount = replicaCount;
            this.keySelector = keySelector;
        }

        // 添加节点到哈希环
        public void Add(T node)
        {
            for (int i = 0; i < replicaCount; i++)
            {
                string virtualNodeKey = $"{keySelector(node)}_{i}";
                int hash = ComputeHash(virtualNodeKey);
                ring[hash] = node; 
            }
            //#region 反向查找逻辑--1，非必需逻辑可删除
            if (!KeysForNode.ContainsKey(node))
            {
                KeysForNode[node] = new List<string>();
            }
            //KeysForNode[node].Add(Convert.ToString(node)??"");
            //#endregion

        }

        // 从哈希环中删除节点
        public void Remove(T node)
        {
            for (int i = 0; i < replicaCount; i++)
            {
                string virtualNodeKey = $"{keySelector(node)}_{i}";
                int hash = ComputeHash(virtualNodeKey);

                ring.Remove(hash);

                #region 反向查找逻辑--2，非必需逻辑可删除
                // 从 KeysForNode 字典中删除键
                if (KeysForNode.ContainsKey(node))
                {
                    KeysForNode[node].Remove(virtualNodeKey);
                    if (KeysForNode[node].Count == 0)
                    {
                        KeysForNode.Remove(node);
                    }
                }
                #endregion
            }


        }

        // 查找给定键对应的节点
        public T GetNode(string key)
        {
            if (ring.Count == 0)
                throw new InvalidOperationException("No nodes available.");

            int hash = ComputeHash(key);

            // 找到第一个哈希大于或等于键的哈希的节点
            foreach (var kvp in ring)
            {
                if (kvp.Key >= hash)
                {
                    #region 反向查找逻辑--3，非必需逻辑可删除
                    // 在 KeysForNode 字典中添加键
                    if (KeysForNode.ContainsKey(kvp.Value))
                    {
                        KeysForNode[kvp.Value].Add(key);
                    }
                    #endregion
                    return kvp.Value;
                }
            }
           
            // 如果需要，循环回第一个节点
            var firstNode = ring.First().Value;
            #region 反向查找逻辑--3，非必需逻辑可删除
            if (KeysForNode.ContainsKey(firstNode))
            {
                KeysForNode[firstNode].Add(key);
            }
            #endregion

            return firstNode;
        }

        #region 反向查找逻辑-3，非必需逻辑
        /// <summary>
        /// 查找给定节点对应的键集合
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        // 查找给定节点对应的键集合
        public IEnumerable<string> GetKeysForNode(T node)
        {
            if (KeysForNode.ContainsKey(node))
            {
                return KeysForNode[node];
            }
            return Enumerable.Empty<string>();
        }
        #endregion

        // 使用SHA256计算字符串的哈希值
        private int ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToInt32(hashBytes, 0);
            }
        }
    }
}
