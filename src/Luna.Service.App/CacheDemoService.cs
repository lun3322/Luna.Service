using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna.Service.App
{
    public class CacheDemoService : LunaServiceBase, ICacheDemoService
    {
        private string CacheKey => "cachedemo";
        public void Add(string value)
        {
            Cache.GetCacheManager<string>(CacheKey).Add("fff", value);
        }

        public string Get()
        {
            return Cache.GetCacheManager<string>(CacheKey).Get("fff");
        }
    }
}
