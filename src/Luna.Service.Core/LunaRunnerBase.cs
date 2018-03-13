using Castle.Core.Logging;

namespace Luna.Service
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
