using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;
using CacheManager.Serialization.Json;
using Castle.Core.Logging;

namespace Luna.Service.Caching
{
    public class LunaCache : ILunaCache
    {
        private ConcurrentDictionary<string, object> Caches { get; set; }
        private readonly StarterOption _starterOption;

        public LunaCache(StarterOption starterOption)
        {
            _starterOption = starterOption;
            Caches = new ConcurrentDictionary<string, object>();
        }

        public ICacheManager<T> GetCacheManager<T>(string name)
        {
            var cfg = _starterOption.CacheManagerConfiguration ?? ConfigurationBuilder.BuildConfiguration(settings =>
            {
                settings.WithUpdateMode(CacheUpdateMode.Up)
                    .WithSerializer(typeof(JsonCacheSerializer))
                    .WithSystemRuntimeCacheHandle()
                    .WithExpiration(ExpirationMode.Absolute, TimeSpan.FromMinutes(5));
            });

            return Caches.GetOrAdd(name, key => CacheFactory.FromConfiguration(typeof(T), cfg)) as ICacheManager<T>;
        }
    }
}
