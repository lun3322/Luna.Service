using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Luna.Service.Core.Application;

namespace Luna.Service.Core
{
    public abstract class LunaServiceBase : ILunaService
    {
        public ILogger Logger { protected get; set; }

        protected LunaServiceBase()
        {
            Logger = NullLogger.Instance;
        }
    }
}
