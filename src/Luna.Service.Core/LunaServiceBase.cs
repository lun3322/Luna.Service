using Castle.Core.Logging;
using Castle.Windsor;
using Luna.Service.Application;
using Luna.Service.Caching;
using Luna.Service.Dependency;

namespace Luna.Service
{
    public abstract class LunaServiceBase : ILunaService
    {
        public ILogger Logger { protected get; set; }
        public ILunaCache Cache { get; set; }
        public readonly WindsorContainer Container;

        protected LunaServiceBase()
        {
            Logger = NullLogger.Instance;
            Container = IocManager.Container;
        }
    }
}
