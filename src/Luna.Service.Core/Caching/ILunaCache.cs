using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;

namespace Luna.Service.Caching
{
    public interface ILunaCache
    {
        ICacheManager<T> GetCacheManager<T>(string name);
    }
}
