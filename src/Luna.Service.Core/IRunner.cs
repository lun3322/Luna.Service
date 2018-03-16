using Luna.Service.Dependency;

namespace Luna.Service
{
    public interface IRunner : ISingletonDependency
    {
        void Run();
        void Stop();
    }
}