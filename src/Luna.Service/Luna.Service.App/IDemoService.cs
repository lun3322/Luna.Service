using Luna.Service.Core.Application;

namespace Luna.Service.App
{
    public interface IDemoService : ILunaService
    {
        string GetMessage();
    }
}
