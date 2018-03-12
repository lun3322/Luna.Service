using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;

namespace Luna.Service.Core
{
    public abstract class LunaRunnerBase : IRunner
    {
        public ILogger Logger { protected get; set; }

        protected LunaRunnerBase()
        {
            Logger = NullLogger.Instance;
        }

        public abstract void Run();
    }
}
