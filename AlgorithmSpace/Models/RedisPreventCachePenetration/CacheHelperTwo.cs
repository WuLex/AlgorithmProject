using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Models.RedisPreventCachePenetration
{
    public class CacheHelperTwo
    {
        private Dictionary<string, string> cacheData;

        public CacheHelperTwo()
        {
            cacheData = new Dictionary<string, string>();
        }

        // 获取缓存数据
        public string Get(string key)
        {
            if (cacheData.ContainsKey(key))
            {
                return cacheData[key];
            }

            // 如果缓存中不存在该键，则返回空值
            return null;
        }

        // 添加缓存数据
        public void Add(string key, string value)
        {
            cacheData[key] = value;
        }
    }
}
