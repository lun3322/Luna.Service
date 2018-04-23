using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;
using Luna.Service.Dependency;

namespace Luna.Service.Caching
{
    public interface ILunaCache : ISingletonDependency
    {
        ICacheManager<T> GetCacheManager<T>(string name);
    }
}
