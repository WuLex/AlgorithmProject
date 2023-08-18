using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RedisPreventCachePenetration
{
    // 缓存处理类
    public class CacheHelper
    {
        private Dictionary<string, string> cacheData;
        private BloomFilter bloomFilter;

        public CacheHelper()
        {
            cacheData = new Dictionary<string, string>();
            bloomFilter = new BloomFilter(10000, 0.01); // 设置布隆过滤器容量和误判率
        }

        // 获取缓存数据
        public string Get(string key)
        {
            // 先检查布隆过滤器，如果元素可能不存在于缓存，则直接返回空值
            if (!bloomFilter.MightContain(key))
            {
                return null;
            }

            if (cacheData.ContainsKey(key))
            {
                return cacheData[key];
            }
            else
            {
                // 此处可以查询后端存储，并将结果加入缓存中
                // 如果查询结果为空，也将其加入缓存，并设置适当的失效时间
                cacheData[key] = string.Empty;
                return null;
            }
        }

        // 添加缓存数据
        public void Add(string key, string value)
        {
            cacheData[key] = value;
            bloomFilter.Add(key);
        }
    }
}
