using Castle.Core.Logging;
using Castle.Windsor;
using Luna.Service.Caching;
using Luna.Service.Dependency;

namespace Luna.Service
{
    public abstract class LunaRunnerBase : IRunner
    {
        public ILogger Logger { get; set; }
        public ILunaCache Cache { get; set; }
        public readonly WindsorContainer Container;

        protected LunaRunnerBase()
        {
            Logger = NullLogger.Instance;
            Container = IocManager.Container;
        }

        public abstract void Run();

        public virtual void Stop()
        {

        }

        public virtual void Init()
        {

        }
    }
}
