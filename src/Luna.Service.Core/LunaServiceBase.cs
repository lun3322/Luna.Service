using Castle.Core.Logging;
using Luna.Service.Application;

namespace Luna.Service
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
