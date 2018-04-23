using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;

namespace Luna.Service
{
    public class StarterOption
    {
        public bool DisableAudit { get; set; }
        public ICacheManagerConfiguration CacheManagerConfiguration { get; set; }
    }
}
